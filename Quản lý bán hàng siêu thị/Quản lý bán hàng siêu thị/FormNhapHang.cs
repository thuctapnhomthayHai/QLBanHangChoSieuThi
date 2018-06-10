using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quản_lý_bán_hàng_siêu_thị
{
    public partial class FormNhapHang : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - EADVFVM; Initial Catalog = PMBanHangSieuThi; Integrated Security = True");

        private void show()
        {
            con.Open();
            String sql = "select * from ChiTietHoaDonNhap, HoaDonNhap where ChiTietHoaDonNhap.MaHDN = HoaDonNhap.MaHDN";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public FormNhapHang()
        {
            InitializeComponent();
        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            show();
        }
        String them1;
        String them2;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - EADVFVM; Initial Catalog = PMBanHangSieuThi; Integrated Security = True");

                con.Open();
                them1 = "insert into HoaDonNhap values ('"+txtmahd.Text+"','"+txtmancc.Text+"','"+dtpngaynhap.Text+"','"+txttongtien.Text+"','"+txtghichu.Text+"','"+txtmanv.Text+"')";
                SqlCommand cmd1 = new SqlCommand(them1, con);
                cmd1.ExecuteNonQuery();
                them2 = "insert into ChiTietHoaDonNhap values ('"+txtmahd.Text+"','"+txtmahang.Text+"','"+txtsl.Text+"','"+txtdongia.Text+"','"+txtthanhtien.Text+"')";
                SqlCommand cmd2 = new SqlCommand(them2, con);
                cmd2.ExecuteNonQuery();
                show();
            }
            catch
            {
                MessageBox.Show("Lỗi,mời thử lại");
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - EADVFVM; Initial Catalog = PMBanHangSieuThi; Integrated Security = True");
                con.Close();
            }
        }
        String sua1;
        String sua2;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - EADVFVM; Initial Catalog = PMBanHangSieuThi; Integrated Security = True");

                con.Open();
                sua1 = "update HoaDonNhap set MaNhaCC= '" + txtmancc.Text + "',NgayNhap= '" + dtpngaynhap.Text + "',TongTien= '" + txttongtien.Text + "',GhiChu= '" + txtghichu.Text + "',MaNV='" + txtmanv.Text + "' where MaHDN= '" + txtmahd.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sua1, con);
                cmd1.ExecuteNonQuery();
                sua2 = "update ChiTietHoaDonNhap set MaHang='" + txtmahang.Text + "',SoLuong='" + txtsl.Text + "',DonGia='" + txtdongia.Text + "',ThanhTien='" + txtthanhtien.Text + "' where MaHDN='" + txtmahd.Text + "'";
                SqlCommand cmd2 = new SqlCommand(sua2, con);
                cmd2.ExecuteNonQuery();
                show();
            }
            catch
            {
                MessageBox.Show("Lỗi,mời thử lại");
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP - EADVFVM; Initial Catalog = PMBanHangSieuThi; Integrated Security = True");
                con.Close();
            }
        }
        int index;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtmahd.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtmahd.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            txtmahang.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtdongia.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtghichu.Text = dataGridView1.Rows[index].Cells[9].Value.ToString();
            txtmancc.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            txtmanv.Text= dataGridView1.Rows[index].Cells[10].Value.ToString();
            txtsl.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtthanhtien.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            txttongtien.Text = dataGridView1.Rows[index].Cells[8].Value.ToString();
            dtpngaynhap.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
        }
    }
}
