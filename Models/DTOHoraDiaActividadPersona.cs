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

[Table("HoraDiaActividadPersona", Schema = "dbo")]
public class DTOHoraDiaActividadPersona
{
    [Key]
    public int IIDHORADIAACTIVIDADPERSONA { get; set; } 

    public int? IIDDIA { get; set; }                    
    public int? IIDHORA { get; set; }                  

    [StringLength(150)]
    public string? NOMBREACTIVIDAD { get; set; }

    public int? IIDPERSONA { get; set; }                

    public int? BHABILITADO { get; set; }
}
