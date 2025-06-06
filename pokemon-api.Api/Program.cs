using Microsoft.AspNetCore.Mvc.Infrastructure;
using pokemon_api.Api;
using pokemon_api.Application;
using pokemon_api.Api.Errors;
using pokemon_api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{   
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}




