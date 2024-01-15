namespace Aplicacion17
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdapter = new System.Windows.Forms.Button();
            this.txtReader = new System.Windows.Forms.Button();
            this.dgClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTADO DE CLIENTES";
            // 
            // txtAdapter
            // 
            this.txtAdapter.Location = new System.Drawing.Point(243, 104);
            this.txtAdapter.Name = "txtAdapter";
            this.txtAdapter.Size = new System.Drawing.Size(102, 57);
            this.txtAdapter.TabIndex = 1;
            this.txtAdapter.Text = "Consulta DataAdapter";
            this.txtAdapter.UseVisualStyleBackColor = true;
            this.txtAdapter.Click += new System.EventHandler(this.txtAdapter_Click);
            // 
            // txtReader
            // 
            this.txtReader.Location = new System.Drawing.Point(455, 104);
            this.txtReader.Name = "txtReader";
            this.txtReader.Size = new System.Drawing.Size(102, 57);
            this.txtReader.TabIndex = 2;
            this.txtReader.Text = "Consulta DataReader";
            this.txtReader.UseVisualStyleBackColor = true;
            this.txtReader.Click += new System.EventHandler(this.txtReader_Click);
            // 
            // dgClientes
            // 
            this.dgClientes.AllowUserToAddRows = false;
            this.dgClientes.AllowUserToDeleteRows = false;
            this.dgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientes.Location = new System.Drawing.Point(50, 187);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.Size = new System.Drawing.Size(695, 251);
            this.dgClientes.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgClientes);
            this.Controls.Add(this.txtReader);
            this.Controls.Add(this.txtAdapter);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button txtAdapter;
        private System.Windows.Forms.Button txtReader;
        private System.Windows.Forms.DataGridView dgClientes;
    }
}

