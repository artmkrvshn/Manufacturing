using System.Windows.Input;
using Behavior.Command;
using CommunityToolkit.Mvvm.ComponentModel;
using DomainModel;
using DomainModel.Tables;

namespace Behavior.ViewModel;

public partial class WorkshopsTableViewModel : ObservableObject
{
    [ObservableProperty] private Workshop? _selectedWorkshop;

    public WorkshopsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    public WorkshopList Workshops { get; } = Storage.Instance.Workshops;

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    private bool CanAddRow() => true;

    private void AddRow() => Workshops.Add(new Workshop());

    private bool CanRemoveRow() => Workshops.Count > 0 && SelectedWorkshop != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedWorkshop!);
}