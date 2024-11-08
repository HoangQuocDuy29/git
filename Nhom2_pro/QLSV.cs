using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom2_pro
{
    public partial class QLSV : Form
    {
        public QLSV()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void QLSV_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;"; // Chuỗi kết nối đến SQL Server

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien WHERE DaXoa = 0", conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt; // Gán DataTable cho DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấn vào hàng hợp lệ hay không
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin hàng đã chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy thông tin sinh viên từ hàng đã chọn
                string maSV = selectedRow.Cells["MaSV"].Value.ToString();
                string ho = selectedRow.Cells["Ho"].Value.ToString();
                string ten = selectedRow.Cells["Ten"].Value.ToString();

                // Hiển thị thông tin sinh viên đã chọn
                MessageBox.Show($"Bạn đã chọn sinh viên:\nMã SV: {maSV}\nHọ: {ho}\nTên: {ten}");
            }

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy thông tin hàng đã chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy thông tin sinh viên từ hàng đã chọn và gán cho các ô nhập liệu
                txtmasv.Text = selectedRow.Cells["MaSV"].Value.ToString();
                txtho.Text = selectedRow.Cells["Ho"].Value.ToString();
                txtten.Text = selectedRow.Cells["Ten"].Value.ToString();
                txtemail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtsdt.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                txtmanganh.Text = selectedRow.Cells["MaNganh"].Value.ToString();
                date.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                txtdiachi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtsocmnd.Text = selectedRow.Cells["SoCMND"].Value.ToString();
                txtkhoahoc.Text = selectedRow.Cells["KhoaHoc"].Value.ToString();
                txtghichu.Text = selectedRow.Cells["GhiChu"].Value.ToString();

                // Set ComboBox1 based on the gender column
                string gender = selectedRow.Cells["GioiTinh"].Value.ToString();
                if (comboBox1.Items.Contains(gender))
                {
                    comboBox1.SelectedItem = gender;
                }
                else
                {
                    comboBox1.SelectedIndex = -1; // Deselect if the value is not recognized
                }
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label1.Left = (panel1.Width - label1.Width) / 2;
            label1.Top = (panel1.Height - label1.Height) / 2;
           
        }

        private void txtmasv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtho_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void gtnam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gtnu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gtkhac_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsocmnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkhoahoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtghichu_TextChanged(object sender, EventArgs e)
        {

        }

        private void daxoa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chuaxoa_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO SinhVien (MaSV, Ho, Ten, Email, SoDienThoai, MaNganh, NgaySinh, DiaChi, SoCMND, KhoaHoc, GhiChu, GioiTinh, DaXoa) VALUES (@MaSV, @Ho, @Ten, @Email, @SoDienThoai, @MaNganh, @NgaySinh, @DiaChi, @SoCMND, @KhoaHoc, @GhiChu, @GioiTinh, 0)", conn);

                    // Adding parameters from input fields
                    cmd.Parameters.AddWithValue("@MaSV", txtmasv.Text);
                    cmd.Parameters.AddWithValue("@Ho", txtho.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtten.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@MaNganh", txtmanganh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", date.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@SoCMND", txtsocmnd.Text);
                    cmd.Parameters.AddWithValue("@KhoaHoc", txtkhoahoc.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text);

                    // Retrieve and add ComboBox1 value for gender
                    if (comboBox1.SelectedItem != null)
                    {
                        cmd.Parameters.AddWithValue("@GioiTinh", comboBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn giới tính.");
                        return;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm sinh viên thành công!");
                    LoadData(); // Cập nhật DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            // Check if a student is selected before attempting to update
            if (string.IsNullOrEmpty(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để sửa.");
                return;
            }

            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE SinhVien SET Ho = @Ho, Ten = @Ten, Email = @Email, SoDienThoai = @SoDienThoai, " +
                        "MaNganh = @MaNganh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, SoCMND = @SoCMND, " +
                        "KhoaHoc = @KhoaHoc, GhiChu = @GhiChu WHERE MaSV = @MaSV", conn);

                    // Adding parameters to the query with values from input fields
                    cmd.Parameters.AddWithValue("@MaSV", txtmasv.Text);
                    cmd.Parameters.AddWithValue("@Ho", txtho.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtten.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txtsdt.Text);
                    cmd.Parameters.AddWithValue("@MaNganh", txtmanganh.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", date.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@SoCMND", txtsocmnd.Text);
                    cmd.Parameters.AddWithValue("@KhoaHoc", txtkhoahoc.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtghichu.Text);

                    // Execute the update command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sinh viên thành công!");
                        LoadData(); // Refresh the DataGridView with updated data
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với mã SV đã chọn.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
    {
        string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";
        string maSV = dataGridView1.SelectedRows[0].Cells["MaSV"].Value.ToString(); // Lấy mã sinh viên từ hàng đã chọn

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SinhVien SET DaXoa = 1 WHERE MaSV = @MaSV", conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Đánh dấu sinh viên đã xóa thành công!");
                LoadData(); // Cập nhật DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    else
    {
        MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
    }
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien WHERE DaXoa = 1", conn); // Query to get deleted students
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt; // Display deleted students in DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên nào đã bị xóa.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnsvhientai_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien WHERE DaXoa = 0", conn); // Query to get non-deleted students
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt; // Display non-deleted students in DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên hiện tại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnkhoiphuc_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";
                string maSV = dataGridView1.SelectedRows[0].Cells["MaSV"].Value.ToString(); // Get selected student ID (MaSV)

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE SinhVien SET DaXoa = 0 WHERE MaSV = @MaSV", conn); // Restore student
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Khôi phục sinh viên thành công!");
                            LoadDeletedStudents(); // Refresh to show updated list of deleted students
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để khôi phục.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên để khôi phục.");
            }
        }
        private void LoadDeletedStudents()
        {
            string connectionString = "Data Source=HOANG-QUOC-DUY;Initial Catalog=QuanLySinhVien;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM SinhVien WHERE DaXoa = 1", conn); // Query to get deleted students
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt; // Display deleted students in DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
