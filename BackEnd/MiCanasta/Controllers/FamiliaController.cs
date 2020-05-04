using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.Persistence;
using System.Linq;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("familias")]
    public class FamiliaController: ControllerBase
    {
        private readonly FamiliaService _familiaService;

        public FamiliaController(FamiliaService FamiliaService)
        {
            _familiaService = FamiliaService;
        }

        [HttpPost]
        public ActionResult Create(FamiliaCreateDto model)
        {
            var result = _familiaService.Create(model);

            if (result == null)
            {
               return BadRequest("El grupo familiar ya existe :( ");
            }
            return Ok("Se ha creado el grupo familiar :) ");
        }
        
        [HttpGet("{nombreFamilia}/usuarios")]
        public ActionResult GetUsuariosByNombreFamilia(string nombreFamilia)
        {
            var result = _familiaService.GetByFamiliaNombre(nombreFamilia);
            return Ok(result);
        }
    }
}