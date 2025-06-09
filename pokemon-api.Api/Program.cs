using Microsoft.AspNetCore.Mvc.Infrastructure;
using pokemon_api.Api;
using pokemon_api.Api.Common.Errors;
using pokemon_api.Application;
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
    
    //UseAuthentication() must come before UseAuthorization() because:
    //UseAuthentication() verifies who you are (i.e., sets HttpContext.User)
    //UseAuthorization() checks what you're allowed to do, based on HttpContext.User
    
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}




