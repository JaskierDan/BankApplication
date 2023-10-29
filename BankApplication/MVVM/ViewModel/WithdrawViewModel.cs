using BankApplication.Core;

namespace BankApplication.MVVM.ViewModel;

public class WithdrawViewModel : ObserveableObject
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