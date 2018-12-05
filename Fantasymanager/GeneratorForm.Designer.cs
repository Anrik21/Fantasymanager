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
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 290);
            this.Controls.Add(this.GeneratorChoicebox);
            this.Controls.Add(this.button1);
            this.Name = "GeneratorForm";
            this.Text = "GeneratorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox GeneratorChoicebox;
    }
}