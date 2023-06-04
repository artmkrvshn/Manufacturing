using System.Windows.Input;
using Behavior.Command;
using DomainModel;
using DomainModel.Tables;

namespace Behavior.ViewModel;

public class DetailsTableViewModel : BaseViewModel
{
    private Detail? _selectedDetail;

    public Detail? SelectedDetail
    {
        get => _selectedDetail;
        set => SetProperty(ref _selectedDetail, value);
    }

    public DetailList Details { get; } = Storage.Instance.Details;

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    public DetailsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    private bool CanAddRow() => true;

    private void AddRow() => Details.Add(new Detail());

    private bool CanRemoveRow() => Details.Count > 0 && SelectedDetail != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedDetail!);
}