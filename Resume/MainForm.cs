using Resume.DTO;
using Resume.service;

namespace Resume
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    outText.Text = folderBrowserDialog.SelectedPath;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    inText.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consoleText.Clear();
            if (string.IsNullOrEmpty(inText.Text))
            {
                MessageBox.Show("请选择简历文件路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(outText.Text))
            {
                MessageBox.Show("请选择文件输出路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] wordFiles = Directory.GetFiles(inText.Text, "*.*")
                .Where(file => file.ToLower().EndsWith(".doc") || file.ToLower().EndsWith(".docx"))
                .ToArray();
            List<PersonInfo> personInfos = new List<PersonInfo>();
            foreach (string file in wordFiles)
            { 
                PersonInfo personInfo = WordProcess.ReadWordFile(file);
                if (personInfo == null)
                {
                    consoleText.AppendText($"读取文件{file}失败！！！！！！！\r\n");
                    continue;
                }
                personInfos.Add(personInfo);
                     consoleText.AppendText($"读取文件{file}成功！\r\n");
            }
            var fileName=ExcelProcess.ExportToExcel(personInfos, outText.Text,consoleText);

            consoleText.AppendText($"文件处理完成！请查看文件：{fileName}\r\n");
        }
    }
}
