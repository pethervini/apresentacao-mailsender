using ApresentacaoMailsender.Service.Interface;
using ApresentacaoMailsender.Service.Model;
using MailSender.Transacional.Client;
using Microsoft.Extensions.Configuration;
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
    public class ServiceEnvio : IHostedService, IDisposable
    {
        private readonly IMailsenderService _mailSenderService;
        private readonly IConfiguration _configuration;

        public ServiceEnvio(IConfiguration configuration, IMailsenderService mailSenderService)
        {
            _configuration = configuration;
            _mailSenderService = mailSenderService;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async  Task StartAsync(CancellationToken cancellationToken)
        {
            var dataToMailSender = new MeuModeloCarta("pethersonamorim@bne.com.br","pethervini@gmail.com", "minha carta para apresentacao","Petherson");

            dynamic objeto = new ExpandoObject();
            objeto.parameters = dataToMailSender;
            objeto.template = _configuration["TemplateIdCarta"];
            objeto.processKey = _configuration["ProcessKeyBNE"];

            await _mailSenderService.SendEmail(JsonConvert.SerializeObject(objeto));
        }

    public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
