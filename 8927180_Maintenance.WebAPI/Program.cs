using _8927180_Maintenance.WebAPI.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepairHistoryService, FakeRepairHistoryService>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Name = "X-Api-Key",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Enter your API key"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});

var usageCount = new Dictionary<string, int>();
builder.Services.AddSingleton(usageCount);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            error = "ServerError",
            message = "Error: Unexpected Error Occurred."
        });
    }
});

const string API_KEY = "MY_SECRET_KEY_123";
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-Api-Key", out var key) ||
    key != API_KEY)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsJsonAsync(new
        {
            error = "Unauthorized",
            message = "Error: Missing or invalid API key."
        });
        return;
    }
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
