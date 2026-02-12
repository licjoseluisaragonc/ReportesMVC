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

[Table("Persona", Schema = "dbo")]
public class DTOPersona
{
    [Key]
    public int IIDPERSONA { get; set; }

    [StringLength(20)]
    public string? NUMEROIDENTIFICACION { get; set; }

    [StringLength(100)]
    public string? NOMBRE { get; set; }

    [StringLength(100)]
    public string? APPATERNO { get; set; }

    [StringLength(100)]
    public string? APMATERNO { get; set; }

    public int? IIDSEXO { get; set; }

    [StringLength(100)]
    public string? CORREO { get; set; }

    [StringLength(15)]
    public string? TELEFONOOCELULAR1 { get; set; }

    [StringLength(15)]
    public string? TELEFONOOCELULAR2 { get; set; }

    [StringLength(50)]
    public string? CALLE { get; set; }

    [StringLength(25)]
    public string? NEXTERIOR { get; set; }

    [StringLength(25)]
    public string? NINTERIOR { get; set; }

    [StringLength(25)]
    public string? COLONIA { get; set; }

    [StringLength(25)]
    public string? CP { get; set; }

    [StringLength(50)]
    public string? MUNICIPIOPAIS { get; set; }

    [Required]
    [StringLength(50)]
    public string ESTADOPAIS { get; set; } = ""; 

    public int? IIDTIPODOCUMENTO { get; set; }

    [StringLength(30)]
    public string? NUMEROREGISTROUNICOCONTRIBUYENTE { get; set; }

    [StringLength(50)]
    public string? NOMBREFOTO { get; set; }

    public int? BHABILITADO { get; set; }
}
