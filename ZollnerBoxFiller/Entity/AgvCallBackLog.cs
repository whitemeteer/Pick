// 标准管理平台

using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passion.Entity
{

    [SugarTable("AgvCallBackLog", "Agv上报任务运行情况")]
    public class AgvCallBackLog : ZollnerEntityBase
    {
        [SugarColumn(ColumnDescription = "请求编号", Length = 32)]
        public string ReqCode { get; set; } // 请求编号

        [SugarColumn(ColumnDescription = "请求时间戳", Length = 20)]
        public string ReqTime { get; set; } // 请求时间戳

        [SugarColumn(ColumnDescription = "地码 X 坐标")]
        public double? CooX { get; set; } // 地码 X 坐标

        [SugarColumn(ColumnDescription = "地码 Y 坐标")]
        public double? CooY { get; set; } // 地码 Y 坐标

        [SugarColumn(ColumnDescription = "当前位置编号", Length = 32)]
        public string CurrentPositionCode { get; set; } // 当前位置编号

        [SugarColumn(ColumnDescription = "自定义字段", Length = 2000)]
        public string Data { get; set; } // 自定义字段

        [SugarColumn(ColumnDescription = "地图编号", Length = 16)]
        public string MapCode { get; set; } // 地图编号

        [SugarColumn(ColumnDescription = "地码编号", Length = 32)]
        public string MapDataCode { get; set; } // 地码编号

        [SugarColumn(ColumnDescription = "仓位编号", Length = 32)]
        public string StgBinCode { get; set; } // 仓位编号

        [SugarColumn(ColumnDescription = "方法名", Length = 16)]
        public string Method { get; set; } // 方法名

        [SugarColumn(ColumnDescription = "货架编号", Length = 16)]
        public string PodCode { get; set; } // 货架编号

        [SugarColumn(ColumnDescription = "货架方向", Length = 4)]
        public string PodDir { get; set; } // 货架方向

        [SugarColumn(ColumnDescription = "物料编号", Length = 32)]
        public string MaterialLot { get; set; } // 物料编号

        [SugarColumn(ColumnDescription = "物料类型", Length = 32)]
        public string MaterialType { get; set; } // 物料类型

        [SugarColumn(ColumnDescription = "AGV编号", Length = 5)]
        public string RobotCode { get; set; } // AGV编号

        [SugarColumn(ColumnDescription = "任务单号", Length = 64)]
        public string TaskCode { get; set; } // 任务单号

        [SugarColumn(ColumnDescription = "工作位", Length = 32)]
        public string WbCode { get; set; } // 工作位

        [SugarColumn(ColumnDescription = "容器编号", Length = 30)]
        public string CtnrCode { get; set; } // 容器编号

        [SugarColumn(ColumnDescription = "容器类型", Length = 2)]
        public string CtnrType { get; set; } // 容器类型

        [SugarColumn(ColumnDescription = "巷道编号", Length = 16)]
        public string RoadWayCode { get; set; } // 巷道编号

        [SugarColumn(ColumnDescription = "巷道内顺序号", Length = 2)]
        public string Seq { get; set; } // 巷道内顺序号

        [SugarColumn(ColumnDescription = "设备编号", Length = 32)]
        public string EqpCode { get; set; } // 设备编号

    }
}
