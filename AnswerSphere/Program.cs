using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnswerSphere.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReponseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ReponseContext") ?? throw new InvalidOperationException("Connection string 'ReponseContext' not found.")));
builder.Services.AddDbContext<OptionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("OptionContext") ?? throw new InvalidOperationException("Connection string 'OptionContext' not found.")));
builder.Services.AddDbContext<QuestionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("QuestionContext") ?? throw new InvalidOperationException("Connection string 'QuestionContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
