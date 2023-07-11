using myfinance_web_netcore;
using myfinance_web_netcore.Application.GetAccountUseCase;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Repository.Repositories;
using myfinance_web_netcore.Services.Account;
using myfinance_web_netcore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add db context
builder.Services.AddDbContext<MyFinanceDbContext>();

// dependencies resolver
builder.Services.AddScoped<IGetAccountUseCase, GetAccountUseCase>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();


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
