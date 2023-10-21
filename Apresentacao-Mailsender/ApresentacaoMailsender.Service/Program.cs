using ApresentacaoMailsender.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder();

builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    config.AddEnvironmentVariables();

    if (args != null)
    {
        config.AddCommandLine(args);
    }
});



builder.ConfigureServices((hostingContext, services) =>
{
    var urlMailSenderTransacionalAPI = hostingContext.Configuration["MailSenderTransacionalApi"];

    services.AddSingleton<MailSender.Transacional.Client.IClient>(new MailSender.Transacional.Client.Client(urlMailSenderTransacionalAPI, new HttpClient()));
    services.AddSingleton<IHostedService, Service>();
});

await builder.RunConsoleAsync();