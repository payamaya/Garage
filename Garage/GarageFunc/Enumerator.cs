using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage
{
    public partial class Garage<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in _spots)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
