﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimulationEnvironment
{
    public partial class Form1 : Form
    {
        World world;
        private Random random = new Random();
        private DateTime start = DateTime.Now;
        private DateTime end;
        private int framesRun = 0;

        public Form1()
        {
            InitializeComponent();
            world = new World(new Bee.BeeMessage(SendMessage));
            timer1.Interval = 50;
            timer1.Tick+=new EventHandler(RunFrame);
            timer1.Enabled = false;
            UpdateStats(new TimeSpan());
        }

        private void UpdateStats(TimeSpan frameDuration)
        {
            Bees.Text = world.Bees.Count.ToString();
            Flowers.Text = world.Flowers.Count.ToString();
            HoneyInHive.Text = String.Format("{0:f3}", world.Hive.Honey);
            double nectar = 0;
            foreach (Flower flower in world.Flowers)
            {
                nectar += flower.Nectar;
            }
            NectarInFlowers.Text = String.Format("{0:f3}", nectar);
            FramesRun.Text = framesRun.ToString();
            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
            {
                FrameRate.Text = string.Format("{0:f0} ({1:f1}ms)", 1000 / milliSeconds, milliSeconds);
            }
            else
            {
                FrameRate.Text = "N/A";
            }
        }

        public void RunFrame(object sender, EventArgs e)
        {
            framesRun++;
            world.Go(random);
            end = DateTime.Now;
            TimeSpan frameDuration = end - start;
            start = end;
            UpdateStats(frameDuration);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Resume Simulation";
                timer1.Stop();
            }
            else
            {
                toolStrip1.Items[0].Text = "Pause Simulation";
                timer1.Start();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            framesRun = 0;
            world = new World(new Bee.BeeMessage(SendMessage));
            if (!timer1.Enabled)
            {
                toolStrip1.Items[0].Text = "Start Simulation";
            }
        }

        private void SendMessage(int ID, string Message)
        {
            statusStrip1.Items[0].Text = "Bee #" + ID + ": " + Message;
            var beeGroups =
                from bee in world.Bees
                group bee by bee.CurrentState into beeGroup
                orderby beeGroup.Key
                select beeGroup;
            listBox1.Items.Clear();
            foreach (var group in beeGroups)
            {
                string s;
                if (group.Count() == 1)
                {
                    s = "";
                }
                else
                {
                    s = "s";
                }
                listBox1.Items.Add(group.Key.ToString() + ": " + group.Count() + " bee" + s);
                if (group.Key == Bee.BeeState.Idle && group.Count() == world.Bees.Count() && framesRun > 0)
                {
                    listBox1.Items.Add("Simulation ended: all bees are idle");
                    toolStrip1.Items[0].Text = "Simulation ended";
                    statusStrip1.Items[0].Text = "Simulation ended";
                    timer1.Enabled = false;
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)//保存
        {
            bool enabled = timer1.Enabled;
            if (enabled)
            {
                timer1.Stop();
            }
            world.Hive.MessageSender = null;
            foreach (Bee bee in world.Bees)
            {
                bee.MessageSender = null;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Simulator.File(*.bees)|.bees";
            saveDialog.FileName = "test";
            saveDialog.CheckPathExists = true;
            saveDialog.Title = "CHoose a file to save the current simulation";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream output = File.OpenWrite(saveDialog.FileName))
                    {
                        bf.Serialize(output, world);
                        bf.Serialize(output, framesRun);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to save the simulator file\r\n" + ex.Message, "Bee Simulation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            world.Hive.MessageSender = new Bee.BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
            {
                bee.MessageSender = new Bee.BeeMessage(SendMessage);
            }
            if (enabled)
            {
                timer1.Start();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            World currentWorld = world;
            int currentFramsRun = framesRun;

            bool enabled = timer1.Enabled;
            if (enabled)
            {
                timer1.Stop();
            }

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Simulation File(*.bees)|*.bees";
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            openDialog.Title = "Choose a file with a simulation to load";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream input = File.OpenRead(openDialog.FileName))
                    {
                        world = (World)bf.Deserialize(input);
                        framesRun = (int)bf.Deserialize(input);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to read the simulator file\r\n" + ex.Message, "Bee Simulation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world = currentWorld;
                    framesRun = currentFramsRun;
                }
            }
            world.Hive.MessageSender = new Bee.BeeMessage(SendMessage);
            foreach (Bee bee in world.Bees)
            {
                bee.MessageSender = new Bee.BeeMessage(SendMessage);
            }
            if (enabled)
            {
                timer1.Start();
            }
        }
    }
}