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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetProcess();
        }
        //Danh sách các Process đang chạy
        Process[] process;
        void GetProcess()
        {
            process = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (var item in process) {
                //Tên process
                ListViewItem NewItem = new ListViewItem() { Text = item.ProcessName };
                //Mememory size
                NewItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.PagedSystemMemorySize.ToString() });
                listView1.Items.Add(NewItem);
            }
            
        }
        //Load lại và cập nhật danh sách process
        private void timer1_Tick(object sender, EventArgs e)
        {
            // nếu danh sách có thêm hoặc ít hơn danh sách cũ thì load lại
            if (process.Length != Process.GetProcesses().Length)
            {
                GetProcess();
            }
        }

        //Đóng process đang chạy
        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                int index = 0;
                foreach (var item in process)
                {
                    if(item.ProcessName == listView1.SelectedItems[0].Text)
                    {
                        index = process.ToList().IndexOf(item);
                    }
                }
                process[index].Kill();
            }
        }
        //Chạy process mới
        private void runNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddProcess frm = new AddProcess())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    GetProcess();
                }
            }
        }
    }
}
