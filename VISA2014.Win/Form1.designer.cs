﻿namespace LisenceKey
{
    partial class Form1
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSQLConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(133, 45);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(273, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(133, 74);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(273, 23);
            this.btnRegistration.TabIndex = 1;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(133, 103);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(273, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSQLConnection
            // 
            this.btnSQLConnection.Location = new System.Drawing.Point(133, 132);
            this.btnSQLConnection.Name = "btnSQLConnection";
            this.btnSQLConnection.Size = new System.Drawing.Size(273, 23);
            this.btnSQLConnection.TabIndex = 3;
            this.btnSQLConnection.Text = "SQLConnection";
            this.btnSQLConnection.UseVisualStyleBackColor = true;
            this.btnSQLConnection.Click += new System.EventHandler(this.btnSQLConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 209);
            this.Controls.Add(this.btnSQLConnection);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSQLConnection;
    }
}

