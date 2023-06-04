using System.Windows.Input;
using Behavior.Command;
using CommunityToolkit.Mvvm.ComponentModel;
using DomainModel;
using DomainModel.Tables;

namespace Behavior.ViewModel;

public partial class ProductionsTableViewModel : ObservableObject
{
    [ObservableProperty] private Production? _selectedProduction;

    public ProductionsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    public ProductionList Productions { get; } = Storage.Instance.Productions;

    public WorkshopList Workshops { get; } = Storage.Instance.Workshops;

    public DetailList Details { get; } = Storage.Instance.Details;

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    private bool CanAddRow() => Workshops.Count > 0 && Details.Count > 0;

    private void AddRow() => Productions.Add(new Production());

    private bool CanRemoveRow() => Productions.Count > 0 && SelectedProduction != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedProduction!);
}