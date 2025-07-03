using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MyLib;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace ITPS_Checkout
{
    public partial class Form1 : Form {
        GetPath p = new GetPath();
        string workPath;
        SettingsIO settingsIo = new SettingsIO();
        Settings param = new Settings();

        public Form1() {
            InitializeComponent();
            workPath = p.WorkFolder + @"\";
            if (!Directory.Exists(workPath)) {
                Directory.CreateDirectory(workPath);
            }

            InitializeControlValues();

            }
            
private void InitializeControlValues() {

            param = settingsIo.LoadFromXmlFile();
 
            textBoxCvsRootLib.Text = param.strCvsRootFolder_LIB;
            textBoxCvsRootCw.Text = param.strCvsRootFolder_CW;
            textBoxCvsRootBm.Text = param.strCvsRootFolder_BM;
            textBoxCvsRootWc.Text = param.strCvsRootFolder_WC;
            textBoxCvsRootSc.Text = param.strCvsRootFolder_SC;
            textBoxCvsRootItps.Text = param.strCvsRootFolder_ITPS;

            textBoxCvsFolderLib.Text = param.strCvsFolder_LIB;
            textBoxCvsFolderCw.Text = param.strCvsFolder_CW;
            textBoxCvsFolderBm.Text = param.strCvsFolder_BM;
            textBoxCvsFolderWc.Text = param.strCvsFolder_WC;
            textBoxCvsFolderSc.Text = param.strCvsFolder_SC;
            textBoxCvsFolderItps.Text = param.strCvsFolder_ITPS;

            textBoxCcwImageFile.Text = param.strCvsFolderItps_CWIMG;
            textBoxItpsCw.Text = param.strCvsFolderItps_CW;
            textBoxItpsBm.Text = param.strCvsFolderItps_BM;
            textBoxItpsWc.Text = param.strCvsFolderItps_WC;
            textBoxItpsSc.Text = param.strCvsFolderItps_SC;

            textBoxCoLib.Text = param.strCvsCheckoutFolder_LIB;
            textBoxCoCw.Text = param.strCvsCheckoutFolder_CW;
            textBoxCoBm.Text = param.strCvsCheckoutFolder_BM;
            textBoxCoWc.Text = param.strCvsCheckoutFolder_WC;
            textBoxCoSc.Text = param.strCvsCheckoutFolder_SC;
            textBoxCoItps.Text = param.strCvsCheckoutFolder_ITPS;

            textBoxCvsPprogFolder.Text = param.strAppFolder_CVSDIR;
            textBoxAppFolderCw.Text = param.strAppFolder_CW;
            textBoxAppFolderBm.Text = param.strAppFolder_BM;
            textBoxAppFolderWc.Text = param.strAppFolder_WC;
            textBoxAppFolderSc.Text = param.strAppFolder_SC;
            textBoxAppFolderItps.Text = param.strAppFolder_ITPS;

            textBoxProgNameCw13.Text = param.strAppProgNo13_CW;
            textBoxProgNameBm13.Text = param.strAppProgNo13_BM;
            textBoxProgNameWc13.Text = param.strAppProgNo13_WC;
            textBoxProgNameSc13.Text = param.strAppProgNo13_SC;
            textBoxProgNameItps13.Text = param.strAppProgNo13_ITPS;

            textBoxProgNameCw18.Text = param.strAppProgNo18_CW;
            textBoxProgNameBm18.Text = param.strAppProgNo18_BM;
            textBoxProgNameWc18.Text = param.strAppProgNo18_WC;
            textBoxProgNameSc18.Text = param.strAppProgNo18_SC;
            textBoxProgNameItps18.Text = param.strAppProgNo18_ITPS;

            comboBox1.SelectedIndex = param.initDisplayIndex;
            TabSettings.SelectedIndex = comboBox1.SelectedIndex;
            makeAppFolder();

        }

        void makeAppFolder() {
            if (!string.IsNullOrWhiteSpace(textBoxProgNameCw13.Text)) textBoxProgFolderCw13.Text = textBoxProgNameCw13.Text + "-" + textBoxCvsFolderCw.Text + "-" + textBoxCvsFolderLib.Text + "-" + textBoxCcwImageFile.Text;
            if (!string.IsNullOrWhiteSpace(textBoxProgNameBm13.Text)) textBoxProgFolderBm13.Text = textBoxProgNameBm13.Text + "-" + textBoxCvsFolderBm.Text + "-" + textBoxCvsFolderLib.Text;
            if (!string.IsNullOrWhiteSpace(textBoxProgNameWc13.Text)) textBoxProgFolderWc13.Text = textBoxProgNameWc13.Text + "-" + textBoxCvsFolderWc.Text + "-" + textBoxCvsFolderLib.Text;
            if (!string.IsNullOrWhiteSpace(textBoxProgNameSc13.Text)) textBoxProgFolderSc13.Text = textBoxProgNameSc13.Text + "-" + textBoxCvsFolderSc.Text + "-" + textBoxCvsFolderLib.Text;
            if (!string.IsNullOrWhiteSpace(textBoxProgNameItps13.Text)) textBoxProgFolderItps13.Text = textBoxProgNameItps13.Text + "-" + textBoxCvsFolderLib.Text + "-" + textBoxCvsFolderItps.Text + "-" +
                                                                                                        textBoxItpsCw.Text + "-" + textBoxItpsBm.Text + "-" + textBoxItpsSc.Text + "-" + textBoxItpsWc.Text;


            if (!string.IsNullOrEmpty(textBoxProgNameCw18.Text)) textBoxProgFolderCw18.Text = textBoxProgNameCw18.Text + "-" + textBoxCvsFolderCw.Text + "-" + textBoxCvsFolderLib.Text + "_J8" + "-" + textBoxCcwImageFile.Text;
            if (!string.IsNullOrEmpty(textBoxProgNameBm18.Text)) textBoxProgFolderBm18.Text = textBoxProgNameBm18.Text + "-" + textBoxCvsFolderBm.Text + "-" + textBoxCvsFolderLib.Text + "_J8";
            if (!string.IsNullOrEmpty(textBoxProgNameWc18.Text)) textBoxProgFolderWc18.Text = textBoxProgNameWc18.Text + "-" + textBoxCvsFolderWc.Text + "-" + textBoxCvsFolderLib.Text + "_J8";
            if (!string.IsNullOrEmpty(textBoxProgNameSc18.Text)) textBoxProgFolderSc18.Text = textBoxProgNameSc18.Text + "-" + textBoxCvsFolderSc.Text + "-" + textBoxCvsFolderLib.Text + "_J8";
            if (!string.IsNullOrEmpty(textBoxProgNameItps18.Text)) textBoxProgFolderItps18.Text = textBoxProgNameItps18.Text + "-" + textBoxCvsFolderLib.Text + "_J8" + "-" + textBoxCvsFolderItps.Text + "-" +
                                                                                                    textBoxItpsCw.Text + "-" + textBoxItpsBm.Text + "-" + textBoxItpsSc.Text + "-" + textBoxItpsWc.Text;

            textBoxItpsCwImageFile.Text = textBoxCcwImageFile.Text;
        }

        private Process checkout(string bat, string cvsRoot, string cvsFld, string CoFolder) {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer;

            bat = workPath + bat;

            writer = new StreamWriter(bat, false, sjisEnc);

            writer.WriteLine("@echo off");
            writer.WriteLine("if not exist " + CoFolder + " (");
            writer.WriteLine("mkdir " + "\"" + CoFolder + "\"");
            writer.WriteLine(")");
            writer.WriteLine("pushd " + "\"" + CoFolder + "\"");
            writer.WriteLine("set CVSREAD=1");
            writer.WriteLine("set CVSROOT=" + cvsRoot);
            writer.WriteLine("if not exist " + cvsFld + " (");
            writer.WriteLine("\"" + textBoxCvsPprogFolder.Text + "\"" + " checkout -P " + cvsFld);
            writer.WriteLine(") else (");
            writer.WriteLine("@echo --------------------------------------------------------------------");
            writer.WriteLine("@echo すでに " + cvsFld + " はチェクアウトされています。");
            writer.WriteLine("@echo --------------------------------------------------------------------");
            writer.WriteLine(")");
            writer.WriteLine("popd");
            writer.Close();
            return runCmd(bat,cvsFld);
        }
        private Process collect(string bat, string appRootFld, string appName, string libCoFld, string appCoFld, string mcn) {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer;

            bat = workPath + bat;

            writer = new StreamWriter(bat, false, sjisEnc);

            writer.WriteLine("@echo off");
            writer.WriteLine("set LIB_DIR=" + libCoFld);               // チェックアウトされたライブラリのフォルダー
            writer.WriteLine("set APP_DIR=" + appCoFld);               // チェックアウトされたアプリのフォルダー
            writer.WriteLine("set PRODUCT_DIR=" + appName);            // 完成品のフォルダー
            writer.WriteLine("set NO_FOLDER=");
            writer.WriteLine("if exist " + appRootFld + @"\" + appName + " goto exist_end"); // 完成品のフォルダがすでにある
            writer.WriteLine("if exist %LIB_DIR% goto next1");          // チェックアウトされたライブラリのフォルダーがある
            writer.WriteLine("set NO_FOLDER=%LIB_DIR%");
            writer.WriteLine("goto not_exist_end");                     // チェックアウトされたライブラリのフォルダーが無い
            writer.WriteLine(":next1");
            writer.WriteLine("if exist %APP_DIR% goto next2");          // チェックアウトされたアプリのフォルダーがある
            writer.WriteLine("set NO_FOLDER=%APP_DIR%");
            writer.WriteLine("goto not_exist_end");                     // チェックアウトされたアプリのフォルダーがない
            writer.WriteLine(":next2");
            writer.WriteLine("if exist " + appRootFld + " goto next3"); // 完成品のルートフォルダーがある
            writer.WriteLine("md " + appRootFld);                       // 完成品のルートフォルダーを作成
            writer.WriteLine(":next3");
            writer.WriteLine("pushd " + "\"" + appRootFld + "\"");
            //           writer.WriteLine("cd /d " + appRootFld);                       // 完成品のルートフォルダーに移動
            writer.WriteLine("md %PRODUCT_DIR%");                       // 完成品フォルダーを作成
            writer.WriteLine("cd /d %PRODUCT_DIR%");                       // 完成品フォルダーに移動
            writer.WriteLine(@"xcopy /E /R /K /Y %LIB_DIR%\*.* *.*");   // ライブラリをコピー
            writer.WriteLine(@"rd /S /Q ishida\" + mcn);                // 対象機器のフォルダーを削除
            writer.WriteLine(@"xcopy /E /R /K /Y %APP_DIR%\*.* *.*");
            if(libCoFld.Contains("_J8")) {  // java 1.8
                writer.WriteLine("xcopy /E /R /K /Y " + mcn + @"_J8\*.*");
            }
            if (string.Compare(mcn, "cw") == 0) {
                writer.WriteLine(@"xcopy /R /K /Y CCW_DISTRIBUTION_VERSION\*.*");
            } else {
                writer.WriteLine(@"xcopy /R /K /Y CCW_DUMMY_VERSION\*.*");
            }
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo [ %PRODUCT_DIR% ] を作成しました。");
            writer.WriteLine("@echo Prepare に移動して Prepareを実行して下さい。");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("popd");
            writer.WriteLine("goto end");
            writer.WriteLine(":exist_end");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo すでにフォルダーが存在します。 [ %PRODUCT_DIR% ]");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("goto end");
            writer.WriteLine(":not_exist_end");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo フォルダーが存在しません。 [ %NO_FOLDER% ]");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine(":end");
#if _CMD_DISP_
            writer.WriteLine("pause");
#endif
            writer.Close();
            return runCmd(bat,appName);
        }
        private Process itpsCollect(string bat, int ver) {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer;

            bat = workPath + bat;

            writer = new StreamWriter(bat, false, sjisEnc);

            writer.WriteLine("@echo off");
            if (ver == 18) {
                writer.WriteLine("set LIB_DIR=" + textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text + "_J8");               // チェックアウトされたライブラリのフォルダー
                writer.WriteLine("set PRODUCT_DIR=" + textBoxAppFolderItps.Text + @"\" + textBoxProgFolderItps18.Text);
            } else {
                writer.WriteLine("set LIB_DIR=" + textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text);               // チェックアウトされたライブラリのフォルダー
                writer.WriteLine("set PRODUCT_DIR=" + textBoxAppFolderItps.Text + @"\" + textBoxProgFolderItps13.Text);
            }
            writer.WriteLine("set ITPS_DIR=" + textBoxCoItps.Text + @"\" + textBoxCvsFolderItps.Text);
            writer.WriteLine("set CW_DIR=" + textBoxCoCw.Text + @"\" + textBoxItpsCw.Text);
            writer.WriteLine("set BM_DIR=" + textBoxCoBm.Text + @"\" + textBoxItpsBm.Text);
            writer.WriteLine("set WC_DIR=" + textBoxCoWc.Text + @"\" + textBoxItpsWc.Text);
            writer.WriteLine("set SC_DIR=" + textBoxCoSc.Text + @"\" + textBoxItpsSc.Text);
            string imgJar = textBoxItpsCwImageFile.Text;
            imgJar = imgJar.Replace("cw_img", "cw-img");
            writer.WriteLine(@"set CW_IMAGE_FILE=%CW_DIR%\" + imgJar + ".jar");
            writer.WriteLine("set NO_FOLDER=");
            writer.WriteLine("if exist %PRODUCT_DIR% goto exist_end");
            writer.WriteLine("if exist %LIB_DIR% goto next1");
            writer.WriteLine("set NO_FOLDER =%LIB_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next1");
            writer.WriteLine("if exist %ITPS_DIR% goto next2");
            writer.WriteLine("set NO_FOLDER =%ITPS_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next2");
            writer.WriteLine("if exist %CW_DIR% goto next3");
            writer.WriteLine("set NO_FOLDER =%CW_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next3");
            writer.WriteLine("if exist %BM_DIR% goto next4");
            writer.WriteLine("set NO_FOLDER =%BM_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next4");
            writer.WriteLine("if exist %WC_DIR% goto next5");
            writer.WriteLine("set NO_FOLDER =%WC_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next5");
            writer.WriteLine("if exist %SC_DIR% goto next6");
            writer.WriteLine("set NO_FOLDER =%SC_DIR%");
            writer.WriteLine("goto not_exist_end");
            writer.WriteLine(":next6");
            writer.WriteLine("if exist " + textBoxAppFolderItps.Text + " goto next7"); // 完成品のルートフォルダーがある
            writer.WriteLine("md " + textBoxAppFolderItps.Text);                       // 完成品のルートフォルダーを作成
            writer.WriteLine(":next7");
            writer.WriteLine("pushd " + "\"" + textBoxAppFolderItps.Text + "\"");
            //           writer.WriteLine("cd /d " + textBoxAppFolderItps.Text);                       // 完成品のルートフォルダーに移動
            writer.WriteLine("md %PRODUCT_DIR%");
            writer.WriteLine("cd /d %PRODUCT_DIR%");
            writer.WriteLine(@"xcopy /E /R /K /Y %LIB_DIR%\*.* *.*");
            writer.WriteLine(@"rd /S /Q ishida\wc");
            writer.WriteLine(@"rd /S /Q ishida\sc");
            writer.WriteLine(@"rd /S /Q ishida\ips");
            writer.WriteLine(@"rd /S /Q ishida\cw");
            writer.WriteLine(@"rd /S /Q ishida\bm");
            writer.WriteLine(@"xcopy /E /R /K /Y /I %CW_DIR%\ishida\cw ishida\cw");
            writer.WriteLine(@"xcopy /E /R /K /Y /I %CW_DIR%\theme theme");
            writer.WriteLine(@"xcopy /R /K /Y %CW_IMAGE_FILE% *.*");
            writer.WriteLine(@"xcopy /E /R /K /Y /I %BM_DIR%\ishida\bm ishida\bm");
            writer.WriteLine(@"xcopy /E /R /K /Y /I %SC_DIR%\ishida\sc ishida\sc");
            writer.WriteLine(@"xcopy /E /R /K /Y /I %WC_DIR%\ishida\wc ishida\wc");
            writer.WriteLine(@"xcopy /E /R /K /Y %ITPS_DIR%\*.*");
            if (ver == 18) {  // java 1.8
                writer.WriteLine(@"xcopy /E /R /K /Y IPS_J8\*.*");
            }
            writer.WriteLine(@"xcopy /R /K /Y CCW_DISTRIBUTION_VERSION\*.*");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo [ %PRODUCT_DIR% ] を作成しました。");
            writer.WriteLine("@echo Prepare に移動して Prepareを実行して下さい。");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("popd");
            writer.WriteLine("goto end");
            writer.WriteLine(":exist_end");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo すでにフォルダーが存在します。 [ %PRODUCT_DIR% ]");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("goto end");
            writer.WriteLine(":not_exist_end");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine("@echo フォルダーが存在しません。 [ %NO_FOLDER% ]");
            writer.WriteLine("@echo ----------------------------------------------------------------");
            writer.WriteLine(":end");
#if _CMD_DISP_
            writer.WriteLine("pause");
#endif
            writer.Close();
            return runCmd(bat,"ITPS");
        }

        private void buttonCollect_Click(object sender, EventArgs e) {

            Button x = (Button)sender;
            Process p1 = null, p2 = null, p3 = null, p4 = null, p5 = null, p6 = null, p7 = null;
            if (string.Compare(x.Name, "buttonCollectCw") == 0) {
                if (checkBoxCwJ13.Checked == true) {
                    p1 = checkout("cw_1.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text, textBoxCoLib.Text);
                }
                if (checkBoxCwJ18.Checked == true) {
                    p2 = checkout("cw_2.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text + "_J8", textBoxCoLib.Text);
                }
                if (checkBoxCwJ13.Checked == true || checkBoxCwJ18.Checked == true) {
                    p3 = checkout("cw_3.bat", textBoxCvsRootCw.Text, textBoxCvsFolderCw.Text, textBoxCoCw.Text);
                    Boolean pEnd = false;
                    while(!pEnd) {
                        pEnd = ((p1 != null && p1.HasExited) || p1 == null);
                        pEnd = ((p2 != null && p2.HasExited) || p2 == null) && pEnd;
                        pEnd = ((p3 != null && p3.HasExited) || p3 == null) && pEnd;
                        Application.DoEvents();
                    }
                    if (checkBoxCwJ18.Checked == true) collect("cw_collect18.bat", textBoxAppFolderCw.Text, textBoxProgFolderCw18.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text + "_J8", textBoxCoCw.Text + @"\" + textBoxCvsFolderCw.Text, "cw");
                    if (checkBoxCwJ13.Checked == true) collect("cw_collect13.bat", textBoxAppFolderCw.Text, textBoxProgFolderCw13.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text, textBoxCoCw.Text + @"\" + textBoxCvsFolderCw.Text, "cw");
                }

            } else if (string.Compare(x.Name, "buttonCollectBm") == 0) {
                if (checkBoxBmJ13.Checked == true) {
                    p1 = checkout("bm_1.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text, textBoxCoLib.Text);
                }
                if (checkBoxBmJ18.Checked == true) {
                    p2 = checkout("bm_2.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text + "_J8", textBoxCoLib.Text);
                }
                if (checkBoxBmJ13.Checked == true || checkBoxBmJ18.Checked == true) {
                    p3 = checkout("bm_3.bat", textBoxCvsRootBm.Text, textBoxCvsFolderBm.Text, textBoxCoBm.Text);
                    Boolean pEnd = false;
                    while (!pEnd) {
                        pEnd = ((p1 != null && p1.HasExited) || p1 == null);
                        pEnd = ((p2 != null && p1.HasExited) || p3 == null) && pEnd;
                        pEnd = ((p3 != null && p1.HasExited) || p3 == null) && pEnd;
                        Application.DoEvents();
                    }
                    if (checkBoxBmJ18.Checked == true) collect("bm_collect18.bat", textBoxAppFolderBm.Text, textBoxProgFolderBm18.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text + "_J8", textBoxCoBm.Text + @"\" + textBoxCvsFolderBm.Text, "bm");
                    if (checkBoxBmJ13.Checked == true) collect("bm_collect13.bat", textBoxAppFolderBm.Text, textBoxProgFolderBm13.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text, textBoxCoBm.Text + @"\" + textBoxCvsFolderBm.Text, "bm");
                }
            } else if (string.Compare(x.Name, "buttonCollectWc") == 0) {
                if (checkBoxWcJ13.Checked == true) {
                    p1 = checkout("Wc_1.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text, textBoxCoLib.Text);
                }
                if (checkBoxWcJ18.Checked == true) {
                    p2 = checkout("Wc_2.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text + "_J8", textBoxCoLib.Text);
                }
                if (checkBoxWcJ13.Checked == true || checkBoxWcJ18.Checked == true) {
                    p3 = checkout("Wc_3.bat", textBoxCvsRootWc.Text, textBoxCvsFolderWc.Text, textBoxCoWc.Text);
                    Boolean pEnd = false;
                    while (!pEnd) {
                        pEnd = ((p1 != null && p1.HasExited) || p1 == null);
                        pEnd = ((p2 != null && p2.HasExited) || p2 == null) && pEnd;
                        pEnd = ((p3 != null && p3.HasExited) || p3 == null) && pEnd;
                        Application.DoEvents();
                    }
                    if (checkBoxWcJ18.Checked == true) collect("wc_collect18.bat", textBoxAppFolderWc.Text, textBoxProgFolderWc18.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text + "_J8", textBoxCoWc.Text + @"\" + textBoxCvsFolderWc.Text, "wc");
                    if (checkBoxWcJ13.Checked == true) collect("wc_collect13.bat", textBoxAppFolderWc.Text, textBoxProgFolderWc13.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text, textBoxCoWc.Text + @"\" + textBoxCvsFolderWc.Text, "wc");
                }
            } else if (string.Compare(x.Name, "buttonCollectSc") == 0) {
                if (checkBoxScJ13.Checked == true) {
                    p1 = checkout("Sc_1.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text, textBoxCoLib.Text);
                }
                if (checkBoxScJ18.Checked == true) {
                    p2 = checkout("Sc_2.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text + "_J8", textBoxCoLib.Text);
                }
                if (checkBoxScJ13.Checked == true || checkBoxScJ18.Checked == true) {
                    p3 = checkout("Sc_3.bat", textBoxCvsRootSc.Text, textBoxCvsFolderSc.Text, textBoxCoSc.Text);
                    Boolean pEnd = false;
                    while (!pEnd) {
                        pEnd = ((p1 != null && p1.HasExited) || p1 == null);
                        pEnd = ((p2 != null && p2.HasExited) || p2 == null) && pEnd;
                        pEnd = ((p3 != null && p3.HasExited) || p3 == null) && pEnd;
                        Application.DoEvents();
                    }
                    if (checkBoxScJ18.Checked == true) collect("sc_collect18.bat", textBoxAppFolderSc.Text, textBoxProgFolderSc18.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text + "_J8", textBoxCoSc.Text + @"\" + textBoxCvsFolderSc.Text, "sc");
                    if (checkBoxScJ13.Checked == true) collect("sc_collect13.bat", textBoxAppFolderSc.Text, textBoxProgFolderSc13.Text, textBoxCoLib.Text + @"\" + textBoxCvsFolderLib.Text, textBoxCoSc.Text + @"\" + textBoxCvsFolderSc.Text, "sc");
                }
            } else if (string.Compare(x.Name, "buttonCollectItps") == 0) {
                if (checkBoxItpsJ13.Checked == true) {
                    p1 = checkout("Itps_1.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text, textBoxCoLib.Text);
                }
                if (checkBoxItpsJ18.Checked == true) {
                    p2 = checkout("Itps_2.bat", textBoxCvsRootLib.Text, textBoxCvsFolderLib.Text + "_J8", textBoxCoLib.Text);
                }

                if (checkBoxItpsJ13.Checked == true || checkBoxItpsJ18.Checked == true) {
                    p3 = checkout("itsp_3.bat", textBoxCvsRootItps.Text, textBoxCvsFolderItps.Text, textBoxCoItps.Text);
                }
                if (checkBoxItpsJ13.Checked == true || checkBoxItpsJ18.Checked == true) {
                    p4 = checkout("itps_cw_3.bat", textBoxCvsRootCw.Text, textBoxItpsCw.Text, textBoxCoCw.Text);
                }
                if (checkBoxItpsJ13.Checked == true || checkBoxItpsJ18.Checked == true) {
                    p5 = checkout("itps_bm_3.bat", textBoxCvsRootBm.Text, textBoxItpsBm.Text, textBoxCoBm.Text);
                }
                if (checkBoxItpsJ13.Checked == true || checkBoxItpsJ18.Checked == true) {
                    p6 = checkout("itps_Wc_3.bat", textBoxCvsRootWc.Text, textBoxItpsWc.Text, textBoxCoWc.Text);
                }
                if (checkBoxItpsJ13.Checked == true || checkBoxItpsJ18.Checked == true) {
                    p7 = checkout("itps_Sc_3.bat", textBoxCvsRootSc.Text, textBoxItpsSc.Text, textBoxCoSc.Text);
                }
                Boolean pEnd = false;
                while (!pEnd) {
                    pEnd = ((p1 != null && p1.HasExited) || p1 == null);
                    pEnd = ((p2 != null && p2.HasExited) || p2 == null) && pEnd;
                    pEnd = ((p3 != null && p3.HasExited) || p3 == null) && pEnd;
                    pEnd = ((p4 != null && p4.HasExited) || p4 == null) && pEnd;
                    pEnd = ((p5 != null && p5.HasExited) || p5 == null) && pEnd;
                    pEnd = ((p6 != null && p6.HasExited) || p6 == null) && pEnd;
                    pEnd = ((p7 != null && p7.HasExited) || p7 == null) && pEnd;
                    Application.DoEvents();
                }
                if (checkBoxItpsJ18.Checked == true) {
                    itpsCollect("itpsAll18.bat", 18);
                }
                if (checkBoxItpsJ13.Checked == true) {
                    itpsCollect("itpsAll13.bat", 13);
                }
            }
        }
#if _CMD_DISP_
        private Process runCmd(string fName, string title) {
            var path = fName;
            Process p = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Environment.GetEnvironmentVariable("ComSpec"),
                    CreateNoWindow = false,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    UseShellExecute = false,
                    Arguments = "/c " + path,
                    WorkingDirectory = workPath,
                    Verb = "RunAs",
                }
            };
            p.Start();
            return p;
        }
#else
    private Process runCmd(string fName,string title) {
        FormConsole output = new FormConsole(fName, workPath, title);
            return output.getProc();
        }
#endif
        private void tabControl1_Click(object sender, EventArgs e) {
            makeAppFolder();
        }

        private void textBox_TextChanged(object sender, EventArgs e) {
            makeAppFolder();
        }
        private void textBoxCcwImageFile_TextChanged(object sender, EventArgs e) {
            makeAppFolder();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {

            param.strCvsRootFolder_LIB = textBoxCvsRootLib.Text;
            param.strCvsRootFolder_CW = textBoxCvsRootCw.Text;
            param.strCvsRootFolder_BM = textBoxCvsRootBm.Text;
            param.strCvsRootFolder_WC = textBoxCvsRootWc.Text;
            param.strCvsRootFolder_SC = textBoxCvsRootSc.Text;
            param.strCvsRootFolder_ITPS = textBoxCvsRootItps.Text;

            param.strCvsFolder_LIB = textBoxCvsFolderLib.Text;
            param.strCvsFolder_CW = textBoxCvsFolderCw.Text;
            param.strCvsFolder_BM = textBoxCvsFolderBm.Text;
            param.strCvsFolder_WC = textBoxCvsFolderWc.Text;
            param.strCvsFolder_SC = textBoxCvsFolderSc.Text;
            param.strCvsFolder_ITPS = textBoxCvsFolderItps.Text;

            param.strCvsFolderItps_CWIMG = textBoxCcwImageFile.Text;
            param.strCvsFolderItps_CW = textBoxItpsCw.Text;
            param.strCvsFolderItps_BM = textBoxItpsBm.Text;
            param.strCvsFolderItps_WC = textBoxItpsWc.Text;
            param.strCvsFolderItps_SC = textBoxItpsSc.Text;

            param.strCvsCheckoutFolder_LIB = textBoxCoLib.Text;
            param.strCvsCheckoutFolder_CW = textBoxCoCw.Text;
            param.strCvsCheckoutFolder_BM = textBoxCoBm.Text;
            param.strCvsCheckoutFolder_WC = textBoxCoWc.Text;
            param.strCvsCheckoutFolder_SC = textBoxCoSc.Text;
            param.strCvsCheckoutFolder_ITPS = textBoxCoItps.Text;

            param.strAppFolder_CVSDIR = textBoxCvsPprogFolder.Text;
            param.strAppFolder_CW = textBoxAppFolderCw.Text;
            param.strAppFolder_BM = textBoxAppFolderBm.Text;
            param.strAppFolder_WC = textBoxAppFolderWc.Text;
            param.strAppFolder_SC = textBoxAppFolderSc.Text;
            param.strAppFolder_ITPS = textBoxAppFolderItps.Text;

            param.strAppProgNo13_CW = textBoxProgNameCw13.Text;
            param.strAppProgNo13_BM = textBoxProgNameBm13.Text; 
            param.strAppProgNo13_WC = textBoxProgNameWc13.Text; 
            param.strAppProgNo13_SC = textBoxProgNameSc13.Text; 
            param.strAppProgNo13_ITPS = textBoxProgNameItps13.Text;

            param.strAppProgNo18_CW = textBoxProgNameCw18.Text;
            param.strAppProgNo18_BM = textBoxProgNameBm18.Text;
            param.strAppProgNo18_WC = textBoxProgNameWc18.Text;
            param.strAppProgNo18_SC = textBoxProgNameSc18.Text;
            param.strAppProgNo18_ITPS = textBoxProgNameItps18.Text;

            param.initDisplayIndex = comboBox1.SelectedIndex;

            settingsIo.SaveToXmlFile(param);
        }
    }
}