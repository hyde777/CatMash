using Domain;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<CatMash>(provider =>
{
    var catMashApi = provider.GetRequiredService<ICatMashApi>();
    var catRepository = provider.GetRequiredService<ICatRepository>();
    var catMash = new CatMash(catRepository, catMashApi);
    Task.Run(async () => await catMash.Initialise());
    return catMash;
});
builder.Services.AddSingleton<ICatRepository, InMemoryCatRepository>();
builder.Services.AddHttpClient<ICatMashApi, CatMashApi>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();