using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Extension;

internal static class Number
{
    public static string ConvertPersianToEnglish(this string persianNumber)
    {
        StringBuilder englishNumber = new StringBuilder();

        
        foreach (char ch in persianNumber)
        {
            switch (ch)
            {
                case '۰': englishNumber.Append('0'); break;
                case '۱': englishNumber.Append('1'); break;
                case '۲': englishNumber.Append('2'); break;
                case '۳': englishNumber.Append('3'); break;
                case '۴': englishNumber.Append('4'); break;
                case '۵': englishNumber.Append('5'); break;
                case '۶': englishNumber.Append('6'); break;
                case '۷': englishNumber.Append('7'); break;
                case '۸': englishNumber.Append('8'); break;
                case '۹': englishNumber.Append('9'); break;
                default: englishNumber.Append(ch); break;  }
        }

        return englishNumber.ToString();
    }
}
