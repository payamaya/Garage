// Garage.Enumerator.cs (Partial Class)

using System.Collections;
using System.Collections.Generic;

namespace Garage
{
    public partial class Garage<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
