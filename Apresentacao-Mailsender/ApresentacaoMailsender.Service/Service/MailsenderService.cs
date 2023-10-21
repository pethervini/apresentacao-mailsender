using ApresentacaoMailsender.Service.Interface;
using MailSender.API;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApresentacaoMailsender.Service.Service
{
    public class MailsenderService : IMailsenderService
    {
        private readonly IConfiguration _config;
        private readonly Client _client;

        public MailsenderService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _client = new Client(_config["Mailsender"], httpClientFactory.CreateClient());
        }

        public async Task<bool> SendEmail(dynamic sendEmail)
        {
            var sendDynamic = JsonConvert.DeserializeObject<SendDynamicCommand>(sendEmail);

            var result = await _client.RabbitSendTransacionalAsync(sendDynamic);

            return result;
        }
    }
}
