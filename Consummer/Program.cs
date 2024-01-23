using Consummer;
using Consummer.Eventos;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        var configuration = hostContext.Configuration;
        #region masstransitazureservicebus
        var connectionString = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;

        services.AddMassTransit(x =>
        {
            x.AddConsumer<CadastroCliente>();
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(connectionString);
                cfg.ReceiveEndpoint("fila", e =>
                {
                    e.ConfigureConsumer<CadastroCliente>(context);
                });
            });
        });

        #endregion
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
