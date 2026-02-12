/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: Lógica de negocios de datos Persona 
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Creación
* ---------------------------------------------------------------------------------------
*/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportesMVC.Data;
using ReportesMVC.Models;

namespace ReportesMVC.Controllers
{
    [Authorize] //Protege el acceso a Persona Data
    public class PersonaController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(AppDbContext db, ILogger<PersonaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Personas.AsNoTracking()
                .OrderBy(x => x.IIDPERSONA)
                .ToListAsync();

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var p = await _db.Personas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.IIDPERSONA == id);

            if (p == null)
                return NotFound(new { ok = false, message = "Persona no encontrada." });

            return Ok(p); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actualizar(DTOPersona model)
        {
            try
            {
                var p = await _db.Personas.FirstOrDefaultAsync(x => x.IIDPERSONA == model.IIDPERSONA);
                if (p == null)
                    return NotFound(new { ok = false, message = "Persona no encontrada." });

                string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

                if (Clean(model.NOMBRE) != null)
                    p.NOMBRE = model.NOMBRE!.Trim();
                if (Clean(model.APPATERNO) != null)
                    p.APPATERNO = model.APPATERNO!.Trim();
                if (Clean(model.APMATERNO) != null)
                    p.APMATERNO = model.APMATERNO!.Trim();
                if (model.IIDSEXO != null)
                    p.IIDSEXO = model.IIDSEXO;

                if (Clean(model.CORREO) != null)
                    p.CORREO = model.CORREO!.Trim();
                if (Clean(model.TELEFONOOCELULAR1) != null)
                    p.TELEFONOOCELULAR1 = model.TELEFONOOCELULAR1!.Trim();

                if (model.IIDTIPODOCUMENTO != null)
                    p.IIDTIPODOCUMENTO = model.IIDTIPODOCUMENTO;
                if (Clean(model.NUMEROIDENTIFICACION) != null)
                    p.NUMEROIDENTIFICACION = model.NUMEROIDENTIFICACION!.Trim();

                await _db.SaveChangesAsync();
                return Ok(new { ok = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Actualizar Persona");
                return StatusCode(500, new { ok = false, message = "Error al guardar." });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hijos = await _db.TratamientoMedicoPersona
                    .Where(x => x.IIDPERSONA == id)
                    .ToListAsync();

                _db.TratamientoMedicoPersona.RemoveRange(hijos);

                var medicamentos = await _db.MedicamentoConsumoPersona
                    .Where(x => x.IIDPERSONA == id)
                    .ToListAsync();

                _db.MedicamentoConsumoPersona.RemoveRange(medicamentos);

                var enf = await _db.EnfermedadesIntervencionesPersona
                    .Where(x => x.IIDPERSONA == id)
                    .ToListAsync();

                _db.EnfermedadesIntervencionesPersona.RemoveRange(enf);

                var observaciones = await _db.ObservacionesPersona
                    .Where(x => x.IIDPERSONA == id)
                    .ToListAsync();

                _db.ObservacionesPersona.RemoveRange(observaciones);

                var fichamedic = await _db.FichaMedica
                    .Where(x => x.IIDPERSONA == id)
                    .ToListAsync();

                _db.FichaMedica.RemoveRange(fichamedic);

                var expedVacunac = await _db.ExpedienteVacunacion
                      .Where(x => x.IIDPERSONA == id)
                      .ToListAsync();

                _db.ExpedienteVacunacion.RemoveRange(expedVacunac);


                var horaactividad = await _db.HoraDiaActividadPersona
                  .Where(x => x.IIDPERSONA == id)
                  .ToListAsync();

                _db.HoraDiaActividadPersona.RemoveRange(horaactividad);

                await _db.SaveChangesAsync();

                var p = await _db.Personas.FirstOrDefaultAsync(x => x.IIDPERSONA == id);
                if (p == null)
                    return NotFound(new { ok = false, message = "Persona no encontrada." });

                _db.Personas.Remove(p);

                await _db.SaveChangesAsync();

                return Ok(new { ok = true });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "DbUpdateException al eliminar Persona {Id}", id);
                return StatusCode(409, new { ok = false, message = "No se puede eliminar: existen datos relacionados." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar Persona {Id}", id);
                return StatusCode(500, new { ok = false, message = "Error al eliminar." });
            }
        }


    }
}
