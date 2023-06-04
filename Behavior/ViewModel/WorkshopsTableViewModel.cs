using Behavior.Command;
using DomainModel.Tables;
using DomainModel;
using System.Windows.Input;

namespace Behavior.ViewModel;

public class WorkshopsTableViewModel : BaseViewModel
{
    private Workshop? _selectedWorkshop;

    public Workshop? SelectedWorkshop
    {
        get => _selectedWorkshop;
        set => SetProperty(ref _selectedWorkshop, value);
    }

    public WorkshopList Workshops { get; } = Storage.Instance.Workshops;
    
    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    public WorkshopsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    private bool CanAddRow() => true;

    private void AddRow() => Workshops.Add(new Workshop());

    private bool CanRemoveRow() => Workshops.Count > 0 && SelectedWorkshop != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedWorkshop!);
}