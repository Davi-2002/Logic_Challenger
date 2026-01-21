using Logic_Challenger.Models;

namespace Logic_Challenger.Services;

public class ChallengeGenService : IChallengeGenService
{
    public async Task<ChallengeViewModel> GenerateChallenge()
    {
        var challange = new ChallengeViewModel();
        challange.Question = "2 + 2";
        challange.Answer = "4";
        challange.Difficulty = 1;
        challange.Category = "matemática";
        challange.Explanation = "desafio de soma";
        await Task.Delay(1000);
        return challange;
    }
}
