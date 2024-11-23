using System;
using SqlSugar;

namespace Passion.Entity
{
    [SugarTable("Zollner_inoutorder", "Zollner_InOutOrder出入库单据")]

    public class Zollner_InOutOrder : EntityBase
    {
        [SugarColumn(ColumnDescription = "任务单号", Length = 50)]
        public string OutOrderNo { get; set; }


        [SugarColumn(ColumnDescription = "需求单号", Length = 50)]
        public string OutboundID { get; set; }


        [SugarColumn(ColumnDescription = "单据类型")]
        public int? OutboundType { get; set; }


        [SugarColumn(ColumnDescription = "出料口", Length = 50)]
        public string OutboundPort { get; set; }


        [SugarColumn(ColumnDescription = "仓库类型", Length = 50)]
        public string AreaType { get; set; }


        [SugarColumn(ColumnDescription = "AGV送料目的地", Length = 50)]
        public string DestinationforAGV { get; set; }


        [SugarColumn(ColumnDescription = "出库任务单据状态/Outbound Job Status")]
        public int? OutboundJobStatus { get; set; }



        [SugarColumn(ColumnDescription = "备注", Length = 500)]
        public string Remark { get; set; }


        [SugarColumn(ColumnDescription = "开始时间")]
        public DateTime? StartTime { get; set; }


        [SugarColumn(ColumnDescription = "完成时间")]
        public DateTime? EndTime { get; set; }



        /// <summary>
        /// 创建人账号
        /// </summary>
        [SugarColumn(ColumnDescription = "创建人", Length = 20, IsOnlyIgnoreUpdate = true)]
        public virtual string CreateId { get; set; }

        /// <summary>
        /// 更新人账号
        /// </summary>
        [SugarColumn(ColumnDescription = "更新人", Length = 20)]
        public virtual string UpdateId { get; set; }
    }

}