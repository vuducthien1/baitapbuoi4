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
    
        public partial class Nhanvien : Form
        {
            public NhanVien NhanVien { get; private set; }

            public Nhanvien()
            {
                InitializeComponent();
                
                btn_dongy.Click += new EventHandler(btnDongY_Click);
                btn_boqua.Click += new EventHandler(btnBoQua_Click);
            }

         
            public Nhanvien(NhanVien nhanVien) : this()
            {
                txt_msnv.Text = nhanVien.MSNV;
                txt_tennhanvien.Text = nhanVien.TenNV;
                txt_LuongCB.Text = nhanVien.LuongCB.ToString();
            }

            private void btnDongY_Click(object sender, EventArgs e)
            {
                string msnv = txt_msnv.Text;
                string tenNV = txt_tennhanvien.Text;
                decimal luongCB;

                if (string.IsNullOrWhiteSpace(msnv) || string.IsNullOrWhiteSpace(tenNV) || !decimal.TryParse(txt_LuongCB.Text, out luongCB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

              
                NhanVien = new NhanVien(msnv, tenNV, luongCB);
                DialogResult = DialogResult.OK; 
                Close();
            }

            private void btnBoQua_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }

