namespace Proyecto_HernandezMartinez
{
    partial class VentanaNuevoArticulo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBnombre = new System.Windows.Forms.TextBox();
            this.TBcantidad = new System.Windows.Forms.TextBox();
            this.B_Agregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "NOMBRE DEL ARTICULO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "CANTIDAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 11;
            // 
            // TBnombre
            // 
            this.TBnombre.Location = new System.Drawing.Point(480, 99);
            this.TBnombre.Margin = new System.Windows.Forms.Padding(6);
            this.TBnombre.Name = "TBnombre";
            this.TBnombre.Size = new System.Drawing.Size(275, 45);
            this.TBnombre.TabIndex = 13;
            // 
            // TBcantidad
            // 
            this.TBcantidad.Location = new System.Drawing.Point(480, 229);
            this.TBcantidad.Margin = new System.Windows.Forms.Padding(6);
            this.TBcantidad.Name = "TBcantidad";
            this.TBcantidad.Size = new System.Drawing.Size(275, 45);
            this.TBcantidad.TabIndex = 14;
            // 
            // B_Agregar
            // 
            this.B_Agregar.Location = new System.Drawing.Point(319, 390);
            this.B_Agregar.Margin = new System.Windows.Forms.Padding(6);
            this.B_Agregar.Name = "B_Agregar";
            this.B_Agregar.Size = new System.Drawing.Size(165, 42);
            this.B_Agregar.TabIndex = 15;
            this.B_Agregar.Text = "Agregar";
            this.B_Agregar.UseVisualStyleBackColor = true;
            this.B_Agregar.Click += new System.EventHandler(this.B_Agregar_Click);
            // 
            // VentanaNuevoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_HernandezMartinez.Properties.Resources.descarga;
            this.ClientSize = new System.Drawing.Size(840, 482);
            this.Controls.Add(this.B_Agregar);
            this.Controls.Add(this.TBcantidad);
            this.Controls.Add(this.TBnombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Adobe Gothic Std B", 14.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VentanaNuevoArticulo";
            this.Text = "VentanaNuevoArticulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBnombre;
        private System.Windows.Forms.TextBox TBcantidad;
        private System.Windows.Forms.Button B_Agregar;
    }
}