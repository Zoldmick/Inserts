using System;

namespace InsertsAPI.Models.Request
{
    public class LoginsRequest
    {
        public int Nivel { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}