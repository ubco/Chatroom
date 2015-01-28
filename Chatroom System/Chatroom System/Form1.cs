using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chatroom_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createfile();
        }

        public void createfile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.FileName = "My Messages";
            sfd.Title = "Save the conversation";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                writeStringToFile(sfd.FileName, "Hello World !" + Environment.NewLine);
                writeStringToFile(sfd.FileName, "Hello World !" + Environment.NewLine);
                writeStringToFile(sfd.FileName, "Hello World !" + Environment.NewLine);
            }
        }

        public void writeStringToFile(String filePath,String content)
        {
            // File.WriteAllText(path, s);
            File.AppendAllText(filePath, content);
        }

        public String readStringFromFile(String filePath)
        {
            StreamReader sr = new StreamReader(File.OpenRead(filePath));
            return sr.ReadToEnd();
        }
        
        }
}
