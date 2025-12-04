using Application;

using EndPoint_Ui.Middlewares;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scrutor;

using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scrutor;
using EndPoint_Ui.Areas.Admin.Pages.Dashboard;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
//.AddRazorPagesOptions(o => { o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()); });


builder.Services.Application(builder.Configuration);
builder.Services.Infrastructure(builder.Configuration);

builder.Services.Scan(scan => scan
 .FromAssemblies(
             typeof(Application.Cofiguration).Assembly,
             typeof(Infrastructure.Cofiguration).Assembly,
             typeof(Program).Assembly)
    .AddClasses()
    .UsingRegistrationStrategy(RegistrationStrategy.Append)
    .AsMatchingInterface()
    .WithScopedLifetime());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseUserInformationMiddleware();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
