using System;
using System.IO;                /* Path */

namespace MyLib {
    class GetPath {
        private string _AppPath;
        private string _AppNameWithOutExtention;
        private string _AppNameWithExtention;
        private string _AppDir;
        private string _WorkFolder;

        public GetPath() {
            _AppPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            _AppDir = Path.GetDirectoryName(_AppPath);
            _AppNameWithOutExtention = Path.GetFileNameWithoutExtension(_AppPath);
            _AppNameWithExtention = Path.GetFileName(_AppPath);
            _WorkFolder = Environment.ExpandEnvironmentVariables(@"%APPDATA%\" + _AppNameWithOutExtention);
        }
        public string AppPath {
            get { return _AppPath; }
            set { _AppPath = value; }
        }

        public string AppNameWithOutExtention {
            get { return _AppNameWithOutExtention; }
            set { _AppNameWithOutExtention = value; }
        }

        public string AppNameWithExtention {
            get { return _AppNameWithExtention; }
            set { _AppNameWithExtention = value; }
        }

        public string AppDir {
            get { return _AppDir; }
            set { _AppDir = value; }
        }
        public string WorkFolder {
            get { return _WorkFolder; }
            set { _WorkFolder = value; }

        }
    }
}
