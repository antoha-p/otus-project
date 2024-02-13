using Infrastructure.EntityFramework.CoreService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CoreService.WebApi.Extensions;
using CoreService.WebApi.Filters;
using CoreService.WebApi.Settings;
using MassTransit;
using Infrastructure.Masstransit;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//регистрируем зависимости
builder.Services.AddBLLServices();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ћикросервис €дра", Version = "v1" });
});
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(CoreDBContext).Assembly);
ConfigurationManager configuration = builder.Configuration;
var databaseConfig = configuration.GetSection("DBConfig").Get<ApplicationSettings>();

builder.Services.AddDbContext<CoreDBContext>(options => options
                .UseNpgsql(builder.Configuration.GetSection("DBConfig").Get<ApplicationSettings>().ConnectionString));

builder.Services.AddControllers(x => x.Filters.Add(typeof(ApiExceptionFilter)));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MassTransitEventConsumer>();
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(MassTransitConstants.MassTransitHost,
            MassTransitConstants.MassTransitVirtualHost,
            h =>
            {
                h.Username(MassTransitConstants.MassTransitUserName);
                h.Password(MassTransitConstants.MassTransitPswrd);
            });
        cfg.ReceiveEndpoint(MassTransitConstants.MassTransitFirstQueueName, ep =>
        {
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<MassTransitEventConsumer>(provider);
        });
        cfg.ReceiveEndpoint(MassTransitConstants.MassTransitSecondQueueName, ep =>
        {
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<MassTransitEventConsumer>(provider);
        });
    }));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
