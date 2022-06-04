using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace BTL_HĐH
{
    public partial class AddProcess : Form
    {
        public AddProcess()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textProcessName.Text))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = textProcessName.Text;
                    proc.Start();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hãy nhập tên process", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
