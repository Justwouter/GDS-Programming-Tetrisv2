using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;


using API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScoreContext>(options => {
  options.UseSqlite(builder.Configuration.GetConnectionString("Scoreboard"));
});

builder.Services.AddCors(options => {
  options.AddPolicy("CorsAllowAll",
                        policy => policy.AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowAnyOrigin());
});



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  // add OpenAPI info to the swagger page
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "TetrisV2 Official API", Version = "v0.69", Description = "Scoreboard API for [TetrisV2](https://github.com/Justwouter/Tetrisv2)" });


  // Allow XML comments in controller reflected on the swagger page
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {

}

app.UseSwagger();
app.UseSwaggerUI(c => c.InjectStylesheet("/css/SwaggerDark.css"));

// Import css file from the csproj embed
app.MapGet("/css/SwaggerDark.css", () => {
  var assembly = Assembly.GetExecutingAssembly();
  return Results.Stream(assembly.GetManifestResourceStream("API.Assets.SwaggerDark.css")!, "text/css");
}).ExcludeFromDescription();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
