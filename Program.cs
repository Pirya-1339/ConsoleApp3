using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ConsoleApp3;


var botClient = new TelegramBotClient("5309738011:AAGbGOCM9HioJM2Tg4057uYKutT8dZSxbT0");

using var cts = new CancellationTokenSource();  //Создаёт объект для остановки

var receiverOptions = new ReceiverOptions //задаём реакцию,те на какие сообщения реагирует бот
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
updateHandler: BotHandlers.HandleUpdateAsync,
pollingErrorHandler: BotHandlers.HandlePollingErrorAsync,
receiverOptions: receiverOptions,
cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine("Bot started");
Console.WriteLine($"Start listening for @{me.Username}");
Console.WriteLine("Press enter for stop");
Console.ReadKey();

cts.Cancel();

Console.WriteLine("Bot stopped");