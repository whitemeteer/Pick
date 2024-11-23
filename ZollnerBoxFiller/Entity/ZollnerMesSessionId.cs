using System;
using SqlSugar;

namespace Passion.Entity
{

    [SugarTable("ZollnerMesSessionId", "Mes登录SessionId信息清单")]
    public class ZollnerMesSessionId : ZollnerEntityBase
    {
        [SugarColumn(ColumnDescription = "Session类别. 0: 机器设备过账用: 1: 机器设备登录用[智能仓,料塔,码垛机]; 2:平台用户登录用; 3: PDA设备登录用; 4: AGV ")]
        public int Type { get; set; }

        [SugarColumn(ColumnDescription = "IP", Length = 100)]
        public string IP { get; set; }

        [SugarColumn(ColumnDescription = "设备机器编号", Length = 50)]
        public string MachineNo { get; set; }

        [SugarColumn(ColumnDescription = "设备机器名称", Length = 50)]
        public string MachineName { get; set; }

        [SugarColumn(ColumnDescription = "设备机器BC", Length = 50)]
        public string MachineLocationBC { get; set; }

        [SugarColumn(ColumnDescription = "Mes Seesion Id", Length = 50)]
        public string Session_Id { get; set; }

        [SugarColumn(ColumnDescription = "MesLogin", Length = 50)]
        public string MesLogin { get; set; }

        [SugarColumn(ColumnDescription = "MesPassWord", Length = 50)]
        public string MesPassWord { get; set; }

    }

}
