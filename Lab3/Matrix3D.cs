using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Matrix3D<T>
    {
        private readonly Dictionary<string, T> matrix = new Dictionary<string, T>();

        private readonly int maxX;

        private readonly int maxY;

        private readonly int maxZ;

        private readonly T nullElement;

        public Matrix3D(int x, int y, int z, T nullElementParam)
        {
            maxX = x;
            maxY = y;
            maxZ = z;
            nullElement = nullElementParam;
        }

        public T this[int x, int y, int z]
        {
            get
            {
                var key = DictKey(x, y, z);

                return matrix.ContainsKey(key) ? matrix[key] : nullElement;
            }
            set => matrix.Add(DictKey(x, y, z), value);
        }

        private string DictKey(int x, int y, int z)
        {
            if (x < 0 || x >= maxX) throw new Exception($"x = {x} выходит за границы");
            if (y < 0 || y >= maxY) throw new Exception($"y = {y} выходит за границы");
            if (z < 0 || z >= maxY) throw new Exception($"z = {z} выходит за границы");

            return $"{x}_{y}_{z}";
        }
        
        public override string ToString()
        {
            var str = new StringBuilder();

            for (var k = 0; k < maxZ; k++)
            {
                for (var j = 0; j < maxY; j++)
                {
                    str.Append("[");
                    for (var i = 0; i < maxX; i++)
                    {
                        if (i > 0) str.Append("\t");

                        str.Append(this[i, j, k]);
                    }
                    str.Append("]\n");
                }
                str.Append("\n");
            }
            
            return str.ToString();
        }
    }
}