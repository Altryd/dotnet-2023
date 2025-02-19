﻿using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace Organization.Client.ViewModels;
public class OccupationViewModel : ViewModelBase
{
    private int _id;
    public int Id
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }
    private string _name;
    [Required]
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public ReactiveCommand<Unit, OccupationViewModel> OnSubmitCommand { get; }

    public OccupationViewModel()
    {
        OnSubmitCommand = ReactiveCommand.Create(() => this);
    }
}
