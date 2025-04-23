namespace WindowsFormsApp3
{
    partial class Form7
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
            this.components = new System.ComponentModel.Container();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.worldSkills_1DataSet = new WindowsFormsApp3.WorldSkills_1DataSet();
            this.patientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientsTableAdapter = new WindowsFormsApp3.WorldSkills_1DataSetTableAdapters.PatientsTableAdapter();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldSkills_1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(69, 12);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 82;
            this.dataGrid.RowTemplate.Height = 33;
            this.dataGrid.Size = new System.Drawing.Size(2487, 660);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 733);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(479, 733);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 71);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(855, 733);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 71);
            this.button3.TabIndex = 3;
            this.button3.Text = "Обновить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // worldSkills_1DataSet
            // 
            this.worldSkills_1DataSet.DataSetName = "WorldSkills_1DataSet";
            this.worldSkills_1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientsBindingSource
            // 
            this.patientsBindingSource.DataMember = "Patients";
            this.patientsBindingSource.DataSource = this.worldSkills_1DataSet;
            // 
            // patientsTableAdapter
            // 
            this.patientsTableAdapter.ClearBeforeFill = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1331, 733);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(281, 71);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Location = new System.Drawing.Point(1684, 724);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(412, 31);
            this.textBoxOrderId.TabIndex = 5;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2633, 1093);
            this.Controls.Add(this.textBoxOrderId);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid);
            this.Name = "Form7";
            this.Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.worldSkills_1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private WorldSkills_1DataSet worldSkills_1DataSet;
        private System.Windows.Forms.BindingSource patientsBindingSource;
        private WorldSkills_1DataSetTableAdapters.PatientsTableAdapter patientsTableAdapter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxOrderId;
    }
}