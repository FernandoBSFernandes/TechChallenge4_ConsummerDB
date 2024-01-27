using Consummer;
using Consummer.Context;
using Consummer.Eventos;
using Consummer.Profiles;
using Consummer.Repository;
using Consummer.Service;
using MassTransit;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        var configuration = hostContext.Configuration;
        
        #region MassTransit Azure Service Bus Settings
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

        //Adding DBContexts - Trocar nome da string de conexão
        string connectionStringSQLServer = configuration.GetConnectionString("DefaultSQLServerStringConnection");
        services.AddDbContext<UsuarioContext>(settings => settings.UseSqlServer(connectionStringSQLServer));

        services.AddAutoMapper(typeof(ConsummerProfile));

        services.AddTransient<ICadastrarUsuarioService, CadastrarUsuarioService>();
        services.AddTransient<ICadastrarUsuarioRepository, CadastrarUsuarioRepository>();

        services.AddHostedService<Worker>();
    })

    .Build();

host.Run();
