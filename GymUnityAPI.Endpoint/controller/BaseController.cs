using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller;

[ApiController]
public class BaseController : ControllerBase
{
    protected ConnectedAccount ConnectedAccount { get; set; }
    
    public BaseController()
    {
        ConnectedAccount = new ConnectedAccount()
        {
            Id = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ""
        };
    }
}

public class ConnectedAccount
{
    public string Id { get; set; } = "";
    public string Email { get; set; } = "";
}