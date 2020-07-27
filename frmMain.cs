using System;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace WatchNyan
{
    public partial class frmMain : Form
    {
        //工作路径、配置文件路径
        string currentPath = Environment.CurrentDirectory + @"\";
        //当前扫描起始偏移量
        long currentOffset = 0;
        //某关键字是否已给出提示，当为true时不重复提示
        bool[] isKeywordPrompted;
        //某关键字的全行内容
        string[] keywordFullLine;
        //Minecraft样式代码前导符『§』正则匹配对象
        Regex mcFormatCodeRegex = new Regex("§[a-zA-Z0-9]");
        //提示内容提交给远端 API 的地址及密钥
        string notify_remoteAPI = string.Empty;
        string notify_remoteAPIsecret = string.Empty;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadSettings();
            writeLog("程序启动");
        }

        //关闭窗口时如果正在监视，缩小到通知区域
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tmrChecker.Enabled == true)
            {
                this.Hide();
                e.Cancel = true;
            }
            else
            {
                saveSettings();
            }
        }

        //通知图标双击
        private void trayIco_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        //选中来源为本地文件时，启用文件编码等选项
        private void optMonitorOn_Local_CheckedChanged(object sender, EventArgs e)
        {
            if(optMonitorOn_Local.Checked)
            {
                txtInputFile.Enabled = true;
                txtInputAPI.Enabled = false;
                txtInputAPISecret.Enabled = false;
                lstKeyword.Enabled = true;
                grpEncoding.Enabled = true;
                grpOffset.Enabled = true;
                txtInstanceTag.Enabled = true;
            }
        }

        //选中来源为API时，禁用无关选项
        private void optMonitorOn_Remote_CheckedChanged(object sender, EventArgs e)
        {
            if(optMonitorOn_Remote.Checked)
            {
                txtInputFile.Enabled = false;
                txtInputAPI.Enabled = true;
                txtInputAPISecret.Enabled = true;
                lstKeyword.Enabled = false;
                grpEncoding.Enabled = false;
                grpOffset.Enabled = false;
                txtInstanceTag.Enabled = false;
            }
        }

        //打开文件
        private void btnSelectInputFile_Click(object sender, EventArgs e)
        {
            if (cmdOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //如果已有项目，查找对应的列表项
                if (txtInputFile.Items.Count > 0)
                {
                    string cmdFNlower = cmdOpen.FileName.ToLower().Trim();
                    string lstFNlower; bool found = false;
                    //这里不直接使用 ComboBox.Items.IndexOf 是因为 Windows 路径大小写通吃，但列表项匹配区分
                    for (int idx = 0; idx < txtInputFile.Items.Count; idx++)
                    {
                        lstFNlower = txtInputFile.Items[idx].ToString().ToLower().Trim();
                        if (cmdFNlower == lstFNlower) { txtInputFile.SelectedIndex = idx; found = true; break; }
                    }
                    //没找到的话，新增列表项并选中
                    if (found == false)
                    {
                        txtInputFile.Items.Add(cmdOpen.FileName); txtInputFile.SelectedIndex = txtInputFile.Items.Count - 1;
                    }
                }
                //否则，新增唯一列表项
                else
                {
                    txtInputFile.Items.Add(cmdOpen.FileName);
                    txtInputFile.SelectedIndex = 0;
                }
            }
        }

        //关键字列表右键菜单打开事件，如果有选中项则启用『修改』和『删除』，否则禁用
        private void mnuKeyword_Opened(object sender, EventArgs e)
        {
            if (lstKeyword.SelectedItems.Count > 0)
            { mnuKeyword_Modify.Enabled = true; mnuKeyword_Remove.Enabled = true; }
            else { mnuKeyword_Modify.Enabled = false; mnuKeyword_Remove.Enabled = false; }
        }

        //添加关键字
        private void mnuKeyword_Add_Click(object sender, EventArgs e)
        {
            frmKeyword kwForm = new frmKeyword("新增关键字", string.Empty, string.Empty, string.Empty);
            kwForm.ShowDialog();
            if (kwForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(kwForm.kw1) && string.IsNullOrEmpty(kwForm.kw2)) return;
                string[] data = new string[3];
                data[0] = kwForm.kw1.Trim();
                data[1] = kwForm.kw2.Trim();
                data[2] = string.IsNullOrEmpty(kwForm.showFullLine) ? string.Empty : "√";
                ListViewItem lvi = new ListViewItem(data);
                lstKeyword.Items.Add(lvi);
            }
        }

        //修改关键字
        private void mnuKeyword_Modify_Click(object sender, EventArgs e)
        {
            if (lstKeyword.SelectedItems.Count < 1) return;
            ListViewItem lvSI = lstKeyword.SelectedItems[0];
            frmKeyword kwForm = new frmKeyword("修改关键字", lvSI.SubItems[0].Text, lvSI.SubItems[1].Text, lvSI.SubItems[2].Text);
            kwForm.ShowDialog();
            if (kwForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(kwForm.kw1) && string.IsNullOrEmpty(kwForm.kw2)) return;
                string[] data = new string[3];
                data[0] = kwForm.kw1.Trim(); 
                data[1] = kwForm.kw2.Trim(); 
                data[2] = kwForm.showFullLine;
                lvSI.SubItems[0].Text = data[0]; 
                lvSI.SubItems[1].Text = data[1];
                lvSI.SubItems[2].Text = string.IsNullOrEmpty(data[2]) ? "" : "√";
            }
        }

        //删除关键字
        private void mnuKeyword_Remove_Click(object sender, EventArgs e)
        {
            if (lstKeyword.SelectedItems.Count < 1) return;
            ListViewItem lvSI = lstKeyword.SelectedItems[0];
            if (MessageBox.Show("确认要删除选中的关键字吗？", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                lstKeyword.Items.Remove(lvSI);
            }
        }

        //启动/停止监听
        private void btnDo_Click(object sender, EventArgs e)
        {
            //检查是否指定了目标文件
            if (optMonitorOn_Local.Checked && string.IsNullOrEmpty(txtInputFile.Text) ) { MessageBox.Show("没有指定要监听的文件！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            //如果监听目标是远端 API，检查是否填写了完整的参数
            if (optMonitorOn_Remote.Checked && string.IsNullOrEmpty(txtInputAPI.Text)) { MessageBox.Show("没有指定要监听的API地址！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            if (optMonitorOn_Remote.Checked && string.IsNullOrEmpty(txtInputAPISecret.Text)) { MessageBox.Show("没有指定要监听的API Secret！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            //检查是否设置了监听关键字
            if (lstKeyword.Items.Count < 1) { MessageBox.Show("没有设置监听关键字！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            //检查如果启用了提交到 API，是否设置了 API 地址和 Secret
            if(chkNotify_API.Checked)
            {
                if(string.IsNullOrEmpty(notify_remoteAPI) || string.IsNullOrEmpty(notify_remoteAPIsecret) || 
                    (notify_remoteAPI.ToLower().StartsWith("http://") == false &&
                    notify_remoteAPI.ToLower().StartsWith("https://") == false))
                {
                    MessageBox.Show("提交通知的 API 信息未设置，或者格式无效，请检查！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                }
            }
            //如果监听目标是远端 API，则不能再传递给另一个 API，避免套娃
            if (optMonitorOn_Remote.Checked) chkNotify_API.Checked = false;
            //检查采样间隔
            if (txtInterval.Value < 5 || txtInterval.Value > 60) { MessageBox.Show("采样间隔不正确，范围应为 5 到 60 秒！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            //保存配置信息
            saveSettings();
            //切换工作状态
            toggleWorkStatus();
        }

        //设置提醒方式的远端 API 地址
        private void btnNotify_APIurl_Click(object sender, EventArgs e)
        {
            notify_remoteAPI = Interaction.InputBox("请输入提交提醒所使用的 API 地址", "设置", notify_remoteAPI);
            notify_remoteAPIsecret = Interaction.InputBox("请输入提交提醒所使用的 API Secret", "设置", notify_remoteAPIsecret);
        }

        //初始化窗体
        private void InitializeForm()
        {
            this.Icon = Properties.Resources.appico;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            txtInputFile.DropDownStyle = ComboBoxStyle.DropDownList;
            optMonitorOn_Local.Checked = true;
            lstKeyword.MultiSelect = false;
            lstKeyword.Items.Clear();
            lstKeyword.ContextMenuStrip = mnuKeyword;
            chkNotify_TrayBubble.Checked = true;
            chkNotify_OpenWnd.Checked = true;
            cmdOpen.Title = "选择要打开的文件...";
            cmdOpen.Filter = "常用文件类型 (*.txt, *.log)|*.txt;*.log|所有文件 (*.*)|*.*";
            cmdOpen.FileName = string.Empty;
            cmdOpen.Multiselect = false;
            txtInterval.Minimum = 5;
            txtInterval.Maximum = 60;
            txtInterval.Value = 5;
            trayIco.Text = "自在观喵";
            trayIco.Icon = this.Icon;
            trayIco.Visible = true;
        }

        //监听循环
        private void tmrChecker_Tick(object sender, EventArgs e)
        {
            if (optMonitorOn_Local.Checked)
            {
                //本地文件模式
                //每时每刻确认文件存在情况，如果文件不存在立刻停止
                if (File.Exists(txtInputFile.Text) == false) { toggleWorkStatus(); }
                string currentContent = string.Empty; string[] currentLines;
                //初始化剩余字节数计数器，并获取当前文件大小
                long remainLen = 0;
                FileInfo fi = new FileInfo(txtInputFile.Text);
                /* 工作模式：从开头扫描 */
                if (optStartFrom_Begining.Checked == true)
                {
                    remainLen = fi.Length;
                }
                /* 工作模式：从末尾扫描 */
                if (optStartFrom_End.Checked == true)
                {
                    //求得剩余大小
                    remainLen = fi.Length - currentOffset;
                    //如果剩余大小为 0，表示没有新增内容，如果为负数，表明文件内容减少了，重置偏移量并进入下一个循环
                    if (remainLen == 0) return;
                    if (remainLen < 0) { currentOffset = fi.Length; return; }
                }
                //读入指定偏移量起的剩余内容
                using (BinaryReader reader = new BinaryReader(new FileStream(txtInputFile.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    byte[] data = new byte[remainLen];
                    reader.BaseStream.Seek(currentOffset, SeekOrigin.Begin);
                    reader.Read(data, 0, (int)remainLen);
                    System.Diagnostics.Debug.Print(DateTime.Now.ToString());
                    if (optEncoding_ANSI.Checked == true) { System.Diagnostics.Debug.Print(System.Text.Encoding.GetEncoding("GB2312").GetString(data)); }
                    else { System.Diagnostics.Debug.Print(System.Text.Encoding.UTF8.GetString(data)); }
                    if (optEncoding_ANSI.Checked == true) currentContent = System.Text.Encoding.GetEncoding("GB2312").GetString(data);
                    if (optEncoding_UTF8.Checked == true) currentContent = System.Text.Encoding.UTF8.GetString(data);
                }
                //将读入的内容拆行
                currentLines = currentContent.Split('\n');
                //搜索关键字
                foreach (string line in currentLines)
                {
                    for (int lviidx = 0; lviidx < lstKeyword.Items.Count; lviidx++)
                    {
                        if (line.Contains(lstKeyword.Items[lviidx].SubItems[0].Text)
                            && line.Contains(lstKeyword.Items[lviidx].SubItems[1].Text))
                        {
                            //发现关键字，设置标志位以供稍后给出提示
                            isKeywordPrompted[lviidx] = true;
                            //如果该关键字设置了显示全行内容，则将全行内容暂存，否则，设置空的索引项
                            if (string.IsNullOrEmpty(lstKeyword.Items[lviidx].SubItems[2].Text) == false)
                            {
                                keywordFullLine[lviidx] = mcFormatCodeRegex.Replace(line, string.Empty);
                            }
                            else { keywordFullLine[lviidx] = string.Empty; }
                        }
                    }
                }
                //清除缓存
                currentContent = string.Empty;
                Array.Clear(currentLines, 0, currentLines.Length);
                //如果是从末尾扫描模式，设置新的偏移量
                if (optStartFrom_End.Checked == true) currentOffset = fi.Length;
                txtCurrentOffset.Text = currentOffset.ToString();
                //依照扫描结果，给出提示
                for (int kwidx = 0; kwidx < isKeywordPrompted.Length; kwidx++)
                {
                    if (isKeywordPrompted[kwidx] == true)
                    {
                        makePrompt(lstKeyword.Items[kwidx].SubItems[0].Text, lstKeyword.Items[kwidx].SubItems[1].Text, lstKeyword.Items[kwidx].SubItems[2].Text, keywordFullLine[kwidx]);
                        isKeywordPrompted[kwidx] = false;
                    }
                }
            }
            else
            {
                //远端 API 模式
                string r = httpPost(txtInputAPI.Text, txtInputAPISecret.Text, "action=fetch");
                if (string.IsNullOrEmpty(r) == false)
                {
                    string[] lns = r.Split('\n');
                    string[] ln_parts;
                    StringBuilder output = new StringBuilder();
                    foreach(string ln in lns)
                    {
                        ln_parts = ln.Split('|');
                        if (ln_parts.Length != 2) continue;
                        output.AppendLine("【" + fromTimestamp(ln_parts[0]) + "】" + ln_parts[1]);
                    }
                    if (output.Length > 0)
                    {
                        //写日志
                        writeLog("远端 API 下发消息：" + output.ToString());
                        //弹出新窗口
                        if (chkNotify_OpenWnd.Checked) MessageBox.Show("来自 API 的新消息：\r\n" + output.ToString(), "新消息！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //气泡通知
                        if (chkNotify_TrayBubble.Checked) trayIco.ShowBalloonTip(30000, "新消息！", "来自 API 的新消息：\r\n" + output.ToString(), ToolTipIcon.Info);
                        //传递给远程 API：没这回事，禁止套娃
                    }
                }
            }
        }

        //读取配置文件
        private void LoadSettings()
        {
            string settingsFile = currentPath + "settings.xml";
            if (File.Exists(settingsFile) == true)
            {
                try
                {
                    XmlNodeList xNL;
                    XmlDocument x = new XmlDocument(); x.Load(settingsFile);
                    //加载最近使用的来源类型（升级配置）
                    XmlNode xN_RecentType = x.SelectSingleNode("/Settings/RecentType");
                    if (!(xN_RecentType is null))
                    {
                        if (xN_RecentType.Attributes["value"] == null) { optMonitorOn_Local.Checked = true; }
                        else
                        {
                            switch (xN_RecentType.Attributes["value"].InnerText)
                            {
                                case "0": optMonitorOn_Local.Checked = true; break;
                                case "1": optMonitorOn_Remote.Checked = true; break;
                                default: optMonitorOn_Local.Checked = true; break;
                            }
                        }
                    }
                    else
                    {
                        optMonitorOn_Local.Checked = true;
                    }
                    //加载最近文件列表
                    xNL = x.SelectNodes("/Settings/RecentFiles/RecentFile");
                    if (xNL.Count > 0)
                    {
                        //只有检测为存在的文件才会被加入列表
                        foreach (XmlNode xN in xNL)
                        { if (File.Exists(xN.InnerText)) txtInputFile.Items.Add(xN.InnerText); }
                    }
                    //加载远端API地址（升级配置）
                    XmlNode xN_RecentAPI = x.SelectSingleNode("/Settings/RecentAPI");
                    if ((xN_RecentAPI is null) == false)
                    {
                        if (!(xN_RecentAPI.Attributes["url"] is null)) txtInputAPI.Text = xN_RecentAPI.Attributes["url"].InnerText;
                        if (!(xN_RecentAPI.Attributes["secret"] is null)) txtInputAPISecret.Text = xN_RecentAPI.Attributes["secret"].InnerText;
                    }
                    //加载关键字列表，及是否显示全行内容
                    xNL = x.SelectNodes("/Settings/Keywords/Keyword");
                    if (xNL.Count > 0)
                    {
                        string[] kwData;
                        foreach (XmlNode xN in xNL) 
                        {
                            kwData = new string[3];
                            kwData[0] = xN.Attributes["kwA"].InnerText.Trim();
                            kwData[1] = xN.Attributes["kwB"].InnerText.Trim();
                            //兼容上一版配置文件，当fullLine属性不存在时，视为显示全行为 False
                            if (xN.Attributes["fullLine"] == null)
                            {
                                kwData[2] = string.Empty;
                            }
                            else
                            {
                                kwData[2] = bool.Parse(xN.Attributes["fullLine"].InnerText) == true ? "√" : string.Empty;
                            }
                            ListViewItem lvi = new ListViewItem(kwData);
                            lstKeyword.Items.Add(lvi);
                        }
                    }
                    //加载其它选项
                    optEncoding_ANSI.Checked = bool.Parse(x.SelectSingleNode("/Settings/UseANSIEncoding").Attributes["value"].InnerText);
                    optStartFrom_End.Checked = bool.Parse(x.SelectSingleNode("/Settings/ScanFromEnd").Attributes["value"].InnerText);
                    chkNotify_OpenWnd.Checked = bool.Parse(x.SelectSingleNode("/Settings/PromptMsgbox").Attributes["value"].InnerText);
                    chkNotify_TrayBubble.Checked = bool.Parse(x.SelectSingleNode("/Settings/PromptTrayNotification").Attributes["value"].InnerText);
                    //提示方式：远端 API（升级配置）
                    XmlNode xN_promptAPI = x.SelectSingleNode("/Settings/PromptRemoteAPI");
                    if(!(xN_promptAPI is null))
                    {
                        chkNotify_API.Checked = bool.Parse(xN_promptAPI.Attributes["value"].InnerText);
                        notify_remoteAPI = xN_promptAPI.Attributes["api"].InnerText;
                        notify_remoteAPIsecret = xN_promptAPI.Attributes["api_secret"].InnerText;
                    }
                    txtInterval.Value = int.Parse(x.SelectSingleNode("/Settings/ScanInterval").Attributes["value"].InnerText);
                }
                catch
                {
                    this.Text = this.Text + "（配置加载失败）";
                }
            }
        }

        private void saveSettings()
        {
            string settingsFile = currentPath + "settings.xml";
            //试写配置文件，不能保存则报错，且不继续保存过程
            try
            {
                File.WriteAllText(settingsFile, string.Empty, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("尝试写配置文件失败，设置将不会保存。\r\n异常信息：" + ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            StringBuilder output = new StringBuilder();
            //组合配置文件数据
            output.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            output.AppendLine("<Settings>");
            output.AppendLine("<RecentType value=\"" + (optMonitorOn_Local.Checked ? "0" : "1") + "\" />");
            output.AppendLine("<RecentFiles>");
            if (txtInputFile.Items.Count > 0)
            {
                foreach (string f in txtInputFile.Items)
                {
                    output.AppendLine("<RecentFile>" + f + "</RecentFile>");
                }
            }
            output.AppendLine("</RecentFiles>");
            output.AppendLine("<RecentAPI url=\"" + txtInputAPI.Text + "\" secret=\"" + txtInputAPISecret.Text + "\" />");
            output.AppendLine("<Keywords>");
            if (lstKeyword.Items.Count > 0)
            {
                foreach (ListViewItem lvi in lstKeyword.Items)
                {
                    output.AppendLine("<Keyword kwA=\"" + lvi.SubItems[0].Text + "\" kwB=\"" + lvi.SubItems[1].Text + "\" fullLine=\"" + (string.IsNullOrEmpty(lvi.SubItems[2].Text) ? "false" : "true") + "\"/>");
                }
            }
            output.AppendLine("</Keywords>");
            output.AppendLine("<UseANSIEncoding value=\"" + optEncoding_ANSI.Checked.ToString() + "\"/>");
            output.AppendLine("<ScanFromEnd value=\"" + optStartFrom_End.Checked.ToString() + "\"/>");
            output.AppendLine("<PromptMsgbox value=\"" + chkNotify_OpenWnd.Checked.ToString() + "\"/>");
            output.AppendLine("<PromptTrayNotification value=\"" + chkNotify_TrayBubble.Checked.ToString() + "\"/>");
            output.AppendLine("<PromptRemoteAPI value=\"" + chkNotify_API.Checked.ToString() + "\" api=\"" + notify_remoteAPI + "\" api_secret=\"" + notify_remoteAPIsecret + "\" />");
            output.AppendLine("<ScanInterval value=\"" + txtInterval.Value.ToString() + "\"/>");
            output.AppendLine("</Settings>");
            //写入配置文件
            try
            {
                File.WriteAllText(settingsFile, output.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("尝试写配置文件失败，设置未能保存。\r\n异常信息：" + ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        //切换控件可用性
        private void toggleControlEnabled()
        {
            grpInput.Enabled = !grpInput.Enabled;
            lstKeyword.Enabled = grpInput.Enabled;
            grpEncoding.Enabled = grpInput.Enabled;
            grpOffset.Enabled = grpInput.Enabled;
            grpPromptMethod.Enabled = grpInput.Enabled;
            txtInputFile.Enabled = grpInput.Enabled;
            txtInstanceTag.Enabled = grpInput.Enabled;
            txtInterval.Enabled = grpInput.Enabled;
        }

        //切换监听状态
        private void toggleWorkStatus()
        {
            if (tmrChecker.Enabled == false)
            {
                //初始化关键字提示状态数组
                isKeywordPrompted = new bool[lstKeyword.Items.Count];
                //初始化整行内容暂存数组
                keywordFullLine = new string[lstKeyword.Items.Count];
                //设置采样间隔
                tmrChecker.Interval = (int)txtInterval.Value * 1000;
                //设置起始偏移量
                if (optMonitorOn_Local.Checked)
                {
                    if (optStartFrom_End.Checked == true) { FileInfo fi = new FileInfo(txtInputFile.Text); currentOffset = fi.Length; }
                    else { currentOffset = 0; }
                    txtCurrentOffset.Text = currentOffset.ToString();
                }
                else
                {
                    currentOffset = 0;
                    txtCurrentOffset.Text = "-";
                }
                //设置按钮文字，启动监视
                btnDo.Text = "停止监听";
                tmrChecker.Enabled = true;
            }
            else { tmrChecker.Enabled = false; btnDo.Text = "开始监听"; }
            toggleControlEnabled();
            if (optMonitorOn_Local.Checked)
            {
                //文件如果已不存在，会由 Timer 调用本方法停止监视，但提示需要做在这里，否则会一直提示
                if (File.Exists(txtInputFile.Text) == false)
                {
                    MessageBox.Show("目标文件已不存在，监听停止！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tmrChecker.Enabled = false; btnDo.Text = "开始监听";
                }
            }
        }

        //写日志
        private void writeLog(string s) {
            lstLog.Items.Add("[" + DateTime.Now.ToString("yyyy/mm/dd HH:mm:ss") + "] " + s);
            if (lstLog.Items.Count > 0) lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        //发出提示
        private void makePrompt(string kw1, string kw2, string showFullLine, string fullLine)
        {
            DateTime currentTime = DateTime.Now;
            if (chkNotify_TrayBubble.Checked == true)
            {
                //气泡通知
                trayIco.ShowBalloonTip(30000, "发现关键字！", "关键字 = " + kw1 +
                                                             "\r\n配合关键字 = " + kw2 +
                                                             (string.IsNullOrEmpty(showFullLine) == true ? string.Empty : "\r\n整行内容 = " + fullLine) +
                                                             "\r\n时间 = " + currentTime.ToString("HH:mm:ss") +
                                                             "\r\n实例标识 = " + (string.IsNullOrEmpty(txtInstanceTag.Text) ? "（未设置）" : txtInstanceTag.Text),
                                                             ToolTipIcon.Info);
            }
            if (chkNotify_OpenWnd.Checked == true)
            {
                //弹出窗口
                MessageBox.Show("关键字 = " + kw1 +
                                "\r\n配合关键字 = " + kw2 +
                                (string.IsNullOrEmpty(showFullLine) == true ? string.Empty : "\r\n整行内容 = " + fullLine) +
                                "\r\n时间 = " + currentTime.ToString("HH:mm:ss") +
                                "\r\n实例标识 = " + (string.IsNullOrEmpty(txtInstanceTag.Text) ? "（未设置）" : txtInstanceTag.Text),
                                "发现关键字！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (chkNotify_API.Checked == true)
            {
                //提交给远程 API
                string r = httpPost(notify_remoteAPI, notify_remoteAPIsecret, "action=update&text=" + HttpUtility.UrlEncode("关键字：" + kw1 + "，配合关键字：" + kw2));
                if (r == "ok") { writeLog("提交给远程 API 成功"); }
                else { writeLog("提交给远程 API 时发生错误：" + (string.IsNullOrEmpty(r) ? "服务器返回为空" : r)); }
            }
        }

        //远端 API POST 操作
        private string httpPost(string apiUrl, string apiSecret, string otherArgs)
        {
            try
            {
                HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(apiUrl);
                wReq.Method = "POST";
                wReq.Timeout = 5000;
                wReq.ReadWriteTimeout = 5000;
                wReq.ContentType = "application/x-www-form-urlencoded";
                otherArgs += "&key=" + apiSecret;
                byte[] postByte = Encoding.UTF8.GetBytes(otherArgs);
                Stream postStream = wReq.GetRequestStream();
                postStream.Write(postByte, 0, postByte.Length);
                postStream.Close();
                WebResponse wResp = wReq.GetResponse(); return new StreamReader(wResp.GetResponseStream()).ReadToEnd();
            }
            catch(Exception ex) {
                writeLog("HTTP POST 失败：" + ex.Message);
                return string.Empty;
            }
        }

        //将时间戳转换为 DateTime
        private DateTime fromTimestamp(string ts)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToInt64(ts)).AddHours(8);
        }

    }
}
