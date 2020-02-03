using System;
using System.Collections.Generic;
using System.IO;

namespace MES2._0
{
    class GridService
    {
        public static List<double> vectorReset;

        public static void InitializeGlobal(Grid grid, InputData globalData)
        {
            grid.global_H_Matrix = new List<List<double>>();
            grid.global_Hbc_Matrix = new List<List<double>>();
            grid.global_C_Matrix = new List<List<double>>();
            grid.global_P_Vector = new List<double>();
            vectorReset = new List<double>();
            for (int j = 0; j < globalData.nN; j++)
            {
                grid.global_H_Matrix.Add(new List<double>());
                grid.global_Hbc_Matrix.Add(new List<double>());
                grid.global_C_Matrix.Add(new List<double>());
                grid.global_P_Vector.Add(0f);
                // Vektor Resetujący
                vectorReset.Add(0f);
                for (int k = 0; k < globalData.nN; k++)
                {
                    grid.global_H_Matrix[j].Add(0d);
                    grid.global_Hbc_Matrix[j].Add(0d);
                    grid.global_C_Matrix[j].Add(0d);

                }
            }
        }
        public static void AgregateToGlobal_WithElement(Element element, Grid grid)
        {
            for (var i = 0; i < 4; i++)
            {
                grid.global_P_Vector[element.ID[i].ID - 1] += element.P_Vector[i];
                // Vektor Resetujący Vektor P
                vectorReset[element.ID[i].ID - 1] += element.P_Vector[i];
                for (var j = 0; j < 4; j++)
                {
                    grid.global_H_Matrix[element.ID[i].ID - 1][element.ID[j].ID - 1] += element.Matrix_H[i][j];
                    grid.global_Hbc_Matrix[element.ID[i].ID - 1][element.ID[j].ID - 1] += element.Matrix_Hbc[i][j];
                    grid.global_C_Matrix[element.ID[i].ID - 1][element.ID[j].ID - 1] += element.Matrix_C[i][j];
                }
            }
        }
        public static List<List<double>> Count_H_CdT(InputData globalData, Grid grid)
        {
            if (grid.global_H_CdT != null)
                return grid.global_H_CdT;
            grid.global_H_CdT = new List<List<double>>();
            for (int i = 0; i < globalData.nN; i++)
            {
                grid.global_H_CdT.Add(new List<double>());
                for (int j = 0; j < globalData.nN; j++)
                {
                    grid.global_H_CdT[i].Add(grid.global_H_Matrix[i][j] + (grid.global_C_Matrix[i][j] / globalData.step)
                        + grid.global_Hbc_Matrix[i][j]);
                }
            }
            return grid.global_H_CdT;
        }
        public static List<double> Count_P_C_dT_T0(InputData globalData, Grid grid)
        {
            //[H]{t} - {p} = 0;
            if (grid.global_C_dT_T0 == null)
            {
                grid.global_C_dT_T0 = new List<List<double>>();
                for (int i = 0; i < globalData.nN; i++)
                {
                    grid.global_C_dT_T0.Add(new List<double>());
                    for (int j = 0; j < globalData.nN; j++)
                        grid.global_C_dT_T0[i].Add(grid.global_C_Matrix[i][j]);
                }
            }
            else
            // RESET C/dT*T0
            {
                for (int i = 0; i < globalData.nN; i++)
                {
                    for (int j = 0; j < globalData.nN; j++)
                        grid.global_C_dT_T0[i][j] = grid.global_C_Matrix[i][j];
                }
            }
            int div_i = 0;
            for (int i = 0; i < globalData.nN; i++)
            {
                if (i == globalData.nH * (div_i + 1))
                    div_i++;
                for (int j = 0; j < globalData.nN; j++)
                {
                    grid.global_C_dT_T0[i][j] /= globalData.step;
                    grid.global_C_dT_T0[j][i] *= grid.nodes[div_i][i - (globalData.nH * div_i)].t;
                }
            }
            // RESET P
            for (int i = 0; i < globalData.nN; i++)
                if (grid.global_P_Vector[i] != vectorReset[i])
                    grid.global_P_Vector[i] = vectorReset[i];

            for (int i = 0; i < globalData.nN; i++)
                for (int j = 0; j < globalData.nN; j++)
                    grid.global_P_Vector[i] += grid.global_C_dT_T0[i][j];

            return grid.global_P_Vector;
        }
        public static List<double> Count_FinalVector(InputData globalData, Grid grid)
        {
            double m, s, e;
            List<double> FinalVector;
            List<List<double>> tmp;
            e = (double)Math.Pow(10, -12);
            FinalVector = new List<double>();
            for (int i = 0; i < globalData.nN; i++)
                FinalVector.Add(0f);
            tmp = new List<List<double>>();
            for (int i = 0; i < globalData.nN; i++)
            {
                tmp.Add(new List<double>());
                for (int j = 0; j < globalData.nN + 1; j++)
                {
                    if (j < globalData.nN)
                        tmp[i].Add(grid.global_H_CdT[i][j]);
                    else
                        tmp[i].Add(grid.global_P_Vector[i]);
                }
            }
            for (int i = 0; i < globalData.nN - 1; i++)
            {
                for (int j = i + 1; j < globalData.nN; j++)
                {
                    if (Math.Abs(tmp[i][i]) < e)
                    {
                        Console.WriteLine("Can not divide by 0");
                        break;
                    }
                    m = -tmp[j][i] / tmp[i][i];
                    for (int k = 0; k < globalData.nN + 1; k++)
                    {
                        tmp[j][k] += m * tmp[i][k];
                    }
                }
            }
            for (int i = globalData.nN - 1; i >= 0; i--)
            {
                s = tmp[i][globalData.nN];
                for (int j = globalData.nN - 1; j >= 0; j--)
                {
                    s -= tmp[i][j] * FinalVector[j];
                }
                if (Math.Abs(tmp[i][i]) < e)
                {
                    Console.WriteLine("Can not divide by 0");
                    break;
                }
                FinalVector[i] = s / tmp[i][i];
            }
            return FinalVector;
        }
        public static double[] Find_MinmalAndMaximal_Temperarure(List<double> tempVector)
        {
            double[] MinAndMax = new double[2];

            var min = tempVector[0];
            foreach (var value in tempVector)
                if (min > value) min = value;
            MinAndMax[0] = min;

            var max = tempVector[0];
            foreach (var value in tempVector)
                if (max < value) max = value;
            MinAndMax[1] = max;
            return MinAndMax;
        }
        public static void UpdateNodesTemperature(Grid grid, InputData globalData)
        {
            int div_i = 0;
            for (int i = 0; i < globalData.nN; i++)
            {
                if (i == globalData.nH * (div_i + 1))
                    div_i++;
                grid.nodes[div_i][i - (globalData.nH * div_i)].t = grid.finalVector[i];
            }
        }
        public static void Write_Temperature(List<double> tempVector, double iteration,
            EventHandler<string> writeEvent = null, EventHandler<string> writeEvent2 = null)
        {
            double[] temp = Find_MinmalAndMaximal_Temperarure(tempVector);
            var log = "Iteration nr: " + (iteration + 1) + " -> Min = " + temp[0].ToString("#.000") + " Max = " + temp[1].ToString("#.000");
            var log_minMax = "Min = " + temp[0].ToString() + " Max = " + temp[1].ToString();
            Console.WriteLine(log);
            if (writeEvent != null)
                writeEvent.Invoke(null, log);
            if (writeEvent2 != null)
                writeEvent2.Invoke(null, log_minMax);
        }
        public static void SaveToFile(double[] data, InputData inputData, EventHandler<string> writeEvent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "mesOutput.txt"), true))
            {
                for (int i = 0; i < data.Length / 2; i++)
                {
                    if (i == 0)
                    {
                        outputFile.WriteLine();
                        outputFile.WriteLine("Grid H = " + inputData.H + " -> nH = " + inputData.nH);
                        outputFile.WriteLine("Grid W = " + inputData.W + " -> nW = " + inputData.nW);
                        outputFile.WriteLine("Initial Temperature = " + inputData.initial_temp +
                            " -> Ambient Temperature = " + inputData.ambient_temp);
                        outputFile.WriteLine("Simulation Time = " + inputData.simulation_time +
                            " -> Time Step = " + inputData.step);
                        outputFile.WriteLine();
                    }
                    outputFile.WriteLine("Iteration nr: " + i + " -> Min = " + data[i] +
                        " Max = " + data[i + (data.Length / 2)]);
                }
            }
            var log = "Data has been saved.";
            Console.WriteLine(log);
            if (writeEvent != null)
                writeEvent.Invoke(null, log);
        }
    }
}