using System;
using System.Collections.Generic;


namespace MES2._0
{
    class UniversalElement
    {
        public double[] Weight = new double[2];
        public double[] Point = new double[2];

        public struct PC
        {
            public int Id;
            public List<double> Matrix_N;
            public List<double> Matrix_dNdKsi;
            public List<double> Matrix_dNdEta;

            public double dXdKsi;
            public double dXdEta;
            public double dYdKsi;
            public double dYdEta;

            public List<List<double>> Matrix_J;
            public List<List<double>> Matrix_J_Transposed;
            public List<List<double>> Inverse_Matrix_J;
            public double DetJ;

            public List<double> dNdX;
            public List<double> dNdY;
            public List<List<double>> dNdX_dNdX_Transposed_Matrix;
            public List<List<double>> dNdY_dNdY_Transposed_Matrix;
            public List<List<double>> N_N_Transparent;

            public List<List<double>> Local_H_Matrix;
            public List<List<double>> Local_H_BC_Matrix;
            public List<List<double>> Local_C_Matrix;
        }
        public struct PcBC
        {
            public double Ksi;
            public double Eta;
            public List<double> Matrix_N_BC;
            public List<List<double>> Matrix_N_Transp_BC;

        };
        public struct Lateral_Surface
        {
            public List<PcBC> pcBCs;
            public List<List<double>> sum;
            public List<double> VectorSum;
        };

        List<Lateral_Surface> Lateral_Surface_List = new List<Lateral_Surface>();
        List<PcBC> pcBCs = new List<PcBC>();
        List<PC> PcList = new List<PC>();

        List<List<double>> Matrix_H;
        List<List<double>> Matrix_C;
        List<List<double>> Matrix_Hbc;
        List<double> P_Vector;
        List<List<double>> Matrix_H_plus_H_bc;

        public UniversalElement(Element elementGlobal, InputData globalData)
        {
            Weight[0] = 1;
            Weight[1] = 1;
            Point[0] = -1 / Math.Sqrt(3);
            Point[1] = 1 / Math.Sqrt(3);

            List<double> _Set_Ksi_Eta = new List<double>();
            double Ksi = 0, Eta = 0;

            //Obliczenia
            for (int i = 0; i < 4; i++)
            {

                _Set_Ksi_Eta = Set_Ksi_Eta(i);
                Ksi = _Set_Ksi_Eta[0];
                Eta = _Set_Ksi_Eta[1];

                //PUNKT CAŁKOWANIA
                PC Pc = new PC();
                Pc.Id = i;
                Pc.dXdKsi = 0;
                Pc.dXdEta = 0;
                Pc.dYdKsi = 0;
                Pc.dYdEta = 0;

                Pc.Matrix_N = Matrix_N(Ksi, Eta);
                Pc.Matrix_dNdKsi = Matrix_dNdKsi(Eta);
                Pc.Matrix_dNdEta = Matrix_dNdEta(Ksi);

                //JAKOBIANY PRZEKSZTAŁCENIA
                for (int j = 0; j < 4; j++)
                {
                    Pc.dXdKsi += ((Pc.Matrix_dNdKsi[j]) * elementGlobal.ID[j].x);
                    Pc.dXdEta += ((Pc.Matrix_dNdEta[j]) * elementGlobal.ID[j].x);
                    Pc.dYdKsi += ((Pc.Matrix_dNdKsi[j]) * elementGlobal.ID[j].y);
                    Pc.dYdEta += ((Pc.Matrix_dNdEta[j]) * elementGlobal.ID[j].y);
                }


                //J
                Pc.Matrix_J = new List<List<double>>();
                Pc.Matrix_J_Transposed = new List<List<double>>();
                Pc.Inverse_Matrix_J = new List<List<double>>();
                for (int j = 0; j < 2; j++)
                {
                    Pc.Matrix_J.Add(new List<double>());
                    Pc.Matrix_J_Transposed.Add(new List<double>());
                    Pc.Inverse_Matrix_J.Add(new List<double>());
                }
                Pc.Matrix_J[0].Add(Pc.dXdKsi);
                Pc.Matrix_J[0].Add(Pc.dYdKsi);
                Pc.Matrix_J[1].Add(Pc.dXdEta);
                Pc.Matrix_J[1].Add(Pc.dYdEta);

                //J Trans
                Pc.Matrix_J_Transposed[0].Add(Pc.Matrix_J[1][1]);
                Pc.Matrix_J_Transposed[0].Add(-Pc.Matrix_J[0][1]);
                Pc.Matrix_J_Transposed[1].Add(-Pc.Matrix_J[1][0]);
                Pc.Matrix_J_Transposed[1].Add(Pc.Matrix_J[0][0]);

                //Det[J]
                Pc.DetJ = (Pc.Matrix_J[0][0] * Pc.Matrix_J[1][1]) - (Pc.Matrix_J[0][1] * Pc.Matrix_J[1][0]);

                //Inverse J
                for (int j = 0; j < 2; j++)
                {
                    Pc.Inverse_Matrix_J[j].Add(Pc.Matrix_J_Transposed[j][0] / Pc.DetJ);
                    Pc.Inverse_Matrix_J[j].Add(Pc.Matrix_J_Transposed[j][1] / Pc.DetJ);
                }

                //dN/dX dN/dY
                Pc.dNdX = new List<double>();
                Pc.dNdY = new List<double>();
                for (int j = 0; j < 4; j++)
                {
                    Pc.dNdX.Add((Pc.Inverse_Matrix_J[0][0] * Pc.Matrix_dNdKsi[j]) +
                        (Pc.Inverse_Matrix_J[0][1] * Pc.Matrix_dNdEta[j]));
                    Pc.dNdY.Add((Pc.Inverse_Matrix_J[1][0] * Pc.Matrix_dNdKsi[j]) +
                        (Pc.Inverse_Matrix_J[1][1] * Pc.Matrix_dNdEta[j]));
                }

                //{dN/dX)(dN/dX} Transp. {dN/dY)(dN/dY} Transp. {N}{N} Transp.
                Pc.dNdX_dNdX_Transposed_Matrix = Matrix_Matrix_Transposed_optionalParam(Pc.dNdX, 1.0);
                Pc.dNdY_dNdY_Transposed_Matrix = Matrix_Matrix_Transposed_optionalParam(Pc.dNdY, 1.0);
                Pc.N_N_Transparent = Matrix_Matrix_Transposed_optionalParam(Pc.Matrix_N, 1.0);

                //Local H Matrix Local C Matrix
                Pc.Local_H_Matrix = new List<List<double>>();
                Pc.Local_H_BC_Matrix = new List<List<double>>();
                Pc.Local_C_Matrix = new List<List<double>>();
                for (int j = 0; j < 4; j++)
                {
                    Pc.Local_H_Matrix.Add(new List<double>());
                    Pc.Local_H_BC_Matrix.Add(new List<double>());
                    Pc.Local_C_Matrix.Add(new List<double>());

                    for (int k = 0; k < 4; k++)
                    {
                        Pc.Local_H_Matrix[j].Add(globalData.K * (((Pc.dNdX_dNdX_Transposed_Matrix[j][k]) +
                            (Pc.dNdY_dNdY_Transposed_Matrix[j][k])) * Pc.DetJ));
                        Pc.Local_C_Matrix[j].Add(globalData.c * globalData.ro *
                            Pc.N_N_Transparent[j][k] * Pc.DetJ);
                    }
                }

                PcList.Add(Pc);
                Lateral_Surface_List.Add(_Set_Lateral_Surface(i, globalData));

            }

            //Macierz H Matrix C Vector P
            Matrix_H = new List<List<double>>();
            Matrix_H_plus_H_bc = new List<List<double>>();
            Matrix_C = new List<List<double>>();
            P_Vector = new List<double>();
            double H_Matrix_Index = 0;
            double C_Matrix_Index = 0;
            for (int i = 0; i < 4; i++)
            {
                Matrix_H.Add(new List<double>());
                Matrix_H_plus_H_bc.Add(new List<double>());
                Matrix_C.Add(new List<double>());
                P_Vector.Add(0f);
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        H_Matrix_Index += PcList[k].Local_H_Matrix[i][j];
                        C_Matrix_Index += PcList[k].Local_C_Matrix[i][j];
                    }
                    Matrix_H[i].Add(H_Matrix_Index);
                    Matrix_H_plus_H_bc[i].Add(H_Matrix_Index);
                    Matrix_C[i].Add(C_Matrix_Index);
                    H_Matrix_Index = 0;
                    C_Matrix_Index = 0;
                }
            }

            Matrix_Hbc = Matrix_H_Bc(elementGlobal, Lateral_Surface_List);
            P_Vector = Vector_P(elementGlobal, Lateral_Surface_List);
            Matrix_H_plus_H_bc = ArraySumary(Matrix_H_plus_H_bc, Matrix_Hbc);

            // Przypisanie do elementu
            elementGlobal.Matrix_H = Matrix_H;
            elementGlobal.Matrix_Hbc = Matrix_Hbc;
            elementGlobal.Matrix_H_plus_H_bc = Matrix_H_plus_H_bc;
            elementGlobal.Matrix_C = Matrix_C;
            elementGlobal.P_Vector = P_Vector;
        }
        public List<List<double>> Matrix_H_Bc(Element globalElement, List<Lateral_Surface> lateral_Surfaces)
        {
            List<List<double>> Matrix_H_Bc = new List<List<double>>();
            for (int i = 0; i < 4; i++)
            {
                Matrix_H_Bc.Add(new List<double>());
                for (int j = 0; j < 4; j++)
                {
                    Matrix_H_Bc[i].Add(0);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != 3 && globalElement.ID[i].BC == true && globalElement.ID[i + 1].BC == true)
                    ArraySumary(Matrix_H_Bc, Lateral_Surface_List[i].sum);
                if (i == 3 && globalElement.ID[i].BC == true && globalElement.ID[0].BC == true)
                    ArraySumary(Matrix_H_Bc, Lateral_Surface_List[i].sum);
            }
            return Matrix_H_Bc;
        }
        public List<double> Vector_P(Element globalElement, List<Lateral_Surface> lateral_Surfaces)
        {
            List<double> Vector_P = new List<double>();
            for (int i = 0; i < 4; i++)
            {
                Vector_P.Add(new double());
            }
            for (int i = 0; i < 4; i++)
            {
                if (i != 3 && globalElement.ID[i].BC == true && globalElement.ID[i + 1].BC == true)
                    VectorSumary(Vector_P, Lateral_Surface_List[i].VectorSum);
                if (i == 3 && globalElement.ID[i].BC == true && globalElement.ID[0].BC == true)
                    VectorSumary(Vector_P, Lateral_Surface_List[i].VectorSum);
            }
            return Vector_P;
        }
        public List<List<double>> ArraySumary(List<List<double>> ArrayResult, List<List<double>> ArrayToAdd)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ArrayResult[i][j] += ArrayToAdd[i][j];
                }
            }
            return ArrayResult;
        }
        public List<double> VectorSumary(List<double> VectorResult, List<double> VectorToAdd)
        {
            for (int i = 0; i < 4; i++)
            {
                VectorResult[i] += VectorToAdd[i];
            }
            return VectorResult;
        }
        public List<double> Set_Ksi_Eta(int i)
        {
            List<double> Set_Ksi_Eta = new List<double>();
            // WSP. PUNKTÓW CAŁKOWANIA 
            if (i == 0)
            {
                Set_Ksi_Eta.Add(Point[0]);
                Set_Ksi_Eta.Add(Point[0]);
            }
            else if (i == 1)
            {
                Set_Ksi_Eta.Add(Point[1]);
                Set_Ksi_Eta.Add(Point[0]);
            }
            else if (i == 2)
            {
                Set_Ksi_Eta.Add(Point[1]);
                Set_Ksi_Eta.Add(Point[1]);
            }
            else if (i == 3)
            {
                Set_Ksi_Eta.Add(Point[0]);
                Set_Ksi_Eta.Add(Point[1]);
            }
            return Set_Ksi_Eta;
        }
        public Lateral_Surface _Set_Lateral_Surface(int i, InputData globalData)
        {
            Lateral_Surface lateral_surface = new Lateral_Surface();
            lateral_surface.pcBCs = new List<PcBC>();
            double surface_length = 0;

            //Punkty całkowania na pow. bocznych
            if (i == 0)
            {
                surface_length = globalData.W / (globalData.nW - 1);
                PcBC pcBC = new PcBC();
                pcBC.Ksi = Point[0];
                pcBC.Eta = -1;
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
                pcBC.Ksi = Point[1];
                pcBC.Eta = -1;
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
            }
            else if (i == 1)
            {
                surface_length = globalData.H / (globalData.nH - 1);
                PcBC pcBC = new PcBC();
                pcBC.Ksi = 1;
                pcBC.Eta = Point[0];
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
                pcBC.Ksi = 1;
                pcBC.Eta = Point[1];
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
            }
            else if (i == 2)
            {
                surface_length = globalData.W / (globalData.nW - 1);
                PcBC pcBC = new PcBC();
                pcBC.Ksi = Point[1];
                pcBC.Eta = 1;
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
                pcBC.Ksi = Point[0];
                pcBC.Eta = 1;
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
            }
            else if (i == 3)
            {
                surface_length = globalData.H / (globalData.nH - 1);
                PcBC pcBC = new PcBC();
                pcBC.Ksi = -1;
                pcBC.Eta = Point[1];
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
                pcBC.Ksi = -1;
                pcBC.Eta = Point[0];
                pcBC.Matrix_N_BC = Matrix_N(pcBC.Ksi, pcBC.Eta);
                pcBC.Matrix_N_Transp_BC = Matrix_Matrix_Transposed_optionalParam(pcBC.Matrix_N_BC, globalData.alfa);
                lateral_surface.pcBCs.Add(pcBC);
            }
            double DetJ = surface_length / 2;
            lateral_surface.sum = new List<List<double>>();
            lateral_surface.VectorSum = new List<double>();
            for (int j = 0; j < 4; j++)
            {
                // Vector P
                lateral_surface.sum.Add(new List<double>());
                lateral_surface.VectorSum.Add((lateral_surface.pcBCs[0].Matrix_N_BC[j] +
                    lateral_surface.pcBCs[1].Matrix_N_BC[j]) * DetJ * globalData.alfa * globalData.ambient_temp);
                for (int k = 0; k < 4; k++)
                {
                    lateral_surface.sum[j].Add((lateral_surface.pcBCs[0].Matrix_N_Transp_BC[j][k] +
                        lateral_surface.pcBCs[1].Matrix_N_Transp_BC[j][k]) * DetJ);
                }

            }
            return lateral_surface;
        }
        public List<double> Matrix_N(double Ksi, double Eta)
        {
            List<double> Matrix_N_PC = new List<double>();

            //W DANYM PUNKCIE
            // WARTOŚCI FUNKCJI KRZTAŁTU
            Matrix_N_PC.Add((0.25 * (1 - Ksi) * (1 - Eta)));
            Matrix_N_PC.Add((0.25 * (1 + Ksi) * (1 - Eta)));
            Matrix_N_PC.Add((0.25 * (1 + Ksi) * (1 + Eta)));
            Matrix_N_PC.Add((0.25 * (1 - Ksi) * (1 + Eta)));
            return Matrix_N_PC;
        }
        public List<double> Matrix_dNdKsi(double Eta)
        {
            List<double> Matrix_dNdKsi_PC = new List<double>();
            Matrix_dNdKsi_PC.Add(item: (-0.25 * (1 - Eta)));
            Matrix_dNdKsi_PC.Add(item: (0.25 * (1 - Eta)));
            Matrix_dNdKsi_PC.Add(item: (0.25 * (1 + Eta)));
            Matrix_dNdKsi_PC.Add(item: (-0.25 * (1 + Eta)));
            return Matrix_dNdKsi_PC;
        }
        public List<double> Matrix_dNdEta(double Ksi)
        {
            List<double> Matrix_dNdEta_PC = new List<double>();
            Matrix_dNdEta_PC.Add(item: (-0.25 * (1 - Ksi)));
            Matrix_dNdEta_PC.Add(item: (-0.25 * (1 + Ksi)));
            Matrix_dNdEta_PC.Add(item: (0.25 * (1 + Ksi)));
            Matrix_dNdEta_PC.Add(item: (0.25 * (1 - Ksi)));
            return Matrix_dNdEta_PC;
        }
        public List<List<double>> Matrix_Matrix_Transposed_optionalParam(List<double> Matrix_N, double param)
        {
            List<List<double>> Matrix_Matrix_Transposed = new List<List<double>>();
            for (int i = 0; i < 4; i++)
            {
                Matrix_Matrix_Transposed.Add(new List<double>());
                for (int j = 0; j < 4; j++)
                {
                    Matrix_Matrix_Transposed[i].Add(param * Matrix_N[i] * Matrix_N[j]);
                }
            }
            return Matrix_Matrix_Transposed;
        }
        public void Write()
        {
            Console.WriteLine("MATRIX N");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                        Console.Write("Point " + (PcList[i].Id + 1) + ": ");
                    if (j < 3)
                        Console.Write(PcList[i].Matrix_N[j] + " - ");
                    else
                        Console.WriteLine(PcList[i].Matrix_N[j]);
                }
            }
            Console.WriteLine();

            Console.WriteLine("MATRIX dN/dKsi");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                        Console.Write("Point " + (PcList[i].Id + 1) + ": ");
                    if (j < 3)
                        Console.Write(PcList[i].Matrix_dNdKsi[j] + " - ");
                    else
                        Console.WriteLine(PcList[i].Matrix_dNdKsi[j]);
                }
            }
            Console.WriteLine();

            Console.WriteLine("MATRIX dN/dEta");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                        Console.Write("Point " + (PcList[i].Id + 1) + ": ");
                    if (j < 3)
                        Console.Write(PcList[i].Matrix_dNdEta[j] + " - ");
                    else
                        Console.WriteLine(PcList[i].Matrix_dNdEta[j]);
                }
            }
            Console.WriteLine();

            Console.WriteLine("MATRIX H");
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (j == 0)
                        Console.WriteLine(Matrix_H[i][j]);
                    if (j > 0)
                        Console.Write(Matrix_H[i][j] + " - ");
                }
            }
            Console.WriteLine();

            /*Console.WriteLine("MATRIX H_Bc");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 3)
                        Console.WriteLine(Matrix_Hbc[j][i]);
                    if (j < 3)
                        Console.Write(Matrix_Hbc[j][i] + " - ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Vector_p");
            for(int i = 0; i < 4; i++)
            {
                {
                    if (i == 3)
                        Console.WriteLine(P_Vector[i]);
                    if (i < 3)
                        Console.Write(P_Vector[i] + " - ");
                }
            }*/


            Console.WriteLine("MATRIX C");
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (j == 0)
                        Console.WriteLine(Matrix_C[i][j]);
                    if (j > 0)
                        Console.Write(Matrix_C[i][j] + " - ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Jakobiany");
            for (int k = 0; k < 4; k++)
            {
                Console.WriteLine("Point: " + (k + 1));
                for (int i = 1; i >= 0; i--)
                {
                    for (int j = 1; j >= 0; j--)
                    {
                        if (j == 0)
                            Console.WriteLine(PcList[k].Matrix_J[i][j]);
                        if (j > 0)
                            Console.Write(PcList[k].Matrix_J[i][j] + " - ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("DetJ");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Point: " + (i + 1) + " = " + (PcList[i].DetJ));
            }
            Console.WriteLine();
        }
    }
}