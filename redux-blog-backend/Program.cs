using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس‌های لازم برای کنترلرها
builder.Services.AddControllers();

// اضافه کردن سرویس Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// فعال کردن Swagger و Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();