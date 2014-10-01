/* 
 * This file is part of ROMLaunch.
 *
 * ROMLaunch is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ROMLaunch is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ROMLaunch.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Emu;

namespace ROMLaunch
{
    public partial class MainForm : Form
    {
        public static String VERSION = "1.2";

        private List<Emulator> emulators;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emulators = new List<Emulator>();
            LoadSettings();
            RefreshTabList();
        }

        private void RefreshTabList()
        {
            int prevTab = tabROMSelector.SelectedIndex;
            tabROMSelector.TabPages.Clear();
            emulators = emulators.OrderBy(emu => emu.emulatorName).ToList();
            foreach (Emulator emu in emulators)
            {
                TabPage newTab = new TabPage(emu.emulatorName);
                ListBox romList = new ListBox();
                foreach (String ext in emu.fileExtensions)
                {
                    string[] roms = Directory.GetFiles(emu.romFolderPath, "*." + ext);
                    for (int i = 0; i < roms.Length; i++)
                    {
                        roms[i] = Path.GetFileName(roms[i]);
                    }
                    romList.Items.AddRange(roms);
                }
                newTab.Controls.Add(romList);
                romList.Dock = DockStyle.Fill;

                tabROMSelector.TabPages.Add(newTab);
            }
            try
            {
                tabROMSelector.SelectTab(prevTab);
            }
            catch (ArgumentOutOfRangeException)
            {
                //Do nothing, just means that the tab index no longer exists as a tab was likely removed, or a tab was not selected
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to restore previous tab:\n" + ex.Message, "ROMLaunch");
            }
        }

#region Emulator Objects

        private void NewEmulator()
        {
            OpenFileDialog emuChooser = new OpenFileDialog();
            emuChooser.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            emuChooser.Title = "Choose a new emulator";

            OpenFileDialog romChooser = new OpenFileDialog();
            romChooser.Filter = "All files (*.*)|*.*";
            romChooser.Title = "Choose a sample ROM to be opened with this emulator";

            if (emuChooser.ShowDialog().Equals(DialogResult.OK) && romChooser.ShowDialog().Equals(DialogResult.OK))
            {
                String newExtensions = Microsoft.VisualBasic.Interaction.InputBox("Enter the file extensions that this emulator can run.\n" +
                    "Separate extensions with commas (no spaces)", "", Path.GetExtension(romChooser.FileName).Substring(1), -1, -1);
                if (!newExtensions.Equals(""))
                {
                    String newArguments = Microsoft.VisualBasic.Interaction.InputBox("Enter any necessary arguments for the emulator.\n" + 
                        "If you're unsure, don't enter anything here.", "", "", -1, -1);

                    String newEmuName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for this emulator", "", "Emulator", -1, -1);

                    if (!newEmuName.Equals(""))
                    {
                        emulators.Add(new Emulator(emuChooser.FileName, Path.GetDirectoryName(romChooser.FileName),
                            newExtensions.Split(','), newEmuName, newArguments));

                        SaveSettings();
                    }
                }
            }
        }

        private void RemoveEmulator()
        {
            if (MessageBox.Show("Are you sure you want to delete " + tabROMSelector.SelectedTab.Text + 
                "?", "ROMLaunch", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                emulators.RemoveAll(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text));
                SaveSettings();
            }
        }

#endregion

#region Settings/XML

        private void LoadSettings()
        {
            try
            {
                String newEmuName = "";
                String newEmuPath = "";
                String newROMPath = "";
                List<String> newROMFileExtensions = new List<String>();
                String newArguments = "";

                using (XmlReader reader = XmlReader.Create("./settings.xml"))
                {
                    while (reader.Read())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "Name":
                                newEmuName = reader.ReadElementString();
                                break;
                            case "Executable":
                                newEmuPath = reader.ReadElementString();
                                break;
                            case "ROMDirectory":
                                newROMPath = reader.ReadElementString();
                                break;
                            case "ROMExtension":
                                newROMFileExtensions.Add(reader.ReadElementString());
                                break;
                            case "Arguments":
                                newArguments = reader.ReadElementString();
                                break;
                        }
                        if (reader.Name.Equals("Emulator") && reader.NodeType == XmlNodeType.EndElement)
                        {
                            emulators.Add(new Emulator(newEmuPath, newROMPath, newROMFileExtensions.ToArray<String>(), newEmuName, newArguments));
                            newROMFileExtensions.Clear();
                        }
                    }
                }
            }
            catch (FileNotFoundException) //The settings file was missing, this happens during first launch
            {
                File.WriteAllText("./settings.xml", String.Empty);
                File.CreateText("./settings.xml").Close();
                LoadSettings();
            }
            catch (XmlException) //No emulator exists yet
            {
                NewEmulator();
            }
            catch (Exception ex) //Unknown error
            {
                MessageBox.Show("An unhandled error occurred while opening the settings file: \n" + ex.Message, "ROMLaunch");
            }
        }

        private void SaveSettings()
        {
            emulators = emulators.OrderBy(emu => emu.emulatorName).ToList();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            using (XmlWriter writer = XmlWriter.Create("settings.xml", settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Settings");

                foreach (Emulator emu in emulators)
                {
                    writer.WriteStartElement("Emulator");

                    writer.WriteElementString("Name", emu.emulatorName);
                    writer.WriteElementString("Executable", emu.emulatorPath);
                    writer.WriteElementString("ROMDirectory", emu.romFolderPath);
                    foreach (String ext in emu.fileExtensions)
                    {
                        writer.WriteElementString("ROMExtension", ext);
                    }
                    writer.WriteElementString("Arguments", emu.arguments);
                    
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            RefreshTabList();
        }

#endregion

#region Buttons

        private void mnuAddEmulator_Click(object sender, EventArgs e)
        {
            NewEmulator();
        }

        private void mnuRemoveEmulator_Click(object sender, EventArgs e)
        {
            RemoveEmulator();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ROMLaunch Version " + VERSION + "\n\nCopyright © 2012 Logan Baron\nROMLaunch is licensed under the GNU " +
                "General Public License, Version 3 (GPLv3)", "ROMLaunch");
        }

        private void mnuEditEmuName_Click(object sender, EventArgs e)
        {
            String newName = Microsoft.VisualBasic.Interaction.InputBox("Enter a new name for this emulator", "", emulators.Find(emu => 
                emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).emulatorName, -1, -1);
            
            if (!newName.Equals(""))
            {
                emulators.Find(emu => 
                emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).emulatorName = newName;
                SaveSettings();
            } 
        }

        private void mnuEditEmuExe_Click(object sender, EventArgs e)
        {
            OpenFileDialog emuChooser = new OpenFileDialog();
            emuChooser.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            emuChooser.Title = "Choose a new executable for " + tabROMSelector.SelectedTab.Text;

            if (emuChooser.ShowDialog().Equals(DialogResult.OK))
            {
                emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).emulatorPath = emuChooser.FileName;

                MessageBox.Show("Successfully changed " + tabROMSelector.SelectedTab.Text + "'s executable to:\n" + 
                    emuChooser.FileName, "ROMLaunch");

                SaveSettings();
            }
        }

        private void mnuEditROMPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog romChooser = new OpenFileDialog();
            romChooser.Filter = "All files (*.*)|*.*";
            romChooser.Title = "Choose a sample ROM to be opened with " + tabROMSelector.SelectedTab.Text;

            if (romChooser.ShowDialog().Equals(DialogResult.OK))
            {
                emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).romFolderPath = 
                    Path.GetDirectoryName(romChooser.FileName);

                MessageBox.Show(tabROMSelector.SelectedTab.Text + " will now open " +
                    String.Join(",", emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).fileExtensions) + " files in " +
                    emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).romFolderPath, "ROMLaunch");

                SaveSettings();
            }
        }

        private void mnuEditEmulatorArgs_Click(object sender, EventArgs e)
        {
            String newArguments = Microsoft.VisualBasic.Interaction.InputBox("Enter any necessary arguments for the emulator.\n" +
                        "If you're unsure, don't enter anything here.", "", emulators.Find(emu => 
                            emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).arguments, -1, -1);

            emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).arguments = newArguments;

            if (newArguments.Equals(""))
            {
                MessageBox.Show(tabROMSelector.SelectedTab.Text + " will not use any arguments at launch.", "ROMLaunch");
            }
            else
            {
                MessageBox.Show(tabROMSelector.SelectedTab.Text + " will now open with the following arguments:\n" +
                    newArguments, "ROMLaunch");
            }
            SaveSettings();
        }

        private void mnuEditROMFileExtensions_Click(object sender, EventArgs e)
        {
            String newExtensions = Microsoft.VisualBasic.Interaction.InputBox("Enter the file extensions that this emulator can run.\n" +
                    "Separate extensions with commas (no spaces)", "", String.Join(",", emulators.Find(emu => 
                        emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).fileExtensions), -1, -1);

            if (!newExtensions.Equals(""))
            {
                emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).fileExtensions =
                    newExtensions.Split(',');

                MessageBox.Show(tabROMSelector.SelectedTab.Text + " will now open " +
                    String.Join(",", emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).fileExtensions) + " files in " +
                    emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).romFolderPath, "ROMLaunch");

                SaveSettings();
            }
        }

        private void btnLaunchROM_Click(object sender, EventArgs e)
        {
            String selectedROM = "";
            String selectedEmu = "";
            String selectedEmuROMPath = "";
            String selectedEmuArgs = "";

            try
            {
                selectedROM = ((ListBox)tabROMSelector.SelectedTab.Controls[0]).SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Choose a ROM first", "ROMLaunch");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to get selected ROM:\n" + ex.Message, "ROMLaunch");
            }

            try
            {
                selectedEmu = emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).emulatorPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to get selected emulator:\n" + ex.Message, "ROMLaunch");
            }

            try
            {
                selectedEmuROMPath = emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).romFolderPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to get selected emulator ROM path:\n" + ex.Message, "ROMLaunch");
            }

            try
            {
                selectedEmuArgs = emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).arguments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to get selected emulator arguments:\n" + ex.Message, "ROMLaunch");
            }

            try
            {
                if (!selectedROM.Equals("") && !selectedEmu.Equals("") && !selectedEmuROMPath.Equals(""))
                {
                    String procArgs = selectedEmuArgs + selectedEmuROMPath + "\\" + selectedROM;
                    System.Diagnostics.Process.Start(selectedEmu, "\"" + procArgs.Trim() + "\"");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to launch ROM:\n" + ex.Message, "ROMLaunch");
            }
        }

        private void btnOpenEmulator_Click(object sender, EventArgs e)
        {
            String selectedEmu = "";

            try
            {
                selectedEmu = emulators.Find(emu => emu.emulatorName.Equals(tabROMSelector.SelectedTab.Text)).emulatorPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to get selected emulator:\n" + ex.Message, "ROMLaunch");
            }

            try
            {
                if (!selectedEmu.Equals(""))
                {
                    System.Diagnostics.Process.Start(selectedEmu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error when trying to open emulator:\n" + ex.Message, "ROMLaunch");
            }
        }

#endregion

    }
}
