using ConsoleApp;

namespace ConsoleApp.App
{
    /// <summary>
    /// Операция запроса
    /// </summary>
    class Request
    {
        /// <summary>
        /// Время текущего запроса
        /// </summary>
        private DateTime time;
        /// <summary>
        /// Действия запроса
        /// </summary>
        public enum RequestAction
        {
            GetName, // Получить имя клиента банка
            GetBankAccount, // Получить счёт клиента банка
            GetBankName, // Получить имя банка клиента
            GetSum // Получить текущий баланс счета клиента
        }
        public Request()
        {
            time = DateTime.Now;
        }
        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="action">Действие запроса</param>
        /// <param name="account">Клиент банка</param>
        public void RequestAccount(RequestAction action, Account account)
        {
            string message = ""; // Текст сообщения
            message += $"Время запроса: {this.time}\n";
            switch (action)
            {
                case RequestAction.GetName:
                    message += account.GetName();
                    break;
                case RequestAction.GetBankAccount:
                    message += account.GetBankAccount();
                    break;
                case RequestAction.GetBankName:
                    message += account.GetBankName();
                    break;
                case RequestAction.GetSum:
                    message += account.GetSum();
                    break;
            }
            message += $"\n{new String('-', 20)}";
            Messenger.SendMessage<Message>(new Message(message));
        }
    }
}
