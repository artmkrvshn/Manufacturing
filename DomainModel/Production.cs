using System.Linq;

namespace DomainModel;

public class Production : BaseModel
{
    private string _detailId = "00.00.00";

    private uint _workshopId = 0;

    private double _cost = 0.0;

    private uint _durationInHours = 0;

    private uint _operationNumber = 1;

    public string DetailId
    {
        get => _detailId;
        set => SetField(ref _detailId, value);
    }

    public Detail? Detail
    {
        get => Storage.Instance.Details.ToList().Find(d => d.Id.Equals(_detailId));
        set
        {
            if (value != null)
                DetailId = value.Id;
        }
    }

    public uint WorkshopId
    {
        get => _workshopId;
        set => SetField(ref _workshopId, value);
    }

    public Workshop? Workshop
    {
        get => Storage.Instance.Workshops.ToList().Find(w => w.Id.Equals(_workshopId));
        set
        {
            if (value != null)
                WorkshopId = value.Id;
        }
    }

    public double Cost
    {
        get => _cost;
        set => SetField(ref _cost, value);
    }

    public uint DurationInHours
    {
        get => _durationInHours;
        set => SetField(ref _durationInHours, value);
    }

    public uint OperationNumber
    {
        get => _operationNumber;
        set => SetField(ref _operationNumber, value);
    }
}