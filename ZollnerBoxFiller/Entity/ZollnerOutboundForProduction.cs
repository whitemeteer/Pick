using System;
using SqlSugar;

namespace Passion.Entity
{


    [SugarTable("zollnerOutboundForProduction", "一般出库需求单")]
    public class ZollnerOutboundForProduction : ZollnerEntityBase
    {

        [SugarColumn(ColumnDescription = "需求单号", Length = 100)]
        public string OutboundID { get; set; }


        [SugarColumn(ColumnDescription = "线体", Length = 50)]
        public string SMTLine { get; set; }

        [SugarColumn(ColumnDescription = "是否至车间")]
        public bool? ToTheWorkshop { get; set; }


        [SugarColumn(ColumnDescription = "需求单据状态-0:未寻料；1：已寻料；2：发料中；3：发料中；4：完成；5,；出库异常 6:手工关闭")]
        public int? OutboundStatus { get; set; } = 0;



        [SugarColumn(ColumnDescription = "寻料状态- 0:未寻料 1：齐套；2：缺料")]
        public int? SortingStatus { get; set; } = 0;



        [SugarColumn(ColumnDescription = "是否混箱")]

        public bool? DiffSizeInOneBox { get; set; }



        [SugarColumn(ColumnDescription = "单据类型- 1:一般 0：其他；2：指定Batch_BC", Length = 50)]
        public string OutboundType { get; set; }



        [SugarColumn(ColumnDescription = "完成时间")]
        public DateTime? EndTime { get; set; }


        [SugarColumn(ColumnDescription = "备注", Length = 500)]
        public string Remark { get; set; }



        //[SugarColumn(ColumnDescription = "创建人", Length = 20)]
        //[MaxLength(20)]
        //public string CreateId { get; set; }


        //[SugarColumn(ColumnDescription = "创建时间")]
        //public DateTime CreateTime { get; set; } = DateTime.Now;



        //[SugarColumn(ColumnDescription = "更新人", Length = 20), AllowNull]
        //[MaxLength(20)]
        //public string UpdateId { get; set; }


        //[SugarColumn(ColumnDescription = "更新时间"), AllowNull]
        //public DateTime UpdateTime { get; set; } = DateTime.Now;

    }
}
