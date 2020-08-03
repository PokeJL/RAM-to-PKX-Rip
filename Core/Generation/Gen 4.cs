using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace RAM_to_PKX_Rip
{
    class Gen_4
    {
        public Gen_4() { }
        public int Start(byte[,] pokemon, string path, int row, int column)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;
            int found = 0;

            inputFile = fm.OpenFile(path);
            found = SearchPokemon(pokemon, inputFile, row, column);
            
            return found;
        }

        private int SearchPokemon(byte[,] pokemon, byte[] inputFile, int row, int column)
        {
            int found = 0;
            const int size = 127;
            Hex_Conversion hex = new Hex_Conversion();
            Array_Manager arr = new Array_Manager();

            if (inputFile.Length >= column)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        pokemon[i, j] = 0;
                    }
                }

                for (int i = 0; i < (inputFile.Length - size) && found < row; i++)
                {
                    ////Check ball
                    if (hex.ConOneHex(inputFile[i + 127]) < 17 && hex.ConOneHex(inputFile[i + 127]) != 0)
                    {
                        ////Checks level
                        if (hex.ConOneHex(inputFile[i + 52]) < 101)
                        {
                            ////Check OT terminating value
                            if (hex.ConOneHex(inputFile[i + 98]) == 255 && hex.ConOneHex(inputFile[i + 99]) == 255)
                            {
                                ////Check Pokemon name terminating value
                                if (hex.ConOneHex(inputFile[i + 75]) == 255 && hex.ConOneHex(inputFile[i + 74]) == 255)
                                {
                                    ////Item
                                    if (hex.LittleEndian(inputFile, i + 120, 2) < 536)
                                    {
                                        ////Check Species
                                        if (hex.LittleEndian(inputFile, i, 2) < 494 && hex.LittleEndian(inputFile, i, 2) != 0)
                                        {
                                            //Move 1
                                            if (hex.LittleEndian(inputFile, i + 12, 2) < 468 && hex.LittleEndian(inputFile, i + 12, 2) != 0)
                                                {
                                                //Move 2
                                                if (hex.LittleEndian(inputFile, i + 14, 2) < 468)
                                                {
                                                    //Move 3
                                                    if (hex.LittleEndian(inputFile, i + 16, 2) < 468)
                                                    {
                                                        //Move 4
                                                        if (hex.LittleEndian(inputFile, i + 18, 2) < 468)
                                                        {
                                                            //1 != 2 and != 3 and != 4
                                                            if (hex.LittleEndian(inputFile, i + 12, 2) != hex.LittleEndian(inputFile, i + 14, 2) && 
                                                                hex.LittleEndian(inputFile, i + 12, 2) != hex.LittleEndian(inputFile, i + 16, 2) && 
                                                                hex.LittleEndian(inputFile, i + 12, 2) != hex.LittleEndian(inputFile, i + 18, 2))
                                                            {

                                                                //2 != 3 and != 4 OR Moves 2 = 0 and 3 = 0 and 4 = 0
                                                                if ((hex.LittleEndian(inputFile, i + 14, 2) != hex.LittleEndian(inputFile, i + 16, 2) && 
                                                                    hex.LittleEndian(inputFile, i + 14, 2) != hex.LittleEndian(inputFile, i + 18, 2)) == true 
                                                                    || (hex.LittleEndian(inputFile, i + 14, 2) == 0 && 
                                                                    hex.LittleEndian(inputFile, i + 16, 2) == 0 && 
                                                                    hex.LittleEndian(inputFile, i + 18, 2) == 0) == true)
                                                                {

                                                                    //3 != 4
                                                                    if ((hex.LittleEndian(inputFile, i + 16, 2) != hex.LittleEndian(inputFile, i + 18, 2)) == true
                                                                        || (hex.LittleEndian(inputFile, i + 16, 2) == 0 && hex.LittleEndian(inputFile, i + 18, 2) == 0) == true)
                                                                    {
                                                                        //Make sure move 2 is a move if move 3 is a move
                                                                        if (hex.LittleEndian(inputFile, i + 14, 2) == 0 && hex.LittleEndian(inputFile, i + 16, 2) != 0)
                                                                        {
                                                                            //Test failed
                                                                        }
                                                                        else
                                                                        {
                                                                            //Make sure move 3 is a move if move 4 is a move
                                                                            if (hex.LittleEndian(inputFile, i + 16, 2) == 0 && hex.LittleEndian(inputFile, i + 18, 2) != 0)
                                                                            {
                                                                                //Test Failed
                                                                            }
                                                                            else
                                                                            {
                                                                                //Ensures that current buffs of the Pokemon is not past +6
                                                                                if (hex.ConOneHex(inputFile[i + 24]) < 13 && hex.ConOneHex(inputFile[i + 25]) < 13 &&
                                                                                    hex.ConOneHex(inputFile[i + 26]) < 13 && hex.ConOneHex(inputFile[i + 27]) < 13 &&
                                                                                    hex.ConOneHex(inputFile[i + 28]) < 13 && hex.ConOneHex(inputFile[i + 29]) < 13 &&
                                                                                    hex.ConOneHex(inputFile[i + 30]) < 13 && hex.ConOneHex(inputFile[i + 31]) < 13)
                                                                                {
                                                                                    //Valid Pokemon found and Pokemon is extracted.
                                                                                    arr.AddString(pokemon, found, 0, inputFile, i + 104, 3); //PID
                                                                                    arr.AddString(pokemon, found, 8, inputFile, i, 2); //Species
                                                                                    arr.AddString(pokemon, found, 10, inputFile, i + 120, 2); //Item
                                                                                    arr.AddString(pokemon, found, 12, inputFile, i + 116, 2); //ID
                                                                                    arr.AddString(pokemon, found, 14, inputFile, i + 118, 2); //SID
                                                                                    arr.AddString(pokemon, found, 16, inputFile, i + 100, 4); //EXP
                                                                                    pokemon[found, 20] = inputFile[i + 53]; //Friendship
                                                                                    pokemon[found, 21] = inputFile[i + 39]; //Ability
                                                                                    arr.AddString(pokemon, found, 40, inputFile, i + 12, 8); //Moves
                                                                                    arr.AddString(pokemon, found, 48, inputFile, i + 44, 4); //PP
                                                                                    arr.AddString(pokemon, found, 52, inputFile, i + 48, 4); //PP max
                                                                                    arr.AddString(pokemon, found, 56, inputFile, i + 20, 4); //IVs
                                                                                    arr.AddString(pokemon, found, 72, inputFile, i + 54, 22); //Pokemon Name
                                                                                    arr.AddString(pokemon, found, 104, inputFile, i + 84, 16); //OT name
                                                                                    arr.AddString(pokemon, found, 123, inputFile, i + 36, 3); //Met Date
                                                                                    pokemon[found, 131] = inputFile[i + 127]; //Ball

                                                                                    found++;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }                
                                                        }
                                                    }                       
                                                }
                                            }   
                                        }
                                    }
                                }
                            }
                        }
                    }  
                }
            }
            return found;
        }
    }
}

