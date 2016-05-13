namespace SimpleSketch
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
            this.shapeSelection = new System.Windows.Forms.ComboBox();
            this.blackBut = new System.Windows.Forms.Button();
            this.redBut = new System.Windows.Forms.Button();
            this.yellowBut = new System.Windows.Forms.Button();
            this.blueBut = new System.Windows.Forms.Button();
            this.greenBut = new System.Windows.Forms.Button();
            this.sketchPad = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeSelection
            // 
            this.shapeSelection.FormattingEnabled = true;
            this.shapeSelection.Items.AddRange(new object[] {
            "Freehand",
            "Line",
            "Rectangle",
            "Ellipse",
            "Polygon",
            "Free Polygon",
            "Move Object",
            "Erase Object",
            "Copy Object"});
            this.shapeSelection.Location = new System.Drawing.Point(127, 14);
            this.shapeSelection.Name = "shapeSelection";
            this.shapeSelection.Size = new System.Drawing.Size(162, 24);
            this.shapeSelection.TabIndex = 0;
            this.shapeSelection.Text = "Freehand";
            this.shapeSelection.SelectedValueChanged += new System.EventHandler(this.shapeSelection_SelectedValueChanged);
            // 
            // blackBut
            // 
            this.blackBut.BackColor = System.Drawing.Color.Black;
            this.blackBut.Location = new System.Drawing.Point(681, 14);
            this.blackBut.Name = "blackBut";
            this.blackBut.Size = new System.Drawing.Size(75, 23);
            this.blackBut.TabIndex = 1;
            this.blackBut.UseVisualStyleBackColor = false;
            this.blackBut.Click += new System.EventHandler(this.blackBut_Click);
            // 
            // redBut
            // 
            this.redBut.BackColor = System.Drawing.Color.OrangeRed;
            this.redBut.Location = new System.Drawing.Point(762, 14);
            this.redBut.Name = "redBut";
            this.redBut.Size = new System.Drawing.Size(75, 23);
            this.redBut.TabIndex = 2;
            this.redBut.UseVisualStyleBackColor = false;
            this.redBut.Click += new System.EventHandler(this.redBut_Click);
            // 
            // yellowBut
            // 
            this.yellowBut.BackColor = System.Drawing.Color.Yellow;
            this.yellowBut.Location = new System.Drawing.Point(843, 14);
            this.yellowBut.Name = "yellowBut";
            this.yellowBut.Size = new System.Drawing.Size(75, 23);
            this.yellowBut.TabIndex = 3;
            this.yellowBut.UseVisualStyleBackColor = false;
            this.yellowBut.Click += new System.EventHandler(this.yellowBut_Click);
            // 
            // blueBut
            // 
            this.blueBut.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.blueBut.Location = new System.Drawing.Point(926, 14);
            this.blueBut.Name = "blueBut";
            this.blueBut.Size = new System.Drawing.Size(75, 23);
            this.blueBut.TabIndex = 4;
            this.blueBut.UseVisualStyleBackColor = false;
            this.blueBut.Click += new System.EventHandler(this.blueBut_Click);
            // 
            // greenBut
            // 
            this.greenBut.BackColor = System.Drawing.Color.ForestGreen;
            this.greenBut.Location = new System.Drawing.Point(1008, 14);
            this.greenBut.Name = "greenBut";
            this.greenBut.Size = new System.Drawing.Size(75, 23);
            this.greenBut.TabIndex = 5;
            this.greenBut.UseVisualStyleBackColor = false;
            this.greenBut.Click += new System.EventHandler(this.greenBut_Click);
            // 
            // sketchPad
            // 
            this.sketchPad.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sketchPad.Location = new System.Drawing.Point(13, 65);
            this.sketchPad.Name = "sketchPad";
            this.sketchPad.Size = new System.Drawing.Size(1070, 540);
            this.sketchPad.TabIndex = 6;
            this.sketchPad.Paint += new System.Windows.Forms.PaintEventHandler(this.sketchPad_Paint);
            this.sketchPad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sketchPad_MouseDoubleClick);
            this.sketchPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sketchPad_MouseDown);
            this.sketchPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sketchPad_MouseMove);
            this.sketchPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sketchPad_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(622, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Colour:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Drawing Tool:";
            // 
            // toolTip
            // 
            this.toolTip.AutoSize = true;
            this.toolTip.Location = new System.Drawing.Point(92, 45);
            this.toolTip.Name = "toolTip";
            this.toolTip.Size = new System.Drawing.Size(355, 17);
            this.toolTip.TabIndex = 9;
            this.toolTip.Text = "Click and drag to draw a line that will follow your cursor.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tool Tip:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 617);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolTip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sketchPad);
            this.Controls.Add(this.greenBut);
            this.Controls.Add(this.blueBut);
            this.Controls.Add(this.yellowBut);
            this.Controls.Add(this.redBut);
            this.Controls.Add(this.blackBut);
            this.Controls.Add(this.shapeSelection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox shapeSelection;
        private System.Windows.Forms.Button blackBut;
        private System.Windows.Forms.Button redBut;
        private System.Windows.Forms.Button yellowBut;
        private System.Windows.Forms.Button blueBut;
        private System.Windows.Forms.Button greenBut;
        private System.Windows.Forms.Panel sketchPad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label toolTip;
        private System.Windows.Forms.Label label3;
    }
}

