var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    // Hoe lang een sessie duurt (voor testing kan je een lagere waarde gebruiken) 
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;

    // Als een cookie niet "essential" is, zal het pas werken nadat 
    // de gebruiker toestemming gegeven heeft voor het bijhouden van gegevens 
    // Opgelet: nooit gebruikersdata opslaan in essential cookies! (AVG/GDPR) 
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registreer}/{action=Index}/{id?}");

app.Run();
