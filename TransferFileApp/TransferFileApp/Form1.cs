using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TransferFileApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        public void FileToFrame()
        {
            List<byte> _frame = new List<byte>();
            Converter converter = Converter.GetInstance();
            _frame =  converter.FileToFrame(@"D:\File.txt", "result.txt");
        }
       
        private void btnAction_Click(object sender, EventArgs e)
        {
            FileToFrame();
        }
    }
}
