using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passion.Entity
{
    [SugarTable("WCSInteractionLog", "上位机交互日志")]
    public class WCSInteractionLog : EntityBaseId
    {

        [SugarColumn(ColumnDescription = "设备编号", Length = 50)]
        public string TowerNo { get; set; }

        [SugarColumn(ColumnDescription = "方法名称", Length = 50)]
        public string FunctionName { get; set; }


        [SugarColumn(ColumnDescription = "描述", Length = 500)]
        public string InterfaceDescription { get; set; }



        [SugarColumn(ColumnDescription = "IWSM接收文本", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string ReceiveTxt { get; set; }


        [SugarColumn(ColumnDescription = "IWS返回文本", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string BackTxt { get; set; }



        [SugarColumn(ColumnDescription = "IWMS发送接口文本", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string RequestTxt { get; set; }


        [SugarColumn(ColumnDescription = "IWMS接口响应文本", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string ResponseTxt { get; set; }



        [SugarColumn(ColumnDescription = "操作时间")]
        public DateTime? OperateTime { get; set; }


    }
}
