using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITPS_Checkout {
    public partial class FormConsole : Form {

        public delegate void DelegateUpdateText(string line);
        Process prcs = null;
 
        public FormConsole(string name,string path,string title) {
            InitializeComponent();
            prcs = runCmd(name, path);
            this.Text = title;
            this.Visible = true;
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();      //スレッド実行
        }

        public Process getProc() {
            return prcs;
        }
        private void ThreadProc() {
            if (prcs != null) {
                string line;
                while ((line = prcs.StandardOutput.ReadLine()) != null) {
                    UpdateText(line);
                }
            }
        }

        private void UpdateText(string msg) {
             if (this.InvokeRequired) {
                DelegateUpdateText d = new DelegateUpdateText(UpdateText);
                this.BeginInvoke(d, new object[] { msg });
                return;
            }
            if (msg != "") {
                textBoxConsole.AppendText(msg + "\r\n");
            }
        }
        private Process runCmd(string fName,string workPath) {
            ProcessStartInfo psInfo = new ProcessStartInfo();
            psInfo.FileName = Environment.GetEnvironmentVariable("ComSpec"); // 実行するファイル
            psInfo.Arguments = "/c " + fName;       // 引数
            psInfo.WorkingDirectory = workPath;     // 
            psInfo.CreateNoWindow = true;           // コンソール・ウィンドウを開かない
                                                    //            psInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            psInfo.UseShellExecute = false;         // シェル機能を使用しない
            psInfo.RedirectStandardOutput = true;   // 標準出力をリダイレクト
            Process p = Process.Start(psInfo);
//            p.PriorityClass = ProcessPriorityClass.Idle;
            return p;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
