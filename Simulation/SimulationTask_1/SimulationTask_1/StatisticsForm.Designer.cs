namespace SimulationTask_1
{
    partial class StatisticsForm
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
            this.txtAverageWaiting = new System.Windows.Forms.TextBox();
            this.txtCustomerWaitingProbability = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxQueueLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grdServersStatisticsTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdServersStatisticsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average Customer Waiting Time:";
            // 
            // txtAverageWaiting
            // 
            this.txtAverageWaiting.Location = new System.Drawing.Point(275, 32);
            this.txtAverageWaiting.Name = "txtAverageWaiting";
            this.txtAverageWaiting.ReadOnly = true;
            this.txtAverageWaiting.Size = new System.Drawing.Size(177, 20);
            this.txtAverageWaiting.TabIndex = 1;
            // 
            // txtCustomerWaitingProbability
            // 
            this.txtCustomerWaitingProbability.Location = new System.Drawing.Point(275, 71);
            this.txtCustomerWaitingProbability.Name = "txtCustomerWaitingProbability";
            this.txtCustomerWaitingProbability.ReadOnly = true;
            this.txtCustomerWaitingProbability.Size = new System.Drawing.Size(177, 20);
            this.txtCustomerWaitingProbability.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer Waiting Probability:";
            // 
            // txtMaxQueueLength
            // 
            this.txtMaxQueueLength.Location = new System.Drawing.Point(275, 112);
            this.txtMaxQueueLength.Name = "txtMaxQueueLength";
            this.txtMaxQueueLength.ReadOnly = true;
            this.txtMaxQueueLength.Size = new System.Drawing.Size(177, 20);
            this.txtMaxQueueLength.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maximum Queue Length:";
            // 
            // grdServersStatisticsTable
            // 
            this.grdServersStatisticsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServersStatisticsTable.Location = new System.Drawing.Point(12, 152);
            this.grdServersStatisticsTable.Name = "grdServersStatisticsTable";
            this.grdServersStatisticsTable.ReadOnly = true;
            this.grdServersStatisticsTable.Size = new System.Drawing.Size(474, 225);
            this.grdServersStatisticsTable.TabIndex = 6;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 389);
            this.Controls.Add(this.grdServersStatisticsTable);
            this.Controls.Add(this.txtMaxQueueLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerWaitingProbability);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAverageWaiting);
            this.Controls.Add(this.label1);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdServersStatisticsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAverageWaiting;
        private System.Windows.Forms.TextBox txtCustomerWaitingProbability;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxQueueLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdServersStatisticsTable;
    }
}