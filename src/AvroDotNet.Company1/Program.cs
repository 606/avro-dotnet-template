using AvroDotNet.Company1.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#if EnableSwagger
builder.Services.AddSwaggerServices();
#endif

#if EnableHealthChecks
builder.Services.AddHealthChecks();
#endif

// Register application services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
#if EnableSwagger
    app.UseSwagger();
    app.UseSwaggerUI();
#endif
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if EnableHealthChecks
app.MapHealthChecks("/health");
#endif

app.Run();
