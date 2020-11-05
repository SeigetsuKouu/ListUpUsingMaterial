using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ListUpUsingMaterial.Classes
{
    public class AviUtlObjectReader
    {
        /// <summary>
        /// オブジェクトファイルを読み込む
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AviUtlObject[] ReadObjectFile(string path) 
        {
            if (!File.Exists(path)) return null;

            string objectData;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(path, System.Text.Encoding.GetEncoding("shift_jis"))) 
            {
                objectData = reader.ReadToEnd();
            }

            double id = -1;
            var readObjects = new List<AviUtlObject>();
            AviUtlObject newObject = null;
            foreach (var line in objectData.SplitNewLine()) 
            {
                if (string.IsNullOrEmpty(line)) continue;

                if (line.Contains("["))
                {
                    // 各オブジェクトの区切り部分が [数値] なので切り替え
                    if (newObject != null) readObjects.Add(newObject);
                    newObject = new AviUtlObject(line);
                }
                else 
                {
                    // 各オブジェクトの設定値は key=value になっている
                    var keyValue = line.Split("=");
                    newObject.SetValue(keyValue[0], keyValue[1]);
                }
            }
            if (newObject != null) readObjects.Add(newObject);

            return readObjects.ToArray();
           
        }
    }
}
