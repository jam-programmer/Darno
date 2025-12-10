using Application;
using Application.Services.User;
using EndPoint_Ui.Areas.Admin.Pages.Dashboard;
using EndPoint_Ui.Middlewares;
using Infrastructure;
using Scrutor;

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

builder.Services.AddScoped<IUserService, UserService>();


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
app.UseAuthentication();
app.UseAuthorization();

app.UseUserInformationMiddleware();

app.MapRazorPages();
IndexModel index = new IndexModel();
index.OnGet();

app.Run();
