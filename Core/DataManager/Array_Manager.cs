using RAM_to_PKX_Rip.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip
{
    class Array_Manager
    {
        public Array_Manager() { }

        public void Array1Dto2D(byte[,] a2d, int row, int column, byte[] a1d)
        {
            for (int i = 0; i < column; i++)
            {
                a2d[row, i] = a1d[i];
            }
        }

        public void ArrayPart(byte[] a1, int offset1, int size, byte[] a1d, int offset2)
        {
            for (int i = offset1; i < offset1 + size; i++, offset2++)
            {
                a1[i] = a1d[offset2];
            }
        }

        public void UpdateCheck(byte[,] pokemon, int column, int found, byte[] convert, ref bool update, int gen)
        {
            Data_Conversion hex = new Data_Conversion();
            Offset offset = new Offset();

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

            if (found != 0)
            {
                for (int f = 0; f < found && update == false; f++)
                {
                    if(hex.LittleEndian2D(pokemon, f, PID, sizePID) == hex.LittleEndian(convert, PID, sizePID) &&
                        hex.LittleEndian2D(pokemon, f, dex, sizeDex) == hex.LittleEndian(convert, dex, sizeDex) &&
                        hex.LittleEndian2D(pokemon, f, ID, sizeID) == hex.LittleEndian(convert, ID, sizeID) &&
                        hex.LittleEndian2D(pokemon, f, SID, sizeSID) == hex.LittleEndian(convert, SID, sizeSID) &&
                        hex.LittleEndian2D(pokemon, f, item, sizeItem) == hex.LittleEndian(convert, item, sizeItem) && //May cause issue if item is consumed
                        hex.LittleEndian2D(pokemon, f, friendship, sizeFriendship) == hex.LittleEndian(convert, friendship, sizeFriendship) && //May cause issue if Pokemon fraints
                        hex.LittleEndian2D(pokemon, f, ability, sizeAbility) == hex.LittleEndian(convert, ability, sizeAbility) &&
                        hex.LittleEndian2D(pokemon, f, HPEV, sizeHPEV) == hex.LittleEndian(convert, HPEV, sizeHPEV) &&
                        hex.LittleEndian2D(pokemon, f, attEV, sizeAttEV) == hex.LittleEndian(convert, attEV, sizeAttEV) &&
                        hex.LittleEndian2D(pokemon, f, defEV, sizeDefEV) == hex.LittleEndian(convert, defEV, sizeDefEV) &&
                        hex.LittleEndian2D(pokemon, f, spAttEV, sizeSpAttEV) == hex.LittleEndian(convert, spAttEV, sizeSpAttEV) &&
                        hex.LittleEndian2D(pokemon, f, spDefEV, sizeSpDefEV) == hex.LittleEndian(convert, spDefEV, sizeSpDefEV) &&
                        hex.LittleEndian2D(pokemon, f, speedEV, sizeSpeed) == hex.LittleEndian(convert, speedEV, sizeSpeed) &&
                        hex.LittleEndian2D(pokemon, f, cool, sizeCool) == hex.LittleEndian(convert, cool, sizeCool) &&
                        hex.LittleEndian2D(pokemon, f, beauty, sizeBeauty) == hex.LittleEndian(convert, beauty, sizeBeauty) &&
                        hex.LittleEndian2D(pokemon, f, cute, sizeCute) == hex.LittleEndian(convert, cute, sizeCute) &&
                        hex.LittleEndian2D(pokemon, f, smart, sizeSmart) == hex.LittleEndian(convert, smart, sizeSmart) &&
                        hex.LittleEndian2D(pokemon, f, tough, sizeTough) == hex.LittleEndian(convert, tough, sizeTough) &&
                        hex.LittleEndian2D(pokemon, f, sheen, sizeSheen) == hex.LittleEndian(convert, sheen, sizeSheen) &&
                        hex.LittleEndian2D(pokemon, f, m1, sizeM1) == hex.LittleEndian(convert, m1, sizeM1) &&
                        hex.LittleEndian2D(pokemon, f, m2, sizeM2) == hex.LittleEndian(convert, m2, sizeM2) &&
                        hex.LittleEndian2D(pokemon, f, m3, sizeM3) == hex.LittleEndian(convert, m3, sizeM3) &&
                        hex.LittleEndian2D(pokemon, f, m4, sizeM4) == hex.LittleEndian(convert, m4, sizeM4) &&
                        hex.LittleEndian2D(pokemon, f, nature, sizeNature) == hex.LittleEndian(convert, nature, sizeNature) &&
                        hex.LittleEndian2D(pokemon, f, encryption, sizeEncryption) == hex.LittleEndian(convert, encryption, sizeEncryption) &&
                        hex.LittleEndian2D(pokemon, f, EXP, sizeEXP) == hex.LittleEndian(convert, EXP, sizeEXP)
                        )
                    {
                        update = true;
                    }
                }
            }
        }

        public void AddPart1Dto2D(byte[,] pokemon, int row, int start1, byte[] data, int start2, int length)
        {
            for (int i = 0; i < length; i++)
            {
                pokemon[row, start1 + i] = data[start2 + i];
            }
        }
    }
}
