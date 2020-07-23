using System;
using System.Windows.Forms;

namespace WatchNyan
{
    public partial class frmKeyword : Form
    {
        public string kw1 { get; set; }
        public string kw2 { get; set; }
        public string showFullLine { get; set; }

        public frmKeyword(string title, string ekw1, string ekw2, string showFullLineText)
        {
            InitializeComponent();
            this.Text = title;
            txtKeyword1.Text = ekw1;
            txtKeyword2.Text = ekw2;
            chkShowFullLine.Checked = string.IsNullOrEmpty(showFullLineText) ? false : true;
        }

        private void frmKeyword_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.kw1 = txtKeyword1.Text;
            this.kw2 = txtKeyword2.Text;
            this.showFullLine = chkShowFullLine.Checked == true ? "true" : string.Empty;
            if (string.IsNullOrEmpty(this.kw1) == true && string.IsNullOrEmpty(this.kw2) == false)
            {
                MessageBox.Show("不能在关键字为空的情况下，使用配合关键字！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
