using BankApplication.Core;
using BankApplication.MVVM.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace BankApplication.MVVM.View;

/// <summary>
/// Interaction logic for DepositView.xaml
/// </summary>
public partial class DepositView : UserControl
{
    public DepositView()
    {
        InitializeComponent();
    }

    private void DepositBtn_Click(object sender, RoutedEventArgs e)
    {        
        if (DataContext is DepositViewModel model)
        {
            BalanceManager.Deposit(model.Amount);
            MoneyTextInput.Text = "";
        }
    }

    private void MoneyTextInput_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        bool approvedDecimalPoint = false;

        if (e.Text == ".")
        {
            if (!((TextBox)sender).Text.Contains("."))
                approvedDecimalPoint = true;
        }

        if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
            e.Handled = true;
    }
}