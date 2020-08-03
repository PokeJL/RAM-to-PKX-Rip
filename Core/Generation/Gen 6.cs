using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip.Core.Generation
{
    class Gen_6
    {
        public Gen_6() { }
        public int Start(byte[,] pokemon, string path, int column)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;
            int found = 0;
            byte[] test = new byte[232];

            inputFile = fm.OpenFile(path);
            found = SearchPokemon(pokemon, inputFile, column);
            return found;
        }

        private int SearchPokemon(byte[,] pokemon, byte[] inputFile, int column)
        {
            int found = 0;
            bool update = false;
            Hex_Conversion hex = new Hex_Conversion();
            Array_Manager arr = new Array_Manager();
            byte[] buffer = new byte[260];
            byte[] convert;

            if (inputFile.Length >= 292)
            {
                for (int i = 0; i < inputFile.Length && found < 24; i++)
                {
                    if (inputFile[i] == 0x28 && inputFile[i + 1] == 0x00 && inputFile[i + 2] == 0x00 && inputFile[i + 3] == 0x00 &&
                        inputFile[i + 4] == 0x20 && inputFile[i + 5] == 0x00 && inputFile[i + 6] == 0x00 && inputFile[i + 7] == 0x00 && 
                        inputFile[i + 8] == 0x00 && inputFile[i + 9] == 0x00 && inputFile[i + 10] == 0x00 && inputFile[i + 11] == 0x00 &&
                        inputFile[i + 12] == 0x00 && inputFile[i + 13] == 0x00 && inputFile[i + 14] == 0x00 && inputFile[i + 15] == 0x00 &&
                        inputFile[i + 16] == 0x00 && inputFile[i + 17] == 0x00 && inputFile[i + 18] == 0x00 && inputFile[i + 19] == 0x00 &&
                        inputFile[i + 20] == 0x00 && inputFile[i + 21] == 0x00 && inputFile[i + 22] == 0x00 && inputFile[i + 23] == 0x00 &&
                        inputFile[i + 24] == 0x00 && inputFile[i + 25] == 0x00 && inputFile[i + 26] == 0x00 && inputFile[i + 27] == 0x00 &&
                        inputFile[i + 28] == 0x00 && inputFile[i + 29] == 0x00 && inputFile[i + 30] == 0x00 && inputFile[i + 31] == 0x00)
                    {
                        if (i + 292 <= inputFile.Length)
                        {
                            int m = i + 32;
                            for (int n = 0; n < 260; n++, m++)
                            {
                                 buffer[n] = inputFile[m];
                            }
                            convert = PK6(buffer);
                            if (hex.LittleEndian(convert, 8, 2) < 721 && hex.LittleEndian(convert, 8, 2) != 0 && hex.LittleEndian(convert, 90, 2) != 0 &&
                                hex.LittleEndian(convert, 90, 2) < 622 && hex.LittleEndian(convert, 92, 2) < 622 && hex.LittleEndian(convert, 94, 2) < 622 &&
                                hex.LittleEndian(convert, 96, 2) < 622 && hex.LittleEndian(convert, 21, 2) < 182)
                            {
                                arr.UpdateCheck(pokemon, column, found, convert, ref update, 6);
                                if (update == false)
                                {
                                    arr.Array1Dto2D(pokemon, found, column, convert);
                                    found++;
                                }
                                update = false;
                            }
                        }
                    }
                }
            }
            return found;
        }

        private byte[] PK6(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted67(ref data);
            if (data.Length != PokeCrypto.SIZE_6PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_6PARTY);
            return data;
        }
    }
}