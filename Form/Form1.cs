using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Drawing.Imaging;
using RAM_to_PKX_Rip.Core.Generation;

namespace RAM_to_PKX_Rip
{
    public partial class Form1 : Form
    {
        //Needed values to rip Pokemon
        public
        byte[,] pokemon;
        bool fileAdded = false;
        string path = " ";
        int row;
        int column;
        int found = 0;
        int speciesIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    OpenFileTXB.Text = string.Format("{0}", openFileDialog1.FileName); //Show file path in textbox
                    fileAdded = true;
                    path = string.Format("{0}", openFileDialog1.FileName);
                    FileInfo fi = new FileInfo(path);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Rip_Click(object sender, EventArgs e)
        {
            Save1.Enabled = false;
            Name1.Enabled = false;
            Save2.Enabled = false;
            Name2.Enabled = false;
            Save3.Enabled = false;
            Name3.Enabled = false;
            Save4.Enabled = false;
            Name4.Enabled = false;
            Save5.Enabled = false;
            Name5.Enabled = false;
            Save6.Enabled = false;
            Name6.Enabled = false;
            Save7.Enabled = false;
            Name7.Enabled = false;
            Save8.Enabled = false;
            Name8.Enabled = false;
            Save9.Enabled = false;
            Name9.Enabled = false;
            Save10.Enabled = false;
            Name10.Enabled = false;
            Save11.Enabled = false;
            Name11.Enabled = false;
            Save12.Enabled = false;
            Name12.Enabled = false;
            Save13.Enabled = false;
            Name13.Enabled = false;
            Save14.Enabled = false;
            Name14.Enabled = false;
            Save15.Enabled = false;
            Name15.Enabled = false;
            Save16.Enabled = false;
            Name16.Enabled = false;
            Save17.Enabled = false;
            Name17.Enabled = false;
            Save18.Enabled = false;
            Name18.Enabled = false;
            Save19.Enabled = false;
            Name19.Enabled = false;
            Save20.Enabled = false;
            Name20.Enabled = false;
            Save21.Enabled = false;
            Name21.Enabled = false;
            Save22.Enabled = false;
            Name22.Enabled = false;
            Save23.Enabled = false;
            Name23.Enabled = false;
            Save24.Enabled = false;
            Name24.Enabled = false;

            if (fileAdded == true)
            {
                row = 24;
                if (Gen3.Checked == true)
                {
                    column = 80;
                    pokemon = new byte[row, column];
                    speciesIndex = 32;
                }
                if (Gen4.Checked == true || Gen5.Checked == true)
                {
                    column = 136;
                    pokemon = new byte[row, column];
                    speciesIndex = 8;
                }
                if (Gen6.Checked == true)
                {
                    column = 232;
                    pokemon = new byte[row, column];
                    speciesIndex = 8;
                }

                if (Gen3.Checked == true)
                {
                    Gen_3 rip3 = new Gen_3();
                    found = rip3.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), row, column);
                }
                if (Gen4.Checked == true)
                {
                    Gen_4 rip4 = new Gen_4();
                    found = rip4.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), row, column);
                }
                if (Gen5.Checked == true)
                {
                    Gen_5 rip5 = new Gen_5();
                    found  = rip5.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), column);
                }
                if (Gen6.Checked == true)
                {
                    Gen_6 rip6 = new Gen_6();
                    found = rip6.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), column);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(found.ToString() + " Pokemon found.");

            if (found != 0)
            {
                Hex_Conversion hex = new Hex_Conversion();
                if(1<=found)
                {
                    Save1.Enabled = true;
                    Name1.Enabled = true;
                    Name1.Text = hex.LittleEndian2D(pokemon, 0, speciesIndex, 2).ToString();
                }
                if (2 <= found)
                {
                    Save2.Enabled = true;
                    Name2.Enabled = true;
                    Name2.Text = hex.LittleEndian2D(pokemon, 1, speciesIndex, 2).ToString();
                }
                if (3 <= found)
                {
                    Save3.Enabled = true;
                    Name3.Enabled = true;
                    Name3.Text = hex.LittleEndian2D(pokemon, 2, speciesIndex, 2).ToString();
                }
                if (4 <= found)
                {
                    Save4.Enabled = true;
                    Name4.Enabled = true;
                    Name4.Text = hex.LittleEndian2D(pokemon, 3, speciesIndex, 2).ToString();
                }
                if (5 <= found)
                {
                    Save5.Enabled = true;
                    Name5.Enabled = true;
                    Name5.Text = hex.LittleEndian2D(pokemon, 4, speciesIndex, 2).ToString();
                }
                if (6 <= found)
                {
                    Save6.Enabled = true;
                    Name6.Enabled = true;
                    Name6.Text = hex.LittleEndian2D(pokemon, 5, speciesIndex, 2).ToString();
                }
                if (7 <= found)
                {
                    Save7.Enabled = true;
                    Name7.Enabled = true;
                    Name7.Text = hex.LittleEndian2D(pokemon, 6, speciesIndex, 2).ToString();
                }
                if (8 <= found)
                {
                    Save8.Enabled = true;
                    Name8.Enabled = true;
                    Name8.Text = hex.LittleEndian2D(pokemon, 7, speciesIndex, 2).ToString();
                }
                if (9 <= found)
                {
                    Save9.Enabled = true;
                    Name9.Enabled = true;
                    Name9.Text = hex.LittleEndian2D(pokemon, 8, speciesIndex, 2).ToString();
                }
                if (10 <= found)
                {
                    Save10.Enabled = true;
                    Name10.Enabled = true;
                    Name10.Text = hex.LittleEndian2D(pokemon, 9, speciesIndex, 2).ToString();
                }
                if (11 <= found)
                {
                    Save11.Enabled = true;
                    Name11.Enabled = true;
                    Name11.Text = hex.LittleEndian2D(pokemon, 10, speciesIndex, 2).ToString();
                }
                if (12 <= found)
                {
                    Save12.Enabled = true;
                    Name12.Enabled = true;
                    Name12.Text = hex.LittleEndian2D(pokemon, 11, speciesIndex, 2).ToString();
                }
                if (13 <= found)
                {
                    Save13.Enabled = true;
                    Name13.Enabled = true;
                    Name13.Text = hex.LittleEndian2D(pokemon, 12, speciesIndex, 2).ToString();
                }
                if (14 <= found)
                {
                    Save14.Enabled = true;
                    Name14.Enabled = true;
                    Name14.Text = hex.LittleEndian2D(pokemon, 13, speciesIndex, 2).ToString();
                }
                if (15 <= found)
                {
                    Save15.Enabled = true;
                    Name15.Enabled = true;
                    Name15.Text = hex.LittleEndian2D(pokemon, 14, speciesIndex, 2).ToString();
                }
                if (16 <= found)
                {
                    Save16.Enabled = true;
                    Name16.Enabled = true;
                    Name16.Text = hex.LittleEndian2D(pokemon, 15, speciesIndex, 2).ToString();
                }
                if (17 <= found)
                {
                    Save17.Enabled = true;
                    Name17.Enabled = true;
                    Name17.Text = hex.LittleEndian2D(pokemon, 16, speciesIndex, 2).ToString();
                }
                if (18 <= found)
                {
                    Save18.Enabled = true;
                    Name18.Enabled = true;
                    Name18.Text = hex.LittleEndian2D(pokemon, 17, speciesIndex, 2).ToString();
                }
                if (19 <= found)
                {
                    Save19.Enabled = true;
                    Name19.Enabled = true;
                    Name19.Text = hex.LittleEndian2D(pokemon, 18, speciesIndex, 2).ToString();
                }
                if (20 <= found)
                {
                    Save20.Enabled = true;
                    Name20.Enabled = true;
                    Name20.Text = hex.LittleEndian2D(pokemon, 19, speciesIndex, 2).ToString();
                }
                if (21 <= found)
                {
                    Save21.Enabled = true;
                    Name21.Enabled = true;
                    Name21.Text = hex.LittleEndian2D(pokemon, 20, speciesIndex, 2).ToString();
                }
                if (22 <= found)
                {
                    Save22.Enabled = true;
                    Name22.Enabled = true;
                    Name22.Text = hex.LittleEndian2D(pokemon, 21, speciesIndex, 2).ToString();
                }
                if (23 <= found)
                {
                    Save23.Enabled = true;
                    Name23.Enabled = true;
                    Name23.Text = hex.LittleEndian2D(pokemon, 22, speciesIndex, 2).ToString();
                }
                if (24 <= found)
                {
                    Save24.Enabled = true;
                    Name24.Enabled = true;
                    Name24.Text = hex.LittleEndian2D(pokemon, 23, speciesIndex, 2).ToString();
                }
            }
        }

        private void SaveDialog(int slot)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (Gen3.Checked == true)
            {
                saveFileDialog1.Filter = "PK3|*.pk3";
            }
            if (Gen4.Checked == true)
            {
                saveFileDialog1.Filter = "PK4|*.pk4";
            }
            if (Gen5.Checked == true)
            {
                saveFileDialog1.Filter = "PK5|*.pk5";
            }
            if (Gen6.Checked == true)
            {
                saveFileDialog1.Filter = "PK6|*.pk6";
            }

            saveFileDialog1.Title = "Save Pokemon";
            saveFileDialog1.ShowDialog();
            File_Manager fm = new File_Manager();

            if (saveFileDialog1.FileName != "")
            {
                byte[] saveData = new byte[column];
                for (int i = 0; i < column; i++)
                {
                    saveData[i] = pokemon[slot - 1, i];
                }

                fm.WriteFile(string.Format("{0}", saveFileDialog1.FileName), saveData);
            }
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            SaveDialog(1);
        }

        private void Save2_Click(object sender, EventArgs e)
        {
            SaveDialog(2);
        }

        private void Save3_Click(object sender, EventArgs e)
        {
            SaveDialog(3);
        }

        private void Save4_Click(object sender, EventArgs e)
        {
            SaveDialog(4);
        }

        private void Save5_Click(object sender, EventArgs e)
        {
            SaveDialog(5);
        }

        private void Save6_Click(object sender, EventArgs e)
        {
            SaveDialog(6);
        }

        private void Save7_Click(object sender, EventArgs e)
        {
            SaveDialog(7);
        }

        private void Save8_Click(object sender, EventArgs e)
        {
            SaveDialog(8);
        }

        private void Save9_Click(object sender, EventArgs e)
        {
            SaveDialog(9);
        }

        private void Save10_Click(object sender, EventArgs e)
        {
            SaveDialog(10);
        }

        private void Save11_Click(object sender, EventArgs e)
        {
            SaveDialog(11);
        }

        private void Save12_Click(object sender, EventArgs e)
        {
            SaveDialog(12);
        }

        private void Save13_Click(object sender, EventArgs e)
        {
            SaveDialog(13);
        }

        private void Save14_Click(object sender, EventArgs e)
        {
            SaveDialog(14);
        }

        private void Save15_Click(object sender, EventArgs e)
        {
            SaveDialog(15);
        }

        private void Save16_Click(object sender, EventArgs e)
        {
            SaveDialog(16);
        }

        private void Save17_Click(object sender, EventArgs e)
        {
            SaveDialog(17);
        }

        private void Save18_Click(object sender, EventArgs e)
        {
            SaveDialog(18);
        }

        private void Save19_Click(object sender, EventArgs e)
        {
            SaveDialog(19);
        }

        private void Save20_Click(object sender, EventArgs e)
        {
            SaveDialog(20);
        }

        private void Save21_Click(object sender, EventArgs e)
        {
            SaveDialog(21);
        }

        private void Save22_Click(object sender, EventArgs e)
        {
            SaveDialog(22);
        }

        private void Save23_Click(object sender, EventArgs e)
        {
            SaveDialog(23);
        }

        private void Save24_Click(object sender, EventArgs e)
        {
            SaveDialog(24);
        }

        private void Gen3_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Accressy in results will increase in later builds.\nSome incrorrect Pokemon may appear in results.";
        }

        private void Gen4_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Pokemon form data not implemented. Accressy \nin results will increase in later builds.";
        }

        private void Gen5_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Vs. Recorder Pokemon may have game set to \nBlack version. Duplicate Pokemon will be \nreplaced with the highest level version.";
        }

        private void Gen6_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Multi battle not tested. \nUse PKHeX to dump Vs. Recorder playback. \nDuplicate Pokemon will be replaced \nwith the highest level copy.";
        }
    }

}
