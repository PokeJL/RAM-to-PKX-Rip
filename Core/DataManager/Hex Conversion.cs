using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip
{
    class Hex_Conversion
    {
        public Hex_Conversion() { }

        /// <summary>
        /// Converts one hex byte to an int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int ConOneHex(byte hex)
        {
            return Convert.ToInt32(hex);
        }

        /// <summary>
        /// Converts a hex string stored in
        /// Little Endian to and int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int LittleEndian(byte[] hex, int start, int length)
        {
            byte[] buffer = new byte[length];
            int value = 0;
            byte temp;

            Extract(hex, buffer, start, length);

            Invert(buffer);

            if(length == 1)
            {
                temp = buffer[0];
                value = ConOneHex(temp);
            }
            if (length == 2)
            {
                value = Int16(buffer);
            }
            if (length == 3)
            {
                value = Int24(buffer);
            }
            if (length == 4)
            {
                value = Int32(buffer);
            }

            return value;
        }

        /// <summary>
        /// Converts a hex string stored in
        /// Little Endian to and int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns the converted hex value as an int from 2D array</returns>
        public int LittleEndian2D(byte[,] hex, int row, int start, int length)
        {
            byte[] buffer = new byte[length];
            int value = 0;
            byte temp;

            Extract2D(hex, buffer, row, start, length);

            Invert(buffer);

            if (length == 1)
            {
                temp = buffer[0];
                value = ConOneHex(temp);
            }
            if (length == 2)
            {
                value = Int16(buffer);
            }
            if (length == 3)
            {
                value = Int24(buffer);
            }
            if (length == 4)
            {
                value = Int32(buffer);
            }

            return value;
        }

        /// <summary>
        /// Extracts a hex string from a array of hex values
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns array of extracted values</returns>
        private void Extract(byte[] hex, byte[] buffer, int start, int length) 
        {
            for(int i = 0; i < length; i++)
            {
                buffer[i] = hex[i + start];
            }
        }

        /// <summary>
        /// Extracts a hex string from a array of hex values
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns array of extracted values from 2D array</returns>
        private void Extract2D(byte[,] hex, byte[] buffer, int row, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                buffer[i] = hex[row, i + start];
            }
        }

        private static void Invert(byte[] buffer)
        {
            int m = buffer.Length - 1;
            byte temp;
            for (int i = 0; i < m; i++, m--)
            {
                temp = buffer[i];
                buffer[i] = buffer[m];
                buffer[m] = temp;
            }
        }

        //Two byte hex to int
        private int Int16(byte[] buffer)
        {
            return buffer[0] << 8 | buffer[1];
        }

        //Three byte hex to int.  Not used at the moment
        private int Int24(byte[] buffer)
        {
            return buffer[0] << 16 | buffer[1] << 8 | buffer[2];
        }

        //Four byte hex to int.  Not used at the moment
        private int Int32(byte[] buffer)
        {
            return buffer[0] << 32 | buffer[1] << 16 | buffer[2] << 8 | buffer[3];
        }
    }
}
