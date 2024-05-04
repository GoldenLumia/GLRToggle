using System.Diagnostics;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace GLRToggle
{
    public partial class Form1 : Form
    {
        private readonly SoundPlayer _soundPlayer;
        private int _clickCount;
        private readonly Timer _timer;
        private int _clickCount2;
        private DateTime _lastClickTime;
        private readonly SoundPlayer _soundPlayer2;
        
        private const string User32Dll = "user32.dll";
        private const string VersionDll = "version.dll";
        private const string AppinfoVdf = "appinfo.vdf";
        private const string PackageinfoVdf = "packageinfo.vdf";
        private const string DisabledFolder = "disabled";

        private void FileCheck()
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string user32Path = Path.Combine(userInputPath, User32Dll);
            string user32DisabledPath = Path.Combine(userInputPath, DisabledFolder, User32Dll);
            string appInfoPath = Path.Combine(userInputPath, "appcache", AppinfoVdf);
            string versionPath = Path.Combine(userInputPath, VersionDll);
            string versionDisabledPath = Path.Combine(userInputPath, DisabledFolder, VersionDll);

            button1.Enabled = File.Exists(user32Path);
            label1.ForeColor = button1.Enabled ? Color.Green : SystemColors.ControlText;

            button3.Enabled = File.Exists(appInfoPath);

            button5.Enabled = File.Exists(versionPath);
            label2.ForeColor = button5.Enabled ? Color.Green : SystemColors.ControlText;

            button2.Enabled = File.Exists(user32DisabledPath);
            button4.Enabled = File.Exists(versionDisabledPath);
        }

        public Form1()
        {
            InitializeComponent();
            FileCheck();

            _soundPlayer = new SoundPlayer("wow.wav");
            _clickCount = 0;

            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Tick += TimerElapsed;

            _soundPlayer2 = new SoundPlayer("why_are_you_blue.wav");
        }
        
        private void MoveFile(string sourcePath, string destinationPath, string successMessage)
        {
            try
            {
                if (File.Exists(destinationPath))
                {
                    MessageBox.Show($@"File exists in {Path.GetDirectoryName(destinationPath)}. Stopping operation as two copies exist.");
                    FileCheck();
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? throw new InvalidOperationException());
                File.Move(sourcePath, destinationPath);
                MessageBox.Show(successMessage);
                FileCheck();
            }
            catch (Exception exc)
            {
                MessageBox.Show($@"The process failed: {exc}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string user32Path = Path.Combine(userInputPath, User32Dll);
            string user32DisabledPath = Path.Combine(userInputPath, DisabledFolder, User32Dll);

            MoveFile(user32Path, user32DisabledPath, "GLR disabled.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string user32Path = Path.Combine(userInputPath, User32Dll);
            string user32DisabledPath = Path.Combine(userInputPath, DisabledFolder, User32Dll);

            MoveFile(user32DisabledPath, user32Path, "GLR enabled.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string appInfoPath = Path.Combine(userInputPath, "appcache", AppinfoVdf);
            string packageInfoPath = Path.Combine(userInputPath, "appcache", PackageinfoVdf);

            DialogResult dialogResult = MessageBox.Show(@"Are you sure you want to clear the Steam Cache? (appinfo.vdf and packageinfo.vdf will be permanently deleted!)", @"Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    File.Delete(appInfoPath);
                    File.Delete(packageInfoPath);

                    string message = Process.GetProcessesByName("steam").Length > 0
                        ? "Deletion successful. You will need to restart Steam to see changes."
                        : "Deletion successful.";

                    MessageBox.Show(message);
                    FileCheck();
                }
                catch
                {
                    MessageBox.Show(@"Deletion failed or errors occurred.");
                    FileCheck();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string versionPath = Path.Combine(userInputPath, VersionDll);
            string versionDisabledPath = Path.Combine(userInputPath, DisabledFolder, VersionDll);

            MoveFile(versionDisabledPath, versionPath, "Version enabled.");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string userInputPath = Properties.Settings1.Default.userpath;
            string versionPath = Path.Combine(userInputPath, VersionDll);
            string versionDisabledPath = Path.Combine(userInputPath, DisabledFolder, VersionDll);

            MoveFile(versionPath, versionDisabledPath, "Version disabled.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using var steampath = new FolderBrowserDialog();
            steampath.Description = @"Select your root Steam folder.";
            if (steampath.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings1.Default.userpath = steampath.SelectedPath;
                Properties.Settings1.Default.Save();
                FileCheck();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileCheck();
        }

        // teehee
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _soundPlayer.Play();
            HandleClick(FlipPictureBox);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            _soundPlayer.Play();
            HandleClick(FlipPictureBox2);
        }

        private void HandleClick(Action flipAction)
        {
            if (_clickCount == 0)
            {
                _timer.Start();
            }

            _clickCount++;

            if (_clickCount >= 5)
            {
                flipAction();
                _timer.Stop();
                _clickCount = 0;
            }
        }

        private void TimerElapsed(object? sender, EventArgs e)
        {
            _clickCount = 0;
            _timer.Stop();
        }

        private void FlipPictureBox()
        {
            FlipImage(pictureBox1);
        }

        private void FlipPictureBox2()
        {
            FlipImage(pictureBox2);
        }

        private void FlipImage(PictureBox pictureBox)
        {
            pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox.Refresh();
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            _clickCount2++;

            if (_clickCount2 == 5 && DateTime.Now - _lastClickTime < TimeSpan.FromSeconds(5))
            {
                label1.ForeColor = Color.Blue;
                _soundPlayer2.Play();

                Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(_ =>
                {
                    label1.ForeColor = SystemColors.ControlText;
                });
            }

            _lastClickTime = DateTime.Now;
        }
    }
}