using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btbuoi4
{

    public partial class FormListView : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public FormListView()
        {
            InitializeComponent();
     
            btn_them.Click += new EventHandler(btnThem_Click);
            btn_sua.Click += new EventHandler(btnSua_Click);
            btn_xoa.Click += new EventHandler(btnXoa_Click);
            btn_dong.Click += new EventHandler(btnDong_Click);
        }

        private void FormListView_Load(object sender, EventArgs e)
        {
            CapNhatListView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
     
            Nhanvien formNhanVien = new Nhanvien();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                
                danhSachNhanVien.Add(formNhanVien.NhanVien);
                CapNhatListView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            { 
                int index = listView1.SelectedItems[0].Index;
                NhanVien nv = danhSachNhanVien[index];

                
                Nhanvien formNhanVien = new Nhanvien(nv);
                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                   
                    danhSachNhanVien[index] = formNhanVien.NhanVien;
                    CapNhatListView();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
               
                int index = listView1.SelectedItems[0].Index;

             
                danhSachNhanVien.RemoveAt(index);
                CapNhatListView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
        
            this.Close();
        }

        private void CapNhatListView()
        {
           
            listView1.Items.Clear();
            foreach (var nv in danhSachNhanVien)
            {
                ListViewItem item = new ListViewItem(nv.MSNV); 
                item.SubItems.Add(nv.TenNV);                  
                item.SubItems.Add(nv.LuongCB.ToString("C"));  
                listView1.Items.Add(item);
            }
        }
    }
}
