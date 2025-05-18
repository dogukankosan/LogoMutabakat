using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace ConsensusUI.Forms
{
    public partial class SplashScreen1 : SplashScreen
    {
        private volatile bool isCancelled = false;
        public bool IsCancelled => isCancelled;
        public SplashScreen1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.labelCopyright.Text = "Copyright © Nokta Bilgi İşlem A.Ş. 2000-" + DateTime.Now.Year.ToString();
            this.Load += (s, e) =>
            {
                if (this.Owner != null)
                {
                    this.Location = new System.Drawing.Point(
                        this.Owner.Location.X + (this.Owner.Width - this.Width) / 2,
                        this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2
                    );
                    this.TopMost = true;        
                    this.BringToFront();         
                    this.Activate();          
                }
            };
        }
        public void UpdateStatus(string message)
        {
            labelStatus.Text = message;
            labelStatus.Refresh();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            isCancelled = true;
        }
        private void btn_Cancel_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_Cancel, "Gönderimi İptal Et");
        }
        private void SplashScreen1_Load(object sender, EventArgs e)
        {
        }
    }
}