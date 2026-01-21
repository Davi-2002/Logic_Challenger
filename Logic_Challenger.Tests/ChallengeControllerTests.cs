using Logic_Challenger.Controllers;
using Logic_Challenger.Models;
using Logic_Challenger.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Logic_Challenger.Tests;

public class ChallengeControllerTests
{
    [Fact]
    public async Task Index_ReturnsViewResult_WithChallengeViewModel()
    {
        var mockServiceGen = new Mock<IChallengeGenService>();
        var Challenge = new ChallengeViewModel();
        mockServiceGen.Setup(g => g.GenerateChallenge()).ReturnsAsync(Challenge);
        var controller = new ChallengeController(mockServiceGen.Object);
        var resultIndex = await controller.Index();
        var viewResult = Assert.IsType<ViewResult>(resultIndex);
        Assert.Equal(Challenge, viewResult.Model);
    }
}
