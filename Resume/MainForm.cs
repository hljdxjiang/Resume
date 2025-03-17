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
                MessageBox.Show("��ѡ������ļ�·����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(outText.Text))
            {
                MessageBox.Show("��ѡ���ļ����·����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    consoleText.AppendText($"��ȡ�ļ�{file}ʧ�ܣ�������������\r\n");
                    continue;
                }
                personInfos.Add(personInfo);
                     consoleText.AppendText($"��ȡ�ļ�{file}�ɹ���\r\n");
            }
            var fileName=ExcelProcess.ExportToExcel(personInfos, outText.Text,consoleText);

            consoleText.AppendText($"�ļ�������ɣ���鿴�ļ���{fileName}\r\n");
        }
    }
}
