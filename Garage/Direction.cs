using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Direction
    {
        public static Position North => new Position(row: -1, col: 0);
        public static Position South => new Position(row: 1, col: 0);
        public static Position West => new Position(row: 0, col: -1);
        public static Position East => new Position(row: 0, col: 1);
    }
}
