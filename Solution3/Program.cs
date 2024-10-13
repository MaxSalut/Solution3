using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        const decimal rateEUR = 45.0m;
        const decimal rateUSD = 41.0m;
        var converter = new Converter(rateUSD, rateEUR);
        bool run = true;
        while (run)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ConvertFromUAH(converter);
                    break;
                case "2":
                    ConvertToUAH(converter);
                    break;
                case "3":
                    AddOrUpdateCurrency(converter);
                    break;
                case "4":
                    Console.WriteLine("Програма завершена.");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Оберіть операцію:");
        Console.WriteLine("1. Конвертувати з гривні в іншу валюту");
        Console.WriteLine("2. Конвертувати з валюти в гривню");
        Console.WriteLine("3. Додати або змінити курс валюти");
        Console.WriteLine("4. Вийти");
    }

    static void ConvertFromUAH(Converter converter)
    {
        decimal amount = GetAmount("гривнях");
        converter.ShowAvailableCurrencies();
        string currency = GetCurrency();

        decimal result = converter.ConvertFromUAH(amount, currency);
        if (result > 0)
        {
            Console.WriteLine($"{amount} грн = {result:F2} {currency}");
        }
    }

    static void ConvertToUAH(Converter converter)
    {
        
        decimal amount = GetAmount("");
        converter.ShowAvailableCurrencies();
        string currency = GetCurrency();

        decimal result = converter.ConvertToUAH(amount, currency);
        if (result > 0)
        {
            Console.WriteLine($"{amount} {currency} = {result:F2} грн");
        }
    }

    static void AddOrUpdateCurrency(Converter converter)
    {
        converter.ShowAvailableCurrencies();
        string currency = GetCurrency();
        decimal rate = GetRate();  // Тепер змінна rate існує в цьому методі
        converter.AddOrUpdateCurrency(currency, rate);
    }

    static decimal GetAmount(string currencyType)
    {
        decimal amount = 0;
        Console.Write($"Введіть суму в {currencyType}: ");
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Будь ласка, введіть коректну суму.");
        }

        return amount;
    }

    static string GetCurrency()
    {
        Console.Write("Введіть код валюти (наприклад, USD, EUR): ");
        return Console.ReadLine().ToUpper();
    }

    static decimal GetRate()
    {
        decimal rate = 0;
        Console.Write("Введіть курс цієї валюти по відношенню до гривні: ");
        while (!decimal.TryParse(Console.ReadLine(), out rate) || rate <= 0)
        {
            Console.WriteLine("Будь ласка, введіть коректний курс.");
        }
        return rate;
    }
}
