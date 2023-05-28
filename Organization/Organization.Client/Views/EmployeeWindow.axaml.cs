using Avalonia.Controls;
using Avalonia.Interactivity;
using Organization.Client.ViewModels;

namespace Organization.Client.Views;
public partial class EmployeeWindow : BaseWindow<EmployeeViewModel>
{
    public EmployeeWindow()
    {
        InitializeComponent();
        //this.WhenActivated(disposableObj =>
        //    disposableObj(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
