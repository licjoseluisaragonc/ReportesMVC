/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: DTO de modelo para Login en tabla Accesos
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Creación
* ---------------------------------------------------------------------------------------
*/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportesMVC.Models
{
    [Table("Accesos", Schema = "dbo")]
    public class EntLoginDTO
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Usuario requerido.")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        [Column("userAccess", TypeName = "nchar(25)")]
        public string? userAccess { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña requerida.")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        [DataType(DataType.Password)]
        [Column("passwordAccess", TypeName = "nchar(25)")]
        public string? passwordAccess { get; set; }

        [Display(Name = "Rol")]
        [StringLength(50)]
        [Column("rollAccess", TypeName = "nchar(50)")]
        public string? rollAccess { get; set; }

        [Display(Name = "Token")]
        [Column("tokenAccess", TypeName = "nvarchar(max)")]
        public string? tokenAccess { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(10)]
        [Column("nameUser", TypeName = "nchar(10)")]
        public string? nameUser { get; set; }

        [Display(Name = "Correo")]
        [StringLength(90)]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        [Column("emailUser", TypeName = "nchar(90)")]
        public string? emailUser { get; set; }

        // (Opcional) Sólo para UI, NO toca BD
        [NotMapped]
        public bool Recordarme { get; set; } = true;
    }
}
