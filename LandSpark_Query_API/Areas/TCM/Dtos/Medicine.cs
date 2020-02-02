using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace LandSpark_Query_API.Areas.TCM.Dtos
{
    public class Medicine
    {
        readonly string _medicineCode; //药物代码。
        
        /// <summary>
        /// Medicine类的空构造函数。
        /// </summary>
        protected Medicine() { }

        /// <summary>
        /// Medicine类带有药物代码（medicineCode）参数的构造函数。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        public Medicine(string medicineCode)
        {
            this._medicineCode = medicineCode;
        }

        public string MedicineCode
        {
            get { return _medicineCode; }
        }
    }

    public class MedicineImage : Medicine
    {
        string _imgFileName;  //图片文件名。

        /// <summary>
        /// MedicineImage类的空构造函数。
        /// </summary>
        protected MedicineImage() : base()
        {
            //利用基类的构造函数构造当前类的实例。
        }

        /// <summary>
        /// MedicineImage类带有药物代码（medicineCode）参数的构造函数。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        public MedicineImage(string medicineCode) : base(medicineCode)
        {
            //利用基类的构造函数构造当前类的实例。
        }

        /// <summary>
        /// 图片文件名。
        /// </summary>
        public string ImgFileName
        {
            get
            {
                return this._imgFileName;
            }

            set
            {
                this._imgFileName = value;
            }
        }
    }

    public class MedicineImageUpload : MedicineImage
    {
        int _affectedRowsCount; //受影响的行数。
        string _username;       //上传者的用户名。

        /// <summary>
        /// MedicineImageUpload类的空构造函数。
        /// </summary>
        private MedicineImageUpload() : base()
        {
            //利用基类的构造函数构造当前类的实例。
        }

        /// <summary>
        /// MedicineImage类带有药物代码（medicineCode）和用户名（username）参数的构造函数。
        /// </summary>
        /// <param name="medicineCode">药物代码</param>
        /// <param name="username">用户名</param>
        public MedicineImageUpload(string medicineCode, string username) : base(medicineCode)
        {
            //利用基类的构造函数构造当前类的实例。
            this._username = username;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return _username; }
        }

        /// <summary>
        /// 受影响的行数（亦即录入图片数目）
        /// </summary>
        public int AffectedRowsCount
        {
            get
            {
                return _affectedRowsCount;
            }

            set
            {
                _affectedRowsCount = value;
            }
        }

        public DataTable GetUploadStatus()
        {
            using (DataTable table = new DataTable("UploadStatus"))
            {
                string colUsername = "Username";            //“用户名”字段
                string colImgFileName = "FileName";         //“文件名”字段
                string colAffectedRowsCount = "Affected";   //“受影响行数”字段

                DataRow dataRow = table.NewRow();
                table.Columns.Add(colUsername);
                table.Columns.Add(colImgFileName);
                table.Columns.Add(colAffectedRowsCount);

                dataRow[colUsername] = this.Username;                   //添加“用户名”字段的值。
                dataRow[colImgFileName] = this.ImgFileName;             //添加“文件名”字段的值。
                dataRow[colAffectedRowsCount] = this.AffectedRowsCount; //添加“受影响行数”字段的值。
                table.Rows.Add(dataRow.ItemArray);                      //将行的值添加到表中。

                return table;
            }
        }
    }
}
