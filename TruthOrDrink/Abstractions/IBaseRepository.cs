using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthOrDrink.Abstractions
{
    public interface IBaseRepository<T> :IDisposable where T : TableData, new()
    {
        // Create/Update
        void SaveEntity(T entity);

        // Read One/ Read Many
        T? GetEntity(int id);

        List<T> GetEntities();

        // Delete
        void DeleteEnity(T entity);
    }
}
