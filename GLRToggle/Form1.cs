using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace GLRToggle
{
    public partial class Form1 : Form
    {
        private SoundPlayer soundPlayer;

        public void FileCheck()
        {
            // Form1.Designer.cs references:
            // button1 = GLR Disable
            // button2 = GLR Enable
            // button3 = Clear Steam Cache
            // button4 = Koala Enable
            // button5 = Koala Disable
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\User32.dll";
            string path2 = @"\disabled\User32.dll";
            string path3 = @"\appcache\appinfo.vdf";
            string path4 = @"\version.dll";
            string path5 = @"\disabled\version.dll";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;
            string userInputPath3 = userInputPath + path3;
            string userInputPath4 = userInputPath + path4;
            string userInputPath5 = userInputPath + path5;

            // Initialize GLR disable button
            button1.Enabled = File.Exists(userInputPath1);

            // Initialize Clear Steam Cache button
            button3.Enabled = File.Exists(userInputPath3);

            // Initialize Koala disable button
            button5.Enabled = File.Exists(userInputPath4);

            // If User32.dll in disable AND version.dll doesn't exist in the root, enable the Enable button for GLR
            // Add check for override checkbox. If checked, always enable the button.
            if (File.Exists(userInputPath2) & !File.Exists(userInputPath4) | checkBox_override.Checked)
            {
                button2.Enabled = true;
            }
            else if (!File.Exists(userInputPath2) | File.Exists(userInputPath4) & (checkBox_override.Checked == false))
            {
                button2.Enabled = false;
            }

            // If version.dll in disable AND User32.dll doesn't exist in the root, enable the Enable button for Koala
            // Add check for override checkbox. If checked, always enable the button.
            if (File.Exists(userInputPath5) & !File.Exists(userInputPath1) | checkBox_override.Checked)
            {
                button4.Enabled = true;
            }
            else if (!File.Exists(userInputPath5) | File.Exists(userInputPath1) & (checkBox_override.Checked == false))
            {
                button4.Enabled = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            FileCheck();
            soundPlayer = new SoundPlayer("wow.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\User32.dll";
            string path2 = @"\disabled\User32.dll";
            string path3 = @"\disabled";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;
            string userInputPath3 = userInputPath + path3;
            System.IO.Directory.CreateDirectory(userInputPath3);

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(userInputPath2))
                {
                    string message2 = "File exists in disabled folder. Stopping disable as two copies of User32.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(userInputPath1, userInputPath2);
                Console.WriteLine("{0} was moved to {1}.", userInputPath1, userInputPath2);
                string message3 = "GLR disabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(userInputPath1))
                {
                    Console.WriteLine("The original file still exists, which is unexpected.");
                }
                else
                {
                    Console.WriteLine("The original file no longer exists, which is expected.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("The process failed: {0}", exc.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\disabled\User32.dll";
            string path2 = @"\User32.dll";
            string path3 = @"\disabled";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;
            string userInputPath3 = userInputPath + path3;
            System.IO.Directory.CreateDirectory(userInputPath3);

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(userInputPath2))
                {
                    string message2 = "File exists in Steam folder. Stopping enable as two copies of User32.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(userInputPath1, userInputPath2);
                Console.WriteLine("{0} was moved to {1}.", userInputPath1, userInputPath2);
                string message3 = "GLR enabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(userInputPath1))
                {
                    Console.WriteLine("The original file still exists, which is unexpected.");
                }
                else
                {
                    Console.WriteLine("The original file no longer exists, which is expected.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("The process failed: {0}", exc.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\appcache\appinfo.vdf";
            string path2 = @"\appcache\packageinfo.vdf";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the Steam Cache? (appinfo.vdf and packageinfo.vdf will be permanently deleted!)", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(userInputPath1))
                    {
                        File.Delete(userInputPath1);
                    }

                    if (File.Exists(userInputPath2))
                    {
                        File.Delete(userInputPath2);
                    }

                    if (Process.GetProcessesByName("steam").Length > 0)
                    {
                        string message6 = "Deletion successful. You will need to restart Steam to see changes.";
                        MessageBox.Show(message6);
                    }
                    else
                    {
                        string message4 = "Deletion successful.";
                        MessageBox.Show(message4);
                    }
                    FileCheck();
                }
                catch
                {
                    string message5 = "Deletion failed or errors occured.";
                    MessageBox.Show(message5);
                    FileCheck();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\disabled\version.dll";
            string path2 = @"\version.dll";
            string path3 = @"\disabled";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;
            string userInputPath3 = userInputPath + path3;
            System.IO.Directory.CreateDirectory(userInputPath3);

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(userInputPath2))
                {
                    string message2 = "File exists in Steam folder. Stopping enable as two copies of version.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(userInputPath1, userInputPath2);
                Console.WriteLine("{0} was moved to {1}.", userInputPath1, userInputPath2);
                string message3 = "Koala enabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(userInputPath1))
                {
                    Console.WriteLine("The original file still exists, which is unexpected.");
                }
                else
                {
                    Console.WriteLine("The original file no longer exists, which is expected.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("The process failed: {0}", exc.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string path = @"\version.dll";
            string path2 = @"\disabled\version.dll";
            string path3 = @"\disabled";
            string userInputPath1 = userInputPath + path;
            string userInputPath2 = userInputPath + path2;
            string userInputPath3 = userInputPath + path3;
            System.IO.Directory.CreateDirectory(userInputPath3);

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(userInputPath2))
                {
                    string message2 = "File exists in disabled folder. Stopping disable as two copies of version.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(userInputPath1, userInputPath2);
                Console.WriteLine("{0} was moved to {1}.", userInputPath1, userInputPath2);
                string message3 = "Koala disabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(userInputPath1))
                {
                    Console.WriteLine("The original file still exists, which is unexpected.");
                }
                else
                {
                    Console.WriteLine("The original file no longer exists, which is expected.");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("The process failed: {0}", exc.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create folder dialog
            FolderBrowserDialog steampath = new FolderBrowserDialog();
            // Prompt for Steam folder selection?
            steampath.Description = "Select your root Steam folder.";
            // Show dialog
            steampath.ShowDialog();
            // Store variable
            string userPath = steampath.SelectedPath;
            // Save variable?
            Properties.Settings1.Default.userpath = userPath;
            Properties.Settings1.Default.Save();
            // Repopulate buttons (hopefully)
            FileCheck();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileCheck();
        }

        // teehee
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            soundPlayer.Play();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            soundPlayer.Play();
        }

        // Call FileCheck anytime the checkbox is changed
        private void checkBox_override_CheckedChanged_1(object sender, EventArgs e)
        {
            FileCheck();
        }
    }
}