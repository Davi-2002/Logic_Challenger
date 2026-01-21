using Logic_Challenger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logic_Challenger.Controllers;

public class ChallengeController : Controller
{
    private readonly IChallengeGenService _challengeGenService;
    public ChallengeController(IChallengeGenService challengeGenService)
    {
        _challengeGenService = challengeGenService;
    }
    public async Task<IActionResult> Index()
    {
        var generate = await _challengeGenService.GenerateChallenge();
        return View(generate);
    }
}
