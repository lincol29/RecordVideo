namespace RecordVideo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.vsp_Panel = new AForge.Controls.VideoSourcePlayer();
            this.btn_Connect = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.pb_BoxPanel = new System.Windows.Forms.PictureBox();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.btn_EndVideo = new CCWin.SkinControl.SkinButton();
            this.btn_PauseVideo = new CCWin.SkinControl.SkinButton();
            this.btn_OpenPath = new CCWin.SkinControl.SkinButton();
            this.btn_Save = new CCWin.SkinControl.SkinButton();
            this.lab_Time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Capture = new CCWin.SkinControl.SkinButton();
            this.btn_StartVideo = new CCWin.SkinControl.SkinButton();
            this.cb_CameraSelect = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cb_dpiSelect = new System.Windows.Forms.ComboBox();
            this.uiGroupBox1.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BoxPanel)).BeginInit();
            this.skinGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.vsp_Panel);
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vsp_Panel
            // 
            resources.ApplyResources(this.vsp_Panel, "vsp_Panel");
            this.vsp_Panel.Name = "vsp_Panel";
            this.vsp_Panel.VideoSource = null;
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Transparent;
            this.btn_Connect.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Connect.DownBack = null;
            resources.ApplyResources(this.btn_Connect, "btn_Connect");
            this.btn_Connect.MouseBack = null;
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.NormlBack = null;
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.DownBack = null;
            resources.ApplyResources(this.btn_Close, "btn_Close");
            this.btn_Close.MouseBack = null;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = null;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Red;
            this.skinGroupBox1.Controls.Add(this.pb_BoxPanel);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Fuchsia;
            resources.ApplyResources(this.skinGroupBox1, "skinGroupBox1");
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Red;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // pb_BoxPanel
            // 
            resources.ApplyResources(this.pb_BoxPanel, "pb_BoxPanel");
            this.pb_BoxPanel.Name = "pb_BoxPanel";
            this.pb_BoxPanel.TabStop = false;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Red;
            this.skinGroupBox2.Controls.Add(this.btn_EndVideo);
            this.skinGroupBox2.Controls.Add(this.btn_PauseVideo);
            this.skinGroupBox2.Controls.Add(this.btn_OpenPath);
            this.skinGroupBox2.Controls.Add(this.btn_Save);
            this.skinGroupBox2.Controls.Add(this.lab_Time);
            this.skinGroupBox2.Controls.Add(this.label2);
            this.skinGroupBox2.Controls.Add(this.btn_Capture);
            this.skinGroupBox2.Controls.Add(this.btn_StartVideo);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.DarkViolet;
            resources.ApplyResources(this.skinGroupBox2, "skinGroupBox2");
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Red;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btn_EndVideo
            // 
            this.btn_EndVideo.BackColor = System.Drawing.Color.Transparent;
            this.btn_EndVideo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_EndVideo.DownBack = null;
            resources.ApplyResources(this.btn_EndVideo, "btn_EndVideo");
            this.btn_EndVideo.MouseBack = null;
            this.btn_EndVideo.Name = "btn_EndVideo";
            this.btn_EndVideo.NormlBack = null;
            this.btn_EndVideo.UseVisualStyleBackColor = false;
            this.btn_EndVideo.Click += new System.EventHandler(this.btn_EndVideo_Click);
            // 
            // btn_PauseVideo
            // 
            this.btn_PauseVideo.BackColor = System.Drawing.Color.Transparent;
            this.btn_PauseVideo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_PauseVideo.DownBack = null;
            resources.ApplyResources(this.btn_PauseVideo, "btn_PauseVideo");
            this.btn_PauseVideo.MouseBack = null;
            this.btn_PauseVideo.Name = "btn_PauseVideo";
            this.btn_PauseVideo.NormlBack = null;
            this.btn_PauseVideo.UseVisualStyleBackColor = false;
            this.btn_PauseVideo.Click += new System.EventHandler(this.btn_PauseVideo_Click);
            // 
            // btn_OpenPath
            // 
            this.btn_OpenPath.BackColor = System.Drawing.Color.Transparent;
            this.btn_OpenPath.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_OpenPath.DownBack = null;
            resources.ApplyResources(this.btn_OpenPath, "btn_OpenPath");
            this.btn_OpenPath.MouseBack = null;
            this.btn_OpenPath.Name = "btn_OpenPath";
            this.btn_OpenPath.NormlBack = null;
            this.btn_OpenPath.UseVisualStyleBackColor = false;
            this.btn_OpenPath.Click += new System.EventHandler(this.btn_OpenPath_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Save.DownBack = null;
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.MouseBack = null;
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.NormlBack = null;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lab_Time
            // 
            resources.ApplyResources(this.lab_Time, "lab_Time");
            this.lab_Time.Name = "lab_Time";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btn_Capture
            // 
            this.btn_Capture.BackColor = System.Drawing.Color.Transparent;
            this.btn_Capture.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Capture.DownBack = null;
            resources.ApplyResources(this.btn_Capture, "btn_Capture");
            this.btn_Capture.MouseBack = null;
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.NormlBack = null;
            this.btn_Capture.UseVisualStyleBackColor = false;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // btn_StartVideo
            // 
            this.btn_StartVideo.BackColor = System.Drawing.Color.Transparent;
            this.btn_StartVideo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_StartVideo.DownBack = null;
            resources.ApplyResources(this.btn_StartVideo, "btn_StartVideo");
            this.btn_StartVideo.MouseBack = null;
            this.btn_StartVideo.Name = "btn_StartVideo";
            this.btn_StartVideo.NormlBack = null;
            this.btn_StartVideo.UseVisualStyleBackColor = false;
            this.btn_StartVideo.Click += new System.EventHandler(this.btn_StartVideo_Click);
            // 
            // cb_CameraSelect
            // 
            this.cb_CameraSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CameraSelect.FormattingEnabled = true;
            resources.ApplyResources(this.cb_CameraSelect, "cb_CameraSelect");
            this.cb_CameraSelect.Name = "cb_CameraSelect";
            this.cb_CameraSelect.SelectedIndexChanged += new System.EventHandler(this.cb_CameraSelect_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cb_dpiSelect
            // 
            this.cb_dpiSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dpiSelect.FormattingEnabled = true;
            resources.ApplyResources(this.cb_dpiSelect, "cb_dpiSelect");
            this.cb_dpiSelect.Name = "cb_dpiSelect";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cb_dpiSelect);
            this.Controls.Add(this.cb_CameraSelect);
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.uiGroupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 878, 490);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_BoxPanel)).EndInit();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBox1;
        private AForge.Controls.VideoSourcePlayer vsp_Panel;
        private CCWin.SkinControl.SkinButton btn_Connect;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton btn_Close;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private System.Windows.Forms.PictureBox pb_BoxPanel;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinButton btn_EndVideo;
        private CCWin.SkinControl.SkinButton btn_PauseVideo;
        private CCWin.SkinControl.SkinButton btn_Save;
        private System.Windows.Forms.Label lab_Time;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinButton btn_Capture;
        private CCWin.SkinControl.SkinButton btn_StartVideo;
        private System.Windows.Forms.ComboBox cb_CameraSelect;
        private System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinButton btn_OpenPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_dpiSelect;
    }
}

