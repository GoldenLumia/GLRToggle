using System;
using System.IO;

namespace GLRToggle
{
    public partial class Form1 : Form
    {
        public void FileCheck()
        {
            string path = @"C:\Program Files (x86)\Steam\User32.dll";
            string path2 = @"C:\Program Files (x86)\Steam\disabled\User32.dll";

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
        }

        public Form1()
        {
            InitializeComponent();
            FileCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"C:\Program Files (x86)\Steam\disabled");

            string path = @"C:\Program Files (x86)\Steam\User32.dll";
            string path2 = @"C:\Program Files (x86)\Steam\disabled\User32.dll";

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
            System.IO.Directory.CreateDirectory(@"C:\Program Files (x86)\Steam\disabled");

            string path = @"C:\Program Files (x86)\Steam\disabled\User32.dll";
            string path2 = @"C:\Program Files (x86)\Steam\User32.dll";

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
    }
}