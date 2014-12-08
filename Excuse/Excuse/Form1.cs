using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Excuse
{
    public partial class Form1 : Form
    {
        private Excuse currentExcuse = new Excuse();
        private string selectedFolder = "";
        private bool formChanged = false;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = selectedFolder;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedFolder = folderBrowserDialog1.SelectedPath;
                buttonSave.Enabled = true;
                buttonOpen.Enabled = true;
                buttonRandom.Enabled = true;
            }
        }

        public void UpdateForm(bool Changed)
        {
            if (!Changed)
            {
                this.textExcuse.Text = currentExcuse.Description;
                this.textResults.Text = currentExcuse.Results;
                this.dateTimeLastUsed.Value = currentExcuse.LastUsed;
                if (!String.IsNullOrEmpty(currentExcuse.ExcusePath))
                {
                    textFileDate.Text=File.GetLastWriteTime(currentExcuse.ExcusePath).ToString();
                    this.Text = "Excuse Manageer";
                }
                else
                {
                    this.Text = "Excuse Manager*";
                }
                this.formChanged = Changed;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textExcuse.Text)||String.IsNullOrEmpty(textResults.Text))
            {
                MessageBox.Show("Please specify an excuse and a result", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            saveFileDialog1.InitialDirectory = selectedFolder;
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.FileName = textExcuse.Text + ".txt";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentExcuse.Save(saveFileDialog1.FileName);
                if (currentExcuse.LastUsed == DateTime.MinValue || currentExcuse.LastUsed == DateTime.MaxValue)//如果不输入最后使用时间将无法储存
                {
                    MessageBox.Show("Please input the Datetime", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    File.Delete(saveFileDialog1.FileName);
                    return;
                }
                else
                {
                    UpdateForm(false);
                    MessageBox.Show("Excuse written");
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                openFileDialog1.InitialDirectory = selectedFolder;
                openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog1.FileName = textExcuse.Text + ".txt";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool clearForm = false;
                    try
                    {
                        currentExcuse = new Excuse(openFileDialog1.FileName);
                        try
                        {
                            UpdateForm(false);
                        }
                        catch
                        {
                            MessageBox.Show("An error occurred while opening the excuse");
                            clearForm = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while opening the excuse" + openFileDialog1.FileName + "'\n" + ex.Message, "Unable to open the excuse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clearForm = true;
                    }
                    finally
                    {
                        if (clearForm)
                        {
                            textExcuse.Text = "";
                            textResults.Text = "";
                            dateTimeLastUsed.Value = DateTime.Now;
                        }
                    }
                }
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                currentExcuse = new Excuse(random, selectedFolder);
                UpdateForm(false);
            }
        }

        private bool CheckChanged()
        {
            if (formChanged)
            {
                DialogResult result = MessageBox.Show("The current excuse has not been saved. Continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void textExcuse_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Description = textExcuse.Text;
            UpdateForm(true);
        }

        private void textResults_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Results = textResults.Text;
            UpdateForm(true);
        }

        private void dateTimeLastUsed_ValueChanged(object sender, EventArgs e)
        {
            currentExcuse.LastUsed = dateTimeLastUsed.Value;
            UpdateForm(true);
        }

    }
}
