
namespace RDR2Single
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lab_path = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_enable = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_open_path = new System.Windows.Forms.Button();
            this.lab_status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_path
            // 
            this.lab_path.AutoSize = true;
            this.lab_path.BackColor = System.Drawing.Color.Transparent;
            this.lab_path.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lab_path.ForeColor = System.Drawing.Color.Black;
            this.lab_path.Location = new System.Drawing.Point(31, 25);
            this.lab_path.Name = "lab_path";
            this.lab_path.Size = new System.Drawing.Size(78, 21);
            this.lab_path.TabIndex = 1;
            this.lab_path.Text = "安装路径";
            // 
            // tb_path
            // 
            this.tb_path.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_path.Location = new System.Drawing.Point(118, 21);
            this.tb_path.Name = "tb_path";
            this.tb_path.ReadOnly = true;
            this.tb_path.Size = new System.Drawing.Size(156, 29);
            this.tb_path.TabIndex = 30;
            // 
            // tb_code
            // 
            this.tb_code.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_code.Location = new System.Drawing.Point(118, 66);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(188, 29);
            this.tb_code.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "战局代码";
            // 
            // btn_enable
            // 
            this.btn_enable.Location = new System.Drawing.Point(32, 117);
            this.btn_enable.Name = "btn_enable";
            this.btn_enable.Size = new System.Drawing.Size(132, 41);
            this.btn_enable.TabIndex = 5;
            this.btn_enable.Text = "应用单人战局";
            this.btn_enable.UseVisualStyleBackColor = true;
            this.btn_enable.Click += new System.EventHandler(this.btn_enable_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(174, 117);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(132, 41);
            this.btn_clear.TabIndex = 6;
            this.btn_clear.Text = "清除单人战局";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_open_path
            // 
            this.btn_open_path.Location = new System.Drawing.Point(280, 20);
            this.btn_open_path.Name = "btn_open_path";
            this.btn_open_path.Size = new System.Drawing.Size(26, 31);
            this.btn_open_path.TabIndex = 7;
            this.btn_open_path.Text = "...";
            this.btn_open_path.UseVisualStyleBackColor = true;
            this.btn_open_path.Click += new System.EventHandler(this.btn_open_path_Click);
            // 
            // lab_status
            // 
            this.lab_status.AutoSize = true;
            this.lab_status.BackColor = System.Drawing.Color.Transparent;
            this.lab_status.Location = new System.Drawing.Point(71, 175);
            this.lab_status.Name = "lab_status";
            this.lab_status.Size = new System.Drawing.Size(33, 15);
            this.lab_status.TabIndex = 9;
            this.lab_status.Text = "未知";
            this.lab_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "状态：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RDR2Single.Properties.Resources._2;
            this.ClientSize = new System.Drawing.Size(348, 200);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_status);
            this.Controls.Add(this.btn_open_path);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_enable);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.lab_path);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "荒野大镖客2单人战局工具";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lab_path;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_enable;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_open_path;
        private System.Windows.Forms.Label lab_status;
        private System.Windows.Forms.Label label2;
    }
}

