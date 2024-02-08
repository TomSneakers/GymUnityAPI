using GymUnityAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddEntityFrameworkStores<AuthenticationDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthenticationDb")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();