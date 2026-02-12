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

[Table("TratamientoMedicoPersona", Schema = "dbo")]
public class DTOTratamientoMedicoPersona
{
    [Key]
    public int IIDTRATAMIENTOMEDICOPERSONA { get; set; }

    public int IIDPERSONA { get; set; }

    [StringLength(100)]
    public string? DESCRIPCION { get; set; } = string.Empty;
    public int? BHABILITADO { get; set; } = 0;

}
