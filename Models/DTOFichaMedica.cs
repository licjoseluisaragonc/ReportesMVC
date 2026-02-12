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

[Table("FichaMedica", Schema = "dbo")]
public class DTOFichaMedica
{
    [Key]
    public int IIDFICHAMEDICA { get; set; }  

    public int? IIDPERSONA { get; set; }    

    public int? IIDSISTEMASALUD { get; set; }
    public string? NOMBRESISTEMASALUD { get; set; }

    public string? MEDICOATIENDE { get; set; }

    public int? IIDTIPOALERGIA { get; set; }
    public string? DESCRIPCIONALERGIA { get; set; }

    public int? IIDGRUPOSANGUINEO { get; set; }

    public string? ENFERMEDADCRONICA { get; set; }
}
