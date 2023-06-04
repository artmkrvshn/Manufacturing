using System.Windows.Input;
using Behavior.Command;
using CommunityToolkit.Mvvm.ComponentModel;
using DomainModel;
using DomainModel.Tables;

namespace Behavior.ViewModel;

public partial class DetailsTableViewModel : ObservableObject
{
    [ObservableProperty] private Detail? _selectedDetail;

    public DetailsTableViewModel()
    {
        AddCommand = new RelayCommand(_ => CanAddRow(), _ => AddRow());
        RemoveCommand = new RelayCommand(_ => CanRemoveRow(), _ => RemoveRow());
    }

    public DetailList Details { get; } = Storage.Instance.Details;

    public ICommand AddCommand { get; }

    public ICommand RemoveCommand { get; }

    private bool CanAddRow() => true;

    private void AddRow() => Details.Add(new Detail());

    private bool CanRemoveRow() => Details.Count > 0 && SelectedDetail != null;

    private void RemoveRow() => Storage.Instance.RemoveCascade(SelectedDetail!);
}