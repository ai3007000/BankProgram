namespace ConsoleApp.App
{
    /// <summary>
    /// Класс сообщения
    /// </summary>
    class Message
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText;
        public Message(string MessageText)
        {
            this.MessageText = MessageText;
        }
        /// <summary>
        /// Печать сообщения
        /// </summary>
        public void PrintMessage(string MessageText)
        {
            Console.WriteLine(MessageText);
        }
    }
    class EmailMessage : Message
    {
        public EmailMessage(string MessageText) : base(MessageText) { }
    }
    /// <summary>
    /// Мессенджер
    /// </summary>
    class Messenger
    {
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">Тип сообщения</param>
        public static void SendMessage<T>(T message) where T : Message
        {
            message.PrintMessage(message.MessageText);
        }
    }
}
