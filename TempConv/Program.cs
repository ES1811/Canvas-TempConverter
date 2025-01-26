using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

//add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

//add client
builder.Services.AddHttpClient();

var app = builder.Build();

//use CORS
app.UseCors("allowAll");
//use static page
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/", content =>
{
    content.Response.Redirect("/index.html");
    return Task.CompletedTask;
});


//POST method for temperature conversion
app.MapPost("/tempconverter", ([FromBody] Temperature temperatureRequest) =>
{
    if (string.IsNullOrEmpty(temperatureRequest.TypeOfTemp) || (temperatureRequest.TypeOfTemp != "Celsius" && temperatureRequest.TypeOfTemp != "Fahrenheit" && temperatureRequest.TypeOfTemp != "Kelvin"))
    {
        return Results.BadRequest("Invalid input");
    }

    if(temperatureRequest.TypeOfTemp == "Celsius") 
    {
        temperatureRequest.Celsius = Math.Round(temperatureRequest.Value,2);

    } else if(temperatureRequest.TypeOfTemp == "Fahrenheit")
    {
        temperatureRequest.Fahrenheit = Math.Round(temperatureRequest.Value,2);

    } else if(temperatureRequest.TypeOfTemp == "Kelvin") 
    {
        temperatureRequest.Kelvin = Math.Round(temperatureRequest.Value,2);
    }

    temperatureRequest.TempConversion();

    return Results.Ok(temperatureRequest);
});

app.Run();
