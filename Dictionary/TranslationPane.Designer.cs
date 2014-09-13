namespace Dictionary
{
    partial class TranslationPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Definition = new System.Windows.Forms.TextBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.WordList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Close_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Group_ComboBox = new System.Windows.Forms.ComboBox();
            this.WordComboBox = new System.Windows.Forms.ComboBox();
            this.WordName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Definition
            // 
            this.Definition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Definition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Definition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Definition.Location = new System.Drawing.Point(11, 194);
            this.Definition.Multiline = true;
            this.Definition.Name = "Definition";
            this.Definition.Size = new System.Drawing.Size(192, 286);
            this.Definition.TabIndex = 1;
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Location = new System.Drawing.Point(162, 492);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(41, 22);
            this.Add_Button.TabIndex = 2;
            this.Add_Button.Text = "Add";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "noun",
            "verb",
            "adj",
            "adv",
            "phrase",
            "other"});
            this.TypeComboBox.Location = new System.Drawing.Point(102, 95);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(101, 21);
            this.TypeComboBox.TabIndex = 3;
            // 
            // WordList
            // 
            this.WordList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WordList.FormattingEnabled = true;
            this.WordList.Location = new System.Drawing.Point(230, 8);
            this.WordList.Name = "WordList";
            this.WordList.Size = new System.Drawing.Size(163, 472);
            this.WordList.TabIndex = 5;
            this.WordList.SelectedIndexChanged += new System.EventHandler(this.WordList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Definition:";
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.Location = new System.Drawing.Point(115, 492);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(41, 22);
            this.Save_Button.TabIndex = 8;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Location = new System.Drawing.Point(295, 492);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(46, 22);
            this.Delete_Button.TabIndex = 9;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Button.Location = new System.Drawing.Point(347, 492);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(46, 22);
            this.Close_Button.TabIndex = 10;
            this.Close_Button.Text = "Close";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Group:";
            // 
            // Group_ComboBox
            // 
            this.Group_ComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Group_ComboBox.FormattingEnabled = true;
            this.Group_ComboBox.Location = new System.Drawing.Point(69, 122);
            this.Group_ComboBox.Name = "Group_ComboBox";
            this.Group_ComboBox.Size = new System.Drawing.Size(134, 21);
            this.Group_ComboBox.TabIndex = 12;
            this.Group_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Group_ComboBox_SelectedIndexChanged);
            // 
            // WordComboBox
            // 
            this.WordComboBox.FormattingEnabled = true;
            this.WordComboBox.Location = new System.Drawing.Point(12, 59);
            this.WordComboBox.Name = "WordComboBox";
            this.WordComboBox.Size = new System.Drawing.Size(144, 21);
            this.WordComboBox.TabIndex = 14;
            this.WordComboBox.SelectedIndexChanged += new System.EventHandler(this.WordComboBox_SelectedIndexChanged);
            // 
            // WordName
            // 
            this.WordName.Location = new System.Drawing.Point(10, 16);
            this.WordName.Multiline = true;
            this.WordName.Name = "WordName";
            this.WordName.Size = new System.Drawing.Size(192, 27);
            this.WordName.TabIndex = 15;
            this.WordName.TextChanged += new System.EventHandler(this.WordName_TextChanged);
            // 
            // TranslationPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.WordName);
            this.Controls.Add(this.WordComboBox);
            this.Controls.Add(this.Group_ComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WordList);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.Definition);
            this.Name = "TranslationPane";
            this.Size = new System.Drawing.Size(410, 524);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Definition;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ListBox WordList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Group_ComboBox;
        private System.Windows.Forms.ComboBox WordComboBox;
        private System.Windows.Forms.TextBox WordName;
    }
}
