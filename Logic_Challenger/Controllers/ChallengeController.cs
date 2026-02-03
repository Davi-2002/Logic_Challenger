using Logic_Challenger.Models;
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
    public IActionResult Index()
    {
        return View(new ChallengeViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> GenerateTest(int difficulty)
    {
        var generate = await _challengeGenService.GenerateChallenge(difficulty);
        return View("Index", generate);
    }

    [HttpPost]
    public async Task<IActionResult> CheckAnswer(string CorrectAnswer, string UserAnswer, string OriginalQuestion, int Difficulty)
    {
        var aiResponse = await _challengeGenService.CheckAnswer(CorrectAnswer, UserAnswer, OriginalQuestion);
        var challenge = new ChallengeViewModel();

        challenge.Answer = CorrectAnswer;
        challenge.Question = OriginalQuestion;
        challenge.Feedback = aiResponse;
        challenge.CreatedQuestion = true;
        challenge.Difficulty = Difficulty;

        return View("Index", challenge);
    }
}
