// 标准管理平台

using System;
using SqlSugar;

namespace Passion.Entity
{

    [SugarTable("ZollnerNGLog", "NG日志")]
    public class ZollnerNGLog : EntityBaseId
    {
        /// <summary>
        /// NG箱码
        /// </summary>
        [SugarColumn(ColumnDescription = "NG箱码", Length = 50)]
        public string NGBoxCode { get; set; }

        /// <summary>
        /// 需求单号
        /// </summary>
        [SugarColumn(ColumnDescription = "需求单号", Length = 100)]
        public string OutboundID { get; set; }

        /// <summary>
        /// 任务单号
        /// </summary>
        [SugarColumn(ColumnDescription = "任务单号", Length = 50)]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// BatchBC
        /// </summary>
        [SugarColumn(ColumnDescription = "BatchBC", Length = 50)]
        public string BatchBC { get; set; }

        /// <summary>
        /// 线体
        /// </summary>
        [SugarColumn(ColumnDescription = "线体", Length = 50)]
        public string SMTLine { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [SugarColumn(ColumnDescription = "异常信息")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        [SugarColumn(ColumnDescription = "料号编号")]
        public string Component_BC { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnDescription = "数量")]
        public int? Qty { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        [SugarColumn(ColumnDescription = "箱号", Length = 50)]
        public string BoxCode { get; set; }

        /// <summary>
        /// NG时间
        /// </summary>
        [SugarColumn(ColumnDescription = "NG时间")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [SugarColumn(ColumnDescription = "是否删除")]
        public bool? isDelete { get; set; } = false;

        /// <summary>
        /// 是否是NG箱的物料
        /// </summary>
        [SugarColumn(ColumnDescription = "是否是NG箱的物料")]
        public bool? inBox { get; set; } = false;

        [SugarColumn(ColumnDescription = "NG时间", Length = 5)]
        public string TowerNo { get; set; }

    }
}
