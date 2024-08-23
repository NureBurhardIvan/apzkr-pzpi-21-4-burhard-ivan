using System;
using System.Globalization;
using Application.Common.Interfaces.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

namespace Infrastructure.Services;

public class BackupService : IBackupService
{
    private readonly ApplicationDbContext _context;

    public BackupService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveToCsv(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        var entityTypes = _context.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var entityName = entityType.ClrType.Name;
            var filePath = Path.Combine(directoryPath, $"{entityName}.csv");
            
            var dbSetProperty = _context.GetType().GetProperty(entityName + "s");
            if (dbSetProperty == null) continue;
            
            var dbSet = dbSetProperty.GetValue(_context);
            var queryable = dbSet as IQueryable<object>;
            if (queryable == null) return;

            var entities = await queryable.ToListAsync();

            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            await csv.WriteRecordsAsync(entities);
        }
    }

    public async Task RestoreFromCsv(string directoryPath)
    {
        var entityTypes = _context.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var entityName = entityType.ClrType.Name;
            var filePath = Path.Combine(directoryPath, $"{entityName}.csv");

            if (!File.Exists(filePath)) continue;

            var dbSetProperty = _context.GetType().GetProperty(entityName + "s");
            if (dbSetProperty == null) continue;

            var dbSet = dbSetProperty.GetValue(_context);
            
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var entityListType = typeof(List<>).MakeGenericType(entityType.ClrType);
            var entities = (IList)Activator.CreateInstance(entityListType);

            var records = csv.GetRecords(entityType.ClrType);
            foreach (var record in records)
            {
                entities.Add(record);
            }
            
            var addRangeMethod = dbSet.GetType().GetMethod("AddRange", new[] { typeof(IEnumerable<>).MakeGenericType(entityType.ClrType) });
            if (addRangeMethod != null)
            {
                addRangeMethod.Invoke(dbSet, new object[] { entities });
            }
            
            await _context.SaveChangesAsync();
        }
    }
}