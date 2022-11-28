using System;
using System.IO;

namespace GLRToggle
{
    public partial class Form1 : Form
    {
        public void FileCheck()
        {
            string path = @"D:\Games\Steam\User32.dll";
            string path2 = @"D:\Games\Steam\disabled\User32.dll";
            string path3 = @"D:\Games\Steam\appcache\appinfo.vdf";
            string path4 = @"D:\Games\Steam\version.dll";
            string path5 = @"D:\Games\Steam\disabled\version.dll";

            if (!File.Exists(path))
            {
                button1.Enabled = false;
            }

            if (!File.Exists(path2))
            {
                button2.Enabled = false;
            }

            if (File.Exists(path))
            {
                button1.Enabled = true;
            }

            if (File.Exists(path2))
            {
                button2.Enabled = true;
            }

            if (File.Exists(path3) | File.Exists(path4))
            {
                button3.Enabled = true;
            }

            if (!File.Exists(path3) & !File.Exists(path4))
            {
                button3.Enabled = false;
            }

            // If no version.dll in root, disable the Disable button
            if (!File.Exists(path4))
            {
                button5.Enabled = false;
            }

            // If no version.dll in disabled, disable the Enable button
            if (!File.Exists(path5))
            {
                button4.Enabled = false;
            }

            if (File.Exists(path4))
            {
                button5.Enabled = true;
            }

            if (File.Exists(path5))
            {
                button4.Enabled = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
            FileCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"D:\Games\Steam\disabled");

            string path = @"D:\Games\Steam\User32.dll";
            string path2 = @"D:\Games\Steam\disabled\User32.dll";

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(path2))
                {
                    string message2 = "File exists in disabled folder. Stopping disable as two copies of User32.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(path, path2);
                Console.WriteLine("{0} was moved to {1}.", path, path2);
                string message3 = "GLR disabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(path))
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
            System.IO.Directory.CreateDirectory(@"D:\Games\Steam\disabled");

            string path = @"D:\Games\Steam\disabled\User32.dll";
            string path2 = @"D:\Games\Steam\User32.dll";

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(path2))
                {
                    string message2 = "File exists in Steam folder. Stopping enable as two copies of User32.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(path, path2);
                Console.WriteLine("{0} was moved to {1}.", path, path2);
                string message3 = "GLR enabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(path))
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
            string path = @"D:\Games\Steam\appcache\appinfo.vdf";
            string path2 = @"D:\Games\Steam\appcache\packageinfo.vdf";

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the Steam Cache? (appinfo.vdf and packageinfo.vdf will be permanently deleted!)", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }

                    string message4 = "Deletion successful.";
                    MessageBox.Show(message4);
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
            System.IO.Directory.CreateDirectory(@"D:\Games\Steam\disabled");

            string path = @"D:\Games\Steam\disabled\version.dll";
            string path2 = @"D:\Games\Steam\version.dll";

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(path2))
                {
                    string message2 = "File exists in Steam folder. Stopping enable as two copies of version.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(path, path2);
                Console.WriteLine("{0} was moved to {1}.", path, path2);
                string message3 = "Koala enabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(path))
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
            System.IO.Directory.CreateDirectory(@"D:\Games\Steam\disabled");

            string path = @"D:\Games\Steam\version.dll";
            string path2 = @"D:\Games\Steam\disabled\version.dll";

            try
            {
                // Ensure that the target does not exist.
                if (File.Exists(path2))
                {
                    string message2 = "File exists in disabled folder. Stopping disable as two copies of version.dll exist.";
                    MessageBox.Show(message2);
                    FileCheck();
                }

                // Move the file.
                File.Move(path, path2);
                Console.WriteLine("{0} was moved to {1}.", path, path2);
                string message3 = "Koala disabled.";
                MessageBox.Show(message3);
                FileCheck();

                // See if the original exists now.
                if (File.Exists(path))
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
    }
}