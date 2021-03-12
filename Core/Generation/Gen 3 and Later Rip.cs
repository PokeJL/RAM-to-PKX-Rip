using RAM_to_PKX_Rip.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAM_to_PKX_Rip.Core.Generation
{
    class Gen_3_and_Later_Rip
    {
        public Gen_3_and_Later_Rip() { }
        public delegate void MaxProgressMethodInvoker(int amount);
        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();
        public event MaxProgressMethodInvoker MP;
        public event CurrentProgressMethodInvoker CP;
        public event EndThread End;

        public int Start(byte[,] pokemon, string path, int row, int column, int size, int gen)
        {
            File_Manager fm = new File_Manager();
            byte[] inputFile;
            int found;

            inputFile = fm.OpenFile(path);
            MP(inputFile.Length);

            found = SearchPokemon(pokemon, inputFile, row, column, size, gen);

            return found;
        }

        private int SearchPokemon(byte[,] pokemon, byte[] inputFile, int row, int column, int size, int gen)
        {
            Offset offset = new Offset();
            Data_Conversion hex = new Data_Conversion();
            Array_Manager arr = new Array_Manager();
            Bit_Check bit = new Bit_Check();
            Dex_Conversion dexCon = new Dex_Conversion();
            byte[] buffer = new byte[size];
            byte[] convert;
            int found = 0;
            bool update = false;
            int currentDexNum;
            int updateTime;

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
            int speedEV = 0;
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

            int numOfPokeInGen = 0;
            int numOfMovesInGen = 0;
            int pkrus = 0;
            int checksum = 0;
            int checksumCalcDataStart = 0;

            offset.Offsets3Later(ref PID, ref dex, ref item, ref ID, ref SID, ref EXP, ref friendship,
                                ref ability, ref HPEV, ref attEV, ref defEV, ref speedEV, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref m1, ref m2,
                                ref m3, ref m4, ref IV, ref nature, ref sizePID, ref sizeDex, ref sizeItem,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeed, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeM1, ref sizeM2, ref sizeM3, ref sizeM4,
                                ref sizeIV, ref sizeNature, ref encryption, ref sizeEncryption, ref numOfPokeInGen,
                                ref numOfMovesInGen, ref pkrus, ref checksum, ref checksumCalcDataStart, gen);

            if (inputFile.Length >= size)
            {
                updateTime = UpdateBar(inputFile.Length);
                for (int i = 0; i < inputFile.Length && found < row; i++)
                {
                    //Ends the rip process
                    if (End() == true)
                    {
                        found = 0;
                        break;
                    }
                    if (i + size <= inputFile.Length && hex.LittleEndian(inputFile, i + checksum, 2) != 0)
                    {
                        for (int n = 0; n < size; n++)
                        {
                            buffer[n] = inputFile[i + n];
                        }

                        if (gen == 3)
                            convert = PK3(buffer);
                        else if (gen == 4)
                            convert = PK4(buffer);
                        else if (gen == 5)
                            convert = PK5(buffer);
                        else if (gen == 6)
                            convert = PK6(buffer);
                        else
                            break;

                        if (gen == 3)
                            currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(convert, dex, sizeDex));
                        else
                            currentDexNum = hex.LittleEndian(convert, dex, sizeDex);

                        if (hex.LittleEndian(convert, m1, sizeM1) != 0 && //Move 1 has an actual move
                        hex.LittleEndian(convert, m1, sizeM1) <= numOfMovesInGen && //Move 1 is a valid move
                        hex.LittleEndian(convert, m2, sizeM2) <= numOfMovesInGen && //Move 2 is a valid move
                        hex.LittleEndian(convert, m3, sizeM3) <= numOfMovesInGen && //Move 3 is a valid move
                        hex.LittleEndian(convert, m4, sizeM4) <= numOfMovesInGen && //Move 4 is a valid move
                        currentDexNum <= numOfPokeInGen && //Ensures the species is not outside the valid range
                        hex.LittleEndian(convert, dex, sizeDex) != 0 && //Not a glitch Pokemon
                         hex.LittleEndian(convert, m1, sizeM1) != hex.LittleEndian(convert, m2, sizeM2) && //Move 1 != Move 2
                        hex.LittleEndian(convert, m1, sizeM1) != hex.LittleEndian(convert, m3, sizeM3) && //Move 1 != Move 3
                        hex.LittleEndian(convert, m1, sizeM1) != hex.LittleEndian(convert, m4, sizeM4) && //Move 1 != Move 4
                        ((hex.LittleEndian(convert, m2, sizeM2) != hex.LittleEndian(convert, m3, sizeM3) &&
                        hex.LittleEndian(convert, m2, sizeM2) != hex.LittleEndian(convert, m4, sizeM4)) == true ||
                        (hex.LittleEndian(convert, m2, sizeM2) == 0 &&
                        hex.LittleEndian(convert, m3, sizeM3) == 0 &&
                        hex.LittleEndian(convert, m4, sizeM4) == 0) == true) && //2 != 3 and != 4 OR Moves 2 = 0 and 3 = 0 and 4 = 0
                        ((hex.LittleEndian(convert, m3, sizeM3) != hex.LittleEndian(convert, m4, sizeM4)) == true ||
                        (hex.LittleEndian(convert, m3, sizeM3) == 0 &&
                        hex.LittleEndian(convert, m4, sizeM4) == 0) == true) && //3 != 4
                        (hex.LittleEndian(convert, m2, sizeM2) == 0 &&
                        hex.LittleEndian(convert, m3, sizeM3) != 0 &&
                        hex.LittleEndian(convert, m4, sizeM4) != 0) == false && //Make sure move 2 is a move if move 3 and 4 is a move
                        (hex.LittleEndian(convert, m3, sizeM3) == 0 && hex.LittleEndian(convert, m4, sizeM4) != 0) == false && //Make sure move 3 is a move if move 4 is a move
                        (hex.LittleEndian(convert, HPEV, sizeHPEV) +
                        hex.LittleEndian(convert, attEV, sizeAttEV) +
                        hex.LittleEndian(convert, defEV, sizeDefEV) +
                        hex.LittleEndian(convert, speedEV, sizeSpeed) +
                        hex.LittleEndian(convert, spAttEV, sizeSpAttEV) +
                        hex.LittleEndian(convert, spDefEV, sizeSpDefEV)) <= 510 && // EV total does not exceed 510
                        bit.Pokerus(convert[pkrus]) && //Makes sure Pokerus is valid
                        bit.IV(convert, IV) && //Check valid IVs
                        bit.Checksum(convert, checksum, checksumCalcDataStart, column) //Makes sure the checksum is correct
                        )
                        {
                            arr.UpdateCheck(pokemon, column, found, convert, ref update, gen);
                            if (update == false)
                            {
                                arr.Array1Dto2D(pokemon, found, column, convert);
                                found++;
                            }
                            update = false;
                        }
                    }
                    //Update Progress Bar Event
                    if (i % updateTime == 0)
                    {
                        CP(i);
                    }
                    else if (i + 1 == inputFile.Length)
                    {
                        CP(i);
                    }
                }
            }
            //Ensures that the game that the Pokemon is from is valid for gen 5.
            if (found != 0 && gen == 5)
            {
                for (int i = 0; i < found; i++)
                {
                    if (pokemon[i, 95] == 0x00)
                    {
                        pokemon[i, 95] = 0x15;
                    }
                }
            }
            return found;
        }
        //163 allows for update intervals that don't slow down the process by delaying the update by a bit
        private int UpdateBar(int size)
        {
            int timing;
            if (size <= 163)
                timing = size;
            else
                timing = (int)(size / 163);
            return timing;
        }

        //From PKHeX and modified to meet needs of this application needed to get decryption started
        private byte[] PK3(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted3(ref data);
            if (data.Length != PokeCrypto.SIZE_3PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_3PARTY);
            return data;
        }

        private byte[] PK4(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted45(ref data);
            if (data.Length != PokeCrypto.SIZE_4PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_4PARTY);
            return data;
        }

        private byte[] PK5(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted45(ref data);
            if (data.Length != PokeCrypto.SIZE_5PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_5PARTY);
            return data;
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
