#region << Lincol29 https://www.lincol29.cn>>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 命名空间：RecordVideo
 * 文件名：Class1
 * 
 * 创建者：Lincol29
 * 电子邮箱：eeeg72848@gmail.com
 * 个人Blog：https://www.lincol29.cn
 * 创建时间：2024/10/6 09:37:25
 *----------------------------------------------------------------*/
#endregion << Lincol29 https://www.lincol29.cn >>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;
using AForge.Video.FFMPEG;
using AForge.Video;
using Sunny.UI;
using System.Threading;
using System.IO;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using VideoFileWriter = Accord.Video.FFMPEG.VideoFileWriter;
using CCWin.Win32.Const;
using AForge.Controls;
using Accord;

namespace RecordVideo
{
    public partial class Form1 : UIForm
    {
        public Form1()
        {
            InitializeComponent();          
        }

        #region 字段

        /// <summary>
        /// 设备源
        /// 用来操作摄像头
        /// </summary>
        private AForge.Video.DirectShow.VideoCaptureDevice sourceDevice;

        /// <summary>
        /// 摄像头设备集合
        /// </summary>
        private AForge.Video.DirectShow.FilterInfoCollection infoCollection;

        /// <summary>
        /// 用与把每一帧图像写入到视频文件
        /// </summary>
        //private AForge.Video.FFMPEG.VideoFileWriter videoWriter;

        private VideoFileWriter videoWriter;

        /// <summary>
        /// 图片
        /// </summary>
        private System.Drawing.Bitmap imgMap;

        /// <summary>
        /// 文件保存路径
        /// </summary>
        private string fileDirectory = "D:\\SaveVideo\\";  //AppDomain.CurrentDomain.BaseDirectory

        /// <summary>
        /// 日期目录
        /// </summary>
        private string dateDirectory;

        /// <summary>
        /// 文件名称
        /// </summary>
        private readonly string fileName = $"{DateTime.Now.ToString("yyyyMMddhh")}";

        

        /// <summary>
        /// 停止录像
        /// </summary>
        private Stopwatch stopWatch;

        /// <summary>
        /// 写入次数
        /// </summary>
        private int tick_num = 0;

        /// <summary>
        /// 录制多少小时,只是为了定时间计算录制时间使用
        /// </summary>
        private int Hour = 0;

        /// <summary>
        /// 计时器
        /// </summary>
        private System.Timers.Timer timer_count;

        private System.Timers.Timer deleteTimer;

        private System.Timers.Timer showTimer;

        private string hour;

        #endregion

        #region 窗口加载与关闭
        /// <summary>
        /// 讲题加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitCamera();
            InitCameraSelect();
            InitCameraDpi();
            this.btn_Capture.Enabled = false;
            this.btn_Save.Enabled = false;
            this.pb_BoxPanel.SizeMode = PictureBoxSizeMode.Zoom;//图片大小按比例适应控件，不加的话图片显示问题太大
                                                                //this.skinGroupBox1.Visible = false;//默认不显示照片区域，拍照时在显示
                                                                //秒表
            timer_count = new System.Timers.Timer(1000);   //实例化Timer类，设置间隔时间为1000毫秒；
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);   //到达时间的时候执行事件；
            timer_count.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；    

            deleteTimer = new System.Timers.Timer(60000); //一分钟检测一次，超过时间则清理
            deleteTimer.Elapsed += DeleteTimer_Elapsed;
            deleteTimer.AutoReset = true;
            deleteTimer.Enabled = true;

        }

        /// <summary>
        /// 窗口关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndCamera();
            deleteTimer.Enabled = false;
        }

        #endregion

        #region 实例化摄像头
        /// <summary>
        /// 实例化摄像头
        /// </summary>
        public void InitCamera()
        {
            try
            {
                //检测电脑上的摄像头设备
                infoCollection = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"没有找到设备:{ex.Message}", "Error");
            }

        }
        //加载摄像头选择
        public void InitCameraSelect()
        {
            this.cb_CameraSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            //根据读取到的摄像头加载选择项
            foreach (AForge.Video.DirectShow.FilterInfo item in infoCollection)
            {
                this.cb_CameraSelect.Items.Add(item.Name);
            }
            if (this.cb_CameraSelect.Items.Count != 0)
            {
                this.cb_CameraSelect.SelectedIndex = 0;
            }
        }

        //加载摄像头分辨率
        public void InitCameraDpi()
        {
            cb_dpiSelect.Items.Clear();
            //获得摄像头设备
            sourceDevice = new AForge.Video.DirectShow.VideoCaptureDevice(infoCollection[this.cb_CameraSelect.SelectedIndex].MonikerString);
            //取得摄像头支持的所有属性
            VideoCapabilities[] s = sourceDevice.VideoCapabilities;
            foreach (VideoCapabilities capabilitie in s)
            {
                //处理数据
                if (capabilitie.FrameSize.Width == 2560 && capabilitie.FrameSize.Height == 1440)
                {
                    this.cb_dpiSelect.Items.Add("2K分辨率");
                }
                if (capabilitie.FrameSize.Width == 1920 && capabilitie.FrameSize.Height == 1080)
                {
                    this.cb_dpiSelect.Items.Add("1080P");
                }
                if (capabilitie.FrameSize.Width == 1280 && capabilitie.FrameSize.Height == 720)
                {
                    this.cb_dpiSelect.Items.Add("720P");
                }
                if (capabilitie.FrameSize.Width == 640 && capabilitie.FrameSize.Height == 480)
                {
                    this.cb_dpiSelect.Items.Add("480P");
                }
            }
            if (this.cb_dpiSelect.Items.Count != 0 && this.cb_dpiSelect.Items.Contains("1080P"))
            {
                this.cb_dpiSelect.Text = "1080P";
            }
            else if(this.cb_dpiSelect.Items.Count != 0 && this.cb_dpiSelect.Items.Contains("480P"))
            {
                this.cb_dpiSelect.Text = "480P";
            }
        }

        private int width;
        private int height;


        private int SelectDpi()
        {
            switch (this.cb_dpiSelect.Text.Trim())
            {
                case "2K分辨率":
                    width = 2560; height = 1440;
                    break;
                case "1080P":
                    width = 1920; height = 1080;
                    break;
                case "720P":
                    width = 1280; height = 720;
                    break;
                case "480P":
                    width = 640; height = 480;
                    break;
                default:
                    width = 640; height = 480;
                    break;
            }
            return height;
        }


        #endregion

        #region  摄像头的连接读取与关闭
        /// <summary>
        /// 连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //已有连接的摄像头时先关闭(只有一个摄像头，暂且不使用)
            if (this.vsp_Panel.VideoSource != null || sourceDevice != null)
            {
                EndCamera();
            }
            sourceDevice = new AForge.Video.DirectShow.VideoCaptureDevice(infoCollection[this.cb_CameraSelect.SelectedIndex].MonikerString);
            //启动摄像头                    
            //设置控件播放的视频源  不会直接从摄像头捕获视频，而是接受来自其他视频源的流，比如文件或网络。它是一个用于显示视频的控件，但它并不负责从摄像头中捕获视频。
            this.vsp_Panel.VideoSource = sourceDevice;
            this.vsp_Panel.Start();

            CameraDpi();
            //this.vsp_Panel.Start();
            this.btn_Capture.Enabled = true;
            this.btn_Save.Enabled = false;
        }

        private void CameraDpi()
        {
            var dpi = SelectDpi();
            int index = 0;
            foreach (VideoCapabilities capabilitie in sourceDevice.VideoCapabilities)
            {

                if (capabilitie.FrameSize.Height != dpi)
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
            //在start前指定分辨率
            sourceDevice.VideoResolution = sourceDevice.VideoCapabilities[index];
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            EndCamera();
            this.vsp_Panel.VideoSource = null;
        }
        /// <summary>
        /// 关闭摄像头
        /// </summary>
        public void EndCamera()
        {
            if (this.vsp_Panel.VideoSource != null || sourceDevice != null)
            {
                //也可以用 Stop() 方法关闭
                //指示灯停止且等待
                this.vsp_Panel.SignalToStop();
                //停止且等待
                this.vsp_Panel.WaitForStop();
                //this.vsp_Panel.VideoSource = null;
                sourceDevice.SignalToStop();
                sourceDevice.WaitForStop();
                if (videoWriter != null)
                {
                    videoWriter.Close();
                }
                timer1.Enabled = false;
                timer_count.Enabled = false;
            }
        }
        #endregion

        #region 拍照与保存
        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Capture_Click(object sender, EventArgs e)
        {
            imgMap = this.vsp_Panel.GetCurrentVideoFrame();
            this.skinGroupBox1.Visible = true;
            this.pb_BoxPanel.Image = imgMap;
            this.btn_Save.Enabled = true;
        }
        /// <summary>
        /// 保存照片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            CreateCatalog();
            var saveName = $"{dateDirectory}{DateTime.Now.ToString("HH")}.jpg";
            try
            {
                this.pb_BoxPanel.Image.Save(saveName);
            }
            catch
            {
                MessageBox.Show($"保存失败：{saveName}");
            }

            this.btn_Save.Enabled = false;
            MessageBox.Show($"保存成功：{saveName}");
        }
        #endregion

        #region 录像

        /// <summary>
        /// 开始录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartVideo_Click(object sender, EventArgs e)
        {
            //if (sourceDevice == null)
            //{
            //    MessageBox.Show("请先连接摄像头！", "提示");
            //    return;
            //}
            //开始计时
            timer_count.Enabled = true; //计时
            timer1.Enabled = true; //启用定时器
            SelectDpi();
            StartRecord();
        }

        private void StartRecord()
        {
            
            //if (videoWriter.IsOpen || videoWriter != null)
            //{
            //    videoWriter.Close();
            //    videoWriter.Dispose();
            //}

            //查看当前是否有图像
            //Bitmap b = this.vsp_Panel.GetCurrentVideoFrame();

            //释放掉之前录制的视频帧，重新开始
            sourceDevice.NewFrame -= Camera_NewFrame;
            
            this.vsp_Panel.SignalToStop();
            this.vsp_Panel.WaitForStop();
            Thread.Sleep(300);
            this.vsp_Panel.VideoSource = null;
            Thread.Sleep(500);
            sourceDevice = new AForge.Video.DirectShow.VideoCaptureDevice(infoCollection[this.cb_CameraSelect.SelectedIndex].MonikerString);
            CreateCatalog();           
            string videoName = $"{dateDirectory}{DateTime.Now.ToString("HH")}.mp4";

            //配置录像参数(宽,高,帧率,比特率等参数)VideoCapabilities这个属性会返回摄像头支持哪些配置,从这里面选一个赋值接即可

            //sourceDevice.VideoResolution = VideoCapabilities[1];
            this.vsp_Panel.VideoSource = sourceDevice;
            CameraDpi();
            this.vsp_Panel.Start();
            //事件绑定方法。设置回调,aforge会不断从这个回调推出图像数据
            sourceDevice.NewFrame += Camera_NewFrame;

            videoWriter = new VideoFileWriter();
            //打开录像文件(如果没有则创建,如果有也会清空),这里还有关于视频宽高、帧率、格式、图像位数
            //AForge.Video.FFMPEG.VideoFileWriter v  = new AForge.Video.FFMPEG.VideoFileWriter();     
            videoWriter.Open(
               videoName,
               width,
               height,
               30,
               Accord.Video.FFMPEG.VideoCodec.MPEG4,
               5500000
            //AForge.Video.FFMPEG.VideoCodec.MPEG4,
            //sourceDevice.VideoResolution.BitCount  默认为16    bitRate默认400000
            );
            //编解码器 图像位数 比特率 

            //videoWriter.Close();
            //videoWriter.Dispose();

        }
        //this.lab_Time
        //摄像头输出回调
        private void Camera_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            //Bitmap img = CopyImgByBytes(eventArgs.Frame);
            lock (eventArgs.Frame)
            {

                if (eventArgs != null && eventArgs.Frame != null)
                {
                    try
                    {

                        Bitmap videoFrame = (Bitmap)eventArgs.Frame.Clone();

                        // 在视频帧上绘制当前时间水印
                        Graphics g = Graphics.FromImage(videoFrame);
                        string currentTime = DateTime.Now.ToString("HH:mm:ss");
                        Font font = new Font("Arial", 50);
                        SolidBrush brush = new SolidBrush(Color.White);
                        g.DrawString(currentTime, font, brush, new PointF(10, 10));

                        //pictureBox1.Image = videoFrame;
                        //写到文件
                        videoWriter.WriteVideoFrame(videoFrame);
                        GC.Collect();
                        videoFrame.Dispose();
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("录像没有保存到文件");
                    }
                }
            }


            //try
            //{
            //   this.pb_BoxPanel.Image = img;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}

            //Bitmap image = this.vsp_Panel.GetCurrentVideoFrame();

        }


        //图像拷贝
        public static Bitmap CopyImgByBytes(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Bitmap img = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            BitmapData imgData = img.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr optr = bmpData.Scan0;
            IntPtr nptr = imgData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] OriginalImgBytes = new byte[bytes];
            //把原始图像数据复制到byte[]数组中
            Marshal.Copy(optr, OriginalImgBytes, 0, bytes);
            //把原始图像byte[]数据复制到新图像中
            Marshal.Copy(OriginalImgBytes, 0, nptr, bytes);
            //解除锁定
            bmp.UnlockBits(bmpData);
            img.UnlockBits(imgData);
            return img;
        }

        /// <summary>
        /// 暂停录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PauseVideo_Click(object sender, EventArgs e)
        {
            if (sourceDevice == null)
            {
                MessageBox.Show("请连接摄像头");
                return;
            }
            var stopBtnName = this.btn_PauseVideo.Text;
            if (stopBtnName == "暂停录像")
            {
                this.btn_PauseVideo.Text = "恢复录像";
                //暂停计时
                timer_count.Enabled = false;
                timer1.Enabled = false;

            }
            if (stopBtnName == "恢复录像")
            {
                this.btn_PauseVideo.Text = "暂停录像";
                //恢复计时
                timer_count.Enabled = true;
                timer1.Enabled = true;

            }
        }
        /// <summary>
        /// 停止录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EndVideo_Click(object sender, EventArgs e)
        {
            if (!sourceDevice.IsRunning)
            {
                MessageBox.Show("请连接摄像头");
                return;
            }
            if(videoWriter == null)
            {
                MessageBox.Show("请先开始录像");
                return;
            }
            timer1.Enabled = false;

            timer_count.Enabled = false;

            sourceDevice.NewFrame -= Camera_NewFrame;

            this.vsp_Panel.SignalToStop();
            this.vsp_Panel.WaitForStop();
            
            videoWriter.Close();
            this.tick_num = 0;
        }
        #endregion

        #region 计时器响应函数


        private int inTimer = 0;
        /// <summary>
        /// 定时器：每隔多少时间去执行重新录制（更改需求：当前时间一小时节点为录制，到整点了就重新录制）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled=false;
            
            DateTime currentTime = DateTime.Now;
            //如果是整点，则结束录制并重新开始
            //currentTime.Minute == 0  || currentTime.Minute == 30
            
            if(currentTime.Minute == 0 && Interlocked.Exchange(ref inTimer,1) == 0 )
            //if( (currentTime.Minute == 0 && (Math.Abs(currentTime.Second) < 6) ) )
            {
                timer1.Stop();
                var taskList = new List<Task>();
                Task task1 = Task.Run(new Action(() =>
                {
                    this.Invoke(new Action(() =>
                    {
                        //关闭当前视频流
                        //指示灯停止且等待
                        this.vsp_Panel.SignalToStop();
                        //停止且等待
                        this.vsp_Panel.WaitForStop();
                        //this.vsp_Panel.VideoSource.Stop();
                        //this.vsp_Panel.VideoSource = null;
                    }));                 
                }
                ));
                taskList.Add(task1);       
                taskList.Add(Task.Delay(60000));
                await Task.WhenAll(taskList);
           
                //do
                //{
                //    videoWriter.Close();
                //    videoWriter.Dispose();
                //} while (videoWriter.IsOpen);

                videoWriter.Close();
                videoWriter.Dispose();


                //延时让摄像头休息2分钟,彻底释放资源 此方法不可行
                //Thread.Sleep(2*60000);

                //重新打开录制
                //this.vsp_Panel.Start();
                StartRecord();
                timer1.Start();
                Interlocked.Exchange(ref inTimer, 0);
            }
        }

        private void DeleteTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // 获取文件夹中的所有子目录 年月份
                string[] directorys = Directory.GetDirectories(fileDirectory);

                // 当前时间
                DateTime currentTime = DateTime.Now;

                foreach (var d in directorys)
                {
                    // 获取目录的最后修改时间
                    DateTime lastModifiedTime = Directory.GetLastWriteTime(d);

                    // 计算文件最后修改时间与当前时间的时间间隔
                    TimeSpan timeSinceLastModified = currentTime - lastModifiedTime;

                    // 如果时间间隔超过了1天，删除文件
                    if (timeSinceLastModified.TotalHours >= 3)
                    {
                        Directory.Delete(d, true);
                        Debug.WriteLine($"已删除过期文件：{d}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"清除文件时发生错误：{ex.Message}");
            }
        }

        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void tick_count(object source, System.Timers.ElapsedEventArgs e)
        {
            tick_num++;
            int Temp = tick_num;
            int Second = Temp % 60;
            int Minute = Temp / 60;
            if (Minute % 60 == 0)
            {
                Hour = Minute / 60;
                Minute = 0;
            }
            else
            {
                Minute = Minute - Hour * 60;
            }
            string HourStr = Hour < 10 ? $"0{Hour}" : Hour.ToString();
            string MinuteStr = Minute < 10 ? $"0{Minute}" : Minute.ToString();
            string SecondStr = Second < 10 ? $"0{Second}" : Second.ToString();
            String tick = $"{HourStr}：{MinuteStr}：{SecondStr}";
            this.Invoke((EventHandler)(delegate
            {
                this.lab_Time.Text = tick;
            }));
        }
        #endregion

        #region 打开文件路径

        private void btn_OpenPath_Click(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                //string path = @"D:\";
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", fileDirectory);
                }
                catch (Exception ex)
                {
                    // 处理异常，例如路径无效等
                    MessageBox.Show($"无法打开文件资源管理器：{ex.Message}");
                }
            }));
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        private void CreateCatalog()
        {
            if (fileDirectory == "D:\\SaveVideo\\")
            {
                //创建日期目录
                var catalog = fileDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                if (!System.IO.Directory.Exists(catalog))
                {
                    System.IO.Directory.CreateDirectory(catalog);
                }
                dateDirectory = catalog;
            }
        }
        #endregion

        private void cb_CameraSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCameraDpi();
        }
    }
}
