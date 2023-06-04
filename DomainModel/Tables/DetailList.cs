using System.Collections.ObjectModel;
using System.Linq;

namespace DomainModel.Tables;

public class DetailList : ObservableCollection<Detail>
{
    public bool Exists(string id)
    {
        return Items.ToList().Exists(d => d.Id.Equals(id));
    }
}