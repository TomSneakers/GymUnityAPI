using GymUnityApi.Domain.training;
using GymUnityApi.Domain.training.dto;
using GymUnityApi.Domain.training.queryService;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller.training;

[ApiController]
[Route("[controller]")]
public class TrainingController : BaseController
{
    [HttpGet]
    public ObjectResult Get()
    {
        var customerTrainings = new TrainingQueryService().GetTrainings(ConnectedAccount.Id);
        
        return Ok(customerTrainings);
    }
    
    [HttpPost]
    public ActionResult Post(TrainingDto body)
    {
        new TrainingCommand().CreateTraining( ConnectedAccount.Id, body.Name, body.Description, body.Exercices);
        
        return Ok();
    }
}