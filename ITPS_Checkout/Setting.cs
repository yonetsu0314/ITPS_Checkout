using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace MyLib {

    public class Settings {
        //コンストラクタ
        public Settings() {

        }

        //設定のプロパティ
        public string strCvsRootFolder_LIB { get; set; }
        public string strCvsRootFolder_CW { get; set; }
        public string strCvsRootFolder_BM { get; set; }
        public string strCvsRootFolder_WC { get; set; }
        public string strCvsRootFolder_SC { get; set; }
        public string strCvsRootFolder_ITPS { get; set; }
        public string strCvsFolder_LIB { get; set; }
        public string strCvsFolder_CW { get; set; }
        public string strCvsFolder_BM { get; set; }
        public string strCvsFolder_WC { get; set; }
        public string strCvsFolder_SC { get; set; }
        public string strCvsFolder_ITPS { get; set; }
        public string strCvsFolderItps_CWIMG { get; set; }
        public string strCvsFolderItps_CW { get; set; }
        public string strCvsFolderItps_BM { get; set; }
        public string strCvsFolderItps_WC { get; set; }
        public string strCvsFolderItps_SC { get; set; }
        public string strCvsFolderItps_ITPS { get; set; }
        public string strCvsCheckoutFolder_LIB { get; set; }
        public string strCvsCheckoutFolder_CW { get; set; }
        public string strCvsCheckoutFolder_BM { get; set; }
        public string strCvsCheckoutFolder_WC { get; set; }
        public string strCvsCheckoutFolder_SC { get; set; }
        public string strCvsCheckoutFolder_ITPS { get; set; }
        public string strAppFolder_CVSDIR { get; set; }
        public string strAppFolder_CW { get; set; }
        public string strAppFolder_BM { get; set; }
        public string strAppFolder_WC { get; set; }
        public string strAppFolder_SC { get; set; }
        public string strAppFolder_ITPS { get; set; }
        public int initDisplayIndex { get; set; }

        public string strAppProgNo13_CW { get; set; }
        public string strAppProgNo13_BM { get; set; }
        public string strAppProgNo13_WC { get; set; }
        public string strAppProgNo13_SC { get; set; }
        public string strAppProgNo13_ITPS { get; set; }

        public string strAppProgNo18_CW { get; set; }
        public string strAppProgNo18_BM { get; set; }
        public string strAppProgNo18_WC { get; set; }
        public string strAppProgNo18_SC { get; set; }
        public string strAppProgNo18_ITPS { get; set; }







        public void setDefaultParam() {

            strCvsRootFolder_LIB = @"\\katata\sanki\web_rcu\Library";
            strCvsRootFolder_CW = @"\\katata\sanki\presto\web_rcu\main";
            strCvsRootFolder_BM = @"\\katata\sanki\atlas202\web_rcu\main";
            strCvsRootFolder_WC = @"\\katata\sanki\DACS_TRI\WEB_RCU\main";
            strCvsRootFolder_SC = @"\\katata\sanki\tsc_r\WEB_RCU\main";
            strCvsRootFolder_ITPS = @"\\katata\sanki\ITPS\WEB_RCU\main";

            strCvsFolder_LIB = "lib230512";
            strCvsFolder_CW = "ccw_Ver4x_190_STD";
            strCvsFolder_BM = "Atlas_Ver3x_075_STD";
            strCvsFolder_WC = "DACSG_Ver5x_026_STD";
            strCvsFolder_SC = "TSC_Ver4x_108_STD";
            strCvsFolder_ITPS = "ips_Ver5x_073_STD";

            strCvsFolderItps_CWIMG = "cw_img_230323";
            strCvsFolderItps_CW = "ccw_Ver4x_192_STD";
            strCvsFolderItps_BM = "Atlas_Ver3x_075_STD";
            strCvsFolderItps_WC = "DACSG_Ver5x_025_STD";
            strCvsFolderItps_SC = "TSC_Ver4x_108_STD";
            strCvsFolderItps_ITPS = "ips_Ver5x_072_STD";

            strCvsCheckoutFolder_LIB = @"D:\Java-RCU\Library\Checkout";
            strCvsCheckoutFolder_CW = @"D:\Java-RCU\CCW-RV\CheckOut";
            strCvsCheckoutFolder_BM = @"D:\Java-RCU\ATLAS202\CheckOut";
            strCvsCheckoutFolder_WC = @"D:\Java-RCU\DACS_TRI\Checkout";
            strCvsCheckoutFolder_SC = @"D:\Java-RCU\TSC-R\Checkout";
            strCvsCheckoutFolder_ITPS = @"D:\Java-RCU\ITPS\Checkout";

            strAppFolder_CVSDIR = @"C:\Program Files (x86)\Gnu\WinCVS1.2_JP\cvs";
            strAppFolder_CW = @"D:\Java-RCU\CCW-RV";
            strAppFolder_BM = @"D:\Java-RCU\ATLAS202";
            strAppFolder_WC = @"D:\Java-RCU\DACS_TRI";
            strAppFolder_SC = @"D:\Java-RCU\TSC-R";
            strAppFolder_ITPS = @"D:\Java-RCU\ITPS";

            strAppProgNo13_CW = "W0537P";
            strAppProgNo13_BM = "W0392";
            strAppProgNo13_WC = "W0230";
            strAppProgNo13_SC = "W0437";
            strAppProgNo13_ITPS = "W0360X";

            strAppProgNo18_CW = "W0530L";
            strAppProgNo18_BM = "W0531";
            strAppProgNo18_WC = "W0533";
            strAppProgNo18_SC = "W0532";
            strAppProgNo18_ITPS = "W0534";




            initDisplayIndex = 1;
        }
    }

    public class SettingsIO {

            //コンストラクタ
        public SettingsIO() {

        }
        public void SaveToXmlFile(Settings param) {
            string fileName = GetSettingPath();
            System.IO.StreamWriter sw = null;

            try {
                //XmlSerializerオブジェクトを作成
                //オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Settings));
                //書き込むファイルを開く（UTF-8 BOM無し）
                sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));
                //シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, param);
                //ファイルを閉じる
                sw.Close();
            } catch (Exception ex) {
                if (sw != null) sw.Close();
                //例外をキャッチした時
                //例外を説明するメッセージを表示
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 現在の設定をXMLファイルに保存する
        /// </summary>
        public Settings LoadFromXmlFile() {
            string fileName = GetSettingPath();
            Settings param = new Settings();

            System.IO.StreamReader sr = null;

            try {
                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Settings));
                //読み込むファイルを開く
                sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                param = (Settings)serializer.Deserialize(sr);
                //ファイルを閉じる
                sr.Close();
            } catch (Exception ex) {
                if (sr != null) sr.Close();
                //例外をキャッチした時
                //例外を説明するメッセージを表示
                Debug.WriteLine(ex.Message);
                param.setDefaultParam();
            }
            return param;
        }

        public string GetSettingPath()
        {
            GetPath p = new GetPath();

            string path = p.WorkFolder + @"\" + p.AppNameWithOutExtention + ".config";
            return path;
        }
    }
}
