namespace BookShop
{
    partial class AuthorForm
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
            this.Delete_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            this.Insert_button = new System.Windows.Forms.Button();
            this.Clear_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Input_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Input_surname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Input_name = new System.Windows.Forms.TextBox();
            this.Select_country = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(916, 492);
            this.Delete_button.Margin = new System.Windows.Forms.Padding(4);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(133, 37);
            this.Delete_button.TabIndex = 26;
            this.Delete_button.Text = "Delete";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Update_button
            // 
            this.Update_button.Location = new System.Drawing.Point(775, 492);
            this.Update_button.Margin = new System.Windows.Forms.Padding(4);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(133, 37);
            this.Update_button.TabIndex = 25;
            this.Update_button.Text = "Update";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // Insert_button
            // 
            this.Insert_button.Location = new System.Drawing.Point(633, 492);
            this.Insert_button.Margin = new System.Windows.Forms.Padding(4);
            this.Insert_button.Name = "Insert_button";
            this.Insert_button.Size = new System.Drawing.Size(133, 37);
            this.Insert_button.TabIndex = 24;
            this.Insert_button.Text = "Insert";
            this.Insert_button.UseVisualStyleBackColor = true;
            this.Insert_button.Click += new System.EventHandler(this.Insert_button_Click);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(492, 492);
            this.Clear_button.Margin = new System.Windows.Forms.Padding(4);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(133, 37);
            this.Clear_button.TabIndex = 23;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 406);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 465);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Country:";
            // 
            // Input_search
            // 
            this.Input_search.Location = new System.Drawing.Point(916, 15);
            this.Input_search.Margin = new System.Windows.Forms.Padding(4);
            this.Input_search.Name = "Input_search";
            this.Input_search.Size = new System.Drawing.Size(132, 22);
            this.Input_search.TabIndex = 19;
            this.Input_search.TextChanged += new System.EventHandler(this.Input_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(849, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 465);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Surname:";
            // 
            // Input_surname
            // 
            this.Input_surname.Location = new System.Drawing.Point(685, 462);
            this.Input_surname.Margin = new System.Windows.Forms.Padding(4);
            this.Input_surname.Name = "Input_surname";
            this.Input_surname.Size = new System.Drawing.Size(132, 22);
            this.Input_surname.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 464);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Name:";
            // 
            // Input_name
            // 
            this.Input_name.Location = new System.Drawing.Point(467, 462);
            this.Input_name.Margin = new System.Windows.Forms.Padding(4);
            this.Input_name.Name = "Input_name";
            this.Input_name.Size = new System.Drawing.Size(132, 22);
            this.Input_name.TabIndex = 29;
            // 
            // Select_country
            // 
            this.Select_country.FormattingEnabled = true;
            this.Select_country.Location = new System.Drawing.Point(888, 460);
            this.Select_country.Margin = new System.Windows.Forms.Padding(4);
            this.Select_country.Name = "Select_country";
            this.Select_country.Size = new System.Drawing.Size(160, 24);
            this.Select_country.TabIndex = 31;
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 544);
            this.Controls.Add(this.Select_country);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Input_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Input_surname);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.Insert_button);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Input_search);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AuthorForm";
            this.Text = "Author";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Input_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Input_surname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Input_name;
        private System.Windows.Forms.ComboBox Select_country;
    }
}