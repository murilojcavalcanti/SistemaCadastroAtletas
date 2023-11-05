using AutoMapper;
using back.Data.DTO.usuario;
using back.Models;
using back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace back.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController: ControllerBase
    {
        private UsuarioService Service;
         public UsuarioController(UsuarioService service)
         {
            Service = service;
         }
        
        [HttpPost]
        [Authorize(Policy = "AdminUsuario")]
        public async Task<IActionResult> CadastraUsuario(CadastraUsuarioDTO DTO)
        {
            await Service.Cadastra(DTO);
            return Ok(DTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDTO dto)
        {
            var token = await Service.Login(dto);
            return Ok(token);
        }
    }
}
