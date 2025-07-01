using swiftest_hip_calculator.Components;

namespace swiftest_hip_calculator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Dynamically bind to the port
        var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
        builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}