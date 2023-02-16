using ShipManagement.API.Configurations;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "CorsPolicy";

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:4200")
        .WithOrigins("http://localhost:8888")
        .AllowCredentials());
});

builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
