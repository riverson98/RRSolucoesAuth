using MassTransit;
using Microsoft.Extensions.Logging;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using Shared.Application.Events;
using System.Diagnostics;

namespace RRSolucoesFinanceiraUsers.Application.Services.Events;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IUserService _userService;
    private readonly ILogger<UserCreatedConsumer> _log;

    public UserCreatedConsumer(IUserService userService, ILogger<UserCreatedConsumer> log)
    {
        _userService = userService;
        _log = log;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        try
        {
            var time = new Stopwatch();
            time.Start();
            var userId = context.Message.UserId;
            var userEmail = context.Message.Email;

            _log.LogInformation("🚀 Receiving event of pre-register the user id:{0} e-mail:{1};", userId, userEmail);

            await _userService.AddEmailAndIdInicial(Guid.Parse(userId!), userEmail);

            time.Stop();

            _log.LogInformation("✨ the user was pre-registered successfully id:{0} e-mail:{1} elapsed time:{2} ms", userId, userEmail, time.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error to register the user: {ex.Message}");
        }
    }
}
