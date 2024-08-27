using Application.Common.Interfaces.Repositories;

namespace WebAPI.Controllers;

public class StatController : BaseApiController
{
    private IStatRepository _statRepository;
    public StatController(IStatRepository statRepository)
    {
        _statRepository = statRepository;
    }
}