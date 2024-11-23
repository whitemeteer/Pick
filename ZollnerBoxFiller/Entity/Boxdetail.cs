using System;
using SqlSugar;

namespace Passion.Entity
{
    /// <summary>
    /// 料格
    /// </summary>
    [SugarTable("boxdetail", "Boxdetail 料格")]
    public class Boxdetail : EntityBase
    {
        /// <summary>
        /// 料格编码
        /// </summary>
        [SugarColumn(ColumnDescription = "料格编码", Length = 10)]
        public string Code { get; set; }

        /// <summary>
        /// 料箱码
        /// </summary>
        [SugarColumn(ColumnDescription = "料箱码", Length = 50)]
        public string BoxCode { get; set; }



        /// <summary>
        /// 绑定唯一码
        /// </summary>
        [SugarColumn(ColumnDescription = "绑定唯一码", Length = 255)]
        public string BindReeid { get; set; }


        /// <summary>
        /// 是否已删除
        /// </summary>
        [SugarColumn(ColumnDescription = "是否已删除")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [SugarColumn(ColumnDescription = "创建日期")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnDescription = "创建人", Length = 50)]
        public string CreatorId { get; set; }

    }
}
