using HtmlToPdfWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new HtmlToPdfService());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
