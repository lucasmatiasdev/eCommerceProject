using eCommerceProject.Infrastructure.DependencyInjection;
using eCommerceProject.Application.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.

builder.Host.UseSerilog();
Log.Logger.Information("Application Starting Up");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddAplicationService();
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:7502")
        .AllowCredentials();
    });
});

try
{
    var app = builder.Build();

    app.UseSerilogRequestLogging();

    app.UseCors();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseInfrastructureService();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Log.Logger.Information("Application Started Up");

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

