using Behavior.Command;
using DomainModel;
using System.Windows.Input;
using DomainModel.Tables;

namespace Behavior.ViewModel;

public class ProductionsTableViewModel : BaseViewModel
{
    private Production? _selectedProduction;

    public Production? SelectedProduction
    {
        get => _selectedProduction;
        set => SetProperty(ref _selectedProduction, value);
    }

    public ProductionList Productions { get; } = Storage.Instance.Productions;
    
    public WorkshopList Workshops { get; } = Storage.Instance.Workshops;

    public DetailList Details { get; } = Storage.Instance.Details;

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    public ProductionsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    private bool CanAddRow() => Workshops.Count > 0 && Details.Count > 0;

    private void AddRow() => Productions.Add(new Production());

    private bool CanRemoveRow() => Productions.Count > 0 && SelectedProduction != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedProduction!);
}