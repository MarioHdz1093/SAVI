namespace Proyecto_HernandezMartinez
{
    partial class VentanaVentas
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
            this.Abrir = new System.Windows.Forms.Button();
            this.TBdireccion = new System.Windows.Forms.TextBox();
            this.numeroCopias = new System.Windows.Forms.ComboBox();
            this.ByN = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.imprimirArchivo = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.Copias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Abrir
            // 
            this.Abrir.Location = new System.Drawing.Point(434, 69);
            this.Abrir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(118, 35);
            this.Abrir.TabIndex = 0;
            this.Abrir.Text = "Abrir";
            this.Abrir.UseVisualStyleBackColor = true;
            this.Abrir.Click += new System.EventHandler(this.Abrir_Click);
            // 
            // TBdireccion
            // 
            this.TBdireccion.Location = new System.Drawing.Point(18, 69);
            this.TBdireccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBdireccion.Name = "TBdireccion";
            this.TBdireccion.Size = new System.Drawing.Size(325, 39);
            this.TBdireccion.TabIndex = 1;
            // 
            // numeroCopias
            // 
            this.numeroCopias.FormattingEnabled = true;
            this.numeroCopias.Location = new System.Drawing.Point(164, 154);
            this.numeroCopias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numeroCopias.Name = "numeroCopias";
            this.numeroCopias.Size = new System.Drawing.Size(180, 28);
            this.numeroCopias.TabIndex = 3;
            // 
            // ByN
            // 
            this.ByN.Location = new System.Drawing.Point(222, 265);
            this.ByN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ByN.Name = "ByN";
            this.ByN.Size = new System.Drawing.Size(123, 35);
            this.ByN.TabIndex = 4;
            this.ByN.Text = "B/N";
            this.ByN.UseVisualStyleBackColor = true;
            this.ByN.Click += new System.EventHandler(this.ByN_Click);
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(422, 265);
            this.Color.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(130, 35);
            this.Color.TabIndex = 5;
            this.Color.Text = "COLOR";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // imprimirArchivo
            // 
            this.imprimirArchivo.Location = new System.Drawing.Point(18, 392);
            this.imprimirArchivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imprimirArchivo.Name = "imprimirArchivo";
            this.imprimirArchivo.Size = new System.Drawing.Size(534, 74);
            this.imprimirArchivo.TabIndex = 6;
            this.imprimirArchivo.Text = "Imprimir";
            this.imprimirArchivo.UseVisualStyleBackColor = true;
            this.imprimirArchivo.Click += new System.EventHandler(this.imprimirArchivo_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Copias
            // 
            this.Copias.AutoSize = true;
            this.Copias.Location = new System.Drawing.Point(46, 154);
            this.Copias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Copias.Name = "Copias";
            this.Copias.Size = new System.Drawing.Size(115, 20);
            this.Copias.TabIndex = 7;
            this.Copias.Text = "N° de copias: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "TIpo: ";
            // 
            // VentanaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_HernandezMartinez.Properties.Resources.descarga;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 525);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Copias);
            this.Controls.Add(this.imprimirArchivo);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.ByN);
            this.Controls.Add(this.numeroCopias);
            this.Controls.Add(this.TBdireccion);
            this.Controls.Add(this.Abrir);
            this.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VentanaVentas";
            this.Text = "VentanaVentas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Abrir;
        private System.Windows.Forms.TextBox TBdireccion;
        private System.Windows.Forms.ComboBox numeroCopias;
        private System.Windows.Forms.Button ByN;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button imprimirArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label Copias;
        private System.Windows.Forms.Label label2;
    }
}