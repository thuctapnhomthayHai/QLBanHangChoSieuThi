using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanHang.BUS;

namespace BanHang
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();
        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
        DataTable Banhang;//Lưu dữ liệu vào bảng Bán hàng
        private void BanHang_Load(object sender, EventArgs e)
        {
            BUS.DataAccess.Connect();//Mở kết nối
           // txt_mahd.Enabled = false;
           // btnLuu.Enabled = false;
           // btnHuy.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaHDX,NgayXuat,TongTien,GhiChu,MaNV,MaKH,MaHang,TenHang,DVT,MaNhaSX,MaLoai From DanhMucHang,HoaDonXuat";
            Banhang = DataAccess.GetDataToTable(sql); //lấy dữ liệu
            dtg_thongtinhoadon.DataSource = Banhang;

            dtg_thongtinhoadon.Columns[0].HeaderText = "Mã hóa đơn";
            dtg_thongtinhoadon.Columns[1].HeaderText = "Ngày xuất";
            dtg_thongtinhoadon.Columns[2].HeaderText = "Tổng tiền";
            dtg_thongtinhoadon.Columns[3].HeaderText = "Ghi chú";
            dtg_thongtinhoadon.Columns[4].HeaderText = "Mã nhân viên";
            dtg_thongtinhoadon.Columns[5].HeaderText = "Mã khách hàng";
            dtg_thongtinhoadon.Columns[6].HeaderText = "Mã hàng";
            dtg_thongtinhoadon.Columns[7].HeaderText = "Tên hàng";
            dtg_thongtinhoadon.Columns[8].HeaderText = "Đơn vị tính";
            dtg_thongtinhoadon.Columns[9].HeaderText = "Mã nhà sản xuất";
            dtg_thongtinhoadon.Columns[10].HeaderText = "Mã loại";


            dtg_thongtinhoadon.Columns[0].Width = 150;
            dtg_thongtinhoadon.Columns[1].Width = 200;
            dtg_thongtinhoadon.Columns[2].Width = 150;
            dtg_thongtinhoadon.Columns[3].Width = 150;
            dtg_thongtinhoadon.Columns[4].Width = 150;
            dtg_thongtinhoadon.Columns[5].Width = 150;
            dtg_thongtinhoadon.Columns[6].Width = 150;
            dtg_thongtinhoadon.Columns[7].Width = 150;
            dtg_thongtinhoadon.Columns[8].Width = 150;
            dtg_thongtinhoadon.Columns[9].Width = 150;
            dtg_thongtinhoadon.Columns[10].Width = 150;


            dtg_thongtinhoadon.AllowUserToAddRows = false;
            dtg_thongtinhoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahd.Focus();
                return;
            }
            if (Banhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_mahd.Text = dtg_thongtinhoadon.CurrentRow.Cells["MaHDX"].Value.ToString();
            txt_manv.Text = dtg_thongtinhoadon.CurrentRow.Cells["MaNV"].Value.ToString();
            txt_makh.Text = dtg_thongtinhoadon.CurrentRow.Cells["MaKH"].Value.ToString();
            txt_soluong.Text = dtg_thongtinhoadon.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_tongtien.Text = dtg_thongtinhoadon.CurrentRow.Cells["TongTien"].Value.ToString();
            txt_ghichu.Text = dtg_thongtinhoadon.CurrentRow.Cells["GhiChu"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
    }
}
