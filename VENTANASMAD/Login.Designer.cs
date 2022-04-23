
namespace VENTANASMAD
{
    partial class Login
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
            this.label22 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.logi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(263, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 28);
            this.label22.TabIndex = 98;
            this.label22.Text = "Login";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(268, 171);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(264, 22);
            this.textBox18.TabIndex = 96;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(265, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 17);
            this.label18.TabIndex = 94;
            this.label18.Text = "Usuario";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(268, 229);
            this.textBox12.Name = "textBox12";
            this.textBox12.PasswordChar = '*';
            this.textBox12.Size = new System.Drawing.Size(264, 22);
            this.textBox12.TabIndex = 92;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(265, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 91;
            this.label5.Text = "Contraseña";
            // 
            // logi
            // 
            this.logi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.logi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logi.ForeColor = System.Drawing.Color.White;
            this.logi.Location = new System.Drawing.Point(193, 302);
            this.logi.Name = "logi";
            this.logi.Size = new System.Drawing.Size(155, 49);
            this.logi.TabIndex = 99;
            this.logi.Text = "Iniciar Sesión";
            this.logi.UseVisualStyleBackColor = false;
            this.logi.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(427, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 49);
            this.button2.TabIndex = 100;
            this.button2.Text = "Registrate";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(68)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.logi);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button logi;
        private System.Windows.Forms.Button button2;
    }
}