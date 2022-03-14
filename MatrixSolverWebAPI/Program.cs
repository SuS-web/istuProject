var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowMethods",
                      builder =>
                      {
                          builder.WithOrigins("https://matrixsolver-58f5b.web.app", "http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowMethods");

app.MapControllers();

app.Run();
