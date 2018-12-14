namespace Fantasymanager
{
    partial class GeneratorForm
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
            this.GeneratorChoicebox = new System.Windows.Forms.ListBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.MonthInput = new System.Windows.Forms.TextBox();
            this.DayInput = new System.Windows.Forms.TextBox();
            this.HourInput = new System.Windows.Forms.TextBox();
            this.labelNameNewCal = new System.Windows.Forms.Label();
            this.labelMonthsNewCal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDaysNewCal = new System.Windows.Forms.Label();
            this.labelHoursNewCal = new System.Windows.Forms.Label();
            this.TryAddCalendar = new System.Windows.Forms.Button();
            this.genYear2 = new System.Windows.Forms.TextBox();
            this.genYear1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Stop generating";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GeneratorChoicebox
            // 
            this.GeneratorChoicebox.FormattingEnabled = true;
            this.GeneratorChoicebox.Location = new System.Drawing.Point(12, 12);
            this.GeneratorChoicebox.Name = "GeneratorChoicebox";
            this.GeneratorChoicebox.Size = new System.Drawing.Size(243, 160);
            this.GeneratorChoicebox.TabIndex = 1;
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(13, 255);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 20);
            this.nameInput.TabIndex = 2;
            // 
            // MonthInput
            // 
            this.MonthInput.Location = new System.Drawing.Point(119, 255);
            this.MonthInput.Name = "MonthInput";
            this.MonthInput.Size = new System.Drawing.Size(27, 20);
            this.MonthInput.TabIndex = 3;
            // 
            // DayInput
            // 
            this.DayInput.Location = new System.Drawing.Point(167, 255);
            this.DayInput.Name = "DayInput";
            this.DayInput.Size = new System.Drawing.Size(27, 20);
            this.DayInput.TabIndex = 4;
            // 
            // HourInput
            // 
            this.HourInput.Location = new System.Drawing.Point(200, 255);
            this.HourInput.Name = "HourInput";
            this.HourInput.Size = new System.Drawing.Size(27, 20);
            this.HourInput.TabIndex = 5;
            // 
            // labelNameNewCal
            // 
            this.labelNameNewCal.AutoSize = true;
            this.labelNameNewCal.Location = new System.Drawing.Point(13, 239);
            this.labelNameNewCal.Name = "labelNameNewCal";
            this.labelNameNewCal.Size = new System.Drawing.Size(35, 13);
            this.labelNameNewCal.TabIndex = 6;
            this.labelNameNewCal.Text = "Name";
            // 
            // labelMonthsNewCal
            // 
            this.labelMonthsNewCal.AutoSize = true;
            this.labelMonthsNewCal.Location = new System.Drawing.Point(116, 239);
            this.labelMonthsNewCal.Name = "labelMonthsNewCal";
            this.labelMonthsNewCal.Size = new System.Drawing.Size(42, 13);
            this.labelMonthsNewCal.TabIndex = 7;
            this.labelMonthsNewCal.Text = "Months";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Add a new calendar";
            // 
            // labelDaysNewCal
            // 
            this.labelDaysNewCal.AutoSize = true;
            this.labelDaysNewCal.Location = new System.Drawing.Point(164, 239);
            this.labelDaysNewCal.Name = "labelDaysNewCal";
            this.labelDaysNewCal.Size = new System.Drawing.Size(31, 13);
            this.labelDaysNewCal.TabIndex = 9;
            this.labelDaysNewCal.Text = "Days";
            // 
            // labelHoursNewCal
            // 
            this.labelHoursNewCal.AutoSize = true;
            this.labelHoursNewCal.Location = new System.Drawing.Point(201, 239);
            this.labelHoursNewCal.Name = "labelHoursNewCal";
            this.labelHoursNewCal.Size = new System.Drawing.Size(35, 13);
            this.labelHoursNewCal.TabIndex = 10;
            this.labelHoursNewCal.Text = "Hours";
            // 
            // TryAddCalendar
            // 
            this.TryAddCalendar.Location = new System.Drawing.Point(233, 255);
            this.TryAddCalendar.Name = "TryAddCalendar";
            this.TryAddCalendar.Size = new System.Drawing.Size(75, 23);
            this.TryAddCalendar.TabIndex = 11;
            this.TryAddCalendar.Text = "Add to list";
            this.TryAddCalendar.UseVisualStyleBackColor = true;
            this.TryAddCalendar.Click += new System.EventHandler(this.TryAddCalendar_Click);
            // 
            // genYear2
            // 
            this.genYear2.Location = new System.Drawing.Point(339, 41);
            this.genYear2.Name = "genYear2";
            this.genYear2.Size = new System.Drawing.Size(47, 20);
            this.genYear2.TabIndex = 12;
            // 
            // genYear1
            // 
            this.genYear1.Location = new System.Drawing.Point(264, 41);
            this.genYear1.Name = "genYear1";
            this.genYear1.Size = new System.Drawing.Size(66, 20);
            this.genYear1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Years to generate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "To";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 290);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genYear1);
            this.Controls.Add(this.genYear2);
            this.Controls.Add(this.TryAddCalendar);
            this.Controls.Add(this.labelHoursNewCal);
            this.Controls.Add(this.labelDaysNewCal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMonthsNewCal);
            this.Controls.Add(this.labelNameNewCal);
            this.Controls.Add(this.HourInput);
            this.Controls.Add(this.DayInput);
            this.Controls.Add(this.MonthInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.GeneratorChoicebox);
            this.Controls.Add(this.button1);
            this.Name = "GeneratorForm";
            this.Text = "GeneratorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox GeneratorChoicebox;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox MonthInput;
        private System.Windows.Forms.TextBox DayInput;
        private System.Windows.Forms.TextBox HourInput;
        private System.Windows.Forms.Label labelNameNewCal;
        private System.Windows.Forms.Label labelMonthsNewCal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDaysNewCal;
        private System.Windows.Forms.Label labelHoursNewCal;
        private System.Windows.Forms.Button TryAddCalendar;
        private System.Windows.Forms.TextBox genYear2;
        private System.Windows.Forms.TextBox genYear1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}