
namespace ednevnik
{
    partial class Upisnica
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_upisnica = new System.Windows.Forms.TextBox();
            this.cmb_godina = new System.Windows.Forms.ComboBox();
            this.cmb_odeljenje = new System.Windows.Forms.ComboBox();
            this.cmb_ucenik = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Godina";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(470, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Odeljenje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(665, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ucenik";
            // 
            // txt_upisnica
            // 
            this.txt_upisnica.Enabled = false;
            this.txt_upisnica.Location = new System.Drawing.Point(129, 85);
            this.txt_upisnica.Name = "txt_upisnica";
            this.txt_upisnica.Size = new System.Drawing.Size(100, 22);
            this.txt_upisnica.TabIndex = 4;
            // 
            // cmb_godina
            // 
            this.cmb_godina.FormattingEnabled = true;
            this.cmb_godina.Location = new System.Drawing.Point(284, 85);
            this.cmb_godina.Name = "cmb_godina";
            this.cmb_godina.Size = new System.Drawing.Size(121, 24);
            this.cmb_godina.TabIndex = 5;
            this.cmb_godina.SelectedIndexChanged += new System.EventHandler(this.cmb_godina_SelectedIndexChanged);
            // 
            // cmb_odeljenje
            // 
            this.cmb_odeljenje.FormattingEnabled = true;
            this.cmb_odeljenje.Location = new System.Drawing.Point(455, 85);
            this.cmb_odeljenje.Name = "cmb_odeljenje";
            this.cmb_odeljenje.Size = new System.Drawing.Size(121, 24);
            this.cmb_odeljenje.TabIndex = 6;
            this.cmb_odeljenje.SelectedValueChanged += new System.EventHandler(this.cmb_odeljenje_SelectedValueChanged);
            // 
            // cmb_ucenik
            // 
            this.cmb_ucenik.FormattingEnabled = true;
            this.cmb_ucenik.Location = new System.Drawing.Point(619, 85);
            this.cmb_ucenik.Name = "cmb_ucenik";
            this.cmb_ucenik.Size = new System.Drawing.Size(190, 24);
            this.cmb_ucenik.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(80, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(743, 279);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.Location = new System.Drawing.Point(164, 137);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(125, 42);
            this.btn_insert.TabIndex = 9;
            this.btn_insert.Text = "Ubaci";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(369, 137);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(125, 42);
            this.btn_update.TabIndex = 10;
            this.btn_update.Text = "Izmeni";
            this.btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(573, 137);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(125, 42);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "Obrisi";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // Upisnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 498);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmb_ucenik);
            this.Controls.Add(this.cmb_odeljenje);
            this.Controls.Add(this.cmb_godina);
            this.Controls.Add(this.txt_upisnica);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Upisnica";
            this.Text = "Upisnica";
            this.Load += new System.EventHandler(this.Upisnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_upisnica;
        private System.Windows.Forms.ComboBox cmb_godina;
        private System.Windows.Forms.ComboBox cmb_odeljenje;
        private System.Windows.Forms.ComboBox cmb_ucenik;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
    }
}