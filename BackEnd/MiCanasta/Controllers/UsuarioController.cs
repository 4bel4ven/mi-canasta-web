﻿using MiCanasta.Micanasta.Dto;
using MiCanasta.MiCanasta.Services;
using Microsoft.AspNetCore.Mvc;
using MiCanasta.MiCanasta.Util;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using MiCanasta.MiCanasta.Exceptions;
using MiCanasta.MiCanasta.Dto;

namespace MiCanasta.MiCanasta.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDto> GetById(String id)
        {
            return _usuarioService.GetById(id);
        }

        /// <summary>
        /// Realiza la funcion de loguear y registrar
        /// Los Parametros van dentro del cuerpo.
        /// </summary>
        /// <param Dni="12345678"></param>
        /// <param Contrasena="12345678"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UsuarioAccesoDto> ValidarIngreso([FromBody] UsuarioLoginDto UsuarioLogin)
        {
            try
            {
                UsuarioAccesoDto usuario = _usuarioService.ValidateLogin(UsuarioLogin.Dni, UsuarioLogin.Contrasena);
                return Ok(usuario);
            }
            catch(UserLoginIncorrectException UserIncorrect)
            {
                return BadRequest(UserIncorrect.ExceptionDto);
            }
            catch(UserLoginNotFoundException UserNotFound)
            {
                return BadRequest(UserNotFound.ExceptionDto);
            }
        }

        [HttpPut("{Dni}")]
        public ActionResult Update(string Dni, UsuarioUpdateDto UsuarioUpdateDto) {
            try
            {
                return Ok(_usuarioService.Update(Dni, UsuarioUpdateDto));
            }
            catch (NewPasswordNotMatchException NewPasswordNotMatch) {
                return BadRequest(NewPasswordNotMatch.ExceptionDto);
            }
            catch (ActualPasswordNotMatchException ActualPasswordNotMatch)
            {
                return BadRequest(ActualPasswordNotMatch.ExceptionDto);
            }
            catch (EmailWrongFormatException EmailWrongFormat)
            {
                return BadRequest(EmailWrongFormat.ExceptionDto);
            }
        }

        [HttpPut("{Dni}/tiendas/{IdTienda}")]
        public ActionResult UpdateTienda(string Dni, int IdTienda, TiendaUpdateDto TiendaUpdateDto ) {
            try
            {
                return Ok(_usuarioService.UpdateTienda(Dni, IdTienda, TiendaUpdateDto));
            }
            catch (ActualPasswordNotMatchException e) {
                return BadRequest(e.ExceptionDto); 
            }
        }

    }
}
