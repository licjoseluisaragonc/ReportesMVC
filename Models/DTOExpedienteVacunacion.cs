/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: DTO de modelo para Persona en tabla Persona
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Creación
* ---------------------------------------------------------------------------------------
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ExpedienteVacunacion", Schema = "dbo")]
public class DTOExpedienteVacunacion
{
    [Key]
    public int IIDEXPEDIENTEVACUNACION { get; set; }  

    public int? IIDPERSONA { get; set; }              

    public DateTime? FECHAVACUNACION { get; set; }   

    public int? DIABETES { get; set; }
    public int? HIPERTENCION { get; set; }

    [StringLength(100)]
    public string? OTROPADECIMIENTO { get; set; } = string.Empty;

    public int? IIDMARCAVACUNA { get; set; }
    public int? NUMERODOSIS { get; set; }
    public int? LOTEVACUNA { get; set; }

    public int? BHABILITADO { get; set; }
    public int? EDAD { get; set; }
}