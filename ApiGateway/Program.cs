using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Ocelot services
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: HTTPS redirection if your downstreams use HTTPS
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

// ✅ This line actually enables the Ocelot Gateway routing
await app.UseOcelot();

app.Run();
