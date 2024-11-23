using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;
using IoTClient.Clients.Modbus;
using IoTServer.Servers.Modbus;
using IoTClient.Enums;
using System.Threading;
using IoTClient;
using Passion;
using SqlSugar;
using Passion.Entity;
using System.Runtime.Remoting.Contexts;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.CompilerServices;

using HPSocket;
using HPSocket.Sdk;
using HPSocket.Tcp;
using HPSocket.WebSocket;
using System.Data.SqlClient;
using static log4net.Appender.RollingFileAppender;
using RestSharp;
using NLog;
using System.Collections.ObjectModel;
using System.Collections;


namespace ZollnerBoxFiller
{
    public partial class ApplicationForm :BaseForm
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        SynchronizationContext uiContextMain;

        byte stationNumber = 2;
        IModbusClient client;
        ModbusTcpServer server;

        protected SqlSugarScope dbContent
        {
            get
            {
                return MySqlSugar.Db;
            }

        }

        TcpClient hpPhotoClient = new TcpClient();
        TcpClient hpScanClient1 = new TcpClient();
        TcpClient hpScanClient2 = new TcpClient();

        bool tcpPhotoState = false;
        bool tcpScan1State = false;
        bool tcpScan2State = false;

        #region 硬件地址上的缓存

        /// <summary>
        /// 码垛位箱号
        /// </summary>
        public string Buffer_BoxNo_AtOperate { get; set; } = string.Empty;
        /// <summary>
        /// 上一轮码垛位箱号
        /// </summary>
        public string Buffer_Last_BoxNo_AtOperate { get; set; } = string.Empty;
        /// <summary>
        /// 码垛位箱号列表
        /// </summary>
        public List<string> Buffer_BoxNoList_AtOperate { get; set; } = new List<string>();


        /// <summary>
        /// 料盘唯一码
        /// </summary>
        public string Buffer_ReelId_AtOperate { get; set; } = string.Empty;
        /// <summary>
        /// 上一轮料盘唯一码
        /// </summary>
        public string Buffer_Last_ReelId_AtOperate { get; set; } = string.Empty;
        /// <summary>
        /// 料盘唯一码的列表
        /// </summary>
        public List<string> Buffer_ReelIdList_AtOperate { get; set; } = new List<string>();

        /// <summary>
        /// 出箱通道箱号
        /// </summary>
        public string Buffer_BoxNo_AtOutput3 { get; set; } = string.Empty;
        /// <summary>
        /// 上一轮出箱通道箱号
        /// </summary>
        public string Buffer_Last_BoxNo_AtOutput3 { get; set; } = string.Empty;
        /// <summary>
        /// 出箱通道箱号列表
        /// </summary>
        public List<string> Buffer_BoxNoList_AtOutput3 { get; set; } = new List<string>();

        #endregion

        #region 相机,扫码器1,扫码器2的返回接收配置
        public string Address_Image { get; set; } = "127.0.0.1";
        public ushort Port_Image { get; set; } = 5555;
        public string Address_Scan1 { get; set; } = "192.168.1.121";
        public ushort Port_Scan1 { get; set; } = 2001;
        public string Address_Scan2 { get; set; } = "192.168.1.122";
        public ushort Port_Scan2 { get; set; } = 2001;
        #endregion

        #region 程序自动任务的缓存

        #region Ref_Buf_Reel

        public bool Buf_Last_Catch_Reel { get; set; } = false;
        public bool Buf_Catch_Reel { get; set; } = false;
        public string Buf_Catch_ReelId { get; set; } = "";
        public bool Buf_Catch_ReelId_CheckResult {  get; set; } = false;
        public MaterialStock Buf_Pending_ReelId_Entity { get; set; } = null;
        public int Buf_Pending_ReelId_MaterialSize { get; set; } = 0;
        public string Buf_Process_OutOrderNo_ByReelId { get; set; } = string.Empty;
        public Zollner_InOutOrder Buf_Process_OutOrderEntity_ByReelId { get; set; } = null;
        public List<Zollner_InOutOrderDetail> Buf_Process_OutOrderDetailList_ByReelId { get; set; } = null;
        public List<string> Buf_Processed_ReelIdList_ByReelId { get; set; } = null;

        #endregion

        #region Ref_Buf_Box

        public bool Buf_Last_Catch_Box { get; set; } = false;
        public bool Buf_Catch_Box { get; set; } = false;
        public string Buf_Catch_BoxNo { get; set; } = string.Empty;
        public bool Buf_Catch_BoxNo_CheckResult { get; set; } = false;
        public Box Buf_Pending_Box_Entity { get; set; } = null;
        public List<Boxdetail> Buf_Pending_BoxDetail_List { get; set; } = null;
        public string Buf_Process_OutOrderNo_ByBoxNo { get; set; } = string.Empty;
        public Zollner_InOutOrder Buf_Process_OutOrderEntity_ByBoxNo { get; set; } = null;
        public List<Zollner_InOutOrderDetail> Buf_Process_OutOrderDetailList_ByBoxNo { get; set; } = null;
        public List<string> Buf_Processed_ReelIdList_ByBoxNo { get; set; } = null;

        #endregion

        #endregion

        public List<NGItem> NGDictionary { get; set; } = new List<NGItem>();

        System.Threading.Timer _reconnectTimer;
        public ApplicationForm()
        {
            InitializeComponent();

            btn_initial.Enabled = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = false;
            btn_error.Enabled = false;

            btn_autoprc_start.Enabled = false;
            btn_autoprc_stop.Enabled = false;
            btn_TakePhotoFromEquiment0.Enabled = false;
            btn_TakeScanFromEquiment1.Enabled = false;
            btn_TakeScanFromEquiment2.Enabled = false;
            btn_rollout.Enabled = false;

            #region NG字典

            NGDictionary.Add(new NGItem(1, "急停报警"));
            NGDictionary.Add(new NGItem(2, "设备未上电"));
            NGDictionary.Add(new NGItem(3, "安全门打开"));
            NGDictionary.Add(new NGItem(4, "1通道阻挡气缸上升超时"));
            NGDictionary.Add(new NGItem(5, "1通道阻挡气缸下降超时"));
            NGDictionary.Add(new NGItem(6, "通道1AGV入料超时"));
            NGDictionary.Add(new NGItem(7, "通道1滚筒1报警"));
            NGDictionary.Add(new NGItem(8, "1通道2段入料滚筒报警"));
            NGDictionary.Add(new NGItem(9, "1通道2段移栽滚筒报警"));
            NGDictionary.Add(new NGItem(10, "1通道2段入料超时"));
            NGDictionary.Add(new NGItem(11, "1通道2段移栽顶升上升超时"));
            NGDictionary.Add(new NGItem(12, "1通道2段移栽顶升下降超时"));
            NGDictionary.Add(new NGItem(13, "码垛段移栽滚筒报警"));
            NGDictionary.Add(new NGItem(14, "码垛段入料滚筒报警"));
            NGDictionary.Add(new NGItem(15, "码垛阻挡气缸上升超时"));
            NGDictionary.Add(new NGItem(16, "码垛阻挡气缸下降超时"));
            NGDictionary.Add(new NGItem(17, "1通道码垛入料超时"));
            NGDictionary.Add(new NGItem(18, "2通道码垛入料超时"));
            NGDictionary.Add(new NGItem(19, "码垛移栽顶升上升超时"));
            NGDictionary.Add(new NGItem(20, "码垛移栽顶升下降超时"));
            NGDictionary.Add(new NGItem(21, "2通道入料滚筒超时"));
            NGDictionary.Add(new NGItem(22, "2通道阻挡气缸上升超时"));
            NGDictionary.Add(new NGItem(23, "2通道阻挡气缸下降超时"));
            NGDictionary.Add(new NGItem(24, "2通道AGV入料超时"));
            NGDictionary.Add(new NGItem(25, "3通道1段出料滚筒报警"));
            NGDictionary.Add(new NGItem(26, "3通道1段移栽滚筒报警"));
            NGDictionary.Add(new NGItem(27, "3通道1段阻挡气缸上升超时"));
            NGDictionary.Add(new NGItem(28, "3通道1段阻挡气缸下降超时"));
            NGDictionary.Add(new NGItem(29, "3通道1段入料超时"));
            NGDictionary.Add(new NGItem(30, "3通道1段移栽顶升上升超时"));
            NGDictionary.Add(new NGItem(31, "3通道1段移栽顶升下降超时"));
            NGDictionary.Add(new NGItem(32, "3通道2段出料滚筒报警"));
            NGDictionary.Add(new NGItem(33, "3通道2段阻挡气缸上升超时"));
            NGDictionary.Add(new NGItem(34, "3通道2段阻挡气缸下降超时"));
            NGDictionary.Add(new NGItem(35, "3通道2段AGV出料超时"));
            NGDictionary.Add(new NGItem(36, "3通道1段往2段入料超时"));
            NGDictionary.Add(new NGItem(37, "取放料模组X轴报警"));
            NGDictionary.Add(new NGItem(38, "取放料模组X伺服报警"));
            NGDictionary.Add(new NGItem(39, "取放料模组Y轴报警"));
            NGDictionary.Add(new NGItem(40, "取放料模组Y伺服报警"));
            NGDictionary.Add(new NGItem(41, "取放料模组Z轴报警"));
            NGDictionary.Add(new NGItem(42, "取放料模组Z伺服报警"));
            NGDictionary.Add(new NGItem(43, "取放模组X轴未使能报警"));
            NGDictionary.Add(new NGItem(44, "取放模组Y轴未使能报警"));
            NGDictionary.Add(new NGItem(45, "取放模组Z轴未使能报警"));
            NGDictionary.Add(new NGItem(46, "取放模组X轴正极限报警"));
            NGDictionary.Add(new NGItem(47, "取放模组X轴负极限报警"));
            NGDictionary.Add(new NGItem(48, "取放模组Y轴正极限报警"));
            NGDictionary.Add(new NGItem(49, "取放模组Y轴负极限报警"));
            NGDictionary.Add(new NGItem(50, "取放模组Z轴正极限报警"));
            NGDictionary.Add(new NGItem(51, "取放模组Z轴负极限报警"));
            NGDictionary.Add(new NGItem(52, "7寸箱位置1放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(53, "7寸箱位置2放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(54, "7寸箱位置3放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(55, "7寸箱位置4放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(56, "7寸箱抛料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(57, "13寸箱位置1放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(58, "13寸箱抛料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(59, "混箱位置1放料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(60, "混箱抛料中掉料或模组报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(61, "取料失败"));
            NGDictionary.Add(new NGItem(62, "7寸箱位置1放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(63, "7寸箱位置2放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(64, "7寸箱位置3放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(65, "7寸箱位置4放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(66, "7寸箱抛料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(67, "13寸箱放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(68, "13寸箱抛料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(69, "13寸箱放料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(70, "13寸箱抛料中复位了初始化完成，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(71, "夹紧气缸夹紧超时"));
            NGDictionary.Add(new NGItem(72, "7寸箱产品NG料报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(73, "13寸箱产品NG料报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(74, "混箱产品NG料报警，请人工PDA处理当前料"));
            NGDictionary.Add(new NGItem(75, "NG料盒满料"));
            NGDictionary.Add(new NGItem(76, "NG料盒不在位"));
            NGDictionary.Add(new NGItem(77, "入料皮带7寸产品检测故障"));
            NGDictionary.Add(new NGItem(78, ""));
            NGDictionary.Add(new NGItem(79, ""));
            NGDictionary.Add(new NGItem(80, "入料皮带滚筒报警"));
            NGDictionary.Add(new NGItem(81, "入料皮带入料超时"));
            NGDictionary.Add(new NGItem(82, "汇流皮带报警"));
            NGDictionary.Add(new NGItem(83, "13寸出料皮带入汇流皮带超时"));
            NGDictionary.Add(new NGItem(84, "7寸出料皮带入汇流皮带超时"));
            NGDictionary.Add(new NGItem(85, "7寸仓内皮带1入7寸出料皮带超时"));
            NGDictionary.Add(new NGItem(86, "7寸仓内皮带2入7寸出料皮带超时"));
            NGDictionary.Add(new NGItem(87, "汇流皮带初始化前请清空外部皮带料盘"));
            NGDictionary.Add(new NGItem(88, "料盘等待超时报警"));
            NGDictionary.Add(new NGItem(89, "码垛有箱子时初始化前请将3通道1段箱子人工拿走!"));
            NGDictionary.Add(new NGItem(90, ""));
            NGDictionary.Add(new NGItem(91, ""));
            NGDictionary.Add(new NGItem(92, ""));
            NGDictionary.Add(new NGItem(93, ""));
            NGDictionary.Add(new NGItem(94, "软件与码垛机未连接报警"));
            NGDictionary.Add(new NGItem(95, ""));
            NGDictionary.Add(new NGItem(96, ""));
            NGDictionary.Add(new NGItem(97, ""));
            NGDictionary.Add(new NGItem(98, ""));
            NGDictionary.Add(new NGItem(99, ""));
            NGDictionary.Add(new NGItem(100, ""));

            #endregion

            logger.Info("Application started.");

            uiContextMain = SynchronizationContext.Current;

            // ClientPrepareConnectEventHandler -- photo
            hpPhotoClient.OnPrepareConnect += OnPrepareConnect; // 链接前
            hpPhotoClient.OnConnect += OnConnect; // 链接成功后
            hpPhotoClient.OnSend += OnSend;  // 发送消息
            hpPhotoClient.OnReceive += OnReceive; // 接受到消息后
            hpPhotoClient.OnClose += OnClose; // 链接关闭后


            hpPhotoClient.Address = Address_Image; // 服务端的Ip
            hpPhotoClient.Port = Port_Image; // 服务端监听的端口
            hpPhotoClient.BindAddress = "127.0.0.1"; // 客户端本机的ip
            hpPhotoClient.BindPort = 6001;  // 客户端本机的端口


            hpPhotoClient.Connect();
            hpPhotoClient.ConnectionTimeout = 1000 * 900;
            hpPhotoClient.KeepAliveInterval = 10;
            hpPhotoClient.KeepAliveTime = 200;

            //hpPhotoClient.PauseReceive = ReceiveState.Resume;


            // ClientPrepareConnectEventHandler -- scan1
            hpScanClient1.OnPrepareConnect += OnPrepareConnect_scan1; // 链接前
            hpScanClient1.OnConnect += OnConnect_scan1; // 链接成功后
            hpScanClient1.OnSend += OnSend_scan1;  // 发送消息
            hpScanClient1.OnReceive += OnReceive_scan1; // 接受到消息后
            hpScanClient1.OnClose += OnClose_scan1; // 链接关闭后


            hpScanClient1.Address = Address_Scan1; // 服务端的Ip
            hpScanClient1.Port = Port_Scan1; // 服务端监听的端口
            hpScanClient1.BindAddress = "192.168.1.110"; // 客户端本机的ip
            hpScanClient1.BindPort = 2001;  // 客户端本机的端口


            hpScanClient1.Connect();
            hpScanClient1.ConnectionTimeout = 1000 * 900;
            hpScanClient1.KeepAliveInterval = 10;
            hpScanClient1.KeepAliveTime = 200;

            //hpScanClient1.PauseReceive = ReceiveState.Resume;

            // ClientPrepareConnectEventHandler -- scan2
            hpScanClient2.OnPrepareConnect += OnPrepareConnect_scan2; // 链接前
            hpScanClient2.OnConnect += OnConnect_scan2; // 链接成功后
            hpScanClient2.OnSend += OnSend_scan2;  // 发送消息
            hpScanClient2.OnReceive += OnReceive_scan2; // 接受到消息后
            hpScanClient2.OnClose += OnClose_scan2; // 链接关闭后


            hpScanClient2.Address = Address_Scan2; // 服务端的Ip
            hpScanClient2.Port = Port_Scan2; // 服务端监听的端口
            hpScanClient2.BindAddress = "192.168.1.110"; // 客户端本机的ip
            hpScanClient2.BindPort = 12001;  // 客户端本机的端口


            hpScanClient2.Connect();
            hpScanClient2.ConnectionTimeout = 1000 * 900;
            hpScanClient2.KeepAliveInterval = 10;
            hpScanClient2.KeepAliveTime = 200;
            
            //hpScanClient2.PauseReceive = ReceiveState.Resume;



            Thread.Sleep(1000);

            _reconnectTimer = new System.Threading.Timer(ReconnectTimerCallback, null, 3 * 1000, 10 * 1000);
        }

        #region tcp client -> photo

        public void ReconnectTimerCallback(object state)
        {
            try
            {
                if (!hpPhotoClient.IsConnected)
                {
                    this.pbCamera.BackColor = Color.Gray;

                    hpPhotoClient.Connect(Address_Image, Port_Image);
                    hpPhotoClient.ConnectionTimeout = 1000 * 900;
                    hpPhotoClient.KeepAliveInterval = 10;
                    hpPhotoClient.KeepAliveTime = 200;
                    //hpPhotoClient.PauseReceive = ReceiveState.Resume;
                }
                else
                {
                    this.pbCamera.BackColor = Color.LawnGreen;
                }

                if (!hpScanClient1.IsConnected)
                {
                    this.pbScan1.BackColor = Color.Gray;

                    hpScanClient1.Connect(Address_Scan1, Port_Scan1);
                    hpScanClient1.ConnectionTimeout = 1000 * 900;
                    hpScanClient1.KeepAliveInterval = 10;
                    hpScanClient1.KeepAliveTime = 200;
                    //hpScanClient1.PauseReceive = ReceiveState.Resume;
                }
                else
                {
                    this.pbScan1.BackColor = Color.LawnGreen;
                }

                if (!hpScanClient2.IsConnected)
                {
                    this.pbScan2.BackColor = Color.Gray;

                    hpScanClient2.Connect(Address_Scan2, Port_Scan2);
                    hpScanClient2.ConnectionTimeout = 1000 * 900;
                    hpScanClient2.KeepAliveInterval = 10;
                    hpScanClient2.KeepAliveTime = 200;
                    //hpScanClient2.PauseReceive = ReceiveState.Resume;
                }
                else
                {
                    this.pbScan2.BackColor = Color.LawnGreen;
                }
            }
            catch (Exception ex)
            {
                SynchronizationContext uiContext = this.uiContextMain;
                AppendText($"HP Socket重连失败 {ex.Message}", uiContext);
            }
            finally
            {

            }
        }

        /// <summary>
        /// 准备连接
        /// </summary>
        /// <returns></returns>
        public HandleResult OnPrepareConnect(IClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 连接后
        /// </summary>
        /// <returns></returns>
        public HandleResult OnConnect(IClient sender)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 消息发送后
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public HandleResult OnSend(IClient sender, byte[] data)
        {
            return HandleResult.Ok;
        }

        public bool IsReceive { get; set; } = false;
        /// <summary>
        /// 接收返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnReceive(IClient sender, byte[] data)
        {
            var reelIdString = System.Text.Encoding.UTF8.GetString(data);
            string reelId = string.Empty;

            if (reelIdString.IndexOf("SN") > -1)
            {
                int indexStart = reelIdString.IndexOf("SN");
                reelId = reelIdString.Substring(indexStart + 5);
                indexStart = reelId.IndexOf("PN");
                if (indexStart > -1)
                {
                    reelId = reelId.Substring(0, indexStart - 3);
                }
            }
            

            this.Buffer_Last_ReelId_AtOperate = this.Buffer_ReelId_AtOperate;

            this.Buffer_ReelId_AtOperate = reelId;

            IsReceive = true;

            // 返回一个操作结果代码，通常是HandleResult.Ok
            return HandleResult.Ok;
        }

        /// <summary>
        /// 关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnClose(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            return HandleResult.Ok;
        }

        #endregion

        #region tcp client -> scan1

        /// <summary>
        /// 准备连接
        /// </summary>
        /// <returns></returns>
        public HandleResult OnPrepareConnect_scan1(IClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 连接后
        /// </summary>
        /// <returns></returns>
        public HandleResult OnConnect_scan1(IClient sender)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 消息发送后
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public HandleResult OnSend_scan1(IClient sender, byte[] data)
        {
            return HandleResult.Ok;
        }

        public bool IsReceive1 { get; set; } = false;

        /// <summary>
        /// 接收返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnReceive_scan1(IClient sender, byte[] data)
        {
            var boxNo = System.Text.Encoding.UTF8.GetString(data);

            boxNo = boxNo.Replace("\r\n", "");

            this.Buffer_Last_BoxNo_AtOperate = this.Buffer_BoxNo_AtOperate;

            this.Buffer_BoxNo_AtOperate = boxNo;

            IsReceive1 = true;

            // 返回一个操作结果代码，通常是HandleResult.Ok
            return HandleResult.Ok;
        }

        /// <summary>
        /// 关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnClose_scan1(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            return HandleResult.Ok;
        }

        #endregion

        #region tcp client -> scan2

        /// <summary>
        /// 准备连接
        /// </summary>
        /// <returns></returns>
        public HandleResult OnPrepareConnect_scan2(IClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 连接后
        /// </summary>
        /// <returns></returns>
        public HandleResult OnConnect_scan2(IClient sender)
        {
            return HandleResult.Ok;
        }

        /// <summary>
        /// 消息发送后
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public HandleResult OnSend_scan2(IClient sender, byte[] data)
        {
            return HandleResult.Ok;
        }

        public bool IsReceive2 { get; set; } = false;

        /// <summary>
        /// 接收返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnReceive_scan2(IClient sender, byte[] data)
        {
            var boxNo = System.Text.Encoding.UTF8.GetString(data);

            boxNo = boxNo.Replace("\r\n", "");

            this.Buffer_Last_BoxNo_AtOutput3 = this.Buffer_BoxNo_AtOutput3;

            this.Buffer_BoxNo_AtOutput3 = boxNo;

            IsReceive2 = true;

            // 返回一个操作结果代码，通常是HandleResult.Ok
            return HandleResult.Ok;
        }

        /// <summary>
        /// 关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HandleResult OnClose_scan2(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            return HandleResult.Ok;
        }

        #endregion


        #region add txt log at UI
        private void AppendText(string content, SynchronizationContext uiContext)
        {
            if (string.IsNullOrEmpty(content))
            {
                //uiContext.Post(_ => txt_MsgPLC.Text = string.Empty, null);
            }
            else
            {
                logger.Info($"{content}");
                //uiContext.Post(_ => txt_MsgPLC.Text += ($"[{DateTime.Now.ToLongTimeString()}]{content}\r\n"), null);

                this.AddLog(content, string.Empty);
            }
        }

        #endregion

        #region add log at DB
        private void AddLog(string content, string functionname)
        {
            WCSInteractionLog logEntity = new WCSInteractionLog
            {
                Id = SnowFlakeSingle.Instance.NextId(),
                FunctionName = functionname,
                InterfaceDescription = content,
                ReceiveTxt = "",
                BackTxt = "",
                RequestTxt = "",
                ResponseTxt = "",
                OperateTime = DateTime.Now,
                TowerNo = "5",
            };

            var insertResult = this.dbContent.Insertable<WCSInteractionLog>(logEntity).ExecuteCommand();
        }

        #endregion

        #region Task

        public CancellationTokenSource Cancel_TaskStart_PopupError_Order;
        public void TaskStart_PopupError_Order()
        {
            Cancel_TaskStart_PopupError_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.PopupError_Order = true;
                ResponseContent returnRes = this.PopupError(Cancel_TaskStart_PopupError_Order.Token);
            }, Cancel_TaskStart_PopupError_Order.Token);
        }
        public bool PopupError_Order { get; set; } = false;
        public ResponseContent PopupError(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool PopupError_Self = true;

            while (true && PopupError_Order && PopupError_Self)
            {
                Thread.Sleep(50);

                var Result_13302 = client.ReadCoil("13302", stationNumber);
                var Result_13303 = client.ReadCoil("13303", stationNumber);

                Thread.Sleep(50);

                if ((Result_13302.IsSucceed && Result_13302.Value)
                    ||
                    (Result_13303.IsSucceed && Result_13303.Value)
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"警告, 码垛机报警!", uiContext);

                    base.Error("警告", "码垛机报警!");

                    PopupError_Self = false;
                }

                if (!PopupError_Order || !PopupError_Self)
                {
                    if (!PopupError_Order)
                    {
                        response = response.Error("取消报警监测任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }
            }


            return response;
        }
        public void TaskEnd_PopupError_Order()
        {
            this.PopupError_Order = false;
        }



        public CancellationTokenSource Cancel_RefreshAgvBoxAtInput1;
        public void TaskStart_RefreshAgvBoxAtInput1()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            Cancel_RefreshAgvBoxAtInput1 = new CancellationTokenSource();
            Task.Run(() => {
                AppendText($"开启1通道AGV查询展示任务", uiContext);
                this.RefreshAgvBoxAtInput1_Order = true;
                ResponseContent returnRes = this.RefreshAgvBoxAtInput1(Cancel_RefreshAgvBoxAtInput1.Token);
            }, Cancel_RefreshAgvBoxAtInput1.Token);
        }
        public bool RefreshAgvBoxAtInput1_Order { get; set; } = false;
        public ResponseContent RefreshAgvBoxAtInput1(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            bool RefreshAgvBoxAtInput1_Self = true;

            while (true && RefreshAgvBoxAtInput1_Order && RefreshAgvBoxAtInput1_Self)
            {
                if (!RefreshAgvBoxAtInput1_Order || !RefreshAgvBoxAtInput1_Self)
                {
                    if (!RefreshAgvBoxAtInput1_Order)
                    {
                        response = response.Error("取消1通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {

                }

                Thread.Sleep(50);

                var findTaskList = this.dbContent.Queryable<AgvSendRequestLog>().Where(x => x.RequestSide == 1 && (x.IsDelete == false || x.IsDelete == true) && !string.IsNullOrEmpty(x.TaskCode))
                                    .OrderByDescending(x => x.CreateTime)
                                    .ToList();
                if (findTaskList.Count > 0)
                {
                    var findTaskEntity = findTaskList[0];
                    string taskCode = findTaskEntity.TaskCode;
                    TaskCode = findTaskEntity.TaskCode;

                    if (findTaskEntity.IsDelete == false)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide1CheckResult.BackColor = Color.LawnGreen;
                            uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = this.ConvertAGVCallBackMethodToDesc1(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                            }
                        }
                        else
                        {
                            this.pbAGVSide1CheckResult.BackColor = Color.OrangeRed;
                            uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = this.ConvertAGVCallBackMethodToDesc1(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                            }
                        }

                    }
                    else if (findTaskEntity.IsDelete == true)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide1CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = "", null);
                        }
                        else
                        {
                            this.pbAGVSide1CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = this.ConvertAGVCallBackMethodToDesc1(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                            }
                        }
                    }
                    else
                    {
                        this.pbAGVSide1CheckResult.BackColor = Color.Gray;
                        uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = "", null);
                    }

                }
                else
                {
                    this.pbAGVSide1CheckResult.BackColor = Color.Gray;
                    uiContext.Post(_ => this.txtAGVSide1TaskCode.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide1Method.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide1BoxNo.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide1CarcaseNo.Text = "", null);
                }

                if (!RefreshAgvBoxAtInput1_Order || !RefreshAgvBoxAtInput1_Self)
                {
                    if (!RefreshAgvBoxAtInput1_Order)
                    {
                        response = response.Error("取消1通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                }

                Thread.Sleep(50);

                if (!RefreshAgvBoxAtInput1_Order || !RefreshAgvBoxAtInput1_Self)
                {
                    if (!RefreshAgvBoxAtInput1_Order)
                    {
                        response = response.Error("取消1通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            return response;
        }
        public void TaskEnd_RefreshAgvBoxAtInput1()
        {
            this.RefreshAgvBoxAtInput1_Order = false;
        }
        private string ConvertAGVCallBackMethodToDesc1(string Method)
        {
            string returnDesc = "";
            switch (Method)
            {
                case "start":
                    returnDesc = "AGV小车开始工作";
                    break;
                case "applyToAgv":
                    returnDesc = "AGV小车到达货架";
                    break;
                case "outBin":
                    returnDesc = "AGV小车运载空箱中";
                    break;
                case "applyFromAgv":
                    returnDesc = "AGV小车到达入箱通道口";
                    break;
                case "end":
                    returnDesc = "AGV小车已完成工作";
                    break;
                default:
                    break;
            }

            return returnDesc;
        }




        public CancellationTokenSource Cancel_RefreshAgvBoxAtInput2;
        public void TaskStart_RefreshAgvBoxAtInput2()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            Cancel_RefreshAgvBoxAtInput2 = new CancellationTokenSource();
            Task.Run(() => {
                AppendText($"开启2通道AGV查询展示任务", uiContext);
                this.RefreshAgvBoxAtInput2_Order = true;
                ResponseContent returnRes = this.RefreshAgvBoxAtInput2(Cancel_RefreshAgvBoxAtInput2.Token);
            }, Cancel_RefreshAgvBoxAtInput2.Token);
        }
        public bool RefreshAgvBoxAtInput2_Order { get; set; } = false;
        public ResponseContent RefreshAgvBoxAtInput2(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            bool RefreshAgvBoxAtInput2_Self = true;

            while (true && RefreshAgvBoxAtInput2_Order && RefreshAgvBoxAtInput2_Self)
            {
                if (!RefreshAgvBoxAtInput2_Order || !RefreshAgvBoxAtInput2_Self)
                {
                    if (!RefreshAgvBoxAtInput2_Order)
                    {
                        response = response.Error("取消任务!");
                    }

                    break;
                }
                else
                {

                }

                Thread.Sleep(50);

                var findTaskList = this.dbContent.Queryable<AgvSendRequestLog>().Where(x => x.RequestSide == 2 && (x.IsDelete == false || x.IsDelete == true) && !string.IsNullOrEmpty(x.TaskCode))
                                    .OrderByDescending(x => x.CreateTime)
                                    .ToList();
                if (findTaskList.Count > 0)
                {
                    var findTaskEntity = findTaskList[0];
                    string taskCode = findTaskEntity.TaskCode;
                    TaskCode = findTaskEntity.TaskCode;

                    if (findTaskEntity.IsDelete == false)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide2CheckResult.BackColor = Color.LawnGreen;
                            uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = this.ConvertAGVCallBackMethodToDesc2(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                            }
                        }
                        else
                        {
                            this.pbAGVSide2CheckResult.BackColor = Color.OrangeRed;
                            uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = this.ConvertAGVCallBackMethodToDesc2(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                            }
                        }
                    }
                    else if (findTaskEntity.IsDelete == true)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide2CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = "", null);
                        }
                        else
                        {
                            this.pbAGVSide2CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = this.ConvertAGVCallBackMethodToDesc2(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                            }
                        }
                    }
                    else
                    {
                        this.pbAGVSide2CheckResult.BackColor = Color.Gray;
                        uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = "", null);
                    }
                }
                else
                {
                    this.pbAGVSide2CheckResult.BackColor = Color.Gray;
                    uiContext.Post(_ => this.txtAGVSide2TaskCode.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide2Method.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide2BoxNo.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide2CarcaseNo.Text = "", null);
                }
                Thread.Sleep(10000);

                Thread.Sleep(50);

                if (!RefreshAgvBoxAtInput2_Order || !RefreshAgvBoxAtInput2_Self)
                {
                    if (!RefreshAgvBoxAtInput2_Order)
                    {
                        response = response.Error("取消任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            return response;
        }
        public void TaskEnd_RefreshAgvBoxAtInput2()
        {
            this.RefreshAgvBoxAtInput2_Order = false;
        }
        private string ConvertAGVCallBackMethodToDesc2(string Method)
        {
            string returnDesc = "";
            switch (Method)
            {
                case "start":
                    returnDesc = "AGV小车开始工作";
                    break;
                case "applyToAgv":
                    returnDesc = "AGV小车到达货架";
                    break;
                case "outBin":
                    returnDesc = "AGV小车运载空箱中";
                    break;
                case "applyFromAgv":
                    returnDesc = "AGV小车到达入箱通道口";
                    break;
                case "end":
                    returnDesc = "AGV小车已完成工作";
                    break;
                default:
                    break;
            }

            return returnDesc;
        }




        public CancellationTokenSource Cancel_RefreshAgvBoxAtInput3;
        public void TaskStart_RefreshAgvBoxAtInput3()
        {
            Cancel_RefreshAgvBoxAtInput3 = new CancellationTokenSource();
            Task.Run(() => {
                this.RefreshAgvBoxAtInput3_Order = true;
                ResponseContent returnRes = this.RefreshAgvBoxAtInput3(Cancel_RefreshAgvBoxAtInput3.Token);
            }, Cancel_RefreshAgvBoxAtInput3.Token);
        }
        public bool RefreshAgvBoxAtInput3_Order { get; set; } = false;
        public ResponseContent RefreshAgvBoxAtInput3(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            bool RefreshAgvBoxAtInput3_Self = true;

            while (true && RefreshAgvBoxAtInput3_Order && RefreshAgvBoxAtInput3_Self)
            {
                if (!RefreshAgvBoxAtInput3_Order || !RefreshAgvBoxAtInput3_Self)
                {
                    if (!RefreshAgvBoxAtInput3_Order)
                    {
                        response = response.Error("取消3通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {

                }

                Thread.Sleep(50);

                var findTaskList = this.dbContent.Queryable<AgvSendRequestLog>().Where(x => x.RequestSide == 3 && (x.IsDelete == false || x.IsDelete == true) && !string.IsNullOrEmpty(x.TaskCode))
                                    .OrderByDescending(x => x.CreateTime)
                                    .ToList();
                if (findTaskList.Count > 0)
                {
                    var findTaskEntity = findTaskList[0];
                    string taskCode = findTaskEntity.TaskCode;
                    TaskCode = findTaskEntity.TaskCode;

                    if (findTaskEntity.IsDelete == false)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide3CheckResult.BackColor = Color.LawnGreen;
                            uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = this.ConvertAGVCallBackMethodToDesc3(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                            }
                        }
                        else
                        {
                            this.pbAGVSide3CheckResult.BackColor = Color.OrangeRed;
                            uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = this.ConvertAGVCallBackMethodToDesc3(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                            }
                        }
                    }
                    else if (findTaskEntity.IsDelete == true)
                    {
                        if (TaskCode.ToUpper().IndexOf("ZNCS") > -1)
                        {
                            this.pbAGVSide3CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = "", null);
                            uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = "", null);
                        }
                        else
                        {
                            this.pbAGVSide3CheckResult.BackColor = Color.Gray;
                            uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = findTaskEntity.TaskCode, null);
                            uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = findTaskEntity.BoxNo, null);
                            uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = findTaskEntity.CarcaseNo, null);

                            var findCallBackList = this.dbContent.Queryable<AgvCallBackLog>().Where(x => x.TaskCode.ToLower() == taskCode.ToLower() && x.IsDelete == false)
                                            .OrderByDescending(x => x.CreateTime)
                                            .ToList();
                            if (findCallBackList.Count > 0)
                            {
                                var findCallBackEntity = findCallBackList[0];
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = this.ConvertAGVCallBackMethodToDesc3(findCallBackEntity.Method), null);
                            }
                            else
                            {
                                uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                            }
                        }
                    }
                    else
                    {
                        this.pbAGVSide3CheckResult.BackColor = Color.Gray;
                        uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = "", null);
                        uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = "", null);
                    }
                    
                }
                else
                {
                    this.pbAGVSide3CheckResult.BackColor = Color.Gray;
                    uiContext.Post(_ => this.txtAGVSide3TaskCode.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide3Method.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide3BoxNo.Text = "", null);
                    uiContext.Post(_ => this.txtAGVSide3CarcaseNo.Text = "", null);
                }

                if (!RefreshAgvBoxAtInput3_Order || !RefreshAgvBoxAtInput3_Self)
                {
                    if (!RefreshAgvBoxAtInput3_Order)
                    {
                        response = response.Error("取消3通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                }

                Thread.Sleep(50);

                if (!RefreshAgvBoxAtInput3_Order || !RefreshAgvBoxAtInput3_Self)
                {
                    if (!RefreshAgvBoxAtInput3_Order)
                    {
                        response = response.Error("取消2通道AGV查询展示任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            AppendText("结束 RefreshAgvBoxAtInput3", uiContext);
            return response;
        }
        public void TaskEnd_RefreshAgvBoxAtInput3()
        {
            this.RefreshAgvBoxAtInput3_Order = false;
        }
        private string ConvertAGVCallBackMethodToDesc3(string Method)
        {
            string returnDesc = "";
            switch (Method)
            {
                case "start":
                    returnDesc = "AGV小车开始工作";
                    break;
                case "applyToAgv":
                    returnDesc = "AGV小车到达出箱通道口";
                    break;
                case "arrive":
                    returnDesc = "AGV小车对接箱子中";
                    break;
                case "outBin":
                    returnDesc = "AGV小车运载箱子中";
                    break;
                case "applyFromAgv":
                    returnDesc = "AGV小车到达货架";
                    break;
                case "end":
                    returnDesc = "AGV小车已完成工作";
                    break;
                default:
                    break;
            }

            return returnDesc;
        }




        public CancellationTokenSource Cancel_CallAgvBoxAtInput1;
        public void TaskStart_CallAgvBoxAtInput1()
        {
            Cancel_CallAgvBoxAtInput1 = new CancellationTokenSource();
            Task.Run(() => {
                this.CallAgvBoxAtInput1_Order = true;
                ResponseContent returnRes = this.CallAgvBoxAtInput1(Cancel_CallAgvBoxAtInput1.Token);
            }, Cancel_CallAgvBoxAtInput1.Token);
        }
        public void TaskEnd_CallAgvBoxAtInput1()
        {
            this.CallAgvBoxAtInput1_Order = false;
        }




        public CancellationTokenSource Cancel_CallAgvBoxAtInput2;
        public void TaskStart_CallAgvBoxAtInput2()
        {
            Cancel_CallAgvBoxAtInput2 = new CancellationTokenSource();
            Task.Run(() => {
                this.CallAgvBoxAtInput2_Order = true;
                ResponseContent returnRes = this.CallAgvBoxAtInput2(Cancel_CallAgvBoxAtInput2.Token);
            }, Cancel_CallAgvBoxAtInput2.Token);
        }
        public void TaskEnd_CallAgvBoxAtInput2()
        {
            this.CallAgvBoxAtInput2_Order = false;
        }




        public CancellationTokenSource Cancel_TakeOperateApp;
        public void TaskStart_TakeOperateApp()
        {
            Cancel_TakeOperateApp = new CancellationTokenSource();
            Task.Run(() => {
                this.TakeOperateApp_Order = true;
                ResponseContent returnRes = this.TakeOperateApp(Cancel_TakeOperateApp.Token);
            }, Cancel_TakeOperateApp.Token);
        }
        public void TaskEnd_TakeOperateApp()
        {
            this.AskPickerWork_Order = false;

            this.TakeOperateWortAtOperateApp_Order = false;

            this.TakeOperateApp_Order = false;

            this.TakeScanAtOperateApp_Order = false;

        }




        public CancellationTokenSource Cancel_CallBoxAgvAtOutput3;
        /// 出箱
        public void TaskStart_CallBoxAgvAtOutput3()
        {
            Cancel_CallBoxAgvAtOutput3 = new CancellationTokenSource();
            Task.Run(() => {
                this.CallBoxAgvAtOutput3_Order = true;
                ResponseContent returnRes = this.CallBoxAgvAtOutput3(Cancel_CallBoxAgvAtOutput3.Token);
            }, Cancel_CallBoxAgvAtOutput3.Token);
        }
        public void TaskEnd_CallBoxAgvAtOutput3()
        {
            this.CallBoxAgvAtOutput3_Order = false;
        }




        #endregion Task

        #region PLC init 信息反馈Task

        public CancellationTokenSource Cancel_GetPLCInitInfo_Order;
        public void TaskStart_GetPLCInitInfo()
        {
            Cancel_GetPLCInitInfo_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.GetPLCInitInfo_Order = true;
                ResponseContent returnRes = this.GetPLCInitInfo(Cancel_GetPLCInitInfo_Order.Token);
            }, Cancel_GetPLCInitInfo_Order.Token);
        }
        public bool GetPLCInitInfo_Order { get; set; }
        public ResponseContent GetPLCInitInfo(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool GetPLCInitInfo_Self = true;

            while (true && GetPLCInitInfo_Order)
            {
                Thread.Sleep(50);

                ///码垛机初始化中
                var Result_13294 = client.ReadCoil("13294", stationNumber);
                if (Result_13294.IsSucceed
                    && Result_13294.Value
                    )
                {
                    Thread.Sleep(50);

                    client.Write("14388", false, stationNumber); //1通道AGV小车到位
                    client.Write("14389", false, stationNumber); //1通道起转OK
                    client.Write("14404", false, stationNumber); //1通道箱子码垛入料调入信号

                    client.Write("14488", false, stationNumber); //2通道AGV小车到位
                    client.Write("14489", false, stationNumber); //2通道起转OK
                    client.Write("14504", false, stationNumber); //2通道箱子码垛入料调入信号

                    client.Write("14588", false, stationNumber); //3通道AGV小车到位
                    client.Write("14589", false, stationNumber); //3通道起转OK


                    client.Write("14688", false, stationNumber); //带格箱
                    client.Write("14689", false, stationNumber);
                    client.Write("14690", false, stationNumber); //不带格箱
                    client.Write("14691", false, stationNumber); //NG箱
                    client.Write("14692", false, stationNumber); //空箱清0信号
                    client.Write("14693", false, stationNumber); //扫码超时
                    client.Write("14694", false, stationNumber);


                    client.Write("14738", false, stationNumber); //拍照完成
                    client.Write("14748", false, stationNumber); //当前OK类型的箱子流出


                    client.Write("7011", 0, stationNumber); //7寸箱格子放置
                    client.Write("7012", 0, stationNumber); //13寸箱格子放置
                    client.Write("7013", 0, stationNumber); //混箱格子放置


                    client.Write("14788", false, stationNumber); //扫码完成
                    client.Write("14789", false, stationNumber); //扫码超时

                    client.Write("14289", false, stationNumber); //新工单启动信号保持（工单完成时复位）

                    client.Write("14308", false, stationNumber); //工单完成-》PLC-》前端PLC-》WCS


                    client.Write("14302", false, stationNumber); //箱子流出
                    Thread.Sleep(500);
                    client.Write("14302", true, stationNumber); //箱子流出
                    Thread.Sleep(500);
                    client.Write("14302", false, stationNumber); //箱子流出

                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);

                    Thread.Sleep(50);
                }


                if (!GetPLCInitInfo_Order || !GetPLCInitInfo_Self)
                {
                    if (!GetPLCInitInfo_Order)
                    {
                        response = response.Error("任务GetPLCInitInfo遇到异常,取消工作!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            return response;
        }
        public void TaskEnd_GetPLCInitInfo()
        {
            this.GetPLCInitInfo_Order = false;
        }

        #endregion 

        #region PLC信息返回Task

        public CancellationTokenSource Cancel_GetPLCBinInfo_Order;
        public void TaskStart_GetPLCBinInfo()
        {
            Cancel_GetPLCBinInfo_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.GetPLCBinInfo_Order = true;
                ResponseContent returnRes = this.GetPLCBinInfo(Cancel_GetPLCBinInfo_Order.Token);
            }, Cancel_GetPLCBinInfo_Order.Token);
        }
        public bool GetPLCBinInfo_Order { get; set; }
        public ResponseContent GetPLCBinInfo(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool GetPLCBinInfo_Self = true;

            while (true && GetPLCBinInfo_Order)
            {
                Thread.Sleep(50);

                ///码垛位箱子有无检测
                var Result_13291 = client.ReadCoil("13291", stationNumber);
                if (Result_13291.IsSucceed
                    && Result_13291.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbBoxCheckResult.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbBoxCheckResult.BackColor = Color.OrangeRed;

                    uiContext.Post(_ => this.curBufBoxNo.Text = "", null);
                    uiContext.Post(_ => this.curBufIsEmpty.Text = "", null);
                    uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = "", null);

                    Thread.Sleep(50);
                }

                ///入料皮带处有料检测
                var Result_13292 = client.ReadCoil("13292", stationNumber);
                if (Result_13292.IsSucceed
                    && Result_13292.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbReelIdCheckResult.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbReelIdCheckResult.BackColor = Color.OrangeRed;

                    uiContext.Post(_ => this.curBufReelId.Text = "", null);
                    uiContext.Post(_ => this.curBufReelIdBindOutorderNo.Text = "", null);

                    Thread.Sleep(50);
                }

                

                ///初始化信号
                var Result_13294 = client.ReadCoil("13294", stationNumber);
                if (Result_13294.IsSucceed
                    && Result_13294.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbUpInitialInfo.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbUpInitialInfo.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///报警
                var Result_13302 = client.ReadCoil("13302", stationNumber);
                if (Result_13302.IsSucceed
                    && Result_13302.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbRaiseError.BackColor = Color.OrangeRed;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbRaiseError.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///急停
                var Result_13293 = client.ReadCoil("13293", stationNumber);
                if (Result_13293.IsSucceed
                    && Result_13293.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbUrgentStop.BackColor = Color.OrangeRed;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbUrgentStop.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///自动模式
                var Result_13304 = client.ReadCoil("13304", stationNumber);
                if (Result_13304.IsSucceed
                    && Result_13304.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbAutoModel.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbAutoModel.BackColor = Color.OrangeRed;
                    Thread.Sleep(50);
                }

                ///码垛机自动模式运行中
                var Result_13301 = client.ReadCoil("13301", stationNumber);
                if (Result_13301.IsSucceed
                    && Result_13301.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbAutoModeling.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbAutoModeling.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }



                ///码垛机初始化中
                var Result_13312 = client.ReadCoil("13312", stationNumber);
                if (Result_13312.IsSucceed
                    && Result_13312.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbUpInitialing.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbUpInitialing.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///汇流皮带初始化中
                var Result_13313 = client.ReadCoil("13313", stationNumber);
                if (Result_13313.IsSucceed
                    && Result_13313.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbStreamInitialing.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbStreamInitialing.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///码垛机初始化OK
                var Result_13305 = client.ReadCoil("13305", stationNumber);
                if (Result_13305.IsSucceed
                    && Result_13305.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbUpInitialOK.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbUpInitialOK.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///汇流皮带初始化OK
                var Result_13306 = client.ReadCoil("13306", stationNumber);
                if (Result_13306.IsSucceed
                    && Result_13306.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbStreamInitialOK.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbStreamInitialOK.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///码垛机自动中
                Result_13301 = client.ReadCoil("13301", stationNumber);
                if (Result_13301.IsSucceed
                    && Result_13301.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbUpAutoing.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbUpAutoing.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }

                ///汇流皮带自动中
                var Result_13303 = client.ReadCoil("13303", stationNumber);
                if (Result_13303.IsSucceed
                    && Result_13303.Value
                    )
                {
                    Thread.Sleep(50);
                    this.pbSteamAutoing.BackColor = Color.LawnGreen;
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(50);
                    this.pbSteamAutoing.BackColor = Color.Gray;
                    Thread.Sleep(50);
                }



                if (!GetPLCBinInfo_Order || !GetPLCBinInfo_Self)
                {
                    if (!GetPLCBinInfo_Order)
                    {
                        response = response.Error("任务GetPLCBinInfo遇到异常,取消工作!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            return response;
        }
        public void TaskEnd_GetPLCBinInfo()
        {
            this.GetPLCBinInfo_Order = false;
        }

        #endregion

        #region PLC NG 信息返回Task

        public CancellationTokenSource Cancel_GetNGInfo_Order;
        public void TaskStart_GetNGInfo()
        {
            Cancel_GetNGInfo_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.GetNGInfo_Order = true;
                ResponseContent returnRes = this.GetNGInfo(Cancel_GetNGInfo_Order.Token);
            }, Cancel_GetNGInfo_Order.Token);
        }
        public bool GetNGInfo_Order { get; set; }
        public ResponseContent GetNGInfo(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool GetNGInfo_Self = true;

            bool isUpdateDB = false;

            while (true && GetNGInfo_Order && GetNGInfo_Self)
            {
                Thread.Sleep(50);

                ///PLC NG Error Infor
                var Result_7010 = client.ReadInt16("7010", stationNumber);
                if (Result_7010.IsSucceed
                    )
                {
                    int Result_7010_ValueResult = Result_7010.Value;

                    Thread.Sleep(50);

                    var findMapppingNGItemList = this.NGDictionary.FindAll(x => x.NGNo == Result_7010_ValueResult);
                    if (findMapppingNGItemList.Count > 0)
                    {
                        var findMapppingNGItem = findMapppingNGItemList[0];

                        uiContext.Post(_ => this.txt_NGDisplay.Text = findMapppingNGItem.NGDesc, null);

                        if (findMapppingNGItem.NGNo == 88)
                        {
                            if (!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
                            {
                                var outOrderNo = this.GetOutOrderNoByBoxNo(this.Buffer_BoxNo_AtOperate);
                                if (!string.IsNullOrEmpty(outOrderNo))
                                {
                                    var outOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                                    if (outOrderEntity != null)
                                    {
                                        outOrderEntity.OutboundJobStatus = 3;
                                        //outOrderEntity.EndTime = DateTime.Now;
                                        outOrderEntity.UpdateTime = DateTime.Now;
                                        outOrderEntity.UpdateUserId = -1;
                                        outOrderEntity.UpdateUserName = "码垛机";

                                        isUpdateDB = this.dbContent.Updateable<Zollner_InOutOrder>(outOrderEntity).ExecuteCommand() > 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            isUpdateDB = false;
                        }

                        GetNGInfo_Self = false;
                    }
                    else
                    {
                        if (Result_7010_ValueResult == 0)
                        {
                            uiContext.Post(_ => this.txt_NGDisplay.Text = "", null);
                        }
                        else
                        {
                            uiContext.Post(_ => this.txt_NGDisplay.Text = "NG" + "代码" + Result_7010_ValueResult, null);

                            GetNGInfo_Self = false;
                        }
                    }

                    Thread.Sleep(50);

                }
                else
                {
                    Thread.Sleep(50);
                    this.txt_NGDisplay.Text = "";
                    isUpdateDB = false;
                    Thread.Sleep(50);
                }


                if (!GetNGInfo_Order || !GetNGInfo_Self)
                {
                    if (!GetNGInfo_Order)
                    {
                        response = response.Error("任务GetNGInfo遇到异常,取消工作!");
                    }

                    
                    //this.btn_autoagv1_stop_Click(null, null);
                    
                    //this.btn_autoagv2_stop_Click(null, null);

                    //this.btn_autoagv3_stop_Click(null, null);

                    //取消掉自动任务
                    this.TaskEnd_TakeOperateApp();
                    uiContext.Post(_ => this.btn_autoprc_stop.Enabled = false, null);
                    Thread.Sleep(10000);
                    uiContext.Post(_ => this.btn_autoprc_start.Enabled = true, null);
                    //this.TaskEnd_CallBoxAgvAtOutpu3();

                    break;
                }
                else
                {
                    continue;
                }


            }

            return response;
        }
        public void TaskEnd_GetNGInfo()
        {
            this.GetNGInfo_Order = false;
        }

        #endregion

        #region 料盘到位,拍照识别,自动赋值

        public CancellationTokenSource Cancel_ReelAtPosition_Order;
        public void TaskStart_ReelAtPosition()
        {
            Cancel_ReelAtPosition_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.ReelAtPosition_Order = true;
                ResponseContent returnRes = this.ReelAtPosition(Cancel_ReelAtPosition_Order.Token);
            }, Cancel_ReelAtPosition_Order.Token);
        }
        public bool ReelAtPosition_Order { get; set; }
        public ResponseContent ReelAtPosition(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool ReelAtPosition_Self = true;

            while (true && ReelAtPosition_Order && ReelAtPosition_Self)
            {
                Thread.Sleep(50);

                Buf_Last_Catch_Reel = Buf_Catch_Reel;

                ///入料皮带处有料检测【传感器】
                bool is_13290_ok = false;
                var Result_13290 = client.ReadCoil("13290", stationNumber);
                if (Result_13290.IsSucceed
                    && Result_13290.Value
                    )
                {
                    is_13290_ok = true;
                }
                else
                {
                    is_13290_ok = false;
                }

                ///入料皮带处有料检测 【PLC】
                bool is_13291_ok = false;
                var Result_13291 = client.ReadCoil("13292", stationNumber);
                if (Result_13291.IsSucceed
                    && Result_13291.Value
                    )
                {
                    is_13291_ok = true;
                }
                else
                {
                    is_13291_ok = false;
                }


                Buf_Catch_Reel = false;
                if (is_13290_ok)
                {
                    if (is_13291_ok)
                    {
                        AppendText($"入料皮带处有料检测【传感器】有感应到料盘,入料皮带处料到位标志位【PLC】返回数据", uiContext);
                        Buf_Catch_Reel = true;
                    }
                    else
                    {
                        AppendText($"入料皮带处有料检测【传感器】有感应到料盘,但入料皮带处料到位标志位【PLC】没有返回数据", uiContext);
                        Buf_Catch_Reel = false;
                    }
                }
                else
                {
                    AppendText($"入料皮带处有料检测【传感器】没有感应到料盘", uiContext);
                }

                var StartNextStep = (!this.Buf_Last_Catch_Reel) && (this.Buf_Catch_Reel);

                var EndNextStep = (this.Buf_Last_Catch_Reel) && (!this.Buf_Catch_Reel);

                if (StartNextStep)
                {
                    AppendText($"入料皮带处进行料盘拍照检测工作", uiContext);

                    ResponseContent Res_GetPhotoString = this.GetPhotoString(null);

                    int retrytime = 0;
                    while (retrytime < 3 && string.IsNullOrEmpty(this.Buffer_ReelId_AtOperate))
                    {
                        Res_GetPhotoString = this.GetPhotoString(null);
                        retrytime = retrytime + 1;
                        Thread.Sleep(250);
                    }

                    if (Res_GetPhotoString.Status)
                    {
                        var tempReelId = this.Buffer_ReelId_AtOperate;
                        this.Buf_Catch_ReelId = this.Buffer_ReelId_AtOperate;
                        if (this.CheckRealId(tempReelId))
                        {
                            this.Buf_Catch_ReelId_CheckResult = true;
                            this.SetReelTotallyInfor(tempReelId);
                        }
                        else
                        {
                            this.Buf_Catch_ReelId_CheckResult = false;
                            this.EmptyReelTotallyInfor();
                        }
                    }
                    else
                    {
                        AppendText($"入料皮带处有料检测【传感器】没有发现料盘", uiContext);
                    }
                }
                else if(EndNextStep)
                {
                    this.Buf_Catch_ReelId_CheckResult = false;
                    this.EmptyReelTotallyInfor();
                }
                else
                {
                    AppendText($"码垛位箱子不进行任何逻辑工作", uiContext);

                    Thread.Sleep(1000);
                }


                if (!ReelAtPosition_Order || !ReelAtPosition_Self)
                {
                    if (!ReelAtPosition_Order)
                    {
                        response = response.Error("任务ReelAtPosition遇到异常,取消工作!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            return response;
        }
        public void TaskEnd_ReelAtPosition()
        {
            this.ReelAtPosition_Order = false;
        }

        public void SetReelTotallyInfor(string tempReelId)
        {
            this.Buf_Pending_ReelId_Entity = this.GetMaterialStockEntityByReelId(tempReelId);
            this.Buf_Pending_ReelId_MaterialSize = this.GetMaterialSize(tempReelId);
            this.Buf_Process_OutOrderNo_ByReelId = this.GetOutOrderNoByReelId(tempReelId);
            if (!string.IsNullOrEmpty(this.Buf_Process_OutOrderNo_ByReelId))
            {
                this.Buf_Process_OutOrderEntity_ByReelId = this.GetOutOrderEntityByOutOrderNo(this.Buf_Process_OutOrderNo_ByReelId);
                this.Buf_Process_OutOrderDetailList_ByReelId = this.GetOutOrderDetailListByOutOrderNo(this.Buf_Process_OutOrderNo_ByReelId);
                this.Buf_Processed_ReelIdList_ByReelId = this.GetReelIdListInBoxDetailListByBoxNo(this.Buf_Process_OutOrderNo_ByReelId);
            }
            else
            {
                this.Buf_Process_OutOrderEntity_ByReelId = null;
                this.Buf_Process_OutOrderDetailList_ByReelId = null;
                this.Buf_Processed_ReelIdList_ByReelId = null;
            }
        }

        public void EmptyReelTotallyInfor()
        {
            this.Buf_Pending_ReelId_Entity = null;
            this.Buf_Pending_ReelId_MaterialSize = 0;
            this.Buf_Process_OutOrderNo_ByReelId = "";
            this.Buf_Process_OutOrderEntity_ByReelId = null;
            this.Buf_Process_OutOrderDetailList_ByReelId = null;
            this.Buf_Processed_ReelIdList_ByReelId = null;
    }

        #endregion

        #region 箱子到位，拍照识别,自动赋值

        public CancellationTokenSource Cancel_BoxAtPosition_Order;
        public void TaskStart_BoxAtPosition()
        {
            Cancel_BoxAtPosition_Order = new CancellationTokenSource();
            Task.Run(() => {
                this.BoxAtPosition_Order = true;
                ResponseContent returnRes = this.BoxAtPosition(Cancel_BoxAtPosition_Order.Token);
            }, Cancel_BoxAtPosition_Order.Token);
        }
        public bool BoxAtPosition_Order { get; set; }
        public ResponseContent BoxAtPosition(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool BoxAtPosition_Self = true;

            while (true && BoxAtPosition_Order && BoxAtPosition_Self)
            {
                Thread.Sleep(50);

                Buf_Last_Catch_Box = Buf_Catch_Box;

                ///码垛位箱子检测传感器【传感器】
                bool is_13291_ok = false;
                var Result_13291 = client.ReadCoil("13291", stationNumber);
                if (Result_13291.IsSucceed
                    && Result_13291.Value
                    )
                {
                    is_13291_ok = true;
                }
                else
                {
                    is_13291_ok = false;
                }

                if (is_13291_ok)
                {
                    AppendText($"码垛位箱子检测【传感器】有感应到箱子", uiContext);
                    Buf_Catch_Box = true;
                }
                else
                {
                    AppendText($"码垛位箱子检测【传感器】没有感应到箱子", uiContext);
                    Buf_Catch_Box = false;
                }

                var StartNextStep = (!this.Buf_Last_Catch_Box) && (this.Buf_Catch_Box);

                var EndNextStep = (this.Buf_Last_Catch_Box) && (!this.Buf_Catch_Box);

                if (StartNextStep)
                {
                    AppendText($"码垛位箱子进行箱子拍照检测工作", uiContext);

                    ResponseContent Res_GetScan1String = this.GetScan1String(null);

                    int retrytime = 0;
                    while (retrytime < 3 && string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
                    {
                        Res_GetScan1String = this.GetScan1String(null);
                        retrytime = retrytime + 1;
                        Thread.Sleep(250);
                    }

                    if (Res_GetScan1String.Status)
                    {
                        var tempBoxNo = this.Buffer_BoxNo_AtOperate;
                        this.Buf_Catch_BoxNo = this.Buffer_BoxNo_AtOperate;
                        if (this.CheckBoxNo(tempBoxNo))
                        {
                            this.Buf_Catch_BoxNo_CheckResult = true;
                            this.SetBoxTotallyInfor(tempBoxNo);
                        }
                        else
                        {
                            this.Buf_Catch_BoxNo_CheckResult = false;
                            this.EmptyBoxTotallyInfor();
                        }
                    }
                    else
                    {
                        this.Buf_Catch_BoxNo_CheckResult = false;
                        this.EmptyBoxTotallyInfor();
                        AppendText($"码垛位箱子进行箱子拍照检测工作 没有发现箱子", uiContext);
                    }
                }
                else if(EndNextStep)
                {
                    this.Buf_Catch_BoxNo_CheckResult = false;
                    this.EmptyBoxTotallyInfor();
                }
                else
                {
                    AppendText($"码垛位箱子不进行任何逻辑工作", uiContext);

                    Thread.Sleep(5000);
                }


                if (!BoxAtPosition_Order || !BoxAtPosition_Self)
                {
                    if (!BoxAtPosition_Order)
                    {
                        response = response.Error("任务BoxAtPosition遇到异常,取消工作!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            return response;
        }
        public void TaskEnd_BoxAtPosition()
        {
            this.BoxAtPosition_Order = false;
        }

        public void SetBoxTotallyInfor(string tempBoxNo)
        {
            this.Buf_Pending_Box_Entity = this.GetBoxEntityByBoxNo(tempBoxNo);
            this.Buf_Pending_BoxDetail_List = this.GetBoxDetailListByBoxNo(tempBoxNo);
            this.Buf_Process_OutOrderNo_ByBoxNo = this.GetOutOrderNoByBoxNo(tempBoxNo);
            if (!string.IsNullOrEmpty(this.Buf_Process_OutOrderNo_ByBoxNo))
            {
                this.Buf_Process_OutOrderEntity_ByBoxNo = this.GetOutOrderEntityByOutOrderNo(this.Buf_Process_OutOrderNo_ByBoxNo);
                this.Buf_Process_OutOrderDetailList_ByBoxNo = this.GetOutOrderDetailListByOutOrderNo(this.Buf_Process_OutOrderNo_ByBoxNo);
                this.Buf_Processed_ReelIdList_ByBoxNo = this.GetReelIdListInBoxDetailListByBoxNo(this.Buf_Process_OutOrderNo_ByBoxNo);
            }
            else
            {
                this.Buf_Process_OutOrderEntity_ByBoxNo = null;
                this.Buf_Process_OutOrderDetailList_ByBoxNo = null;
                this.Buf_Processed_ReelIdList_ByBoxNo = null;
            }
        }

        public void EmptyBoxTotallyInfor()
        {
            this.Buf_Pending_Box_Entity = null;
            this.Buf_Pending_BoxDetail_List = null;
            this.Buf_Process_OutOrderNo_ByBoxNo = "";
            this.Buf_Process_OutOrderEntity_ByBoxNo = null;
            this.Buf_Process_OutOrderDetailList_ByBoxNo = null;
            this.Buf_Processed_ReelIdList_ByBoxNo = null;
        }

        #endregion

        #region  Process

        #region Iot Client

        public CancellationTokenSource Cancel_RefreshIOT;
        public void TaskStart_RefreshIOT()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            Cancel_RefreshIOT = new CancellationTokenSource();
            Task.Run(() => {
                AppendText($"开启IOT检查任务", uiContext);
                this.RefreshIOT_Order = true;
                ResponseContent returnRes = this.RefreshIOT(Cancel_RefreshIOT.Token);
            }, Cancel_RefreshIOT.Token);
        }
        public bool RefreshIOT_Order { get; set; } = false;
        public ResponseContent RefreshIOT(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool RefreshIOT_Self = true;

            while (true && RefreshIOT_Order && RefreshIOT_Self)
            {
                if (!RefreshIOT_Order || !RefreshIOT_Self)
                {
                    if (!RefreshIOT_Order)
                    {
                        response = response.Error("取消IOT检查任务!");
                    }

                    break;
                }
                else
                {

                }

                Thread.Sleep(50);

                if (client != null && !client.Connected)
                {
                    var plcadd = false;

                    client = new ModbusTcpClient("192.168.1.88", 502, format: format, plcAddresses: plcadd);

                    var result = client.Open();

                    if (result.IsSucceed)
                    {
                        client.Write("14290", false, stationNumber);
                        client.Write("14290", true, stationNumber);

                        AppendText($"重新连接成功", uiContext);
                    }
                    else
                    {
                        client.Write("14290", true, stationNumber);
                        client.Write("14290", false, stationNumber);

                        AppendText($"重新连接失败", uiContext);
                    }
                }

                Thread.Sleep(60 * 1000);

                Thread.Sleep(50);

                if (!RefreshIOT_Order || !RefreshIOT_Self)
                {
                    if (!RefreshIOT_Order)
                    {
                        response = response.Error("取消IOT检查任务!");
                    }

                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }

                Thread.Sleep(50);

                if (!RefreshIOT_Order || !RefreshIOT_Self)
                {
                    if (!RefreshIOT_Order)
                    {
                        response = response.Error("取消IOT检查任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            return response;
        }
        public void TaskEnd_RefreshIOT()
        {
            this.RefreshIOT_Order = false;
        }

        #endregion

        #region Beat

        public CancellationTokenSource Cancel_RefreshBeat;
        public void TaskStart_RefreshBeat()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            Cancel_RefreshBeat = new CancellationTokenSource();
            Task.Run(() => {
                AppendText($"开启心跳任务", uiContext);
                this.RefreshBeat_Order = true;
                ResponseContent returnRes = this.RefreshBeat(Cancel_RefreshBeat.Token);
            }, Cancel_RefreshBeat.Token);
        }
        public bool RefreshBeat_Order { get; set; } = false;
        public ResponseContent RefreshBeat(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool RefreshBeat_Self = true;

            bool writeValue = false;

            while (true && RefreshBeat_Order && RefreshBeat_Self)
            {
                if (!RefreshBeat_Order || !RefreshBeat_Self)
                {
                    if (!RefreshBeat_Order)
                    {
                        response = response.Error("取消心跳任务!");
                    }

                    break;
                }
                else
                {

                }

                Thread.Sleep(50);

                var Result_14288 = client.Write("14288", writeValue, stationNumber);
                if (Result_14288.IsSucceed)
                {
                    writeValue = !writeValue;
                }

                Thread.Sleep(50);

                if (!RefreshBeat_Order || !RefreshBeat_Self)
                {
                    if (!RefreshBeat_Order)
                    {
                        response = response.Error("取消心跳任务!");
                    }

                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }

                Thread.Sleep(50);

                if (!RefreshBeat_Order || !RefreshBeat_Self)
                {
                    if (!RefreshBeat_Order)
                    {
                        response = response.Error("取消心跳任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            return response;
        }
        public void TaskEnd_RefreshBeat()
        {
            this.RefreshBeat_Order = false;
        }

        #endregion

        #region AGV

        public string CallWebApi_CallAgvBoxAtInput1()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CallAgvBoxAtInput1";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content;
            }

            return resContent;
        }

        public string CallWebApi_CallAgvBoxAtInput2()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CallAgvBoxAtInput2";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", zollner_session_id);
            //request.AddHeader("Accept", "application/json");
            //var postBody = new { BatchBC = reelId, targetLocationBC = boxEntity.RelevanceCode, TransferType = "internal" };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content;
            }

            return resContent;
        }

        public string CallWebApi_CallAgvBoxAtOutput3(string BoxNo)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CallAgvBoxAtOutput3";
            url = url + "/" + BoxNo;
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", zollner_session_id);
            //request.AddHeader("Accept", "application/json");
            //var postBody = new { BatchBC = reelId, targetLocationBC = boxEntity.RelevanceCode, TransferType = "internal" };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content;
            }

            return resContent;
        }

        public string CallWebApi_ArriveInputSide(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/ArriveInputSide";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_ArriveOutputSide(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/ArriveOutputSide";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_AdjustInputSide(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/AdjustInputSide";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_AdjustOutputSide(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/AdjustOutputSide";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_CallAgvStartInputRoll(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CallAgvStartInputRoll";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_CallAgvStartOutputRoll(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CallAgvStartOutputRoll";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_CompleteInputWork(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CompleteInputWork";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        public string CallWebApi_CompleteOutputWork(string TaskCode)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CompleteOutputWork";
            url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            return resContent;
        }

        #endregion 


        #region Input1
        public bool CallAgvBoxAtInput1_Order { get; set; } = false;
        public ResponseContent CallAgvBoxAtInput1(object para)
        {
            ResponseContent response = new ResponseContent();
            
            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            bool CallAgvBoxAtInput1_Self = true;

            while (true && CallAgvBoxAtInput1_Order && CallAgvBoxAtInput1_Self)
            {
                Thread.Sleep(50);

                ///1
                //1通道允许上料信号【13388】
                var Result_13388 = client.ReadCoil("13388", stationNumber);
                if (true 
                    && Result_13388.IsSucceed
                    && Result_13388.Value
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"1通道允许上料信号【13388】{Result_13388.Value}", uiContext);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {
 
                    }

                    Thread.Sleep(50);

                    //2
                    //呼叫AGV小车送空箱过来
                    Thread.Sleep(50);

                    TaskCode = this.CallWebApi_CallAgvBoxAtInput1();
                    TaskCode = TaskCode.Replace("\"", "");

                    if (string.IsNullOrEmpty(TaskCode) || TaskCode.ToUpper().IndexOf("ZNCS") == -1)
                    {
                        AppendText($"1通道呼叫AGV小车送空箱过来 获取TaskCode失败 【{TaskCode}】 请检查AGV任务清单", uiContext);

                        var Result_13738 = client.Write("13738", true, stationNumber);

                        Thread.Sleep(5000);

                        continue;
                    }
                    else
                    {
                        AppendText($"1通道呼叫AGV小车送空箱过来 获取TaskCode【{TaskCode}】", uiContext);

                        var Result_13738 = client.Write("13738", false, stationNumber);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //3
                    //1通道AGV小车到位货架信号
                    Thread.Sleep(50);

                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        bool arriveOutputSide = this.CallWebApi_ArriveOutputSide(TaskCode) == "1";
                        if (arriveOutputSide)
                        {
                            AppendText("1通道AGV小车已到位货架", uiContext);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //4
                    //要求AGV转动-货架处取箱子
                    Thread.Sleep(50);

                    if (true && CallAgvBoxAtInput1_Order)
                    {
                        AppendText("要求1通道AGV货架处取箱子", uiContext);
                        var resultStr_CallWebApi_CallAgvStartOutputRoll = this.CallWebApi_CallAgvStartOutputRoll(TaskCode);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //5
                    //AGV到达1通道位置
                    Thread.Sleep(50);

                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        bool arriveInputSide = this.CallWebApi_ArriveInputSide(TaskCode) == "1";
                        if (arriveInputSide)
                        {
                            AppendText("检测到 1通道AGV小车已到位", uiContext);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //6
                    //1通道AGV小车到位信号【14388】
                    Thread.Sleep(50);

                    Result Result_14388;
                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        Result_14388 = client.Write("14388", true, stationNumber);
                        if (Result_14388.IsSucceed)
                        {
                            AppendText("1通道写入AGV小车到位信号【14388】", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    //7
                    //1通道起转等待起转命令工作信号【13389】
                    Thread.Sleep(50);
                    AppendText("开始 1通道起转等待起转命令工作信号【13389】", uiContext);
                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        var Result_13389 = client.ReadCoil("13389", stationNumber);
                        if (Result_13389.IsSucceed && Result_13389.Value)
                        {

                            AppendText($"[读取 13389 成功]：{Result_13389.Value}", uiContext);
                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            AppendText("擦除 前一轮写入的信号【14388】", uiContext);
                            Result_14388 = client.Write("14388", false, stationNumber);
                            Thread.Sleep(50);

                            break;
                        }
                        else
                        {
                            AppendText($"[读取 13389 失败]：{Result_13389.Value}", uiContext);
                            Result_14388 = client.Write("14388", true, stationNumber);
                            continue;
                        }
                    }
                    AppendText("结束 1通道起转等待起转命令工作信号【13389】", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    ///8
                    //要求1通道起转信号【14389】
                    Thread.Sleep(50);

                    AppendText("开始 要求1通道起转信号【14389】", uiContext);
                    Result Result_14389;
                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        Result_14389 = client.Write("14389", true, stationNumber);
                        if (Result_14389.IsSucceed)
                        {
                            AppendText($"[写入 14389 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            AppendText($"[写入 14389 失败]", uiContext);
                            continue;
                        }
                    }
                    AppendText("结束 要求1通道起转信号【14389】", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {
      
                    }

                    Thread.Sleep(50);


                    //9
                    //通知要求AGV转动放箱
                    Thread.Sleep(50);

                    if (true && CallAgvBoxAtInput1_Order)
                    {
                        AppendText("要求1通道AGV起转", uiContext);
                        var resultStr_CallWebApi_CallAgvStartInputRoll = this.CallWebApi_CallAgvStartInputRoll(TaskCode);
                    }
                    else
                    {
                        break;
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {
                   
                    }

                    Thread.Sleep(50);


                    //10
                    //AGV上报已调整完，已开始工作
                    Thread.Sleep(50);

                    Thread.Sleep(9000);
                    //while (true && CallAgvBoxAtInput1_Order && CallAgvBoxAtInput1_Self)
                    //{
                    //    bool arriveInputSide = this.CallWebApi_AdjustInputSide(TaskCode) == "1";
                    //    if (arriveInputSide)
                    //    {
                    //        AppendText("检测到 1通道AGV小车已准备OK的上报消息", uiContext);

                    //        break;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}

                    Thread.Sleep(50);

                    ///11
                    //1通道入料OK【13390】
                    //1通道入料超时报警【13391】
                    Thread.Sleep(50);

                    AppendText("开始 1通道入料OK【13390】", uiContext);
                    while (true && CallAgvBoxAtInput1_Order)
                    {
                        Thread.Sleep(50);

                        var Result_13390 = client.ReadCoil("13390", stationNumber);
                        var Result_13391 = client.ReadCoil("13391", stationNumber);
                        if (Result_13390.IsSucceed && Result_13390.Value)
                        {
                            //Success
                            response = response.OK("1通道入料OK!");
                            AppendText("1通道入料OK!", uiContext);

                            AppendText($"[读取 13390 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            AppendText("擦除刚才前一轮写入的信号【14389】", uiContext);
                            Result_14389 = client.Write("14389", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteInputWork(TaskCode);

                            //CallAgvBoxAtInput1_Self = false;

                            break;
                        }
                        else if (Result_13391.IsSucceed && Result_13391.Value)
                        {
                            //Raise Error
                            response = response.Error("1通道入料超时报警!");
                            AppendText("1通道入料超时报警!", uiContext);

                            AppendText($"[读取 13391 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            AppendText("擦除刚才前一轮写入的信号【14389】", uiContext);
                            Result_14389 = client.Write("14389", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO
                            //AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteInputWork(TaskCode);

                            //CallAgvBoxAtInput1_Self = false;

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);


                    AppendText("结束 1通道入料OK【13390】", uiContext);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        if (!CallAgvBoxAtInput1_Order)
                        {
                            response = response.Error("取消1通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    Thread.Sleep(10000);
                }
                else
                {
                    Thread.Sleep(1000);
                }

                if (!CallAgvBoxAtInput1_Order || !CallAgvBoxAtInput1_Self)
                {
                    if (!CallAgvBoxAtInput1_Order)
                    {
                        response  = response.Error("取消1通道AGV任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            AppendText("结束 1通道AGV任务", uiContext);
            return response;
        }

        public bool AskBoxRollFromInput1_Order { get; set; } = false;
        public ResponseContent AskBoxRollFromInput1(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool AskBoxRollFromInput1_Self = true;

            AppendText("开始 AskBoxRollFromInput1", uiContext);

            while (true && AskBoxRollFromInput1_Order && AskBoxRollFromInput1_Self)
            {
                Thread.Sleep(50);

                //取消任务
                if (!AskBoxRollFromInput1_Order)
                {
                    if (!AskBoxRollFromInput1_Order)
                    {
                        response = response.Error("取消码垛呼叫1通道箱子任务!");
                    }

                    break;
                }
                else
                {
                    
                }

                Thread.Sleep(50);

                Thread.Sleep(50);
                ///1
                //1通道箱子码垛入料准备OK信号【13404】
                var Result_13404 = client.ReadCoil("13404", stationNumber);
                if (Result_13404.IsSucceed
                    && Result_13404.Value
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"[读取 13404 成功]：{Result_13404.Value}", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);

                    //取消任务
                    if (!AskBoxRollFromInput1_Order)
                    {
                        if (!AskBoxRollFromInput1_Order)
                        {
                            response = response.Error("取消码垛呼叫1通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    ///2
                    //1通道箱子码垛入料调入信号【14404】
                    Thread.Sleep(50);

                    Result Result_14404;
                    while (AskBoxRollFromInput1_Order)
                    {
                        Result_14404 = client.Write("14404", true, stationNumber);
                        if (Result_14404.IsSucceed)
                        {
                            AppendText($"[写入 14404 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            AppendText($"[写入 14404 失败]", uiContext);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);

                    //取消任务
                    if (!AskBoxRollFromInput1_Order)
                    {
                        if (!AskBoxRollFromInput1_Order)
                        {
                            response = response.Error("取消码垛呼叫1通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    ///3
                    //1通道箱子码垛入料OK信号【13405】
                    //或者
                    //作业台-扫码触发信号【13688】
                    Thread.Sleep(50);

                    while (AskBoxRollFromInput1_Order)
                    {
                        Thread.Sleep(50);

                        var Result_13405 = client.ReadCoil("13405", stationNumber);
                        var Result_13688 = client.ReadCoil("13688", stationNumber);
                        if (
                            (Result_13405.IsSucceed && Result_13405.Value) 
                            || 
                            (Result_13688.IsSucceed && Result_13688.Value)
                            )
                        {
                            //Success
                            response = response.OK("1通道箱子码垛入料OK!");
                            AppendText("1通道箱子码垛入料OK!", uiContext);

                            if ((Result_13405.IsSucceed && Result_13405.Value))
                            {
                                AppendText($"[读取 13405 成功]", uiContext);
                            }
                            else if ((Result_13688.IsSucceed && Result_13688.Value))
                            {
                                AppendText($"[读取 13688 成功]", uiContext);
                            }

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            AppendText("擦除刚才前一轮写入的信号【14404】", uiContext);
                            Result_14404 = client.Write("14404", false, stationNumber);
                            Thread.Sleep(50);

                            //擦除先前工作台设置的信号
                            Thread.Sleep(50);
                            //擦除箱子类型
                            AppendText("擦除箱子类型【14688,14689,14690,14691,14692】", uiContext);
                            var Result_14688 = client.Write("14688", false, stationNumber);
                            var Result_14689 = client.Write("14689", false, stationNumber);
                            var Result_14690 = client.Write("14690", false, stationNumber);
                            var Result_14691 = client.Write("14691", false, stationNumber);
                            var Result_14692 = client.Write("14692", false, stationNumber);
                            ////针对动作请求操作
                            //var Result_14748 = client.Write("14748", false, stationNumber);
                            //var Result_14749 = client.Write("14749", false, stationNumber);
                            Thread.Sleep(50);

                            this.TakeScanAtOperateApp_Order = true;
                            this.TakeScanAtOperateApp(null);
                            this.TakeScanAtOperateApp_Order = false;

                            Thread.Sleep(50);

                            AskBoxRollFromInput1_Self = false;
                            AskBoxRollFromInput1_Order = false;

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    AppendText("结束 1通道箱子码垛入料OK信号【13405】", uiContext);

                    Thread.Sleep(50);

                }

                if (!AskBoxRollFromInput1_Order || !AskBoxRollFromInput1_Self)
                {
                    if (!AskBoxRollFromInput1_Order)
                    {
                        response = response.Error("取消码垛呼叫1通道箱子任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }
            }

            Thread.Sleep(50);


            AppendText("结束码垛呼叫1通道箱子任务", uiContext);

            return response;
        }

        #endregion Input1

        #region Input2

        public bool CallAgvBoxAtInput2_Order { get; set; } = false;
        private ResponseContent CallAgvBoxAtInput2(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            while (true && CallAgvBoxAtInput2_Order)
            {
                Thread.Sleep(50);
                ///1
                //2通道允许上料信号【13488】
                var Result_13488 = client.ReadCoil("13488", stationNumber);
                if (true 
                    && Result_13488.IsSucceed
                    && Result_13488.Value
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"2通道允许上料信号【13488】{Result_13488.Value}", uiContext);

                    Thread.Sleep(50);

                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {
                        
                    }

                    Thread.Sleep(50);

                    //2
                    //呼叫AGV小车送空箱过来
                    Thread.Sleep(50);

                    TaskCode = this.CallWebApi_CallAgvBoxAtInput2();
                    TaskCode = TaskCode.Replace("\"", "");

                    if (string.IsNullOrEmpty(TaskCode) || TaskCode.ToUpper().IndexOf("ZNCS") == -1)
                    {
                        AppendText($"2通道 呼叫AGV小车送空箱过来 获取TaskCode失败 【{TaskCode}】 请检查AGV任务清单", uiContext);

                        var Result_13738 = client.Write("13738", true, stationNumber);

                        Thread.Sleep(5000);

                        continue;
                    }
                    else
                    {
                        AppendText($"2通道呼叫AGV小车送空箱过来 获取TaskCode【{TaskCode}】", uiContext);

                        var Result_13738 = client.Write("13738", false, stationNumber);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //3
                    //2通道AGV小车到位货架信号
                    Thread.Sleep(50);

                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        bool arriveOutputSide = this.CallWebApi_ArriveOutputSide(TaskCode) == "1";
                        if (arriveOutputSide)
                        {
                            AppendText("2通道AGV小车已到位货架", uiContext);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    //4
                    //要求AGV转动-货架处取箱子
                    Thread.Sleep(50);

                    if (true && CallAgvBoxAtInput2_Order)
                    {
                        AppendText("要求2通道AGV货架处取箱子", uiContext);
                        var resultStr_CallWebApi_CallAgvStartOutputRoll = this.CallWebApi_CallAgvStartOutputRoll(TaskCode);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    ///5
                    ///AGV到达2通道位置
                    Thread.Sleep(50);

                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        bool arriveInputSide = this.CallWebApi_ArriveInputSide(TaskCode) == "1";
                        if (arriveInputSide)
                        {
                            AppendText("检测到 2通道AGV小车已到位", uiContext);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    //6
                    //2通道AGV小车到位信号【14488】
                    Thread.Sleep(50);

                    Result Result_14488;
                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        Result_14488 = client.Write("14488", true, stationNumber);
                        if (Result_14488.IsSucceed)
                        {
                            AppendText("2通道AGV小车到位信号【14488】", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //7
                    //2通道起转等待起转命令工作信号【13489】
                    Thread.Sleep(50);
                    AppendText("开始 2通道起转等待起转命令工作信号【13489】", uiContext);
                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        var Result_13489 = client.ReadCoil("13489", stationNumber);
                        if (Result_13489.IsSucceed && Result_13489.Value)
                        {
                            AppendText($"[读取 13489 成功]", uiContext);
                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14488 = client.Write("14488", false, stationNumber);
                            Thread.Sleep(50);

                            break;
                        }
                        else
                        {
                            AppendText($"[读取 13489 失败]", uiContext);
                            Result_14488 = client.Write("14488", true, stationNumber);
                            continue;
                        }
                    }
                    AppendText("结束 2通道起转等待起转命令工作信号【13489】", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    ///8
                    //要求2通道起转信号【14489】
                    Thread.Sleep(50);

                    AppendText("开始 要求2通道起转信号【14489】", uiContext);
                    Result Result_14489;
                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        Thread.Sleep(50);

                        Result_14489 = client.Write("14489", true, stationNumber);
                        if (Result_14489.IsSucceed)
                        {
                            AppendText($"[写入 14489 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            AppendText($"[写入 14489 失败]", uiContext);
                            continue;
                        }
                    }
                    AppendText("结束 要求2通道起转信号【14489】", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //9
                    //通知要求AGV转动放箱
                    Thread.Sleep(50);

                    if (true && CallAgvBoxAtInput2_Order)
                    {
                        AppendText("要求2通道AGV起转", uiContext);
                        var resultStr_CallWebApi_CallAgvStartInputRoll = this.CallWebApi_CallAgvStartInputRoll(TaskCode);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //10
                    //AGV上报已调整完，已开始工作
                    Thread.Sleep(50);

                    Thread.Sleep(9000);
                    //while (true && CallAgvBoxAtInput2_Order && CallAgvBoxAtInput2_Self)
                    //{
                    //    bool arriveInputSide = this.CallWebApi_AdjustInputSide(TaskCode) == "1";
                    //    if (arriveInputSide)
                    //    {
                    //        AppendText("检测到 2通道AGV小车已准备OK的上报消息", uiContext);

                    //        break;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}

                    Thread.Sleep(50);

                    ///11
                    //1通道入料OK【13490】
                    //1通道入料超时报警【13491】
                    Thread.Sleep(50);

                    AppendText("开始 2通道入料OK【13490】", uiContext);
                    while (true && CallAgvBoxAtInput2_Order)
                    {
                        var Result_13490 = client.ReadCoil("13490", stationNumber);
                        var Result_13491 = client.ReadCoil("13491", stationNumber);
                        if (Result_13490.IsSucceed && Result_13490.Value)
                        {
                            //Success
                            response = response.OK("2通道入料OK!");

                            AppendText("2通道入料OK!", uiContext);

                            AppendText($"[读取 13490 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14489 = client.Write("14489", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteInputWork(TaskCode);

                            //CallAgvBoxAtInput2_Self = false;

                            break;
                        }
                        else if (Result_13491.IsSucceed && Result_13491.Value)
                        {
                            //Raise Error
                            response = response.Error("2通道入料超时报警!");

                            AppendText("2通道入料超时报警!", uiContext);

                            AppendText($"[读取 13491 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14489 = client.Write("14489", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO
                            //AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteInputWork(TaskCode);

                            //CallAgvBoxAtInput2_Self = false;

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);


                    AppendText("结束 2通道入料OK【13490】", uiContext);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        if (!CallAgvBoxAtInput2_Order)
                        {
                            response = response.Error("取消2通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    Thread.Sleep(10000);
                }
                else
                {
                    Thread.Sleep(1000);
                }
                if (!CallAgvBoxAtInput2_Order)
                {
                    if (!CallAgvBoxAtInput2_Order)
                    {
                        response = response.Error("取消2通道AGV任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }

            }

            AppendText("结束 2通道AGV任务", uiContext);
            return response;
        }

        public bool AskBoxRollFromInput2_Order { get; set; } = false;
        public ResponseContent AskBoxRollFromInput2(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool AskBoxRollFromInput2_Self = true;

            while (true && AskBoxRollFromInput2_Order && AskBoxRollFromInput2_Self)
            {
                Thread.Sleep(50);

                ///1
                //2通道箱子码垛入料准备OK信号【13504】
                var Result_13504 = client.ReadCoil("13504", stationNumber);
                if (Result_13504.IsSucceed
                    && Result_13504.Value
                    )
                {
                    Thread.Sleep(50);

                    //取消任务
                    if (!AskBoxRollFromInput2_Order)
                    {
                        if (!AskBoxRollFromInput2_Order)
                        {
                            response = response.Error("取消码垛呼叫2通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {
                        
                    }

                    Thread.Sleep(50);

                    ///2
                    //2通道箱子码垛入料调入信号【14504】
                    Thread.Sleep(50);

                    Result Result_14504;
                    while (AskBoxRollFromInput2_Order)
                    {
                        Result_14504 = client.Write("14504", true, stationNumber);
                        if (Result_14504.IsSucceed)
                        {
                            AppendText($"[写入 14504 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            AppendText($"[写入 14504 失败]", uiContext);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    //取消任务
                    if (!AskBoxRollFromInput2_Order)
                    {
                        if (!AskBoxRollFromInput2_Order)
                        {
                            response = response.Error("取消码垛呼叫2通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    ///3
                    //2通道箱子码垛入料OK信号【13505】
                    //或者
                    //作业台-扫码触发信号【13688】
                    Thread.Sleep(50);

                    while (AskBoxRollFromInput2_Order)
                    {
                        Thread.Sleep(50);

                        var Result_13505 = client.ReadCoil("13505", stationNumber);
                        var Result_13688 = client.ReadCoil("13688", stationNumber);
                        if (
                            (Result_13505.IsSucceed && Result_13505.Value)
                                                        ||
                            (Result_13688.IsSucceed && Result_13688.Value)
                           )
                        {
                            //Success
                            response = response.OK("2通道箱子码垛入料OK!");

                            if ((Result_13505.IsSucceed && Result_13505.Value))
                            {
                                AppendText($"[读取 13505  成功]：{Result_13505.Value}", uiContext);
                            }
                            else if ((Result_13688.IsSucceed && Result_13688.Value))
                            {
                                AppendText($"[读取 13688 成功]：{Result_13688.Value}", uiContext);
                            }

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14504 = client.Write("14504", false, stationNumber);
                            Thread.Sleep(50);

                            //擦除先前工作台设置的信号
                            Thread.Sleep(50);
                            //擦除箱子类型
                            var Result_14688 = client.Write("14688", false, stationNumber);
                            var Result_14689 = client.Write("14689", false, stationNumber);
                            var Result_14690 = client.Write("14690", false, stationNumber);
                            var Result_14691 = client.Write("14691", false, stationNumber);
                            var Result_14692 = client.Write("14692", false, stationNumber);
                            ////针对动作请求操作
                            //var Result_14748 = client.Write("14748", false, stationNumber);
                            //var Result_14749 = client.Write("14749", false, stationNumber);
                            Thread.Sleep(50);

                            this.TakeScanAtOperateApp_Order = true;
                            this.TakeScanAtOperateApp(null);
                            this.TakeScanAtOperateApp_Order = false;

                            Thread.Sleep(50);

                            AskBoxRollFromInput2_Self = false;
                            AskBoxRollFromInput2_Order = false;

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    AppendText("结束 2通道箱子码垛入料OK信号【13405】", uiContext);

                    Thread.Sleep(50);

                }
                else
                {
                    Thread.Sleep(10000);
                }

                if (!AskBoxRollFromInput2_Order || !AskBoxRollFromInput2_Self)
                {
                    if (!AskBoxRollFromInput2_Order)
                    {
                        response = response.Error("取消码垛呼叫2通道箱子任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }
            }

            Thread.Sleep(50);

            AppendText("结束码垛呼叫2通道箱子任务", uiContext);

            return response;
        }

        #endregion Input2

        #region OperateApplication

        #region main process

        public bool TakeOperateApp_Order { get; set; } = false;
        public ResponseContent TakeOperateApp(object para)
        {
            ResponseContent response = new ResponseContent();

            string thisTempReelId = string.Empty;

            SynchronizationContext uiContext = this.uiContextMain;

            Thread.Sleep(50);
            AppendText($"开始 TakePhotoAtOperateApp", uiContext);
            while (true && this.TakeOperateApp_Order)
            {
                Thread.Sleep(50);
                this.TakePhotoAtOperateApp_Order = true;
                response = this.TakePhotoAtOperateApp(null);
                this.TakePhotoAtOperateApp_Order = false;
                Thread.Sleep(50);
                if (response.Status)
                {
                    AppendText($"TakePhotoAtOperateApp 返回成功", uiContext);
                    //TakeOperateApp_Self = true;
                }
                else
                {
                    AppendText($"TakePhotoAtOperateApp 返回失败", uiContext);
                    //TakeOperateApp_Self = false;
                }

                Thread.Sleep(50);

                if (response.Status)
                {
                    AppendText($"开始 TakeOperateWortAtOperateApp", uiContext);
                    Thread.Sleep(50);
                    this.TakeOperateWortAtOperateApp_Order = true;
                    response = this.TakeOperateWortAtOperateApp(null);
                    this.TakeOperateWortAtOperateApp_Order = false;
                    Thread.Sleep(50);
                    AppendText($"结束 TakeOperateWortAtOperateApp", uiContext);
                    if (response.Status)
                    {
                        //TakeOperateApp_Self = false;
                        AppendText($"TakeOperateWortAtOperateApp 返回成功", uiContext);
                    }
                    else
                    {
                        //TakeOperateApp_Self = false;
                        AppendText($"TakeOperateWortAtOperateApp 返回失败", uiContext);
                    }
                }
                else
                {
                    //TakeOperateApp_Self = false;
                }


            }
            AppendText($"结束 TakePhotoAtOperateApp", uiContext);
            Thread.Sleep(50);

            return response;
        }

        #endregion


        public bool TakeScanAtOperateApp_Order { get; set; } = false;
        /// <summary>
        /// 工作台扫箱码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent TakeScanAtOperateApp(object para)
        {
            ResponseContent response = new ResponseContent();

            string thisTempBoxNo = string.Empty;

            SynchronizationContext uiContext = this.uiContextMain;

            bool TakeScanAtOperateApp_Self = true;

            Thread.Sleep(50);

            AppendText("开始 工作台扫箱码TakeScanAtOperateApp", uiContext);
            while (true && TakeScanAtOperateApp_Order && TakeScanAtOperateApp_Self)
            {
                Thread.Sleep(50);

                AppendText("尝试 扫码触发信号【13688】", uiContext);
                ///1
                //扫码触发信号【13688】或者码垛位箱子信号【13291】
                var Result_13688 = client.ReadCoil("13688", stationNumber);
                var Result_13291 = client.ReadCoil("13291", stationNumber);
                if ((Result_13688.IsSucceed
                    && Result_13688.Value
                    ) ||
                    (Result_13291.IsSucceed
                    && Result_13291.Value
                    )
                    //||
                    //(!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"[读取 13688 成功]：{Result_13688.Value}", uiContext);

                    //擦除先前工作台设置的信号
                    Thread.Sleep(50);
                    //箱子类型
                    AppendText("擦除先前工作台设置的箱子类型信号【14688,14689,14690,14691,14692】", uiContext);
                    var Result_14688 = client.Write("14688", false, stationNumber);
                    var Result_14689 = client.Write("14689", false, stationNumber);
                    var Result_14690 = client.Write("14690", false, stationNumber);
                    var Result_14691 = client.Write("14691", false, stationNumber);
                    var Result_14692 = client.Write("14692", false, stationNumber);
                    ////针对动作请求操作
                    //var Result_14748 = client.Write("14748", false, stationNumber);
                    //var Result_14749 = client.Write("14749", false, stationNumber);
                    Thread.Sleep(50);

                    int boxType = 2;
                    while (true)
                    {
                        //扫码 获取箱单编号
                        AppendText("扫码 获取箱单编号", uiContext);
                        var Response_GetScan1String = this.GetScan1String(null);
                        if (Response_GetScan1String.Status)
                        {
                            thisTempBoxNo = this.Buffer_BoxNo_AtOperate;
                        }
                        else
                        {
                            int retrytime = 0;
                            while (retrytime < 3 && !Response_GetScan1String.Status)
                            {
                                Response_GetScan1String = this.GetScan1String(null);
                                retrytime = retrytime + 1;
                                Thread.Sleep(50);
                            }
                            if (Response_GetScan1String.Status)
                            {
                                thisTempBoxNo = this.Buffer_BoxNo_AtOperate;
                            }
                        }
                        AppendText($"[扫码 成功]：{thisTempBoxNo}\t\t", uiContext);
                        Thread.Sleep(50);

                        Thread.Sleep(50);
                        AppendText("访问数据库，获取箱类型", uiContext);
                        
                        Box findBoxEntity = this.GetBoxEntityByBoxNo(thisTempBoxNo);
                        if (findBoxEntity != null)
                        {
                            if (findBoxEntity.CellType.HasValue)
                            {
                                if (findBoxEntity.CellType.Value == 4)
                                {
                                    boxType = 0;
                                }
                                else
                                {
                                    boxType = 2;
                                }
                            }
                            else
                            {
                                boxType = 3;
                            }
                            break;
                        }
                        else
                        {
                            boxType = 3;
                            break;
                        }
                    }
                    
                    ///2
                    //扫码完成【14688】【14689】【14690】【14691】
                    AppendText($"获取箱类型boxType【{boxType}】", uiContext);
                    Thread.Sleep(50);

                    //Result Result_14688;
                    //Result Result_14689;
                    //Result Result_14690;
                    //Result Result_14691;
                    //Result Result_14692;
                    Thread.Sleep(50);
                    AppendText($"开始 对应点位写入箱类型boxType", uiContext);
                    while (true && TakeScanAtOperateApp_Order && TakeScanAtOperateApp_Self)
                    {
                        if (boxType == 0)
                        {
                            Result_14688 = client.Write("14688", true, stationNumber);
                            Result_14692 = client.Write("14692", true, stationNumber);
                            AppendText($"写入空箱【14692】", uiContext);
                            if (Result_14688.IsSucceed)
                            {
                                AppendText($"写入【14688】成功", uiContext);

                                response = response.OK("Success", thisTempBoxNo);

                                TakeScanAtOperateApp_Self = false; ;

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (boxType == 1) //没有这个逻辑了,前面不会返回boxType = 1的这种箱子出来
                        {
                            Result_14689 = client.Write("14689", true, stationNumber);
                            Result_14692 = client.Write("14692", true, stationNumber);
                            AppendText($"写入空箱【14692】", uiContext);
                            if (Result_14689.IsSucceed)
                            {
                                AppendText($"写入【14689】成功", uiContext);

                                response = response.OK("Success", thisTempBoxNo);

                                TakeScanAtOperateApp_Self = false; ;

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (boxType == 2)
                        {
                            Result_14690 = client.Write("14690", true, stationNumber);
                            Result_14692 = client.Write("14692", true, stationNumber);
                            AppendText($"写入空箱【14692】", uiContext);
                            if (Result_14690.IsSucceed)
                            {
                                AppendText($"[写入【14690】成功", uiContext);

                                response = response.OK("Success", thisTempBoxNo);

                                TakeScanAtOperateApp_Self = false; ;

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (boxType == 3)
                        {
                            Result_14691 = client.Write("14691", true, stationNumber);
                            Result_14692 = client.Write("14692", true, stationNumber);
                            AppendText($"写入空箱【14692】", uiContext);
                            if (Result_14691.IsSucceed)
                            {
                                AppendText($"[写入【14691】成功", uiContext);

                                response = response.OK("Success", thisTempBoxNo);

                                TakeScanAtOperateApp_Self = false; ;

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }


                    }

                    AppendText($"结束 对应点位写入箱类型boxType", uiContext);
                    Thread.Sleep(50);


                    if (!TakeScanAtOperateApp_Order || !TakeScanAtOperateApp_Self)
                    {
                        if (!TakeScanAtOperateApp_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            AppendText("结束 工作台扫箱码TakeScanAtOperateApp", uiContext);

            Thread.Sleep(50);

            return response;
        }

        public bool TakePhotoAtOperateApp_Order { get; set; } = false;

        /// <summary>
        /// 工作台拍料盘照
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent TakePhotoAtOperateApp(object para)
        {
            ResponseContent response = new ResponseContent();

            string thisTempReelId = string.Empty;

            SynchronizationContext uiContext = this.uiContextMain;

            bool TakePhotoAtOperateApp_Self = true;

            AppendText($"开始 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
            while (true && TakePhotoAtOperateApp_Order && TakePhotoAtOperateApp_Self)
            {
                AppendText($"触发开启 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
                Thread.Sleep(50);

                AppendText($"检查拍照触发【13738】", uiContext);

                ///1
                //拍照触发【13738】
                var Result_13738 = client.ReadCoil("13738", stationNumber);
                if (Result_13738.IsSucceed
                    && (Result_13738.Value || !Result_13738.Value)
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"拍照触发【13738】", uiContext);
                    AppendText($"读取 13738 成功：{Result_13738.Value}", uiContext);

                    Thread.Sleep(50);

                    ///2
                    //拍照完成【14738】
                    Thread.Sleep(50);
                    AppendText($"开始 TakePhotoScanAtOperateApp", uiContext);
                    response = this.TakePhotoScanAtOperateApp(null);
                    AppendText($"结束 TakePhotoScanAtOperateApp", uiContext);
                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    TakePhotoAtOperateApp_Self = false;

                    if (!TakePhotoAtOperateApp_Order || !TakePhotoAtOperateApp_Self)
                    {
                        AppendText($"触发跳出 TakePhotoAtOperateApp循环", uiContext);
                        if (!TakePhotoAtOperateApp_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            AppendText($"结束 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
            return response;
        }

        /// <summary>
        /// 工作台拍料盘照
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        //public ResponseContent TakePhotoAtOperateApp(object para)
        //{
        //    ResponseContent response = new ResponseContent();

        //    string thisTempReelId = string.Empty;

        //    SynchronizationContext uiContext = this.uiContextMain;

        //    bool TakePhotoAtOperateApp_Self = true;

        //    response = response.OK("Sucess");

        //    while (true && TakePhotoAtOperateApp_Order && TakePhotoAtOperateApp_Self)
        //    {
        //        Thread.Sleep(50);

        //        var Result_13290 = client.ReadCoil("13290", stationNumber);
        //        var Result_13292 = client.ReadCoil("13292", stationNumber);

        //        if (
        //            (Result_13290.IsSucceed && Result_13290.Value)
        //            &&
        //            (Result_13292.IsSucceed && Result_13292.Value)
        //            )
        //        {
        //            break;
        //        }
        //        else
        //        { 

        //        }

        //        if (!TakePhotoAtOperateApp_Order || !TakePhotoAtOperateApp_Self)
        //        {
        //            AppendText($"触发跳出 等待料盘循环", uiContext);
        //            if (!TakePhotoAtOperateApp_Order)
        //            {
        //                response = response.Error("取消任务!");
        //            }

        //            break;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }

        //    //AppendText($"开始 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
        //    //while (true && TakePhotoAtOperateApp_Order && TakePhotoAtOperateApp_Self)
        //    //{
        //    //    AppendText($"触发开启 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
        //    //    Thread.Sleep(50);

        //    //    AppendText($"检查拍照触发【13738】", uiContext);

        //    //    var Result_13290 = client.ReadCoil("13290", stationNumber);
        //    //    var Result_13292 = client.ReadCoil("13292", stationNumber);
        //    //    ///1
        //    //    //拍照触发【13738】



        //    //    var Result_13738 = client.ReadCoil("13738", stationNumber);
        //    //    if (Result_13738.IsSucceed
        //    //        && (Result_13738.Value || !Result_13738.Value)
        //    //        )
        //    //    {
        //    //        Thread.Sleep(50);

        //    //        AppendText($"拍照触发【13738】", uiContext);
        //    //        AppendText($"[读取 13738 成功]：{Result_13738.Value}\t\t耗时：{Result_13738.TimeConsuming}ms", uiContext);

        //    //        Thread.Sleep(50);

        //    //        ///2
        //    //        //拍照完成【14738】
        //    //        Thread.Sleep(50);
        //    //        AppendText($"开始 TakePhotoScanAtOperateApp", uiContext);
        //    //        response = this.TakePhotoScanAtOperateApp(null);
        //    //        AppendText($"结束 TakePhotoScanAtOperateApp", uiContext);
        //    //        Thread.Sleep(50);

        //    //        Thread.Sleep(50);
        //    //        TakePhotoAtOperateApp_Self = false;

        //    //        if (!TakePhotoAtOperateApp_Order || !TakePhotoAtOperateApp_Self)
        //    //        {
        //    //            AppendText($"触发跳出 TakePhotoAtOperateApp循环", uiContext);
        //    //            if (!TakePhotoAtOperateApp_Order)
        //    //            {
        //    //                response = response.Error("取消任务!");
        //    //            }

        //    //            break;
        //    //        }
        //    //        else
        //    //        {
        //    //            continue;
        //    //        }
        //    //    }
        //    //}

        //    //AppendText($"结束 工作台拍料盘照TakePhotoAtOperateApp", uiContext);
        //    return response;
        //}

        public bool TakePhotoScanAtOperateApp_Order { get; set; } = false;
        /// <summary>
        /// 工作台拍料盘照
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent TakePhotoScanAtOperateApp(object para)
        {
            ResponseContent response = new ResponseContent();
            SynchronizationContext uiContext = this.uiContextMain;

            AppendText($"开始调用 TakePhotoFromEquiment0", uiContext);
            bool takePhotoResult = TakePhotoFromEquiment0();
            AppendText($"结束调用 TakePhotoFromEquiment0", uiContext);

            int maxRetryNum = 3;
            int thisTry = 1;
            while(!takePhotoResult && thisTry <= maxRetryNum)
            {
                Thread.Sleep(100);
                AppendText($"开始调用 TakePhotoFromEquiment0", uiContext);
                takePhotoResult = TakePhotoFromEquiment0();
                AppendText($"结束调用 TakePhotoFromEquiment0", uiContext);

                thisTry++;
            }

            if (takePhotoResult)
            {
                AppendText($"调用成功 TakePhotoFromEquiment0", uiContext);

                while (!this.IsReceive)
                {
                    Thread.Sleep(100);
                }                

                if (!string.IsNullOrEmpty(this.Buffer_ReelId_AtOperate))
                {
                    response = response.OK("Sucess", this.Buffer_ReelId_AtOperate);
                }
                else
                {
                    //response = response.Error("条码读取失败!");
                    this.Buffer_ReelId_AtOperate = "";
                    response = response.OK("Sucess", this.Buffer_ReelId_AtOperate);
                }
            }
            else
            {
                //response = response.Error("条码拍照失败!");
                AppendText($"调用失败 TakePhotoFromEquiment0", uiContext);
                this.Buffer_ReelId_AtOperate = "";
                response = response.OK("Sucess", this.Buffer_ReelId_AtOperate);
            }

            uiContext.Post(_ => this.curBufReelId.Text = this.Buffer_ReelId_AtOperate, null);

            uiContext.Post(_ => this.curBufReelIdBindOutorderNo.Text = "", null);
            if (!string.IsNullOrEmpty(this.Buffer_ReelId_AtOperate))
            {
                string ourOrderNoByReelId = this.GetOutOrderNoByReelId(this.Buffer_ReelId_AtOperate);
                if (!string.IsNullOrEmpty(ourOrderNoByReelId))
                {
                    uiContext.Post(_ => this.curBufReelIdBindOutorderNo.Text = ourOrderNoByReelId, null);
                }
            }

            return response;
        }

        /// <summary>
        /// 硬件工作-识别条码
        /// </summary>
        /// <returns></returns>
        public bool TakePhotoFromEquiment0()
        {
            this.IsReceive = false;

            SynchronizationContext uiContext = this.uiContextMain;

            AppendText($"开始 TakePhotoFromEquiment0", uiContext);
            string triggerCommand = "RUN";
            if (string.IsNullOrEmpty(triggerCommand))
            {
                triggerCommand = "RUN";
            }
            triggerCommand += Environment.NewLine;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(triggerCommand);
            var result = hpPhotoClient.Send(bytes, bytes.Length);

            AppendText($"结束 TakePhotoFromEquiment0", uiContext);

            return result;
        }

        public ResponseContent GetPhotoString(object para)
        {
            ResponseContent response = new ResponseContent();
            SynchronizationContext uiContext = this.uiContextMain;

            AppendText($"开始调用 相机 TakePhotoFromEquiment0", uiContext);
            bool takePhotoResult = TakePhotoFromEquiment0();
            AppendText($"结束调用 相机 TakePhotoFromEquiment0", uiContext);

            int maxRetryNum = 3;
            int thisTry = 1;
            while (!takePhotoResult && thisTry <= maxRetryNum)
            {
                Thread.Sleep(100);
                AppendText($"开始调用 相机 TakePhotoFromEquiment0", uiContext);
                takePhotoResult = TakePhotoFromEquiment0();
                AppendText($"结束调用 相机 TakePhotoFromEquiment0", uiContext);

                thisTry++;
            }

            if (takePhotoResult)
            {
                AppendText($"调用成功 相机 TakePhotoFromEquiment0", uiContext);

                while (!this.IsReceive)
                {
                    Thread.Sleep(100);
                }

                if (!string.IsNullOrEmpty(this.Buffer_ReelId_AtOperate))
                {
                    response = response.OK("Sucess", this.Buffer_ReelId_AtOperate);
                }
                else
                {
                    //response = response.Error("条码读取失败!");
                    this.Buffer_ReelId_AtOperate = "";
                    response = response.OK("Sucess", this.Buffer_ReelId_AtOperate);
                }
            }
            else
            {
                //response = response.Error("条码拍照失败!");
                this.Buffer_ReelId_AtOperate = "";
                response = response.OK("Success", this.Buffer_ReelId_AtOperate);
            }

            uiContext.Post(_ => this.curBufReelId.Text = this.Buffer_ReelId_AtOperate, null);

            if (!string.IsNullOrEmpty(this.Buffer_ReelId_AtOperate))
            {
                string ourOrderNoByReelId = this.GetOutOrderNoByReelId(this.Buffer_ReelId_AtOperate);
                if (!string.IsNullOrEmpty(ourOrderNoByReelId))
                {
                    uiContext.Post(_ => this.curBufReelIdBindOutorderNo.Text = ourOrderNoByReelId, null);
                }
            }

            return response;
        }

        /// <summary>
        /// 识别扫描仪1
        /// </summary>
        /// <returns></returns>
        public bool TakeScanFromEquiment1()
        {
            this.IsReceive1 = false;

            string triggerCommand = "start";
            if (string.IsNullOrEmpty(triggerCommand))
            {
                triggerCommand = "start";
            }
            //triggerCommand += Environment.NewLine;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(triggerCommand);
            var result = hpScanClient1.Send(bytes, bytes.Length);

            Thread.Sleep(50);

            return result;
        }

        public ResponseContent GetScan1String(object para)
        {
            ResponseContent response = new ResponseContent();
            SynchronizationContext uiContext = this.uiContextMain;

            bool takePhotoResult = TakeScanFromEquiment1();

            int maxRetryNum = 3;
            int thisTry = 1;
            while (!takePhotoResult && thisTry <= maxRetryNum)
            {
                Thread.Sleep(100);
                AppendText($"开始调用 TakeScanFromEquiment1", uiContext);
                takePhotoResult = TakeScanFromEquiment1();
                AppendText($"结束调用 TakeScanFromEquiment1", uiContext);

                thisTry++;
            }

            if (takePhotoResult)
            {
                AppendText($"调用成功 TakeScanFromEquiment1", uiContext);

                while (!this.IsReceive1)
                {
                    Thread.Sleep(100);
                }

                if (!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate) && this.Buffer_BoxNo_AtOperate != "NoRead")
                {
                    response = response.OK("Sucess", this.Buffer_BoxNo_AtOperate);
                }
                else
                {
                    //response = response.Error("二维码读取失败!");
                    this.Buffer_BoxNo_AtOperate = "";
                    response = response.Error("False");
                }
            }
            else
            {
                //response = response.Error("二维码读取失败!");
                this.Buffer_BoxNo_AtOperate = "";
                response = response.Error("False");
            }

            uiContext.Post(_ => this.curBufBoxNo.Text = this.Buffer_BoxNo_AtOperate, null);

            uiContext.Post(_ => this.curBufIsEmpty.Text = "", null);
            uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = "", null);

            if (!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
            {
                if (this.CheckBoxNo(this.Buffer_BoxNo_AtOperate))
                {
                    Box boxEntity = this.GetBoxEntityByBoxNo(this.Buffer_BoxNo_AtOperate);
                    if (boxEntity != null)
                    {

                        if (boxEntity.isEmpty??false)
                        {
                            uiContext.Post(_ => this.curBufIsEmpty.Text = "否", null);
                        }
                        else
                        {
                            uiContext.Post(_ => this.curBufIsEmpty.Text = "是", null);
                        }

                        if (!string.IsNullOrEmpty(boxEntity.InOutOrder))
                        {
                            uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = boxEntity.InOutOrder, null);
                        }
                    }
                }
            }
            

            return response;
        }


        /// <summary>
        /// 识别扫描仪2
        /// </summary>
        /// <returns></returns>
        public bool TakeScanFromEquiment2()
        {
            this.IsReceive2 = false;

            string triggerCommand = "start";
            if (string.IsNullOrEmpty(triggerCommand))
            {
                triggerCommand = "start";
            }
            //triggerCommand += Environment.NewLine;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(triggerCommand);
            var result = hpScanClient2.Send(bytes, bytes.Length);

            Thread.Sleep(50);

            return result;
        }

        public ResponseContent GetScan2String(object para)
        {
            ResponseContent response = new ResponseContent();
            SynchronizationContext uiContext = this.uiContextMain;

            bool takePhotoResult = TakeScanFromEquiment2();

            int maxRetryNum = 3;
            int thisTry = 1;
            while (!takePhotoResult && thisTry <= maxRetryNum)
            {
                Thread.Sleep(100);
                AppendText($"开始调用 TakeScanFromEquiment2", uiContext);
                takePhotoResult = TakeScanFromEquiment2();
                AppendText($"结束调用 TakeScanFromEquiment2", uiContext);

                thisTry++;
            }

            if (takePhotoResult)
            {
                AppendText($"调用成功 TakeScanFromEquiment2", uiContext);

                while (!this.IsReceive2)
                {
                    Thread.Sleep(100);
                }

                if (!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOutput3) && this.Buffer_BoxNo_AtOutput3 != "NoRead")
                {
                    response = response.OK("Sucess", this.Buffer_BoxNo_AtOutput3);
                }
                else
                {
                    //response = response.Error("二维码读取失败!");
                    this.Buffer_BoxNo_AtOperate = "";
                    response = response.Error("False");
                }
            }
            else
            {
                //response = response.Error("二维码读取失败!");
                this.Buffer_BoxNo_AtOperate = "";
                response = response.Error("False");
            }

            //uiContext.Post(_ => this.curBufBoxNo.Text = this.Buffer_BoxNo_AtOperate, null);

            //uiContext.Post(_ => this.curBufIsEmpty.Text = "", null);
            //uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = "", null);

            //if (!string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
            //{
            //    if (this.CheckBoxNo(this.Buffer_BoxNo_AtOperate))
            //    {
            //        Box boxEntity = this.GetBoxEntityByBoxNo(this.Buffer_BoxNo_AtOperate);
            //        if (boxEntity != null)
            //        {

            //            if (boxEntity.isEmpty ?? false)
            //            {
            //                uiContext.Post(_ => this.curBufIsEmpty.Text = "否", null);
            //            }
            //            else
            //            {
            //                uiContext.Post(_ => this.curBufIsEmpty.Text = "是", null);
            //            }

            //            if (!string.IsNullOrEmpty(boxEntity.InOutOrder))
            //            {
            //                uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = boxEntity.InOutOrder, null);
            //            }
            //        }
            //    }
            //}


            return response;
        }

        public bool TakeOperateWortAtOperateApp_Order { get; set; } = false;
        /// <summary>
        /// 工作台动作请求
        /// 处理请求，决定是Pick还是Out
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent TakeOperateWortAtOperateApp(Object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool TakeOperateWortAtOperateApp_Self = true;

            //bool alreadyPut13748 = false;

            AppendText($"开始内部循环 TakeOperateWortAtOperateApp", uiContext);
            while (true && TakeOperateWortAtOperateApp_Order && TakeOperateWortAtOperateApp_Self)
            {
                //AppendText($"触发循环启动 TakeOperateWortAtOperateApp", uiContext);
                Thread.Sleep(50);
                string thisTempBoxNo = string.Empty;
                string thisTempReelId = string.Empty;

                //检查信息，是否等待2秒后重新循环
                var Request_13290 = client.ReadCoil("13290", stationNumber);
                var Request_13292 = client.ReadCoil("13292", stationNumber);
                var Request_13291 = client.ReadCoil("13291", stationNumber);
                var Request_13688 = client.ReadCoil("13688", stationNumber);
                if (
                    !(
                    //(Request_13290.IsSucceed && Request_13290.Value)
                    //||
                    (Request_13292.IsSucceed && Request_13292.Value)
                    || 
                    (Request_13291.IsSucceed && Request_13291.Value)
                    ||
                    (Request_13688.IsSucceed && Request_13688.Value)
                    )
                    )
                {
                    Thread.Sleep(2000);
                    AppendText($"等待2秒后重新循环", uiContext);
                    continue;
                }
                //AppendText($"开始 TakeOperateWortAtOperateApp", uiContext);
                //取出料盘唯一码
                //while (true && TakeOperateWortAtOperateApp_Order && TakeOperateWortAtOperateApp_Self)
                //{
                //    AppendText($"触发循环启动 取出料盘唯一码", uiContext);

                //    AppendText($"开始调用 GetPhotoString", uiContext);
                //    var Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                //    AppendText($"结束调用 GetPhotoString", uiContext);

                //    if (Response_TakePhotoAtOperateApp.Status)
                //    {
                //        Thread.Sleep(100);
                //        thisTempReelId = this.Buffer_ReelId_AtOperate;
                //        AppendText($"当前料盘唯一码:【{thisTempReelId}】", uiContext);
                //        AppendText($"当前料盘唯一码:【{thisTempReelId}】", uiContext);

                //        AppendText($"退出循环 取出料盘唯一码", uiContext);
                //        break;
                //    }
                //    else
                //    {
                //        Thread.Sleep(100);
                //        Thread.Sleep(5000);
                //        AppendText($"继续循环 取出料盘唯一码", uiContext);
                //        continue;
                //    }
                //}
                //AppendText($"结束 TakeOperateWortAtOperateApp", uiContext);
                bool alreadyAskBox = false;


                AppendText($"检查 动作请求【13748】", uiContext);
                ///1
                //动作请求【13747】【13748】
                var Result_13747 = client.ReadCoil("13747", stationNumber);
                var Result_13748 = client.ReadCoil("13748", stationNumber);
                if (
                    (Result_13748.IsSucceed
                    && Result_13748.Value
                    )
                    //||
                    //alreadyPut13748
                    )
                {
                    Thread.Sleep(50);

                    //alreadyPut13748 = false;

                    AppendText($"[读取 13748 成功]", uiContext);

                    Thread.Sleep(50);


                    AppendText($"检查 码垛位是否有箱子【13291】", uiContext);
                    AppendText($"检查 入料皮带处是否有料【13292】", uiContext);
                    ///2
                    //码垛位是否有箱子【13291】
                    //入料皮带处是否有料【13292】
                    Thread.Sleep(50);

                    var Result_13291 = client.ReadCoil("13291", stationNumber);
                    var Result_13292 = client.ReadCoil("13292", stationNumber);

                    //同时有箱子也有料盘
                    if (
                        (Result_13291.IsSucceed && Result_13291.Value)
                        &&
                        (Result_13292.IsSucceed && Result_13292.Value)
                        )
                    {
                        AppendText($"检查结果 同时有箱子也有料盘", uiContext);
                        AppendText($"开始调用 GetPhotoString", uiContext);
                        var Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                        AppendText($"结束调用 GetPhotoString", uiContext);
                        if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                        {
                            AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                            thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                        }
                        else
                        {
                            int retrytime = 0;
                            while (retrytime < 3 && string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                                retrytime = retrytime + 1;
                                Thread.Sleep(50);
                            }
                            if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                                thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                            }
                        }
                        AppendText($"开始调用 GetScan1String", uiContext);
                        var Response_GetScan1String = this.GetScan1String(null);
                        AppendText($"结束调用 GetScan1String", uiContext);
                        if (Response_GetScan1String.Status)
                        {
                            AppendText($"获取箱号 【{Response_GetScan1String.Data.ToString()}】", uiContext);
                            thisTempBoxNo = Response_GetScan1String.Data.ToString();
                        }
                        else
                        {
                            int retrytime = 0;
                            while (retrytime < 3 && !Response_GetScan1String.Status)
                            {
                                Response_GetScan1String = this.GetScan1String(null);
                                retrytime = retrytime + 1;
                                Thread.Sleep(50);
                            }
                            if (Response_GetScan1String.Status)
                            {
                                AppendText($"获取箱号 【{Response_GetScan1String.Data.ToString()}】", uiContext);
                                thisTempBoxNo = Response_GetScan1String.Data.ToString();
                            }
                        }

                        //只通过箱号唯一码来判断
                        AppendText($"开始调用 QueryOperateDictate 只通过箱号【{thisTempBoxNo}】唯一码来判断", uiContext);
                        var Response_QueryOperateDictate = this.QueryOperateDictate(thisTempBoxNo);
                        AppendText($"结束调用 QueryOperateDictate 只通过箱号唯一码来判断", uiContext);
                        if (Response_QueryOperateDictate.Status && (int)Response_QueryOperateDictate.Data == 1)
                        {
                            //移栽到3出口通道
                            AppendText($"调用结果判断 移栽到3出口通道", uiContext);
                            AskBoxRoolToOutpu3_Order = true;
                            //AppendText($"开始调用 AskBoxRoolToOutpu3", uiContext);
                            this.AskBoxRoolToOutpu3(null);
                            //AppendText($"结束调用 AskBoxRoolToOutpu3", uiContext);
                            AskBoxRoolToOutpu3_Order = false;
                        }
                        else
                        {
                            //留在操作台上,等待抓料装箱
                            //同时通过箱号和料盘唯一码来判断
                            AppendText($"调用结果判断 留在操作台上,等待抓料装箱", uiContext);
                            AppendText($"开始调用 QueryOperateDictate 同时通过箱号【{thisTempBoxNo}】和料盘唯一码【{thisTempReelId}】来判断", uiContext);
                            Response_QueryOperateDictate = this.QueryOperateDictate(thisTempBoxNo, thisTempReelId);
                            AppendText($"结束调用 QueryOperateDictate 同时通过箱号和料盘唯一码来判断", uiContext);
                            if (Response_QueryOperateDictate.Status)
                            {
                                //AppendText($"调用结果 调用成功", uiContext);
                                var Response_OperateDictate = (int)Response_QueryOperateDictate.Data;

                                if (Response_OperateDictate == 1)
                                {
                                    AppendText($"调用结果判断 移栽到3出口通道", uiContext);
                                    //移栽到3出口通道
                                    AskBoxRoolToOutpu3_Order = true;
                                    AppendText($"开始调用 AskBoxRoolToOutpu3 移栽到3出口通道", uiContext);
                                    this.AskBoxRoolToOutpu3(null);
                                    AppendText($"结束调用 AskBoxRoolToOutpu3 移栽到3出口通道", uiContext);
                                    AskBoxRoolToOutpu3_Order = false;
                                }
                                else if (Response_OperateDictate == 0) 
                                {
                                    AppendText($"调用结果判断 抓料到箱", uiContext);
                                    //抓料到箱
                                    AskPickerWork_Order = true;
                                    AppendText($"开始调用 AskPickerWork 抓料到箱", uiContext);
                                    this.AskPickerWork(null, thisTempBoxNo, thisTempReelId);
                                    AppendText($"结束调用 AskPickerWork 抓料到箱", uiContext);
                                    AskPickerWork_Order = false;
                                }
                                else if (Response_OperateDictate == -1)
                                {
                                    AppendText($"调用结果判断 抓料到NG料", uiContext);
                                    //抓料到NG料
                                    uiContext.Post(_ => txtCurrentNGInfo.Text = Response_QueryOperateDictate.Message, null);
                                    AskPickerWork_Order = true;
                                    AppendText($"开始调用 AskPickerWork 抓料到NG料", uiContext);
                                    this.AskPickerWork(null, thisTempBoxNo, thisTempReelId, "5");
                                    AppendText($"结束调用 AskPickerWork 抓料到NG料", uiContext);
                                    AskPickerWork_Order = false;
                                }
                                else
                                {
                                    //TODO 记录错误类型
                                    AppendText($"调用结果 调用失败", uiContext);
                                    TakeOperateWortAtOperateApp_Self = false;
                                }

                            }
                            else
                            {
                                //TODO 记录错误类型
                                AppendText($"调用结果 调用失败", uiContext);
                                TakeOperateWortAtOperateApp_Self = false;
                            }
                        }
                    }
                    //有箱子没有料盘 -> 走不到这里，不需要考虑是否会走到这部分逻辑
                    else if (
                            (Result_13291.IsSucceed && Result_13291.Value)
                            &&
                            (Result_13292.IsSucceed && !Result_13292.Value)
                            )
                    {
                        AppendText($"检查结果 有箱子没有料盘", uiContext);
                        if (string.IsNullOrEmpty(thisTempBoxNo) && string.IsNullOrEmpty(this.Buffer_BoxNo_AtOperate))
                        {
                            var Response_GetScan1String = this.GetScan1String(null);
                            if (Response_GetScan1String.Status)
                            {
                                thisTempBoxNo = Response_GetScan1String.Data.ToString();
                            }
                            else
                            {
                                int retrytime = 0;
                                while (retrytime < 3 && !Response_GetScan1String.Status)
                                {
                                    Response_GetScan1String = this.GetScan1String(null);
                                    retrytime = retrytime + 1;
                                    Thread.Sleep(50);
                                }
                                if (Response_GetScan1String.Status)
                                {
                                    thisTempBoxNo = Response_GetScan1String.Data.ToString();
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(thisTempBoxNo))
                        {
                            thisTempBoxNo = this.Buffer_BoxNo_AtOperate;
                        }

                        var Response_QueryOperateDictate = this.QueryOperateDictate(thisTempBoxNo);
                        if (Response_QueryOperateDictate.Status && (int)Response_QueryOperateDictate.Data == 1)
                        {
                            //移栽到3出口通道
                            AskBoxRoolToOutpu3_Order = true;
                            this.AskBoxRoolToOutpu3(null);
                            AskBoxRoolToOutpu3_Order = false;
                        }
                        else
                        {
                            //留在操作台上, 等候料盘
                            Thread.Sleep(2000);
                        }
                        //TakeOperateWortAtOperateApp_Self = false;
                    }
                    //没有箱子有料盘
                    else if (
                            (Result_13291.IsSucceed && !Result_13291.Value)
                            &&
                            (Result_13292.IsSucceed && Result_13292.Value)
                            )
                    {
                        AppendText("信号显示码垛位没有箱子但有料盘", uiContext);

                        AppendText($"开始调用 GetPhotoString", uiContext);
                        var Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                        AppendText($"结束调用 GetPhotoString", uiContext);
                        if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                        {
                            AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                            thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                        }
                        else
                        {
                            int retrytime = 0;
                            while (retrytime < 3 && string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                                retrytime = retrytime + 1;
                                Thread.Sleep(50);
                            }
                            if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                                thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                            }
                        }

                        response = response.Error("信号显示码垛位没有箱子但有料盘");

                        AppendText("开始调用 CheckRealId", uiContext);
                        if (this.CheckRealId(thisTempReelId))
                        {
                            int reel_size = this.GetMaterialSize(thisTempReelId);
                            AppendText($"获取 料盘尺寸【{reel_size}】", uiContext);
                            Zollner_InOutOrder outOrderEntity = this.GetOutOrderEntityByReelId(thisTempReelId);
                            if (outOrderEntity != null)
                            {
                                string OutboundID = outOrderEntity.OutboundID;
                                AppendText($"获取 料盘对应寻料单单号【{OutboundID}】", uiContext);

                                ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                    .Where(x => x.OutboundID.ToLower() == OutboundID.ToLower())
                                    .Where(x => (x.IsDelete) == false)
                                    .OrderByDescending(x => x.CreateTime)
                                    .First();

                                bool isMix = false;
                                if (soringWorkOrder != null)
                                {
                                    if (soringWorkOrder.DiffSizeInOneBox.HasValue && soringWorkOrder.DiffSizeInOneBox.Value)
                                    {
                                        isMix = true;
                                    }
                                }
                                AppendText($"获取 寻料单是否混箱【{isMix}】", uiContext);

                                int callBoxByCellType = 1;
                                if (reel_size == 7 && isMix)
                                {
                                    callBoxByCellType = 1;
                                }
                                else if (reel_size == 7 && !isMix)
                                {
                                    callBoxByCellType = 4;
                                }
                                else if (reel_size == 13 && isMix)
                                {
                                    callBoxByCellType = 1;
                                }
                                else if (reel_size == 13 && !isMix)
                                {
                                    callBoxByCellType = 1;
                                }
                                AppendText($"对比【{reel_size}】和【{isMix}】获取 当前需要叫箱类型【{callBoxByCellType}】", uiContext);

                                if (callBoxByCellType == 1)
                                {
                                    if (!alreadyAskBox)
                                    {
                                        AppendText("呼叫2入口的箱子入操作台", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫2入口的箱子入操作台", null);
                                        this.AskBoxRollFromInput2_Order = true;
                                        this.AskBoxRollFromInput2(null);
                                        alreadyAskBox = true;
                                        this.AskBoxRollFromInput2_Order = false;
                                    }
                                    else
                                    {
                                        AppendText("已呼叫2入口的箱子入操作台,请耐心等待", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫2入口的箱子入操作台", null);
                                    }

                                }
                                else
                                {
                                    if (!alreadyAskBox)
                                    {
                                        AppendText("呼叫1入口的箱子入操作台", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫1入口的箱子入操作台", null);
                                        this.AskBoxRollFromInput1_Order = true;
                                        this.AskBoxRollFromInput1(null);
                                        alreadyAskBox = true;
                                        this.AskBoxRollFromInput1_Order = false;
                                    }
                                    else
                                    {
                                        AppendText("已呼叫1入口的箱子入操作台,请耐心等待", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫1入口的箱子入操作台", null);
                                    }
                                }
                            }
                            else
                            {
                                AppendText($"调用结果判断 抓料到NG料", uiContext);
                                //抓料到NG料
                                uiContext.Post(_ => txtCurrentNGInfo.Text = $"物料【{thisTempReelId}】无法找到对应出库单，无法匹配箱子类型", null);
                                AskPickerWork_Order = true;
                                AppendText($"开始调用 AskPickerWork 抓料到NG料", uiContext);
                                this.AskPickerWork(null, thisTempBoxNo, thisTempReelId, "5");
                                AppendText($"结束调用 AskPickerWork 抓料到NG料", uiContext);
                                AskPickerWork_Order = false;
                            }

                        }
                        else
                        {
                            AppendText($"检查结果 平台中没有找到当前料号【{thisTempReelId}】", uiContext);
                            uiContext.Post(_ => txtCurrentNGInfo.Text = $"平台中没有找到当前料号【{thisTempReelId}】", null);
                            //抓料到NG料
                            AskPickerWork_Order = true;
                            AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                            this.AskPickerWork(null, thisTempBoxNo, thisTempReelId, "5");
                            AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                            AskPickerWork_Order = false;
                            //TakeOperateWortAtOperateApp_Self = false;
                        }

                        alreadyAskBox = false;
                        //TakeOperateWortAtOperateApp_Self = false;
                        continue;
                    }
                    //没有箱子没有料盘 -> 走不到这里，不需要考虑是否会走到这部分逻辑
                    else if (
                            (Result_13291.IsSucceed && !Result_13291.Value)
                            &&
                            (Result_13292.IsSucceed && !Result_13292.Value)
                            )
                    {
                        AppendText($"检查结果 没有箱子没有料盘", uiContext);
                        AppendText("信号显示码垛位没有箱子,同时入料皮带处没有料盘", uiContext);

                        response = response.Error("信号显示码垛位没有箱子,同时入料皮带处没有料盘");

                        //TakeOperateWortAtOperateApp_Self = false;

                        continue;
                    }
                    else
                    {
                        //信息错误，但PLC是告诉上位机需要提供动作请求的，所以这里就继续循环
                        Thread.Sleep(100);
                        //TakeOperateWortAtOperateApp_Self = false;
                        continue;
                    }

                    Thread.Sleep(50);

                    if (!TakeOperateWortAtOperateApp_Order || !TakeOperateWortAtOperateApp_Self)
                    {
                        if (!TakeOperateWortAtOperateApp_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        AppendText($"退出内部循环 TakeOperateWortAtOperateApp", uiContext);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(50);

                        AppendText($"继续内部循环 TakeOperateWortAtOperateApp", uiContext);
                        continue;
                    }

                    Thread.Sleep(50);

                }
                else
                {
                    AppendText($"[读取 13748 失败]", uiContext);

                    var Result_13291 = client.ReadCoil("13291", stationNumber);
                    var Result_13292 = client.ReadCoil("13292", stationNumber);

                    AppendText($"尝试读取【13291,13292】信号", uiContext);
                    if (
                            (Result_13291.IsSucceed && !Result_13291.Value)
                            &&
                            (Result_13292.IsSucceed && Result_13292.Value)
                            )
                    {
                        AppendText("信号显示码垛位没有箱子但有料盘", uiContext);

                        AppendText($"开始调用 GetPhotoString", uiContext);
                        var Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                        AppendText($"结束调用 GetPhotoString", uiContext);
                        if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                        {
                            AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                            thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                        }
                        else
                        {
                            int retrytime = 0;
                            while (retrytime < 3 && string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                Response_TakePhotoAtOperateApp = this.GetPhotoString(null);
                                retrytime = retrytime + 1;
                                Thread.Sleep(50);
                            }
                            if (!string.IsNullOrEmpty(Response_TakePhotoAtOperateApp.Data.ToString()) && Response_TakePhotoAtOperateApp.Data.ToString() != "M")
                            {
                                AppendText($"获取料盘 【{Response_TakePhotoAtOperateApp.Data.ToString()}】", uiContext);
                                thisTempReelId = Response_TakePhotoAtOperateApp.Data.ToString();
                            }
                        }

                        response = response.Error("信号显示码垛位没有箱子但有料盘");

                        AppendText("调用 CheckRealId, 检查料盘", uiContext);
                        if (this.CheckRealId(thisTempReelId))
                        {
                            int reel_size = this.GetMaterialSize(thisTempReelId);
                            AppendText($"获取 料盘尺寸尺寸【{reel_size}】", uiContext);
                            Zollner_InOutOrder outOrderEntity = this.GetOutOrderEntityByReelId(thisTempReelId);
                            if (outOrderEntity != null)
                            {
                                AppendText($"获取 出库单实体", uiContext);
                                string OutboundID = outOrderEntity.OutboundID;
                                AppendText($"获取 寻料单单号{OutboundID}", uiContext);
                                ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                    .Where(x => x.OutboundID.ToLower() == OutboundID.ToLower())
                                    .Where(x => (x.IsDelete) == false)
                                    .OrderByDescending(x => x.CreateTime)
                                    .First();
                                AppendText($"获取 寻料单实体", uiContext);
                                bool isMix = false;
                                if (soringWorkOrder != null)
                                {
                                    if (soringWorkOrder.DiffSizeInOneBox.HasValue && soringWorkOrder.DiffSizeInOneBox.Value)
                                    {
                                        isMix = true;
                                    }
                                }
                                AppendText($"获取 是否混箱【{isMix}】", uiContext);
                                int callBoxByCellType = 1;
                                if (reel_size == 7 && isMix)
                                {
                                    callBoxByCellType = 1;
                                }
                                else if (reel_size == 7 && !isMix)
                                {
                                    callBoxByCellType = 4;
                                }
                                else if (reel_size == 13 && isMix)
                                {
                                    callBoxByCellType = 1;
                                }
                                else if (reel_size == 13 && !isMix)
                                {
                                    callBoxByCellType = 1;
                                }

                                if (callBoxByCellType == 1)
                                {
                                    if (!alreadyAskBox)
                                    {
                                        AppendText("呼叫2入口的箱子入操作台", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫2入口的箱子入操作台", null);
                                        this.AskBoxRollFromInput2_Order = true;
                                        this.AskBoxRollFromInput2(null);
                                        alreadyAskBox = true;
                                        this.AskBoxRollFromInput2_Order = false;
                                    }
                                    else
                                    {
                                        AppendText("已呼叫2入口的箱子入操作台,请耐心等待", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫2入口的箱子入操作台", null);
                                    }

                                }
                                else
                                {
                                    if (!alreadyAskBox)
                                    {
                                        AppendText("呼叫1入口的箱子入操作台", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫1入口的箱子入操作台", null);
                                        this.AskBoxRollFromInput1_Order = true;
                                        this.AskBoxRollFromInput1(null);
                                        alreadyAskBox = true;
                                        this.AskBoxRollFromInput1_Order = false;
                                    }
                                    else
                                    {
                                        AppendText("已呼叫1入口的箱子入操作台,请耐心等待", uiContext);
                                        uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫1入口的箱子入操作台", null);
                                    }
                                }
                            }
                            else
                            {
                                AppendText($"检查结果 平台中没有找到当前料号【{thisTempReelId}】", uiContext);
                                uiContext.Post(_ => txtCurrentNGInfo.Text = $"平台中没有找到当前料号【{thisTempReelId}】", null);

                                if (!alreadyAskBox)
                                {
                                    AppendText("呼叫2入口的箱子入操作台", uiContext);
                                    uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫2入口的箱子入操作台", null);
                                    this.AskBoxRollFromInput2_Order = true;
                                    this.AskBoxRollFromInput2(null);
                                    alreadyAskBox = true;
                                    this.AskBoxRollFromInput2_Order = false;
                                }
                                else
                                {
                                    AppendText("已呼叫2入口的箱子入操作台,请耐心等待", uiContext);
                                    uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫2入口的箱子入操作台", null);
                                }

                                //抓料到NG料
                                AskPickerWork_Order = true;
                                AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                                this.AskPickerWork(null, thisTempBoxNo, thisTempReelId, "5");
                                AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                                AskPickerWork_Order = false;
                                //TakeOperateWortAtOperateApp_Self = false;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(thisTempReelId))
                            {
                                response = response.OK($"物料唯一码【{thisTempReelId}】未识别", -1);
                                AppendText($"物料唯一码【{thisTempReelId}】未识别", uiContext);
                                uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                            }
                            else if (thisTempReelId.ToUpper() == "M")
                            {
                                response = response.OK($"物料唯一码【{thisTempReelId}】不清晰或存在多个唯一码", -1);
                                AppendText($"物料唯一码【{thisTempReelId}】不清晰或存在多个唯一码", uiContext);
                                uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                            }
                            else
                            {
                                response = response.OK($"物料唯一码【{thisTempReelId}】不存在", -1);
                                AppendText($"物料唯一码【{thisTempReelId}】不存在", uiContext);
                                uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                            }


                            if (!alreadyAskBox)
                            {
                                AppendText("呼叫2入口的箱子入操作台", uiContext);
                                uiContext.Post(_ => txtCurrentProcessInfo.Text = $"呼叫2入口的箱子入操作台", null);
                                this.AskBoxRollFromInput2_Order = true;
                                this.AskBoxRollFromInput2(null);
                                alreadyAskBox = true;
                                this.AskBoxRollFromInput2_Order = false;
                            }
                            else
                            {
                                AppendText("已呼叫2入口的箱子入操作台,请耐心等待", uiContext);
                                uiContext.Post(_ => txtCurrentProcessInfo.Text = $"已呼叫2入口的箱子入操作台", null);
                            }

                            //
                            //var Result_14311 = client.Write("14311", true, stationNumber);

                            //抓料到NG料
                            //client.Write("14690", true, stationNumber);
                            uiContext.Post(_ => txtCurrentNGInfo.Text = response.Message, null);
                            AskPickerWork_Order = true;
                            AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                            this.AskPickerWork(null, thisTempBoxNo, thisTempReelId, "5");
                            AppendText($"调用 AskPickerWork, 抓料到NG料", uiContext);
                            AskPickerWork_Order = false;
                            //client.Write("14690", false, stationNumber);
                        }

                        alreadyAskBox = false;
                        //TakeOperateWortAtOperateApp_Self = false;
                        continue;
                    }
                    else if ((Result_13291.IsSucceed && Result_13291.Value))
                    {
                        AppendText("信号显示码垛位有箱子", uiContext);
                        AppendText("信号显示码垛位有箱子但没有料盘", uiContext);

                        Thread.Sleep(50);

                        this.TakeScanAtOperateApp_Order = true;
                        this.TakeScanAtOperateApp(null);
                        this.TakeScanAtOperateApp_Order = false;


                        string boxNo = this.Buffer_BoxNo_AtOperate;
                        string outOrderNo = this.GetOutOrderNoByBoxNo(boxNo);
                        if (!string.IsNullOrEmpty(outOrderNo))
                        {
                            //检查是否是出库单的最后一笔记录
                            var findOurOrderDetailList = this.GetOutOrderDetailListByOutOrderNo(outOrderNo);
                            if (findOurOrderDetailList.FindAll(x => (!x.BatchBCJobStatus.HasValue || (x.BatchBCJobStatus.HasValue && (x.BatchBCJobStatus.Value != 2 && x.BatchBCJobStatus.Value != 3 && x.BatchBCJobStatus.Value != 5)))).Count > 0)
                            {
                                AppendText($"出库单【{outOrderNo}】下明细数据尚未全部完成出库或手工出库", uiContext);
                                //不做出库单主表的操作
                            }
                            else
                            {
                                AppendText($"出库单【{outOrderNo}】下所有明细数据全部完成出库或手工出库", uiContext);
                                var updateOutOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                                if (updateOutOrderEntity.OutboundJobStatus == 0 || updateOutOrderEntity.OutboundJobStatus == 1 || updateOutOrderEntity.OutboundJobStatus == 2 || updateOutOrderEntity.OutboundJobStatus == 3)
                                {
                                    updateOutOrderEntity.OutboundJobStatus = 2;
                                }
                                updateOutOrderEntity.EndTime = DateTime.Now;
                                updateOutOrderEntity.UpdateTime = DateTime.Now;
                                updateOutOrderEntity.UpdateUserId = -1;
                                updateOutOrderEntity.UpdateUserName = "码垛机";
                                this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();

                                ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                                                                .Where(x => x.OutboundID.ToLower() == updateOutOrderEntity.OutboundID.ToLower())
                                                                                .Where(x => (x.IsDelete) == false)
                                                                                .OrderByDescending(x => x.CreateTime)
                                                                                .First();
                                //检查是否所有的出库单都是完成的
                                var otherNotCompleteInoutOrderList = this.dbContent.Queryable<Zollner_InOutOrder>()
                                        .Where(x => x.IsDelete == false && x.OutboundID == updateOutOrderEntity.OutboundID
                                                && x.OutOrderNo != updateOutOrderEntity.OutOrderNo
                                                && (x.OutboundJobStatus != 2 && x.OutboundJobStatus != 4)
                                                ).ToList();
                                if (otherNotCompleteInoutOrderList.Count == 0)
                                {
                                    if (soringWorkOrder != null)
                                    {
                                        soringWorkOrder.OutboundStatus = 4;
                                        soringWorkOrder.EndTime = DateTime.Now;
                                        this.dbContent.Updateable<ZollnerOutboundForProduction>(soringWorkOrder).ExecuteCommand();
                                    }

                                }

                                //给PLC信号->出库工单已经完成，可以走下一个出库工单
                                AppendText($"准备写入【14308】True 信号", uiContext);
                                var Result_14308 = client.Write("14308", true, stationNumber);
                                if (Result_14308.IsSucceed)
                                {
                                    AppendText($"写入【14308】成功", uiContext);
                                    //Thread.Sleep(5000);
                                    Thread.Sleep(500);
                                    AppendText($"准备擦除【14308】True 信号", uiContext);
                                    Result_14308 = client.Write("14308", false, stationNumber);
                                    AppendText($"[写入【14308】成功", uiContext);
                                }


                                //给PLC信号->出库工单新工单信号-->置成false
                                client.Write("14289", true, stationNumber);
                                AppendText($"准备写入【14289】False 信号", uiContext);
                                var Result_14289 = client.Write("14289", false, stationNumber);
                                if (Result_14289.IsSucceed)
                                {
                                    AppendText($"写入【14289】成功", uiContext);
                                }
                            }
                        }
                        

                        Thread.Sleep(50);
                    }

                    //client.Write("13748", true, stationNumber);
                    //client.Write("14738", true, stationNumber);
                    //alreadyPut13748 = true;

                    Thread.Sleep(50);

                    if (!TakeOperateWortAtOperateApp_Order || !TakeOperateWortAtOperateApp_Self)
                    {
                        if (!TakeOperateWortAtOperateApp_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        AppendText($"退出内部循环 TakeOperateWortAtOperateApp", uiContext);
                        break;
                    }
                    else
                    {
                        Thread.Sleep(50);

                        AppendText($"继续内部循环 TakeOperateWortAtOperateApp", uiContext);
                        continue;
                    }

                    Thread.Sleep(50);
                    continue;
                }
            }

            AppendText($"结束内部循环 TakeOperateWortAtOperateApp", uiContext);

            return response;
        }

        public bool AskBoxRoolToOutpu3_Order { get; set; } = false;
        /// <summary>
        /// 工作台出箱
        /// </summary>
        public ResponseContent AskBoxRoolToOutpu3(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool AskBoxRoolToOutpu3_Self = true;

            while (true && AskBoxRoolToOutpu3_Order && AskBoxRoolToOutpu3_Self)
            {
                Thread.Sleep(50);

                ///1
                //动作请求【13748】
                var Result_13748 = client.ReadCoil("13748", stationNumber);
                if (Result_13748.IsSucceed
                    && Result_13748.Value
                    )
                {
                    Thread.Sleep(50);

                    //取消任务
                    if (!AskBoxRoolToOutpu3_Order)
                    {
                        if (!AskBoxRoolToOutpu3_Order)
                        {
                            response = response.Error("取消码垛呼叫3通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {
                        
                    }

                    Thread.Sleep(50);

                    AppendText($"[读取 13748 成功]", uiContext);

                    //擦除前一轮写入的信号
                    Thread.Sleep(50);
                    Result Result_14748 = client.Write("14748", false, stationNumber);
                    Thread.Sleep(50);

                    ///2
                    //当前OK类型的箱子流出【14748】
                    Thread.Sleep(50);

                    while (true && AskBoxRoolToOutpu3_Order && AskBoxRoolToOutpu3_Self)
                    {
                        Result_14748 = client.Write("14748", true, stationNumber);
                        if (Result_14748.IsSucceed)
                        {
                            AppendText($"[写入 14748 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);


                    ///3
                    //当前OK类型的箱子流出OK【13753】
                    Thread.Sleep(50);

                    while (true && AskBoxRoolToOutpu3_Order && AskBoxRoolToOutpu3_Self)
                    {
                        var Result_13753 = client.ReadCoil("13753", stationNumber);
                        if (Result_13753.IsSucceed && Result_13753.Value)
                        {
                            AppendText($"[读取 13753 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14748 = client.Write("14748", false, stationNumber);
                            Thread.Sleep(50);

                            response = response.OK();

                            AskBoxRoolToOutpu3_Self = false;
                            //AskBoxRoolToOutpu3_Order = false;

                            this.Buffer_BoxNo_AtOperate = string.Empty;
                            uiContext.Post(_ => this.curBufBoxNo.Text = this.Buffer_BoxNo_AtOperate, null);
                            uiContext.Post(_ => this.curBufIsEmpty.Text = "", null);
                            uiContext.Post(_ => this.curBufBoxNoBindOutorderNo.Text = "", null);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);


                    if (!AskBoxRoolToOutpu3_Order || !AskBoxRoolToOutpu3_Self)
                    {
                        if (!AskBoxRoolToOutpu3_Order)
                        {
                            response = response.Error("取消码垛呼叫3通道箱子任务!");
                        }

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Thread.Sleep(50);

            AppendText("结束码垛呼叫3通道箱子任务", uiContext);

            return response;
        }

        public bool AskPickerWork_Order { get; set; } = false;
        /// <summary>
        /// 工作台装料
        /// </summary>
        public ResponseContent AskPickerWork(object para, string boxNo, string reelId, string cellNo = "")
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool AskPickerWork_Self = true;

            AppendText($"开始执行 AskPickerWork", uiContext);
            bool RunOnce = true;

            //给PLC信号->出库工单新工单信号-->置成True
            AppendText($"准备写入【14289】False 信号", uiContext);
            var Result_14289 = client.Write("14289", true, stationNumber);
            if (Result_14289.IsSucceed)
            {
                AppendText($"[写入 14289 成功]", uiContext);
            }

            while (true && AskPickerWork_Order && AskPickerWork_Self && RunOnce)
            {
                Thread.Sleep(50);
                //RunOnce = false;

                if (!AskPickerWork_Order)
                {
                    break;
                }

                if (cellNo == "5")
                {
                    Result Result_14311 = null;

                    Result_14311 = client.Write("14311", false, stationNumber);
                    Result_14311 = client.Write("14311", true, stationNumber);

                    if (Result_14311.IsSucceed)
                    {
                        AppendText($"[写入 14311 成功]", uiContext);

                        Result_14311 = client.Write("14311", false, stationNumber);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    Result Result_14310 = null;

                    Result_14310 = client.Write("14310", false, stationNumber);
                    Result_14310 = client.Write("14310", true, stationNumber);

                    if (Result_14310.IsSucceed)
                    {
                        AppendText($"[写入 14310 成功]", uiContext);

                        Result_14310 = client.Write("14310", false, stationNumber);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (!AskPickerWork_Order)
                {
                    break;
                }

                ///1
                //动作请求【13748】
                AppendText($"开始执行 动作请求【13748】", uiContext);
                var Result_13748 = client.ReadCoil("13748", stationNumber);
                AppendText($"开始执行 检查料盘到位【13292】", uiContext);
                var Result_13292 = client.ReadCoil("13292", stationNumber);
                if (
                    (
                    Result_13748.IsSucceed
                    && Result_13748.Value
                    )
                    ||
                    (
                    Result_13292.IsSucceed
                    && Result_13292.Value
                    )
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"[读取 13748 成功]", uiContext);

                    //擦除前一轮写入的信号
                    Thread.Sleep(50);
                    AppendText($"擦除前一轮写入的信号", uiContext);
                    Result Result_14749 = client.Write("14749", false, stationNumber);
                    Thread.Sleep(50);


                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    ///2
                    //入料皮带处有料【13292】

                    Thread.Sleep(50);
                    AppendText($"开始执行 入料皮带处有料【13292】", uiContext);
                    while (true && AskPickerWork_Order && AskPickerWork_Self)
                    {
                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        Result_13292 = client.ReadCoil("13292", stationNumber);
                        if (Result_13292.IsSucceed && Result_13292.Value)
                        {
                            //uiContext.Post(_ => txt_13292.Text = "1", null);
                            AppendText($"[读取 13292 成功]", uiContext);
                            Thread.Sleep(50);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    //3
                    //拍照取放【14749】
                    Thread.Sleep(50);
                    AppendText($"开始执行 拍照取放【14749】", uiContext);
                    while (true && AskPickerWork_Order && AskPickerWork_Self)
                    {
                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        Result_14749 = client.Write("14749", true, stationNumber);
                        if (Result_14749.IsSucceed)
                        {
                            AppendText($"[写入 14749 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Thread.Sleep(50);

                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    int cellType = 1;
                    int d_cell_no = 1;
                    //4
                    //位置放置
                    AppendText($"开始执行 位置放置", uiContext);
                    while (true && AskPickerWork_Order && AskPickerWork_Self)
                    {
                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        //获取设定
                        var resourceSetting = Properties.Settings.Default;

                        cellType = this.GetBoxCellTypeByBoxNo(boxNo);
                        List<Boxdetail> findAllExistInBox = this.GetBoxDetailListByBoxNo(boxNo);
                        if (cellType == 4)
                        {
                            if (cellNo != "5")
                            {
                                if (string.IsNullOrEmpty(cellNo))
                                {
                                    for (int currentCellNo = 1; currentCellNo <= 4; currentCellNo++)
                                    {
                                        if (findAllExistInBox.FindAll(x => x.Code == currentCellNo.ToString()).Count >= resourceSetting.Box7CellMaxNum)
                                        {
                                            d_cell_no = currentCellNo;
                                            continue;
                                        }
                                        else
                                        {
                                            d_cell_no = currentCellNo;
                                            if (this.CheckIsCellFullInPLCInfo(cellType, currentCellNo))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    d_cell_no = int.Parse(cellNo);
                                }
                            }
                            else
                            {
                                d_cell_no = 5;
                            }
                        }
                        else
                        {
                            if (cellNo != "5")
                            {
                                if (string.IsNullOrEmpty(cellNo))
                                {
                                    for (int currentCellNo = 1; currentCellNo <= 1; currentCellNo++)
                                    {
                                        if (findAllExistInBox.FindAll(x => x.Code == currentCellNo.ToString()).Count >= resourceSetting.Box13CellMaxNum)
                                        {
                                            d_cell_no = currentCellNo;
                                            continue;
                                        }
                                        else
                                        {
                                            d_cell_no = currentCellNo;
                                            if (this.CheckIsCellFullInPLCInfo(cellType, currentCellNo))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    d_cell_no = int.Parse(cellNo);
                                }
                            }
                            else
                            {
                                d_cell_no = 5;
                            }
                        }

                        AppendText($"获取 位置放置【{d_cell_no}】", uiContext);
                        Thread.Sleep(50);

                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        //先过账，过账OK-》正常操作；过账失败-》NG操作
                        Thread.Sleep(50);
                        if (d_cell_no == 5)
                        {

                        }
                        else
                        {
                            ResponseContent transferRes = new ResponseContent();
                            try
                            {
                                transferRes = this.TransferBatch(reelId, boxNo);
                            }
                            catch(Exception ex)
                            {
                                transferRes = transferRes.Error("过账失败，网络传输失败");
                                AppendText(transferRes.Message, uiContext);
                            }
                        
                            if (transferRes.Status)
                            {
                                AppendText($"过账成功，继续正常装箱", uiContext);
                                AppendText(transferRes.Message, uiContext);
                            }
                            else
                            {
                                AppendText($"过账失败，继续料进NG箱", uiContext);
                                AppendText(transferRes.Message, uiContext);
                                d_cell_no = 5;

                            }
                        }
                        Thread.Sleep(50);

                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        Thread.Sleep(50);
                        Result Result_14738 = null;
                        AppendText($"获取 cellType【{cellType}】", uiContext);
                        if (cellType == 4) //7寸的
                        {
                            AppendText($"当前箱子是 【{cellType}】格子", uiContext);

                            Result Result_7011 = null;

                            Result_14738 = client.Write("14738", true, stationNumber);
                            Result_7011 = client.Write("7011", d_cell_no, stationNumber);

                            if (Result_7011.IsSucceed)
                            {
                                AppendText($"[写入 7011 成功]", uiContext);

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else              //13寸或者混的
                        {
                            AppendText($"当前箱子是 【{cellType}】格子", uiContext);
                            Result Result_7013 = null;

                            Result_14738 = client.Write("14738", true, stationNumber);
                            Result_7013 = client.Write("7013", d_cell_no, stationNumber);

                            //if (d_cell_no != 5 && cellNo != "5")
                            //{
                            //    int reelSize = 13;
                            //    if (this.CheckRealId(reelId))
                            //    {
                            //        reelSize = this.GetMaterialSize(reelId);
                            //    }
                            //    if (reelSize == 7)
                            //    {
                            //        var existBoxItemNumInBoxPosition2 = this.GetBoxDetailListByBoxNo(boxNo).FindAll(x => x.Code == "2").Count;
                            //        var existBoxItemNumInBoxPosition3 = this.GetBoxDetailListByBoxNo(boxNo).FindAll(x => x.Code == "3").Count;
                            //        if (existBoxItemNumInBoxPosition2 > existBoxItemNumInBoxPosition3)
                            //        {
                            //            if (d_cell_no != 5 && cellNo != "5")
                            //            {
                            //                d_cell_no = 3;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (d_cell_no != 5 && cellNo != "5")
                            //            {
                            //                d_cell_no = 2;
                            //            }
                            //        }
                            //    }

                            //    Result_14738 = client.Write("14738", true, stationNumber);
                            //    Result_7013 = client.Write("7013", d_cell_no, stationNumber);
                            //}
                            //else
                            //{
                            //    Result_14738 = client.Write("14738", true, stationNumber);
                            //    Result_7013 = client.Write("7013", d_cell_no, stationNumber);
                            //}

                            if (Result_7013.IsSucceed)
                            {
                                AppendText($"[写入 7013 成功]", uiContext);

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }


                    }
                    Thread.Sleep(50);

                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    //5
                    //位置放置OK【6011,6012,6013】
                    Thread.Sleep(50);

                    while (true && AskPickerWork_Order && AskPickerWork_Self)
                    {

                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        var Result_6011 = client.ReadCoil("6011", stationNumber);
                        var Result_6012 = client.ReadCoil("6012", stationNumber);
                        var Result_6013 = client.ReadCoil("6013", stationNumber);
                        Result_13748 = client.ReadCoil("13748", stationNumber);
                        if (cellType == 4 && ((Result_6011.IsSucceed && (Result_6011.Value)) || (Result_13748.IsSucceed && Result_13748.Value)))
                        {
                            //Success
                            response = response.OK("位置放置OK!");
                            AppendText("位置放置OK!", uiContext);

                            AppendText($"读取【6011】成功：{Result_6011.Value}", uiContext);

                            //擦除刚才前一轮写入的信号
                            AppendText($"擦除刚才前一轮写入的信号【{7011},{7012},{7013},{14738}】", uiContext);
                            Thread.Sleep(50);
                            var Result_7011 = client.Write("7011", 0, stationNumber);
                            var Result_7012 = client.Write("7012", 0, stationNumber);
                            var Result_7013 = client.Write("7013", 0, stationNumber);
                            var Result_14738 = client.Write("14738", false, stationNumber);
                            Thread.Sleep(50);

                            break;
                        }
                        else if (cellType == 1 && ((Result_6013.IsSucceed && (Result_6013.Value)) || (Result_13748.IsSucceed && Result_13748.Value)))
                        {
                            //Raise Error
                            response = response.Error("位置放置OK!");

                            AppendText($"读取【6013】成功：{Result_6013.Value}", uiContext);

                            //擦除刚才前一轮写入的信号
                            AppendText($"擦除刚才前一轮写入的信号【{7011},{7012},{7013},{14738}】", uiContext);
                            Thread.Sleep(50);
                            var Result_7011 = client.Write("7011", 0, stationNumber);
                            var Result_7012 = client.Write("7012", 0, stationNumber);
                            var Result_7013 = client.Write("7013", 0, stationNumber);
                            var Result_14738 = client.Write("14738", false, stationNumber);
                            Thread.Sleep(50);

                            break;
                        }
                    }
                    Thread.Sleep(50);

                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    //更新数据
                    Thread.Sleep(50);
                    if (d_cell_no != 5)
                    {
                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        AppendText($"开始 更新平台箱内料盘数据", uiContext);
                        bool isBoxDetailExist = this.IsBoxDetailExistInBox(boxNo, reelId);
                        Boxdetail boxDetailEntity = null;
                        if (isBoxDetailExist)
                        {
                            boxDetailEntity = this.GetBoxDetailExistInBox(boxNo, reelId);
                            boxDetailEntity.Code = d_cell_no.ToString();
                            boxDetailEntity.BoxCode = boxNo;
                            boxDetailEntity.Deleted = false;
                            boxDetailEntity.CreateTime = DateTime.Now;
                            boxDetailEntity.CreatorId = "-1";
                            boxDetailEntity.BindReeid = reelId;
                            boxDetailEntity.CreateUserId = -1;
                            boxDetailEntity.CreateUserName = "-1";
                            boxDetailEntity.IsDelete = false;
                        }
                        else
                        {
                            boxDetailEntity = new Boxdetail
                            {
                                Id = SnowFlakeSingle.Instance.NextId(),
                                Code = d_cell_no.ToString(),
                                BoxCode = boxNo,
                                Deleted = false,
                                CreateTime = DateTime.Now,
                                CreatorId = "-1",
                                BindReeid = reelId,
                                CreateUserId = -1,
                                CreateUserName = "-1",
                                IsDelete = false,
                                //UpdateTime
                                //UpdateUserId
                                //UpdateUserName
                            };
                        }

                        string outOrderNo = this.GetOutOrderNoByBoxNo(boxNo);
                        if (string.IsNullOrEmpty(outOrderNo))
                        {
                            outOrderNo = this.GetOutOrderNoByReelId(reelId);
                        }
                        
                        if (!string.IsNullOrEmpty(outOrderNo))
                        {
                            Zollner_InOutOrderDetail detailEntity = this.GetInOutOrderDetailEntityByReelId(outOrderNo, reelId);
                            detailEntity.BatchBCJobStatus = 2;
                            detailEntity.BatchBCPostingStatus = 1;
                            detailEntity.Outbound_Container_BC = boxNo;
                            detailEntity.Batch_BC_Outbound_Processing_Type = 0;
                            detailEntity.EndTime = DateTime.Now;

                            var materialEntity = this.GetMaterialStockEntityByReelId(reelId);
                            materialEntity.Status = 70;


                            //更新Boxdetail 和 Zollner_InOutOrderDetail
                            this.dbContent.Ado.BeginTran();
                            bool insert_Flag = false;
                            if (isBoxDetailExist)
                            {
                                //insert_Flag = this.dbContent.Updateable<Boxdetail>(boxDetailEntity).ExecuteCommand() > 0;
                            }
                            else
                            {
                                insert_Flag = this.dbContent.Insertable<Boxdetail>(boxDetailEntity).ExecuteCommand() > 0;
                            }
                                
                            AppendText($"更新 Boxdetail【{insert_Flag}】", uiContext);
                            bool update_Flag = this.dbContent.Updateable<Zollner_InOutOrderDetail>(detailEntity).ExecuteCommand() > 0;
                            AppendText($"更新 Zollner_InOutOrderDetail【{update_Flag}】", uiContext);
                            bool update_Flag1 = this.dbContent.Updateable<MaterialStock>(materialEntity).UpdateColumns(x => new { x.Status }).ExecuteCommand() > 0;
                            AppendText($"更新 MaterialStock【{update_Flag1}】", uiContext);
                            if (insert_Flag && update_Flag && update_Flag1)
                            {
                                this.dbContent.Ado.CommitTran();
                                AppendText($"事务更新成功", uiContext);
                            }
                            else
                            {
                                this.dbContent.Ado.RollbackTran();
                                AppendText($"事务更新失败", uiContext);
                            }

                            //检查是否是出库单的最后一笔记录
                            var findOurOrderDetailList = this.GetOutOrderDetailListByOutOrderNo(outOrderNo);
                            if (findOurOrderDetailList.FindAll(x => (!x.BatchBCJobStatus.HasValue || (x.BatchBCJobStatus.HasValue && (x.BatchBCJobStatus.Value != 2 && x.BatchBCJobStatus.Value != 3 && x.BatchBCJobStatus.Value != 5)))).Count > 0)
                            {
                                AppendText($"出库单【{outOrderNo}】下明细数据尚未全部完成出库或手工出库", uiContext);
                                //不做出库单主表的操作
                            }
                            else
                            {
                                AppendText($"出库单【{outOrderNo}】下所有明细数据全部完成出库或手工出库", uiContext);
                                var updateOutOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                                if (updateOutOrderEntity.OutboundJobStatus == 0 || updateOutOrderEntity.OutboundJobStatus == 1 || updateOutOrderEntity.OutboundJobStatus == 2 || updateOutOrderEntity.OutboundJobStatus == 3)
                                {
                                    updateOutOrderEntity.OutboundJobStatus = 2;
                                }
                                updateOutOrderEntity.EndTime = DateTime.Now;
                                updateOutOrderEntity.UpdateTime = DateTime.Now;
                                updateOutOrderEntity.UpdateUserId = -1;
                                updateOutOrderEntity.UpdateUserName = "码垛机";
                                this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();

                                ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                                                                .Where(x => x.OutboundID.ToLower() == updateOutOrderEntity.OutboundID.ToLower())
                                                                                .Where(x => (x.IsDelete) == false)
                                                                                .OrderByDescending(x => x.CreateTime)
                                                                                .First();

                                //检查是否所有的出库单都是完成的
                                var otherNotCompleteInoutOrderList = this.dbContent.Queryable<Zollner_InOutOrder>()
                                        .Where(x => x.IsDelete == false && x.OutboundID == updateOutOrderEntity.OutboundID
                                                && x.OutOrderNo != updateOutOrderEntity.OutOrderNo
                                                && (x.OutboundJobStatus != 2 && x.OutboundJobStatus != 4)
                                                ).ToList();
                                if (otherNotCompleteInoutOrderList.Count == 0)
                                {
                                    if (soringWorkOrder != null)
                                    {
                                        soringWorkOrder.OutboundStatus = 4;
                                        soringWorkOrder.EndTime = DateTime.Now;
                                        this.dbContent.Updateable<ZollnerOutboundForProduction>(soringWorkOrder).ExecuteCommand();
                                    }
                                }

                                if (!AskPickerWork_Order)
                                {
                                    break;
                                }

                                //给PLC信号->出库工单已经完成，可以走下一个出库工单
                                client.Write("14308", false, stationNumber);
                                AppendText($"准备写入【14308】True 信号", uiContext);
                                var Result_14308 = client.Write("14308", true, stationNumber);
                                if (Result_14308.IsSucceed)
                                {
                                    AppendText($"[写入【14308】成功", uiContext);
                                    //Thread.Sleep(5000);
                                    Thread.Sleep(500);
                                    AppendText($"准备擦除【14308】True 信号", uiContext);
                                    Result_14308 = client.Write("14308", false, stationNumber);
                                    AppendText($"[写入【14308】成功]", uiContext);
                                }

                                if (!AskPickerWork_Order)
                                {
                                    break;
                                }

                                //给PLC信号->出库工单新工单信号-->置成false
                                Result_14289 = client.Write("14289", true, stationNumber);
                                AppendText($"准备写入【14289】False 信号", uiContext);
                                Result_14289 = client.Write("14289", false, stationNumber);
                                if (Result_14289.IsSucceed)
                                {
                                    AppendText($"写入【14289】成功", uiContext);
                                }

                                if (!AskPickerWork_Order)
                                {
                                    break;
                                }
                            }


                            if (insert_Flag)
                            {
                                AppendText($"更新平台箱内料盘数据成功", uiContext);
                            }
                            else
                            {
                                AppendText($"更新平台箱内料盘数据失败", uiContext);
                            }
                        }
                        AppendText($"结束 更新平台箱内料盘数据", uiContext);
                    }
                    else
                    {
                        if (!AskPickerWork_Order)
                        {
                            break;
                        }

                        AppendText($"开始 更新平台NG箱内料盘数据", uiContext);

                        if (cellNo == "5")
                        {
                            //这是还没过账，被码垛机判断为需要直接被扔进NG箱的情况
                            string outOrderNo = this.GetOutOrderNoByBoxNo(boxNo);
                            if (string.IsNullOrEmpty(outOrderNo))
                            {
                                outOrderNo = this.GetOutOrderNoByReelId(reelId);
                            }

                            Zollner_InOutOrder outOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                            if (outOrderEntity != null)
                            {
                                outOrderEntity.OutboundJobStatus = 3;
                                //outOrderEntity.EndTime = DateTime.Now;
                                outOrderEntity.UpdateTime = DateTime.Now;
                                outOrderEntity.UpdateUserId = -1;
                                outOrderEntity.UpdateUserName = "码垛机";
                            }

                            Zollner_InOutOrderDetail detailEntity = this.GetInOutOrderDetailEntityByReelId(outOrderNo, reelId);
                            MaterialStock materialEntity = this.GetMaterialStockEntityByReelId(reelId);
                            if (detailEntity != null && materialEntity != null)
                            {
                                detailEntity.BatchBCJobStatus = 4;
                                detailEntity.BatchBCPostingStatus = 0;
                                detailEntity.EndTime = DateTime.Now;

                                ZollnerNGLog ngLogEntity = new ZollnerNGLog
                                {
                                    Id = SnowFlakeSingle.Instance.NextId(),
                                    NGBoxCode = "830100001734",
                                    OutboundID = outOrderEntity.OutboundID,
                                    OutOrderNo = outOrderEntity.OutOrderNo,
                                    BatchBC = reelId,
                                    SMTLine = string.Empty,
                                    ErrorMsg = "料盘与出库任务单不匹配",
                                    Component_BC = string.Empty,
                                    Qty = null,
                                    BoxCode = boxNo,
                                    CreateTime = DateTime.Now,
                                    isDelete = false,
                                    TowerNo = materialEntity.AreaCode,
                                    inBox = true,
                                };

                                materialEntity.Status = 50;

                                //更新 Zollner_InOutOrderDetail
                                this.dbContent.Ado.BeginTran();
                                this.DeleteAllRefNGLogByReelId(reelId);
                                bool insert_Flag = this.dbContent.Insertable<ZollnerNGLog>(ngLogEntity).ExecuteCommand() > 0;
                                AppendText($"更新 ZollnerNGLog【{insert_Flag}】", uiContext);
                                bool update_Flag = this.dbContent.Updateable<Zollner_InOutOrderDetail>(detailEntity).ExecuteCommand() > 0;
                                AppendText($"更新 Zollner_InOutOrderDetail【{update_Flag}】", uiContext);
                                bool update_Flag2 = this.dbContent.Updateable<Zollner_InOutOrder>(outOrderEntity).ExecuteCommand() > 0;
                                AppendText($"更新 Zollner_InOutOrder【{update_Flag}】", uiContext);
                                bool update_Flag1 = this.dbContent.Updateable<MaterialStock>(materialEntity).UpdateColumns(x => new { x.Status }).ExecuteCommand() > 0;
                                AppendText($"更新 MaterialStock【{update_Flag1}】", uiContext);

                                if (insert_Flag && update_Flag)
                                {
                                    this.dbContent.Ado.CommitTran();
                                    AppendText($"事务更新成功", uiContext);
                                }
                                else
                                {
                                    this.dbContent.Ado.RollbackTran();
                                    AppendText($"事务更新失败", uiContext);
                                }
                            }
                        }
                        else
                        {
                            uiContext.Post(_ => txtCurrentNGInfo.Text = $"物料【{reelId}】过账失败", null);

                            //过账失败，被扔进NG箱的情况
                            string outOrderNo = this.GetOutOrderNoByBoxNo(boxNo);
                            if (string.IsNullOrEmpty(outOrderNo))
                            {
                                outOrderNo = this.GetOutOrderNoByReelId(reelId);
                            }
                            Zollner_InOutOrder outOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                            outOrderEntity.OutboundJobStatus = 3;
                            //outOrderEntity.EndTime = DateTime.Now;
                            outOrderEntity.UpdateTime = DateTime.Now;
                            outOrderEntity.UpdateUserId = -1;
                            outOrderEntity.UpdateUserName = "码垛机";

                            Zollner_InOutOrderDetail detailEntity = this.GetInOutOrderDetailEntityByReelId(outOrderNo, reelId);
                            MaterialStock materialEntity = this.GetMaterialStockEntityByReelId(reelId);
                            detailEntity.BatchBCJobStatus = 4;
                            detailEntity.BatchBCPostingStatus = 2;
                            detailEntity.EndTime = DateTime.Now;

                            ZollnerNGLog ngLogEntity = new ZollnerNGLog
                            {
                                Id = SnowFlakeSingle.Instance.NextId(),
                                NGBoxCode = "",
                                OutboundID = outOrderEntity.OutboundID,
                                OutOrderNo = outOrderEntity.OutOrderNo,
                                BatchBC = reelId,
                                SMTLine = string.Empty,
                                ErrorMsg = "过账失败",
                                Component_BC = string.Empty,
                                Qty = null,
                                BoxCode = boxNo,
                                CreateTime = DateTime.Now,
                                isDelete = false,
                                TowerNo = materialEntity.AreaCode,
                                inBox = true,
                            };

                            materialEntity.Status = 50;

                            //更新Zollner_InOutOrderDetail
                            this.dbContent.Ado.BeginTran();
                            this.DeleteAllRefNGLogByReelId(reelId);
                            bool insert_Flag = this.dbContent.Insertable<ZollnerNGLog>(ngLogEntity).ExecuteCommand() > 0;
                            AppendText($"更新 ZollnerNGLog【{insert_Flag}】", uiContext);
                            bool update_Flag = this.dbContent.Updateable<Zollner_InOutOrderDetail>(detailEntity).ExecuteCommand() > 0;
                            AppendText($"更新 Zollner_InOutOrderDetail【{update_Flag}】", uiContext);
                            bool update_Flag2 = this.dbContent.Updateable<Zollner_InOutOrder>(outOrderEntity).ExecuteCommand() > 0;
                            AppendText($"更新 Zollner_InOutOrder【{update_Flag}】", uiContext);
                            bool update_Flag1 = this.dbContent.Updateable<MaterialStock>(materialEntity).UpdateColumns(x => new { x.Status }).ExecuteCommand() > 0;
                            AppendText($"更新 MaterialStock【{update_Flag1}】", uiContext);

                            if (insert_Flag && update_Flag && update_Flag1)
                            {
                                this.dbContent.Ado.CommitTran();
                                AppendText($"事务更新成功", uiContext);
                            }
                            else
                            {
                                this.dbContent.Ado.RollbackTran();
                                AppendText($"事务更新失败", uiContext);
                            }

                            //设置出库单的任务状态
                            var findOurOrderDetailList = this.GetOutOrderDetailListByOutOrderNo(outOrderNo);
                            var updateOutOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                            updateOutOrderEntity.OutboundJobStatus = 3;
                            updateOutOrderEntity.UpdateTime = DateTime.Now;
                            updateOutOrderEntity.UpdateUserId = -1;
                            updateOutOrderEntity.UpdateUserName = "码垛机";
                            this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();

                            ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                                .Where(x => x.OutboundID.ToLower() == updateOutOrderEntity.OutboundID.ToLower())
                                                .Where(x => (x.IsDelete) == false)
                                                .OrderByDescending(x => x.CreateTime)
                                                .First();
                            if (soringWorkOrder != null)
                            {
                                soringWorkOrder.OutboundStatus = 5;
                                this.dbContent.Updateable<ZollnerOutboundForProduction>(soringWorkOrder).ExecuteCommand();
                            }

                        }


                        AppendText($"结束 更新平台NG箱内料盘数据", uiContext);
                    }


                    Thread.Sleep(50);

                    if (!AskPickerWork_Order)
                    {
                        break;
                    }

                    Thread.Sleep(50);

                    //判断当前箱子是否可以出箱
                    //只通过箱号唯一码来判断
                    var Response_QueryOperateDictate = this.QueryOperateDictate(boxNo);
                    if (Response_QueryOperateDictate.Status && (int)Response_QueryOperateDictate.Data == 1)
                    {
                        var boxEntity = this.GetBoxEntityByBoxNo(boxNo);
                        if (boxEntity != null)
                        {
                            boxEntity.isEmpty = true;
                            this.dbContent.Updateable<Box>(boxEntity).ExecuteCommand();

                            //移栽到3出口通道
                            AskBoxRoolToOutpu3_Order = true;
                            this.AskBoxRoolToOutpu3(null);
                            AskBoxRoolToOutpu3_Order = false;
                        }
                    }

                    Thread.Sleep(50);


                    AskPickerWork_Self = false;

                    if (!AskPickerWork_Order || !AskPickerWork_Self)
                    {
                        if (!AskPickerWork_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            AppendText($"结束执行 AskPickerWork", uiContext);
            return response;
        }

        private bool CheckIsCellFullInPLCInfo(int CellType, int CellNo)
        {
            bool flag = false;

            if (CellType == 4)
            {
                if (CellNo == 1)
                {
                    var Result_13318 = client.ReadCoil("13318", stationNumber);
                    if (Result_13318.IsSucceed
                        && Result_13318.Value
                        )
                    {
                        flag = true;
                    }
                }
                else if (CellNo == 2)
                {
                    var Result_13319 = client.ReadCoil("13319", stationNumber);
                    if (Result_13319.IsSucceed
                        && Result_13319.Value
                        )
                    {
                        flag = true;
                    }
                }
                else if (CellNo == 3)
                {
                    var Result_13320 = client.ReadCoil("13320", stationNumber);
                    if (Result_13320.IsSucceed
                        && Result_13320.Value
                        )
                    {
                        flag = true;
                    }
                }
                else if (CellNo == 4)
                {
                    var Result_13321 = client.ReadCoil("13321", stationNumber);
                    if (Result_13321.IsSucceed
                        && Result_13321.Value
                        )
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                var Result_13322 = client.ReadCoil("13322", stationNumber);
                var Result_13323 = client.ReadCoil("13323", stationNumber);
                var Result_13324 = client.ReadCoil("13324", stationNumber);
                var Result_13325 = client.ReadCoil("13325", stationNumber);
                if (Result_13322.IsSucceed
                    && Result_13322.Value
                    )
                {
                    flag = true;
                }
                else if (Result_13323.IsSucceed
                    && Result_13323.Value
                    )
                {
                    flag = true;
                }
                else
                {
                    if (
                        (Result_13324.IsSucceed && Result_13324.Value)
                        ||
                        (Result_13325.IsSucceed && Result_13325.Value)
                        )
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }


        #endregion

        #region Output3

        public bool CallBoxAgvAtOutput3_Order { get; set; } = false;
        /// <summary>
        /// 出口通道3呼叫AGV小车
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent CallBoxAgvAtOutput3(object para)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            string TaskCode = "";

            while (true && CallBoxAgvAtOutput3_Order)
            {
                Thread.Sleep(50);

                ///1
                //3通道允许出料【13588】【13788】
                var Result_13788 = client.ReadCoil("13788", stationNumber);
                if (Result_13788.IsSucceed
                    //&& (Result_13788.Value || !Result_13788.Value)
                    && (Result_13788.Value)
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"3通道允许上料信号【13788】{Result_13788.Value}", uiContext);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {
                        
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //扫码器2工作
                    string thisTempBoxNo = "";
                    this.GetScan2String(null);
                    var Response_GetScan2String = this.GetScan2String(null);
                    if (Response_GetScan2String.Status)
                    {
                        thisTempBoxNo = Response_GetScan2String.Data.ToString();
                    }
                    else
                    {
                        int retrytime = 0;
                        while (retrytime < 3 && !Response_GetScan2String.Status)
                        {
                            Response_GetScan2String = this.GetScan2String(null);
                            retrytime = retrytime + 1;
                            Thread.Sleep(50);
                        }
                        if (Response_GetScan2String.Status)
                        {
                            thisTempBoxNo = Response_GetScan2String.Data.ToString();
                        }
                    }

                    if (string.IsNullOrEmpty(thisTempBoxNo))
                    {
                        continue;
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //2
                    //呼叫AGV小车过来接收箱子
                    Thread.Sleep(50);

                    TaskCode = this.CallWebApi_CallAgvBoxAtOutput3(thisTempBoxNo);
                    TaskCode = TaskCode.Replace("\"", "");

                    if (string.IsNullOrEmpty(TaskCode) || TaskCode.ToUpper().IndexOf("ZNCS") == -1)
                    {
                        AppendText($"3通道 呼叫AGV小车过来接收箱子 获取TaskCode失败 【{TaskCode}】 请检查AGV任务清单", uiContext);

                        var Result_13738 = client.Write("13738", true, stationNumber);

                        Thread.Sleep(5000);

                        continue;
                    }
                    else
                    {
                        AppendText($"3通道呼叫AGV小车接收箱子 获取TaskCode【{TaskCode}】", uiContext);

                        var Result_13738 = client.Write("13738", false, stationNumber);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //3
                    //AGV到达3通道位置
                    Thread.Sleep(50);
                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        Thread.Sleep(50);

                        bool arriveOutputSide = this.CallWebApi_ArriveOutputSide(TaskCode) == "1";
                        if (arriveOutputSide)
                        {
                            AppendText("3通道AGV小车已到位", uiContext);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //4
                    //3通道AGV小车到位信号【14588】
                    Thread.Sleep(50);

                    Result Result_14588;
                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        Result_14588 = client.Write("14588", true, stationNumber);
                        if (Result_14588.IsSucceed)
                        {
                            AppendText("3通道AGV小车到位信号【14588】", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);


                    //5
                    //通知要求AGV转动取箱
                    Thread.Sleep(50);

                    if (true && CallBoxAgvAtOutput3_Order)
                    {
                        AppendText("要求3通道AGV起转", uiContext);
                        var resultStr_CallWebApi_CallAgvStartOutputRoll = this.CallWebApi_CallAgvStartOutputRoll(TaskCode);
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //6
                    //AGV上报已调整完，已开始工作
                    Thread.Sleep(50);

                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        bool arriveInputSide = this.CallWebApi_AdjustOutputSide(TaskCode) == "1";
                        if (arriveInputSide)
                        {
                            AppendText("检测到 3通道AGV小车已准备OK的上报消息", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //7
                    //3通道起转等待起转命令工作信号【13589】
                    Thread.Sleep(50);

                    AppendText("开始 3通道起转等待起转命令工作信号【13589】", uiContext);
                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        var Result_13589 = client.ReadCoil("13589", stationNumber);
                        if (Result_13589.IsSucceed && Result_13589.Value)
                        {
                            AppendText($"[读取 13589 成功]", uiContext);
                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14588 = client.Write("14588", false, stationNumber);
                            Thread.Sleep(50);

                            break;
                        }
                        else
                        {
                            Result_14588 = client.Write("14588", true, stationNumber);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //8
                    //要求3通道起转信号【14589】
                    Thread.Sleep(50);

                    //要求AGV转动
                    //if (true && CallBoxAgvAtOutpu3_Order && CallBoxAgvAtOutpu3_Self)
                    //{
                    //    AppendText("要求3通道AGV起转", uiContext);
                    //    var resultStr_CallWebApi_CallAgvStartOutputRoll = this.CallWebApi_CallAgvStartOutputRoll(TaskCode);
                    //}

                    Thread.Sleep(50);

                    Result Result_14589;
                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        Result_14589 = client.Write("14589", true, stationNumber);
                        if (Result_14589.IsSucceed)
                        {
                            AppendText($"[写入 14589 成功]", uiContext);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    AppendText("结束 要求3通道起转信号【14589】", uiContext);

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //9
                    //3通道出料出箱OK【13590】
                    //3通道出料出箱超时报警【13591】
                    Thread.Sleep(50);

                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        var Result_13590 = client.ReadCoil("13590", stationNumber);
                        var Result_13591 = client.ReadCoil("13591", stationNumber);
                        if (Result_13590.IsSucceed && Result_13590.Value)
                        {
                            //Success
                            response = response.OK("3通道出料出箱OK!");

                            AppendText($"[读取 13590 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14589 = client.Write("14589", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteOutputWork(TaskCode);

                            //CallBoxAgvAtOutpu3_Self = false;

                            break;
                        }
                        else if (Result_13591.IsSucceed && Result_13591.Value)
                        {
                            //Raise Error
                            response = response.Error("3通道出料出箱超时报警!");

                            AppendText($"[读取 13591 成功]", uiContext);

                            //擦除刚才前一轮写入的信号
                            Thread.Sleep(50);
                            Result_14589 = client.Write("14589", false, stationNumber);
                            Thread.Sleep(50);

                            //TODO
                            //AGV停止并移走
                            AppendText("AGV停止并移走", uiContext);
                            this.CallWebApi_CompleteOutputWork(TaskCode);

                            //CallBoxAgvAtOutpu3_Self = false;

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //10
                    //3通道AGV小车到位货架信号
                    Thread.Sleep(50);

                    while (true && CallBoxAgvAtOutput3_Order)
                    {
                        bool arriveOutputSide = this.CallWebApi_ArriveInputSide(TaskCode) == "1";
                        if (arriveOutputSide)
                        {
                            AppendText("3通道AGV小车已到位货架", uiContext);
                            break;
                        }
                        else
                        {
                            Thread.Sleep(200);
                            continue;
                        }
                    }

                    Thread.Sleep(50);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //11
                    //要求AGV转动-货架处放箱子
                    Thread.Sleep(50);

                    if (true && CallBoxAgvAtOutput3_Order)
                    {
                        AppendText("要求3通道AGV货架处放箱子", uiContext);
                        var resultStr_CallWebApi_CallAgvStartInputRoll = this.CallWebApi_CallAgvStartInputRoll(TaskCode);
                    }

                    Thread.Sleep(50);


                    AppendText("结束 3通道出料OK【13590】", uiContext);

                    Thread.Sleep(50);
                    //退出任务
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        if (!CallBoxAgvAtOutput3_Order)
                        {
                            response = response.Error("取消3通道AGV任务!");
                        }

                        break;
                    }
                    else
                    {

                    }

                    Thread.Sleep(50);

                    //Thread.Sleep(10000);
                    Thread.Sleep(1000);

                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(1000);
                }


                if (!CallBoxAgvAtOutput3_Order)
                {
                    if (!CallBoxAgvAtOutput3_Order)
                    {
                        response = response.Error("取消3通道AGV任务!");
                    }

                    break;
                }
                else
                {
                    continue;
                }


            }

            AppendText("结束 3通道AGV任务", uiContext);
            return response;
        }

        public bool TakeScanAtOutput3_Order { get; set; } = false;
        /// <summary>
        /// 出口通道3扫码
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public ResponseContent TakeScanAtOutput3(object para)
        {
            ResponseContent response = new ResponseContent();

            string thisTempBoxNo = string.Empty;

            SynchronizationContext uiContext = this.uiContextMain;

            bool TakeScanAtOutput3_Self = true;

            while (true && TakeScanAtOutput3_Order && TakeScanAtOutput3_Self)
            {
                Thread.Sleep(50);

                ///1
                //扫码触发信号【13788】
                var Result_13788 = client.ReadCoil("13788", stationNumber);
                if (Result_13788.IsSucceed
                    && Result_13788.Value
                    )
                {
                    Thread.Sleep(50);

                    AppendText($"[读取【13788】成功：{Result_13788.Value}", uiContext);

                    //TODO 扫码 获取箱单编号
                    thisTempBoxNo = Guid.NewGuid().ToString();
                    AppendText($"[扫码 成功]：{thisTempBoxNo}\t\t", uiContext);
                    Thread.Sleep(50);

                    //TODO 访问数据库，获取箱类型
                    int boxType = new Random(0).Next(3);
                    ///2
                    //扫码完成【14788】
                    Thread.Sleep(50);

                    Result Result_14788;
                    while (true && TakeScanAtOutput3_Order && TakeScanAtOutput3_Self)
                    {
                        Result_14788 = client.Write("14788", true, stationNumber);
                        if (Result_14788.IsSucceed)
                        {
                            AppendText($"写入【14788】成功", uiContext);

                            response = response.OK("Success", thisTempBoxNo);

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Thread.Sleep(50);



                    if (!TakeScanAtOutput3_Order || !TakeScanAtOutput3_Self)
                    {
                        if (!TakeScanAtOutput3_Order)
                        {
                            response = response.Error("取消任务!");
                        }

                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }


            return response;
        }

        #endregion

        #endregion Process

        #region mes transfer batch

        public ResponseContent TransferBatch(string reelId, string boxNo)
        {
            ResponseContent res = new ResponseContent();

            //return res.OK();

            SynchronizationContext uiContext = this.uiContextMain;

            Box boxEntity = this.GetBoxEntityByBoxNo(boxNo);

            var resourceSetting = Properties.Settings.Default;
            string url = $"{resourceSetting.TransferBatchAddress}";
            url = url + reelId + "/" + boxEntity.RelevanceCode;
            var request = new RestRequest(url, Method.Post);
            //this.zollner_session_id = "07848846-7033-4f31-98d4-a0e1f66aa563";
            //request.AddHeader("Authorization", zollner_session_id);
            //request.AddHeader("Accept", "application/json");
            //var postBody = new { BatchBC = reelId, targetLocationBC = boxEntity.RelevanceCode, TransferType = "internal" };
            //request.AddJsonBody(postBody);
            
            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            var updateOutOrderEntity = this.GetOutOrderEntityByReelId(reelId);
            var updateOutOrderDetailEntity = this.GetInOutOrderDetailEntityByReelId(updateOutOrderEntity.OutOrderNo, reelId);

            if (response.IsSuccessStatusCode)
            {
                res = res.OK($"物料【{reelId}】Mes过账成功, {response.Content}");

                if (updateOutOrderEntity != null)
                {
                    if (updateOutOrderDetailEntity != null)
                    {
                        updateOutOrderDetailEntity.BatchBCPostingStatus = 1;
                        this.dbContent.Updateable<Zollner_InOutOrderDetail>(updateOutOrderDetailEntity).ExecuteCommand();
                    }
                }
                updateOutOrderEntity.UpdateTime = DateTime.Now;
                updateOutOrderEntity.UpdateUserId = -1;
                updateOutOrderEntity.UpdateUserName = "码垛机";
                this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();

                var materialEntity = this.GetMaterialStockEntityByReelId(reelId);
                materialEntity.Status = 60;
                this.dbContent.Updateable<MaterialStock>(materialEntity).UpdateColumns(x => new { x.Status }).ExecuteCommand();
            }
            else
            {
                var findSortingEntity = this.dbContent.Queryable<ZollnerOutboundForProduction>().First(x => x.OutboundID == updateOutOrderDetailEntity.OutboundID);

                ZollnerNGLog ngLogEntity = new ZollnerNGLog
                {
                    Id = SnowFlakeSingle.Instance.NextId(),
                    NGBoxCode = "830100001734",
                    OutboundID = updateOutOrderEntity.OutboundID,
                    OutOrderNo = updateOutOrderDetailEntity.OutOrderNo,
                    BatchBC = updateOutOrderDetailEntity.BatchBC,
                    SMTLine = findSortingEntity?.SMTLine,
                    ErrorMsg = "过账失败",
                    Component_BC = string.Empty,
                    Qty = null,
                    BoxCode = boxNo,
                    CreateTime = DateTime.Now,
                    isDelete = false,
                    TowerNo = string.Empty,
                    inBox = true,
                };
                this.DeleteAllRefNGLogByReelId(reelId);
                bool ngFlag = this.dbContent.Insertable<ZollnerNGLog>(ngLogEntity).ExecuteCommand() > 0;
                if (ngFlag)
                {
                    AppendText($"NG日志插入成功", uiContext);
                }
                else
                {
                    AppendText($"NG日志插入失败", uiContext);
                }


                res = res.Error($"物料【{reelId}】Mes过账失败, {response.Content}");

                if (updateOutOrderEntity != null)
                {
                    if (updateOutOrderDetailEntity != null)
                    {
                        updateOutOrderDetailEntity.BatchBCPostingStatus = 1;
                        this.dbContent.Updateable<Zollner_InOutOrderDetail>(updateOutOrderDetailEntity).ExecuteCommand();
                    }
                }
                updateOutOrderEntity.OutboundJobStatus = 3;
                updateOutOrderEntity.UpdateTime = DateTime.Now;
                updateOutOrderEntity.UpdateUserId = -1;
                updateOutOrderEntity.UpdateUserName = "码垛机";
                this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();
            }                                                                                                                                                                                                                                                                                                                                                 
            return res;
        }

        public ResponseContent BoxMove(string boxNo, string targetLocation)
        {

            ResponseContent res = new ResponseContent();

            //return res.OK();

            SynchronizationContext uiContext = this.uiContextMain;

            Box boxEntity = this.GetBoxEntityByBoxNo(boxNo);

            var resourceSetting = Properties.Settings.Default;
            string url = $"{resourceSetting.BoxMoveAddress}";
            url = url + boxNo + "/" + targetLocation;
            var request = new RestRequest(url, Method.Post);
            //this.zollner_session_id = "07848846-7033-4f31-98d4-a0e1f66aa563";
            //request.AddHeader("Authorization", zollner_session_id);
            //request.AddHeader("Accept", "application/json");
            //var postBody = new { BatchBC = reelId, targetLocationBC = boxEntity.RelevanceCode, TransferType = "internal" };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                res = res.OK($"箱子【{boxNo}】Mes箱转移成功, {response.Content}");
            }
            else
            {
                res = res.OK($"箱子【{boxNo}】Mes箱转移失败, {response.Content}");
            }
            return res;
        }


        public string self_session_id { get; set; } = "";
        public string zollner_session_id { get; set; } = "";
        public ResponseContent MesLogin(string username, string password)
        {
            ResponseContent res = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            var resourceSetting = Properties.Settings.Default;

            //登录机器自身的session
            //string url = $"{resourceSetting.IWMSAddress}PassionStore/WCF_ApiControl/MesLoginWithUpperSessionId?username={username}&password={password}";
            ////string url = $"{resourceSetting.IWMSAddress}PassionStore/WCF_ApiControl/CheckMesLogin?username={username}&password={password}";
            //AppendText($"登录地址：{url}", uiContext);
            //var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Accept", "application/json");
            //RestClient client = new RestClient(url);
            //RestResponse response = client.Execute(request);
            //if (response.IsSuccessStatusCode)
            //{
            //    AppendText($"登录成功,返回session_id：{response.Content}", uiContext);
            //    res = res.OK("Sucess", response.Content);
            //    this.self_session_id = response.Content.Replace("\"", "");
            //}
            //else
            //{
            //    AppendText($"登录失败,返回错误信息：{response.Content}", uiContext);
            //    this.self_session_id = string.Empty;
            //    res = res.Error(response.Content);
            //}
            //this.zollner_session_id = this.self_session_id;

            //登录机器过账的session
            //string url1 = $"{resourceSetting.IWMSAddress}PassionStore/WCF_ApiControl/MesLoginWithMachineSessionId";
            //AppendText($"登录地址：{url1}", uiContext);
            //var request1 = new RestRequest(url, Method.Post);
            //request1.AddHeader("Accept", "application/json");
            //RestClient client1 = new RestClient(url1);
            //RestResponse response1 = client.Execute(request1);
            //if (response1.IsSuccessStatusCode)
            //{
            //    AppendText($"登录成功,返回session_id：{response1.Content}", uiContext);
            //    res = res.OK("Sucess", response.Content);
            //    this.zollner_session_id = response.Content.Replace("\"", "");
            //}
            //else
            //{
            //    AppendText($"登录失败,返回错误信息：{response.Content}", uiContext);
            //    this.zollner_session_id = string.Empty;
            //    res = res.Error(response.Content);
            //}
            var findList = this.dbContent.Queryable<ZollnerMesSessionId>().Where(x => x.Type == 0 && x.IsDelete == false).ToList().ToList();
            if (findList.Count > 0)
            {
                this.zollner_session_id = findList[0].Session_Id;
            }

            AppendText($"登录成功,返回session_id：{this.zollner_session_id}", uiContext);


            return res;
        }

        #endregion

        #region database sqlsugar

        #region PK is ReelId

        /// <summary>
        /// 检查物料唯一码是否在平台系统中存在
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public bool CheckRealId(string ReelId)
        {
            return this.dbContent.Queryable<MaterialStock>().Any(x => x.ReelId.ToLower() == ReelId.ToLower());
        }

        /// <summary>
        /// 通过物料唯一码获取库存实体对象
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public MaterialStock GetMaterialStockEntityByReelId(string ReelId)
        {
            if (this.CheckRealId(ReelId))
            {
                return this.dbContent.Queryable<MaterialStock>()
                    .Where(x => x.ReelId.ToLower() == ReelId.ToLower() && (x.Status == 30 || x.Status == 50 || x.Status == 60 || x.Status == 70) && x.Deleted == false)
                    .OrderBy(x => x.Status)
                    .First();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过物料唯一码获取物料size
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public int GetMaterialSize(string ReelId)
        {
            int size = 0;
            MaterialStock material = this.GetMaterialStockEntityByReelId(ReelId);
            if (!material.Size.HasValue)
            {
                size = 7;
            }
            else
            {
                size = material.Size.Value;
            }
            if (size == 0)
            {
                size = 7;
            }

            return size;
        }

        /// <summary>
        /// 通过物料唯一码获取对应出库单实体
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public Zollner_InOutOrder GetOutOrderEntityByReelId(string ReelId)
        {
            var findList = this.dbContent.Queryable<Zollner_InOutOrderDetail>()
                .InnerJoin<Zollner_InOutOrder>((d, m) => d.OutOrderNo == m.OutOrderNo)
                .Where((d, m) => d.BatchBC.ToLower() == ReelId.ToLower() && (d.BatchBCJobStatus == 0 || d.BatchBCJobStatus == 1 || d.BatchBCJobStatus == 4 || d.BatchBCJobStatus == 5))
                .OrderByDescending((d, m) => m.CreateTime)
                .Select((d, m) => m)
                .Distinct()
                .ToList();
            if (findList.Count > 0)
            {
                return findList[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过物料唯一码获取对应出库单单据编号
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public string GetOutOrderNoByReelId(string ReelId)
        {
            ResponseContent response = new ResponseContent();
            var findEntity = this.GetOutOrderEntityByReelId(ReelId);
            if (findEntity == null)
            {
                return string.Empty;
            }
            else
            {
                return findEntity.OutOrderNo;
            }
        }

        /// <summary>
        /// 通过物料唯一码获取出库单编号Response
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public ResponseContent GetOutOrderNoResponseByReelId(string ReelId)
        {
            ResponseContent response = new ResponseContent();
            var findEntity = this.GetOutOrderEntityByReelId(ReelId);
            if (findEntity == null)
            {
                string errMsg = $"料盘:[{ReelId}]找不到对应的出库单!";
                response = response.Error(errMsg);
            }
            else
            {
                response = response.OK("Success", findEntity.OutOrderNo);
            }

            return response;
        }


        /// <summary>
        /// 通过物料唯一码获取对应已经放入的箱号明细实体
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public Boxdetail GetPutInBoxEntityByReelId(string ReelId)
        {
            var findList = this.dbContent.Queryable<Boxdetail>().Where(x=>x.BindReeid.ToLower() == ReelId.ToLower() && x.IsDelete == false).OrderByDescending(x=>x.CreateTime).ToList();
            if (findList.Count > 0)
            {
                return findList[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 通过物料唯一码获取对应已经放入的箱号
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public string GetPutInBoxNoByReelId(string ReelId)
        {
            var findEntity = this.GetPutInBoxEntityByReelId(ReelId);
            if (findEntity == null)
            {
                return string.Empty;
            }
            else
            {
                return findEntity.BoxCode;
            }
        }

        /// <summary>
        /// 通过物料唯一码获取对应已经放入的箱号Response
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public ResponseContent GetPutInBoxNoResponseByReelId(string ReelId)
        {
            ResponseContent response = new ResponseContent();

            var findEntity = this.GetPutInBoxEntityByReelId(ReelId);
            if (findEntity == null)
            {
                string errMsg = $"料盘:[{ReelId}]找不到对应的已装箱箱号!";
                response = response.Error(errMsg);
            }
            else
            {
                response = response.OK("Success", findEntity.BoxCode);
            }

            return response;
        }

        /// <summary>
        /// 通过物料唯一码获取对应需要的箱子
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public int GetBoxCellTypeByReelId(string ReelId)
        {
            if (string.IsNullOrEmpty(ReelId))
            {
                return 1;
            }
            else
            {
                if (this.CheckRealId(ReelId))
                {
                    int reel_size = this.GetMaterialSize(ReelId);
                    Zollner_InOutOrder outOrderEntity = this.GetOutOrderEntityByReelId(ReelId);

                    string OutboundID = outOrderEntity.OutboundID;
                    ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                        .Where(x => x.OutboundID.ToLower() == OutboundID.ToLower())
                        .Where(x => (x.IsDelete) == false)
                        .OrderByDescending(x => x.CreateTime)
                        .First();

                    bool isMix = false;
                    if (soringWorkOrder != null)
                    {
                        if (soringWorkOrder.DiffSizeInOneBox.HasValue && soringWorkOrder.DiffSizeInOneBox.Value)
                        {
                            isMix = true;
                        }
                    }

                    int callBoxByCellType = 1;
                    if (reel_size == 7 && isMix)
                    {
                        callBoxByCellType = 1;
                    }
                    else if (reel_size == 7 && !isMix)
                    {
                        callBoxByCellType = 4;
                    }
                    else if (reel_size == 13 && isMix)
                    {
                        callBoxByCellType = 1;
                    }
                    else if (reel_size == 13 && !isMix)
                    {
                        callBoxByCellType = 1;
                    }

                    return callBoxByCellType;

                }
                else
                {
                    return 1;
                }
            }

        }

        #endregion

        #region PK is BoxNo

        /// <summary>
        /// 检查箱号编号是否在平台系统中存在
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public bool CheckBoxNo(string BoxNo)
        {
            if (string.IsNullOrEmpty(BoxNo))
            {
                return false;
            }

            return this.dbContent.Queryable<Box>().Any(x => x.Code.ToLower() == BoxNo.ToLower()
                                                            && x.IsDelete == false
                                                            && x.AreaType == "20"
                                                            );
        }

        /// <summary>
        /// 检查是否是空箱
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public bool IsEmptyBox(string BoxNo)
        {
            Box boxEntity = this.GetBoxEntityByBoxNo(BoxNo);

            return this.IsEmptyBox(boxEntity);
        }

        /// <summary>
        /// 检查是否是空箱
        /// </summary>
        /// <param name="boxEntity"></param>
        /// <returns></returns>
        public bool IsEmptyBox(Box boxEntity)
        {
            bool flag = false;

            if (!(boxEntity.isEmpty??false))
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// 这个空箱是否可用
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="OurorderNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public bool IsEmptyBoxUseFull(string BoxNo, string OurorderNo, string ReelId)
        {
            Box boxEntity = this.GetBoxEntityByBoxNo(BoxNo);

            return this.IsEmptyBoxUseFull(boxEntity, OurorderNo, ReelId);
        }

        /// <summary>
        /// 这个空箱是否可用
        /// </summary>
        /// <param name="boxEntity"></param>
        /// <param name="OurorderNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public bool IsEmptyBoxUseFull(Box boxEntity, string OurorderNo, string ReelId)
        {
            bool flag = false;

            MaterialStock material = this.GetMaterialStockEntityByReelId(ReelId);
            int reel_size = this.GetMaterialSize(ReelId);

            Zollner_InOutOrder outorder = this.GetOutOrderEntityByReelId(ReelId);
            string OutboundID = outorder.OutboundID;
            ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                .Where(x => x.OutboundID.ToLower() == OutboundID.ToLower())
                .Where(x => (x.IsDelete) == false)
                .OrderByDescending(x => x.CreateTime)
                .First();

            bool isMix = false;
            if (soringWorkOrder != null)
            {
                if (soringWorkOrder.DiffSizeInOneBox.HasValue && soringWorkOrder.DiffSizeInOneBox.Value)
                {
                    isMix = true;
                }
            }


            int subscriberBoxSize = reel_size;
            if (isMix)
            {
                subscriberBoxSize = 13;
            }

            int actualBoxSize = 0;
            if (boxEntity.CellType.HasValue && boxEntity.CellType.Value == 4)
            {
                actualBoxSize = 7;
            }
            else
            {
                actualBoxSize = 13;
            }


            if (subscriberBoxSize == actualBoxSize)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// 这个非空箱是否可以用
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="OurorderNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public bool IsUnEmptyBoxUseFull(string BoxNo, string OurorderNo, string ReelId)
        {
            Box boxEntity = this.GetBoxEntityByBoxNo(BoxNo);

            return this.IsUnEmptyBoxUseFull(boxEntity, OurorderNo, ReelId);
        }

        /// <summary>
        /// 这个非空箱是否可以用
        /// </summary>
        /// <param name="boxEntity"></param>
        /// <param name="OurorderNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public bool IsUnEmptyBoxUseFull(Box boxEntity, string OurorderNo, string ReelId)
        {
            bool flag = false;
            if (boxEntity.InOutOrder.ToLower() == OurorderNo.ToLower())
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            if (flag == true)
            {
                flag = this.IsEmptyBoxUseFull(boxEntity, OurorderNo, ReelId);
                if (flag)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }

            return flag;
        }


        /// <summary>
        /// 通过箱号获取箱实体
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public Box GetBoxEntityByBoxNo(string BoxNo)
        {
            var findList = this.dbContent.Queryable<Box>()
                .Where(x => x.Code.ToLower() == BoxNo.ToLower())
                .Where(x => x.IsDelete == false)
                .Where(x => x.AreaType == "20")
                .ToList();

            if (findList.Count > 0)
            {
                return findList[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 通过物料唯一码获取对应需要的箱子
        /// </summary>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public int GetBoxCellTypeByBoxNo(string BoxNo)
        {
            if (string.IsNullOrEmpty(BoxNo))
            {
                return 1;
            }
            else
            {
                if (this.CheckBoxNo(BoxNo))
                {
                    Box findBoxEntity = this.GetBoxEntityByBoxNo(BoxNo);

                    int callBoxByCellType = 1;
                    if (findBoxEntity.CellType.HasValue)
                    {
                        if (findBoxEntity.CellType.Value == 4)
                        {
                            callBoxByCellType = 4;
                        }
                    }

                    return callBoxByCellType;
                }
                else
                {
                    return 1;
                }
            }

        }


        /// <summary>
        /// 通过箱号获取该箱号已装入箱明细实体集合
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public List<Boxdetail> GetBoxDetailListByBoxNo(string BoxNo)
        {
            var findList = this.dbContent.Queryable<Boxdetail>()
            .Where(x => x.BoxCode.ToLower() == BoxNo.ToLower())
            .Where(x => x.IsDelete == false)
            .OrderBy(x => x.BoxCode)
            .ToList();

            return findList;
        }

        /// <summary>
        /// 通过箱号获取已装入箱的料盘唯一码集合
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public List<string> GetReelIdListInBoxDetailListByBoxNo(string BoxNo)
        {
            var findList = this.GetBoxDetailListByBoxNo(BoxNo).Select(s => s.BindReeid).ToList();

            return findList;
        }

        /// <summary>
        /// 料盘是否已存在于箱子中
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="ReelId"></param>
        public bool IsBoxDetailExistInBox(string BoxNo, string ReelId)
        {
            bool flag = false;

            List<Boxdetail> detailInBox_List = this.GetBoxDetailListByBoxNo(BoxNo);

            if (detailInBox_List.FindAll(x=>x.BindReeid == ReelId).Count > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// 获取箱内的已经装箱的料盘明细
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public Boxdetail GetBoxDetailExistInBox(string BoxNo, string ReelId)
        {
            Boxdetail findEntity = null;

            List<Boxdetail> detailInBox_List = this.GetBoxDetailListByBoxNo(BoxNo);

            if (detailInBox_List.FindAll(x => x.BindReeid == ReelId).Count > 0)
            {
                findEntity = detailInBox_List.FindAll(x => x.BindReeid == ReelId)[0];
            }
            else
            {
                findEntity = null;
            }

            return findEntity;

        }

        /// <summary>
        /// 通过箱号获取已装入箱的料盘唯一码集合Response
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public ResponseContent GetReelIdListInBoxDetailListResponseByBoxNo(string BoxNo)
        {
            ResponseContent response = new ResponseContent();

            var findList = this.GetReelIdListInBoxDetailListByBoxNo(BoxNo);
            response = response.OK("Sucess", findList);

            return response;
        }

        /// <summary>
        /// 通过箱号列表获取该箱号列表下已装入箱明细实体集合
        /// </summary>
        /// <param name="BoxNoList"></param>
        /// <returns></returns>
        public List<Boxdetail> GetBoxDetailListByBoxNoList(List<string> BoxNoList)
        {
            var findList = this.dbContent.Queryable<Boxdetail>()
            .Where(x => BoxNoList.Select(s=>s.ToLower()).ToList().Contains(x.BoxCode.ToLower()))
            .Where(x => x.IsDelete == false)
            .OrderBy(x => x.BoxCode)
            .ToList();

            return findList;
        }

        /// <summary>
        /// 通过箱号列表获取已装入箱的料盘唯一码集合
        /// </summary>
        /// <param name="BoxNoList"></param>
        /// <returns></returns>
        public List<string> GetReelIdListInBoxDetailListByBoxNoList(List<string> BoxNoList)
        {
            var findList = this.GetBoxDetailListByBoxNoList(BoxNoList).Select(s => s.BindReeid).ToList();

            return findList;
        }

        /// <summary>
        /// 通过箱号列表获取已装入箱的料盘唯一码集合Response
        /// </summary>
        /// <param name="BoxNoList"></param>
        /// <returns></returns>
        public ResponseContent GetReelIdListInBoxDetailListResponseByBoxNoList(List<string> BoxNoList)
        {
            ResponseContent response = new ResponseContent();

            var findList = this.GetReelIdListInBoxDetailListByBoxNoList(BoxNoList);
            response = response.OK("Sucess", findList);

            return response;
        }

        /// <summary>
        /// 通过箱号编号获取箱子对应的出库单编号
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public string GetOutOrderNoByBoxNo(string BoxNo)
        {
            var findEntity = this.GetBoxEntityByBoxNo(BoxNo);
            if (findEntity == null)
            {
                return string.Empty;
            }
            else
            {
                return !string.IsNullOrEmpty(findEntity.InOutOrder) ? findEntity.InOutOrder : string.Empty;
            }
        }

        /// <summary>
        /// 通过箱号编号获取箱子对应的出库单编号Response
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public ResponseContent GetOutOrderNoResponseByBoxNo(string BoxNo)
        {
            ResponseContent response = new ResponseContent();
            var findEntity = this.GetBoxEntityByBoxNo(BoxNo);
            if (findEntity == null)
            {
                string errMsg = $"箱号:[{BoxNo}]找不到对应的箱子记录!";
                response = response.Error(errMsg);
            }
            else
            {
                response = response.OK("Success", !string.IsNullOrEmpty(findEntity.InOutOrder)? findEntity.InOutOrder : string.Empty);
            }

            return response;
        }

        #endregion

        #region PK is OutOrderNo

        /// <summary>
        /// 检查出库单据编号是否在平台系统中存在
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public bool CheckOutOrderNo(string OutOrderNo)
        {
            return this.dbContent.Queryable<Zollner_InOutOrder>().Any(x => x.OutOrderNo.ToLower() == OutOrderNo.ToLower()
                                                && x.IsDelete == false
                                                );
        }

        /// <summary>
        /// 通过出库单单据编号获取出库单实体
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public Zollner_InOutOrder GetOutOrderEntityByOutOrderNo(string OutOrderNo)
        {
            var findList = this.dbContent.Queryable<Zollner_InOutOrder>().Where(x => x.OutOrderNo.ToLower() == OutOrderNo.ToLower() && x.IsDelete == false).ToList();
            if (findList.Count == 0)
            {
                return null;
            }
            else
            {
                return findList[0];
            }
        }

        /// <summary>
        /// 通过出库单单据编号和物料唯一码获取出库单内物料明细
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public Zollner_InOutOrderDetail GetInOutOrderDetailEntityByReelId(string OutOrderNo, string ReelId)
        {
            var findEntity = this.dbContent.Queryable<Zollner_InOutOrderDetail>()
                .FirstAsync(x => x.OutOrderNo == OutOrderNo && x.BatchBC.ToLower() == ReelId.ToLower()).Result;

            return findEntity;
        }
        /// <summary>
        /// 通过出库单编号获取出库任务明细对象集合
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public List<Zollner_InOutOrderDetail> GetOutOrderDetailListByOutOrderNo(string OutOrderNo)
        {
            var findList = this.dbContent.Queryable<Zollner_InOutOrderDetail>()
                .Where(x => x.OutOrderNo.ToLower() == OutOrderNo.ToLower())
                .OrderBy(x => x.BatchBC)
                .ToList();

            return findList;
        }

        /// <summary>
        /// 通过出库单编号获取出库任务明细中料号唯一码的列表
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public List<string> GetRealIdListInOutOrderDetailListByOutOrderNo(string OutOrderNo)
        {
            var findList = this.GetOutOrderDetailListByOutOrderNo(OutOrderNo).Select(x => x.BatchBC).ToList();

            return findList;
        }

        /// <summary>
        /// 通过出库单编号获取出库任务明细中料号唯一码的列表Response
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public ResponseContent GetRealIdListInOutOrderDetailListResponseByOutOrderNo(string OutOrderNo)
        {
            ResponseContent response = new ResponseContent();

            var findList = this.GetRealIdListInOutOrderDetailListByOutOrderNo(OutOrderNo);
            response = response.OK("Sucess", findList);

            return response;
        }

        /// <summary>
        /// 通过出库单编号获取已关联的箱子对象集合
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public List<Box> GetBoxEntityListByOutOrderNo(string OutOrderNo)
        {
            var findList = this.dbContent.Queryable<Box>()
                            .Where(x => x.InOutOrder.ToLower() == OutOrderNo.ToLower())
                            .Where(x => x.IsDelete == false)
                            .Where(x => x.AreaType == "20")
                            .OrderBy(x => x.Code)
                            .ToList();

            return findList;
        }

        /// <summary>
        /// 通过出库单编号获取已关联的箱号编号集合
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public List<string> GetBoxNoListByOutOrderNo(string OutOrderNo)
        {
            return this.GetBoxEntityListByOutOrderNo(OutOrderNo).Select(x=>x.Code).ToList();
        }

        /// <summary>
        /// 通过出库单编号获取已关联的箱号编号集合Response
        /// </summary>
        /// <param name="OutOrderNo"></param>
        /// <returns></returns>
        public ResponseContent GetBoxNoListResponseByOutOrderNo(string OutOrderNo)
        {
            ResponseContent response = new ResponseContent();
            response = response.OK("Sucess", this.GetBoxNoListByOutOrderNo(OutOrderNo));
            return response;
        }

        #endregion

        #region zollner nglog

        public void DeleteAllRefNGLogByReelId(string reelId)
        {
            var ngList = this.dbContent.Queryable<ZollnerNGLog>().Where((x => x.BatchBC == reelId && (x.isDelete.HasValue ? x.isDelete : false) == false)).ToList();
            if (ngList.Count > 0)
            {
                ngList.ForEach(f => { f.isDelete = true; });
                this.dbContent.Updateable<ZollnerNGLog>(ngList).ExecuteCommand();
            }
        }

        #endregion

        #endregion

        #region 硬件识别,扫码仪,照相机




        #endregion

        #region 操作台命令反馈

        /// <summary>
        /// 仅传入箱子箱号
        /// 说明料等待区域没有料呢【这也并非正确，正确来说，是此时仅需要判断一个参数[箱子]就够了，不需要更多参数】
        /// 所以处理只有两个选择 1. 出箱 0. 停留(交给后面的 QueryOperateDictate(string BoxNo, string ReelId) 去判断)
        /// 1. 出箱
        /// A. 箱号不存在，B.箱号对应的出库单的明细已经全部装箱完成
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <returns></returns>
        public ResponseContent QueryOperateDictate(string BoxNo)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool result_CheckBoxNo = this.CheckBoxNo(BoxNo);
            if (result_CheckBoxNo)
            {
                var BoxEntity = this.GetBoxEntityByBoxNo(BoxNo);
                //这是空箱 - 停留,(交给后续更多参数方法[带上料唯一码]来判断箱子是否可用)
                if ((BoxEntity.isEmpty.HasValue && BoxEntity.isEmpty.Value) && string.IsNullOrEmpty(BoxEntity.InOutOrder))
                {
                    response = response.OK("空箱停留", 0);
                    AppendText($"空箱停留", uiContext);
                }
                else
                {
                    //仅当箱子对应的出库单，这个出库单的明细都在 boxDetail中了，表示都已经装箱完成了，那就可以 出箱
                    //获取箱号绑定的出库单编号
                    var outOrderNo = this.GetOutOrderNoByBoxNo(BoxNo);
                    //获取出库单下所有物料集合
                    List<string> reelIdListInoutOrderNo = new List<string>();
                    List<Zollner_InOutOrderDetail> inoutOrderDetailList = new List<Zollner_InOutOrderDetail>();
                    if (!string.IsNullOrEmpty(outOrderNo))
                    {
                        reelIdListInoutOrderNo = this.GetRealIdListInOutOrderDetailListByOutOrderNo(outOrderNo);
                        inoutOrderDetailList = this.GetOutOrderDetailListByOutOrderNo(outOrderNo);
                    }
                    //获取出库单下所有已经绑定的箱子
                    List<string> boxNoList = new List<string>();
                    if (!string.IsNullOrEmpty(outOrderNo))
                    {
                        boxNoList = this.GetBoxNoListByOutOrderNo(outOrderNo);
                    }
                    //获取箱号集合内所有已入箱的物料唯一码集合
                    List<string> reelIdListInBoxNoList = new List<string>();
                    if (!string.IsNullOrEmpty(outOrderNo))
                    {
                        reelIdListInBoxNoList = this.GetReelIdListInBoxDetailListByBoxNoList(boxNoList);
                    }
                    //获取这个箱号内所有已入箱的物料唯一码集合
                    List<string> reelIdListInBoxNo = new List<string>();
                    if (!string.IsNullOrEmpty(outOrderNo))
                    {
                        reelIdListInBoxNo = this.GetReelIdListInBoxDetailListByBoxNo(BoxNo);
                    }
                    //获取设定
                    var resourceSetting = Properties.Settings.Default; //设定超过预期

                    //这一段代码仅做拖底支持
                    if (
                        reelIdListInoutOrderNo.Count > 0
                        &&
                        reelIdListInBoxNoList.Count > 0
                        &&
                        reelIdListInoutOrderNo.Count == reelIdListInBoxNoList.Count
                        &&
                        reelIdListInoutOrderNo.FindAll(x=> !reelIdListInBoxNoList.Contains(x)).Count == 0
                        &&
                        reelIdListInBoxNoList.FindAll(x => !reelIdListInoutOrderNo.Contains(x)).Count == 0
                        )
                    {
                        response = response.OK($"出库单【{outOrderNo}】已完成装箱", 1);
                        AppendText($"出库单【{outOrderNo}】已完成装箱", uiContext);
                    }
                    else if (reelIdListInBoxNo.Count > 0 && BoxEntity.CellType == 4 && reelIdListInBoxNo.Count == resourceSetting.Box7CellMaxNum * 4) //7寸的箱子依照装料盘数设定已经装满
                    {
                        response = response.OK($"7寸箱【{BoxNo}】已完成装箱", 1);
                        AppendText($"7寸箱【{BoxNo}】已完成装箱", uiContext);
                    }
                    else if (reelIdListInBoxNo.Count > 0 && BoxEntity.CellType == 1 && reelIdListInBoxNo.Count == resourceSetting.Box13CellMaxNum * 1) //13寸的箱子依照装料盘数设定已经装满
                    {
                        response = response.OK($"13寸箱【{BoxNo}】已完成装箱", 1);
                        AppendText($"13寸箱【{BoxNo}】已完成装箱", uiContext);
                    }
                    else
                    {
                        response = response.OK($"出库单【{outOrderNo}】仍有料，箱未满箱", 0);
                        AppendText($"出库单【{outOrderNo}】仍有料,箱未满箱", uiContext);
					}


                    //通过PLC的溢出检测来判断
                    bool flag_CheckIsCellFullInPLCInfo = false;
                    if (BoxEntity.CellType == 4)
                    {
                        flag_CheckIsCellFullInPLCInfo = this.CheckIsCellFullInPLCInfo(4, 4);
                        if (flag_CheckIsCellFullInPLCInfo)
                        {
                            response = response.OK($"7寸箱【{BoxNo}】已完成装箱", 1);
                            AppendText($"7寸箱【{BoxNo}】已完成装箱", uiContext);
                        }
                        else
                        {
                            response = response.OK($"出库单【{outOrderNo}】仍有料,7寸箱【{BoxNo}】未满箱", 0);
                            AppendText($"出库单【{outOrderNo}】仍有料,7寸箱【{BoxNo}】未满箱", uiContext);
                        }
                    }
                    else
                    {
                        flag_CheckIsCellFullInPLCInfo = this.CheckIsCellFullInPLCInfo(1, 1);
                        if (flag_CheckIsCellFullInPLCInfo)
                        {
                            response = response.OK($"13寸箱【{BoxNo}】已完成装箱", 1);
                            AppendText($"13寸箱【{BoxNo}】已完成装箱", uiContext);
                        }
                        else
                        {
                            response = response.OK($"出库单【{outOrderNo}】仍有料,13寸箱【{BoxNo}】未满箱", 0);
                            AppendText($"出库单【{outOrderNo}】仍有料,13寸箱【{BoxNo}】未满箱", uiContext);
                        }
                    }


                    //处理数据,判断下是否已经全部完成
                    if (inoutOrderDetailList.FindAll(x => (!x.BatchBCJobStatus.HasValue || (x.BatchBCJobStatus.HasValue && (x.BatchBCJobStatus.Value != 2 && x.BatchBCJobStatus.Value != 3 && x.BatchBCJobStatus.Value != 5)))).Count > 0)
                    {
                        //不做出库单主表的操作
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(outOrderNo))
                        {
                            var updateOutOrderEntity = this.GetOutOrderEntityByOutOrderNo(outOrderNo);
                            if (updateOutOrderEntity.OutboundJobStatus == 0 || updateOutOrderEntity.OutboundJobStatus == 1 || updateOutOrderEntity.OutboundJobStatus == 2 || updateOutOrderEntity.OutboundJobStatus == 3)
                            {
                                updateOutOrderEntity.OutboundJobStatus = 2;
                            }
                            updateOutOrderEntity.EndTime = DateTime.Now;
                            updateOutOrderEntity.UpdateTime = DateTime.Now;
                            updateOutOrderEntity.UpdateUserId = -1;
                            updateOutOrderEntity.UpdateUserName = "码垛机";
                            this.dbContent.Updateable<Zollner_InOutOrder>(updateOutOrderEntity).ExecuteCommand();

                            ZollnerOutboundForProduction soringWorkOrder = this.dbContent.Queryable<ZollnerOutboundForProduction>()
                                                                            .Where(x => x.OutboundID.ToLower() == updateOutOrderEntity.OutboundID.ToLower())
                                                                            .Where(x => (x.IsDelete) == false)
                                                                            .OrderByDescending(x => x.CreateTime)
                                                                            .First();
                            //检查是否所有的出库单都是完成的
                            var otherNotCompleteInoutOrderList = this.dbContent.Queryable<Zollner_InOutOrder>()
                                    .Where(x => x.IsDelete == false && x.OutboundID == updateOutOrderEntity.OutboundID
                                            && x.OutOrderNo != updateOutOrderEntity.OutOrderNo
                                            && (x.OutboundJobStatus != 2 && x.OutboundJobStatus != 4)
                                            ).ToList();
                            if (otherNotCompleteInoutOrderList.Count == 0)
                            {
                                if (soringWorkOrder != null)
                                {
                                    soringWorkOrder.OutboundStatus = 4;
                                    soringWorkOrder.EndTime = DateTime.Now;
                                    this.dbContent.Updateable<ZollnerOutboundForProduction>(soringWorkOrder).ExecuteCommand();
                                }
                            }

                            //给PLC信号->出库工单已经完成，可以走下一个出库工单
                            AppendText($"准备写入【14308】True 信号", uiContext);
                            var Result_14308 = client.Write("14308", true, stationNumber);
                            if (Result_14308.IsSucceed)
                            {
                                AppendText($"[写入 14308 成功]", uiContext);
                                //Thread.Sleep(5000);
                                Thread.Sleep(500);
                                AppendText($"准备擦除【14308】True 信号", uiContext);
                                Result_14308 = client.Write("14308", false, stationNumber);
                                AppendText($"[写入 14308 成功]", uiContext);
                            }

                            //给PLC信号->出库工单新工单信号-->置成false
                            var Result_14289 = client.Write("14289", true, stationNumber);
                            AppendText($"准备写入【14289】False 信号", uiContext);
                            Result_14289 = client.Write("14289", false, stationNumber);
                            if (Result_14289.IsSucceed)
                            {
                                AppendText($"[写入 14289 成功]", uiContext);
                            }

                            response = response.OK($"出库单【{outOrderNo}】已完成装箱", 1);
                        }
                	}
                }
            }
            else
            {
                response = response.OK($"箱号【{BoxNo}】不存在", 1);
                AppendText($"箱号【{BoxNo}】不存在", uiContext);
            }

            uiContext.Post(_ => txtCurrentBoxInfo.Text = response.Message, null);

            return response;
        }

        /// <summary>
        /// 传入箱子箱号,物料唯一码
        /// 说明料等待区域有料呢
        /// 注意:经过前面的过滤判断->仅箱子箱号的判断【QueryOperateDictate(string BoxNo)】
        /// 可以得出下面的结论->
        /// α.箱子未满箱，甚至它是个空箱
        /// β.箱子如果已关联出库单单据编号，那么出库单尚未处理完成，仍有料盘待装箱
        /// 那么我们此时需要加入料盘唯一码来处理
        /// A.箱子没有满料，箱子对应的出库单也没有出完
        /// B.需要判断物料盘和箱子是否适配
        /// 所以这里处理只有三个选择 1. 出箱(箱子关联单据与物料关联单据一致，但是箱子类型不匹配) 0. 停留(等抓料操作) -1. NG料盘(箱子关联单据与物料关联单据不一致)
        /// 1. 出箱
        /// 0. 抓料
        /// -1.NG料盘
        /// </summary>
        /// <param name="BoxNo"></param>
        /// <param name="ReelId"></param>
        /// <returns></returns>
        public ResponseContent QueryOperateDictate(string BoxNo, string ReelId)
        {
            ResponseContent response = new ResponseContent();

            SynchronizationContext uiContext = this.uiContextMain;

            bool result_CheckBoxNo = this.CheckBoxNo(BoxNo);
            bool result_CheckRealId = this.CheckRealId(ReelId);
            if (string.IsNullOrEmpty(ReelId))
            {
                response = response.OK($"物料唯一码【{ReelId}】未识别", -1);
                AppendText($"物料唯一码【{ReelId}】未识别", uiContext);
                uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                return response;
            }
            else if (ReelId.ToUpper() == "M")
            {
                response = response.OK($"物料唯一码【{ReelId}】不清晰或存在多个唯一码", -1);
                AppendText($"物料唯一码【{ReelId}】不清晰或存在多个唯一码", uiContext);
                uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                return response;
            }
            if (result_CheckBoxNo && result_CheckRealId)
            {
                var BoxEntity = this.GetBoxEntityByBoxNo(BoxNo);
                var ReelIdList_MapThisBoxNo = this.GetReelIdListInBoxDetailListByBoxNo(BoxNo);

                var OutorderNo_MapThisBox = BoxEntity.InOutOrder;
                var BoxNoList_MapThisBox = this.GetBoxNoListByOutOrderNo(OutorderNo_MapThisBox);
                var ReelIdList_MapThisBoxNoList = this.GetReelIdListInBoxDetailListByBoxNoList(BoxNoList_MapThisBox);


                var MaterialEntity = this.GetMaterialStockEntityByReelId(ReelId);
                var OutOrderEntity_MapThisReelId = this.GetOutOrderEntityByReelId(ReelId);
                if (OutOrderEntity_MapThisReelId == null)
                {
                    response = response.OK($"物料【{ReelId}】无法找到对应出库单，无法匹配箱子类型", -1);
                    AppendText($"物料【{ReelId}】无法找到对应出库单，无法匹配箱子类型", uiContext);
                    uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);
                    return response;
                }
                var OutOrderNo_MapThisReelId = OutOrderEntity_MapThisReelId.OutOrderNo;
                var ReelIdList_MapThisReelId = this.GetRealIdListInOutOrderDetailListByOutOrderNo(OutOrderNo_MapThisReelId);

                bool checkResult = false;
                if (this.IsEmptyBox(BoxNo))
                {
                    //如果是空箱子
                    checkResult = this.IsEmptyBoxUseFull(BoxNo, OutOrderNo_MapThisReelId, ReelId);
                    if (checkResult)
                    {
                        BoxEntity.InOutOrder = OutOrderNo_MapThisReelId;
                        BoxEntity.WorkerOrder = OutOrderEntity_MapThisReelId.OutboundID;
                        BoxEntity.isEmpty = true;
                        //将箱号关联上料盘当前所在出库单据的单据编号
                        this.dbContent.Updateable<Box>(BoxEntity).ExecuteCommand();
                        response = response.OK("Success", 0);
                    }
                    else
                    {
                        response = response.OK($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", 1); //既然是空的箱子，那么最优解就是退出箱子，换个箱子
                        AppendText($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", uiContext);
                    }
                }
                else 
                {
                    //如果不是空箱子
                    //箱子关联的出库单编号 无法对应 料盘关联的出库单编号 --> NG料盘
                    if (OutorderNo_MapThisBox.ToLower() != OutOrderNo_MapThisReelId.ToLower())
                    {
                        response = response.OK($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", -1);
                        AppendText($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", uiContext);
                    }
                    //箱子关联的出库单编号 可以对应 料盘关联的出库单编号 --> 检查箱是否可用
                    else
                    {
                        checkResult = this.IsUnEmptyBoxUseFull(BoxNo, OutOrderNo_MapThisReelId, ReelId);
                        if (!checkResult) //不匹配->出箱子
                        {
                            response = response.OK($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", 1);
                            AppendText($"物料【{ReelId}】无法使用该箱号【{BoxNo}】，类型不匹配", uiContext);
                        }
                        else //匹配->抓料
                        {
                            response = response.OK($"准备抓取物料【{ReelId}】进箱号【{BoxNo}】", 0);
                        }
                    }
                }
            }
            else
            {
                if (!result_CheckBoxNo)
                {
                    response = response.OK("", 1);
                    AppendText($"箱号【{BoxNo}】不存在", uiContext);
                }
                else if (!result_CheckRealId)
                {
                    response = response.OK($"物料唯一码【{ReelId}】不存在", -1);
                    AppendText($"物料唯一码【{ReelId}】不存在", uiContext);
                }
                else
                {
                    response = response.OK($"箱号【{BoxNo}】不存在,物料唯一码【{ReelId}】不存在", -1);
                    AppendText($"箱号【{BoxNo}】不存在,物料唯一码【{ReelId}】不存在", uiContext);
                }

            }

            uiContext.Post(_ => txtCurrentProcessInfo.Text = response.Message, null);

            return response;
        }

        #endregion

        #region 功能按钮

        EndianFormat format = EndianFormat.CDAB;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            Task.Run(() =>
            {
                try
                {
                    uiContext.Post(_ => btn_open.Text = "连接中...", null);
                    //if (txt_MsgPLC.Text.Length > 0) txt_MsgPLC.Text = string.Empty;
                    client?.Close();

                    var plcadd = false;

                    client = new ModbusTcpClient(txt_ip.Text?.Trim(), int.Parse(txt_port.Text?.Trim()), format: format, plcAddresses: plcadd);

                    var result = client.Open();

                    if (result.IsSucceed)
                    {
                        uiContext.Post(_ => btn_start.Enabled = true, null);
                        uiContext.Post(_ => btn_stop.Enabled = true, null);

                        client.Write("14290", false, stationNumber);
                        client.Write("14290", true, stationNumber);

                        AppendText($"连接成功\t\t\t\t耗时：{result.TimeConsuming}ms", uiContext);

                        uiContext.Post(_ => btn_initial.Enabled = true, null);
                        uiContext.Post(_ => btn_start.Enabled = true, null);
                        uiContext.Post(_ => btn_stop.Enabled = true, null);
                        uiContext.Post(_ => btn_error.Enabled = true, null);

                        uiContext.Post(_ => btn_autoprc_start.Enabled = true, null);
                        uiContext.Post(_ => btn_autoprc_stop.Enabled = true, null);

                        uiContext.Post(_ => btn_autoagv1_start.Enabled = true, null);
                        uiContext.Post(_ => btn_autoagv2_start.Enabled = true, null);
                        uiContext.Post(_ => btn_autoagv3_start.Enabled = true, null);
                        uiContext.Post(_ => btn_autoagv1_stop.Enabled = true, null);
                        uiContext.Post(_ => btn_autoagv2_stop.Enabled = true, null);
                        uiContext.Post(_ => btn_autoagv3_stop.Enabled = true, null);

                        uiContext.Post(_ => btn_TakePhotoFromEquiment0.Enabled = true, null);
                        uiContext.Post(_ => btn_TakeScanFromEquiment1.Enabled = true, null);
                        uiContext.Post(_ => btn_TakeScanFromEquiment2.Enabled = true, null);
                        uiContext.Post(_ => btn_rollout.Enabled = true, null);

                        ControlEnabledFalse(uiContext);

                        this.TaskStart_GetPLCBinInfo();
                        this.TaskStart_GetPLCInitInfo();

                        this.TaskStart_RefreshBeat();
                        this.TaskStart_RefreshIOT();

                        this.TaskStart_RefreshAgvBoxAtInput1();
                        this.TaskStart_RefreshAgvBoxAtInput2();
                        this.TaskStart_RefreshAgvBoxAtInput3();
                    }
                    else
                        //MessageBox.Show($"连接失败：{result.Err}");
                        this.Error($"连接失败：{result.Err}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    uiContext.Post(_ => btn_open.Text = "连接", null);
                }
            });
        }

        private void ControlEnabledFalse(SynchronizationContext uiContext)
        {
            uiContext.Post(_ => txt_ip.Enabled = false, null);
            uiContext.Post(_ => txt_port.Enabled = false, null);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            client.Write("14290", true, stationNumber);
            client.Write("14290", false, stationNumber);

            client?.Close();
            btn_open.Enabled = true;

            btn_initial.Enabled = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = false;
            btn_error.Enabled = false;

            btn_autoprc_start.Enabled = false;
            btn_autoprc_stop.Enabled = false;

            btn_autoagv1_start.Enabled = false;
            btn_autoagv2_start.Enabled = false;
            btn_autoagv3_start.Enabled = false;
            btn_autoagv1_stop.Enabled = false;
            btn_autoagv2_stop.Enabled = false;
            btn_autoagv3_stop.Enabled = false;

            btn_TakePhotoFromEquiment0.Enabled = false;
            btn_TakeScanFromEquiment1.Enabled = false;
            btn_TakeScanFromEquiment2.Enabled = false;
            btn_rollout.Enabled = false;


            AppendText($"连接关闭", uiContext);
            ControlEnabledTrue(uiContext);

            this.TaskEnd_GetPLCBinInfo();
            this.TaskEnd_GetPLCInitInfo();

            this.TaskEnd_RefreshBeat();
            this.TaskEnd_RefreshIOT();

            this.TaskEnd_RefreshAgvBoxAtInput1();
            this.TaskEnd_RefreshAgvBoxAtInput2();
            this.TaskEnd_RefreshAgvBoxAtInput3();
        }

        private void ControlEnabledTrue(SynchronizationContext uiContext)
        {
            uiContext.Post(_ => txt_ip.Enabled = true, null);
            uiContext.Post(_ => txt_port.Enabled = true, null);
        }

        #region 开启关闭AGV1
        private void btn_autoagv1_start_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            if (!this.CallAgvBoxAtInput1_Order)
            {
                this.TaskStart_CallAgvBoxAtInput1();

                uiContext.Post(_ => this.btn_autoagv1_start.Enabled = false, null);
                uiContext.Post(_ => this.btn_autoagv1_stop.Enabled = true, null);
            }
            else
            {
                base.Info("已开启自动任务失败,请勿重复开启", "已开启自动任务失败,请勿重复开启");
            }
        }

        private void btn_autoagv1_stop_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            this.fnc_CancelAGVSide1_Click();

            this.TaskEnd_CallAgvBoxAtInput1();

            uiContext.Post(_ => this.btn_autoagv1_stop.Enabled = false, null);
            Thread.Sleep(5000);
            uiContext.Post(_ => this.btn_autoagv1_start.Enabled = true, null);
        }
        #endregion

        #region 开启关闭AGV2
        private void btn_autoagv2_start_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            if (!this.CallAgvBoxAtInput2_Order)
            {
                this.TaskStart_CallAgvBoxAtInput2();

                uiContext.Post(_ => this.btn_autoagv2_start.Enabled = false, null);
                uiContext.Post(_ => this.btn_autoagv2_stop.Enabled = true, null);
            }
            else
            {
                base.Info("已开启自动任务失败,请勿重复开启", "已开启自动任务失败,请勿重复开启");
            }
        }

        private void btn_autoagv2_stop_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            this.fnc_CancelAGVSide2_Click();

            this.TaskEnd_CallAgvBoxAtInput2();

            uiContext.Post(_ => this.btn_autoagv2_stop.Enabled = false, null);
            Thread.Sleep(5000);
            uiContext.Post(_ => this.btn_autoagv2_start.Enabled = true, null);
        }
        #endregion

        #region 开启关闭AGV3
        private void btn_autoagv3_start_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            if (!this.CallBoxAgvAtOutput3_Order)
            {
                this.TaskStart_CallBoxAgvAtOutput3();

                uiContext.Post(_ => this.btn_autoagv3_start.Enabled = false, null);
                uiContext.Post(_ => this.btn_autoagv3_stop.Enabled = true, null);
            }
            else
            {
                base.Info("已开启自动任务失败,请勿重复开启", "已开启自动任务失败,请勿重复开启");
            }
        }

        private void btn_autoagv3_stop_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            this.fnc_CancelAGVSide3_Click();

            this.TaskEnd_CallBoxAgvAtOutput3();

            uiContext.Post(_ => this.btn_autoagv3_stop.Enabled = false, null);
            Thread.Sleep(5000);
            uiContext.Post(_ => this.btn_autoagv3_start.Enabled = true, null);
        }
        #endregion

        #region 刷新AGV显示信息

        private void btn_RefreshAGVSide1_Click(object sender, EventArgs e)
        {
            this.TaskEnd_RefreshAgvBoxAtInput1();

            Thread.Sleep(10000);

            this.TaskStart_RefreshAgvBoxAtInput1();
        }

        private void btn_RefreshAGVSide2_Click(object sender, EventArgs e)
        {
            this.TaskEnd_RefreshAgvBoxAtInput2();

            Thread.Sleep(10000);

            this.TaskStart_RefreshAgvBoxAtInput2();
        }

        private void btn_RefreshAGVSide3_Click(object sender, EventArgs e)
        {
            this.TaskEnd_RefreshAgvBoxAtInput3();

            Thread.Sleep(10000);

            this.TaskStart_RefreshAgvBoxAtInput3();
        }

        #endregion

        private void btn_autoprc_start_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            var Result_13301 = client.ReadCoil("13301", stationNumber);

            if (Result_13301.IsSucceed && Result_13301.Value)
            {
                this.TaskStart_GetNGInfo();

                //this.TaskStart_RefreshAgvBoxAtInput1();

                //this.TaskStart_RefreshAgvBoxAtInput2();

                //this.TaskStart_RefreshAgvBoxAtInput3();

                //this.TaskStart_CallAgvBoxAtInput1();

                //this.TaskStart_CallAgvBoxAtInput2();

                this.TaskStart_TakeOperateApp();

                //this.TaskStart_CallBoxAgvAtOutpu3();                

                uiContext.Post(_ => this.btn_autoprc_start.Enabled = false, null);
                uiContext.Post(_ => this.btn_autoprc_stop.Enabled = true, null);
            }
            else
            {
                base.Info("开启自动任务失败,请先将PLC设置为自动模式", "开启自动任务失败,请先将PLC设置为自动模式");
            }


        }

        private void btn_autoprc_stop_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;

            //this.TaskEnd_RefreshAgvBoxAtInput1();

            //this.TaskEnd_RefreshAgvBoxAtInput2();

            //this.TaskEnd_RefreshAgvBoxAtInput3();

            //this.TaskEnd_CallAgvBoxAtInput1();

            //this.TaskEnd_CallAgvBoxAtInput2();

            this.TaskEnd_TakeOperateApp();

            this.AskBoxRollFromInput1_Order = false;
            this.AskBoxRollFromInput2_Order = false;
            this.AskBoxRoolToOutpu3_Order = false;

            //this.TaskEnd_CallBoxAgvAtOutpu3();

            uiContext.Post(_ => this.btn_autoprc_stop.Enabled = false, null);
            Thread.Sleep(10000);
            uiContext.Post(_ => this.btn_autoprc_start.Enabled = true, null);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //client.Write("14388", false, stationNumber);
            //client.Write("14389", false, stationNumber);

            //client.Write("14488", false, stationNumber);
            //client.Write("14489", false, stationNumber);

            client.Write("14299", false, stationNumber);
            client.Write("14299", true, stationNumber);
            Thread.Sleep(500);
            client.Write("14299", false, stationNumber);


        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            client.Write("14300", false, stationNumber);
            client.Write("14300", true, stationNumber);

            Thread.Sleep(500);
            client.Write("14300", false, stationNumber);
        }

        private void btn_error_Click(object sender, EventArgs e)
        {
            client.Write("14301", false, stationNumber);
            client.Write("14301", true, stationNumber);

            Thread.Sleep(500);
            client.Write("14301", false, stationNumber);
        }

        private void btn_rollout_Click(object sender, EventArgs e)
        {
            client.Write("14302", false, stationNumber);
            client.Write("14302", true, stationNumber);

            Thread.Sleep(500);
            client.Write("14302", false, stationNumber);
        }

        private void btn_initial_Click(object sender, EventArgs e)
        {
            client.Write("14298", false, stationNumber); // 初始化信号
            client.Write("14298", true, stationNumber); // 初始化信号
            Thread.Sleep(500);
            client.Write("14298", false, stationNumber); // 初始化信号

            Thread.Sleep(50);
            var Result_13294 = client.ReadCoil("13294", stationNumber); // 初始化信号
            var Result_13305 = client.ReadCoil("13305", stationNumber); // 初始化信号
            if ((Result_13294.IsSucceed && Result_13294.Value))
            {
                //client.Write("14388", false, stationNumber); //1通道AGV小车到位
                //client.Write("14389", false, stationNumber); //1通道起转OK
                //client.Write("14404", false, stationNumber); //1通道箱子码垛入料调入信号

                //client.Write("14488", false, stationNumber); //2通道AGV小车到位
                //client.Write("14489", false, stationNumber); //2通道起转OK
                //client.Write("14504", false, stationNumber); //2通道箱子码垛入料调入信号

                //client.Write("14588", false, stationNumber); //3通道AGV小车到位
                //client.Write("14589", false, stationNumber); //3通道起转OK


                //client.Write("14688", false, stationNumber); //带格箱
                //client.Write("14689", false, stationNumber);
                //client.Write("14690", false, stationNumber); //不带格箱
                //client.Write("14691", false, stationNumber); //NG箱
                //client.Write("14692", false, stationNumber); //空箱清0信号
                //client.Write("14693", false, stationNumber); //扫码超时
                //client.Write("14694", false, stationNumber);


                //client.Write("14738", false, stationNumber); //拍照完成
                //client.Write("14748", false, stationNumber); //当前OK类型的箱子流出


                //client.Write("7011", 0, stationNumber); //7寸箱格子放置
                //client.Write("7012", 0, stationNumber); //13寸箱格子放置
                //client.Write("7013", 0, stationNumber); //混箱格子放置


                //client.Write("14788", false, stationNumber); //扫码完成
                //client.Write("14789", false, stationNumber); //扫码超时

                //client.Write("14289", false, stationNumber); //新工单启动信号保持（工单完成时复位）

                //client.Write("14308", false, stationNumber); //工单完成-》PLC-》前端PLC-》WCS


                //client.Write("14302", false, stationNumber); //箱子流出
                //Thread.Sleep(500);
                //client.Write("14302", true, stationNumber); //箱子流出
                //Thread.Sleep(500);
                //client.Write("14302", false, stationNumber); //箱子流出
            }
            else
            {
                base.Info("初始化失败,请检查码垛机是否满足初始化条件", "初始化失败,请检查码垛机是否满足初始化条件");
            }

            

        }


        private void btn_CancelAGVSide1_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtInput1";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }

        private void fnc_CancelAGVSide1_Click()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtInput1";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }

        private void btn_CancelAGVSide2_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtInput2";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }

        private void fnc_CancelAGVSide2_Click()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtInput2";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }

        private void btn_CancelAGVSide3_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtOutput3";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }

        private void fnc_CancelAGVSide3_Click()
        {
            SynchronizationContext uiContext = this.uiContextMain;
            var resourceSetting = Properties.Settings.Default;

            string resContent = "";

            string url = $"{resourceSetting.IWMSAddress}api/agvCallBack/CancelAgvBoxAtOutput3";
            //url = url + $"/{TaskCode}";
            var request = new RestRequest(url, Method.Post);
            //request.AddHeader("Authorization", "");
            //request.AddHeader("Accept", "application/json");
            //var postBody = new {  };
            //request.AddJsonBody(postBody);

            RestClient client = new RestClient(url);

            RestResponse response = client.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                resContent = response.Content.Replace("\"", "");
            }

            this.Info("AGV任务已成功取消！");

            //return resContent;
        }


        #endregion

        private void btn_TakePhotoFromEquiment0_Click(object sender, EventArgs e)
        {
            ResponseContent response = GetPhotoString(null);

            base.Info("拍照", this.Buffer_ReelId_AtOperate);
        }

        private void btn_TakeScanFromEquiment1_Click(object sender, EventArgs e)
        {
            ResponseContent response = GetScan1String(null);

            base.Info("扫码1", this.Buffer_BoxNo_AtOperate);
        }

        private void btn_TakeScanFromEquiment2_Click(object sender, EventArgs e)
        {
            ResponseContent response = GetScan2String(null);

            base.Info("扫码2", this.Buffer_BoxNo_AtOutput3);
        }


    }
}
