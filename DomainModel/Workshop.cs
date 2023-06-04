namespace DomainModel;

public class Workshop
{
    private static uint _counter = 1;

    public uint Id { get; } = _counter++;

    public string Name { get; set; } = string.Empty;

    public string HeadsNameSurname { get; set; } = string.Empty;
}