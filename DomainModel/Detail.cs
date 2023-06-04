using System;
using System.Text.RegularExpressions;

namespace DomainModel;

public class Detail
{
    private static uint _counter = 1;

    private string _id = $"{DateTime.Today.Day:00}.{DateTime.Today.Month:00}.{_counter++:00}";

    private double _weightKg = 0.0;

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

    public string Name { get; set; } = string.Empty;

    public string AlloyGrade { get; set; } = string.Empty;

    public double WeightKg
    {
        get => _weightKg;
        set
        {
            if (value <= 0) return;
            _weightKg = value;
        }
    }
}