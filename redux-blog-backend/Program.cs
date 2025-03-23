using System.Globalization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerUI;

// ایجاد سازنده برنامه وب
var builder = WebApplication.CreateBuilder(args);

// تنظیمات CORS (اشتراک‌گذاری منابع بین دامنه‌ای)
builder.Services.AddCors(option =>
{
    option.AddPolicy("ClientPermission", policy =>
    {
        // اجازه دادن به هر هدر و متد
        policy.AllowAnyHeader().AllowAnyMethod().
        // تعیین دامنه‌های مجاز برای دسترسی به API
        WithOrigins(
            "http://localhost:3000/", // آدرس لوکال هاست پورت 3000
            "http://192.168.1.13/", // آدرس IP شبکه محلی
            "http://192.168.1.13:6870/", // آدرس IP شبکه محلی با پورت 6870
            "http://localhost:5173/"); // آدرس لوکال هاست پورت 5173
    });
});

// تنظیمات رفتار API
builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
{
    // غیرفعال کردن فیلتر اعتبارسنجی مدل به صورت خودکار
    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
});

// تنظیمات محلی‌سازی
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // تنظیم فرهنگ پیش‌فرض به انگلیسی (آمریکا)
    options.DefaultRequestCulture = new RequestCulture("en-US");
    // تنظیم فرهنگ‌های پشتیبانی شده
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
    // حذف ارائه‌دهندگان فرهنگ پیش‌فرض
    options.RequestCultureProviders = new List<IRequestCultureProvider>();
});

// تنظیمات محدودیت‌های فرم
builder.Services.Configure<FormOptions>(x =>
{
    // تنظیم حداکثر طول مقدار به حداکثر مقدار ممکن
    x.ValueLengthLimit = int.MaxValue;
    // تنظیم حداکثر طول بدنه چندبخشی به حداکثر مقدار ممکن
    x.MultipartBodyLengthLimit = int.MaxValue;
    // تنظیم حداکثر طول هدرهای چندبخشی به حداکثر مقدار ممکن
    x.MultipartHeadersLengthLimit = int.MaxValue;
});

// اضافه کردن سرویس‌های لازم برای کنترلرها
builder.Services.AddControllers();

// اضافه کردن سرویس‌های لازم برای کاوشگر API
builder.Services.AddEndpointsApiExplorer();
// اضافه کردن سرویس‌های لازم برای Swagger (مستندسازی API)
builder.Services.AddOurSwagger();


//پیکربندی سرویس‌های موقت
var ConfigureTransient = new ConfigureTransient();
ConfigureTransient.ConfigureTransients(builder.Services);

// ساخت برنامه وب
var app = builder.Build();

// استفاده از CORS (اجازه دادن به هر دامنه، متد و هدر) - این خط در نهایت با خط پایین تر جایگزین میشود
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// فعال‌سازی Swagger
app.UseSwagger();
// فعال‌سازی رابط کاربری Swagger
app.UseSwaggerUI(
    options =>
    {
        // تعیین آدرس endpoint فایل swagger.json
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        // تنظیم پیشوند مسیر به خالی (دسترسی به Swagger در ریشه)
        options.RoutePrefix = string.Empty;
        // تنظیم نحوه نمایش مستندات (عدم گسترش خودکار)
        options.DocExpansion(DocExpansion.None);
    });

// فعال‌سازی فایل‌های استاتیک
app.UseStaticFiles();

// فعال‌سازی مسیریابی
app.UseRouting();

// استفاده از CORS با سیاست تعریف شده "ClientPermission"
app.UseCors("ClientPermission");

// فعال‌سازی تغییر مسیر به HTTPS
app.UseHttpsRedirection();

// فعال‌سازی احراز هویت
app.UseAuthentication();

// فعال‌سازی مجوزها
app.UseAuthorization();

// نگاشت کنترلرها
app.MapControllers();

// اجرای برنامه
app.Run();
