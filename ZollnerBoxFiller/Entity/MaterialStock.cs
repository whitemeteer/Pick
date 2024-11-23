using SqlSugar;
using System;

namespace Passion.Entity
{
/// <summary>
/// 物料库存信息表
/// </summary>
[SugarTable("materialstock", "MaterialStock 物料库存信息表")]
public class MaterialStock : EntityBaseId
{
    /// <summary>
    /// 仓库编号
    /// </summary>
    [SugarColumn(ColumnDescription = "仓库编号", Length = 50)]
    public string WarehouseCode { get; set; }


    /// <summary>
    /// 库区编号
    /// </summary>
    [SugarColumn(ColumnDescription = "库区编号", Length = 50)]
    public string AreaCode { get; set; }


    /// <summary>
    /// 库位码
    /// </summary>
    [SugarColumn(ColumnDescription = "库位码", Length = 20)]
    public string PositionCode { get; set; }


    /// <summary>
    /// 料箱编码
    /// </summary>
    [SugarColumn(ColumnDescription = "料箱编码", Length = 50)]
    public string BoxCode { get; set; }


    /// <summary>
    /// 物料唯一码
    /// </summary>
    [SugarColumn(ColumnDescription = "物料唯一码", Length = 255)]
    public string ReelId { get; set; }


    /// <summary>
    /// 物料编码
    /// </summary>
    [SugarColumn(ColumnDescription = "物料编码", Length = 50)]
    public string PN { get; set; }


    /// <summary>
    /// 物料名称
    /// </summary>
    [SugarColumn(ColumnDescription = "物料名称", Length = 100)]
    public string MatName { get; set; }


    /// <summary>
    /// 物料单位
    /// </summary>
    [SugarColumn(ColumnDescription = "物料单位", Length = 100)]
    public string MatUnit { get; set; }


    /// <summary>
    /// 物料数量
    /// </summary>
    [SugarColumn(ColumnDescription = "物料数量")]
    public double? Qty { get; set; }


    /// <summary>
    /// 批次号
    /// </summary>
    [SugarColumn(ColumnDescription = "批次号", Length = 50)]
    public string Lot { get; set; }


    /// <summary>
    /// 供应商编码
    /// </summary>
    [SugarColumn(ColumnDescription = "供应商编码", Length = 50)]
    public string SupplierCode { get; set; }


    /// <summary>
    /// 供应商名称
    /// </summary>
    [SugarColumn(ColumnDescription = "供应商名称", Length = 100)]
    public string SupplierName { get; set; }


    /// <summary>
    /// 生产日期编码
    /// </summary>
    [SugarColumn(ColumnDescription = "生产日期编码", Length = 50)]
    public string DateCode { get; set; }


    /// <summary>
    /// 过期时间
    /// </summary>
    [SugarColumn(ColumnDescription = "过期时间")]
    public DateTime? ExpiryDate { get; set; }


    /// <summary>
    /// 物料描述
    /// </summary>
    [SugarColumn(ColumnDescription = "物料描述", Length = 200)]
    public string PartDescription { get; set; }


    /// <summary>
    /// PrepareMaterial/OutOrderNo出库单详细编号
    /// </summary>
    [SugarColumn(ColumnDescription = "PrepareMaterial/OutOrderNo出库单详细编号", Length = 50)]
    public string OutOrderNo { get; set; }


    /// <summary>
    /// 物料尺寸
    /// </summary>
    [SugarColumn(ColumnDescription = "物料尺寸")]
    public int? Size { get; set; }


    /// <summary>
    /// 厚度
    /// </summary>
    [SugarColumn(ColumnDescription = "厚度")]
    public int? Thick { get; set; }


    /// <summary>
    /// 深度(1-3)
    /// </summary>
    [SugarColumn(ColumnDescription = " 深度(1-3)")]
    public int? Depth { get; set; }


    /// <summary>
    /// 是否入库
    /// </summary>
    [SugarColumn(ColumnDescription = "是否入库")]
    public bool? IsSave { get; set; }


    /// <summary>
    /// 状态，10:正常;20：禁用;30:占用;40:Block
    /// </summary>
    [SugarColumn(ColumnDescription = "状态，10:正常;20：禁用;30:占用;40:Block")]
    public int? Status { get; set; }

    /// <summary>
    /// 状态修改对象
    /// </summary>
    [SugarColumn(ColumnDescription = "状态修改对象")]
    public string StatusOperater { get; set; }

    [SugarColumn(ColumnDescription = "是否Block")]
    public int? IsBlock { get; set; }

    [SugarColumn(ColumnDescription = "Block修改对象")]
    public string BlockOperater { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    [SugarColumn(ColumnDescription = "创建人", Length = 50)]
    public string CreatorId { get; set; }


    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription = "创建日期")]
    public DateTime? CreateTime { get; set; }


    /// <summary>
    /// 是否已删除
    /// </summary>
    [SugarColumn(ColumnDescription = "是否已删除")]
    public bool? Deleted { get; set; }


    /// <summary>
    /// Block类型
    /// </summary>
    [SugarColumn(ColumnDescription = "Block类型")]
    public int? BlockType { get; set; }
    
}
}