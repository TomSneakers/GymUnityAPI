using System.Security.Claims;
using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.workout.template;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller.training;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public ObjectResult GetTrainings()
    {
        var customerWorkouts = Locator.WorkoutQueryService()
                                      .GetWorkouts(User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Ok(customerWorkouts);
    }

    [HttpPost]
    [Authorize]
    public ActionResult Post(WorkoutTemplate body)
    {
        Locator.WorkoutCommand()
               .AddWorkout(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "", body.Title,
                   body.Description,
                   body.Exercises);

        return Ok();
    }
}