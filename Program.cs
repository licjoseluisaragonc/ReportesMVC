/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: Program.CS
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Modificación
* ---------------------------------------------------------------------------------------
*/

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ReportesMVC.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["DB_CONNEC_STR"];
if (string.IsNullOrWhiteSpace(connectionString))
    throw new Exception("Falta la cadena de conexión: DB_CONNEC_STR");

// Add services to the container.
builder.Services.AddControllersWithViews();

//Conexión a SQL usando cadena de conexión para uso de entityframewotk 6.0 que es la versión que permite esta vesión de .net 6.0
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(connectionString)
);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Auth/Login";
        opt.AccessDeniedPath = "/Auth/Login";
        opt.Cookie.Name = "BDReportes.Auth";
        opt.ExpireTimeSpan = TimeSpan.FromHours(8);
        opt.SlidingExpiration = true;
    });


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Default: mandar al Login 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accesos}/{action=Login}/{id?}");

app.Run();
