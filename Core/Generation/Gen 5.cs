using RAM_to_PKX_Rip.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip
{
    class Gen_5
    {

        public Gen_5() { }
        public int Start(byte[,] pokemon, string path, int column)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;
            int found = 0;

            inputFile = fm.OpenFile(path);
            found = SearchPokemon(pokemon, inputFile, column);

            return found;
        }

        private int SearchPokemon(byte[,] pokemon, byte[] inputFile, int column)
        {
            int found = 0;
            Hex_Conversion hex = new Hex_Conversion();
            Array_Manager arr = new Array_Manager();
            Offset offset = new Offset();
            byte[] buffer = new byte[220];
            byte[] convert;
            int pokeInParty = 0;
            bool update = false;

            if (inputFile.Length >= 256)
            { 
                for (int i = 0; i < inputFile.Length; i++)
                {
                    if (inputFile[i] == 0x4E && inputFile[i + 1] == 0x19 && inputFile[i + 2] == 0x70 &&
                        inputFile[i + 3] == 0x6F && inputFile[i + 4] == 0x6B && inputFile[i + 5] == 0x65 &&
                        inputFile[i + 6] == 0x70 && inputFile[i + 7] == 0x61 && inputFile[i + 8] == 0x72 &&
                        inputFile[i + 9] == 0x74 && inputFile[i + 10] == 0x79 && inputFile[i + 11] == 0x2E &&
                        inputFile[i + 12] == 0x63)
                    {
                        if (i + 254 <= inputFile.Length)
                        {
                            pokeInParty = hex.ConOneHex(inputFile[i + 30]);
                            i += 34;
                            for (int m = 0; m < pokeInParty && found < 24; m++)
                            {
                                for (int n = 0; n < 220; n++, i++)
                                {
                                    buffer[n] = inputFile[i];
                                }
                                convert = PK5(buffer);
                                arr.UpdateCheck(pokemon, column, found, convert, ref update, 5);
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
            //Ensures that the game that the Pokemon is from is valid for gen 5.
            if (found != 0)
            {
                for(int i = 0; i < found; i++)
                {
                    if(pokemon[i, 95] == 0x00)
                    {
                        pokemon[i, 95] = 0x15;
                    }
                }
            }

            return found;
        }

        //From PKHeX and modified to meet needs of this application needed to get decryption started
        private byte[] PK5(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted45(ref data);
            if (data.Length != PokeCrypto.SIZE_5PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_5PARTY);
            return data;
        }
    }
}
