using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Converter
{
    private Dictionary<string, decimal> currencyRates;

    public Converter(decimal usdRate, decimal eurRate)
    {
        currencyRates = new Dictionary<string, decimal>
        {
            { "USD", usdRate },
            { "EUR", eurRate }
        };
    }

    public void AddOrUpdateCurrency(string currency, decimal rate)
    {
        currencyRates[currency] = rate;
        Console.WriteLine($"Курс для {currency} успішно додано або змінено.");
    }

    public void ShowAvailableCurrencies()
    {
        Console.WriteLine("Доступні валюти:");
        foreach (var currency in currencyRates.Keys)
        {
            Console.WriteLine($"- {currency}");
        }
    }

    public decimal ConvertFromUAH(decimal amount, string currency)
    {
        if (TryGetRate(currency, out decimal rate))
        {
            return amount / rate;
        }
        return 0;
    }

    public decimal ConvertToUAH(decimal amount, string currency)
    {
        if (TryGetRate(currency, out decimal rate))
        {
            return amount * rate;
        }
        return 0;
    }

    private bool TryGetRate(string currency, out decimal rate)
    {
        if (!currencyRates.TryGetValue(currency, out rate))
        {
            Console.WriteLine($"Курс для валюти {currency} не знайдений.");
            return false;
        }
        return true;
    }
}