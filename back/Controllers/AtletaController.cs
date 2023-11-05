using AutoMapper;
using back.Data.DTO.Campeonato;
using back.Data;
using back.Enums;
using back.Models;
using Microsoft.AspNetCore.Mvc;
using back.Data.DTO.Atleta;
using Microsoft.AspNetCore.Authorization;

namespace back.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AtletaController : Controller
    {
        private readonly SistemaDbContext Context;
        private readonly IMapper Mapper;

        public AtletaController(IMapper mapper, SistemaDbContext context)
        {

            Mapper = mapper;
            Context = context;
        }

        [HttpPost]
        [Authorize(Policy = "AdminUsuario")]
        public IActionResult InscreveAtleta([FromQuery] CadastraAtletaDTO dto)
        {
            var atleta = Mapper.Map<Atletas>(dto);
            atleta.TipoUsuario = UsuarioEnum.User;
            Context.Atletas.Add(atleta);
            Context.SaveChanges();

            return Ok(atleta);
        }

        [HttpGet]
        public IEnumerable<LeAtletaDTO> BuscaAtletas()
        {
            return Mapper.Map<ICollection<LeAtletaDTO>>(Context.Atletas.ToList());

        }



        [HttpPut("Atualiza")]
        [Authorize(Policy = "AdminUsuario")]

        public IActionResult AtualizaAtleta([FromQuery] string CPF, AtualizaCampeonatoDTO dto)
        {
            var Atleta = Context.Atletas.FirstOrDefault(a => a.CPF == CPF);
            if (Atleta == null) return NotFound();

            Mapper.Map(dto, Atleta);
            return Ok(Atleta);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminUsuario")]
        public IActionResult DeletaAtletas([FromQuery] string CPF)
        {
            var atleta = Context.Atletas.FirstOrDefault(a => a.CPF == CPF); ;
            if (atleta == null) return NotFound();

            Context.Atletas.Remove(atleta);
            Context.SaveChanges();
            return NoContent();
        }

    }
}
