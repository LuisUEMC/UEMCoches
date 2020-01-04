namespace AppEscritorio
{
    partial class Home
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
            this.btnSubirCoches = new System.Windows.Forms.Button();
            this.btnGuardarCoches = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSubirManual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(211, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home de Administracion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(302, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "UEMCoches";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSubirCoches
            // 
            this.btnSubirCoches.Location = new System.Drawing.Point(85, 158);
            this.btnSubirCoches.Name = "btnSubirCoches";
            this.btnSubirCoches.Size = new System.Drawing.Size(164, 60);
            this.btnSubirCoches.TabIndex = 2;
            this.btnSubirCoches.Text = "Subir Coches desde XML";
            this.btnSubirCoches.UseVisualStyleBackColor = true;
            this.btnSubirCoches.Click += new System.EventHandler(this.btnSubirCoches_Click);
            // 
            // btnGuardarCoches
            // 
            this.btnGuardarCoches.Location = new System.Drawing.Point(556, 158);
            this.btnGuardarCoches.Name = "btnGuardarCoches";
            this.btnGuardarCoches.Size = new System.Drawing.Size(164, 60);
            this.btnGuardarCoches.TabIndex = 3;
            this.btnGuardarCoches.Text = "Guardar Coche en XML";
            this.btnGuardarCoches.UseVisualStyleBackColor = true;
            this.btnGuardarCoches.Click += new System.EventHandler(this.btnGuardarCoches_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblInfo.Location = new System.Drawing.Point(303, 338);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 26);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubirManual
            // 
            this.btnSubirManual.Location = new System.Drawing.Point(335, 158);
            this.btnSubirManual.Name = "btnSubirManual";
            this.btnSubirManual.Size = new System.Drawing.Size(141, 60);
            this.btnSubirManual.TabIndex = 5;
            this.btnSubirManual.Text = "subir coche manualmente";
            this.btnSubirManual.UseVisualStyleBackColor = true;
            this.btnSubirManual.Click += new System.EventHandler(this.btnSubirManual_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubirManual);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnGuardarCoches);
            this.Controls.Add(this.btnSubirCoches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubirCoches;
        private System.Windows.Forms.Button btnGuardarCoches;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnSubirManual;
    }
}