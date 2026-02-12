using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportesMVC.Models;


[Table("ObservacionesPersona", Schema = "dbo")]
public class DTOObservacionesPersona
{
    [Key]
    public int IIDOBSERVACIONESPERSONA { get; set; }

    public int? IIDPERSONA { get; set; }

    [StringLength(100)]
    public string? DESCRIPCION { get; set; } = string.Empty;

    public int? BHABILITADO { get; set; }
}
