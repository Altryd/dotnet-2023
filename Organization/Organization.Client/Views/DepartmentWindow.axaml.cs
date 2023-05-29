using Avalonia.Interactivity;
using Organization.Client.ViewModels;
using ReactiveUI;
using System;

namespace Organization.Client.Views;
public partial class DepartmentWindow : BaseWindow<DepartmentViewModel>
{
    public DepartmentWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposableObj =>
            disposableObj(ViewModel!.OnSubmitCommand.Subscribe(Close)));
    }

    public void CancelButtonOnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
