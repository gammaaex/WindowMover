using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //MoveWindow関数の宣言
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y,int nWidth, int nHeight, int bRepaint);

        private void mainButton_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            // 全てのプロセスを列挙する
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                // メインウィンドウのタイトルがあるときだけ列挙する
                if (p.MainWindowTitle.Length != 0)
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("プロセス名：" + p.ProcessName);
                    Console.WriteLine("タイトル名：" + p.MainWindowTitle);
                    //ウィンドウの位置を(0, 10)に、サイズを300x200に変更する
                    if(p.MainWindowTitle != "Form1")
                    {
                        MoveWindow(p.MainWindowHandle, x, y, 600, 600, 1);
                    }
                    x += 10;
                    y += 10;
                }
            }
        }
    }
}
