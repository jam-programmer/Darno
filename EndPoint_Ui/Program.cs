using System;
using Application;
<<<<<<< HEAD
using Application.Services.User;
=======

>>>>>>> ca465ceb95eddb03965830ce5a3f6cd36ba66f94
using EndPoint_Ui.Middlewares;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scrutor;
<<<<<<< HEAD
=======

>>>>>>> ca465ceb95eddb03965830ce5a3f6cd36ba66f94
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Scrutor;
using EndPoint_Ui.Areas.Admin.Pages.Dashboard;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> ca465ceb95eddb03965830ce5a3f6cd36ba66f94
=======
//using EndPoint_Ui.Areas.Admin.Pages.Articles;
>>>>>>> f8a2519 (Add Article & Category modules (entities, DTOs, viewmodels, migrations))
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

builder.Services.AddScoped<IUserService,UserService>();


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
<<<<<<< HEAD
IndexModel index = new IndexModel();
index.OnGet();
=======

>>>>>>> ca465ceb95eddb03965830ce5a3f6cd36ba66f94
app.Run();
