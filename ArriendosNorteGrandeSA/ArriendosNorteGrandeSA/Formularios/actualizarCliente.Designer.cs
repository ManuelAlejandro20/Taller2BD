namespace ArriendosNorteGrandeSA.Formularios
{
    partial class actualizarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(actualizarCliente));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.RutCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoDomicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteQueAvala = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RutCliente,
            this.Nombre,
            this.Direccion,
            this.TelefonoDomicilio,
            this.TelefonoMovil,
            this.ClienteQueAvala});
            this.dataGridView1.Location = new System.Drawing.Point(36, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(484, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Actualizar clientes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RutCliente
            // 
            this.RutCliente.HeaderText = "RutCliente";
            this.RutCliente.Name = "RutCliente";
            this.RutCliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RutCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre.Width = 200;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.Name = "Direccion";
            this.Direccion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Direccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Direccion.Width = 150;
            // 
            // TelefonoDomicilio
            // 
            this.TelefonoDomicilio.HeaderText = "TeléfonoDomicilio";
            this.TelefonoDomicilio.Name = "TelefonoDomicilio";
            this.TelefonoDomicilio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TelefonoDomicilio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TelefonoMovil
            // 
            this.TelefonoMovil.HeaderText = "TeléfonoMóvil";
            this.TelefonoMovil.Name = "TelefonoMovil";
            this.TelefonoMovil.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TelefonoMovil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClienteQueAvala
            // 
            this.ClienteQueAvala.HeaderText = "ClienteQueAvala";
            this.ClienteQueAvala.Name = "ClienteQueAvala";
            this.ClienteQueAvala.Width = 350;
            // 
            // actualizarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "actualizarCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoDomicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoMovil;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClienteQueAvala;
    }
}