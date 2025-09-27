namespace EF1
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            fNametxt = new TextBox();
            dataGridView1 = new DataGridView();
            addbtn = new Button();
            updatebtn = new Button();
            deletebtn = new Button();
            label2 = new Label();
            lnametxt = new TextBox();
            label4 = new Label();
            adresstxt = new TextBox();
            label3 = new Label();
            birthdatetxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 42);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // fNametxt
            // 
            fNametxt.Location = new Point(97, 42);
            fNametxt.Name = "fNametxt";
            fNametxt.Size = new Size(183, 27);
            fNametxt.TabIndex = 2;
            fNametxt.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(321, 42);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(678, 332);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // addbtn
            // 
            addbtn.Location = new Point(443, 398);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(94, 29);
            addbtn.TabIndex = 4;
            addbtn.Text = "Add";
            addbtn.UseVisualStyleBackColor = true;
            addbtn.Click += addbtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(578, 398);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(94, 29);
            updatebtn.TabIndex = 5;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += button2_Click;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(742, 398);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(94, 29);
            deletebtn.TabIndex = 6;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 113);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 7;
            label2.Text = "Last Name ";
            // 
            // lnametxt
            // 
            lnametxt.Location = new Point(97, 106);
            lnametxt.Name = "lnametxt";
            lnametxt.Size = new Size(183, 27);
            lnametxt.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 183);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 11;
            label4.Text = "Adress";
            label4.Click += label4_Click;
            // 
            // adresstxt
            // 
            adresstxt.Location = new Point(97, 176);
            adresstxt.Name = "adresstxt";
            adresstxt.Size = new Size(183, 27);
            adresstxt.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 245);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 13;
            label3.Text = "Birth Date";
            // 
            // birthdatetxt
            // 
            birthdatetxt.Location = new Point(97, 242);
            birthdatetxt.Name = "birthdatetxt";
            birthdatetxt.Size = new Size(183, 27);
            birthdatetxt.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 450);
            Controls.Add(birthdatetxt);
            Controls.Add(label3);
            Controls.Add(adresstxt);
            Controls.Add(label4);
            Controls.Add(lnametxt);
            Controls.Add(label2);
            Controls.Add(deletebtn);
            Controls.Add(updatebtn);
            Controls.Add(addbtn);
            Controls.Add(dataGridView1);
            Controls.Add(fNametxt);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox fNametxt;
        private DataGridView dataGridView1;
        private Button addbtn;
        private Button updatebtn;
        private Button deletebtn;
        private Label label2;
        private TextBox lnametxt;
        private Label label4;
        private TextBox adresstxt;
        private Label label3;
        private TextBox birthdatetxt;
    }
}
