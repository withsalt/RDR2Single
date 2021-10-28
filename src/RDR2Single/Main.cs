using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDR2Single
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            string path = tb_path.Text;
            if (!CheckParams(true))
            {
                return;
            }
            if (!StartUpFileOperation.DeleteCodeFromStartUpFile(path))
            {
                MessageBox.Show($"操作失败，写入Code到卡单文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!BootLauncherFlowFileOperation.DeleteBootLauncherFlow(path))
            {
                MessageBox.Show($"操作失败，更新卡单文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadOldCode();
            MessageBox.Show($"操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {
            string path = tb_path.Text;
            string code = tb_code.Text;
            if (!CheckParams(false))
            {
                return;
            }
            if (!StartUpFileOperation.DeleteCodeAndRewriteCodeToStartUpFile(path, code))
            {
                MessageBox.Show($"操作失败，写入Code到卡单文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!BootLauncherFlowFileOperation.WriteBootLauncherFlow(path))
            {
                MessageBox.Show($"操作失败，更新卡单文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadOldCode();
            Common.SaveConfig(path, code);
            MessageBox.Show($"操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_open_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择游戏安装路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!Common.CheckIsGamePath(dialog.SelectedPath))
                {
                    MessageBox.Show($"你选择的路径（{dialog.SelectedPath}）非游戏根目录，请重新选择。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tb_path.Text = dialog.SelectedPath;
            }
        }

        private bool CheckParams(bool onlyPath)
        {
            //验证游戏路径
            string inputPath = tb_path.Text;
            if (string.IsNullOrEmpty(inputPath))
            {
                MessageBox.Show($"请选择游戏安装目录。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Common.CheckIsGamePath(inputPath))
            {
                MessageBox.Show($"你选择的路径（{inputPath}）非游戏根目录，请重新选择。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //验证单人代码
            if (!onlyPath)
            {
                //最多13位
                string inputCode = tb_code.Text;
                if (string.IsNullOrEmpty(inputCode))
                {
                    MessageBox.Show($"请输入单人战局代码。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (inputCode.Length > Common.CodeMaxLength)
                {
                    MessageBox.Show($"单人战局代码最多{Common.CodeMaxLength}位，请重新输入。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                string pattern = @"^[A-Za-z0-9]+$";
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(inputCode))
                {
                    MessageBox.Show($"单人战局代码只能包含字母和数字，请重新输入。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void LoadOldCode()
        {
            if (!Common.CheckIsGamePath(tb_path.Text))
            {
                lab_status.Text = "未配置游戏根目录";
                lab_status.ForeColor = Color.Black;
                return;
            }
            string filePath = StartUpFileOperation.GetStartUpFilePath(tb_path.Text);
            if (!File.Exists(filePath))
            {
                lab_status.Text = "多人模式";
                lab_status.ForeColor = Color.Blue;
                return;
            }
            string fileContent = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(fileContent))
            {
                lab_status.Text = "多人模式";
                lab_status.ForeColor = Color.Blue;
                return;
            }
            string code = StartUpFileOperation.GetCodeFromStartUpFile(fileContent);
            if (string.IsNullOrEmpty(code))
            {
                lab_status.Text = "多人模式";
                lab_status.ForeColor = Color.Blue;
                return;
            }
            else
            {
                lab_status.Text = $"单人模式（代码：{code}）";
                lab_status.ForeColor = Color.GreenYellow;
                return;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tb_code.Focus();
            (bool result, ConfigModel config) = Common.LoadConfig();
            if (result)
            {
                tb_path.Text = config.Path;
                tb_code.Text = config.Code;
            }
            LoadOldCode();
        }
    }
}
