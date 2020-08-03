using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RAM_to_PKX_Rip
{
    class File_Manager
    {
        public File_Manager() { }

        public byte[] OpenFile(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void WriteFile(string path, byte[] inputFile)
        {
            //string myString = row.ToString();
            File.WriteAllBytes(path, inputFile);
        }
    }
}
