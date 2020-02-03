using System.Collections.Generic;

namespace MES2._0
{
    public class Element
    {
        public Node[] ID = new Node[4];
        public int Number;

        public List<List<double>> Matrix_H;
        public List<List<double>> Matrix_C;
        public List<List<double>> Matrix_Hbc;
        public List<double> P_Vector;
        public List<List<double>> Matrix_H_plus_H_bc;
        public void ResetMatrixes()
        {
            Matrix_H = null;
            Matrix_C = null;
            Matrix_Hbc = null;
            Matrix_H_plus_H_bc = null;
            P_Vector = null;
        }
    }
}