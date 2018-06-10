using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quản_lý_bán_hàng_siêu_thị.Class;

namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class frmKH : Form
    {
        public frmKH()
        {
            InitializeComponent();
        }
        DataTable KhachHang;
        private void Form1_Load(object sender, EventArgs e)
        {
            Class.Funtion.Connect(); //Mở kết nối
            txtmakh.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaKH,TenKH,DiaChi,SDT,Email From KhachHang";
            KhachHang = Funtion.GetDataToTable(sql); //lấy dữ liệu
            dataGridView.DataSource = KhachHang;

            dataGridView.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView.Columns[2].HeaderText = "Địa chỉ";
            dataGridView.Columns[3].HeaderText = "Điện thoại";
            dataGridView.Columns[4].HeaderText = "Email";

            dataGridView.Columns[0].Width = 150;
            dataGridView.Columns[1].Width = 200;
            dataGridView.Columns[2].Width = 150;
            dataGridView.Columns[3].Width = 150;
            dataGridView.Columns[4].Width = 150;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakh.Focus();
                return;
            }
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakh.Text = dataGridView.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenkh.Text = dataGridView.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiachi.Text = dataGridView.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtdienthoai.Text = dataGridView.CurrentRow.Cells["SDT"].Value.ToString();
            txtemail.Text = dataGridView.CurrentRow.Cells["Email"].Value.ToString();

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
            txtmakh.Enabled = true;
            txtmakh.Focus();
        }

        private void ResetValues()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            txtdienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakh.Focus();
                return;
            }
            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakh.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (txtemail.Text == "  ")
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }



            sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtmakh.Text.Trim() + "'";

            if (Funtion.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakh.Focus();
                txtmakh.Text = "";
                return;
            }
            sql = "INSERT INTO KhachHang(MaKH,TenKH, DiaChi,SDT, Email) VALUES (N'" + txtmakh.Text.Trim() + "',N'" + txttenkh.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "','" + txtdienthoai.Text + "',N'" + txtemail.Text.Trim() + "')";
            Funtion.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtmakh.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenkh.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return;
            }
            if (txtdienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdienthoai.Focus();
                return;
            }
            if (txtemail.Text == "   ")
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }



            sql = "UPDATE KhachHang SET  TenKH=N'" + txttenkh.Text.Trim().ToString() +
                    "',DiaChi=N'" + txtdiachi.Text.Trim().ToString() +
                    "',SDT='" + txtdienthoai.Text.ToString() +
                    "',Email=N'" + txtemail.Text.Trim().ToString() +
                    "' WHERE MaKH=N'" + txtmakh.Text + "'";
            Funtion.RunSQL(sql);
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
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE KhachHang WHERE MaKH=N'" + txtmakh.Text + "'";
                Funtion.RunSqlDel(sql);
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
            txtmakh.Enabled = false;
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
        private void frmKH_Load(object sender, EventArgs e)
        {

        }
    }
}
