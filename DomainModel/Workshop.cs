using CommunityToolkit.Mvvm.ComponentModel;

namespace DomainModel;

public partial class Workshop : ObservableObject
{
    private static uint _counter = 1;

    [ObservableProperty] private string _headsNameSurname = string.Empty;

    [ObservableProperty] private uint _id = _counter++;

    [ObservableProperty] private string _name = string.Empty;
}