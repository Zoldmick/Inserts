using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        Business.GerenciadorFotos fotos = new Business.GerenciadorFotos();
        Utils.FilmesConversor conv = new Utils.FilmesConversor();

        [HttpPost] // funcionando
        public ActionResult<Models.Response.FilmesResponse> Cadastrar([FromForm] Models.Request.FilmesRequest req)
        {
            try
            {
                Console.WriteLine("start");
                Console.WriteLine(JsonConvert.SerializeObject(req));
                Models.TbFilme ret = conv.ParaTabela(req);
                ret.DsImagem = fotos.NovoNome(req.Imagem.FileName);
                Console.WriteLine(JsonConvert.SerializeObject(ret));
                ctx.TbFilme.Add(ret);
                ctx.SaveChanges();
                Console.WriteLine("DB");

                fotos.SalvarFoto(ret.DsImagem,req.Imagem);
                Console.WriteLine("salvar");
                return conv.ParaResponse(ret);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.Message)
                );   
            }
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}