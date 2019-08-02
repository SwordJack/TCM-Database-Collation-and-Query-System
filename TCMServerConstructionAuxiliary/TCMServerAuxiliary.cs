using System;

namespace TCMServerConstructionAuxiliary
{
    //
    //执行对输入项或输入内容的检查。
    //
    public class InputCheck
    {
        //
        //输入序列号文本，函数将根据校验码校验结果，返回“校验通过”或“校验不通过”。
        //
        //
        //“
        //校验码按GB 12904及GB/T 17710校验码计算方法规定。
        //代码位置序号是指包括校验码在内的,由右至左的顺序号（校验码的代码位置序号为1）。
        //
        //校验码的计算步骤如下：
        //
        //a、从代码位置序号2开始，所有偶数位的数字代码求和；
        //b、将步骤a的和乘以3；
        //c、从代码位置序号3开始，所有奇数位的数字代码求和；
        //d、将步骤b与步骤c的结果相加；
        //e、用大于或等于步骤d所得结果且为10最小整数倍的数减去步骤d所得结果，其差即为所求校验码的值。
        //”
        //
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
        string textBegin = "USE TraditionalChinese\nGO";    //所有查询语句均以此开头。
        string textMedicine = "";                           //药物查询的代码主体。
        string textFinish = "GO";                           //所有查询语句均以此结尾。


        //
        //查询数据库中所有中药的信息。
        //
        public static string SelectAllMedicine()
        {
            
            return "";
        }
    }
}
