using System;
using SqlSugar;

namespace Passion.Entity
{
    [SugarTable("Zollner_inoutorderdetail", "zollner出库单详情表")]

    public class Zollner_InOutOrderDetail : EntityBaseId
    {

        [SugarColumn(ColumnDescription = "PrepareMaterial/OutOrderNo出库单详细编号", Length = 50)]
        public string OutOrderNo { get; set; }


        [SugarColumn(ColumnDescription = "需求单号", Length = 50)]
        public string OutboundID { get; set; }


        [SugarColumn(ColumnDescription = "BatchBC", Length = 255)]

        public string BatchBC { get; set; }


        [SugarColumn(ColumnDescription = "仓库单号", Length = 50)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 出库状态：0:待出库; 1:出库中; 2:出库完成; 3:手工出库;
        /// </summary>
        [SugarColumn(ColumnDescription = "出库状态，0:待出库; 1:出库中; 2:出库完成; 3:手工出库;")]
        public int? BatchBCJobStatus { get; set; } = 0;

        /// <summary>
        /// 过账状态：  0:未过账;1:已过账; 2:过账失败;
        /// </summary>
        [SugarColumn(ColumnDescription = "过账状态， 0:未过账;1:已过账; 2:过账失败;")]
        public int? BatchBCPostingStatus { get; set; } = 0;

        /// <summary>
        /// 过账状态：  0:未过账;1:已过账; 2:过账失败;
        /// </summary>
        [SugarColumn(ColumnDescription = "箱码", Length = 50)]
        public string Outbound_Container_BC { get; set; }

        /// <summary>
        /// 出库类型;
        /// </summary>
        [SugarColumn(ColumnDescription = "出库类型")]
        public int? Batch_BC_Outbound_Processing_Type { get; set; }

        /// <summary>
        /// 出库类型;
        /// </summary>
        [SugarColumn(ColumnDescription = "出库时间")]
        public DateTime? EndTime { get; set; }

    }
}
