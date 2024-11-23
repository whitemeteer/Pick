using System;
using SqlSugar;

namespace Passion.Entity
{


    [SugarTable("zollnerOutboundForProductionDetail", "一般出库需求单明细")]
    public class ZollnerOutboundForProductionDetail : ZollnerEntityBase
    {
        [SugarColumn(ColumnDescription = "需求单号", Length = 100)]
        public string OutboundID { get; set; }


        [SugarColumn(ColumnDescription = "料号", Length = 50)]
        public string Component_BC { get; set; }

        [SugarColumn(ColumnDescription = "批次编号(ReelID)", Length = 50)]
        public string Batch_BC { get; set; }


        [SugarColumn(ColumnDescription = "工厂", Length = 50)]
        public string Plant { get; set; }


        [SugarColumn(ColumnDescription = "数量")]
        public int? Quantity { get; set; }

        #region 物料升级

        [SugarColumn(ColumnDescription = "新料号", Length = 50)]
        public string Component_BCNew { get; set; }

        [SugarColumn(ColumnDescription = "制造商物料号", Length = 50)]
        public string ManufacturerPartNo { get; set; }

        [SugarColumn(ColumnDescription = "制造商名称", Length = 50)]
        public string ManufacturerName { get; set; }

        [SugarColumn(ColumnDescription = "需求人", Length = 50)]
        public string RequestedBy { get; set; }

        #endregion


        #region 指定物料状态

        [SugarColumn(ColumnDescription = "库位", Length = 20)]
        public string PostionCode { get; set; }

        [SugarColumn(ColumnDescription = "库区", Length = 50)]
        public string AreaCode { get; set; }

        [SugarColumn(ColumnDescription = "Block状态")]
        public int? BlockStatus { get; set; }

        [SugarColumn(ColumnDescription = "Block类型")]
        public string BlockType { get; set; }

        [SugarColumn(ColumnDescription = "Block时间")]
        public DateTime? BlockTime { get; set; }

        [SugarColumn(ColumnDescription = "入库时间")]
        public DateTime? StockInTime { get; set; }

        #endregion

        [SugarColumn(ColumnDescription = "描述", Length = 500)]
        public string Description { get; set; }


    }
}


