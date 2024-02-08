using System.Security.Claims;
using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.dto;
using GymUnityApi.Domain.training.queryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller.training;

[ApiController]
[Route("[controller]")]
public class TrainingController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ObjectResult Get()
    {
        var customerTrainings =
            new TrainingQueryService().GetTrainings(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");

        return Ok(customerTrainings);
    }

    [HttpPost]
    [Authorize]
    public ActionResult Post(TrainingDto body)
    {
        new TrainingCommand().CreateTraining(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "", body.Name,
            body.Description,
            body.Exercices);

        return Ok();
    }
}