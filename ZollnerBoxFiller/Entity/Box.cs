using System;
using SqlSugar;

namespace Passion.Entity
{
    /// <summary>
    /// 料箱
    /// </summary>
    [SugarTable("box", "Box 料箱")]
    public class Box : EntityBase
    {
        /// <summary>
        /// 编码
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", Length = 50)]
        public string Code { get; set; }


        /// <summary>
        /// 外部编码
        /// </summary>
        [SugarColumn(ColumnDescription = "外部编码", Length = 50)]
        public string RelevanceCode { get; set; }


        // <summary>
        /// BindReeid
        /// </summary>
        [SugarColumn(ColumnDescription = "BindReeid-用于料箱绑定单个id", Length = 50)]
        public string BindReeid { get; set; }



        /// <summary>
        /// 需求单
        /// </summary>
        [SugarColumn(ColumnDescription = "WorkerOrder", Length = 50)]
        public string WorkerOrder { get; set; }



        /// <summary>
        /// 出入库单据
        /// </summary>
        [SugarColumn(ColumnDescription = "InOutOrder", Length = 50)]
        public string InOutOrder { get; set; }



        /// <summary>
        /// 箱子运行
        /// </summary>
        [SugarColumn(ColumnDescription = "箱子状态；10：入库中；20：装箱中；30：出库中；")]
        public int? Status { get; set; }


        /// <summary>
        /// 箱子是否空箱
        /// </summary>
        [SugarColumn(ColumnDescription = "是否空箱")]
        public bool? isEmpty { get; set; } = false;

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDescription = "名称", Length = 50)]
        public string Name { get; set; }

        /// <summary>
        /// 库区类型
        /// </summary>
        [SugarColumn(ColumnDescription = "库区类型", Length = 10)]
        public string AreaType { get; set; }


        /// <summary>
        /// AGV区域
        /// </summary>
        [SugarColumn(ColumnDescription = "AGV区域", Length = 50)]
        public string AgvArea { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
        [SugarColumn(ColumnDescription = "列类型")]
        public int? CellType { get; set; }

    }
}
