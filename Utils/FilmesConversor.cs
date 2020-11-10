using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertsAPI.Utils
{
    public class FilmesConversor
    {
        public Models.TbFilme ParaTabela(Models.Request.FilmesRequest req)
        {
            return new Models.TbFilme {
                NmFilme = req.Nome,
                DsGenero = req.Genero,
                NrClassificacao = req.Classificacao,
                DsSinopse = req.Sinopse,
                BtEstreia = req.Estreia,
                NrDuracao = req.Duracao,
                BtBreve = req.Breve
            };
        }

        public Models.Response.FilmesResponse ParaResponse(Models.TbFilme tb)
        {
            return new Models.Response.FilmesResponse {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Classificacao = tb.NrClassificacao,
                Sinopse = tb.DsSinopse,
                Estreia = tb.BtEstreia,
                Duracao = tb.NrDuracao,
                Breve = tb.BtBreve,
                Imagem = tb.DsImagem
            };
        }
    }
}