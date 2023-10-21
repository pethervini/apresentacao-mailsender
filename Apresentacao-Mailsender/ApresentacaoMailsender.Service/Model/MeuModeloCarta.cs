using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApresentacaoMailsender.Service.Model
{
    public class MeuModeloCarta
    {
        public MeuModeloCarta(string to, string from, string subject, string nome)
        {
            To = to;
            From = from;
            Subject = subject;
            Nome = nome;
        }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Nome { get; set; }
    }
}
