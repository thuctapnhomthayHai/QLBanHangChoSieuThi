using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachHang.Class;


namespace QLKhachHang
{
    public partial class BangKhachHang : Form
    {
        public BangKhachHang()
        {
            InitializeComponent();
        }

        DataTable KhachHang; //Lưu dữ liệu bảng KHÁCH HÀNG

        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Function.Connect(); //Mở kết nối
            txtma.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
        }

        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaKH,TenKH,DiaChi,SDT,Email From KhachHang";
            KhachHang = Function.GetDataToTable(sql); //lấy dữ liệu
            DataGridView.DataSource = KhachHang;
          
            DataGridView.Columns[0].HeaderText = "Mã khách hàng";
            DataGridView.Columns[1].HeaderText = "Tên khách hàng";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "Điện thoại";
            DataGridView.Columns[4].HeaderText = "Email";
         
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 150;
            DataGridView.Columns[3].Width = 150;
            DataGridView.Columns[4].Width = 150;
         
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtma.Focus();
                return;
            }
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtma.Text = DataGridView.CurrentRow.Cells["MaKH"].Value.ToString();
            txtten.Text = DataGridView.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiachi.Text = DataGridView.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienthoai.Text = DataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            txtemail.Text = DataGridView.CurrentRow.Cells["Email"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           
            DialogResult hoi;
            hoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtma.Enabled = true;
            txtma.Focus();
        }

        private void ResetValues()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            mskDienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtma.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (txtemail.Text == "  ")
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }
           
           

            sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtma.Text.Trim() + "'";

            if (Function.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtma.Focus();
                txtma.Text = "";
                return;
            }
            sql = "INSERT INTO KhachHang(MaKH,TenKH, DiaChi,SDT, Email) VALUES (N'" + txtma.Text.Trim() + "',N'" + txtten.Text.Trim()  + "',N'" + txtdiachi.Text.Trim() + "','" + mskDienthoai.Text + "',N'" + txtemail.Text.Trim() + "')";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtma.Enabled = false;
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtten.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (txtemail.Text == "   ")
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }
           
           

            sql = "UPDATE KhachHang SET  TenKH=N'" + txtten.Text.Trim().ToString() +
                    "',DiaChi=N'" + txtdiachi.Text.Trim().ToString() +
                    "',SDT='" + mskDienthoai.Text.ToString() + 
                    "',Email=N'" + txtemail.Text.Trim().ToString() +
                    "' WHERE MaKH=N'" + txtma.Text + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtma.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachHang WHERE MaKH=N'" + txtma.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtma.Enabled = false;
        }

        private void txtma_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtten_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtdiachi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void mskDienthoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtemail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
