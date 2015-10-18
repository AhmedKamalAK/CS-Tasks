namespace SimulationTask_1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radNumberOfCustomers = new System.Windows.Forms.RadioButton();
            this.radStoppingTime = new System.Windows.Forms.RadioButton();
            this.txtNumberOfCustomers = new System.Windows.Forms.TextBox();
            this.txtStoppingTime = new System.Windows.Forms.TextBox();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnCustomersQueueGraph = new System.Windows.Forms.Button();
            this.btnCustomersQueueHistogram = new System.Windows.Forms.Button();
            this.btnServersBusyTimeGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(908, 435);
            this.dataGridView1.TabIndex = 1;
            // 
            // radNumberOfCustomers
            // 
            this.radNumberOfCustomers.AutoSize = true;
            this.radNumberOfCustomers.Checked = true;
            this.radNumberOfCustomers.Location = new System.Drawing.Point(12, 468);
            this.radNumberOfCustomers.Name = "radNumberOfCustomers";
            this.radNumberOfCustomers.Size = new System.Drawing.Size(129, 17);
            this.radNumberOfCustomers.TabIndex = 2;
            this.radNumberOfCustomers.TabStop = true;
            this.radNumberOfCustomers.Text = "Number of Customers";
            this.radNumberOfCustomers.UseVisualStyleBackColor = true;
            this.radNumberOfCustomers.CheckedChanged += new System.EventHandler(this.radNumberOfCustomers_CheckedChanged);
            // 
            // radStoppingTime
            // 
            this.radStoppingTime.AutoSize = true;
            this.radStoppingTime.Location = new System.Drawing.Point(189, 468);
            this.radStoppingTime.Name = "radStoppingTime";
            this.radStoppingTime.Size = new System.Drawing.Size(92, 17);
            this.radStoppingTime.TabIndex = 3;
            this.radStoppingTime.Text = "Stopping Time";
            this.radStoppingTime.UseVisualStyleBackColor = true;
            this.radStoppingTime.CheckedChanged += new System.EventHandler(this.radStoppingTime_CheckedChanged);
            // 
            // txtNumberOfCustomers
            // 
            this.txtNumberOfCustomers.Location = new System.Drawing.Point(12, 504);
            this.txtNumberOfCustomers.Name = "txtNumberOfCustomers";
            this.txtNumberOfCustomers.Size = new System.Drawing.Size(126, 20);
            this.txtNumberOfCustomers.TabIndex = 4;
            // 
            // txtStoppingTime
            // 
            this.txtStoppingTime.Enabled = false;
            this.txtStoppingTime.Location = new System.Drawing.Point(189, 504);
            this.txtStoppingTime.Name = "txtStoppingTime";
            this.txtStoppingTime.Size = new System.Drawing.Size(126, 20);
            this.txtStoppingTime.TabIndex = 5;
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(447, 468);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 56);
            this.btnSimulate.TabIndex = 6;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnCustomersQueueGraph
            // 
            this.btnCustomersQueueGraph.Location = new System.Drawing.Point(683, 468);
            this.btnCustomersQueueGraph.Name = "btnCustomersQueueGraph";
            this.btnCustomersQueueGraph.Size = new System.Drawing.Size(75, 56);
            this.btnCustomersQueueGraph.TabIndex = 7;
            this.btnCustomersQueueGraph.Text = "Customers Queue Graph";
            this.btnCustomersQueueGraph.UseVisualStyleBackColor = true;
            this.btnCustomersQueueGraph.Click += new System.EventHandler(this.btnCustomersQueueGraph_Click);
            // 
            // btnCustomersQueueHistogram
            // 
            this.btnCustomersQueueHistogram.Location = new System.Drawing.Point(764, 468);
            this.btnCustomersQueueHistogram.Name = "btnCustomersQueueHistogram";
            this.btnCustomersQueueHistogram.Size = new System.Drawing.Size(75, 56);
            this.btnCustomersQueueHistogram.TabIndex = 8;
            this.btnCustomersQueueHistogram.Text = "Customers Queue Histogram";
            this.btnCustomersQueueHistogram.UseVisualStyleBackColor = true;
            this.btnCustomersQueueHistogram.Click += new System.EventHandler(this.btnCustomersQueueHistogram_Click);
            // 
            // btnServersBusyTimeGraph
            // 
            this.btnServersBusyTimeGraph.Location = new System.Drawing.Point(845, 468);
            this.btnServersBusyTimeGraph.Name = "btnServersBusyTimeGraph";
            this.btnServersBusyTimeGraph.Size = new System.Drawing.Size(75, 56);
            this.btnServersBusyTimeGraph.TabIndex = 9;
            this.btnServersBusyTimeGraph.Text = "Servers Busy Time Graph";
            this.btnServersBusyTimeGraph.UseVisualStyleBackColor = true;
            this.btnServersBusyTimeGraph.Click += new System.EventHandler(this.btnServersBusyTimeGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 559);
            this.Controls.Add(this.btnServersBusyTimeGraph);
            this.Controls.Add(this.btnCustomersQueueHistogram);
            this.Controls.Add(this.btnCustomersQueueGraph);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.txtStoppingTime);
            this.Controls.Add(this.txtNumberOfCustomers);
            this.Controls.Add(this.radStoppingTime);
            this.Controls.Add(this.radNumberOfCustomers);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radNumberOfCustomers;
        private System.Windows.Forms.RadioButton radStoppingTime;
        private System.Windows.Forms.TextBox txtNumberOfCustomers;
        private System.Windows.Forms.TextBox txtStoppingTime;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnCustomersQueueGraph;
        private System.Windows.Forms.Button btnCustomersQueueHistogram;
        private System.Windows.Forms.Button btnServersBusyTimeGraph;
    }
}

