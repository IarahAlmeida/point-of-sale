using Application.Services;
using Domain.Repositories;
using Infrastructure.Persistence.MessageQueue;
using Infrastructure.Persistence.Repositories;

namespace Presentation;

public class Program
{
    protected Program()
    {
    }

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IMessageQueueService, Producer>();
        builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}