namespace Proyecto_HernandezMartinez
{
    partial class VentanaTipoVenta
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBtipoVenta = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numeroCopias = new System.Windows.Forms.ComboBox();
            this.vender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 304);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Impresion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de venta:";
            // 
            // TBtipoVenta
            // 
            this.TBtipoVenta.FormattingEnabled = true;
            this.TBtipoVenta.Location = new System.Drawing.Point(378, 104);
            this.TBtipoVenta.Margin = new System.Windows.Forms.Padding(6);
            this.TBtipoVenta.Name = "TBtipoVenta";
            this.TBtipoVenta.Size = new System.Drawing.Size(238, 34);
            this.TBtipoVenta.TabIndex = 2;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(378, 418);
            this.close.Margin = new System.Windows.Forms.Padding(6);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(242, 46);
            this.close.TabIndex = 3;
            this.close.Text = "Cancelar";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Copias:";
            // 
            // numeroCopias
            // 
            this.numeroCopias.FormattingEnabled = true;
            this.numeroCopias.Location = new System.Drawing.Point(378, 200);
            this.numeroCopias.Margin = new System.Windows.Forms.Padding(6);
            this.numeroCopias.Name = "numeroCopias";
            this.numeroCopias.Size = new System.Drawing.Size(238, 34);
            this.numeroCopias.TabIndex = 5;
            // 
            // vender
            // 
            this.vender.Location = new System.Drawing.Point(74, 418);
            this.vender.Margin = new System.Windows.Forms.Padding(6);
            this.vender.Name = "vender";
            this.vender.Size = new System.Drawing.Size(242, 46);
            this.vender.TabIndex = 6;
            this.vender.Text = "Vender";
            this.vender.UseVisualStyleBackColor = true;
            this.vender.Click += new System.EventHandler(this.vender_Click);
            // 
            // VentanaTipoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_HernandezMartinez.Properties.Resources.descarga;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(704, 518);
            this.Controls.Add(this.vender);
            this.Controls.Add(this.numeroCopias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.close);
            this.Controls.Add(this.TBtipoVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Adobe Gothic Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VentanaTipoVenta";
            this.Text = "VentanaTipoVenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TBtipoVenta;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox numeroCopias;
        private System.Windows.Forms.Button vender;
    }
}