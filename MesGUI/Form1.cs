using MES2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMES
{
    public partial class MesForm : Form
    {
        public double H = 0.1;
        public double W = 0.1;
        public int nH = 4;
        public int nW = 4;
        public int nN;
        public int nE;
        public double K = 25;
        public double alfa = 300;
        public double ro = 7800;
        public double c = 700;
        public double ambient_temp = 1200;
        public double initial_temp = 100;
        public double step = 50;
        public double simulation_time = 500;
        public Bitmap DrawArea;


        public Grid grid;
        public double[] output;

        public MesForm()
        {
            InitializeComponent();
            grid = new Grid();
            SetScale(ambient_temp);
            grid.writeEvent += UpdateOutput;
            grid.writeTemperatureEvent += Update_IterationTemp_label;
            grid.progressEvent += UpdateProgress;
        }

        public void Update_IterationTemp_label(object sender, string message)
        {            
            if (!InvokeRequired)
            {
                iteration_MaxMin.Text = message;
                iteration_MaxMin.Refresh();
            }
            else
                Invoke(new Action<object, string>(Update_IterationTemp_label), sender, message);
        }

        public void UpdateOutput(object sender, string message)
        {
            if (!InvokeRequired)
            {
                outputData_textBox.AppendText(message);
                outputData_textBox.AppendText(Environment.NewLine);
            }
            else
                Invoke(new Action<object, string>(UpdateOutput), sender, message);
        }

        public void UpdateProgress(object sender, Tuple<double, double, int> values)
        {
            if (!InvokeRequired)
            {
                progressBar.Value = (int)(values.Item1 / values.Item2 * 100);
                iterationSimulationTime_label.Text = "Simulation Time: " + ((values.Item3) * step).ToString() + " s";
                iterationSimulationTime_label.Refresh();
                Draw();
                iterations_comboBox_SelectedIndexChanged(sender, values.Item3);
            }
            else
                Invoke(new Action<object, Tuple<double, double, int>>(UpdateProgress), sender, values);
        }

        private void Draw()
        {
            Graphics graphics = pictureBox.CreateGraphics();
            int x = 0;
            int y = 0;
            int d;
            SolidBrush brush = new SolidBrush(Color.White);
            if (nW > nH)
                d = pictureBox.Width / nW;
            else
                d = pictureBox.Height / nH;
            foreach (var column in grid.nodes)
            {
                foreach (var node in column)
                {
                    brush.Color = SetNodeColor(node);
                    graphics.FillRectangle(brush, x, y, d, d);
                    y += d;
                }
                y = 0;
                x += d;
            }
            graphics.DrawLine(new Pen(Color.Black), (d * nW) / 2, 0, (d * nW) / 2, d * nH);
            graphics.DrawLine(new Pen(Color.Black), 0, (d * nH) / 2, d * nW, (d * nH) / 2);
        }

        private Color SetNodeColor(Node node)
        {
            double tempStep = ambient_temp / 20;
            Color color = new Color();

            if (node.t < (tempStep * 1.5))
                color = Color.FromArgb(4, 1, 130);

            else if (node.t > (tempStep * 1.5) && node.t < (tempStep * 2.5))
                color = Color.FromArgb(4, 1, 130);
            else if (node.t > (tempStep * 2.5) && node.t < (tempStep * 3.5))
                color = Color.FromArgb(0, 0, 192);

            else if (node.t > (tempStep * 3.5) && node.t < (tempStep * 4.5))
                color = Color.FromArgb(4, 0, 249);
            else if (node.t > (tempStep * 4.5) && node.t < (tempStep * 5.5))
                color = Color.FromArgb(0, 44, 252);

            else if (node.t > (tempStep * 5.5) && node.t < (tempStep * 6.5))
                color = Color.FromArgb(4, 108, 255);
            else if (node.t > (tempStep * 6.5) && node.t < (tempStep * 7.5))
                color = Color.FromArgb(4, 155, 251);    

            else if (node.t > (tempStep * 7.5) && node.t < (tempStep * 8.5))
                color = Color.FromArgb(3, 220, 253);
            else if (node.t > (tempStep * 8.5) && node.t < (tempStep * 9.5))
                color = Color.FromArgb(24, 252, 227);

            else if (node.t > (tempStep * 9.5) && node.t < (tempStep * 10.5))
                color = Color.FromArgb(81, 252, 174);
            else if (node.t > (tempStep * 10.5) && node.t < (tempStep * 11.5))
                color = Color.FromArgb(128, 255, 126);

            else if (node.t > (tempStep * 11.5) && node.t < (tempStep * 12.5))
                color = Color.FromArgb(193, 254, 62);
            else if (node.t > (tempStep * 12.5) && node.t < (tempStep * 13.5))
                color = Color.FromArgb(254, 253, 5);

            else if (node.t > (tempStep * 13.5) && node.t < (tempStep * 14.5))
                color = Color.FromArgb(255, 206, 4);
            else if (node.t > (tempStep * 14.5) && node.t < (tempStep * 15.5))
                color = Color.FromArgb(253, 150, 0);

            else if (node.t > (tempStep * 15.5) && node.t < (tempStep * 16.5))
                color = Color.FromArgb(251, 96, 6);
            else if (node.t > (tempStep * 16.5) && node.t < (tempStep * 17.5))
                color = Color.FromArgb(252, 30, 0);

            else if (node.t > (tempStep * 17.5) && node.t < (tempStep * 18.5))
                color = Color.FromArgb(229, 3, 7);
            else if (node.t > (tempStep * 18.5) && node.t < (tempStep * 19.5))
                color = Color.FromArgb(171, 0, 2);

            else
                color = Color.FromArgb(124, 0, 1);
            return color;
        }

        private void SetScale(double ambient_temperature)
        {
            int tempStep = Convert.ToInt32(ambient_temperature / 10);
            label1.Text = (tempStep * 1).ToString();
            label2.Text = (tempStep * 2).ToString();
            label3.Text = (tempStep * 3).ToString();
            label4.Text = (tempStep * 4).ToString();
            label5.Text = (tempStep * 5).ToString();
            label6.Text = (tempStep * 6).ToString();
            label7.Text = (tempStep * 7).ToString();
            label8.Text = (tempStep * 8).ToString();
            label9.Text = (tempStep * 9).ToString();
            label10.Text = (tempStep * 10).ToString();
        }

        private void iterations_comboBox_SelectedIndexChanged(object sender, int i)
        {
            iterations_comboBox.Items.Add(i);
        }

        private void iterations_comboBox_TextChanged(object sender, EventArgs e)
        {
            int selected;
            if (int.TryParse(iterations_comboBox.Text, out selected)
                && selected >= 0 && selected <= (simulation_time / step))
            {                    
                int id = 0;
                foreach (var column in grid.nodes)
                {
                    foreach (var node in column)
                    {
                        if (selected == 0)
                            node.t = initial_temp;
                        else
                        {
                            node.t = grid.iteration_finalVectors[selected - 1][id];
                            id++;
                        }
                    }
                }
                Draw();
                if (selected == 0)
                    iteration_MaxMin.Text =
                        ("Min = " + initial_temp + " Max = " + initial_temp);
                else
                    iteration_MaxMin.Text =
                        ("Min = " + output[selected - 1] + " Max = " + output[((output.Length / 2) + selected) - 1]);
                iterationSimulationTime_label.Text =
                    "Simulation time: " + ((step * (selected)).ToString() + " s");
            }                
            else
            {
                if (iterations_comboBox.Text != "")
                {
                    MessageBox.Show("The value must be an integer between 0 and " + 
                        simulation_time / step, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iterations_comboBox.Text = "";
                }
            }                 
        }

        private void startSimulation_button_Click(object sender, EventArgs e)
        {
            if (nH < 2 || nW < 2)
                MessageBox.Show("The nodes value must be an integer grater than or equal to 2!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Graphics graphics = pictureBox.CreateGraphics();
                graphics.Clear(Color.FromArgb(240, 240, 240));
                outputData_textBox.Clear();
                outputData_textBox.Refresh();
                iterations_comboBox.Items.Clear();
                iterations_comboBox.Text = "";
                iterations_comboBox.Refresh();
                outputData_textBox.AppendText("Iteration nr: 0" + " -> Min = " +
                    initial_temp.ToString("#.000") + " Max = " + initial_temp.ToString("#.000") +
                    Environment.NewLine);
                iterationSimulationTime_label.Text = "Simulation time: ";
                iteration_MaxMin.Text = "Minimal and Maximal temperature: ";
                iterationSimulationTime_label.Refresh();
                iteration_MaxMin.Refresh();
                var inputData = new InputData
                {
                    H = H,
                    W = W,
                    nH = nH,
                    nW = nW,
                    K = K,
                    alfa = alfa,
                    ambient_temp = ambient_temp,
                    initial_temp = initial_temp,
                    ro = ro,
                    c = c,
                    step = step,
                    simulation_time = simulation_time,
                    nN = nH * nW,
                    nE = (nH - 1) * (nW - 1)
                };
                Thread t = new Thread(() =>
                {
                    this.Calculate(inputData);
                });
                t.Start();
            }
        }

        private void Calculate(InputData inputData)
        {
            output = grid.Calculate(inputData);
            grid.Reset();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            var inputData = new InputData
            {
                H = H,
                W = W,
                nH = nH,
                nW = nW,
                K = K,
                alfa = alfa,
                ambient_temp = ambient_temp,
                initial_temp = initial_temp,
                ro = ro,
                c = c,
                step = step,
                simulation_time = simulation_time,
                nN = nH * nW,
                nE = (nH - 1) * (nW - 1)
            };
            grid.SaveToFile(output, inputData);
            output = null;
        }

        private void heigth_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                H = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = H.ToString();
            }
        }

        private void width_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                W = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = W.ToString();
            }
        }

        private void heigthNodes_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            int result;
            if (int.TryParse(((TextBox)sender).Text, out result))
                nH = result;
            else
            {
                MessageBox.Show("The value must be an integer!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = nH.ToString();
            }
        }

        private void widthNodes_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            int result;
            if (int.TryParse(((TextBox)sender).Text, out result))
                nW = result;
            else
            {
                MessageBox.Show("The value must be an integer!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = nW.ToString();
            }
        }

        private void alfa_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                alfa = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = alfa.ToString();
            }
        }

        private void density_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                ro = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = ro.ToString();
            }
        }

        private void conductivity_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                K = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = K.ToString();
            }
        }

        private void specificHeat_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                c = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = c.ToString();
            }
        }

        private void initialTemperature_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                initial_temp = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = initial_temp.ToString();
            }
        }

        private void AmbientTemperature_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
            {
                ambient_temp = result;
                SetScale(ambient_temp);
            }
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = ambient_temp.ToString();
            }
        }

        private void simulationTime_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                simulation_time = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = simulation_time.ToString();
            }
        }

        private void simulationTimeStep_textBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
                return;
            double result;
            if (double.TryParse(((TextBox)sender).Text, out result))
                step = result;
            else
            {
                MessageBox.Show("The value must be a number!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Text = step.ToString();
            }
        }

        System.Drawing.Color colorTemperatureToRGB(Node node)
        {
            Color tempRGB = new Color();
            var temp = ((node.t ) / 100);

            double red;
            double green;
            double blue;

            if (temp <= 66)
            {
                red = 255;
                green = temp;
                green = 99.4708025861 * Math.Log(green) - 161.1195681661;

                if (temp <= 19)
                    blue = 0;
                else
                {
                    blue = temp - 10;
                    blue = 138.5177312231 * Math.Log(blue) - 305.0447927307;
                }

            }
            else
            {
                red = temp - 60;
                red = 329.698727446 * Math.Pow(red, -0.1332047592);

                green = temp - 60;
                green = 288.1221695283 * Math.Pow(green, -0.0755148492);

                blue = 255;
            }
            int R = clamp(Convert.ToInt32(red), 0, 255);
            int G = clamp(Convert.ToInt32(green), 0, 255);
            int B = clamp(Convert.ToInt32(blue), 0, 255);

            tempRGB = Color.FromArgb(R, G, B);
            return tempRGB;
        }

        int clamp(int x, int min, int max)
        {

            if (x < min) { return min; }
            if (x > max) { return max; }
            return x;
        }

        private void MesForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Created by Paweł Dziwura, \n " +
                "All rights reserved.", "MES Simulation©", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(Environment.ExitCode);
        }
    }
}
