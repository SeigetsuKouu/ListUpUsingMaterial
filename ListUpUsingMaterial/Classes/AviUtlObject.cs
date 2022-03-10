using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Navigation;

namespace ListUpUsingMaterial.Classes
{
    /// <summary>
    /// AviUtlの各オブジェクト
    /// </summary>
    public class AviUtlObject : BindableBase
    {
        public AviUtlObject(string number)
        {
            ObjectNumber = number;
            values = new Dictionary<string, string>();
        }

        /// <summary>
        /// オブジェクト番号
        /// </summary>
        public string ObjectNumber {private set;get;}

        /// <summary>
        /// 値一覧
        /// </summary>
        private Dictionary<string, string> values;

        /// <summary>
        /// オブジェクト名称
        /// </summary>
        public string Name { get => GetValue("_name"); } 

        private FileInformation _file;
        /// <summary>
        /// ファイル情報
        /// </summary>
        public FileInformation File 
        {
            get 
            {
                if (_file == null) _file = new FileInformation(GetValue("file"));
                return _file;
            }
        }



        #region メソッド

        /// <summary>
        /// 値をセットする
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">値</param>
        public void SetValue(string key, string value) 
        {
            if (!values.ContainsKey(key)) 
            {
                values.Add(key, value);
            }
        }

        /// <summary>
        /// 値の削除を行う
        /// </summary>
        /// <param name="key">キー</param>
        public void RemoveValue(string key) 
        {
            if (values.ContainsKey(key)) 
            {
                values.Remove(key);
            }
        }

        /// <summary>
        /// 全ての値を削除する
        /// </summary>
        public void Clear() 
        {
            values.Clear();
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>取得した値</returns>
        public string GetValue(string key) 
        {
            if (values.ContainsKey(key))
            {
                return values[key];
            }
            else 
            {
                return "";
            }
        }

        #endregion メソッド

    }
}
