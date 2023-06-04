using System.Linq;
using DomainModel.Tables;

namespace DomainModel;

public class Storage
{
    private static Storage? _instance;

    private Storage()
    {
        WorkshopsInit();
        DetailsInit();
        ProductionsInit();
    }

    public static Storage Instance => _instance ??= new Storage();

    public WorkshopList Workshops { get; } = new();

    public DetailList Details { get; } = new();

    public ProductionList Productions { get; } = new();

    public void RemoveCascade(Production production)
    {
        Productions.Remove(production);
    }

    public void RemoveCascade(Detail detail)
    {
        foreach (Production production in Productions.ToList())
            if (production.Detail != null && production.Detail.Equals(detail))
                RemoveCascade(production);
        Details.Remove(detail);
    }

    public void RemoveCascade(Workshop workshop)
    {
        foreach (Production production in Productions.ToList())
            if (production.Workshop != null && production.Workshop.Equals(workshop))
                RemoveCascade(production);
        Workshops.Remove(workshop);
    }

    #region Storage Init

    private void WorkshopsInit()
    {
        Workshops.Add(new Workshop { Name = "Workshop 1", HeadsNameSurname = "Volodymyr Zelenskyy" });
        Workshops.Add(new Workshop { Name = "Workshop 2", HeadsNameSurname = "Petro Poroshenko" });
        Workshops.Add(new Workshop { Name = "Workshop 3", HeadsNameSurname = "Viktor Yushchenko" });
        Workshops.Add(new Workshop { Name = "Workshop 4", HeadsNameSurname = "Leonid Kuchma" });
        Workshops.Add(new Workshop { Name = "Workshop 5", HeadsNameSurname = "Leonid Kravchuk" });
    }

    private void DetailsInit()
    {
        Details.Add(new Detail { Name = "Bolt", AlloyGrade = "Grade A", WeightKg = 0.1 });
        Details.Add(new Detail { Name = "Nut", AlloyGrade = "Grade B", WeightKg = 0.05 });
        Details.Add(new Detail { Name = "Screw", AlloyGrade = "Grade C", WeightKg = 0.02 });
        Details.Add(new Detail { Name = "Washer", AlloyGrade = "Grade A", WeightKg = 0.08 });
        Details.Add(new Detail { Name = "Spring", AlloyGrade = "Grade B", WeightKg = 0.03 });
        Details.Add(new Detail { Name = "Pin", AlloyGrade = "Grade C", WeightKg = 0.01 });
        Details.Add(new Detail { Name = "Bracket", AlloyGrade = "Grade A", WeightKg = 0.2 });
        Details.Add(new Detail { Name = "Clip", AlloyGrade = "Grade B", WeightKg = 0.07 });
        Details.Add(new Detail { Name = "Plate", AlloyGrade = "Grade C", WeightKg = 0.15 });
        Details.Add(new Detail { Name = "Ring", AlloyGrade = "Grade A", WeightKg = 0.04 });
    }

    private void ProductionsInit()
    {
        Productions.Add(new Production
            { Detail = Details[2], Workshop = Workshops[2], Cost = 356, DurationInHours = 3, OperationNumber = 3 });
        Productions.Add(new Production
            { Detail = Details[3], Workshop = Workshops[3], Cost = 412, DurationInHours = 4, OperationNumber = 4 });
        Productions.Add(new Production
            { Detail = Details[4], Workshop = Workshops[4], Cost = 529, DurationInHours = 5, OperationNumber = 5 });
        Productions.Add(new Production
            { Detail = Details[5], Workshop = Workshops[0], Cost = 623, DurationInHours = 6, OperationNumber = 6 });
        Productions.Add(new Production
            { Detail = Details[6], Workshop = Workshops[4], Cost = 712, DurationInHours = 7, OperationNumber = 7 });
        Productions.Add(new Production
            { Detail = Details[7], Workshop = Workshops[0], Cost = 845, DurationInHours = 8, OperationNumber = 8 });
        Productions.Add(new Production
            { Detail = Details[8], Workshop = Workshops[4], Cost = 923, DurationInHours = 9, OperationNumber = 9 });
        Productions.Add(new Production
            { Detail = Details[9], Workshop = Workshops[3], Cost = 142, DurationInHours = 10, OperationNumber = 10 });
        Productions.Add(new Production
            { Detail = Details[0], Workshop = Workshops[2], Cost = 253, DurationInHours = 3, OperationNumber = 3 });
        Productions.Add(new Production
            { Detail = Details[3], Workshop = Workshops[1], Cost = 321, DurationInHours = 2, OperationNumber = 2 });
        Productions.Add(new Production
            { Detail = Details[5], Workshop = Workshops[0], Cost = 432, DurationInHours = 5, OperationNumber = 5 });
        Productions.Add(new Production
            { Detail = Details[0], Workshop = Workshops[1], Cost = 511, DurationInHours = 4, OperationNumber = 4 });
        Productions.Add(new Production
            { Detail = Details[9], Workshop = Workshops[4], Cost = 642, DurationInHours = 6, OperationNumber = 6 });
        Productions.Add(new Production
            { Detail = Details[2], Workshop = Workshops[2], Cost = 173, DurationInHours = 2, OperationNumber = 2 });
        Productions.Add(new Production
            { Detail = Details[4], Workshop = Workshops[3], Cost = 289, DurationInHours = 3, OperationNumber = 3 });
        Productions.Add(new Production
            { Detail = Details[6], Workshop = Workshops[0], Cost = 376, DurationInHours = 4, OperationNumber = 4 });
        Productions.Add(new Production
            { Detail = Details[8], Workshop = Workshops[1], Cost = 478, DurationInHours = 5, OperationNumber = 5 });
        Productions.Add(new Production
            { Detail = Details[9], Workshop = Workshops[2], Cost = 571, DurationInHours = 6, OperationNumber = 6 });
        Productions.Add(new Production
            { Detail = Details[3], Workshop = Workshops[3], Cost = 192, DurationInHours = 2, OperationNumber = 2 });
    }

    #endregion
}