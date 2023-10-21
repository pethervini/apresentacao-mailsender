using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApresentacaoMailsender.Service.Interface
{
    public interface IMailsenderService
    {
        Task<bool> SendEmail(dynamic sendEmail);
    }
}
