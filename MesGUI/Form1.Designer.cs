namespace WindowsFormsMES
{
    partial class MesForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesForm));
            this.EnterGridData_label = new System.Windows.Forms.Label();
            this.heigth_label = new System.Windows.Forms.Label();
            this.heigth_textBox = new System.Windows.Forms.TextBox();
            this.width_textBox = new System.Windows.Forms.TextBox();
            this.width_label = new System.Windows.Forms.Label();
            this.heigthNodes_textBox = new System.Windows.Forms.TextBox();
            this.heigthNodes_label = new System.Windows.Forms.Label();
            this.widthNodes_textBox = new System.Windows.Forms.TextBox();
            this.widthNodes_label = new System.Windows.Forms.Label();
            this.enterTemperature_label = new System.Windows.Forms.Label();
            this.ambientTemperature_label = new System.Windows.Forms.Label();
            this.AmbientTemperature_textBox = new System.Windows.Forms.TextBox();
            this.initialTemperature_textBox = new System.Windows.Forms.TextBox();
            this.initialTemperature_label = new System.Windows.Forms.Label();
            this.materialData_label = new System.Windows.Forms.Label();
            this.specificHeat_textBox = new System.Windows.Forms.TextBox();
            this.specificHeat_label = new System.Windows.Forms.Label();
            this.conductivity_textBox = new System.Windows.Forms.TextBox();
            this.conductivity_label = new System.Windows.Forms.Label();
            this.density_label = new System.Windows.Forms.Label();
            this.density_textBox = new System.Windows.Forms.TextBox();
            this.alfa_textBox = new System.Windows.Forms.TextBox();
            this.alfa_label = new System.Windows.Forms.Label();
            this.enterSimulation_label = new System.Windows.Forms.Label();
            this.simulationTimeStep_label = new System.Windows.Forms.Label();
            this.simulationTimeStep_textBox = new System.Windows.Forms.TextBox();
            this.simulationTime_textBox = new System.Windows.Forms.TextBox();
            this.simulationTime_label = new System.Windows.Forms.Label();
            this.startSimulation_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.outputData_textBox = new System.Windows.Forms.TextBox();
            this.temperatureDistributiom_label = new System.Windows.Forms.Label();
            this.iterations_comboBox = new System.Windows.Forms.ComboBox();
            this.selectIteration_label = new System.Windows.Forms.Label();
            this.iteration_MaxMin = new System.Windows.Forms.Label();
            this.iterationSimulationTime_label = new System.Windows.Forms.Label();
            this.temperatureScale_pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureScale_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterGridData_label
            // 
            this.EnterGridData_label.AutoSize = true;
            this.EnterGridData_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EnterGridData_label.Location = new System.Drawing.Point(12, 9);
            this.EnterGridData_label.Name = "EnterGridData_label";
            this.EnterGridData_label.Size = new System.Drawing.Size(169, 20);
            this.EnterGridData_label.TabIndex = 0;
            this.EnterGridData_label.Text = "Enter the Grid data.";
            // 
            // heigth_label
            // 
            this.heigth_label.AutoSize = true;
            this.heigth_label.Location = new System.Drawing.Point(12, 38);
            this.heigth_label.Name = "heigth_label";
            this.heigth_label.Size = new System.Drawing.Size(60, 20);
            this.heigth_label.TabIndex = 1;
            this.heigth_label.Text = "Heigth:";
            // 
            // heigth_textBox
            // 
            this.heigth_textBox.Location = new System.Drawing.Point(92, 35);
            this.heigth_textBox.Name = "heigth_textBox";
            this.heigth_textBox.Size = new System.Drawing.Size(100, 26);
            this.heigth_textBox.TabIndex = 2;
            this.heigth_textBox.Text = "0,1";
            this.heigth_textBox.TextChanged += new System.EventHandler(this.heigth_textBox_TextChanged);
            // 
            // width_textBox
            // 
            this.width_textBox.Location = new System.Drawing.Point(92, 68);
            this.width_textBox.Name = "width_textBox";
            this.width_textBox.Size = new System.Drawing.Size(100, 26);
            this.width_textBox.TabIndex = 3;
            this.width_textBox.Text = "0,1";
            this.width_textBox.TextChanged += new System.EventHandler(this.width_textBox_TextChanged);
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.Location = new System.Drawing.Point(12, 69);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(54, 20);
            this.width_label.TabIndex = 4;
            this.width_label.Text = "Width:";
            // 
            // heigthNodes_textBox
            // 
            this.heigthNodes_textBox.Location = new System.Drawing.Point(340, 35);
            this.heigthNodes_textBox.Name = "heigthNodes_textBox";
            this.heigthNodes_textBox.Size = new System.Drawing.Size(100, 26);
            this.heigthNodes_textBox.TabIndex = 6;
            this.heigthNodes_textBox.Text = "4";
            this.heigthNodes_textBox.TextChanged += new System.EventHandler(this.heigthNodes_textBox_TextChanged);
            // 
            // heigthNodes_label
            // 
            this.heigthNodes_label.AutoSize = true;
            this.heigthNodes_label.Location = new System.Drawing.Point(226, 38);
            this.heigthNodes_label.Name = "heigthNodes_label";
            this.heigthNodes_label.Size = new System.Drawing.Size(108, 20);
            this.heigthNodes_label.TabIndex = 5;
            this.heigthNodes_label.Text = "Heigth nodes:";
            // 
            // widthNodes_textBox
            // 
            this.widthNodes_textBox.Location = new System.Drawing.Point(340, 68);
            this.widthNodes_textBox.Name = "widthNodes_textBox";
            this.widthNodes_textBox.Size = new System.Drawing.Size(100, 26);
            this.widthNodes_textBox.TabIndex = 8;
            this.widthNodes_textBox.Text = "4";
            this.widthNodes_textBox.TextChanged += new System.EventHandler(this.widthNodes_textBox_TextChanged);
            // 
            // widthNodes_label
            // 
            this.widthNodes_label.AutoSize = true;
            this.widthNodes_label.Location = new System.Drawing.Point(226, 69);
            this.widthNodes_label.Name = "widthNodes_label";
            this.widthNodes_label.Size = new System.Drawing.Size(102, 20);
            this.widthNodes_label.TabIndex = 7;
            this.widthNodes_label.Text = "Width nodes:";
            // 
            // enterTemperature_label
            // 
            this.enterTemperature_label.AutoSize = true;
            this.enterTemperature_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.enterTemperature_label.Location = new System.Drawing.Point(12, 212);
            this.enterTemperature_label.Name = "enterTemperature_label";
            this.enterTemperature_label.Size = new System.Drawing.Size(217, 20);
            this.enterTemperature_label.TabIndex = 9;
            this.enterTemperature_label.Text = "Enter temperature values.";
            // 
            // ambientTemperature_label
            // 
            this.ambientTemperature_label.AutoSize = true;
            this.ambientTemperature_label.Location = new System.Drawing.Point(12, 274);
            this.ambientTemperature_label.Name = "ambientTemperature_label";
            this.ambientTemperature_label.Size = new System.Drawing.Size(163, 20);
            this.ambientTemperature_label.TabIndex = 13;
            this.ambientTemperature_label.Text = "Ambient temperature:";
            // 
            // AmbientTemperature_textBox
            // 
            this.AmbientTemperature_textBox.Location = new System.Drawing.Point(182, 271);
            this.AmbientTemperature_textBox.Name = "AmbientTemperature_textBox";
            this.AmbientTemperature_textBox.Size = new System.Drawing.Size(100, 26);
            this.AmbientTemperature_textBox.TabIndex = 12;
            this.AmbientTemperature_textBox.Text = "1200";
            this.AmbientTemperature_textBox.TextChanged += new System.EventHandler(this.AmbientTemperature_textBox_TextChanged);
            // 
            // initialTemperature_textBox
            // 
            this.initialTemperature_textBox.Location = new System.Drawing.Point(182, 238);
            this.initialTemperature_textBox.Name = "initialTemperature_textBox";
            this.initialTemperature_textBox.Size = new System.Drawing.Size(100, 26);
            this.initialTemperature_textBox.TabIndex = 11;
            this.initialTemperature_textBox.Text = "100";
            this.initialTemperature_textBox.TextChanged += new System.EventHandler(this.initialTemperature_textBox_TextChanged);
            // 
            // initialTemperature_label
            // 
            this.initialTemperature_label.AutoSize = true;
            this.initialTemperature_label.Location = new System.Drawing.Point(12, 242);
            this.initialTemperature_label.Name = "initialTemperature_label";
            this.initialTemperature_label.Size = new System.Drawing.Size(141, 20);
            this.initialTemperature_label.TabIndex = 10;
            this.initialTemperature_label.Text = "Initial temperature:";
            // 
            // materialData_label
            // 
            this.materialData_label.AutoSize = true;
            this.materialData_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.materialData_label.Location = new System.Drawing.Point(12, 112);
            this.materialData_label.Name = "materialData_label";
            this.materialData_label.Size = new System.Drawing.Size(168, 20);
            this.materialData_label.TabIndex = 14;
            this.materialData_label.Text = "Enter material data.";
            // 
            // specificHeat_textBox
            // 
            this.specificHeat_textBox.Location = new System.Drawing.Point(340, 168);
            this.specificHeat_textBox.Name = "specificHeat_textBox";
            this.specificHeat_textBox.Size = new System.Drawing.Size(100, 26);
            this.specificHeat_textBox.TabIndex = 22;
            this.specificHeat_textBox.Text = "700";
            this.specificHeat_textBox.TextChanged += new System.EventHandler(this.specificHeat_textBox_TextChanged);
            // 
            // specificHeat_label
            // 
            this.specificHeat_label.AutoSize = true;
            this.specificHeat_label.Location = new System.Drawing.Point(226, 171);
            this.specificHeat_label.Name = "specificHeat_label";
            this.specificHeat_label.Size = new System.Drawing.Size(102, 20);
            this.specificHeat_label.TabIndex = 21;
            this.specificHeat_label.Text = "specific heat:";
            // 
            // conductivity_textBox
            // 
            this.conductivity_textBox.Location = new System.Drawing.Point(340, 135);
            this.conductivity_textBox.Name = "conductivity_textBox";
            this.conductivity_textBox.Size = new System.Drawing.Size(100, 26);
            this.conductivity_textBox.TabIndex = 20;
            this.conductivity_textBox.Text = "25";
            this.conductivity_textBox.TextChanged += new System.EventHandler(this.conductivity_textBox_TextChanged);
            // 
            // conductivity_label
            // 
            this.conductivity_label.AutoSize = true;
            this.conductivity_label.Location = new System.Drawing.Point(226, 138);
            this.conductivity_label.Name = "conductivity_label";
            this.conductivity_label.Size = new System.Drawing.Size(95, 20);
            this.conductivity_label.TabIndex = 19;
            this.conductivity_label.Text = "conductivity:";
            // 
            // density_label
            // 
            this.density_label.AutoSize = true;
            this.density_label.Location = new System.Drawing.Point(12, 171);
            this.density_label.Name = "density_label";
            this.density_label.Size = new System.Drawing.Size(63, 20);
            this.density_label.TabIndex = 18;
            this.density_label.Text = "density:";
            // 
            // density_textBox
            // 
            this.density_textBox.Location = new System.Drawing.Point(92, 168);
            this.density_textBox.Name = "density_textBox";
            this.density_textBox.Size = new System.Drawing.Size(100, 26);
            this.density_textBox.TabIndex = 17;
            this.density_textBox.Text = "7800";
            this.density_textBox.TextChanged += new System.EventHandler(this.density_textBox_TextChanged);
            // 
            // alfa_textBox
            // 
            this.alfa_textBox.Location = new System.Drawing.Point(92, 135);
            this.alfa_textBox.Name = "alfa_textBox";
            this.alfa_textBox.Size = new System.Drawing.Size(100, 26);
            this.alfa_textBox.TabIndex = 16;
            this.alfa_textBox.Text = "300";
            this.alfa_textBox.TextChanged += new System.EventHandler(this.alfa_textBox_TextChanged);
            // 
            // alfa_label
            // 
            this.alfa_label.AutoSize = true;
            this.alfa_label.Location = new System.Drawing.Point(12, 138);
            this.alfa_label.Name = "alfa_label";
            this.alfa_label.Size = new System.Drawing.Size(39, 20);
            this.alfa_label.TabIndex = 15;
            this.alfa_label.Text = "alfa:";
            // 
            // enterSimulation_label
            // 
            this.enterSimulation_label.AutoSize = true;
            this.enterSimulation_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.enterSimulation_label.Location = new System.Drawing.Point(12, 315);
            this.enterSimulation_label.Name = "enterSimulation_label";
            this.enterSimulation_label.Size = new System.Drawing.Size(185, 20);
            this.enterSimulation_label.TabIndex = 23;
            this.enterSimulation_label.Text = "Enter simulation data.";
            // 
            // simulationTimeStep_label
            // 
            this.simulationTimeStep_label.AutoSize = true;
            this.simulationTimeStep_label.Location = new System.Drawing.Point(12, 375);
            this.simulationTimeStep_label.Name = "simulationTimeStep_label";
            this.simulationTimeStep_label.Size = new System.Drawing.Size(153, 20);
            this.simulationTimeStep_label.TabIndex = 27;
            this.simulationTimeStep_label.Text = "simulation time step:";
            // 
            // simulationTimeStep_textBox
            // 
            this.simulationTimeStep_textBox.Location = new System.Drawing.Point(182, 374);
            this.simulationTimeStep_textBox.Name = "simulationTimeStep_textBox";
            this.simulationTimeStep_textBox.Size = new System.Drawing.Size(100, 26);
            this.simulationTimeStep_textBox.TabIndex = 26;
            this.simulationTimeStep_textBox.Text = "50";
            this.simulationTimeStep_textBox.TextChanged += new System.EventHandler(this.simulationTimeStep_textBox_TextChanged);
            // 
            // simulationTime_textBox
            // 
            this.simulationTime_textBox.Location = new System.Drawing.Point(182, 342);
            this.simulationTime_textBox.Name = "simulationTime_textBox";
            this.simulationTime_textBox.Size = new System.Drawing.Size(100, 26);
            this.simulationTime_textBox.TabIndex = 25;
            this.simulationTime_textBox.Text = "500";
            this.simulationTime_textBox.TextChanged += new System.EventHandler(this.simulationTime_textBox_TextChanged);
            // 
            // simulationTime_label
            // 
            this.simulationTime_label.AutoSize = true;
            this.simulationTime_label.Location = new System.Drawing.Point(12, 345);
            this.simulationTime_label.Name = "simulationTime_label";
            this.simulationTime_label.Size = new System.Drawing.Size(118, 20);
            this.simulationTime_label.TabIndex = 24;
            this.simulationTime_label.Text = "simulation time:";
            // 
            // startSimulation_button
            // 
            this.startSimulation_button.Location = new System.Drawing.Point(16, 491);
            this.startSimulation_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startSimulation_button.Name = "startSimulation_button";
            this.startSimulation_button.Size = new System.Drawing.Size(112, 35);
            this.startSimulation_button.TabIndex = 28;
            this.startSimulation_button.Text = "Start Simulation";
            this.startSimulation_button.UseVisualStyleBackColor = true;
            this.startSimulation_button.Click += new System.EventHandler(this.startSimulation_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(138, 491);
            this.save_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(112, 35);
            this.save_button.TabIndex = 29;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 534);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(424, 12);
            this.progressBar.TabIndex = 30;
            // 
            // outputData_textBox
            // 
            this.outputData_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.outputData_textBox.Location = new System.Drawing.Point(16, 580);
            this.outputData_textBox.Multiline = true;
            this.outputData_textBox.Name = "outputData_textBox";
            this.outputData_textBox.ReadOnly = true;
            this.outputData_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputData_textBox.Size = new System.Drawing.Size(424, 244);
            this.outputData_textBox.TabIndex = 31;
            // 
            // temperatureDistributiom_label
            // 
            this.temperatureDistributiom_label.AutoSize = true;
            this.temperatureDistributiom_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.temperatureDistributiom_label.Location = new System.Drawing.Point(496, 12);
            this.temperatureDistributiom_label.Name = "temperatureDistributiom_label";
            this.temperatureDistributiom_label.Size = new System.Drawing.Size(298, 20);
            this.temperatureDistributiom_label.TabIndex = 33;
            this.temperatureDistributiom_label.Text = "Temperature distribution in material:";
            // 
            // iterations_comboBox
            // 
            this.iterations_comboBox.FormattingEnabled = true;
            this.iterations_comboBox.Location = new System.Drawing.Point(500, 789);
            this.iterations_comboBox.MaxDropDownItems = 20;
            this.iterations_comboBox.Name = "iterations_comboBox";
            this.iterations_comboBox.Size = new System.Drawing.Size(133, 28);
            this.iterations_comboBox.TabIndex = 35;
            this.iterations_comboBox.TextChanged += new System.EventHandler(this.iterations_comboBox_TextChanged);
            // 
            // selectIteration_label
            // 
            this.selectIteration_label.AutoSize = true;
            this.selectIteration_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectIteration_label.Location = new System.Drawing.Point(496, 768);
            this.selectIteration_label.Name = "selectIteration_label";
            this.selectIteration_label.Size = new System.Drawing.Size(136, 20);
            this.selectIteration_label.TabIndex = 36;
            this.selectIteration_label.Text = "Select iteration:";
            // 
            // iteration_MaxMin
            // 
            this.iteration_MaxMin.AutoSize = true;
            this.iteration_MaxMin.Location = new System.Drawing.Point(675, 798);
            this.iteration_MaxMin.Name = "iteration_MaxMin";
            this.iteration_MaxMin.Size = new System.Drawing.Size(253, 20);
            this.iteration_MaxMin.TabIndex = 37;
            this.iteration_MaxMin.Text = "Minimal and Maximal Temperature:";
            // 
            // iterationSimulationTime_label
            // 
            this.iterationSimulationTime_label.AutoSize = true;
            this.iterationSimulationTime_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.iterationSimulationTime_label.Location = new System.Drawing.Point(675, 768);
            this.iterationSimulationTime_label.Name = "iterationSimulationTime_label";
            this.iterationSimulationTime_label.Size = new System.Drawing.Size(137, 20);
            this.iterationSimulationTime_label.TabIndex = 38;
            this.iterationSimulationTime_label.Text = "Simulation time:";
            // 
            // temperatureScale_pictureBox
            // 
            this.temperatureScale_pictureBox.BackgroundImage = global::MesGUI.Properties.Resources.MEStemperatureDistributionScaled;
            this.temperatureScale_pictureBox.InitialImage = global::MesGUI.Properties.Resources.MEStemperatureDistributionScaled;
            this.temperatureScale_pictureBox.Location = new System.Drawing.Point(1178, 69);
            this.temperatureScale_pictureBox.Name = "temperatureScale_pictureBox";
            this.temperatureScale_pictureBox.Size = new System.Drawing.Size(20, 669);
            this.temperatureScale_pictureBox.TabIndex = 39;
            this.temperatureScale_pictureBox.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.Location = new System.Drawing.Point(501, 68);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(670, 669);
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1204, 726);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1204, 663);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1204, 594);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1204, 518);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1204, 442);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1204, 366);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1204, 288);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1204, 212);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1204, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1204, 68);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 49;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(1156, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 22);
            this.label11.TabIndex = 50;
            this.label11.Text = "Temp.";
            // 
            // MesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 844);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.temperatureScale_pictureBox);
            this.Controls.Add(this.iterationSimulationTime_label);
            this.Controls.Add(this.iteration_MaxMin);
            this.Controls.Add(this.selectIteration_label);
            this.Controls.Add(this.iterations_comboBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.temperatureDistributiom_label);
            this.Controls.Add(this.outputData_textBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.startSimulation_button);
            this.Controls.Add(this.simulationTimeStep_label);
            this.Controls.Add(this.simulationTimeStep_textBox);
            this.Controls.Add(this.simulationTime_textBox);
            this.Controls.Add(this.simulationTime_label);
            this.Controls.Add(this.enterSimulation_label);
            this.Controls.Add(this.specificHeat_textBox);
            this.Controls.Add(this.specificHeat_label);
            this.Controls.Add(this.conductivity_textBox);
            this.Controls.Add(this.conductivity_label);
            this.Controls.Add(this.density_label);
            this.Controls.Add(this.density_textBox);
            this.Controls.Add(this.alfa_textBox);
            this.Controls.Add(this.alfa_label);
            this.Controls.Add(this.materialData_label);
            this.Controls.Add(this.ambientTemperature_label);
            this.Controls.Add(this.AmbientTemperature_textBox);
            this.Controls.Add(this.initialTemperature_textBox);
            this.Controls.Add(this.initialTemperature_label);
            this.Controls.Add(this.enterTemperature_label);
            this.Controls.Add(this.widthNodes_textBox);
            this.Controls.Add(this.widthNodes_label);
            this.Controls.Add(this.heigthNodes_textBox);
            this.Controls.Add(this.heigthNodes_label);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.width_textBox);
            this.Controls.Add(this.heigth_textBox);
            this.Controls.Add(this.heigth_label);
            this.Controls.Add(this.EnterGridData_label);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1300, 900);
            this.Name = "MesForm";
            this.Text = "MES Simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MesForm_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.temperatureScale_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnterGridData_label;
        private System.Windows.Forms.Label heigth_label;
        private System.Windows.Forms.TextBox heigth_textBox;
        private System.Windows.Forms.TextBox width_textBox;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.TextBox heigthNodes_textBox;
        private System.Windows.Forms.Label heigthNodes_label;
        private System.Windows.Forms.TextBox widthNodes_textBox;
        private System.Windows.Forms.Label widthNodes_label;
        private System.Windows.Forms.Label enterTemperature_label;
        private System.Windows.Forms.Label ambientTemperature_label;
        private System.Windows.Forms.TextBox AmbientTemperature_textBox;
        private System.Windows.Forms.TextBox initialTemperature_textBox;
        private System.Windows.Forms.Label initialTemperature_label;
        private System.Windows.Forms.Label materialData_label;
        private System.Windows.Forms.TextBox specificHeat_textBox;
        private System.Windows.Forms.Label specificHeat_label;
        private System.Windows.Forms.TextBox conductivity_textBox;
        private System.Windows.Forms.Label conductivity_label;
        private System.Windows.Forms.Label density_label;
        private System.Windows.Forms.TextBox density_textBox;
        private System.Windows.Forms.TextBox alfa_textBox;
        private System.Windows.Forms.Label alfa_label;
        private System.Windows.Forms.Label enterSimulation_label;
        private System.Windows.Forms.Label simulationTimeStep_label;
        private System.Windows.Forms.TextBox simulationTimeStep_textBox;
        private System.Windows.Forms.TextBox simulationTime_textBox;
        private System.Windows.Forms.Label simulationTime_label;
        private System.Windows.Forms.Button startSimulation_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox outputData_textBox;
        private System.Windows.Forms.Label temperatureDistributiom_label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox iterations_comboBox;
        private System.Windows.Forms.Label selectIteration_label;
        private System.Windows.Forms.Label iteration_MaxMin;
        private System.Windows.Forms.Label iterationSimulationTime_label;
        private System.Windows.Forms.PictureBox temperatureScale_pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

