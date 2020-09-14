using System.Collections.Generic;

namespace DataMovementLayer
{
    interface IDataProvider
    {
        IList<T> Load<T>(string connectionString);
        void Save<T>();

    }
}
