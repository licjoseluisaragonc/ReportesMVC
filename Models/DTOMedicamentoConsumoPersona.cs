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

namespace ReportesMVC.Models;

[Table("MedicamentoConsumoPersona", Schema = "dbo")]
public class DTOMedicamentoConsumoPersona
{
    [Key]
    public int IIDMEDICAMENTOCONSUMOPERSONA { get; set; }

    public int? IIDPERSONA { get; set; }

    [StringLength(150)]
    public string? DESCRIPCION { get; set; } = string.Empty;

    public int? BHABILITADO { get; set; }

}
