using ABU.CanvasSharp.Core.Constants;
using ABU.CanvasSharp.Infrastructure.Abstractions;
using ABU.CanvasSharp.Infrastructure.Services;
using RestSharp;
using RestSharp.Authenticators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRestClient, RestClient>(sp => new RestClient()
{
    BaseUrl = new Uri(CanvasResource.BaseUrl),
    Authenticator = new JwtAuthenticator(builder.Configuration["CanvasToken"])
});

builder.Services.AddTransient<ICanvasApiClient, CanvasApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// Configure Swagger in any env
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
