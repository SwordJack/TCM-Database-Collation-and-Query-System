using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * 首先建立一个Dtos目录，此目录下建立一个Dto(Data Transfer Object) Product，即创建一个Product.cs类，此方法返回一个Json的结果
 * Source: https://blog.csdn.net/kingyumao/article/details/81533880
 * 
 * （这里按照我自己的需要来建立。）
 */

namespace LandSpark_Query_API.Dtos
{
    public class CuttingSpecification
    {
        /// <summary>
        /// 切制规格代码。
        /// </summary>
        public string CuttingSpecification_Code { get; set; }

        /// <summary>
        /// 切制规格。
        /// </summary>
        public string CuttingSpecification_Name { get; set; }
    }
}
