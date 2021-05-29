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
using RAM_to_PKX_Rip.Core.Resource;

using System.Reflection;

namespace RAM_to_PKX_Rip
{
    public partial class Form1 : Form
    {
        //Needed values to rip Pokemon
        Data_Conversion hex = new Data_Conversion();
        Dex_Conversion dex = new Dex_Conversion();
        Pokemon_Data data = new Pokemon_Data();
        File_Manager fm = new File_Manager();
        Gen_3_and_Later_Rip rip = new Gen_3_and_Later_Rip();
        List<string> list = new List<string>();
        public
        byte[,] pokemon;
        bool fileAdded = false;
        string path = " ";
        int row;
        int column;
        int found = 0;
        int speciesIndex = 0;
        int idIndex = 0;
        int moveIndex = 0;
        int selectIndex = 0;
        int dexNum = 0;
        int size = 0;
        int gen = 0;
        bool endTask;
        
        private delegate void DataSetMethodInvoker();
        public delegate void MaxProgressMethodInvoker(int amount);
        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();

        public Form1()
        {
            InitializeComponent();
            rip.MP += new Gen_3_and_Later_Rip.MaxProgressMethodInvoker(SetAmount);
            rip.CP += new Gen_3_and_Later_Rip.CurrentProgressMethodInvoker(UpdateProgress);
            rip.End += new Gen_3_and_Later_Rip.EndThread(Stopper);
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
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.WorkerSupportsCancellation = true;
                Save_Button.Enabled = false;
                Rip.Text = "Stop Rip";
                OpenFileBTN.Enabled = false;
                comboBox1.Enabled = false;
                endTask = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                backgroundWorker1.CancelAsync();
                endTask = true;
                comboBox1.Items.Clear();
                OpenFileBTN.Enabled = true;
                RipProgressBar.Value = 0;
                Rip.Text = "Rip";
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            RipProgressBar.Value = e.ProgressPercentage;
        }

        private void SaveDialog(int slot)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (gen == 3)
            {
                saveFileDialog1.Filter = "PK3|*.pk3";
            }
            if (gen == 4)
            {
                saveFileDialog1.Filter = "PK4|*.pk4";
            }
            if (gen == 5)
            {
                saveFileDialog1.Filter = "PK5|*.pk5";
            }
            if (gen == 6)
            {
                saveFileDialog1.Filter = "PK6|*.pk6";
            }
            if (gen == 2)
            {
                saveFileDialog1.Filter = "PK2|*.pk2";
            }

            saveFileDialog1.Title = "Save Pokemon";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                byte[] saveData = new byte[column];
                for (int i = 0; i < column; i++)
                {
                    saveData[i] = pokemon[slot, i];
                }

                fm.WriteFile(string.Format("{0}", saveFileDialog1.FileName), saveData);
            }
        }

        private void Gen3_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "The rip process will take some time.\nOpponent's Pokemon can be after active party at\nthe top of the list.\nFRLG Trainer Hill/Tower Shiny Pokemon \nwill not appear in results.";
        }

        private void Gen4_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "The rip process will take a little time.\nOpponent's Pokemon can be found at \nthe end of the list.";
        }

        private void Gen5_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Vs. Recorder Pokemon may have game set to \nBlack version.\nParty and opponent's Pokemon can be found at \nthe end of the list.";
        }

        private void Gen6_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "Multi battle not tested. \nUse PKHeX to dump Vs. Recorder playback.";
        }

        private void Gen2SW97_CheckedChanged(object sender, EventArgs e)
        {
            Info.Text = "-Put the Pokemon you want to dump in the first \n slot of the party.\n" +
                "-In the emulator click on \n Tool -> Debug -> Memory Viewer then click the \n save option.\n" +
                "-In the Address box input 0000D6B2 and in the\n Size box input 30. Then click OK.\n" +
                "-Save the .dmp file somewhere that you can find it.\n" +
                "-The name in the drop down menu is what the\n Pokemon will be in the game.";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = comboBox1.SelectedIndex;

            if (list.Count == 0)
                list.Add("1");

            if (gen == 2)
            {
                Gen_2_Beta_Data beta = new Gen_2_Beta_Data();
                if(dexNum >= 152)
                    list[0] = "d97_" + dexNum.ToString();
                else
                    list[0] = "b_" + dexNum.ToString();
                PName.Text = beta.GetNameString(dexNum);
                ID.Text = "ID: " + hex.LittleEndian2D(pokemon, selectIndex, 9, 2).ToString();
                SID.Text = "SID: 0";
                Move1.Text = "Move 1: " + data.getMove(hex.ConOneHex(pokemon[0, 5]));
                Move2.Text = "Move 2: " + data.getMove(hex.ConOneHex(pokemon[0, 6]));
                Move3.Text = "Move 3: " + data.getMove(hex.ConOneHex(pokemon[0, 7]));
                Move4.Text = "Move 4: " + data.getMove(hex.ConOneHex(pokemon[0, 8]));
            }
            else
            {
                if (gen == 3)
                    dexNum = dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, selectIndex, speciesIndex, 2));
                else
                    dexNum = hex.LittleEndian2D(pokemon, selectIndex, speciesIndex, 2);

                PName.Text = data.getPokemonName(dexNum);
                ID.Text = "ID: " + hex.LittleEndian2D(pokemon, selectIndex, idIndex, 2).ToString();
                SID.Text = "SID: " + hex.LittleEndian2D(pokemon, selectIndex, idIndex + 2, 2).ToString();
                Move1.Text = "Move 1: " + data.getMove(hex.LittleEndian2D(pokemon, selectIndex, moveIndex, 2));
                Move2.Text = "Move 2: " + data.getMove(hex.LittleEndian2D(pokemon, selectIndex, moveIndex + 2, 2));
                Move3.Text = "Move 3: " + data.getMove(hex.LittleEndian2D(pokemon, selectIndex, moveIndex + 4, 2));
                Move4.Text = "Move 4: " + data.getMove(hex.LittleEndian2D(pokemon, selectIndex, moveIndex + 6, 2));

                list[0] = "b_" + dexNum.ToString();
            }
            Icon.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(list[0]);
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SaveDialog(selectIndex);
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (fileAdded == true)
            {
                row = 1010;
                if (Gen3.Checked == true)
                {
                    column = 80;
                    pokemon = new byte[row, column];
                    speciesIndex = 32;
                    idIndex = 4;
                    moveIndex = 44;
                    size = 100;
                    gen = 3;
                }
                if (Gen4.Checked == true)
                {
                    column = 136;
                    pokemon = new byte[row, column];
                    speciesIndex = 8;
                    idIndex = 12;
                    moveIndex = 40;
                    size = 236;
                    gen = 4;
                }
                if (Gen5.Checked == true)
                {
                    column = 136;
                    pokemon = new byte[row, column];
                    speciesIndex = 8;
                    idIndex = 12;
                    moveIndex = 40;
                    size = 236;
                    gen = 5;
                }
                if (Gen6.Checked == true)
                {
                    column = 232;
                    pokemon = new byte[row, column];
                    speciesIndex = 8;
                    idIndex = 12;
                    moveIndex = 90;
                    size = 260;
                    gen = 6;
                }
                if (Gen2SW97.Checked == true)
                {
                    column = 63;
                    row = 1;
                    pokemon = new byte[row, column];
                    speciesIndex = 3;
                    moveIndex = 0;
                    size = 48;
                    gen = 2;
                }

                if (Gen2SW97.Checked == true)
                {
                    Gen_2_SW97 g2 = new Gen_2_SW97();
                    found = g2.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), size, ref dexNum);
                }
                else
                {
                    found = rip.Start(pokemon, string.Format("{0}", openFileDialog1.FileName), row, column, size, gen);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(found.ToString() + " Pokemon found.");

            BindComboBoxData();
        }

        private void BindComboBoxData()
        {
            if (comboBox1.InvokeRequired)
            {
                // Worker thread.
                comboBox1.Invoke(new DataSetMethodInvoker(BindComboBoxData));
            }
            else
            {
                object[] ItemObject = new object[found];
                if (found != 0)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i < found; i++)
                    {
                        if (gen == 3)
                            dexNum = dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, i, speciesIndex, 2));
                        else
                            dexNum = hex.LittleEndian2D(pokemon, i, speciesIndex, 2);

                        ItemObject[i] = data.getPokemonName(dexNum);
                    }
                    comboBox1.Items.AddRange(ItemObject);
                    Save_Button.Enabled = true;
                }
                Rip.Enabled = true;
                OpenFileBTN.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void SetAmount(int amount)
        {
            if (RipProgressBar.InvokeRequired)
            {
                RipProgressBar.Invoke(new MaxProgressMethodInvoker(SetAmount), amount);
            }
            else
            {
                RipProgressBar.Maximum = amount;
                RipProgressBar.Value = 0;
            }
        }

        private void UpdateProgress(int amount)
        {
            if (RipProgressBar.InvokeRequired)
            {
                RipProgressBar.Invoke(new CurrentProgressMethodInvoker(UpdateProgress), amount);
            }
            else
            {
                RipProgressBar.Value = amount;
            }
        }

        public bool Stopper()
        {
            return endTask;
        }
    }
}
