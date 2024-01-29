# TechChallenge4
## Segue abaixo a arquitetura inicial planejada para este tech challenge: 
![Tech4 drawio](https://github.com/JairJr/TechChallenge4_v2/assets/29376086/c8bb320b-cbc5-48e7-938b-b46382434cd6)

## Temos as seguintes soluções:

► App Android em MAUI que funciona como uma interface com o usuário.

► API producer para registrar no service bus o objeto.

► Service Bus, que fará a tratativa de fila para o consumer atuar.

► Serviço Consumer que será responsável por registrar o cliente e enviar o email de confirmação.

# Referências

[MAUI](https://learn.microsoft.com/pt-br/dotnet/maui/what-is-maui?view=net-maui-8.0)
[Azure Service Bus](https://learn.microsoft.com/pt-br/azure/service-bus-messaging/service-bus-messaging-overview)
[Brevo - Envio de emails](https://www.brevo.com/pt/)
