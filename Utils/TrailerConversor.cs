using System;

using InsertsAPI.Models;
using InsertsAPI.Models.Request;

namespace InsertsAPI.Utils
{
    public class TrailerConversor
    {
        public TbTrailer ParaTabela(TrailerRequest req)
        {
            return new TbTrailer {
                BtDublado = req.Dublado,
                NrDuracao = req.Duracao,
                IdFilme = req. Filme
            };
        }
    }
}