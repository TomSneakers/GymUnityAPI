using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace GymUnityAPI.controller;

public class BaseController : ControllerBase
{
    protected ConnectedAccount ConnectedAccount { get; set; }
    
    public BaseController()
    {
        ConnectedAccount = new ConnectedAccount()
        {
            Id = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("Not authenticated"),
            Email = User.FindFirstValue(ClaimTypes.Email) ?? throw new Exception("Not authenticated")
        };
    }
}

public class ConnectedAccount
{
    public string Id { get; set; } = "";
    public string Email { get; set; } = "";
}