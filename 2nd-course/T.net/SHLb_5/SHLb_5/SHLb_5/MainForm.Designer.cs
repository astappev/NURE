namespace SHLb_5
{
    partial class MainForm
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
            this.open = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PrintResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(87, 33);
            this.open.TabIndex = 1;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Text file (*.txt) | *txt";
            // 
            // PrintResult
            // 
            this.PrintResult.Location = new System.Drawing.Point(12, 52);
            this.PrintResult.Name = "PrintResult";
            this.PrintResult.Size = new System.Drawing.Size(87, 33);
            this.PrintResult.TabIndex = 3;
            this.PrintResult.Text = "Отобразить";
            this.PrintResult.UseVisualStyleBackColor = true;
            this.PrintResult.Click += new System.EventHandler(this.PrintResult_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 261);
            this.Controls.Add(this.PrintResult);
            this.Controls.Add(this.open);
            this.Name = "MainForm";
            this.Text = "Лабораторная #5";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button PrintResult;
    }
}

