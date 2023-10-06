using System;


namespace ConsoleApp.App
{

    class Program
    {
        static void Main()
        {
            Account human1 = new Account("Artem Ivanov", "Sberbank", "5555-9999-8888-7777", 21896);
            Account human2 = new Account("Liara Ivanova", "Sberbank", "5555-1111-8888-3333", 212896);

            human1.AccountHundlerMessage += Console.WriteLine;
            human2.AccountHundlerMessage += Console.WriteLine;

            Request request = new Request();
            request.RequestAccount(Request.RequestAction.GetSum, human1);
            request.RequestAccount(Request.RequestAction.GetSum, human2);
            human1.PutMoney(8986);
            human2.TakeMoney(12786);
            request.RequestAccount(Request.RequestAction.GetSum, human1);
            request.RequestAccount(Request.RequestAction.GetSum, human2);

        }
    }
}