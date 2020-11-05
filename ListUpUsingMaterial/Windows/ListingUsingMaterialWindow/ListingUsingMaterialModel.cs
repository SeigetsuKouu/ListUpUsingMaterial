using ListUpUsingMaterial.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ListUpUsingMaterial.Windows.ListingUsingMaterialWindow
{
    class ListingUsingMaterialModel:BindableBase
    {
        #region プロパティ

        private string _filePath;

        /// <summary>
        /// オブジェクトファイルへのパス
        /// </summary>
        public string FilePath 
        {
            get 
            { 
                return _filePath; 
            }
            set 
            {
                SetProperty(ref _filePath, value);
                AviUtlObjects = AviUtlObjectReader.ReadObjectFile(value);
            }
        }

        private IEnumerable<AviUtlObject> _aviUtlObjects = new AviUtlObject[] { new AviUtlObject("") };
        /// <summary>
        /// AviUtlのオブジェクトファイル一覧
        /// </summary>
        public IEnumerable<AviUtlObject> AviUtlObjects
        {
            get { return _aviUtlObjects; }
            set 
            { 
                SetProperty(ref _aviUtlObjects, value);
                ThrowPropertyChangedEvent(nameof(UsingMaterials));
            }
        }

        /// <summary>
        /// 仕様素材一覧
        /// </summary>
        public IEnumerable<FileInformation> UsingMaterials 
        {
            get 
            {
                return AviUtlObjects?
                    .Select(o => o.File)
                    .Where(f=>!string.IsNullOrEmpty(f.Name))
                    .GroupBy(f => f.Name)
                    .Select(g => g.FirstOrDefault());
            }
        }

        #endregion プロパティ
    }
}
