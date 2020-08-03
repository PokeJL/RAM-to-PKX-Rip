using RAM_to_PKX_Rip.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip.Core.Generation
{
    class Gen_3
    {
        public Gen_3() { }

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
            Offset offset = new Offset();
            Hex_Conversion hex = new Hex_Conversion();
            Array_Manager arr = new Array_Manager();
            int found = 0;
            byte[] temp = new byte[column];

            //Offset data
            int PID = 0;
            int sizePID = 0;
            int dex = 0;
            int sizeDex = 0;
            int item = 0;
            int sizeItem = 0;
            int ID = 0;
            int sizeID = 0;
            int SID = 0;
            int sizeSID = 0;
            int EXP = 0;
            int sizeEXP = 0;
            int friendship = 0;
            int sizeFriendship = 0;
            int ability = 0;
            int sizeAbility = 0;
            int HPEV = 0;
            int sizeHPEV = 0;
            int attEV = 0;
            int sizeAttEV = 0;
            int defEV = 0;
            int sizeDefEV = 0;
            int speed = 0;
            int sizeSpeed = 0;
            int spAttEV = 0;
            int sizeSpAttEV = 0;
            int spDefEV = 0;
            int sizeSpDefEV = 0;
            int cool = 0;
            int sizeCool = 0;
            int beauty = 0;
            int sizeBeauty = 0;
            int cute = 0;
            int sizeCute = 0;
            int smart = 0;
            int sizeSmart = 0;
            int tough = 0;
            int sizeTough = 0;
            int sheen = 0;
            int sizeSheen = 0;
            int m1 = 0;
            int sizeM1 = 0;
            int m2 = 0;
            int sizeM2 = 0;
            int m3 = 0;
            int sizeM3 = 0;
            int m4 = 0;
            int sizeM4 = 0;
            int IV = 0;
            int sizeIV = 0;
            int nature = 0;
            int sizeNature = 0;
            int encryption = 0;
            int sizeEncryption = 0;

            offset.Offsets3Later(ref PID, ref dex, ref item, ref ID, ref SID, ref EXP, ref friendship,
                                ref ability, ref HPEV, ref attEV, ref defEV, ref speed, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref m1, ref m2,
                                ref m3, ref m4, ref IV, ref nature, ref sizePID, ref sizeDex, ref sizeItem,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeed, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeM1, ref sizeM2, ref sizeM3, ref sizeM4,
                                ref sizeIV, ref sizeNature, ref encryption, ref sizeEncryption, 3);

            if (inputFile.Length > column)
            {
                for(int i = 0; i < inputFile.Length - 80 && found != 24; i++)
                {
                    if (hex.LittleEndian(inputFile, i + 32, sizeM1) != 0 && //Move 1 has an actual move
                        hex.LittleEndian(inputFile, i + 32, sizeM1) < 355 && //Move 1 is a valid move
                        hex.LittleEndian(inputFile, i + 34, sizeM2) < 355 && //Move 2 is a valid move
                        hex.LittleEndian(inputFile, i + 36, sizeM3) < 355 && //Move 3 is a valid move
                        hex.LittleEndian(inputFile, i + 38, sizeM4) < 355 && //Move 4 is a valid move
                        hex.LittleEndian(inputFile, i + 56, sizeDex) < 387 && //Valid Pokemon speicies
                        hex.LittleEndian(inputFile, i + 56, sizeDex) != 0 && //Not a glitch Pokemon
                        hex.LittleEndian(inputFile, i + 58, sizeItem) < 339 && //Held item does not fall out of range
                        hex.LittleEndian(inputFile, i + 58, sizeItem) != 72 && //Held item does not have an index of 72
                        hex.LittleEndian(inputFile, i + 58, sizeItem) != 82 //&& //Held item does not have an index of 82
                        )
                    {
                        if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 52 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 62)
                        {
                            if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 87 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 92)
                            {
                                if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 99 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 102)
                                {
                                    if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 112 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 120)
                                    {
                                        if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 176 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 178)
                                        {
                                            if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 226 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 253)
                                            {
                                                if (hex.LittleEndian(inputFile, i + 58, sizeItem) > 259 || hex.LittleEndian(inputFile, i + 58, sizeItem) < 288)
                                                {
                                                    //1 != 2 and != 3 and != 4
                                                    if (hex.LittleEndian(inputFile, i + 32, 2) != hex.LittleEndian(inputFile, i + 34, 2) &&
                                                        hex.LittleEndian(inputFile, i + 32, 2) != hex.LittleEndian(inputFile, i + 36, 2) &&
                                                        hex.LittleEndian(inputFile, i + 32, 2) != hex.LittleEndian(inputFile, i + 38, 2))
                                                    {

                                                        //2 != 3 and != 4 OR Moves 2 = 0 and 3 = 0 and 4 = 0
                                                        if ((hex.LittleEndian(inputFile, i + 34, 2) != hex.LittleEndian(inputFile, i + 36, 2) &&
                                                            hex.LittleEndian(inputFile, i + 34, 2) != hex.LittleEndian(inputFile, i + 38, 2)) == true
                                                            || (hex.LittleEndian(inputFile, i + 34, 2) == 0 &&
                                                            hex.LittleEndian(inputFile, i + 36, 2) == 0 &&
                                                            hex.LittleEndian(inputFile, i + 38, 2) == 0) == true)
                                                        {

                                                            //3 != 4
                                                            if ((hex.LittleEndian(inputFile, i + 36, 2) != hex.LittleEndian(inputFile, i + 38, 2)) == true
                                                                || (hex.LittleEndian(inputFile, i + 36, 2) == 0 && hex.LittleEndian(inputFile, i + 38, 2) == 0) == true)
                                                            {
                                                                //Make sure move 2 is a move if move 3 and 4 is a move
                                                                if (hex.LittleEndian(inputFile, i + 34, 2) == 0 && hex.LittleEndian(inputFile, i + 36, 2) != 0 && hex.LittleEndian(inputFile, i + 38, 2) != 0)
                                                                {
                                                                    //Test failed
                                                                }
                                                                else
                                                                {
                                                                    //Make sure move 3 is a move if move 4 is a move
                                                                    if (hex.LittleEndian(inputFile, i + 36, 2) == 0 && hex.LittleEndian(inputFile, i + 38, 2) != 0)
                                                                    {
                                                                        //Test Failed
                                                                    }
                                                                    else
                                                                    {
                                                                        arr.ArrayPart(temp, PID, sizePID, inputFile, i); //PID
                                                                        arr.ArrayPart(temp, ID, sizeID, inputFile, i + 4); //ID
                                                                        arr.ArrayPart(temp, SID, sizeSID, inputFile, i + 6); //SID
                                                                        arr.ArrayPart(temp, 8, 10, inputFile, i + 8); //Pokemon name
                                                                        arr.ArrayPart(temp, 18, 2, inputFile, i + 18); //Language
                                                                        arr.ArrayPart(temp, 20, 7, inputFile, i + 20); //OT
                                                                        temp[27] = inputFile[i + 27]; //Markings
                                                                        arr.ArrayPart(temp, 30, 2, inputFile, i + 30); //???
                                                                        arr.ArrayPart(temp, dex, sizeDex, inputFile, i + 56); //Pokemon species
                                                                        arr.ArrayPart(temp, item, sizeItem, inputFile, i + 58); //Item
                                                                        arr.ArrayPart(temp, EXP, sizeEXP, inputFile, i + 60); //EXP
                                                                        temp[40] = inputFile[i + 64]; //PP Max
                                                                        temp[41] = inputFile[i + 65]; //Friendship
                                                                        arr.ArrayPart(temp, 42, 2, inputFile, i + 66); //???
                                                                        arr.ArrayPart(temp, m1, sizeM1 + sizeM2 + sizeM3 + sizeM4 + 4, inputFile, i + 32); //Move 1 to 4 and their PP Max
                                                                        arr.ArrayPart(temp, HPEV, sizeHPEV + sizeAttEV + sizeDefEV + sizeSpeed + sizeSpAttEV + sizeSpDefEV, inputFile, i + 68); //EV points
                                                                        arr.ArrayPart(temp, cool, sizeCool + sizeBeauty + sizeCute + sizeSmart + sizeTough + sizeSheen, inputFile, i + 74); //Contest stats
                                                                        arr.ArrayPart(temp, 68, 12, inputFile, i + 44); //Met data, IVs, Ribbons
                                                                        arr.Array1Dto2D(pokemon, found, column, temp);
                                                                        ushort check = PokeCrypto.GetCHK3(temp); //Makes the checksum
                                                                        byte[] sumArray = BitConverter.GetBytes(check);
                                                                        arr.AddString(pokemon, found, 28, sumArray, 0, 2);
                                                                        found++;
                                                                        i += 80;
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
