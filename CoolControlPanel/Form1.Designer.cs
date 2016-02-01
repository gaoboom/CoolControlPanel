namespace CoolControlPanel
{
    partial class ControlPanelMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanelMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.GetDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetDataWeixinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GetDataWeiboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataWeixinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataWeiboToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDataCheckStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOperateArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOpearteObjectType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonUpdateData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDataCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPreviousError = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextError = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxRecentPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGotoPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUndelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.ShowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoolId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddOnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoolType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Industry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HandleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HandleResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgwMainServer = new System.ComponentModel.BackgroundWorker();
            this.tbEdit = new System.Windows.Forms.TextBox();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetDataToolStripMenuItem,
            this.ImportDataToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 25);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // GetDataToolStripMenuItem
            // 
            this.GetDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetDataWeixinToolStripMenuItem,
            this.GetDataWeiboToolStripMenuItem});
            this.GetDataToolStripMenuItem.Name = "GetDataToolStripMenuItem";
            this.GetDataToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.GetDataToolStripMenuItem.Text = "获取数据";
            // 
            // GetDataWeixinToolStripMenuItem
            // 
            this.GetDataWeixinToolStripMenuItem.Name = "GetDataWeixinToolStripMenuItem";
            this.GetDataWeixinToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.GetDataWeixinToolStripMenuItem.Text = "微信资源";
            this.GetDataWeixinToolStripMenuItem.Click += new System.EventHandler(this.GetDataWeixinToolStripMenuItem_Click);
            // 
            // GetDataWeiboToolStripMenuItem
            // 
            this.GetDataWeiboToolStripMenuItem.Name = "GetDataWeiboToolStripMenuItem";
            this.GetDataWeiboToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.GetDataWeiboToolStripMenuItem.Text = "微博资源";
            this.GetDataWeiboToolStripMenuItem.Click += new System.EventHandler(this.GetDataWeiboToolStripMenuItem_Click);
            // 
            // ImportDataToolStripMenuItem
            // 
            this.ImportDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportDataWeixinToolStripMenuItem1,
            this.ImportDataWeiboToolStripMenuItem1});
            this.ImportDataToolStripMenuItem.Name = "ImportDataToolStripMenuItem";
            this.ImportDataToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ImportDataToolStripMenuItem.Text = "导入数据";
            // 
            // ImportDataWeixinToolStripMenuItem1
            // 
            this.ImportDataWeixinToolStripMenuItem1.Name = "ImportDataWeixinToolStripMenuItem1";
            this.ImportDataWeixinToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.ImportDataWeixinToolStripMenuItem1.Text = "微信资源";
            // 
            // ImportDataWeiboToolStripMenuItem1
            // 
            this.ImportDataWeiboToolStripMenuItem1.Name = "ImportDataWeiboToolStripMenuItem1";
            this.ImportDataWeiboToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.ImportDataWeiboToolStripMenuItem1.Text = "微博资源";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWelcome,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelDataCheckStatus,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelOperateArea,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabelOpearteObjectType});
            this.statusStripMain.Location = new System.Drawing.Point(0, 539);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(784, 22);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelWelcome
            // 
            this.toolStripStatusLabelWelcome.Name = "toolStripStatusLabelWelcome";
            this.toolStripStatusLabelWelcome.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabelWelcome.Text = "欢迎使用管理面板";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "当前状态:";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.BackColor = System.Drawing.Color.YellowGreen;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelStatus.Text = "空闲";
            this.toolStripStatusLabelStatus.TextChanged += new System.EventHandler(this.toolStripStatusLabelStatus_TextChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel2.Text = "数据状态:";
            // 
            // toolStripStatusLabelDataCheckStatus
            // 
            this.toolStripStatusLabelDataCheckStatus.BackColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabelDataCheckStatus.Name = "toolStripStatusLabelDataCheckStatus";
            this.toolStripStatusLabelDataCheckStatus.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabelDataCheckStatus.Text = "未检查";
            this.toolStripStatusLabelDataCheckStatus.TextChanged += new System.EventHandler(this.toolStripStatusLabelDataCheckStatus_TextChanged);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "操作平台:";
            // 
            // toolStripStatusLabelOperateArea
            // 
            this.toolStripStatusLabelOperateArea.BackColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabelOperateArea.Name = "toolStripStatusLabelOperateArea";
            this.toolStripStatusLabelOperateArea.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabelOperateArea.Text = "无";
            this.toolStripStatusLabelOperateArea.TextChanged += new System.EventHandler(this.toolStripStatusLabelOperateArea_TextChanged);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel4.Text = "操作类别:";
            // 
            // toolStripStatusLabelOpearteObjectType
            // 
            this.toolStripStatusLabelOpearteObjectType.BackColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabelOpearteObjectType.Name = "toolStripStatusLabelOpearteObjectType";
            this.toolStripStatusLabelOpearteObjectType.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabelOpearteObjectType.Text = "无";
            this.toolStripStatusLabelOpearteObjectType.TextChanged += new System.EventHandler(this.toolStripStatusLabelOpearteObjectType_TextChanged);
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowMerge = false;
            this.toolStripMain.CanOverflow = false;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonUpdateData,
            this.toolStripButtonExportData,
            this.toolStripSeparator1,
            this.toolStripButtonDataCheck,
            this.toolStripButtonPreviousError,
            this.toolStripButtonNextError,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripTextBoxRecentPage,
            this.toolStripButtonPreviousPage,
            this.toolStripButtonNextPage,
            this.toolStripButtonGotoPage,
            this.toolStripSeparator3,
            this.toolStripButtonDelete,
            this.toolStripButtonUndelete,
            this.toolStripButtonAddInfo,
            this.toolStripButtonEdit,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripTextBoxKeyword,
            this.toolStripButtonSearch,
            this.toolStripButtonSearchPrevious,
            this.toolStripButtonSearchNext,
            this.toolStripSeparator5});
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(784, 25);
            this.toolStripMain.TabIndex = 2;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripButtonUpdateData
            // 
            this.toolStripButtonUpdateData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdateData.Image = global::CoolControlPanel.Properties.Resources.upload;
            this.toolStripButtonUpdateData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateData.Name = "toolStripButtonUpdateData";
            this.toolStripButtonUpdateData.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdateData.Text = "将数据更新到服务器";
            // 
            // toolStripButtonExportData
            // 
            this.toolStripButtonExportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportData.Enabled = false;
            this.toolStripButtonExportData.Image = global::CoolControlPanel.Properties.Resources.download;
            this.toolStripButtonExportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportData.Name = "toolStripButtonExportData";
            this.toolStripButtonExportData.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportData.Text = "导出数据";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDataCheck
            // 
            this.toolStripButtonDataCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDataCheck.Image = global::CoolControlPanel.Properties.Resources.warning;
            this.toolStripButtonDataCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDataCheck.Name = "toolStripButtonDataCheck";
            this.toolStripButtonDataCheck.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDataCheck.Text = "数据检查";
            // 
            // toolStripButtonPreviousError
            // 
            this.toolStripButtonPreviousError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPreviousError.Image = global::CoolControlPanel.Properties.Resources.left;
            this.toolStripButtonPreviousError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreviousError.Name = "toolStripButtonPreviousError";
            this.toolStripButtonPreviousError.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPreviousError.Text = "上一条错误";
            // 
            // toolStripButtonNextError
            // 
            this.toolStripButtonNextError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextError.Image = global::CoolControlPanel.Properties.Resources.right;
            this.toolStripButtonNextError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextError.Name = "toolStripButtonNextError";
            this.toolStripButtonNextError.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNextError.Text = "下一条错误";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "当前页：";
            // 
            // toolStripTextBoxRecentPage
            // 
            this.toolStripTextBoxRecentPage.Name = "toolStripTextBoxRecentPage";
            this.toolStripTextBoxRecentPage.Size = new System.Drawing.Size(30, 25);
            this.toolStripTextBoxRecentPage.Text = "1";
            this.toolStripTextBoxRecentPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolStripTextBoxRecentPage.ToolTipText = "共1页";
            this.toolStripTextBoxRecentPage.TextChanged += new System.EventHandler(this.toolStripTextBoxRecentPage_TextChanged);
            // 
            // toolStripButtonPreviousPage
            // 
            this.toolStripButtonPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPreviousPage.Image = global::CoolControlPanel.Properties.Resources.left;
            this.toolStripButtonPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreviousPage.Name = "toolStripButtonPreviousPage";
            this.toolStripButtonPreviousPage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPreviousPage.Text = "上一页";
            this.toolStripButtonPreviousPage.Click += new System.EventHandler(this.toolStripButtonPreviousPage_Click);
            // 
            // toolStripButtonNextPage
            // 
            this.toolStripButtonNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextPage.Image = global::CoolControlPanel.Properties.Resources.right;
            this.toolStripButtonNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNextPage.Name = "toolStripButtonNextPage";
            this.toolStripButtonNextPage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNextPage.Text = "下一页";
            this.toolStripButtonNextPage.Click += new System.EventHandler(this.toolStripButtonNextPage_Click);
            // 
            // toolStripButtonGotoPage
            // 
            this.toolStripButtonGotoPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGotoPage.Image = global::CoolControlPanel.Properties.Resources.cursor;
            this.toolStripButtonGotoPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGotoPage.Name = "toolStripButtonGotoPage";
            this.toolStripButtonGotoPage.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonGotoPage.Text = "跳转至";
            this.toolStripButtonGotoPage.Click += new System.EventHandler(this.toolStripButtonGotoPage_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::CoolControlPanel.Properties.Resources.x;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "toolStripButton1";
            this.toolStripButtonDelete.ToolTipText = "删除所选行";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonUndelete
            // 
            this.toolStripButtonUndelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndelete.Image = global::CoolControlPanel.Properties.Resources.unlock;
            this.toolStripButtonUndelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndelete.Name = "toolStripButtonUndelete";
            this.toolStripButtonUndelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUndelete.Text = "取消删除";
            this.toolStripButtonUndelete.Click += new System.EventHandler(this.toolStripButtonUndelete_Click);
            // 
            // toolStripButtonAddInfo
            // 
            this.toolStripButtonAddInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddInfo.Image = global::CoolControlPanel.Properties.Resources.add;
            this.toolStripButtonAddInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddInfo.Name = "toolStripButtonAddInfo";
            this.toolStripButtonAddInfo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddInfo.Text = "新增信息";
            this.toolStripButtonAddInfo.Click += new System.EventHandler(this.toolStripButtonAddInfo_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEdit.Image = global::CoolControlPanel.Properties.Resources.pencil;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEdit.Text = "修改所选单元格";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "关键词：";
            // 
            // toolStripTextBoxKeyword
            // 
            this.toolStripTextBoxKeyword.Name = "toolStripTextBoxKeyword";
            this.toolStripTextBoxKeyword.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::CoolControlPanel.Properties.Resources.search;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "搜索";
            this.toolStripButtonSearch.ToolTipText = "搜索";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonSearchPrevious
            // 
            this.toolStripButtonSearchPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchPrevious.Image = global::CoolControlPanel.Properties.Resources.left;
            this.toolStripButtonSearchPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchPrevious.Name = "toolStripButtonSearchPrevious";
            this.toolStripButtonSearchPrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchPrevious.Text = "上一个";
            this.toolStripButtonSearchPrevious.ToolTipText = "上一个";
            this.toolStripButtonSearchPrevious.Click += new System.EventHandler(this.toolStripButtonSearchPrevious_Click);
            // 
            // toolStripButtonSearchNext
            // 
            this.toolStripButtonSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchNext.Image = global::CoolControlPanel.Properties.Resources.right;
            this.toolStripButtonSearchNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchNext.Name = "toolStripButtonSearchNext";
            this.toolStripButtonSearchNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchNext.Text = "下一个";
            this.toolStripButtonSearchNext.Click += new System.EventHandler(this.toolStripButtonSearchNext_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToOrderColumns = true;
            this.dataGridViewMain.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowId,
            this.CoolId,
            this.AddOnId,
            this.CoolName,
            this.CoolType,
            this.Industry,
            this.AdRegion,
            this.DirectUse,
            this.CheckStatus,
            this.HandleType,
            this.HandleResult});
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 50);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(784, 489);
            this.dataGridViewMain.TabIndex = 3;
            this.dataGridViewMain.DoubleClick += new System.EventHandler(this.dataGridViewMain_DoubleClick);
            this.dataGridViewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewMain_KeyDown);
            // 
            // ShowId
            // 
            this.ShowId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowId.Frozen = true;
            this.ShowId.HeaderText = "编号";
            this.ShowId.Name = "ShowId";
            this.ShowId.ReadOnly = true;
            this.ShowId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShowId.ToolTipText = "数据显示编号";
            this.ShowId.Width = 55;
            // 
            // CoolId
            // 
            this.CoolId.Frozen = true;
            this.CoolId.HeaderText = "主表编号";
            this.CoolId.Name = "CoolId";
            this.CoolId.ReadOnly = true;
            this.CoolId.Visible = false;
            // 
            // AddOnId
            // 
            this.AddOnId.HeaderText = "附表编号";
            this.AddOnId.Name = "AddOnId";
            this.AddOnId.ReadOnly = true;
            this.AddOnId.Visible = false;
            // 
            // CoolName
            // 
            this.CoolName.Frozen = true;
            this.CoolName.HeaderText = "资源名称";
            this.CoolName.Name = "CoolName";
            this.CoolName.ReadOnly = true;
            // 
            // CoolType
            // 
            this.CoolType.HeaderText = "资源类型";
            this.CoolType.Name = "CoolType";
            this.CoolType.ReadOnly = true;
            // 
            // Industry
            // 
            this.Industry.HeaderText = "行业";
            this.Industry.Name = "Industry";
            this.Industry.ReadOnly = true;
            // 
            // AdRegion
            // 
            this.AdRegion.HeaderText = "区域";
            this.AdRegion.Name = "AdRegion";
            this.AdRegion.ReadOnly = true;
            // 
            // DirectUse
            // 
            this.DirectUse.HeaderText = "直投";
            this.DirectUse.Name = "DirectUse";
            this.DirectUse.ReadOnly = true;
            // 
            // CheckStatus
            // 
            this.CheckStatus.HeaderText = "检查状态";
            this.CheckStatus.Name = "CheckStatus";
            this.CheckStatus.ReadOnly = true;
            // 
            // HandleType
            // 
            this.HandleType.HeaderText = "处理方式";
            this.HandleType.Name = "HandleType";
            this.HandleType.ReadOnly = true;
            // 
            // HandleResult
            // 
            this.HandleResult.HeaderText = "处理结果";
            this.HandleResult.Name = "HandleResult";
            this.HandleResult.ReadOnly = true;
            // 
            // bgwMainServer
            // 
            this.bgwMainServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMainServer_DoWork);
            this.bgwMainServer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwMainServer_RunWorkerCompleted);
            // 
            // tbEdit
            // 
            this.tbEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbEdit.Location = new System.Drawing.Point(0, 489);
            this.tbEdit.Multiline = true;
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEdit.Size = new System.Drawing.Size(784, 50);
            this.tbEdit.TabIndex = 4;
            this.tbEdit.Visible = false;
            this.tbEdit.DoubleClick += new System.EventHandler(this.tbEdit_DoubleClick);
            // 
            // ControlPanelMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tbEdit);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "ControlPanelMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "资源库管理面板";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem GetDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetDataWeixinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetDataWeiboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataWeixinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ImportDataWeiboToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWelcome;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateData;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDataCheck;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreviousError;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDataCheckStatus;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddInfo;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKeyword;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchPrevious;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOperateArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoolId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddOnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoolType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Industry;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirectUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn HandleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HandleResult;
        private System.ComponentModel.BackgroundWorker bgwMainServer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOpearteObjectType;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxRecentPage;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreviousPage;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextPage;
        private System.Windows.Forms.ToolStripButton toolStripButtonGotoPage;
        private System.Windows.Forms.TextBox tbEdit;
    }
}

