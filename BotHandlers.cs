using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace ConsoleApp3
{
    internal static class BotHandlers
    {
        public async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;
            var chatId = message.Chat.Id;

            /*Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Привет, путник напиши пожалуйста своё имя");
            return;
            */


            if (message.Text.ToLower() == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать в нашем баре, добрый путник!");
                return;
            }
                await botClient.SendTextMessageAsync(message.Chat, "Введи имя пожалуйста!");
                // чё сюда надо?
                await botClient.SendTextMessageAsync(chatId: chatId, text: "Ну удачного путешествия");
            
        }
        public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
