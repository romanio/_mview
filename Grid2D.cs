using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class Grid2D
    {
        ECL.Cell CELL;

        public void GenerateGrid(EclipseProject ecl, Func<int, float> GetValue)
        {
            unsafe
            {
                float* vertex_mem = (float*)VertexPtr;
                int* index_mem = (int*)ElementPtr;
                byte* color_mem = (byte*)(VertexPtr + ecl.INIT.NACTIV * sizeof(float) * 3 * 8);


            }
        }
    }
}
