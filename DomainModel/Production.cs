using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DomainModel;

public partial class Production : ObservableObject
{
    [ObservableProperty] private double _cost;

    [ObservableProperty] private string _detailId = "00.00.00";

    [ObservableProperty] private uint _durationInHours;

    [ObservableProperty] private uint _operationNumber = 1;

    [ObservableProperty] private uint _workshopId;

    public Detail? Detail
    {
        get => Storage.Instance.Details.ToList().Find(d => d.Id.Equals(DetailId));
        set
        {
            if (value != null)
                DetailId = value.Id;
        }
    }

    public Workshop? Workshop
    {
        get => Storage.Instance.Workshops.ToList().Find(w => w.Id.Equals(WorkshopId));
        set
        {
            if (value != null)
                WorkshopId = value.Id;
        }
    }
}