using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace RAM_to_PKX_Rip.Core.Resource
{
    class Offset
    {
        public Offset() { }

        public void Offsets3Later(ref int PID, ref int dex, ref int item, ref int ID, ref int SID, ref int EXP, ref int friendship,
                                ref int ability, ref int HPEV, ref int attEV, ref int defEV, ref int speed, ref int spAttEV, ref int spDefEV,
                                ref int cool, ref int beauty, ref int cute, ref int smart, ref int tough, ref int sheen, ref int m1, ref int m2,
                                ref int m3, ref int m4, ref int IV, ref int nature, ref int sizePID, ref int sizeDex, ref int sizeItem,
                                ref int sizeID, ref int sizeSID, ref int sizeEXP, ref int sizeFriendship, ref int sizeAbility,
                                ref int sizeHPEV, ref int sizeAttEV, ref int sizeDefEV, ref int sizeSpeed, ref int sizeSpAttEV,
                                ref int sizeSpDefEV, ref int sizeCool, ref int sizeBeauty, ref int sizeCute, ref int sizeSmart,
                                ref int sizeTough, ref int sizeSheen, ref int sizeM1, ref int sizeM2, ref int sizeM3, ref int sizeM4,
                                ref int sizeIV, ref int sizeNature, ref int encryption, ref int sizeEncryption, int gen)
        {
            if (gen == 3)
            {
                PID = 0;
                sizePID = 4;
                dex = 32;
                sizeDex = 2;
                item = 34;
                sizeItem = 2;
                ID = 4;
                sizeID = 2;
                SID = 6;
                sizeSID = 2;
                EXP = 36;
                sizeEXP = 4;
                friendship = 41;
                sizeFriendship = 1;
                ability = 0; //not clear in the structure
                sizeAbility = 1;
                HPEV = 56;
                sizeHPEV = 1;
                attEV = 57;
                sizeAttEV = 1;
                defEV = 58;
                sizeDefEV = 1;
                speed = 59;
                sizeSpeed = 1;
                spAttEV = 60;
                sizeSpAttEV = 1;
                spDefEV = 61;
                sizeSpDefEV = 1;
                cool = 62;
                sizeCool = 1;
                beauty = 63;
                sizeBeauty = 1;
                cute = 64;
                sizeCute = 1;
                smart = 65;
                sizeSmart = 1;
                tough = 66;
                sizeTough = 1;
                sheen = 67;
                sizeSheen = 1;
                m1 = 44;
                sizeM1 = 2;
                m2 = 46;
                sizeM2 = 2;
                m3 = 48;
                sizeM3 = 2;
                m4 = 50;
                sizeM4 = 2;
                IV = 72;
                sizeIV = 4;
                nature = 0; //not clear in structure
                sizeNature = 1;
                encryption = 0; //Value not used in generation but set here so I can reuse code
                sizeEncryption = 1;
            }

            if (gen == 4 || gen == 5)
            {
                PID = 0;
                sizePID = 4;
                dex = 8;
                sizeDex = 2;
                item = 10;
                sizeItem = 2;
                ID = 12;
                sizeID = 2;
                SID = 14;
                sizeSID = 2;
                EXP = 16;
                sizeEXP = 4;
                friendship = 20;
                sizeFriendship = 1;
                ability = 21;
                sizeAbility = 1;
                HPEV = 24;
                sizeHPEV = 1;
                attEV = 25;
                sizeAttEV = 1;
                defEV = 26;
                sizeDefEV = 1;
                speed = 27;
                sizeSpeed = 1;
                spAttEV = 28;
                sizeSpAttEV = 1;
                spDefEV = 29;
                sizeSpDefEV = 1;
                cool = 30;
                sizeCool = 1;
                beauty = 31;
                sizeBeauty = 1;
                cute = 32;
                sizeCute = 1;
                smart = 33;
                sizeSmart = 1;
                tough = 34;
                sizeTough = 1;
                sheen = 35;
                sizeSheen = 1;
                m1 = 40;
                sizeM1 = 2;
                m2 = 42;
                sizeM2 = 2;
                m3 = 44;
                sizeM3 = 2;
                m4 = 46;
                sizeM4 = 2;
                IV = 40;
                sizeIV = 4;
                if (gen == 4)
                {
                    //nature in gen 4 is not stored as its own value so just check first value of array
                    nature = 0;
                    sizeNature = 1;
                }
                else
                {
                    nature = 65;
                    sizeNature = 1;
                }
                encryption = 0; //Value not used in generation but set here so I can reuse code
                sizeEncryption = 1;
            }
            
            if (gen == 6)
            {
                PID = 24;
                sizePID = 4;
                dex = 8;
                sizeDex = 2;
                item = 10;
                sizeItem = 2;
                ID = 12;
                sizeID = 2;
                SID = 14;
                sizeSID = 2;
                EXP = 16;
                sizeEXP = 4;
                friendship = 20;
                sizeFriendship = 1;
                ability = 20;
                sizeAbility = 1;
                HPEV = 30;
                sizeHPEV = 1;
                attEV = 31;
                sizeAttEV = 1;
                defEV = 32;
                sizeDefEV = 1;
                speed = 33;
                sizeSpeed = 1;
                spAttEV = 34;
                sizeSpAttEV = 1;
                spDefEV = 35;
                sizeSpDefEV = 1;
                cool = 36;
                sizeCool = 1;
                beauty = 37;
                sizeBeauty = 1;
                cute = 38;
                sizeCute = 1;
                smart = 39;
                sizeSmart = 1;
                tough = 40;
                sizeTough = 1;
                sheen = 41;
                sizeSheen = 1;
                m1 = 90;
                sizeM1 = 2;
                m2 = 92;
                sizeM2 = 2;
                m3 = 94;
                sizeM3 = 2;
                m4 = 96;
                sizeM4 = 2;
                IV = 116;
                sizeIV = 4;
                nature = 28;
                sizeNature = 1;
                encryption = 0;
                sizeEncryption = 4;
            }
        }
    }
}
