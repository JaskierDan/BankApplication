using BankApplication.Core;

namespace BankApplication.MVVM.ViewModel;

public class MainViewModel : ObserveableObject
{
    public RelayCommand BalanceViewCommand { get; set; }
    public RelayCommand DepositViewCommand { get; set; }
    public RelayCommand WithdrawViewCommand { get; set; }

    public BalanceViewModel BalanceVM { get; set; }
    public DepositViewModel DepositVM { get; set; }
    public WithdrawViewModel WithdrawVM { get; set; }

    private object? _currentView;

	public object CurrentView
    {
        get => _currentView ?? BalanceVM;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }


    public MainViewModel()
    {
        BalanceVM = new BalanceViewModel();
        DepositVM = new DepositViewModel();
        WithdrawVM = new WithdrawViewModel();

		CurrentView = BalanceVM;

        BalanceViewCommand = new RelayCommand(o =>
        {
            CurrentView = BalanceVM;
        });

        DepositViewCommand = new RelayCommand(o =>
        {
            CurrentView = DepositVM;
        });

        WithdrawViewCommand = new RelayCommand(o =>
        {
            CurrentView = WithdrawVM;
        });
    }
}