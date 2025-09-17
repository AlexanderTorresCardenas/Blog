using Blog.Configurations;
using Blog.Datos;
using Blog.Entities;
using Blog.Job;
using Blog.Services;
using Blog.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenAI;

var builder = WebApplication.CreateBuilder(args);

//traemos datos del keysecret
builder.Services.AddOptions<ConfiguracionesIA>()
    .Bind(builder.Configuration.GetSection(ConfiguracionesIA.Seccion))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddScoped(sp =>
{
    var configuracionesIA = sp.GetRequiredService<IOptions<ConfiguracionesIA>>();
    return new OpenAIClient(configuracionesIA.Value.LlaveOpenAI);
});

builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();

builder.Services.AddTransient<IServicioChat, ServicioChatOpenAI>();
builder.Services.AddTransient<IServicioImagenes, ServicioImagenesOpenAI>();
builder.Services.AddScoped<IAnalisisSentimientos, AnalisisSentimientosOpenAI>();

builder.Services.AddHttpClient();
builder.Services.AddHostedService<AnalisisSentimientosRecurrente>();

//configuracion de cadena de conexion para la base de datos
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConexion"))
    .UseSeeding(Seeding.Aplicar)
    .UseAsyncSeeding(Seeding.AplicarAsync);
});

builder.Services.AddIdentity<Usuario, IdentityRole>(options => { 
   options.SignIn.RequireConfirmedAccount = false;  
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
    options =>
    {
        options.LoginPath = "/usuario/login";
        options.AccessDeniedPath = "/usurios/login";

    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (dbContext.Database.IsRelational()) {
        dbContext.Database.Migrate();
    }
    
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapBlazorHub();

app.Run();
