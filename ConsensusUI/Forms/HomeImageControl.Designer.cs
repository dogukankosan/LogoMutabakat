namespace ConsensusUI.Forms
{
    partial class HomeImageControl
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
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_WaitCons = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_UnReadApprove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_unreadCancel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_MonthCons = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_TotalCountCons = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_TotalApprove = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblCancelTotalCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_MonthName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl_NowMonthCancel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(20, 41);
            this.chartControl1.Margin = new System.Windows.Forms.Padding(4);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(619, 258);
            this.chartControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bekleyen Mutabakat Sayısı:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.lbl_WaitCons);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 530);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 78);
            this.panel1.TabIndex = 2;
            // 
            // lbl_WaitCons
            // 
            this.lbl_WaitCons.AutoSize = true;
            this.lbl_WaitCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_WaitCons.Location = new System.Drawing.Point(145, 39);
            this.lbl_WaitCons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WaitCons.Name = "lbl_WaitCons";
            this.lbl_WaitCons.Size = new System.Drawing.Size(28, 30);
            this.lbl_WaitCons.TabIndex = 3;
            this.lbl_WaitCons.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Controls.Add(this.lbl_UnReadApprove);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(20, 427);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 96);
            this.panel2.TabIndex = 3;
            // 
            // lbl_UnReadApprove
            // 
            this.lbl_UnReadApprove.AutoSize = true;
            this.lbl_UnReadApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_UnReadApprove.Location = new System.Drawing.Point(145, 60);
            this.lbl_UnReadApprove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UnReadApprove.Name = "lbl_UnReadApprove";
            this.lbl_UnReadApprove.Size = new System.Drawing.Size(28, 30);
            this.lbl_UnReadApprove.TabIndex = 3;
            this.lbl_UnReadApprove.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(51, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 48);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kabul Edilmiş Okunmamış\r\n        Mutabakat Sayısı:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.lbl_unreadCancel);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(20, 324);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(329, 96);
            this.panel3.TabIndex = 4;
            // 
            // lbl_unreadCancel
            // 
            this.lbl_unreadCancel.AutoSize = true;
            this.lbl_unreadCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_unreadCancel.Location = new System.Drawing.Point(145, 60);
            this.lbl_unreadCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_unreadCancel.Name = "lbl_unreadCancel";
            this.lbl_unreadCancel.Size = new System.Drawing.Size(28, 30);
            this.lbl_unreadCancel.TabIndex = 3;
            this.lbl_unreadCancel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(49, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 48);
            this.label5.TabIndex = 1;
            this.label5.Text = "Reddedilmiş Okunmamış\r\n        Mutabakat Sayısı:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Aqua;
            this.panel4.Controls.Add(this.lbl_MonthCons);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(385, 324);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(329, 96);
            this.panel4.TabIndex = 5;
            // 
            // lbl_MonthCons
            // 
            this.lbl_MonthCons.AutoSize = true;
            this.lbl_MonthCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_MonthCons.Location = new System.Drawing.Point(145, 57);
            this.lbl_MonthCons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MonthCons.Name = "lbl_MonthCons";
            this.lbl_MonthCons.Size = new System.Drawing.Size(28, 30);
            this.lbl_MonthCons.TabIndex = 3;
            this.lbl_MonthCons.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label4.Location = new System.Drawing.Point(24, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 48);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bu Ay Gönderilen Mutabakat\r\n                  Sayısı";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Fuchsia;
            this.panel5.Controls.Add(this.lbl_TotalCountCons);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(385, 427);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(329, 96);
            this.panel5.TabIndex = 6;
            // 
            // lbl_TotalCountCons
            // 
            this.lbl_TotalCountCons.AutoSize = true;
            this.lbl_TotalCountCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_TotalCountCons.Location = new System.Drawing.Point(145, 60);
            this.lbl_TotalCountCons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TotalCountCons.Name = "lbl_TotalCountCons";
            this.lbl_TotalCountCons.Size = new System.Drawing.Size(28, 30);
            this.lbl_TotalCountCons.TabIndex = 3;
            this.lbl_TotalCountCons.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "Toplam Gönderilen Mutabakat \r\n                   Sayısı";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.lbl_TotalApprove);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(740, 324);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(329, 96);
            this.panel6.TabIndex = 7;
            // 
            // lbl_TotalApprove
            // 
            this.lbl_TotalApprove.AutoSize = true;
            this.lbl_TotalApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_TotalApprove.Location = new System.Drawing.Point(138, 60);
            this.lbl_TotalApprove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TotalApprove.Name = "lbl_TotalApprove";
            this.lbl_TotalApprove.Size = new System.Drawing.Size(28, 30);
            this.lbl_TotalApprove.TabIndex = 3;
            this.lbl_TotalApprove.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(20, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 48);
            this.label7.TabIndex = 1;
            this.label7.Text = "Toplam Onaylanan Mutabakat\r\n                  Sayısı";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel7.Controls.Add(this.lblCancelTotalCount);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(385, 530);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(329, 78);
            this.panel7.TabIndex = 8;
            // 
            // lblCancelTotalCount
            // 
            this.lblCancelTotalCount.AutoSize = true;
            this.lblCancelTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lblCancelTotalCount.Location = new System.Drawing.Point(145, 48);
            this.lblCancelTotalCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelTotalCount.Name = "lblCancelTotalCount";
            this.lblCancelTotalCount.Size = new System.Drawing.Size(28, 30);
            this.lblCancelTotalCount.TabIndex = 3;
            this.lblCancelTotalCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(16, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(272, 48);
            this.label9.TabIndex = 1;
            this.label9.Text = "Toplam Reddedilen Mutabakat \r\n                    Sayısı";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel8.Controls.Add(this.lbl_MonthName);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(740, 428);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(329, 96);
            this.panel8.TabIndex = 9;
            // 
            // lbl_MonthName
            // 
            this.lbl_MonthName.AutoSize = true;
            this.lbl_MonthName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_MonthName.Location = new System.Drawing.Point(113, 59);
            this.lbl_MonthName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MonthName.Name = "lbl_MonthName";
            this.lbl_MonthName.Size = new System.Drawing.Size(0, 30);
            this.lbl_MonthName.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.Location = new System.Drawing.Point(4, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(290, 48);
            this.label8.TabIndex = 1;
            this.label8.Text = "En Son Mutabakatın Gönderildiği \r\n                        Ay";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Azure;
            this.panel9.Controls.Add(this.lbl_NowMonthCancel);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Location = new System.Drawing.Point(740, 530);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(329, 78);
            this.panel9.TabIndex = 10;
            // 
            // lbl_NowMonthCancel
            // 
            this.lbl_NowMonthCancel.AutoSize = true;
            this.lbl_NowMonthCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold);
            this.lbl_NowMonthCancel.Location = new System.Drawing.Point(141, 48);
            this.lbl_NowMonthCancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NowMonthCancel.Name = "lbl_NowMonthCancel";
            this.lbl_NowMonthCancel.Size = new System.Drawing.Size(28, 30);
            this.lbl_NowMonthCancel.TabIndex = 3;
            this.lbl_NowMonthCancel.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.Location = new System.Drawing.Point(13, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(253, 48);
            this.label10.TabIndex = 1;
            this.label10.Text = "Bu Ay Reddedilen Mutabakat\r\n                   Sayısı";
            // 
            // chartControl2
            // 
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Location = new System.Drawing.Point(647, 41);
            this.chartControl2.Margin = new System.Windows.Forms.Padding(4);
            this.chartControl2.Name = "chartControl2";
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl2.Size = new System.Drawing.Size(442, 258);
            this.chartControl2.TabIndex = 11;
            // 
            // HomeImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomeImageControl";
            this.Size = new System.Drawing.Size(1121, 630);
            this.Load += new System.EventHandler(this.HomeImageControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_WaitCons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_UnReadApprove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_unreadCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_MonthCons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_TotalCountCons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_TotalApprove;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblCancelTotalCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbl_MonthName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl_NowMonthCancel;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraCharts.ChartControl chartControl2;
    }
}
