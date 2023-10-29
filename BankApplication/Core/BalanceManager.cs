using BankApplication.MVVM.Model;
using System;
using System.IO;
using System.Text.Json;

namespace BankApplication.Core;

public static class BalanceManager
{
    public static BalanceModel GetBalanceModel()
    {
        string balanceModelRaw;
        BalanceModel balanceModel;

        try
        {
            balanceModelRaw = File.ReadAllText(@"balanceModel.json");
            balanceModel = JsonSerializer.Deserialize<BalanceModel>(balanceModelRaw) ?? new BalanceModel();

            return balanceModel;
        }
        catch
        {
            return new BalanceModel();            
        }
    }

    public static void SaveBalance(BalanceModel? balanceModel)
    {
        try
        {
            var jsonObject = JsonSerializer.Serialize(balanceModel);

            File.WriteAllText(@"balanceModel.json", jsonObject);
        }
        catch { }
    }

    public static void Deposit(double? amount)
    {
        try
        {
            var model = GetBalanceModel();

            model.Balance += amount ?? 0;

            if (model.Balance > 100 && model.Balance <= 1000)
                model.Percentage = 5;
            else if (model.Balance > 1000)
                model.Percentage = 7;

            model.APY = model.Balance * Convert.ToDouble($@"1.0{model.Percentage}");

            SaveBalance(model);
        }
        catch { }
    }

    public static void Withdraw(double? amount)
    {
        try
        {
            var model = GetBalanceModel();            

            model.Balance -= amount ?? 0;

            if (model.Balance > 100 && model.Balance <= 1000)
                model.Percentage = 5;
            else if (model.Balance > 1000)
                model.Percentage = 7;

            model.APY = model.Balance * Convert.ToDouble($@"1.0{model.Percentage}");

            SaveBalance(model);
        }
        catch { }
    }
}