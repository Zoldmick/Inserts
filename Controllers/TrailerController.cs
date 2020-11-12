using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using InsertsAPI.Models;
using InsertsAPI.Utils;
using InsertsAPI.Models.Request;
using InsertsAPI.Business;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrailersController : ControllerBase
    {
        TrailerConversor conv = new TrailerConversor();
        tcdbContext ctx = new tcdbContext();
        GerenciadorFotos buss = new GerenciadorFotos();

        [HttpPost] // Inserir trailer
        public ActionResult<string> Cadastrar([FromForm] TrailerRequest req)
        {
            try
            {
                TbTrailer trailer = conv.ParaTabela(req);
                trailer.NmTrailer = buss.NovoNome(req.Trailer.FileName);
                ctx.Add(trailer);
                ctx.SaveChanges();    
                buss.SalvarFoto(trailer.NmTrailer,req.Trailer);
                Console.WriteLine("Concluido");
                return trailer.NmTrailer;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new NotFoundResult();
            }
        }

        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}