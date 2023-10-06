
namespace ConsoleApp.App
{
    /// <summary>
    /// Персона
    /// </summary>
    class Person
    {
        /// <summary>
        /// Имя персоны
        /// </summary>
        protected string Name;
        public Person(string Name)
        {
            this.Name = Name;
        }
        /// <summary>
        /// Показать имя
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return $"Имя: {this.Name}";
        }
    }
    /// <summary>
    /// Клиент
    /// </summary>
    class Client : Person
    {
        /// <summary>
        /// Счёт банка
        /// </summary>
        protected string BankAccount;
        /// <summary>
        /// Название банка
        /// </summary>
        protected string BankName;
        public Client(string Name, string BankName, string BankAccount) : base(Name)
        {
            this.BankName = BankName;
            this.BankAccount = BankAccount;
        }
        /// <summary>
        /// Показать номер счёта
        /// </summary>
        /// <returns></returns>
        public string GetBankAccount()
        {
            return $"{base.GetName()}\nНомер счёта: {this.BankAccount}";
        }
        /// <summary>
        /// Показать название банка
        /// </summary>
        /// <returns></returns>
        public string GetBankName()
        {
            return $"{base.GetName()}\nБанк: {this.BankName}";
        }
    }
    /// <summary>
    /// Клиент банка
    /// </summary>
    class Account : Client
    {
        /// <summary>
        /// Кол-во денег на счету
        /// </summary>
        private decimal Money;
        public delegate void AccountHundler(string message);
        public event AccountHundler? AccountHundlerMessage;
        public Account(string Name, string BankName, string BankAccount, decimal Money) : base(Name, BankName, BankAccount)
        {
            this.Money = Money;
        }
        /// <summary>
        /// Показать кол-во денег на счету
        /// </summary>
        /// <returns></returns>
        public string GetSum()
        {
            return $"{base.GetName()}\nБаланс: {this.Money}";
        }
        /// <summary>
        /// Пополнение счёта
        /// </summary>
        /// <param name="sum">Сумма пополнения счёта</param>
        public void PutMoney(decimal sum)
        {
            this.Money += sum;
            AccountHundlerMessage?.Invoke($"{base.GetBankAccount()}\nПополнение баланса на сумму {sum} руб.");
        }
        /// <summary>
        /// Снятие денег со счёта
        /// </summary>
        /// <param name="sum">Кол-во снимаемых денег</param>
        public void TakeMoney(decimal sum)
        {
            if (this.Money < sum) AccountHundlerMessage?.Invoke($"{base.GetBankAccount}\nНа вашем счёте недостаточно средств.");
            else
            {
                this.Money -= sum;
                AccountHundlerMessage?.Invoke($"{base.GetBankAccount()}\nСнятие с счёта {sum} руб.\nБаланс: {this.Money}");
            }
        }
    }
}
