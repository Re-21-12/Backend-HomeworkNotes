﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeWorksBackEnd.Models;

namespace HomeWorksBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadsController : ControllerBase
    {
        private readonly AdminTareasContext _context;

        public ActividadsController(AdminTareasContext context)
        {
            _context = context;
        }

        // GET: api/Actividads
        [HttpGet]
        //aqui retornamos las actividades en base a lo quue querramos del lado del front end
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividads()
        {
          if (_context.Actividads == null)
          {
              return NotFound();
          }
            return await _context.Actividads.ToListAsync();
        }
        /////////
        //aqui retornamos las actividades en base a lo quue querramos del lado del front end

        /*
                 public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal Nota { get; set; }
        public string Estado { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public string FechaEntrega { get; set; } = null!;

         */ 
        [HttpGet("/api/Actividads/filtrar")]
        public async Task<ActionResult<IEnumerable<Actividad>>> FiltrarActividades(string? Nombre, string? Tipo, string? Estado, string? Materia)
        {
            ///de la tabla Actividad in el contexto de la base de datos seleccioona la actividad 
            // Iniciar con la lista completa de actividades
            IQueryable<Actividad> actividades = _context.Actividads;

            if (_context.Actividads == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(Nombre))
            {
                actividades = _context.Actividads.Where(Actividad=> Actividad.Nombre  == Nombre);
            }

            if (!string.IsNullOrEmpty(Tipo))
            {
                actividades = _context.Actividads.Where(Actividad => Actividad.Tipo == Tipo);
            }

            if (!string.IsNullOrEmpty(Tipo))
            {
                actividades = _context.Actividads.Where(Actividad => Actividad.Tipo == Tipo);
            }

            if (!string.IsNullOrEmpty(Estado))
            {
                actividades = _context.Actividads.Where(Actividad => Actividad.Estado  == Estado);
            }

            if (!string.IsNullOrEmpty(Materia))
            {
                actividades = _context.Actividads.Where(Actividad => Actividad.Materia == Materia);
            }
            return await actividades.ToListAsync();
        }

        //////
        // GET: api/Actividads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
          if (_context.Actividads == null)
          {
              return NotFound();
          }
            var actividad = await _context.Actividads.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // PUT: api/Actividads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Actividads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
          if (_context.Actividads == null)
          {
              return Problem("Entity set 'AdminTareasContext.Actividads'  is null.");
          }
            _context.Actividads.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            if (_context.Actividads == null)
            {
                return NotFound();
            }
            var actividad = await _context.Actividads.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividads.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(int id)
        {
            return (_context.Actividads?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
