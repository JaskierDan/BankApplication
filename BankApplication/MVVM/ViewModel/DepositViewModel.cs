using BankApplication.Core;

namespace BankApplication.MVVM.ViewModel;

public class DepositViewModel : ObserveableObject
{
	private double? amount;

	public double? Amount
	{
		get { return amount; }
		set 
		{
			amount = value;
			OnPropertyChanged();
		}
	}
}