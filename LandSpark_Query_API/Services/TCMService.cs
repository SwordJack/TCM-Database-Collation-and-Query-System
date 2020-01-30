using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandSpark_Query_API.Dtos;     //此类需要通过“LandSpark_Query_API.Dtos”中生成数据格式。
//using System.Data.SqlClient;        //可用。

/*
 * 我们把获取数据的代码整理成一个ProductService, 然后保证程序运行的时候, 操作的是同一批数据。
 * 
 * Source: https://blog.csdn.net/kingyumao/article/details/82896974
 */

namespace LandSpark_Query_API.Services
{
    public class TCMService
    {
        public static TCMService Current { get; }
            = new TCMService();     //获取类的Current属性时，返回类的新实例。

        /// <summary>
        /// 切制规格表。
        /// </summary>
        public List<CuttingSpecification> CuttingSpecifications { get; }    //返回List<>泛型。
        
        private TCMService()
        {
            CuttingSpecifications = new List<CuttingSpecification>
            {
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "00",
                    CuttingSpecification_Name = "净制（如清除杂质、除去非药用部位）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "01",
                    CuttingSpecification_Name = "极薄片（0.5mm以下）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "02",
                    CuttingSpecification_Name = "薄片（1mm~2mm）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "03",
                    CuttingSpecification_Name = "厚片（2mm~4mm）、片",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "04",
                    CuttingSpecification_Name = "段",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "05",
                    CuttingSpecification_Name = "块",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "06",
                    CuttingSpecification_Name = "丝",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "07",
                    CuttingSpecification_Name = "碎末、粉",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "08",
                    CuttingSpecification_Name = "鲜药（鲜药榨汁、鲜药材）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "09",
                    CuttingSpecification_Name = "配方颗粒（单味中药饮片经提取等现代制药技术加工制成的颗粒剂）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "10",
                    CuttingSpecification_Name = "超微饮片",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "11",
                    CuttingSpecification_Name = "超微配方颗粒",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "12",
                    CuttingSpecification_Name = "配方颗粒（单味中药饮片直接粉碎成细粉，适当加辅料混合制粒制成的颗粒剂）",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "13",
                    CuttingSpecification_Name = "药用植物",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "14",
                    CuttingSpecification_Name = "草药",
                },
                new CuttingSpecification
                {
                    CuttingSpecification_Code = "99",
                    CuttingSpecification_Name = "中药材",
                },
            };

        }
    }
}
