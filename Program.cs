using diarioOnlineAPI.Controller;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using diarioOnline.Components;
using diarioOnlineAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7090/") });
// Register interactive components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseAntiforgery();

//// Map interactive server components
//app.MapRazorComponents<diarioOnline.Components.Pages.Entries>()
//    .AddInteractiveServerRenderMode();

// Map interactive WebAssembly components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();