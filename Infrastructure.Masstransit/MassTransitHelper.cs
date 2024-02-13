using MassTransit;
using Services.Abstractions.Masstransit;
using Services.Contracts.Masstransit;

namespace Infrastructure.Masstransit;

public class MassTransitHelper : IMassTransitHelper
{
    /// <summary>
    /// слушаем сообщения из очереди
    /// </summary>
    /// <param name="queueName"></param>
    /// <returns></returns>
    public async Task ReceiveMessageAsync(string queueName)
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            Configure(cfg);
            RegisterEndPoints(cfg, queueName);
        });
        await busControl.StartAsync();
        try
        {
            while (true);
        }
        finally
        {
            await busControl.StopAsync();
        }
    }
    /// <summary>
    /// отправка сообщений в очередь
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="queueName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task SendMessageAsync(MessageDto dto, string queueName)
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(Configure);

        await busControl.StartAsync();
        try
        {
            var sendEndpoint = await busControl.GetSendEndpoint(new Uri($"queue:{queueName}"));
            if (sendEndpoint is null)
                throw new Exception($"Не удалось найти очередь {queueName}");

            await sendEndpoint.Send(dto, CancellationToken.None);
        }
        finally
        {
            await busControl.StopAsync();
        }
    }
    /// <summary>
    /// конфиги MqRabbit
    /// </summary>
    /// <param name="configurator"></param>
    public static void Configure(IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Host(MassTransitConstants.MassTransitHost,
            MassTransitConstants.MassTransitVirtualHost,
            h =>
            {
                h.Username(MassTransitConstants.MassTransitUserName);
                h.Password(MassTransitConstants.MassTransitPswrd);
            });
    }

    /// <summary>
    /// регистрация эндпоинтов
    /// </summary>
    /// <param name="configurator"></param>
    /// <param name="queueName"></param>
    private static void RegisterEndPoints(IRabbitMqBusFactoryConfigurator configurator, string queueName)
    {
        configurator.ReceiveEndpoint(queueName, e =>
        {
            e.Consumer(() => new MassTransitEventConsumer());
            e.UseMessageRetry(r =>
            {
                //r.Ignore<ArithmeticException>(); игнориование исключения
                r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1)); ///повторные отправки , при возникновении исключения
            });
        });
    }
}
