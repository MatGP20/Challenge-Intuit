using FrontendChallenge.WeatherPage.Components;
using FrontendChallenge.WeatherPage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ForecasterService>();
builder.Services.AddScoped<GeoCodingService>();
builder.Services.AddScoped<HistoryForecastService>();
builder.Services.AddScoped<INotificationLoading, NotificationLoading>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
