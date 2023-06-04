using System;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DomainModel;

public partial class Detail : ObservableObject
{
    private static uint _counter = 1;

    private string _id = $"{DateTime.Today.Day:00}.{DateTime.Today.Month:00}.{_counter++:00}";

    public string Id
    {
        get => _id;
        set
        {
            // format: dd.MM.counter
            const string pattern = @"^(0[1-9]|[1-2][0-9]|3[0-1])\.(0[1-9]|1[0-2])\.(0[1-9]|[1-9][0-9])$";
            if (!Regex.IsMatch(value, pattern)) return;
            if (Storage.Instance.Details.Exists(value)) return;
            _id = value;
        }
    }

    [ObservableProperty] private string _name = string.Empty;

    [ObservableProperty] private double _weightKg = 0.0;

    [ObservableProperty] private string _alloyGrade = string.Empty;
}