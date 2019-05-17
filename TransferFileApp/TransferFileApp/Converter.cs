using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TransferFileApp
{
    public class Converter
    {
        private static Converter instance;
        public static Converter GetInstance()
        {
            if (instance == null)
                instance = new Converter();
            return instance;
        }

        private CommonMethods commonMethods;
       /// <summary>
       ///   1 byte de Protocolo
       ///   2 byte de Datos
       ///   X byte de Datos
       ///   16 byte CRC -- MD5
       /// </summary>
  
        public List<byte> FileToFrame(string filePath, string fileName)
        {
            string _fileName;
            string _filePath;
            _fileName = fileName;
            _filePath = filePath;
            List<byte> _frame = new List<byte>();
            List<byte> _bytesProtocol = new List<byte>();
            List<byte> _bytesTotalLength = new List<byte>();
            List<byte> _bytesData = new List<byte>();
            List<byte> _bytesCRC = new List<byte>();
            
            string _hash;
            

            commonMethods = CommonMethods.GetInstance();

            //Protocol
            _bytesProtocol.AddRange(commonMethods.ConvertStringToBinary("0"));

            //DateByte
            _bytesData = getDataListByte(_filePath, _fileName);

            //TotalLengthByteData
            _bytesTotalLength.AddRange(commonMethods.ConvertStringToBinary(_bytesData.Count().ToString()));


            //CRC widht hash MD5
            using (MD5 md5Hash = MD5.Create())
            {
                _hash = commonMethods.GetMd5Hash(md5Hash, _bytesData.ToArray());
            }
            _bytesCRC.AddRange(commonMethods.ConvertStringToBinary(_hash));

            //Create Frame
            _frame.AddRange(_bytesProtocol);
            _frame.AddRange(_bytesTotalLength);
            _frame.AddRange(_bytesData);
            _frame.AddRange(_bytesCRC);

            return _frame;
        }


        public List<byte> getDataListByte(String pathFile, String nameFile)
        {   //Date  + NameFile +  NameLength
            List<byte> _bytesName = new List<byte>();
            List<byte> _bytesNameLength = new List<byte>();
            List<byte> _bytesData = new List<byte>();

            _bytesName.AddRange(commonMethods.ConvertStringToBinary(nameFile));
            _bytesNameLength.AddRange((commonMethods.ConvertStringToBinary(_bytesName.Count.ToString())));
            _bytesData.AddRange(commonMethods.GetFileByte(pathFile));
            _bytesData.AddRange(_bytesName);
            return _bytesData;
        }
        
    }
}
