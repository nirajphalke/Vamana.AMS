using Microsoft.EntityFrameworkCore;
using Serilog;
using Vamana.AMS.Api.Extensions;
using Vamana.AMS.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=DPLAP200;Database=myDB;User Id=sa;Password=delaPlex@123;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
    "TrustServerCertificate=False;";

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod(); 
                      });
});

// Set up Serilog configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders(); // Remove default logging
builder.Host.UseSerilog(); // Use Serilog

builder.Services.AddMyApplicationServices();
builder.Services.AddDatabaseServices(connectionString);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers().AddJsonOptions(opts => { opts.JsonSerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Caching - in-memory
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetValue<string>("REDIS_CONNECTION") ?? "redis:6379";
//});
builder.Services.AddMemoryCache();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
