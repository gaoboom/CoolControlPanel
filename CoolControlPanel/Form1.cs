using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace CoolControlPanel
{
    public partial class ControlPanelMain : Form
    {

        #region 全局变量部分
        public string WorkingStatus = "空闲";// 空闲/处理中
        public string DataCheckStatus = "无数据";// 无数据/有误/正常/未检查
        public string OperateArea = "无";// 无/服务器/本地
        public string OperateObjectType = "无";// 无/微信/微博/网站/视频广告/腾讯广点通/移动广告/门户网站/联盟广告

        MySqlDataReader ServerDataReader = null;//从服务器获取的数据reader 默认为空
        int TotalPage = 1;//总页数 默认为1
        int RecentPage = 1;//当前页 默认为1

        DataGridViewCell EditingCell = null;//当前编辑单元格 默认为null

        List<int> SearchResultsX = new List<int>();
        List<int> SearchResultsY = new List<int>();
        int SearchIndex = 0;

        List<int> CheckResultsX = new List<int>();
        List<int> CheckResultsY = new List<int>();
        List<string> CheckToolTip = new List<string>();
        int ErrorIndex = 0;

        /// <summary>
        /// 重置全局变量 一般首次获取数据时使用
        /// </summary>
        public void GlobalStatusClear()
        {
            WorkingStatus = "空闲";
            DataCheckStatus = "无数据";
            OperateArea = "无";
            OperateObjectType = "无";
            TotalPage = 1;
            RecentPage = 1;
        }

        #endregion

        #region 数据库操作类部分
        /// <summary>
        /// 基于MySQL的数据层基类
        /// </summary>
        /// <remarks>
        /// 参考于MS Petshop 4.0
        /// </remarks>
        public abstract class MySqlHelper
        {
            public static readonly string DBConnectionString = "Server=127.0.0.1;Database=resourcecool;Uid=root;Pwd=admin;";
            //public static readonly string DBConnectionString = "Server=103.29.135.207;Database=resourcecool;Uid=cool_on;Pwd=C20!@5@L;";
            /// <summary>
            /// Command预处理
            /// </summary>
            /// <param name="conn">MySqlConnection对象</param>
            /// <param name="trans">MySqlTransaction对象，可为null</param>
            /// <param name="cmd">MySqlCommand对象</param>
            /// <param name="cmdType">CommandType，存储过程或命令行</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组，可为null</param>
            private static void PrepareCommand(MySqlConnection conn, MySqlTransaction trans, MySqlCommand cmd, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if (trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = cmdType;
                if (cmdParms != null)
                {
                    foreach (MySqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }
            }
            #region ExecuteNonQuery
            /// <summary>
            /// 执行命令
            /// </summary>
            /// <param name="connectionString">数据库连接字符串</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns>返回受引响的记录行数</returns>
            public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            /// <summary>
            /// 执行命令
            /// </summary>
            /// <param name="conn">Connection对象</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns>返回受引响的记录行数</returns>
            public static int ExecuteNonQuery(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            /// <summary>
            /// 执行事务
            /// </summary>
            /// <param name="trans">MySqlTransaction对象</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns>返回受引响的记录行数</returns>
            public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(trans.Connection, trans, cmd, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            #endregion
            #region ExecuteScalar
            /// <summary>
            /// 执行命令，返回第一行第一列的值
            /// </summary>
            /// <param name="connectionString">数据库连接字符串</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns>返回Object对象</returns>
            public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    PrepareCommand(connection, null, cmd, cmdType, cmdText, cmdParms);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
            /// <summary>
            /// 执行命令，返回第一行第一列的值
            /// </summary>
            /// <param name="connectionString">数据库连接字符串</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns>返回Object对象</returns>
            public static object ExecuteScalar(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
            #endregion
            #region ExecuteReader
            /// <summary>
            /// 执行命令或存储过程，返回MySqlDataReader对象
            /// 注意MySqlDataReader对象使用完后必须Close以释放MySqlConnection资源
            /// </summary>
            /// <param name="connectionString">数据库连接字符串</param>
            /// <param name="cmdType">命令类型（存储过程或SQL语句）</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组</param>
            /// <returns></returns>
            public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = new MySqlConnection(connectionString);
                try
                {
                    PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                    MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    return dr;
                }
                catch
                {
                    conn.Close();
                    throw;
                }
            }
            #endregion
            #region ExecuteDataSet
            /// <summary>
            /// 执行命令或存储过程，返回DataSet对象
            /// </summary>
            /// <param name="connectionString">数据库连接字符串</param>
            /// <param name="cmdType">命令类型(存储过程或SQL语句)</param>
            /// <param name="cmdText">SQL语句或存储过程名</param>
            /// <param name="cmdParms">MySqlCommand参数数组(可为null值)</param>
            /// <returns></returns>
            public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
            {
                MySqlCommand cmd = new MySqlCommand();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    PrepareCommand(conn, null, cmd, cmdType, cmdText, cmdParms);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    cmd.Parameters.Clear();
                    return ds;
                }
            }
            #endregion
        }
        #endregion

        #region UI控制部分

        /// <summary>
        /// 页面初始化方法 界面打开时调用
        /// 工作状态：空闲
        /// 数据检查状态：无数据
        /// 当前操作平台：无
        /// 当前操作对象：无
        /// 工具栏不可用
        /// </summary>
        public void UiInit()
        {
            toolStripStatusLabelStatus.Text = "空闲";//操作面板工作状态：空闲/处理中
            toolStripStatusLabelStatus.BackColor= Color.YellowGreen;//绿YellowGreen,红OrangeRed,灰LightGray
            toolStripStatusLabelDataCheckStatus.Text = "无数据";//数据检查状态：无数据/有误/正常/未检查
            toolStripStatusLabelDataCheckStatus.BackColor = Color.LightGray;
            toolStripStatusLabelOperateArea.Text = "无";//当前操作平台：无/服务器/本地
            toolStripStatusLabelOperateArea.BackColor = Color.LightGray;
            toolStripStatusLabelOpearteObjectType.Text = "无";//当前操作类别：无/微信/微博/网站/视频广告/腾讯广点通/移动广告/门户网站/联盟广告
            toolStripStatusLabelOpearteObjectType.BackColor = Color.LightGray;
            toolStripMain.Enabled = false;
        }

        /// <summary>
        /// 根据当前全局变量刷新界面UI
        /// 刷新内容包括：工作状态/数据检查状态/当前操作平台/当前操作对象/当前页数/总页数
        /// </summary>
        public void UiRefresh()
        {
            toolStripStatusLabelStatus.Text = WorkingStatus;
            toolStripStatusLabelDataCheckStatus.Text = DataCheckStatus;
            toolStripStatusLabelOperateArea.Text = OperateArea;
            toolStripStatusLabelOpearteObjectType.Text = OperateObjectType;
            toolStripTextBoxRecentPage.Text = RecentPage.ToString();
            toolStripTextBoxRecentPage.ToolTipText = "共 " + TotalPage + " 页";
        }

        #endregion

        #region UI状态改变事件部分
        /// <summary>
        /// 当程序工作状态改变时需要的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabelStatus_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabelStatus.Text == "空闲")
            {
                toolStripStatusLabelStatus.BackColor = Color.YellowGreen;
                menuStripMain.Enabled = true;
            }
            else if (toolStripStatusLabelStatus.Text == "处理中")
            {
                toolStripStatusLabelStatus.BackColor = Color.OrangeRed;
                menuStripMain.Enabled = false;
                toolStripMain.Enabled = false;
            }
        }
        /// <summary>
        /// 当数据检查状态改变时需要的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabelDataCheckStatus_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabelDataCheckStatus.Text == "无数据")
            {
                toolStripStatusLabelDataCheckStatus.BackColor = Color.LightGray;
                toolStripMain.Enabled = false;
            }
            else if (toolStripStatusLabelDataCheckStatus.Text == "有误")
            {
                toolStripStatusLabelDataCheckStatus.BackColor = Color.OrangeRed;
            }
            else if (toolStripStatusLabelDataCheckStatus.Text == "正常")
            {
                toolStripStatusLabelDataCheckStatus.BackColor = Color.YellowGreen;
            }
            else if (toolStripStatusLabelDataCheckStatus.Text == "未检查")
            {
                toolStripStatusLabelDataCheckStatus.BackColor = Color.OrangeRed;
            }
        }
        /// <summary>
        /// 当操作平台改变时需要的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabelOperateArea_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabelOperateArea.Text == "无")
            {
                toolStripStatusLabelOperateArea.BackColor = Color.LightGray;
            }
            else if (toolStripStatusLabelOperateArea.Text == "服务器")
            {
                toolStripStatusLabelOperateArea.BackColor = Color.SkyBlue;
                toolStripButtonAddInfo.Enabled = false;
            }
            else if (toolStripStatusLabelOperateArea.Text == "本地")
            {
                toolStripStatusLabelOperateArea.BackColor = Color.SteelBlue;
            }
        }
        /// <summary>
        /// 当操作类别改变时需要的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabelOpearteObjectType_TextChanged(object sender, EventArgs e)
        {
            if (toolStripStatusLabelOpearteObjectType.Text == "无")
            {
                toolStripStatusLabelOpearteObjectType.BackColor = Color.LightGray;
                toolStripMain.Enabled = false;
            }
            else if (toolStripStatusLabelOpearteObjectType.Text == "微信")
            {
                toolStripStatusLabelOpearteObjectType.BackColor = Color.SkyBlue;
                toolStripMain.Enabled = true;
            }
        }

        #endregion

        #region 委托部分
        private delegate void MyDelegate();
        #endregion

        #region DataGridView操作部分

        /// <summary>
        /// 清空表格数据 一般在获取远程资源和创建本地资源时调用
        /// </summary>
        private void ClearDataGridView()
        {
            dataGridViewMain.Rows.Clear();
        }

        /// <summary>
        /// 根据当前操作对象重新生成DataGridView的表头
        /// 主表头：编号/主表编号/附表编号/资源名称/资源类型/行业/区域/是否直投
        /// 附表头-微信：WeixinAccount/AccountType/FunsNum/CooperateMode/CooperatePrice
        /// 附表头-微博：
        /// 附表头-网站：
        /// 附表头-视频广告：
        /// 附表头-腾讯广点通：
        /// 附表头-移动广告：
        /// 附表头-门户网站：
        /// 附表头-联盟广告：
        /// 状态表头：检查状态/处理方式/处理结果
        /// </summary>
        public void GridRefresh()
        {
            //首先清空表头
            dataGridViewMain.Columns.Clear();
            //然后添加主表头 ShowId/CoolId/AddOnId/CoolName/CoolType/Industry/AdRegion/DirectUse
            //编号列
            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();//实例化表头对象
            column0.HeaderText = "编号";
            column0.Visible = true;
            column0.Name = "ShowId";
            column0.Frozen = true;
            column0.Width = 55;
            column0.ToolTipText = "数据显示编号";
            dataGridViewMain.Columns.Add(column0);
            //主表ID列
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();//实例化表头对象
            column1.HeaderText = "主表编号";
            column1.Visible = false;
            column1.Name = "CoolId";
            column1.Frozen = true;
            column1.Width = 55;
            column1.ToolTipText = "";
            dataGridViewMain.Columns.Add(column1);
            //附表ID列
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();//实例化表头对象
            column2.HeaderText = "附表编号";
            column2.Visible = false;
            column2.Name = "AddOnId";
            column2.Frozen = true;
            column2.Width = 55;
            column2.ToolTipText = "";
            dataGridViewMain.Columns.Add(column2);
            //资源名称列
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();//实例化表头对象
            column3.HeaderText = "资源名称";
            column3.Visible = true;
            column3.Name = "CoolName";
            column3.Frozen = true;
            column3.Width = 100;
            column3.ToolTipText = "资源名称";
            dataGridViewMain.Columns.Add(column3);
            //资源类型列
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();//实例化表头对象
            column4.HeaderText = "资源类型";
            column4.Visible = true;
            column4.Name = "CoolType";
            column4.Frozen = false;
            column4.Width = 100;
            column4.ToolTipText = "资源类型";
            dataGridViewMain.Columns.Add(column4);
            //行业分类列
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();//实例化表头对象
            column5.HeaderText = "行业";
            column5.Visible = true;
            column5.Name = "Industry";
            column5.Frozen = false;
            column5.Width = 100;
            column5.ToolTipText = "行业";
            dataGridViewMain.Columns.Add(column5);
            //区域分类列
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();//实例化表头对象
            column6.HeaderText = "区域";
            column6.Visible = true;
            column6.Name = "AdRegion";
            column6.Frozen = false;
            column6.Width = 100;
            column6.ToolTipText = "区域";
            dataGridViewMain.Columns.Add(column6);
            //直投（资源状态）列
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();//实例化表头对象
            column7.HeaderText = "直投";
            column7.Visible = true;
            column7.Name = "DirectUse";
            column7.Frozen = false;
            column7.Width = 100;
            column7.ToolTipText = "直投";
            dataGridViewMain.Columns.Add(column7);
            //主表头添加完毕，开始添加附表头 无/微信/微博/网站/视频广告/腾讯广点通/移动广告/门户网站/联盟广告
            if (OperateObjectType == "微信")
            {
                //微信账号列
                DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();//实例化表头对象
                column8.HeaderText = "账号";
                column8.Visible = true;
                column8.Name = "WeixinAccount";
                column8.Frozen = false;
                column8.Width = 100;
                column8.ToolTipText = "账号";
                dataGridViewMain.Columns.Add(column8);
                //微信类别列
                DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();//实例化表头对象
                column9.HeaderText = "类别";
                column9.Visible = true;
                column9.Name = "AccountType";
                column9.Frozen = false;
                column9.Width = 100;
                column9.ToolTipText = "类别";
                dataGridViewMain.Columns.Add(column9);
                //粉丝数量列
                DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();//实例化表头对象
                column10.HeaderText = "粉丝数";
                column10.Visible = true;
                column10.Name = "FunsNum";
                column10.Frozen = false;
                column10.Width = 100;
                column10.ToolTipText = "粉丝数";
                dataGridViewMain.Columns.Add(column10);
                //广告方式
                DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn();//实例化表头对象
                column11.HeaderText = "投放方式";
                column11.Visible = true;
                column11.Name = "CooperateMode";
                column11.Frozen = false;
                column11.Width = 100;
                column11.ToolTipText = "投放方式";
                dataGridViewMain.Columns.Add(column11);
                //广告价格
                DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn();//实例化表头对象
                column12.HeaderText = "投放价格";
                column12.Visible = true;
                column12.Name = "CooperatePrice";
                column12.Frozen = false;
                column12.Width = 100;
                column12.ToolTipText = "投放价格";
                dataGridViewMain.Columns.Add(column12);
            }
            //附表头添加完毕，开始添加操作状态列
            //检查状态列
            DataGridViewTextBoxColumn columnCheckStatus = new DataGridViewTextBoxColumn();//实例化表头对象
            columnCheckStatus.HeaderText = "检查状态";
            columnCheckStatus.Visible = true;
            columnCheckStatus.Name = "CheckStatus";
            columnCheckStatus.Frozen = false;
            columnCheckStatus.Width = 100;
            columnCheckStatus.ToolTipText = "检查状态";
            dataGridViewMain.Columns.Add(columnCheckStatus);
            //处理方式列
            DataGridViewTextBoxColumn columnHandleType = new DataGridViewTextBoxColumn();//实例化表头对象
            columnHandleType.HeaderText = "处理方式";
            columnHandleType.Visible = true;
            columnHandleType.Name = "HandleType";
            columnHandleType.Frozen = false;
            columnHandleType.Width = 100;
            columnHandleType.ToolTipText = "处理方式";
            dataGridViewMain.Columns.Add(columnHandleType);
            //处理结果列
            DataGridViewTextBoxColumn columnHandleResult = new DataGridViewTextBoxColumn();//实例化表头对象
            columnHandleResult.HeaderText = "处理结果";
            columnHandleResult.Visible = true;
            columnHandleResult.Name = "HandleResult";
            columnHandleResult.Frozen = false;
            columnHandleResult.Width = 100;
            columnHandleResult.ToolTipText = "处理结果";
            dataGridViewMain.Columns.Add(columnHandleResult);
        }
        #endregion

        #region 后台处理部分

        /// <summary>
        /// 根据资源类型和页码返回对应的资源reader
        /// </summary>
        /// <param name="type">资源类型</param>
        /// <param name="page">页码</param>
        /// <returns>返回DataReader，如未获取到数据，返回null</returns>
        public MySqlDataReader GetServerData(string type,int page)
        {
            MySqlDataReader ServerDataReader;
            string cmdstr = "";
            string limit = ((page-1)*100).ToString()+",100";
            if (type== "微信")
            {
                cmdstr = "SELECT a.CoolId CoolId,b.WeixinId WeixinId,a.CoolName CoolName,a.CoolType CoolType,a.Industry Industry,a.Region Region,a.UpdateTime UpdateTime,a.ResourceStatus ResourceStatus,b.WeixinAccount WeixinAccount,b.AccountType AccountType,b.FunsNum FunsNum,b.CooperateMode CooperateMode,b.CooperatePrice CooperatePrice FROM cool_maindata a,cool_addon_weixin b WHERE a.CoolId=b.CoolId LIMIT "+limit;
            }
            try
            {
                ServerDataReader = MySqlHelper.ExecuteReader(MySqlHelper.DBConnectionString, CommandType.Text, cmdstr);
            }
            catch
            {
                return null;
            }
            return ServerDataReader;
        }

        public int GetDataTotalPage(string type)
        {
            int totalPage = 1;
            int CountNum = 0;
            string cmdstr = "";
            if (type == "微信")
            {
                cmdstr = "SELECT COUNT(*) FROM cool_maindata a,cool_addon_weixin b WHERE a.CoolId=b.CoolId";
            }
            CountNum = int.Parse(MySqlHelper.ExecuteScalar(MySqlHelper.DBConnectionString, CommandType.Text, cmdstr).ToString());
            if(CountNum==0)//获取到的数量为0，总页数为0
            {
                totalPage = 0;
            }
            else//数量大于0
            {
                if(CountNum%100==0)//数量能被100整除，总页数为总数除以100
                {
                    totalPage = CountNum / 100;
                }
                else//数量不能被100整除，总页数为总数
                {
                    float temp = CountNum / 100;
                    totalPage = (int)(temp + 1);
                }
            }
            return totalPage;
        }
        #endregion

        /// <summary>
        /// 初始化窗口功能
        /// </summary>
        public ControlPanelMain()
        {
            InitializeComponent();
            UiInit();
        }

        /// <summary>
        /// 点击菜单从服务器获取微信资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDataWeixinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalStatusClear();//重置全局参数
            WorkingStatus = "处理中";//将工作状态设置为 处理中
            UiRefresh();//刷新界面状态
            //刷新界面后再设置全局变量，不然会导致用户困惑
            DataCheckStatus = "正常";
            OperateArea = "服务器";
            OperateObjectType = "微信";
            RecentPage = 1;
            ClearDataGridView();//清空表格数据
            bgwMainServer.RunWorkerAsync();//开始后台获取数据
        }

        /// <summary>
        /// 从服务器获取资源的后台工作部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMainServer_DoWork(object sender, DoWorkEventArgs e)
        {
            if(OperateObjectType != "无")
            {
                TotalPage = GetDataTotalPage(OperateObjectType);
                ServerDataReader = GetServerData(OperateObjectType, RecentPage);
            }
        }

        /// <summary>
        /// 从服务器获取资源工作完成后工作部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwMainServer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkingStatus = "空闲";
            if(OperateObjectType == "微信")
            {
                GridRefresh();
                int MainIndex = 0;
                while (ServerDataReader.Read())
                {
                    MainIndex = dataGridViewMain.Rows.Add();
                    dataGridViewMain.Rows[MainIndex].Cells["ShowId"].Value = MainIndex + 1;
                    dataGridViewMain.Rows[MainIndex].Cells["CoolId"].Value = ServerDataReader["CoolId"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["AddOnId"].Value = ServerDataReader["WeixinId"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["CoolName"].Value = ServerDataReader["CoolName"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["CoolType"].Value = ServerDataReader["CoolType"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["Industry"].Value = ServerDataReader["Industry"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["AdRegion"].Value = ServerDataReader["Region"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["DirectUse"].Value = ServerDataReader["ResourceStatus"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["WeixinAccount"].Value = ServerDataReader["WeixinAccount"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["AccountType"].Value = ServerDataReader["AccountType"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["FunsNum"].Value = ServerDataReader["FunsNum"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["CooperateMode"].Value = ServerDataReader["CooperateMode"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["CooperatePrice"].Value = ServerDataReader["CooperatePrice"].ToString();
                    dataGridViewMain.Rows[MainIndex].Cells["CheckStatus"].Value = "正常";
                    dataGridViewMain.Rows[MainIndex].Cells["HandleType"].Value = "无";
                    dataGridViewMain.Rows[MainIndex].Cells["HandleResult"].Value = "无";
                }
                ServerDataReader.Close();
            }
            UiRefresh();
            toolStripMain.Enabled = true;
        }

        /// <summary>
        /// 点击菜单从服务器获取微博资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDataWeiboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalStatusClear();//重置全局参数
            WorkingStatus = "处理中";//将工作状态设置为 处理中
            UiRefresh();//刷新界面状态
            dataGridViewMain.Rows.Clear();//清空表格数据
            GridRefresh();
            //bgwMainServer.RunWorkerAsync();//开始获取数据
        }

        #region 翻页及跳转功能区
        /// <summary>
        /// 检查当前页码输入框是否为数字，如不是设置为1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBoxRecentPage_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (!r.IsMatch(toolStripTextBoxRecentPage.Text))
            {
                toolStripTextBoxRecentPage.Text = "1";
            }
        }
        /// <summary>
        /// 点击上一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonPreviousPage_Click(object sender, EventArgs e)
        {
            WorkingStatus = "处理中";//将工作状态设置为 处理中
            UiRefresh();//刷新界面状态
            if (RecentPage<=1)
            {
                RecentPage = 1;
            }
            else
            {
                RecentPage = RecentPage - 1;
            }
            toolStripTextBoxRecentPage.Text = RecentPage.ToString();
            ClearDataGridView();//清空表格数据
            bgwMainServer.RunWorkerAsync();//开始后台获取数据
        }

        /// <summary>
        /// 点击下一页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonNextPage_Click(object sender, EventArgs e)
        {
            WorkingStatus = "处理中";//将工作状态设置为 处理中
            UiRefresh();//刷新界面状态
            if (RecentPage>=TotalPage)
            {
                RecentPage = TotalPage;
            }
            else
            {
                RecentPage = RecentPage + 1;
            }
            toolStripTextBoxRecentPage.Text = RecentPage.ToString();
            ClearDataGridView();//清空表格数据
            bgwMainServer.RunWorkerAsync();//开始后台获取数据
        }

        /// <summary>
        /// 点击跳转到按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonGotoPage_Click(object sender, EventArgs e)
        {
            int gotoPage = int.Parse(toolStripTextBoxRecentPage.Text);
            if(gotoPage<=1)
            {
                gotoPage = 1;
            }
            else if(gotoPage>=TotalPage)
            {
                gotoPage = TotalPage;
            }
            RecentPage = gotoPage;
            WorkingStatus = "处理中";
            UiRefresh();
            ClearDataGridView();
            bgwMainServer.RunWorkerAsync();
        }

        #endregion

        #region 编辑功能区
        /// <summary>
        /// 删除当前选中行
        /// </summary>
        public void DeleteRow()
        {
            dataGridViewMain.CurrentRow.Cells["HandleType"].Value = "待删除";
            dataGridViewMain.CurrentRow.DefaultCellStyle.ForeColor = Color.LightGray;
        }
        
        /// <summary>
        /// 当按下delete按钮时跳转到自定义删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dataGridViewMain.SelectedCells.Count != 0)
            {
                DeleteRow();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 点击删除按钮跳转到自定义删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        /// <summary>
        /// 点击取消删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonUndelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewMain.CurrentRow.Cells["HandleType"].Value.ToString() == "待删除")
            {
                dataGridViewMain.CurrentRow.Cells["HandleType"].Value = "无";
                dataGridViewMain.CurrentRow.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 点击添加按钮(本地操作时该按钮才会生效)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAddInfo_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 编辑单元格方法，双击单元格或者点击编辑按钮时调用
        /// </summary>
        public void CellEditMethod()
        {
            if (dataGridViewMain.CurrentCell.Value != null)
            {
                string headerText = dataGridViewMain.CurrentCell.OwningColumn.HeaderText;
                if (headerText != "编号" && headerText!="资源类型" && headerText!="检查状态" && headerText != "处理方式" && headerText != "处理结果")
                {
                    EditingCell = dataGridViewMain.CurrentCell;
                    tbEdit.Visible = true;
                    tbEdit.Text = EditingCell.Value.ToString();
                }
            }
        }

        /// <summary>
        /// 编辑单元格后保存内容方法，同时检查与原值是否有改变，有泽设定当前行状态为未检查，双击编辑输入框时调用
        /// </summary>
        public void CellEditSaveMethod()
        {
            //检查保存前后值是否一样，如不一样，则设定当前行状态为未检查
            if(EditingCell.Value.ToString() != tbEdit.Text)
            {
                EditingCell.Value = tbEdit.Text;
                EditingCell.Style.BackColor= Color.Orange;
                dataGridViewMain.Rows[EditingCell.RowIndex].Cells["CheckStatus"].Value = "未检查";
                dataGridViewMain.Rows[EditingCell.RowIndex].Cells["CheckStatus"].Style.BackColor = Color.Orange;
                DataCheckStatus = "未检查";
            }
            else
            {
                EditingCell.Value = tbEdit.Text;
            }
            EditingCell = null;
            tbEdit.Text = "";
            tbEdit.Visible = false;
            UiRefresh();
        }

        /// <summary>
        /// 点击修改单元格，调用单元格编辑方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            CellEditMethod();
        }

        /// <summary>
        /// 双击编辑框保存当前编辑/设置当前单元格null/隐藏编辑框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEdit_DoubleClick(object sender, EventArgs e)
        {
            CellEditSaveMethod();
        }

        /// <summary>
        /// 双击某单元格时进行单元格编辑，调用单元格编辑方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewMain_DoubleClick(object sender, EventArgs e)
        {
            CellEditMethod();
        }

        #endregion

        #region 搜索功能区
        /// <summary>
        /// 表格通用搜索功能
        /// </summary>
        public void GridSearch()
        {
            int totalRowNum = dataGridViewMain.Rows.Count;//总行数
            int totalColumnNum = dataGridViewMain.Rows[1].Cells.Count;//总列数
            string keywordToSearch = toolStripTextBoxKeyword.Text;//关键词
            Regex r = new Regex(keywordToSearch); // 定义一个Regex对象实例
            for(int i=0; i< totalRowNum-1; i++)//在总行数之内循环
            {
                for(int j=0;j<totalColumnNum;j++)//在总列数之内循环
                {
                    Match m = r.Match(dataGridViewMain.Rows[i].Cells[j].Value.ToString()); // 在字符串中模糊匹配
                    if (m.Success)
                    {
                        SearchResultsX.Add(j);
                        SearchResultsY.Add(i);
                    }
                }
            }
        }

        /// <summary>
        /// 点击搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            if(toolStripTextBoxKeyword.Text!="")
            {
                //先重置搜索结果
                SearchResultsX.Clear();
                SearchResultsY.Clear();
                SearchIndex = 0;
                //搜索出结果
                GridSearch();
                if(SearchResultsY.Count>0)//有搜索结果的时候
                {
                    //定位到第一个结果
                    dataGridViewMain.CurrentCell = dataGridViewMain[SearchResultsX[SearchIndex], SearchResultsY[SearchIndex]];
                }
                else
                {
                    MessageBox.Show("无搜索结果");
                }
            }
            else
            {
                MessageBox.Show("请输入关键词！");
            }
        }

        /// <summary>
        /// 点击上一个搜索结果按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSearchPrevious_Click(object sender, EventArgs e)
        {
            if(SearchResultsX.Count>0)
            {
                SearchIndex -= 1;
                if (SearchIndex < 0)
                {
                    SearchIndex = 0;
                    dataGridViewMain.CurrentCell = dataGridViewMain[SearchResultsX[SearchIndex], SearchResultsY[SearchIndex]];
                    MessageBox.Show("已经到了第一个搜索结果");
                }
                else
                {
                    dataGridViewMain.CurrentCell = dataGridViewMain[SearchResultsX[SearchIndex], SearchResultsY[SearchIndex]];
                }
            }
        }
        /// <summary>
        /// 点击下一个搜索结果按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonSearchNext_Click(object sender, EventArgs e)
        {
            if (SearchResultsX.Count > 0)
            {
                SearchIndex += 1;
                if (SearchIndex > SearchResultsX.Count-1)
                {
                    SearchIndex = SearchResultsX.Count-1;
                    dataGridViewMain.CurrentCell = dataGridViewMain[SearchResultsX[SearchIndex], SearchResultsY[SearchIndex]];
                    MessageBox.Show("已经到了最后一个搜索结果");
                }
                else
                {
                    dataGridViewMain.CurrentCell = dataGridViewMain[SearchResultsX[SearchIndex], SearchResultsY[SearchIndex]];
                }
            }
        }
        #endregion

        /// <summary>
        /// 表格通用检查功能
        /// </summary>
        public void DataCheck()
        {
            int totalRowNum = dataGridViewMain.Rows.Count;//总行数
            int totalColumnNum = dataGridViewMain.Rows[1].Cells.Count;//总列数

        }
    }
}
