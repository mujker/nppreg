using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace nppreg
{
    public partial class FormReg : Form
    {
        private const string RegAddress = "*\\shell\\NotePad++";

        public FormReg()
        {
            //
            // 窗体设置初始化
            //
            InitFormSettings();
            InitializeComponent();
            //
            // 事件绑定初始化
            //
            InitEvent();
        }


        /// <summary>
        /// 删除右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelOnClick(object sender, EventArgs e)
        {
            try
            {
                Registry.ClassesRoot.DeleteSubKeyTree(RegAddress);
                MessageBox.Show(@"删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 注册右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegOnClick(object sender, EventArgs e)
        {
            try
            {
                //
                // 判断右键名称是否为空
                //
                if (string.IsNullOrEmpty(tbShow.Text))
                {
                    MessageBox.Show($@"右键名称不可空");
                    return;
                }

                var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "notepad++.exe";
                //
                // 判断程序是否和notepad++.exe执行文件在同一个目录下
                //
                if (File.Exists(path))
                {
                    RegValue(path);
                }
                else
                {
                    //
                    // 提示是否手动选择notepad++路径？
                    //
                    var rst = MessageBox.Show($@"文件路径不正确：
{path}，
是否手动选择notepad++路径？", @"程序默认应放在notepad++.exe同目录", MessageBoxButtons.YesNo);

                    if (rst == DialogResult.Yes)
                    {
                        //
                        // 弹出文件选择框，增加过滤条件，根据选择结果判断是否执行注册方法
                        //
                        OpenFileDialog dialog = new OpenFileDialog
                        {
                            CheckFileExists = true,
                            Filter = @"notepad++执行文件|notepad++.exe"
                        };
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            path = dialog.FileName;
                            RegValue(path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="path">notepad++执行文件路径</param>
        private void RegValue(string path)
        {
            var nppkey = Registry.ClassesRoot.CreateSubKey(RegAddress, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (nppkey == null)
            {
                MessageBox.Show($@"注册表路径异常：HKEY_CLASSES_ROOT\{RegAddress}");
                return;
            }

            nppkey.SetValue("", tbShow.Text);
            nppkey.SetValue("Icon", path);
            var command = nppkey.CreateSubKey("Command", RegistryKeyPermissionCheck.ReadWriteSubTree);
            var commValue = $"{path} \"%1\"";
            command?.SetValue("", commValue);
            MessageBox.Show(@"注册成功");
        }

        /// <summary>
        /// 初始化窗体设置
        /// </summary>
        private void InitFormSettings()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        private void InitEvent()
        {
            btnReg.Click += BtnRegOnClick;
            btnDel.Click += BtnDelOnClick;
        }
    }
}