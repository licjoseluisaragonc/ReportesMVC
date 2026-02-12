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
    public DbSet<DTOTratamientoMedicoPersona> TratamientoMedicoPersona => Set<DTOTratamientoMedicoPersona>();
    public DbSet<DTOMedicamentoConsumoPersona> MedicamentoConsumoPersona => Set<DTOMedicamentoConsumoPersona>();
    public DbSet<DTOEnfermedadesIntervencionesPersona> EnfermedadesIntervencionesPersona => Set<DTOEnfermedadesIntervencionesPersona>();
    public DbSet<DTOObservacionesPersona> ObservacionesPersona => Set<DTOObservacionesPersona>();
    public DbSet<DTOFichaMedica> FichaMedica => Set<DTOFichaMedica>();
    public DbSet<DTOExpedienteVacunacion> ExpedienteVacunacion => Set<DTOExpedienteVacunacion>();
    public DbSet<DTOHoraDiaActividadPersona> HoraDiaActividadPersona => Set<DTOHoraDiaActividadPersona>();

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

        modelBuilder.Entity<DTOTratamientoMedicoPersona>(e =>
        {
            e.ToTable("TratamientoMedicoPersona", "dbo");
            e.HasKey(x => x.IIDTRATAMIENTOMEDICOPERSONA); 
        });

        modelBuilder.Entity<DTOMedicamentoConsumoPersona>(e =>
        {
            e.ToTable("MedicamentoConsumoPersona", "dbo");
            e.HasKey(x => x.IIDMEDICAMENTOCONSUMOPERSONA);
        });

        modelBuilder.Entity<DTOEnfermedadesIntervencionesPersona>(e =>
        {
            e.ToTable("EnfermedadesIntervencionesPersona", "dbo");
            e.HasKey(x => x.IIDENFERMEDADESINTERVENCIONES);
        });

        modelBuilder.Entity<DTOObservacionesPersona>(e =>
        {
            e.ToTable("ObservacionesPersona", "dbo");
            e.HasKey(x => x.IIDOBSERVACIONESPERSONA);
        });


        modelBuilder.Entity<DTOFichaMedica>(e =>
        {
            e.ToTable("FichaMedica", "dbo");
            e.HasKey(x => x.IIDFICHAMEDICA);
        });

        modelBuilder.Entity<DTOExpedienteVacunacion>(e =>
        {
            e.ToTable("ExpedienteVacunacion", "dbo");
            e.HasKey(x => x.IIDEXPEDIENTEVACUNACION);
        });

        modelBuilder.Entity<DTOHoraDiaActividadPersona>(e =>
        {
            e.ToTable("HoraDiaActividadPersona", "dbo");
            e.HasKey(x => x.IIDHORADIAACTIVIDADPERSONA);
        });


        base.OnModelCreating(modelBuilder);
    }
}

