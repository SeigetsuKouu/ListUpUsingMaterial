using ListUpUsingMaterial.Classes;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ListUpUsingMaterial.Windows.ListingUsingMaterialWindow
{
    class ListingUsingMaterialViewModel
    {
        public ListingUsingMaterialViewModel() 
        {
            model = new ListingUsingMaterialModel();

            FilePath = model.ObserveProperty(m=>m.FilePath).ToReactiveProperty();
            FilePath.Subscribe(_ => 
            { 
                model.FilePath = FilePath.Value;

                if (model.AviUtlObjects != null) 
                {
                    string[] ids = null;

                    // ニコニ・コモンズの素材IDと思われる物を取得
                    if (model.AviUtlObjects != null)
                    {
                        // ニコニ・コモンズのID持ち
                        var ncIDs =
                            model.AviUtlObjects
                                ?.Where(n => Regex.IsMatch(n.File.Name, "^.*(nc[0-9]+).*$"))
                                .Select(n => Regex.Matches(n.File.Name.Split(".").First(), "nc[0-9]+").First().Value)
                                .Distinct();

                        // ニコニコ静画のID持ち
                        var imIDs =
                            model.AviUtlObjects
                                ?.Where(n => Regex.IsMatch(n.File.Name, "^.*(im[0-9]+).*$"))
                                .Select(n => Regex.Matches(n.File.Name.Split(".").First(), "im[0-9]+").First().Value)
                                .Distinct();

                        ids = ncIDs.Union(imIDs).ToArray();

                    }

                    // 10個ずつ表示する
                    string text = string.Empty;
                    if (ids != null) 
                    {
                        for (int i = 0; i < Math.Ceiling(ids.Length / 10.0); i++)
                        {
                            text += string.Join(" ", ids.Skip(i * 10).Take(10));
                            text += "\n";
                        }
                    }
                    NicoCommonIDsString.Value = text;
                }
            }
            );

            NicoCommonIDsString = new ReactiveProperty<string>();

            UsingMaterials = model.ObserveProperty(m => m.UsingMaterials).ToReadOnlyReactivePropertySlim();

        }

        #region 変数
        /// <summary>
        /// モデル
        /// </summary>
        private ListingUsingMaterialModel model;
        #endregion 変数

        #region ReactiveProperties

        /// <summary>
        /// ファイルパス
        /// </summary>
        public ReactiveProperty<string> FilePath { get; private set; }

        /// <summary>
        /// AviUtlオブジェクト一覧
        /// </summary>
        public ReactiveProperty<IEnumerable<AviUtlObject>> AviUtlObjects { get; private set; }

        /// <summary>
        /// 使用素材一覧
        /// </summary>
        public ReadOnlyReactivePropertySlim<IEnumerable<FileInformation>> UsingMaterials { get; private set; }


        /// <summary>
        /// ニコニコモンズ用ID一覧
        /// </summary>
        public ReactiveProperty<string> NicoCommonIDsString { get; private set; }

        #endregion ReactiveProperties

    }



}
