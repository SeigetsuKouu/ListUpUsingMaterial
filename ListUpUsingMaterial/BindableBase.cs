using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ListUpUsingMaterial
{
    /// <summary>
    /// バインド対称クラス用のベースクラス
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 値のセット
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティ変更イベントを発行する
        /// </summary>
        /// <param name="propertyName">プロパティ名称</param>
        protected void ThrowPropertyChangedEvent(string propertyName) 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
