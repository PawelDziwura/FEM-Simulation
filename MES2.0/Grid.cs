using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MES2._0
{
    public class Grid
    {
        public event EventHandler<string> writeEvent;
        public event EventHandler<string> writeTemperatureEvent;
        public event EventHandler<Tuple<double, double, int>> progressEvent;

        public List<List<Node>> nodes { get; set; }
        public List<List<Element>> elements { get; set; }
        public List<List<double>> global_H_Matrix { get; set; }
        public List<List<double>> global_Hbc_Matrix { get; set; }
        public List<List<double>> global_C_Matrix { get; set; }
        public List<double> global_P_Vector { get; set; }
        public List<List<double>> global_H_CdT { get; set; }
        public List<List<double>> global_C_dT_T0 { get; set; }
        public List<double> finalVector { get; set; }
        public List<List<double>> iteration_finalVectors { get; set; }

        private void GridGeneration(InputData inputData)
        {
            double dx = inputData.W / (inputData.nW - 1);
            double dy = inputData.H / (inputData.nH - 1);

            Console.Write("Grid Generation -> ");
            //NODES
            nodes = new List<List<Node>>();
            for (int i = 0; i < inputData.nW; i++)
            {
                nodes.Add(new List<Node>());
                for (int j = 0; j < inputData.nH; j++)
                {
                    if (i == 0 || i == inputData.nW - 1 || j == 0 || j == inputData.nH - 1)
                        nodes[i].Add(new Node()
                        {
                            x = dx * i,
                            y = dy * j,
                            t = inputData.initial_temp,
                            ID = (i * inputData.nH) + j + 1,
                            BC = true
                        });
                    else
                        nodes[i].Add(new Node()
                        {
                            x = dx * i,
                            y = dy * j,
                            t = inputData.initial_temp,
                            ID = (i * inputData.nH) + j + 1,
                            BC = false
                        });
                }
            }
            //ELEMENTS
            elements = new List<List<Element>>();
            for (int i = 0; i < inputData.nW - 1; i++)
            {
                elements.Add(new List<Element>());
                for (int j = 0; j < inputData.nH - 1; j++)
                    elements[i].Add(new Element()
                    {
                        ID = new[] { nodes[i][j], nodes[i + 1][j], nodes[i + 1][j + 1], nodes[i][j + 1] },
                        Number = (i * (inputData.nH - 1)) + j + 1
                    });
            }
            Console.WriteLine("Generation Completed.");
        }
        private void AllElements_To_UniversalElement(InputData inputData)
        {
            Console.Write("Conversion To Local System -> ");
            for (int i = 0; i < inputData.nW - 1; i++)
            {
                for (int j = 0; j < inputData.nH - 1; j++)
                {
                    //Console.WriteLine("Element: " + elements[i][j].Number);
                    UniversalElement universalElement = new UniversalElement(elements[i][j], inputData);
                    // universalElement.Write();
                }
            }
            Console.WriteLine("Conversion Completed.");
        }
        private void Aggregation(InputData inputData)
        {
            Console.Write("Aggregation -> ");
            for (int i = 0; i < inputData.nW - 1; i++)
            {
                for (int j = 0; j < inputData.nH - 1; j++)
                {
                    GridService.AgregateToGlobal_WithElement(elements[i][j], this);
                }
            }
            Console.WriteLine("Agregation Completed.");
        }
        private void OutputData(int iteration, InputData inputData, double[] output)
        {
            double[] tmp;
            tmp = GridService.Find_MinmalAndMaximal_Temperarure(finalVector);
            output[(iteration)] = tmp[0];
            output[(output.Length / 2) + iteration] = tmp[1];
        }
        public double[] Calculate(InputData inputData)
        {
            var watch = Stopwatch.StartNew();
            double[] output = new double[Convert.ToInt32(2 * (inputData.simulation_time / inputData.step))];
            iteration_finalVectors = new List<List<double>>();
            GridService.InitializeGlobal(this, inputData);
            GridGeneration(inputData);
            Write(inputData);
            progressEvent.Invoke(null, Tuple.Create(0.0, inputData.simulation_time, 0));
            AllElements_To_UniversalElement(inputData);
            Aggregation(inputData);
            GridService.Count_H_CdT(inputData, this);
            for (var i = 0d; i < inputData.simulation_time; i += inputData.step)
            {
                iteration_finalVectors.Add(new List<double>());
                GridService.Count_P_C_dT_T0(inputData, this);
                finalVector = GridService.Count_FinalVector(inputData, this);
                iteration_finalVectors[Convert.ToInt32(i / inputData.step)] = finalVector;
                OutputData(Convert.ToInt32(i / inputData.step), inputData, output);
                GridService.Write_Temperature(finalVector, (i / inputData.step), writeEvent, writeTemperatureEvent);
                GridService.UpdateNodesTemperature(this, inputData);
                progressEvent.Invoke(null, Tuple.Create(i + inputData.step, inputData.simulation_time,
                    Convert.ToInt32((i / inputData.step) + 1)));
            }
            watch.Stop();
            var elapsedTime = watch.Elapsed;
            Console.WriteLine(elapsedTime);
            if (writeEvent != null)
                writeEvent.Invoke(null, "Calculation tiome: " + elapsedTime.ToString());
            return output;
        }
        private void Write(InputData inputData)
        {
            Console.WriteLine("GRID" + "\n");
            Console.WriteLine("GRID OF NODES");
            for (int j = inputData.nH - 1; j >= 0; j--)
            {
                for (int i = 0; i <= inputData.nW - 1; i++)
                {
                    if (i < inputData.nW - 1)
                        Console.Write(nodes[i][j].ID + "-");
                    else
                        Console.WriteLine(nodes[i][j].ID);
                }
            }
            Console.WriteLine('\n' + "GRID OF ELEMENTS");
            for (int j = inputData.nH - 2; j >= 0; j--)
            {
                for (int i = 0; i <= inputData.nW - 2; i++)
                {
                    if (i < inputData.nW - 2)
                        Console.Write(elements[i][j].Number + "-");
                    else
                        Console.WriteLine(elements[i][j].Number);
                }
            }
            Console.WriteLine('\n' + "ELEMENTS ID");
            for (int i = 0; i <= (inputData.nW - 2); i++)
            {
                for (int j = 0; j <= (inputData.nH - 2); j++)
                    Console.WriteLine("Element nr: " + elements[i][j].Number +
                        " -> ID: [" + elements[i][j].ID[0].ID + "," +
                        elements[i][j].ID[1].ID + "," +
                        elements[i][j].ID[2].ID + "," +
                        elements[i][j].ID[3].ID + "]");
            }
            Console.WriteLine('\n' + "BC");
            for (int j = inputData.nH - 1; j >= 0; j--)
            {
                for (int i = 0; i <= inputData.nW - 1; i++)
                {
                    if (i < inputData.nW - 1)
                    {
                        if (nodes[i][j].BC == true)
                            Console.Write(nodes[i][j].ID + "(1) - ");
                        else
                            Console.Write(nodes[i][j].ID + "(0) - ");
                    }
                    else
                    {
                        if (nodes[i][j].BC == true)
                            Console.WriteLine(nodes[i][j].ID + "(1)");
                        else
                            Console.WriteLine(nodes[i][j].ID + "(0)");
                    }
                }
            }
        }
        public void Reset()
        {
            foreach (var column in elements)
            {
                foreach (var element in column)
                {
                    element.ResetMatrixes();
                }
            }
            global_C_dT_T0 = null;
            global_C_Matrix = null;
            global_H_Matrix = null;
            global_Hbc_Matrix = null;
            global_H_CdT = null;
            global_P_Vector = null;
        }
        public void SaveToFile(double[] outputData, InputData inputData)
        {
            GridService.SaveToFile(outputData, inputData, writeEvent);
        }
    }
}