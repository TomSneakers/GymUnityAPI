using GymUnityAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthenticationDb")));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddEntityFrameworkStores<AuthenticationDbContext>();

builder.Services.AddAuthentication("Bearer");
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();