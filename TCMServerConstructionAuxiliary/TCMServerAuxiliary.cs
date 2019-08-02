using System;

namespace TCMServerConstructionAuxiliary
{
    //
    //执行对输入项或输入内容的检查。
    //
    public class InputCheck
    {
        /// <summary>
        ///
        /// 校验码按GB 12904及GB/T 17710校验码计算方法规定。<br />
        /// <br />
        /// 代码位置序号是指包括校验码在内的,由右至左的顺序号（校验码的代码位置序号为1）。<br />
        /// 校验码的计算步骤如下：<br />
        /// <br />
        /// a、从代码位置序号2开始，所有偶数位的数字代码求和；<br />
        /// b、将步骤a的和乘以3；<br />
        /// c、从代码位置序号3开始，所有奇数位的数字代码求和；<br />
        /// d、将步骤b与步骤c的结果相加；<br />
        /// e、用大于或等于步骤d所得结果且为10最小整数倍的数减去步骤d所得结果，其差即为所求校验码的值。<br />
        /// <br />
        /// 输入序列号文本，函数将根据校验码是否符合上述规则，返回“true”或“false”。<br />
        /// 
        /// </summary>
        /// <param name="codeText"></param>
        /// <returns></returns>
        public static bool CheckCodeVerification(string codeText)
        {
            try
            {
                //将序列号转换为整数型数组。
                int length = codeText.Length;
                int[] checkCode = new int[length];
                for (int i = 0; i < length; i++) checkCode[i] = int.Parse(codeText[i].ToString());

                //将数组倒序，并对校验码进行校验。
                Array.Reverse(checkCode);
                int sumOddPlace = 0, sumEvenPlace = 0;
                for (int i = 1; i < length; i++)        //序列号的第2位，数组索引为1，以此类推。
                {
                    if (i % 2 == 1) sumEvenPlace += checkCode[i];
                    else sumOddPlace += checkCode[i];
                }
                if (((sumOddPlace + sumEvenPlace * 3) % 10 + checkCode[0]) % 10 == 0) return (true);
                else return (false);
            }
            catch
            {
                return(false);
            }
        }
    }

    //
    //SELECT语句的生成。
    //
    public class SelectStatementGeneration
    {
        
    }
}
