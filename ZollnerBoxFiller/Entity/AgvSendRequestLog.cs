// 标准管理平台

using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passion.Entity
{

    [SugarTable("AgvSendRequestLog", "Agv发送创建任务请求记录")]
    public class AgvSendRequestLog : ZollnerEntityBase
    {
        [SugarColumn(ColumnDescription = "请求地址", Length = 2000)]
        public string UrlAddress { get; set; }


        [SugarColumn(ColumnDescription = "请求编号", Length = 32)]
        public string ReqCode { get; set; } // 请求编号


        [SugarColumn(ColumnDescription = "请求文本", Length = 2000)]
        public string RequestJson { get; set; }


        [SugarColumn(ColumnDescription = "返回Code", Length = 50)]
        public string SuccessCode { get; set; }


        [SugarColumn(ColumnDescription = "返回文本", Length = 2000)]
        public string ResponseJson { get; set; }


        [SugarColumn(ColumnDescription = "返回文本", Length = 2000)]
        public string ResponseData { get; set; }


        [SugarColumn(ColumnDescription = "返回TaskCode", Length = 200)]
        public string TaskCode { get; set; }


        [SugarColumn(ColumnDescription = "请求通道", Length = 200)]
        public int? RequestSide { get; set; }

        [SugarColumn(ColumnDescription = "箱号", Length = 200)]
        public string BoxNo { get; set; }

        [SugarColumn(ColumnDescription = "架号", Length = 200)]
        public string CarcaseNo { get; set; }
    }
}

