namespace ListUpUsingMaterial.Classes
{
    public class FileInformation
    {
        public FileInformation(string filePath) 
        {
            Path = filePath;
        }

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// ファイル名
        /// </summary>
        public string Name { get => System.IO.Path.GetFileName(Path); }

        /// <summary>
        /// 拡張子
        /// </summary>
        public string Extention { get => System.IO.Path.GetExtension(Path); }
    }
}
