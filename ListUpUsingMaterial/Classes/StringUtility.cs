using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ListUpUsingMaterial.Classes
{
    public static class StringUtility
    {
        /// <summary>
        /// 改行で分割する
        /// </summary>
        /// <param name="word">対称文字</param>
        /// <returns>分割した文字一覧</returns>
        public static string[] SplitNewLine(this string word) 
        {
            return word.Replace("\r\n", "\n").Split(new[] { '\n', '\r' });
        }

        /// <summary>
        /// 文字列の中から数字のみを抜き出して無理やりdouble値に変換する
        /// </summary>
        /// <param name="word">変換対象文字</param>
        /// <returns>変換後の値</returns>
        public static double ForceConvertToDouble(this string word) 
        {
            var reg = new Regex("[0-9.-]+");
            var numbers = reg.Match(word).Value;

            double.TryParse(numbers, out double value);

            return value;
        }
    }
}
