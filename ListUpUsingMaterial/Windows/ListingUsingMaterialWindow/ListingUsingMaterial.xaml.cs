using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListUpUsingMaterial.Windows.ListingUsingMaterialWindow
{
    /// <summary>
    /// ListingUsingMaterial.xaml の相互作用ロジック
    /// </summary>
    public partial class ListingUsingMaterial : Window
    {
        public ListingUsingMaterial()
        {
            InitializeComponent();
            viewModel = new ListingUsingMaterialViewModel();
            DataContext = viewModel;
        }

        #region 変数

        ListingUsingMaterialViewModel viewModel;

        #endregion 変数

        #region イベント処理
        /// <summary>
        /// ドラッグオーバー時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                e.Effects = System.Windows.DragDropEffects.Copy;
            }
            else
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
            e.Handled = true;
        }


        /// <summary>
        /// ファイルドロップ時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Drop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
            if (dropFiles == null) return;

            (sender as TextBox).Text = dropFiles.First();
        }

        #endregion イベント処理

        /// <summary>
        /// テキスト入力欄ダブルクリック時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;

            var dialog = new OpenFileDialog()
            {
                FileName = textBox.Text
            };

            dialog.Filter = "オブジェクトファイル（*.exo）|*.exo|全てのファイル（*.*）|*.*";

            if (dialog.ShowDialog() == true) 
            {
                textBox.Text = dialog.FileName;
            }
        }
    }
}
