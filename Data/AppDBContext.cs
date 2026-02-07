/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: DBContext para entity y conexión a base de datos BDReportes
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Creación
* ---------------------------------------------------------------------------------------
*/

using Microsoft.EntityFrameworkCore;
using ReportesMVC.Models;

namespace ReportesMVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EntLoginDTO> Accesos => Set<EntLoginDTO>();
    public DbSet<DTOPersona> Personas => Set<DTOPersona>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntLoginDTO>(e =>
        {
            e.ToTable("Accesos", "dbo");
            e.HasKey(x => x.id);
        });

        modelBuilder.Entity<DTOPersona>(e =>
        {
            e.ToTable("Persona", "dbo");
            e.HasKey(x => x.IIDPERSONA);
        });

        base.OnModelCreating(modelBuilder);
    }
}

