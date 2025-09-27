using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
