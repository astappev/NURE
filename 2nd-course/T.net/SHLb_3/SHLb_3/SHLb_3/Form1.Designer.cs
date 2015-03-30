namespace SHLb_3
{
    partial class ImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.Original = new System.Windows.Forms.PictureBox();
            this.Modernize = new System.Windows.Forms.PictureBox();
            this.Rotate = new System.Windows.Forms.TrackBar();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenImage = new System.Windows.Forms.OpenFileDialog();
            this.DegreeLabel = new System.Windows.Forms.Label();
            this.Zoom = new System.Windows.Forms.TrackBar();
            this.ZoomLebel = new System.Windows.Forms.Label();
            this.Circle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modernize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate)).BeginInit();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // Original
            // 
            this.Original.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Original.Dock = System.Windows.Forms.DockStyle.Left;
            this.Original.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Original.Location = new System.Drawing.Point(0, 24);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(237, 237);
            this.Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Original.TabIndex = 0;
            this.Original.TabStop = false;
            this.Original.Click += new System.EventHandler(this.Original_Click);
            // 
            // Modernize
            // 
            this.Modernize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Modernize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Modernize.Location = new System.Drawing.Point(421, 24);
            this.Modernize.MinimumSize = new System.Drawing.Size(10, 10);
            this.Modernize.Name = "Modernize";
            this.Modernize.Size = new System.Drawing.Size(237, 237);
            this.Modernize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Modernize.TabIndex = 1;
            this.Modernize.TabStop = false;
            this.Modernize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Modernize_MouseClick);
            // 
            // Rotate
            // 
            this.Rotate.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.Rotate.LargeChange = 15;
            this.Rotate.Location = new System.Drawing.Point(244, 204);
            this.Rotate.Maximum = 15;
            this.Rotate.Minimum = -15;
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(171, 45);
            this.Rotate.TabIndex = 5;
            this.Rotate.TickFrequency = 3;
            this.Rotate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Rotate.Scroll += new System.EventHandler(this.Rotate_Scroll);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.справкаToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(658, 24);
            this.Menu.TabIndex = 3;
            this.Menu.Text = "Menu";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageMenuItem,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileMenuItem.Text = "Файл";
            // 
            // OpenImageMenuItem
            // 
            this.OpenImageMenuItem.Name = "OpenImageMenuItem";
            this.OpenImageMenuItem.Size = new System.Drawing.Size(121, 22);
            this.OpenImageMenuItem.Text = "Открыть";
            this.OpenImageMenuItem.Click += new System.EventHandler(this.OpenImageMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ExitMenuItem.Text = "Выход";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // OpenImage
            // 
            this.OpenImage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.OpenImage.Title = "Выберите изображение";
            // 
            // DegreeLabel
            // 
            this.DegreeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DegreeLabel.Location = new System.Drawing.Point(243, 174);
            this.DegreeLabel.Name = "DegreeLabel";
            this.DegreeLabel.Size = new System.Drawing.Size(171, 27);
            this.DegreeLabel.TabIndex = 6;
            this.DegreeLabel.Text = "Уточнение угла поворота";
            this.DegreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Zoom
            // 
            this.Zoom.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.Zoom.LargeChange = 25;
            this.Zoom.Location = new System.Drawing.Point(245, 126);
            this.Zoom.Maximum = 150;
            this.Zoom.Minimum = 50;
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(169, 45);
            this.Zoom.SmallChange = 3;
            this.Zoom.TabIndex = 5;
            this.Zoom.TickFrequency = 10;
            this.Zoom.Value = 100;
            this.Zoom.Scroll += new System.EventHandler(this.Zoom_Scroll);
            // 
            // ZoomLebel
            // 
            this.ZoomLebel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomLebel.Location = new System.Drawing.Point(243, 92);
            this.ZoomLebel.Name = "ZoomLebel";
            this.ZoomLebel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ZoomLebel.Size = new System.Drawing.Size(171, 31);
            this.ZoomLebel.TabIndex = 8;
            this.ZoomLebel.Text = "Увеличение изображения";
            this.ZoomLebel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Circle
            // 
            this.Circle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Circle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Circle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Circle.Location = new System.Drawing.Point(237, 24);
            this.Circle.Name = "Circle";
            this.Circle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Circle.Size = new System.Drawing.Size(185, 65);
            this.Circle.TabIndex = 9;
            this.Circle.Text = "Добавить круг";
            this.Circle.UseVisualStyleBackColor = false;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(658, 261);
            this.Controls.Add(this.Circle);
            this.Controls.Add(this.ZoomLebel);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.DegreeLabel);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.Modernize);
            this.Controls.Add(this.Original);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageEditor";
            this.Text = "Лабораторная работа №3";
            ((System.ComponentModel.ISupportInitialize)(this.Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modernize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotate)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Original;
        private System.Windows.Forms.PictureBox Modernize;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenImage;
        private System.Windows.Forms.TrackBar Rotate;
        private System.Windows.Forms.Label DegreeLabel;
        private System.Windows.Forms.TrackBar Zoom;
        private System.Windows.Forms.Label ZoomLebel;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
    }
}

