using KpopApi.Models.DTOs;
using KpopApi.Models.Entities;
using KpopApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KpopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly Repository<Kpopgroup> _repository;

        public GrupoController(Repository<Kpopgroup> repository)
        {
            _repository = repository;
        }

    
        [HttpGet]
        public IEnumerable<Kpopgroup> Get()
        {
            return _repository.GetAll();
        }

     
        [HttpGet("{id}")]
        public ActionResult<Kpopgroup> Get(int id)
        {
            var grupo = _repository.Get(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return grupo;
        }

 
        [HttpPost]
        public ActionResult<Kpopgroup> Post(GrupoDTO grupoDTO)
        {
            if (grupoDTO == null)
            {
                return BadRequest("GrupoDTO no puede ser nulo");
            }

            var grupo = new Kpopgroup
            {
                Nombre = grupoDTO.Nombre,
                Integrantes = grupoDTO.Integrantes,
                FechaDebut = grupoDTO.FechaDebut,
                CantidadAlbums = grupoDTO.CantidadAlbums,
                Imagen = grupoDTO.Imagen
            };

            _repository.Insert(grupo);

            return CreatedAtAction(nameof(Get), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, GrupoDTO grupoDTO)
        {
            if (grupoDTO == null || id != grupoDTO.Id)
            {
                return BadRequest();
            }

            var grupo = _repository.Get(id);
            if (grupo == null)
            {
                return NotFound();
            }

            grupo.Nombre = grupoDTO.Nombre;
            grupo.Integrantes = grupoDTO.Integrantes;
            grupo.FechaDebut = grupoDTO.FechaDebut;
            grupo.CantidadAlbums = grupoDTO.CantidadAlbums;
            grupo.Imagen = grupoDTO.Imagen;

            _repository.Update(grupo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var grupo = _repository.Get(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _repository.Delete(grupo);

            return NoContent();
        }
    }
}
