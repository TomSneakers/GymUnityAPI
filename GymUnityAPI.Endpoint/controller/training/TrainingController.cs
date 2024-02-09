using System.Security.Claims;
using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.training.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller.training;

[ApiController]
[Route("[controller]")]
public class TrainingController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ObjectResult GetTrainings()
    {
        var customerTrainings = Locator.TrainingQueryService()
                                       .GetTrainings(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Ok(customerTrainings);
    }

    [HttpPost]
    [Authorize]
    public ActionResult Post(TrainingTemplate body)
    {
        Locator.TrainingCommand()
               .CreateTraining(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "", body.Title,
                   body.Description,
                   body.Exercices);

        return Ok();
    }
}