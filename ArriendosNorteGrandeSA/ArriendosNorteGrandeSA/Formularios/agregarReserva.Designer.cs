namespace ArriendosNorteGrandeSA.Formularios
{
    partial class agregarReserva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Patente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NúmeroMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioAlquilerDiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LitrosGasolina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rut clientes disponibles";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(72, 35);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(103, 184);
            this.checkedListBox2.TabIndex = 3;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vehículos disponibles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha inicio reserva";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha término reserva";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = " Agregar reserva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(375, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(622, 148);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Patente,
            this.Modelo,
            this.Marca,
            this.NúmeroMotor,
            this.Color,
            this.PrecioAlquilerDiario,
            this.LitrosGasolina});
            this.dataGridView1.Location = new System.Drawing.Point(204, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(571, 94);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(801, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 160);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(798, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vehículos seleccionados";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(801, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Borrar Vehículo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Patente
            // 
            this.Patente.Frozen = true;
            this.Patente.HeaderText = "Patente";
            this.Patente.Name = "Patente";
            this.Patente.ReadOnly = true;
            this.Patente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Patente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Patente.Width = 75;
            // 
            // Modelo
            // 
            this.Modelo.Frozen = true;
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Modelo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Modelo.Width = 75;
            // 
            // Marca
            // 
            this.Marca.Frozen = true;
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Marca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Marca.Width = 75;
            // 
            // NúmeroMotor
            // 
            this.NúmeroMotor.Frozen = true;
            this.NúmeroMotor.HeaderText = "NúmeroMotor";
            this.NúmeroMotor.Name = "NúmeroMotor";
            this.NúmeroMotor.ReadOnly = true;
            this.NúmeroMotor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NúmeroMotor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NúmeroMotor.Width = 75;
            // 
            // Color
            // 
            this.Color.Frozen = true;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Color.Width = 75;
            // 
            // PrecioAlquilerDiario
            // 
            this.PrecioAlquilerDiario.Frozen = true;
            this.PrecioAlquilerDiario.HeaderText = "PrecioAlquilerDiario";
            this.PrecioAlquilerDiario.Name = "PrecioAlquilerDiario";
            this.PrecioAlquilerDiario.ReadOnly = true;
            this.PrecioAlquilerDiario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LitrosGasolina
            // 
            this.LitrosGasolina.Frozen = true;
            this.LitrosGasolina.HeaderText = "LitrosGasolina";
            this.LitrosGasolina.Name = "LitrosGasolina";
            this.LitrosGasolina.ReadOnly = true;
            this.LitrosGasolina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LitrosGasolina.Width = 75;
            // 
            // agregarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1047, 237);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "agregarReserva";
            this.Text = "Agregar Reserva";
            this.Load += new System.EventHandler(this.agregarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn NúmeroMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioAlquilerDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn LitrosGasolina;
    }
}