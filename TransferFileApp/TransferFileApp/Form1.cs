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


        public void FileToTrama()
        {   // 1 byte de Protocolo
            // 2 byte de tamaño de nombre
            // -> 1 byte tamaño de nombre de archcivo
            // -> x byte de nombre
            // 16 byte de verificacion -- MD5?


            List<byte[]> elements = new List<byte[]>();

            List<byte> _trama = new List<byte>();
            List<byte> _bytesProtocol = new List<byte>();
            List<byte> _bytesTotalLenght = new List<byte>();
            List<byte> _bytesWidhName = new List<byte>();
            List<byte> _bytesData = new List<byte>();
            List<byte> _bytesCRC = new List<byte>();

            string _hash;
            List<byte> _bytesName = new List<byte>();
            Converters c = new Converters();
            //Protocol
            _bytesProtocol.AddRange(c.ConvertStringToBinary("0"));
             writeLine("ProtocolLenght=" + _bytesProtocol.Count().ToString());
            ListBinayToLog(_bytesProtocol);

            //NameWidh
            _bytesName.AddRange(c.ConvertStringToBinary("result.txt"));
            _bytesWidhName.AddRange((c.ConvertStringToBinary(_bytesName.Count.ToString())));
            writeLine("NameWidhlLenght=" + _bytesWidhName.Count());
            ListBinayToLog(_bytesWidhName);

            //AddNameAfterFile
            _bytesData.AddRange(c.GetFileByte(@"D:\File.txt"));
            
                _bytesData.AddRange(_bytesName);
            

            //TotalLenghData only Data
            _bytesTotalLenght.AddRange(c.ConvertStringToBinary(_bytesWidhName.Count().ToString()));
            writeLine("_bytesTotalLenght=" + _bytesTotalLenght.Count());


            //CRC widht hash MD5
            using (MD5 md5Hash = MD5.Create())
            {
                _hash = GetMd5Hash(md5Hash, _bytesData.ToArray());
            }
            _bytesCRC.AddRange(c.ConvertStringToBinary(_hash));
            writeLine("_bytesCRCLenght=" + _bytesCRC.Count());

            //Create Trama 


            _trama.AddRange(_bytesTotalLenght);
            _trama.AddRange(_bytesData);
            _trama.AddRange(_bytesCRC);
           
             
            writeLine("_tramaLenght=" + _trama.Count());
            string sss = "";
            foreach (var item in c.ConvertByteToBit(_trama.ToArray()))
            {
                sss += (bool)item ? "1" : "0";
            }

            writeLine(sss);


        }
        public void writeLine(string text)
        {
            string s = textBox1.Text;
            textBox1.Text = s +Environment.NewLine + text;
        }
        private void ListBinayToLog(List<byte> trama)
        {
            string sss = "";
            Converters c = new Converters();
            foreach (var item in c.ConvertByteToBit(trama.ToArray()))
            {
                sss += (bool)item ? "1" : "0";
            }

            writeLine(sss);

        }


        

        public string GetMd5Hash(MD5 md5Hash, byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
       
        private void btnAction_Click(object sender, EventArgs e)
        {
            FileToTrama();
        }
    }
}
