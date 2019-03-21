namespace Fantasymanager
{
    partial class Dungeonportal
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
            this.button_goto_generator = new System.Windows.Forms.Button();
            this.button_refresh_list = new System.Windows.Forms.Button();
            this.button_open_manager = new System.Windows.Forms.Button();
            this.listbox_containsSettings = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exit_picture_lol = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exit_picture_lol)).BeginInit();
            this.SuspendLayout();
            // 
            // button_goto_generator
            // 
            this.button_goto_generator.Location = new System.Drawing.Point(396, 77);
            this.button_goto_generator.Name = "button_goto_generator";
            this.button_goto_generator.Size = new System.Drawing.Size(153, 47);
            this.button_goto_generator.TabIndex = 0;
            this.button_goto_generator.Text = "Generator";
            this.button_goto_generator.UseVisualStyleBackColor = true;
            this.button_goto_generator.Click += new System.EventHandler(this.Button_goto_generator_click);
            // 
            // button_refresh_list
            // 
            this.button_refresh_list.Location = new System.Drawing.Point(396, 130);
            this.button_refresh_list.Name = "button_refresh_list";
            this.button_refresh_list.Size = new System.Drawing.Size(153, 47);
            this.button_refresh_list.TabIndex = 1;
            this.button_refresh_list.Text = "Refresh the list";
            this.button_refresh_list.UseVisualStyleBackColor = true;
            this.button_refresh_list.Click += new System.EventHandler(this.Button_refresh_list_Click);
            // 
            // button_open_manager
            // 
            this.button_open_manager.Location = new System.Drawing.Point(396, 183);
            this.button_open_manager.Name = "button_open_manager";
            this.button_open_manager.Size = new System.Drawing.Size(153, 39);
            this.button_open_manager.TabIndex = 2;
            this.button_open_manager.Text = "Open manager";
            this.button_open_manager.UseVisualStyleBackColor = true;
            // 
            // listbox_containsSettings
            // 
            this.listbox_containsSettings.FormattingEnabled = true;
            this.listbox_containsSettings.Location = new System.Drawing.Point(16, 49);
            this.listbox_containsSettings.Name = "listbox_containsSettings";
            this.listbox_containsSettings.Size = new System.Drawing.Size(364, 173);
            this.listbox_containsSettings.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Welcome to Fantasymanager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose a calendar setting from the list, or create a new one in the generator!";
            // 
            // exit_picture_lol
            // 
            this.exit_picture_lol.Image = global::Fantasymanager.Properties.Resources.exitlol;
            this.exit_picture_lol.InitialImage = null;
            this.exit_picture_lol.Location = new System.Drawing.Point(428, 12);
            this.exit_picture_lol.Name = "exit_picture_lol";
            this.exit_picture_lol.Size = new System.Drawing.Size(64, 64);
            this.exit_picture_lol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exit_picture_lol.TabIndex = 6;
            this.exit_picture_lol.TabStop = false;
            this.exit_picture_lol.Click += new System.EventHandler(this.Exit_picture_lol_Click);
            // 
            // Dungeonportal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(561, 238);
            this.Controls.Add(this.exit_picture_lol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listbox_containsSettings);
            this.Controls.Add(this.button_open_manager);
            this.Controls.Add(this.button_refresh_list);
            this.Controls.Add(this.button_goto_generator);
            this.MaximizeBox = false;
            this.Name = "Dungeonportal";
            this.Text = "Fantasymanager - Portal";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exit_picture_lol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_goto_generator;
        private System.Windows.Forms.Button button_refresh_list;
        private System.Windows.Forms.Button button_open_manager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listbox_containsSettings;
        private System.Windows.Forms.PictureBox exit_picture_lol;
    }
}

