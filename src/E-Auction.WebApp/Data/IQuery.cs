using System.Collections.Generic;

namespace EAuction.WebApp.Data
{
    public interface IQuery<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
    }
}
