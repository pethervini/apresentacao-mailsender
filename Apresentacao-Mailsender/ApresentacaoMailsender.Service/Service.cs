using MailSender.Transacional.Client;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApresentacaoMailsender.Service
{
    public class Service : IHostedService, IDisposable
    {
        private readonly IClient _mailsSenderTransacionalAPI;

        public Service(IClient mailsSenderTransacionalAPI)
        {
            _mailsSenderTransacionalAPI = mailsSenderTransacionalAPI;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async  Task StartAsync(CancellationToken cancellationToken)
        {
            dynamic parameters = new ExpandoObject();
            parameters.Nome = "Petherson";
            var objParameters = JsonConvert.SerializeObject(parameters);

            var objToSend = new SendMailTransacionalRequest()
            { //Objeto de Requisição
                AplicationTrigger = TriggerAplicationsTransacional.API_EMPRESA,
                DtaTrigger = DateTime.Now,
                From = "bne@bne.com.br",
                ProcessKey = "TEMPTESTETESTETESTET",
                TemplateId = new Guid("d438c7e7-9246-4052-b8fe-12ab8805bdd2"),
                To = new List<string>() { "pethersonamorim@bne.com.br" },
                Data = objParameters,
                Title = "Teste de envio de email"
            };


    }

    public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
