
namespace LabGrid
{
    partial class MainForm
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
            this.GridImage = new System.Windows.Forms.PictureBox();
            this.HeightInput = new System.Windows.Forms.TextBox();
            this.WidthInput = new System.Windows.Forms.TextBox();
            this.GridInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SetGridButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.MessageTextInput = new System.Windows.Forms.TextBox();
            this.Encrypt = new System.Windows.Forms.Button();
            this.EncryptedTextInput = new System.Windows.Forms.TextBox();
            this.Decrypt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridImage)).BeginInit();
            this.SuspendLayout();
            // 
            // GridImage
            // 
            this.GridImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GridImage.Location = new System.Drawing.Point(33, 208);
            this.GridImage.Name = "GridImage";
            this.GridImage.Size = new System.Drawing.Size(838, 300);
            this.GridImage.TabIndex = 0;
            this.GridImage.TabStop = false;
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(33, 74);
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(100, 23);
            this.HeightInput.TabIndex = 1;
            // 
            // WidthInput
            // 
            this.WidthInput.Location = new System.Drawing.Point(139, 74);
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(100, 23);
            this.WidthInput.TabIndex = 1;
            // 
            // GridInput
            // 
            this.GridInput.Location = new System.Drawing.Point(33, 150);
            this.GridInput.Name = "GridInput";
            this.GridInput.Size = new System.Drawing.Size(206, 23);
            this.GridInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Высота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ширина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Решётка";
            // 
            // SetGridButton
            // 
            this.SetGridButton.Location = new System.Drawing.Point(33, 179);
            this.SetGridButton.Name = "SetGridButton";
            this.SetGridButton.Size = new System.Drawing.Size(206, 23);
            this.SetGridButton.TabIndex = 4;
            this.SetGridButton.Text = "Применить";
            this.SetGridButton.UseVisualStyleBackColor = true;
            this.SetGridButton.Click += new System.EventHandler(this.SetGridButton_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(33, 103);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(206, 23);
            this.GenerateButton.TabIndex = 4;
            this.GenerateButton.Text = "Сгенерировать решётку";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // MessageTextInput
            // 
            this.MessageTextInput.Location = new System.Drawing.Point(283, 53);
            this.MessageTextInput.Multiline = true;
            this.MessageTextInput.Name = "MessageTextInput";
            this.MessageTextInput.Size = new System.Drawing.Size(269, 120);
            this.MessageTextInput.TabIndex = 5;
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(283, 179);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(269, 23);
            this.Encrypt.TabIndex = 4;
            this.Encrypt.Text = "Зашифровать";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // EncryptedTextInput
            // 
            this.EncryptedTextInput.Location = new System.Drawing.Point(590, 53);
            this.EncryptedTextInput.Multiline = true;
            this.EncryptedTextInput.Name = "EncryptedTextInput";
            this.EncryptedTextInput.Size = new System.Drawing.Size(269, 120);
            this.EncryptedTextInput.TabIndex = 5;
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(590, 179);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(269, 23);
            this.Decrypt.TabIndex = 4;
            this.Decrypt.Text = "Расшифровать";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 551);
            this.Controls.Add(this.EncryptedTextInput);
            this.Controls.Add(this.MessageTextInput);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.SetGridButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridInput);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.GridImage);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GridImage;
        private System.Windows.Forms.TextBox HeightInput;
        private System.Windows.Forms.TextBox WidthInput;
        private System.Windows.Forms.TextBox GridInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SetGridButton;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox MessageTextInput;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.TextBox EncryptedTextInput;
        private System.Windows.Forms.Button Decrypt;
    }
}

