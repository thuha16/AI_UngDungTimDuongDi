using Python.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTX_TimDuongDi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            // Lấy đường dẫn thư mục hiện tại của ứng dụng
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Tạo đường dẫn tương đối đến Python DLL
            string pythonDllPath = Path.Combine(currentDirectory, "python310.dll");

            // Đặt đường dẫn Python DLL
            Runtime.PythonDLL = pythonDllPath;
            //Runtime.PythonDLL = @"F:\Application\GTX_TimDuongDi\GTX_TimDuongDi\bin\Debug\net6.0-windows\python310.dll";
            InitializeComponent();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void FileTrongSo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn một tập tin .txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PathTrongSo.Text = openFileDialog.FileName.ToString();
            }

        }
        private void FileToaDo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Chọn một tập tin .txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PathToaDo.Text = openFileDialog.FileName.ToString();
            }
        }

        private void CheckUpLoadFile_Click(object sender, EventArgs e)
        {
            if (Option.SelectedItem.ToString() == "Simulated Annealing")
            {
                if (PathToaDo.Text.Trim() != "" && PathToaDo.Text.Trim() != "Chọn file liệu tọa độ của các đỉnh")
                {
                    MessageBox.Show("Load File thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CheckLoadFile.Checked = true;
                }
            }
            else
            {
                if (PathTrongSo.Text.Trim() != "" && PathToaDo.Text.Trim() != "" && PathTrongSo.Text.Trim() != "Chọn file dữ liệu đồ thị không trọng số" && PathToaDo.Text.Trim() != "Chọn file liệu tọa độ của các đỉnh")
                {
                    MessageBox.Show("Load File thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CheckLoadFile.Checked = true;
                }
                else
                {
                    MessageBox.Show("Load File không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CheckLoadFile.Checked = false;
                }
            }
        }

        private void CheckData_Click(object sender, EventArgs e)
        {
            if (NameNodeStart.Text.Trim() != "" && NameNodeEnd.Text.Trim() != "" && NameNodeStart.Text.Trim() != "Nhập vào đỉnh bắt đầu" && NameNodeEnd.Text.Trim() != "Nhập vào đỉnh kết thúc")
            {
                MessageBox.Show("Tải dữ liệu hoàn tất!", "Thông báo data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckLoadData.Checked = true;
            }
            else
            {
                MessageBox.Show("Tải dữ liệu không thành công!", "Thông báo data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckLoadData.Checked = false;
            }
        }
        private void NameNodeStart_Click(object sender, EventArgs e)
        {
            NameNodeStart.Clear();
        }
        private void NameNodeEnd_Click(object sender, EventArgs e)
        {
            NameNodeEnd.Clear();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ListChucNang.Enabled = false;
            Option.Items.Add("Astar + DFS");
            Option.Items.Add("Simulated Annealing");
            Option.SelectedItem = "Astar + DFS";
        }

        private void CheckLoadData_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckLoadData.Checked == true && CheckLoadFile.Checked == true)
            {
                ListChucNang.Enabled = true;
            }
        }
        private void CheckLoadFile_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckLoadData.Checked == true && CheckLoadFile.Checked == true)
            {
                ListChucNang.Enabled = true;
            }
        }
        private void NodeStart_Click(object sender, EventArgs e)
        {
            NameNodeStart.Clear();
            NameNodeStart.Focus();
        }

        private void NodeEnd_Click(object sender, EventArgs e)
        {
            NameNodeEnd.Clear();
            NameNodeEnd.Focus();
        }

        private void NameNodeStart_Leave(object sender, EventArgs e)
        {
            if (NameNodeStart.Text.Trim() == "")
            {
                NameNodeStart.Text = "Nhập vào đỉnh bắt đầu";
                NameNodeStart.ForeColor = Color.Red;
            }
            else if (NameNodeStart.Text.Trim() != "")
            {
                NameNodeStart.ForeColor = Color.Gray;
            }
        }

        private void NameNodeEnd_Leave(object sender, EventArgs e)
        {
            if (NameNodeEnd.Text.Trim() == "")
            {
                NameNodeEnd.Text = "Nhập vào đỉnh kết thúc";
                NameNodeEnd.ForeColor = Color.Red;
            }
            else if (NameNodeEnd.Text.Trim() != "")
            {
                NameNodeEnd.ForeColor = Color.Gray;
            }
        }

        private void Option_SelectedValueChanged(object sender, EventArgs e)
        {
            LamMoi_Click(sender, e);
            if (Option.SelectedItem.ToString() == "Astar + DFS")
            {
                ChucNang1.Text = "Tìm đường đi ngẫu nhiên";
                ChucNang2.Text = "Tìm đường đi ngắn nhất";
                FileTrongSo.Enabled = true;
                PathTrongSo.Enabled = true;
                ChucNang2.Enabled = true;
            }
            else
            {
                ChucNang1.Text = "Tìm chu trình tốt nhất từ Start đến End";
                ChucNang2.Enabled = false;
                ChucNang2.Text = string.Empty;
                FileTrongSo.Enabled = false;
                PathTrongSo.Enabled = false;
            }
        }

        private void HienThiDoThi_Click(object sender, EventArgs e)
        {
            if (ShowOption.Checked == false && CheckOption1.Checked == false && CheckOption2.Checked == false)
            {
                try
                {
                    ShowOption.Checked = true;
                    PythonEngine.Initialize();
                    using (Py.GIL())
                    {
                        dynamic pyShowGraph = Py.Import("ShowChart");
                        if (Option.SelectedItem.ToString() == "Astar + DFS")
                        {
                            dynamic graphVer1 = pyShowGraph.show_chart_option1(@PathTrongSo.Text.ToString(), @PathToaDo.Text.ToString());
                        }
                        else
                        {
                            dynamic graphVer2 = pyShowGraph.show_chart_option2(@PathToaDo.Text.ToString());
                        }
                    }
                    PythonEngine.Shutdown();
                    ShowOption.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Có lỗi đối với dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn đang thực hiện một chức năng khác! \n Vui lòng tắt chức đó để thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChucNang1_Click(object sender, EventArgs e)
        {
            if (ShowOption.Checked == false && CheckOption1.Checked == false && CheckOption2.Checked == false)
            {
                try
                {
                    CheckOption1.Checked = true;
                    PythonEngine.Initialize();
                    using (Py.GIL())
                    {
                        if (Option.SelectedItem.ToString() == "Astar + DFS")
                        {
                            dynamic pyAction1 = Py.Import("DFS");
                            dynamic randomPath = pyAction1.visualize_path(@PathTrongSo.Text.ToString(), @PathToaDo.Text.ToString(), NameNodeStart.Text, NameNodeEnd.Text);
                            if (randomPath == false)
                            {
                                MessageBox.Show("Không tồn tại đường đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            dynamic pyAction1 = Py.Import("SimulatedAnnealing");
                            dynamic roundPath = pyAction1.simulated_annealing_Option1(@PathToaDo.Text.ToString(), NameNodeStart.Text, NameNodeEnd.Text);
                            if (roundPath == false)
                            {
                                MessageBox.Show("Không tồn tại đường đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    PythonEngine.Shutdown();
                    CheckOption1.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Có lỗi đối với dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn đang thực hiện một chức năng khác! \n Vui lòng tắt chức đó để thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChucNang2_Click(object sender, EventArgs e)
        {
            if (ShowOption.Checked == false && CheckOption1.Checked == false && CheckOption2.Checked == false)
            {
                try
                {
                    CheckOption2.Checked = true;
                    PythonEngine.Initialize();
                    using (Py.GIL())
                    {
                        dynamic pyAction2 = Py.Import("Astar");
                        if (Option.SelectedItem.ToString() == "Astar + DFS")
                        {
                            dynamic shortestPath = pyAction2.ASTAR(@PathTrongSo.Text.ToString(), @PathToaDo.Text.ToString(), NameNodeStart.Text, NameNodeEnd.Text);
                            if (shortestPath == false)
                            {
                                MessageBox.Show("Không tồn tại đường đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    PythonEngine.Shutdown();
                    CheckOption2.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Có lỗi đối với dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn đang thực hiện một chức năng khác! \n Vui lòng tắt chức đó để thực hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LamMoi_Click(object sender, EventArgs e)
        {
            PathTrongSo.Clear();
            PathToaDo.Clear();
            NameNodeStart.Clear();
            NameNodeEnd.Clear();
            CheckLoadData.Checked = false;
            CheckLoadFile.Checked = false;
            ListChucNang.Enabled = false;
            PathTrongSo.Text = "Chọn file dữ liệu đồ thị";
            PathToaDo.Text = "Chọn file tọa độ của các đỉnh";
            NameNodeStart.Text = "Nhập vào đỉnh bắt đầu";
            NameNodeEnd.Text = "Nhập vào đỉnh kết thúc";
        }
    }
}
