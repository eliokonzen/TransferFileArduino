using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferFileApp
{
    public class Converters
    {

        public byte[] GetFileByte(string filename)
        {
            byte[] bytes;

            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
        }

        public BitArray ConvertByteToBit(byte[] _bytes)
        {
            var bits = new BitArray(_bytes);
            return bits;
        }
        public byte[] ConvertStringToBinary(string _messege)
        {
           
            
            byte[] _byts = Encoding.ASCII.GetBytes(_messege);
            return _byts;
        }

        public string ConvertBytesToString(byte[] _bytes)
        {
            string _messege = Encoding.ASCII.GetString(_bytes);
            return _messege;
        }

        public bool ConvertByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            { 
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);   
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close(); return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine(_Exception.Message); 
            }
            return false;
        }
    }
}


//bits de archcivo
//bits de nombre
//bits de tamaño de nombre
//bits de verificacion -- MD5?


