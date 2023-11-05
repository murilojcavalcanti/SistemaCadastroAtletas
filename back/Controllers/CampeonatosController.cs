using AutoMapper;
using back.Data;
using back.Data.DTO.Campeonato;
using back.Data.DTO.Chave;
using back.Enums;
using back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampeonatosController : ControllerBase
    {
        private readonly SistemaDbContext Context;
        private readonly IMapper Mapper;

        public CampeonatosController(IMapper mapper, SistemaDbContext context)
        {

            Mapper = mapper;
            Context = context;
        }

        [HttpPost]
        [Authorize(Policy = "AdminUsuario")]

        public IActionResult CriaCampeonato([FromQuery] CriaCampeonatoDTO dto)
        {
            var camp = Mapper.Map<Campeonatos>(dto);
            Context.Campeonatos.Add(camp);
            Context.SaveChanges();
            return Ok(camp);
        }

        [HttpGet]
        public IEnumerable<LeCampeonatoDTO> BuscaCampeonatos([FromQuery] string? titulo = null,
            TipoCampeonatoEnum? tipo = null, EstadoEnum? estado = null, FasesCampeonatoEnum? fases = null, string? cidade = null)
        {
            if (string.IsNullOrEmpty(titulo) || tipo == null || estado == null || string.IsNullOrEmpty(cidade))
            {
                var camps = Context.Campeonatos.Where(c =>
                    (string.IsNullOrEmpty(titulo) || c.Titulo.Contains(titulo)) &&
                    (tipo == null || c.TipoCampeonato == tipo) &&
                    (estado == null || c.Estado == estado) &&
                    (fases == null || c.Fase == fases) &&
                    (string.IsNullOrEmpty(cidade) || c.Cidade == cidade));
                var campsDTO = Mapper.Map<ICollection<LeCampeonatoDTO>>(camps);

                return campsDTO;
            }
            return Mapper.Map<ICollection<LeCampeonatoDTO>>(Context.Campeonatos.ToList());


        }



        [HttpPut("Atualiza")]
        [Authorize(Policy = "AdminUsuario")]

        public IActionResult AtualizaCampeonato([FromQuery] string titulo, AtualizaCampeonatoDTO dto)
        {
            var camp = Context.Campeonatos.FirstOrDefault(c => c.Titulo == titulo);
            if (camp == null) return NotFound();

            Mapper.Map(dto, camp);
            return Ok(camp);
        }

        [HttpDelete]
        [Authorize(Policy = "AdminUsuario")]

        public IActionResult DeletaCampeonato([FromQuery] string titulo)
        {
            var camp = Context.Campeonatos.FirstOrDefault(c => c.Titulo == titulo);
            if (camp == null) return NotFound();

            Context.Campeonatos.Remove(camp);
            Context.SaveChanges();
            return NoContent();
        }

        [HttpPost("GeraChave")]
        [Authorize(Policy = "AdminUsuario")]
        public IActionResult GeraChaves(CriaChavesDTO dto)
        {
            var chave = Mapper.Map<Chaves>(dto);
            var atletaCamp = Context.AtletaCampeonato.Where(a => a.CampeonatoId == chave.CampeonatoId);
            var atletas = new List<Atletas>();

            foreach (var a in atletaCamp)
            {
                atletas.Add(a.Atleta);
            }

            var atletaschave = new List<string>();

            foreach (var atleta in atletas)
            {
                if ((atleta.Sexo == chave.Sexo && atleta.Peso == chave.Peso && atleta.Faixa == chave.Faixa))
                {
                    atletaschave.Add(atleta.Id);
                }

            }

            for (int i = 0; i < atletaschave.Count; i++)
            {
                int j = atletas.Count - 1;
                var luta = new Lutas();
                var Atletasluta = new AtletasLutas();
                luta.ChavesId = chave.Id;
                Atletasluta.LutasId = luta.Id;

                Atletasluta.AtletasId = atletaschave[i];
                Atletasluta.AtletasId = atletaschave[j];


                Context.AtletasLutas.Add(Atletasluta);
                Context.SaveChanges();

                Context.Lutas.Add(luta);
                Context.SaveChanges();
                j--;

            }

            Context.Chaves.Add(chave);
            Context.SaveChanges();
            return Ok(chave);
        }

        [HttpGet("Chaves")]
        [Authorize(Policy = "AdminUsuario")]
        public IEnumerable<LeCampeonatoDTO> BuscaChaves([FromQuery] string? titulo = null,
        FaixaEnum? Faixa = null,
        PesoEnum? Peso = null,
        SexoEnum? Sexo = null)
        {
            var camps = Context.Chaves.Where(c =>
                (Faixa == null || c.Faixa == Faixa) &&
                (Peso == null || c.Peso == Peso) &&
                (Sexo == null || c.Sexo == Sexo));
            var campsDTO = Mapper.Map<ICollection<LeCampeonatoDTO>>(camps);

            return campsDTO;
        }



    }
}
