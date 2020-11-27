using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
                
                Console.WriteLine("start");
                TbTrailer trailer = conv.ParaTabela(req);
                trailer.NmTrailer = buss.NovoNome(req.Trailer.FileName);
                Console.WriteLine("salvar no banco");
                ctx.Add(trailer);
                ctx.SaveChanges();
                Console.WriteLine("salvo");
                buss.SalvarFoto(trailer.NmTrailer,req.Trailer);
                Console.WriteLine("Concluido");
                return trailer.NmTrailer;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro {ex.Message}");
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