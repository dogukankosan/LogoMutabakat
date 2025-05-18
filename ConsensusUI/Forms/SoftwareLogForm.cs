using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConsensusUI.Classes;
using System.IO;

namespace ConsensusUI.Forms
{
    public partial class SoftwareLogForm : XtraForm
    {
        public SoftwareLogForm()
        {
            InitializeComponent();
        }
        private class LogItem
        {
            public string UILog { get; set; }
        }
        private List<LogItem> ReadLogs()
        {
            string uiPath = Path.Combine(Application.StartupPath, "Logs", "UILog.txt");
            var list = new List<LogItem>();

            if (File.Exists(uiPath))
            {
                foreach (var line in File.ReadAllLines(uiPath))
                {
                    list.Add(new LogItem { UILog = line });
                }
            }
            return list;
        }
        private void SoftwareLogForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = ReadLogs();
            UtilityHelper.CustomizeGridView(gridView1);
            gridView1.Columns["UILog"].Caption = "Log Mesajı";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
        }
        private void excelAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel'e Aktar";
                    saveDialog.FileName = "UILog.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        gridView1.OptionsPrint.PrintDetails = true;
                        gridControl1.ExportToXlsx(saveDialog.FileName);
                        XtraMessageBox.Show("Excel dosyası başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hatalı Excel İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string uiPath = Path.Combine(Application.StartupPath, "Logs", "UILog.txt");
                if (File.Exists(uiPath))
                    File.WriteAllText(uiPath, string.Empty); 
                gridControl1.DataSource = ReadLogs();
                gridView1.RefreshData();
                XtraMessageBox.Show("Log dosyası başarıyla temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Log dosyası temizlenirken hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}