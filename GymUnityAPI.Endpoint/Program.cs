using GymUnityAPI;
using GymUnityApi.Domain.core.ioc;
using GymUnityApi.Domain.core.ioc.injector;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

Locator.Load(new ProdInjector());

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddEntityFrameworkStores<AuthenticationDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthenticationDb")));

builder.Services.AddCors(opt => opt.AddDefaultPolicy(options => options.AllowAnyOrigin()
                                                                       .AllowAnyHeader()
                                                                       .AllowAnyMethod()
                                                                       .Build()));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();
app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();