using robot_controller_api.Persistence;
using robot_controller_api.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigin = builder.Configuration.GetValue<string>("CorsSettings:AllowedOrigin");
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalOnly",
        p => p.WithOrigins(allowedOrigin ?? "*").AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

builder.Services.AddScoped<IRobotCommandDataAccess, RobotCommandEF>();
builder.Services.AddScoped<IMapDataAccess, MapEF>();
builder.Services.AddScoped<RobotContext>();

var app = builder.Build();

app.UseCors("LocalOnly");
app.MapControllers();

app.Run();