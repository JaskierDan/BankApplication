using BankApplication.Core;
using System;

namespace BankApplication.MVVM.ViewModel;

public class BalanceViewModel : ObserveableObject
{
	private double _balance;

	public string Balance
	{
		get { return _balance.ToString("0.00"); }
		set { _balance = Convert.ToDouble(value); }
	}

	private double _apy;

	public string APY
	{
		get { return _apy.ToString("0.00"); }	
		set { _apy = Convert.ToDouble(value); }
	}

	public int Percentage { get; set; }

    public BalanceViewModel()
    {
		var model = BalanceManager.GetBalanceModel();

		BalanceManager.SaveBalance(model);

        _balance = model.Balance;
		_apy = model.APY;
		Percentage = model.Percentage;
    }
}