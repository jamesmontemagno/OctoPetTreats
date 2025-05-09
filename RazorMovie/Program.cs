using AspNetCoreRateLimit;
using RazorMovie.Extensions;
using RazorMovie.SharedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add in-memory caching for rate limiting
builder.Services.AddMemoryCache();

// Configure IP-based rate limiting
builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = false;
    options.RealIpHeader = "X-Real-IP";
    options.HttpStatusCode = 429; // Too Many Requests
    options.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "*",
            Period = "1m",
            Limit = 5 // Maximum requests per minute
        }
    };
});
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

// register the Safe service
builder.Services.AddScoped<Safe>();
builder.Services.AddHtmlSanitizer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Apply global rate limiting
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapRazorPages();
app.Run();
