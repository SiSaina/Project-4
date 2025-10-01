namespace BookShop
{
    partial class BookForm
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
            this.Select_author = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Input_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Input_page = new System.Windows.Forms.TextBox();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            this.Insert_button = new System.Windows.Forms.Button();
            this.Clear_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Input_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Select_theme = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Input_price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Select_date = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_author
            // 
            this.Select_author.FormattingEnabled = true;
            this.Select_author.Location = new System.Drawing.Point(657, 459);
            this.Select_author.Margin = new System.Windows.Forms.Padding(4);
            this.Select_author.Name = "Select_author";
            this.Select_author.Size = new System.Drawing.Size(160, 24);
            this.Select_author.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 428);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Name:";
            // 
            // Input_name
            // 
            this.Input_name.Location = new System.Drawing.Point(467, 426);
            this.Input_name.Margin = new System.Windows.Forms.Padding(4);
            this.Input_name.Name = "Input_name";
            this.Input_name.Size = new System.Drawing.Size(176, 22);
            this.Input_name.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 430);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Pages:";
            // 
            // Input_page
            // 
            this.Input_page.Location = new System.Drawing.Point(713, 426);
            this.Input_page.Margin = new System.Windows.Forms.Padding(4);
            this.Input_page.Name = "Input_page";
            this.Input_page.Size = new System.Drawing.Size(132, 22);
            this.Input_page.TabIndex = 40;
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(916, 492);
            this.Delete_button.Margin = new System.Windows.Forms.Padding(4);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(133, 37);
            this.Delete_button.TabIndex = 39;
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
            this.Update_button.TabIndex = 38;
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
            this.Insert_button.TabIndex = 37;
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
            this.Clear_button.TabIndex = 36;
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
            this.dataGridView1.Size = new System.Drawing.Size(1033, 370);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(855, 430);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Price($):";
            // 
            // Input_search
            // 
            this.Input_search.Location = new System.Drawing.Point(916, 15);
            this.Input_search.Margin = new System.Windows.Forms.Padding(4);
            this.Input_search.Name = "Input_search";
            this.Input_search.Size = new System.Drawing.Size(132, 22);
            this.Input_search.TabIndex = 33;
            this.Input_search.TextChanged += new System.EventHandler(this.Input_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(849, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Search:";
            // 
            // Select_theme
            // 
            this.Select_theme.FormattingEnabled = true;
            this.Select_theme.Location = new System.Drawing.Point(888, 458);
            this.Select_theme.Margin = new System.Windows.Forms.Padding(4);
            this.Select_theme.Name = "Select_theme";
            this.Select_theme.Size = new System.Drawing.Size(160, 24);
            this.Select_theme.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 462);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "Publish date:";
            // 
            // Input_price
            // 
            this.Input_price.Location = new System.Drawing.Point(916, 426);
            this.Input_price.Margin = new System.Windows.Forms.Padding(4);
            this.Input_price.Name = "Input_price";
            this.Input_price.Size = new System.Drawing.Size(132, 22);
            this.Input_price.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(595, 463);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Author:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(827, 463);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "Theme:";
            // 
            // Select_date
            // 
            this.Select_date.Location = new System.Drawing.Point(320, 458);
            this.Select_date.Margin = new System.Windows.Forms.Padding(4);
            this.Select_date.Name = "Select_date";
            this.Select_date.Size = new System.Drawing.Size(265, 22);
            this.Select_date.TabIndex = 51;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 544);
            this.Controls.Add(this.Select_date);
            this.Controls.Add(this.Select_theme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Input_price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Select_author);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Input_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Input_page);
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
            this.Name = "BookForm";
            this.Text = "Book";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Select_author;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Input_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Input_page;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.Button Insert_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Input_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Select_theme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Input_price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Select_date;
    }
}