using System.Net.Http.Headers;
using BlazorApp2.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("Main", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:5270/");
    httpClient.DefaultRequestHeaders.Accept
        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddScoped<ITypeServices, TypeService>();
builder.Services.AddScoped<IOperationServices, OperationService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddMudServices();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapBlazorHub();
app.UseRouting();
app.MapFallbackToPage("/_Host");
app.UseStaticFiles();

app.Run();