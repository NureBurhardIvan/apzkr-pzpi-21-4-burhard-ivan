using System.Threading.Tasks;
using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BackupController : BaseApiController
{
    private IBackupService _backupService;
    public BackupController(IBackupService backupService)
    {
        _backupService = backupService;
    }

    [HttpGet]
    public async Task<IActionResult> Backup()
    {
        await _backupService.SaveToCsv("./");
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Restore()
    {
        await _backupService.RestoreFromCsv("./");
        return Ok();
    }
}