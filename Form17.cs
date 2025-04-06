using ABB.Robotics.Controllers;
using ReaLTaiizor.Colors;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Enum.Material;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Util;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ABB.Robotics;

using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.IOSystemDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.EventLogDomain;


using ReaLTaiizor.Enum;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HslCommunication;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using Module = ABB.Robotics.Controllers.RapidDomain.Module;
using HslCommunication.MQTT;
using System.Linq.Expressions;
using ABB.Robotics.Controllers.FileSystemDomain;
using Microsoft.VisualBasic;
using Adapters;
using abb.egm;
using System.Net.Sockets;
using System.Net;
using ABB.Robotics.Controllers.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ReaLTaiizor.Drawing.Poison.PoisonPaint.BackColor;
using MathNet.Numerics.LinearAlgebra;
















namespace ReaLTaiizor.UI
{
    public partial class Form17 : MaterialForm
    {
        private NetworkScanner scanner = null;
        private ABB.Robotics.Controllers.Controller? controller = null;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;
        private NetworkWatcher networkwatcher = null;

        private int ki = 0;
        private int Button1 = 0;
        private int Button2 = 0;
        private int Button3 = 0;
        private int Button4 = 0;
        private int Button5 = 0;
        private int Button6 = 0;
        private int Button7 = 0;
        private int Button8 = 0;
        private int Button9 = 0;
        private int Button10 = 0;
        private int Button11 = 0;
        private int Button12 = 0;
        private readonly MaterialSkinManager materialSkinManager;
        private DateTime _lastInvokeTime = DateTime.MinValue;
        private const int THROTTLE_INTERVAL_MS = 100; // 100毫秒间隔
        public Form17()
        {
            InitializeComponent();

            // 设置AutoScaleMode
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //materialSkinManager.ColorScheme = new MaterialColorScheme(0x00C926b3, 0xA1008B, 0xDC2EFF, 0x006E70FF, MaterialTextShade.LIGHT);
            //materialSkinManager.ColorScheme = new MaterialColorScheme("#00480157", "#370142", "DC2EFF", "00BB5FCF", MaterialTextShade.LIGHT);
            //materialSkinManager.ColorScheme = new MaterialColorScheme(Color.Orange, Color.DarkOrange, Color.Orchid, Color.OrangeRed, Color.MediumOrchid);
            materialSkinManager.ColorScheme = new MaterialColorScheme(MaterialPrimary.Indigo500, MaterialPrimary.Indigo700, MaterialPrimary.Indigo100, MaterialAccent.Pink200, MaterialTextShade.LIGHT);

        }

        private void SeedListView()
        {
            //Define
            string[][] data = new[]
            {
                new []{"Lollipop", "392", "0.2", "0"},
                new []{"KitKat", "518", "26.0", "7"},
                new []{"Ice cream sandwich", "237", "9.0", "4.3"},
                new []{"Jelly Bean", "375", "0.0", "0.0"},
                new []{"Honeycomb", "408", "3.2", "6.5"}
            };

        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            UpdateColor();
        }

        private int colorSchemeIndex;

        private void ColorScheme_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;

            if (colorSchemeIndex > 6)
            {
                colorSchemeIndex = 0;
            }

            UpdateColor();
        }

        private void UpdateColor()
        {
            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialPrimary.Teal500 : MaterialPrimary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialPrimary.Teal700 : MaterialPrimary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialPrimary.Teal200 : MaterialPrimary.Indigo100,
                        MaterialAccent.Pink200,
                        MaterialTextShade.LIGHT);
                    break;

                case 1:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.Green600,
                        MaterialPrimary.Green700,
                        MaterialPrimary.Green200,
                        MaterialAccent.Red100,
                        MaterialTextShade.LIGHT);
                    break;

                case 2:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.BlueGrey800,
                        MaterialPrimary.BlueGrey900,
                        MaterialPrimary.BlueGrey500,
                        MaterialAccent.LightBlue200,
                        MaterialTextShade.LIGHT);
                    break;
                case 3:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.Red800,
                        MaterialPrimary.Red900,
                        MaterialPrimary.Red500,
                        MaterialAccent.Green200,
                        MaterialTextShade.LIGHT);
                    break;
                case 4:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.Yellow800,
                        MaterialPrimary.Yellow900,
                        MaterialPrimary.Yellow500,
                        MaterialAccent.DeepOrange200,
                        MaterialTextShade.LIGHT);
                    break;
                case 5:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.DeepOrange800,
                        MaterialPrimary.DeepOrange900,
                        MaterialPrimary.DeepOrange500,
                        MaterialAccent.Yellow200,
                        MaterialTextShade.LIGHT);
                    break;
                case 6:
                    materialSkinManager.ColorScheme = new MaterialColorScheme(
                        MaterialPrimary.Lime800,
                        MaterialPrimary.Lime900,
                        MaterialPrimary.Lime500,
                        MaterialAccent.Green200,
                        MaterialTextShade.LIGHT);
                    break;
            }

            Invalidate();
            Refresh();
        }



        // 定义一个静态字段
        public static string StaticString = "NewFloder";//将RApid文件保存到根目录下的文件夹名
        public static int button21_Count = 0;


        // 定义一个静态方法来设置静态字段的值

        public static Point Down_point = Point.Empty;//鼠标按下的点
        public static Point Last_point = Point.Empty;//鼠标最后的点
        public static Point New_point = Point.Empty;//鼠标移动的新点
        public static bool bCatch = false;

        public static double robot_x_start = 0;
        public static double robot_y_start = 0;
        public static double robot_x_current = 0;
        public static double robot_y_current = 0;
        public static bool bGet = false;
        //public static uint _seqNumber = 0;



        private Thread _sensorThread = null;

        private bool _exitThread = false;
        private uint _seqNumber = 0;
        private UdpClient _udpServer = new UdpClient(6510);
        int egmServerPort = 6510;
        EgmRobot robot = null;
        private IPEndPoint remoteEP = null;


        static double[,] dhParams = {
        { 0, 90, 0.290, 0 },    // 关节 1
        { 0.270, 0, 0, 0 },     // 关节 2
        { 0.070, 90, 0, 0 },    // 关节 3
        { 0, -90, 0.302, 0 },   // 关节 4
        { 0, 90, 0, 0 },        // 关节 5
        { 0, 0, 0.072, 0 }      // 关节 6
    };

        static Vector<double> CrossProduct(Vector<double> a, Vector<double> b)
        {
            return Vector<double>.Build.DenseOfArray(new double[]
            {
            a[1] * b[2] - a[2] * b[1],
            a[2] * b[0] - a[0] * b[2],
            a[0] * b[1] - a[1] * b[0]
            });
        }

        // 计算单个 DH 变换矩阵
        static Matrix<double> DHTransform(double theta, double d, double a, double alpha)
        {
            double radTheta = Math.PI * theta / 180.0;
            double radAlpha = Math.PI * alpha / 180.0;

            return Matrix<double>.Build.DenseOfArray(new double[,]
            {
            { Math.Cos(radTheta), -Math.Sin(radTheta) * Math.Cos(radAlpha),  Math.Sin(radTheta) * Math.Sin(radAlpha), a * Math.Cos(radTheta) },
            { Math.Sin(radTheta),  Math.Cos(radTheta) * Math.Cos(radAlpha), -Math.Cos(radTheta) * Math.Sin(radAlpha), a * Math.Sin(radTheta) },
            { 0, Math.Sin(radAlpha), Math.Cos(radAlpha), d },
            { 0, 0, 0, 1 }
            });
        }

        // 计算末端变换矩阵
        static Matrix<double>[] ComputeForwardKinematics(double[] jointAngles)
        {
            Matrix<double> T = Matrix<double>.Build.DenseIdentity(4);
            Matrix<double>[] transforms = new Matrix<double>[6];

            for (int i = 0; i < 6; i++)
            {
                Matrix<double> Ti = DHTransform(jointAngles[i], dhParams[i, 2], dhParams[i, 0], dhParams[i, 1]);
                T = T * Ti;
                transforms[i] = T; // 保存每个关节的变换矩阵
            }

            return transforms;
        }

        // 计算雅可比矩阵
        static Matrix<double> ComputeJacobian(double[] jointAngles)
        {
            Matrix<double>[] transforms = ComputeForwardKinematics(jointAngles);
            Vector<double> Pn = transforms[5].Column(3).SubVector(0, 3);  // 末端位置
            Matrix<double> Jv = Matrix<double>.Build.Dense(3, 6);
            Matrix<double> Jw = Matrix<double>.Build.Dense(3, 6);

            Vector<double> P0 = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 }); // 基座位置

            for (int i = 0; i < 6; i++)
            {
                Vector<double> Zi = transforms[i].SubMatrix(0, 3, 2, 1).Column(0); // Z 轴方向
                Vector<double> Pi = transforms[i].Column(3).SubVector(0, 3); // 关节位置

                Jv.SetColumn(i, CrossProduct(Zi, Pn - Pi)); // 线速度部分
                Jw.SetColumn(i, Zi); // 角速度部分
            }

            // 组合最终雅可比矩阵

            return Jv.Stack(Jw);
        }








        //public static IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6510);
        void Display_inbouse_Message(EgmRobot robot)//获取机器人的位置信息
        {


            if (robot.HasHeader && robot.Header.HasSeqno && robot.Header.HasTm)//判断是否有消息
            {
                if (bGet == true)//鼠标按下的时候获取机器人的位置
                {
                    // MessageBox.Show("机器人的消息" + robot.FeedBack.Cartesian.Pos.X.ToString() + " " + robot.FeedBack.Cartesian.Pos.Y.ToString());
                    bGet = false;
                    robot_x_start = robot.FeedBack.Cartesian.Pos.X;
                    robot_y_start = robot.FeedBack.Cartesian.Pos.Y;



                }
                else
                {
                    robot_x_current = robot.FeedBack.Cartesian.Pos.X;
                    robot_y_current = robot.FeedBack.Cartesian.Pos.Y;
                }
            }
            else
            {
                MessageBox.Show("没有收到机器人的消息");
            }
        }
        void Create_Sensor_Message()//创建一个消息
        {
            EgmSensor.Builder sensor = EgmSensor.CreateBuilder();
            EgmHeader.Builder hdr = new EgmHeader.Builder();

            hdr.SetSeqno(_seqNumber++);
            hdr.SetTm((uint)DateTime.Now.Ticks);
            hdr.SetMtype(EgmHeader.Types.MessageType.MSGTYPE_CORRECTION);
            sensor.SetHeader(hdr);

            EgmPlanned.Builder planned = new EgmPlanned.Builder();
            EgmPose.Builder pose = new EgmPose.Builder();
            EgmQuaternion.Builder orientation = new EgmQuaternion.Builder();
            EgmCartesian.Builder cartesian = new EgmCartesian.Builder();
            double[] jointAngles = { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
            {
                jointAngles[i] = robot.FeedBack.Joints.JointsList[i];
            }

            Matrix<double> ja_conbi = ComputeJacobian(jointAngles);
            double a = ja_conbi.Determinant();
            if (ja_conbi.Determinant() <= 0.5E-18f + 1E-20f)
            {
                cartesian.SetX(364.68);
                cartesian.SetY(0);
                cartesian.SetZ(368.99);
            }
            else
            {
                if (bCatch == true)
                {
                    cartesian.SetX((float)(robot_x_start) + 0.8 * (New_point.X - Down_point.X));
                    cartesian.SetY((float)(robot_y_start) + 0.8 * (New_point.Y - Down_point.Y));
                    cartesian.SetZ(368.99);
                }
                else
                {
                    cartesian.SetX((float)robot_x_current)
                             .SetY((float)robot_y_current)
                             .SetZ(368.99);
                }
            }
            //测试
            //cartesian.SetX(342)
            //.SetY(25)
            //.SetZ(587.5);
            //if (ki == 0)
            //{
            //    ki = 1;
            //}
            //else
            //{
            //    cartesian.SetX(342)
            //    .SetY（25)
            //   .SetZ(587.5);
            //    ki = 0;
            //}
            //*****************************************************//
            orientation.SetU0(1.0)
           .SetU1(0.0)
            .SetU2(0.0)
            .SetU3(0.0);

            pose.SetPos(cartesian);
            pose.SetOrient(orientation);
            planned.SetCartesian(pose);
            sensor.SetPlanned(planned);

            //EgmSensor sensorMessage = sensor.Build();
            //byte[] sendBytes = sensorMessage.ToByteArray();
            //udpClient.Send(sendBytes, sendBytes.Length);
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())

                {

                    EgmSensor sensorMessage = sensor.Build();

                    sensorMessage.WriteTo(memoryStream);

                    Console.WriteLine(sensorMessage.ToString());

                    //send the udp message to the robot
                    //IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6510);
                    int bytesSent = _udpServer.Send(memoryStream.ToArray(),

                                                   (int)memoryStream.Length, remoteEP);

                    if (bytesSent < 0)

                    {

                        MessageBox.Show("发送消息失败");

                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("发送消息失败" + e.Message);
            }





            //IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);

            //// 解析反馈消息
            //EgmRobot feedback = EgmRobot.ParseFrom(receiveBytes);
            //if (feedback.HasHeader && feedback.Header.HasSeqno && feedback.Header.HasTm)
            //{
            //    // 检查反馈消息中的位置信息
            //    double feedbackX = feedback.FeedBack.Cartesian.Pos.X;
            //    double feedbackY = feedback.FeedBack.Cartesian.Pos.Y;
            //    double feedbackZ = feedback.FeedBack.Cartesian.Pos.Z;

            //    // 比较反馈消息中的位置信息与发送的位置信息
            //    if (Math.Abs(feedbackX - cartesian.X) < 0.01 &&
            //        Math.Abs(feedbackY - cartesian.Y) < 0.01 &&
            //        Math.Abs(feedbackZ - cartesian.Z) < 0.01)
            //    {
            //        MessageBox.Show("机器人控制器正确接收了位置信息");
            //    }
            //    else
            //    {
            //        MessageBox.Show("机器人控制器接收的位置信息不一致");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("没有收到机器人的反馈消息");
            //}
            return;
        }


        private void MaterialSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            DrawerUseColors = materialSwitch4.Checked;
        }

        private void MaterialSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            DrawerHighlightWithAccent = materialSwitch5.Checked;
        }


        private void MaterialSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            DrawerShowIconsWhenHidden = materialSwitch8.Checked;
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new("Batch operation report:\n\n");
            Random random = new();
            int result = 0;

            for (int i = 0; i < 200; i++)
            {
                result = random.Next(1000);

                if (result < 950)
                {
                    builder.AppendFormat(" - Task {0}: Operation completed sucessfully.\n", i);
                }
                else
                {
                    builder.AppendFormat(" - Task {0}: Operation failed! A very very very very very very very very very very very very serious error has occured during this sub-operation. The errorcode is: {1}).\n", i, result);
                }
            }

            string batchOperationResults = builder.ToString();
            batchOperationResults = "Simple text";
            DialogResult mresult = MaterialMessageBox.Show(batchOperationResults, "Batch Operation", MessageBoxButtons.YesNoCancel, MaterialFlexibleForm.ButtonsPosition.Center);

        }


        private void MaterialTextBox2_LeadingIconClick(object sender, EventArgs e)
        {
            MaterialSnackBar SnackBarMessage = new("Leading Icon Click");
            SnackBarMessage.Show(this);

        }

        private void MaterialButton6_Click(object sender, EventArgs e)
        {
            MaterialSnackBar SnackBarMessage = new("SnackBar started succesfully", "OK", true);
            SnackBarMessage.Show(this);
        }







        private void MaterialTextBox21_LeadingIconClick(object sender, EventArgs e)
        {
            MaterialSnackBar SnackBarMessage = new("Leading Icon Click");
            SnackBarMessage.Show(this);
        }

        private void MaterialTextBox21_TrailingIconClick(object sender, EventArgs e)
        {
            MaterialSnackBar SnackBarMessage = new("Trailing Icon Click");
            SnackBarMessage.Show(this);
        }


        private void MaterialButton25_Click(object sender, EventArgs e)
        {
            MaterialDialog materialDialog = new(this, "Dialog Title", "Dialogs inform users about a task and can contain critical information, require decisions, or involve multiple tasks.", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);

            MaterialSnackBar SnackBarMessage = new(result.ToString(), 750);
            SnackBarMessage.Show(this);

        }



        private void MaterialButton27_Click(object sender, EventArgs e)
        {
            DrawerNonClickTabPage = Array.Empty<System.Windows.Forms.TabPage>();
        }

        private void MaterialButton28_Click(object sender, EventArgs e)
        {
            MaterialAnimations.AnimationRun = MaterialAnimations.AnimationRunType.Normal;
        }

        private void MaterialButton29_Click(object sender, EventArgs e)
        {
            MaterialAnimations.AnimationRun = MaterialAnimations.AnimationRunType.Fast;
        }


        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialMultiLineTextBoxEdit2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void materialMultiLineTextBoxEdit11_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel60_Click(object sender, EventArgs e)
        {

        }

        private void materialButton34_Click(object sender, EventArgs e)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {


                    RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "cir2");
                    if (rapidData.RapidType == "num")
                    {
                        Num rd = new Num();
                        rd.FillFromString2("1");
                        rapidData.Value = rd;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialButton36_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join1");
                            if ((float.Parse(textBox4.Text) + 5) < 165)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "xl");
                            if ((float.Parse(textBox4.Text) + 5) < 570)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void tabPage14_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel80_Click(object sender, EventArgs e)
        {

        }


        private void materialCard3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton11_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click_1(object sender, EventArgs e)
        {

        }

        private void materialCard10_Paint(object sender, PaintEventArgs e)
        {

        }


        private void materialListView2_DoubleClick(object sender, EventArgs e)
        {
            if (this.materialListView2.SelectedItems.Count > 0)
            {
                ListViewItem item = this.materialListView2.SelectedItems[0];
                if (item.Tag is ControllerInfo info && info.Availability == Availability.Available)
                {
                    // 注销并释放当前控制器
                    if (controller != null)
                    {
                        controller.Logoff();
                        controller.Dispose();
                        controller = null;
                    }

                    // 创建并登录到新的控制器
                    controller = ControllerFactory.CreateFrom(info);
                    controller.Logon(UserInfo.DefaultUser); // 使用默认用户名登录
                    timer1.Enabled = true;
                    subcribe();
                    subcibe_IO();
                    subscrbe_TpWrite();
                    sucribe_Log();
                    // Subscrbe_Data();
                    // 弹框提示登录成功
                    MessageBox.Show($"已登录到控制器: {info.SystemName}", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        private void materialButton51_Click(object sender, EventArgs e)
        {
            if (scanner == null)
            {
                this.scanner = new NetworkScanner();
            }
            this.scanner.Scan();
            ControllerInfoCollection controllers = scanner.Controllers;//获取控制器信息
            ListViewItem item = null;
            foreach (ControllerInfo controllerInfo in controllers)
            {
                item = new ListViewItem(controllerInfo.IPAddress.ToString());//获取控制器IP地址
                item.SubItems.Add(controllerInfo.Id);//获取控制器ID
                item.SubItems.Add(controllerInfo.SystemName);//获取控制器系统名称
                item.SubItems.Add(controllerInfo.IsVirtual.ToString());//获取控制器是否虚拟
                item.SubItems.Add(controllerInfo.Availability.ToString());//获取控制器可用性
                item.SubItems.Add(controllerInfo.ControllerName);//获取控制器名称
                item.SubItems.Add(controllerInfo.Version.ToString());//获取控制器版本

                this.materialListView2.Items.Add(item);//将获取的控制器信息添加到listview中
                item.Tag = controllerInfo;
            }

        }

        private void materialButton3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    controller.State = ControllerState.MotorsOn;
                    MessageBox.Show("机器人已上电", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请切换至自动模式");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialButton25_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    controller.State = ControllerState.MotorsOff;
                    MessageBox.Show("机器人已下电", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请切换至自动模式");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialButton6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    ;
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        StartResult startResult = controller.Rapid.Start();
                    }

                }
                else
                {
                    MessageBox.Show("请切换至自动模式");
                }

            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("权限被其他客户占有" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        private void materialButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    tasks = controller.Rapid.GetTasks();
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        controller.Rapid.Stop(StopMode.Immediate);
                    }

                }
                else
                {
                    MessageBox.Show("请切换至自动模式");
                }

            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("权限被其他客户占有" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        private void materialButton29_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Restart.SelectedItem != null)
                {
                    using (Mastership m = Mastership.Request(controller))
                    {
                        controller.Restart((ControllerStartMode)System.Enum.Parse(typeof(ControllerStartMode), comboBox_Restart.SelectedItem.ToString()));
                    }
                }
                else
                {
                    MessageBox.Show("请选择一个重启模式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"重启失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void materialComboBox1_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();

            materialComboBox1.Items.Clear();
            for (int i = 0; i < tasks.Length; i++)
            {
                materialComboBox1.Items.Add(tasks[i].Name.ToString());
            }
            materialComboBox1.Text = tasks[0].Name.ToString();

        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox2_Click(object sender, EventArgs e)
        {
            ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks?.FirstOrDefault(task => task.Name == materialComboBox1.SelectedItem?.ToString());

            if (selectedTask != null)
            {
                Module[] modules = selectedTask.GetModules();
                materialComboBox2.Items.Clear();
                for (int i = 0; i < modules.Length; i++)
                {
                    materialComboBox2.Items.Add(modules[i].Name.ToString());
                }
                if (modules.Length > 0)
                {
                    materialComboBox2.Text = modules[0].Name.ToString();
                }
            }

        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox3_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();
            ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks?.FirstOrDefault(task => task.Name == materialComboBox1.SelectedItem?.ToString());
            if (selectedTask != null)
            {
                Module[] modules = selectedTask.GetModules();
                Module? selectedModule = modules.FirstOrDefault(module => module.Name == materialComboBox2.SelectedItem?.ToString());
                if (selectedModule != null)
                {
                    Routine[] routines = selectedModule.GetRoutines();
                    materialComboBox3.Items.Clear();
                    for (int i = 0; i < routines.Length; i++)
                    {
                        materialComboBox3.Items.Add(routines[i].Name.ToString());
                    }
                    if (routines.Length > 0)
                    {
                        materialComboBox3.Text = routines[0].Name.ToString();
                    }
                }
            }

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            string s1 = "";
            string s2 = "";
            s1 = materialComboBox2.SelectedItem.ToString();
            s2 = materialComboBox3.SelectedItem.ToString();
            try
            {
                tasks = controller.Rapid.GetTasks();
                ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks.FirstOrDefault(task => task.Name == materialComboBox1.SelectedItem.ToString());

                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    selectedTask.SetProgramPointer(s1, s2);
                    MessageBox.Show("程序指针已经设置到" + s2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialMultiLineTextBoxEdit3_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton28_Click_1(object sender, EventArgs e)
        {
            try
            {
                RapidData rapidData = controller.Rapid.GetRapidData(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
                txtShowRd.Text = rapidData.Value.ToString();
                if (rapidData.RapidType == "robtarget")
                {
                    RobTarget robTarget = (RobTarget)rapidData.Value;
                    txtShowRdX.Text = robTarget.Trans.X.ToString();
                    txtShowRdY.Text = robTarget.Trans.Z.ToString();
                    txtShowRdZ.Text = robTarget.Trans.Y.ToString();
                    txtShowRdQ1.Text = robTarget.Rot.Q1.ToString();
                    txtShowRdQ2.Text = robTarget.Rot.Q2.ToString();
                    txtShowRdQ3.Text = robTarget.Rot.Q3.ToString();
                    txtShowRdQ4.Text = robTarget.Rot.Q4.ToString();
                }
                else if (rapidData.IsArray)
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void materialButton27_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {
                    RapidData rapidData = controller.Rapid.GetRapidData(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
                    if (rapidData.RapidType == "robtarget")
                    {
                        RobTarget robTarget = (RobTarget)rapidData.Value;


                        robTarget.Trans.X = Convert.ToSingle(txtShowRdX.Text);
                        robTarget.Trans.Y = Convert.ToSingle(txtShowRdY.Text);
                        robTarget.Trans.Z = Convert.ToSingle(txtShowRdZ.Text);
                        robTarget.Rot.Q1 = Convert.ToSingle(txtShowRdQ1.Text);
                        robTarget.Rot.Q2 = Convert.ToSingle(txtShowRdQ2.Text);
                        robTarget.Rot.Q3 = Convert.ToSingle(txtShowRdQ3.Text);
                        rapidData.Value = robTarget;

                    }
                    else if (rapidData.RapidType == "num")
                    {
                        Num rd = new Num();
                        rd.FillFromString2(txtShowRd.Text);
                        rapidData.Value = rd;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialButton32_Click(object sender, EventArgs e)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {
                    Signal signal = controller.IOSystem.GetSignal(textSigName.Text.ToString());

                    signal.Value = Convert.ToSingle(textGetSig.Text);
                    //MessageBox.Show($"Setting signal {signalName} to value {signalValue}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("该变量没有开启ALL权限!");
            }

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            SignalCollection signals = new SignalCollection();
            signals = controller.IOSystem.GetSignals(IOFilterTypes.Unit, "DRV_1");
            ListViewItem item = null;
            foreach (Signal signal in signals)
            {
                item = new ListViewItem(signal.Name);
                item.SubItems.Add(signal.Type.ToString());
                item.SubItems.Add(signal.Value.ToString());
                item.SubItems.Add(signal.Unit.ToString());
                item.SubItems.Add(signal.ToString());

                this.listView2.Items.Add(item);
                item.Tag = signal;
            }
            listView2.Refresh();

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            subcibe_IO();

        }

        private void materialRadioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton_guanjie.Checked)
            {
                this.materialLabel24.Text = "J1";
                this.materialLabel71.Text = "J2";
                this.materialLabel72.Text = "J3";
                this.materialLabel73.Text = "J4";
                this.materialLabel74.Text = "J5";
                this.materialLabel75.Text = "J6";

            }
            else if (radioButton_world.Checked
                || radioButton_Base.Checked
                || radioButton_Tool.Checked
                || radioButton_WorkProject.Checked
                || radioButton_User.Checked)
            {
                this.materialLabel24.Text = "X";
                this.materialLabel71.Text = "Y";
                this.materialLabel72.Text = "Z";
                this.materialLabel73.Text = "pitch";
                this.materialLabel74.Text = "yaw";
                this.materialLabel75.Text = "roll";

            }
        }

        private void materialButton33_Click(object sender, EventArgs e)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {


                    RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "cir1");
                    if (rapidData.RapidType == "num")
                    {
                        Num rd = new Num();
                        rd.FillFromString2("1");
                        rapidData.Value = rd;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialButton35_Click(object sender, EventArgs e)
        {

            try
            {
                using (Mastership.Request(controller.Rapid))
                {


                    RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "cir3");
                    if (rapidData.RapidType == "num")
                    {
                        Num rd = new Num();
                        rd.FillFromString2("1");
                        rapidData.Value = rd;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void materialButton36_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button1 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton36_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join1", "xl", "0", "0", 155, 560);
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (controller.OperatingMode == ControllerOperatingMode.Auto)
                {
                    tasks = controller.Rapid.GetTasks();
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        tasks[0].ResetProgramPointer();
                        MessageBox.Show("程序指针以复位");
                    }

                }
                else
                {
                    MessageBox.Show("请切换至自动模式");
                }

            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("权限被其他客户占有" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        void subcribe()
        {
            controller.StateChanged += new EventHandler<StateChangedEventArgs>(controller_StateChanged);
            controller.Rapid.ExecutionStatusChanged += new EventHandler<ExecutionStatusChangedEventArgs>(controller_ExecutionStatusChanged);
            controller.OperatingModeChanged += new EventHandler<OperatingModeChangeEventArgs>(controller_OperatingModeChanged);
        }
        private void controller_ExecutionStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            this.Invoke(new EventHandler(Uodate_GUI_Status), sender, e);

        }
        private void Uodate_GUI_Status(object sender, System.EventArgs e)
        {
            ExecutionStatusChangedEventArgs ex = (ExecutionStatusChangedEventArgs)e;
            label_Status.Text = "控制器状态：" + ex.Status.ToString();

        }
        private void controller_StateChanged(object sender, StateChangedEventArgs e)
        {
            this.Invoke(new EventHandler(Uodate_GUI_State), sender, e);

        }
        private void Uodate_GUI_State(object sender, System.EventArgs e)
        {
            StateChangedEventArgs ex = (StateChangedEventArgs)e;
            label_State.Text = "控制器状态：" + ex.NewState.ToString();

        }


        private void controller_OperatingModeChanged(object sender, OperatingModeChangeEventArgs e)
        {
            this.Invoke(new EventHandler(Uodate_GUI_Operate), sender, e);

        }
        private void Uodate_GUI_Operate(object sender, System.EventArgs e)
        {
            OperatingModeChangeEventArgs ex = (OperatingModeChangeEventArgs)e;
            label_Operate.Text = "控制器模式：" + ex.NewMode.ToString();

        }

        //满1s时发生
        private void timer_exercise_Tick(object sender, EventArgs e)
        {
            timer_exercise.Stop();
            if (Button1 == 1)
            {
                Send_Exercise_num_Add("join1", "xl", "3", "3", 155, 560);
                Button1 = 0;
            }
            else if (Button2 == 1)
            {
                Send_Exercise_num_Add("join2", "yl", "3", "3", 100, 560);
                Button2 = 0;

            }
            else if (Button3 == 1)
            {
                Send_Exercise_num_Add("join3", "zl", "3", "3", 60, 732);
                Button3 = 0;
            }
            else if (Button4 == 1)
            {
                Send_Exercise_num_Add("join4", "rxl", "3", "3", 150, 200);
                Button4 = 0;
            }
            else if (Button5 == 1)
            {
                Send_Exercise_num_Add("join5", "ryl", "3", "3", 110, 200);
                Button5 = 0;
            }
            else if (Button6 == 1)
            {
                Send_Exercise_num_Add("join6", "rzl", "3", "3", 390, 200);
                Button6 = 0;
            }
            else if (Button7 == 1)
            {
                Send_Exercise_num_Sub("join1", "xl", "4", "4", -155, -560);
                Button7 = 0;
            }
            else if (Button8 == 1)
            {
                Send_Exercise_num_Sub("join2", "yl", "4", "4", -100, -560);
                Button8 = 0;
            }
            else if (Button9 == 1)
            {
                Send_Exercise_num_Sub("join3", "zl", "4", "4", -80, -105);
                Button9 = 0;
            }
            else if (Button10 == 1)
            {
                Send_Exercise_num_Sub("join4", "rxl", "4", "4", -150, -200);
                Button10 = 0;
            }
            else if (Button11 == 1)
            {
                Send_Exercise_num_Sub("join5", "ryl", "4", "4", -110, -200);
                Button11 = 0;
            }
            else if (Button12 == 1)
            {
                Send_Exercise_num_Sub("join6", "rzl", "4", "4", -390, -200);
                Button12 = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double rx;
            double ry;
            double rz;
            if (radioButton_guanjie.Checked)
            {
                JointTarget jointTarget = new JointTarget();
                jointTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition();
                textBox4.Text = jointTarget.RobAx.Rax_1.ToString(format: "#0.00");
                textBox5.Text = jointTarget.RobAx.Rax_2.ToString(format: "#0.00");
                textBox6.Text = jointTarget.RobAx.Rax_3.ToString(format: "#0.00");
                textBox7.Text = jointTarget.RobAx.Rax_4.ToString(format: "#0.00");
                textBox8.Text = jointTarget.RobAx.Rax_5.ToString(format: "#0.00");
                textBox9.Text = jointTarget.RobAx.Rax_6.ToString(format: "#0.00");


            }
            else if (radioButton_world.Checked)
            {
                RobTarget robTarget = new RobTarget();
                robTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.World);
                textBox4.Text = robTarget.Trans.X.ToString(format: "#0.00");
                textBox5.Text = robTarget.Trans.Y.ToString(format: "#0.00");
                textBox6.Text = robTarget.Trans.Z.ToString(format: "#0.00");
                robTarget.Rot.ToEulerAngles(out rx, out ry, out rz);
                textBox7.Text = rx.ToString(format: "#0.00");
                textBox8.Text = ry.ToString(format: "#0.00");
                textBox9.Text = rz.ToString(format: "#0.00");
            }
            else if (radioButton_Base.Checked)
            {
                RobTarget robTarget = new RobTarget();
                robTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.Base);
                textBox4.Text = robTarget.Trans.X.ToString(format: "#0.00");
                textBox5.Text = robTarget.Trans.Y.ToString(format: "#0.00");
                textBox6.Text = robTarget.Trans.Z.ToString(format: "#0.00");
                robTarget.Rot.ToEulerAngles(out rx, out ry, out rz);
                textBox7.Text = rx.ToString(format: "#0.00");
                textBox8.Text = ry.ToString(format: "#0.00");
                textBox9.Text = rz.ToString(format: "#0.00");
            }
            else if (radioButton_Tool.Checked)
            {
                RobTarget robTarget = new RobTarget();
                robTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.Tool);
                textBox4.Text = robTarget.Trans.X.ToString(format: "#0.00");
                textBox5.Text = robTarget.Trans.Y.ToString(format: "#0.00");
                textBox6.Text = robTarget.Trans.Z.ToString(format: "#0.00");
                robTarget.Rot.ToEulerAngles(out rx, out ry, out rz);
                textBox7.Text = rx.ToString(format: "#0.00");
                textBox8.Text = ry.ToString(format: "#0.00");
                textBox9.Text = rz.ToString(format: "#0.00");
            }
            else if (radioButton_WorkProject.Checked)
            {
                RobTarget robTarget = new RobTarget();
                robTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.WorkObject);
                textBox4.Text = robTarget.Trans.X.ToString(format: "#0.00");
                textBox5.Text = robTarget.Trans.Y.ToString(format: "#0.00");
                textBox6.Text = robTarget.Trans.Z.ToString(format: "#0.00");
                robTarget.Rot.ToEulerAngles(out rx, out ry, out rz);
                textBox7.Text = rx.ToString(format: "#0.00");
                textBox8.Text = ry.ToString(format: "#0.00");
                textBox9.Text = rz.ToString(format: "#0.00");
            }
            else if (radioButton_User.Checked)
            {
                RobTarget robTarget = new RobTarget();
                robTarget = controller.MotionSystem.ActiveMechanicalUnit.GetPosition(CoordinateSystemType.Undefined);
                textBox4.Text = robTarget.Trans.X.ToString(format: "#0.00");
                textBox5.Text = robTarget.Trans.Y.ToString(format: "#0.00");
                textBox6.Text = robTarget.Trans.Z.ToString(format: "#0.00");
                robTarget.Rot.ToEulerAngles(out rx, out ry, out rz);
                textBox7.Text = rx.ToString(format: "#0.00");
                textBox8.Text = ry.ToString(format: "#0.00");
                textBox9.Text = rz.ToString(format: "#0.00");
            }

        }

        private void Signal_Changed(object? sender, SignalChangedEventArgs e)
        {
            this.Invoke(new EventHandler<SignalChangedEventArgs>(Update_GUI_IO), sender, e);
        }
        private void Update_GUI_IO(object? sender, SignalChangedEventArgs e)
        {
            Signal signal = (Signal)sender!;
            ListViewItem? item = listView3.FindItemWithText(signal.Name);
            if (item != null)
            {
                item.SubItems[2].Text = signal.Value.ToString();
            }
        }

        void Subscrbe_Data()
        {
            RapidData rapidData = controller.Rapid.GetRapidData(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
            rapidData.ValueChanged += new EventHandler<DataValueChangedEventArgs>(Rapid_Value_Change);
        }
        private void Rapid_Value_Change(object? sender, DataValueChangedEventArgs e)
        {
            this.Invoke(new EventHandler(Update_GUI_Data), sender, e);
        }
        private void Update_GUI_Data(object? sender, EventArgs e)
        {
            DataValueChangedEventArgs ex = (DataValueChangedEventArgs)e;
            RapidData rapidData = (RapidData)sender!;
            txtShowRd.Text = rapidData.Value.ToString();
        }
        UITPReadNumEventArgs numEventArgs;
        UITPWriteEventArgs tpWriteEventArgs;
        void subscrbe_TpWrite()
        {
            controller.Rapid.UIInstruction.UIInstructionEvent += new UIInstructionEventHandler(Rapid_UIInstruction);
        }
        private void Rapid_UIInstruction(object sender, UIInstructionEventArgs e)
        {
            this.Invoke(new EventHandler(Update_GUI_TpWrite), sender, e);
        }
        private void Update_GUI_TpWrite(object sender, System.EventArgs e)
        {
            UIInstructionEventArgs ex = (UIInstructionEventArgs)e;
            //if (ex.InstructionType == UIInstructionType.TPWrite)
            //{
            //    TP_write.Text = ex.EventMessage.ToString();
            //}
            if (ex.InstructionType == UIInstructionType.TPReadNum)
            {
                numEventArgs = (UITPReadNumEventArgs)e;
                TP_write.Text = numEventArgs.TPText.ToString();

            }
            else
            {
                tpWriteEventArgs = (UITPWriteEventArgs)e;
                TP_write.Text = tpWriteEventArgs.TaskName.ToString();
            }

        }
        void sucribe_Log()
        {
            ABB.Robotics.Controllers.EventLogDomain.EventLog log = controller.EventLog;
            log.MessageWritten += new EventHandler<MessageWrittenEventArgs>(Log_MessageWritten);
        }
        private void Log_MessageWritten(object sender, MessageWrittenEventArgs e)
        {
            this.Invoke(new EventHandler(Update_GUI_Log), sender, e);
        }
        private void Update_GUI_Log(object sender, System.EventArgs e)
        {
            MessageWrittenEventArgs ex = (MessageWrittenEventArgs)e;
            int Alaermno;
            Alaermno = ex.Message.CategoryId * 10000 + ex.Message.Number;
            this.textBox_Log.Text = this.textBox_Log.Text + "时间：" + ex.Message.Timestamp.ToString() + "  " + "报警号：" + Alaermno.ToString() + "    消息：" + ex.Message.Title.ToString() + "\r\n";
        }
        private void Send_Exercise_num_Sub(string join, string l, string num1, string num2, long lin1, long lin2)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {
                    if (radioButton_guanjie.Checked)
                    {
                        RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", join);
                        if (num1 == "0")
                        {
                            if (rapidData.RapidType == "num")
                            {
                                Num rd = new Num();
                                rd.FillFromString2(num1);
                                rapidData.Value = rd;

                            }
                        }
                        else
                        {

                            if ((float.Parse(textBox4.Text) + 5) > lin1)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2(num1);
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }


                    }
                    else if (radioButton_world.Checked)
                    {
                        RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", l);

                        if (num2 == "0")
                        {
                            if (rapidData.RapidType == "num")
                            {
                                Num rd = new Num();
                                rd.FillFromString2(num2);
                                rapidData.Value = rd;

                            }
                        }
                        else
                        {
                            if ((float.Parse(textBox8.Text) + 5) > lin2)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2(num2);
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }


                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("减小时出错" + ex.Message.ToString());
            }
        }


        void subcibe_IO()
        {

            if (textBox_Sub_IO.Text != "")
            {
                SignalCollection signals = controller.IOSystem.GetSignals(IOFilterTypes.Unit, textBox_Sub_IO.Text.ToString());
                foreach (Signal signal in signals)
                {
                    ListViewItem item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    item.SubItems.Add(signal.Unit.ToString());
                    this.listView3.Items.Add(item);
                    item.Tag = signal;
                    signal.Changed += new EventHandler<SignalChangedEventArgs>(Signal_Changed);
                }
            }
        }


        //长按的函数
        private void Send_Exercise_num_Add(string join, string l, string num1, string num2, long lin1, long lin2)
        {
            try
            {
                using (Mastership.Request(controller.Rapid))
                {
                    if (radioButton_guanjie.Checked)
                    {


                        RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", join);
                        if (num1 == "0")
                        {
                            if (rapidData.RapidType == "num")
                            {
                                Num rd = new Num();
                                rd.FillFromString2(num1);
                                rapidData.Value = rd;

                            }
                        }
                        else
                        {

                            if ((float.Parse(textBox4.Text) + 1) < lin1)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2(num1);
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }


                    }
                    else if (radioButton_world.Checked)
                    {
                        RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", l);
                        if (num2 == "0")
                        {
                            if (rapidData.RapidType == "num")
                            {
                                Num rd = new Num();
                                rd.FillFromString2(num2);
                                rapidData.Value = rd;

                            }
                        }
                        else
                        {
                            if ((float.Parse(textBox8.Text) + 1) < lin2)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2(num2);
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }

                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void materialButton37_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {

                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join1");
                            if ((float.Parse(textBox4.Text) - 5) > -160)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "xl");
                            if ((float.Parse(textBox4.Text) - 5) > -570)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton37_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button7 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton37_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join1", "xl", "  0", "0", -155, -560);
            }
        }

        private void materialButton39_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join2");
                            if ((float.Parse(textBox5.Text) + 5) < 105)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "yl");
                            if ((float.Parse(textBox4.Text) + 5) < 570)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton39_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button2 = 1;
                timer_exercise.Start();
            }

        }

        private void materialButton39_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join2", "yl", "0", "0", 100, 560);
            }
        }

        private void materialButton38_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join2");
                            if ((float.Parse(textBox5.Text) - 5) > -105)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "yl");
                            if ((float.Parse(textBox4.Text) - 5) > -570)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }

        }

        private void materialButton38_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button8 = 1;
                timer_exercise.Start();
            }

        }

        private void materialButton38_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join2", "yl", "0", "0", -100, -560);
            }

        }

        private void materialButton41_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join3");
                            if ((float.Parse(textBox6.Text) + 5) < 65)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "zl");
                            if ((float.Parse(textBox6.Text) + 5) < 732)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton41_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button3 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton41_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join3", "zl", "0", "0", 60, 120);
            }
        }

        private void materialButton40_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join3");
                            if ((float.Parse(textBox6.Text) - 5) > -85)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "zl");
                            if ((float.Parse(textBox6.Text) - 5) > -105)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }

        }

        private void materialButton40_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button9 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton40_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join3", "zl", "0", "0", -80, -105);
            }
        }

        private void materialButton43_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join4");
                            if ((float.Parse(textBox7.Text) + 5) < 165)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "rxl");
                            if ((float.Parse(textBox7.Text) + 5) < 200)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton43_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button4 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton43_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join4", "rxl", "0", "0", 150, 170);
            }
        }

        private void materialButton42_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join4");
                            if ((float.Parse(textBox7.Text) - 5) > -155)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "rxl");
                            if ((float.Parse(textBox7.Text) - 5) > -175)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }

        }

        private void materialButton42_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button10 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton42_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join4", "rxl", "0", "0", -150, -170);
            }
        }

        private void materialButton45_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {

                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join5");
                            if ((float.Parse(textBox8.Text) + 5) < 110)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }

                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "ryl");
                            if ((float.Parse(textBox8.Text) + 5) < 200)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton45_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button5 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton45_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join5", "ryl", "0", "0", 110, 170);
            }
        }

        private void materialButton44_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join5");
                            if ((float.Parse(textBox8.Text) - 5) > -110)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "ryl");
                            if ((float.Parse(textBox8.Text) - 5) > -175)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }
        private void materialButton44_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button11 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton47_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join6");
                            if ((float.Parse(textBox9.Text) + 5) < 380)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "rzl");
                            if ((float.Parse(textBox9.Text) + 5) < 300)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("1");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }

        }

        private void materialButton47_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button6 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton47_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Add("join6", "rzl", "0", "0", 390, 170);
            }
        }

        private void materialButton44_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join5", "ryl", "0", "0", -110, -170);
            }
        }

        private void materialButton46_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                try
                {
                    using (Mastership.Request(controller.Rapid))
                    {
                        if (radioButton_guanjie.Checked)
                        {


                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "join6");
                            if ((float.Parse(textBox9.Text) - 5) > -380)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                        else if (radioButton_world.Checked)
                        {
                            RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "rzl");
                            if ((float.Parse(textBox9.Text) - 5) > -175)
                            {
                                if (rapidData.RapidType == "num")
                                {
                                    Num rd = new Num();
                                    rd.FillFromString2("2");
                                    rapidData.Value = rd;

                                }
                            }
                            else
                            {
                                MessageBox.Show("关节角度超出范围");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
            }
        }

        private void materialButton46_MouseDown(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                Button12 = 1;
                timer_exercise.Start();
            }
        }

        private void materialButton46_MouseUp(object sender, MouseEventArgs e)
        {
            if (button13.Text.ToString() == "长按")
            {
                timer_exercise.Stop();
                Send_Exercise_num_Sub("join6", "rzl", "0", "0", -390, -170);
            }
        }

        private void materialButton48_Click(object sender, EventArgs e)
        {

            try
            {
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "no_speed");
                    Num speed = (Num)rapidData.Value;
                    speed.FillFromString2(textBoxWrite_speed.Text);
                    rapidData.Value = speed;
                    MessageBox.Show("已经将最大速度设置为" + textBoxWrite_speed.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            materialLabel81.Text = materialScrollBar1.Value.ToString() + "%";
            controller.MotionSystem.SpeedRatio = Convert.ToInt32(materialScrollBar1.Value);
            materialLabel1.Text = "机器人速度" + controller.MotionSystem.SpeedRatio.ToString() + "%";

        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            materialLabel1.Text = "机器人速度" + controller.MotionSystem.SpeedRatio.ToString() + "%";

        }

        private void materialButton49_Click(object sender, EventArgs e)
        {
            numEventArgs.SendAnswer(Convert.ToDouble(textBox_TP_ReadNum.Text));

        }

        private void materialButton50_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();
            RapidSymbolSearchProperties searchProperties = RapidSymbolSearchProperties.CreateDefault();
            searchProperties.Types = SymbolTypes.Data;
            searchProperties.InUse = false;
            searchProperties.SearchMethod = SymbolSearchMethod.Block;
            searchProperties.Recursive = true;
            searchProperties.LocalSymbols = false;
            RapidSymbol[] symbols = tasks[0].SearchRapidSymbol(searchProperties, comboBox4.SelectedItem.ToString(), string.Empty);
            this.listView4.Items.Clear();
            foreach (RapidSymbol symbol in symbols)
            {
                RapidData rapidData = tasks[0].GetRapidData(symbol);
                ListViewItem item = new ListViewItem(rapidData.Name.ToString());
                item.SubItems.Add(symbol.Type.ToString());

                item.SubItems.Add(rapidData.RapidType.ToString());
                if (rapidData.Value != null)
                { 
                item.SubItems.Add(rapidData.Value.ToString());
                  }
                this.listView4.Items.Add(item);
                item.Tag = symbol;
            }

        }

        private void materialButton62_Click(object sender, EventArgs e)
        {
            ABB.Robotics.Controllers.EventLogDomain.EventLog log = controller.EventLog;
            EventLogCategory category = log.GetCategory(0);
            this.textBox_Log.Text = "";
            foreach (ABB.Robotics.Controllers.EventLogDomain.EventLogMessage eventLogMessage in category.Messages)
            {
                int Alaermno;
                Alaermno = eventLogMessage.CategoryId * 10000 + eventLogMessage.Number;
                this.textBox_Log.Text = this.textBox_Log.Text + "时间：" + eventLogMessage.Timestamp.ToString() + "  " + "报警号：" + Alaermno.ToString() + "    消息：" + eventLogMessage.Title.ToString() + "\r\n";
            }

        }

        private void materialButton52_Click(object sender, EventArgs e)
        {
            string strFileFullPath = "";
            string strFileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RAPID文件(*.mod; *.sys)|*.mod; *.sys|所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                strFileFullPath = openFileDialog.FileName;
                strFileName = openFileDialog.SafeFileName;

            }
            try
            {
                string RemoteDir = controller.FileSystem.RemoteDirectory;
                if (controller.FileSystem.FileExists("/" + strFileName))
                {
                    controller.FileSystem.PutFile(strFileFullPath, "\\" + strFileName, true);
                    MessageBox.Show("替换" + strFileName + "到HOME/test/成功");
                }
                else
                {

                    controller.FileSystem.PutFile(strFileFullPath, "\\" + strFileName, false);
                    MessageBox.Show("复制" + strFileName + "到HOME/test/成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialComboBox9_Click(object sender, EventArgs e)
        {
            try
            {

                string RemoteDir = controller.FileSystem.RemoteDirectory + "/";
                ControllerFileSystemInfo[] controllerFileSystemInfo = controller.FileSystem.GetFilesAndDirectories("HOME:");

                comboBox_jiazai.Items.Clear();

                foreach (ControllerFileSystemInfo info in controllerFileSystemInfo)
                {
                    comboBox_jiazai.Items.Add(info.Name.ToString());


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void materialComboBox10_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();
            Module[] modules = tasks[0].GetModules();
            comboBox_Save.Items.Clear();
            foreach (Module module in modules)
            {
                comboBox_Save.Items.Add(module.Name.ToString());
            }

        }

        private void materialComboBox11_Click(object sender, EventArgs e)
        {
            string RemoteDir = controller.FileSystem.RemoteDirectory;
            ControllerFileSystemInfo[] controllerFileSystemInfo = controller.FileSystem.GetFilesAndDirectories("//");
            comboBox_pgf.Items.Clear();
            foreach (ControllerFileSystemInfo info in controllerFileSystemInfo)
            {
                if (info.Name.EndsWith(".pgf", StringComparison.OrdinalIgnoreCase))
                {
                    comboBox_pgf.Items.Add(info.Name.ToString());
                }


            }

        }

        private void materialButton53_Click(object sender, EventArgs e)
        {
            if (comboBox_jiazai.SelectedItem != null)
            {
                string RemoteDir = controller.FileSystem.RemoteDirectory + @"/" + comboBox_jiazai.SelectedItem.ToString();
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    tasks = controller.Rapid.GetTasks();
                    bool flag1 = tasks[0].LoadModuleFromFile(RemoteDir, RapidLoadMode.Replace);

                    MessageBox.Show("加载成功");




                }
            }
            else
            {
                MessageBox.Show("请选择一个文件");
            }

        }

        private void materialButton54_Click(object sender, EventArgs e)
        {
            if (comboBox_Save.SelectedItem != null)
            {
                tasks = controller.Rapid.GetTasks();
                Module m1 = tasks[0].GetModule(comboBox_Save.SelectedItem.ToString());
                string RemoteDir = controller.FileSystem.RemoteDirectory;
                try
                {
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        m1.SaveToFile(RemoteDir);
                        MessageBox.Show("保存" + comboBox_Save.SelectedItem.ToString() + "成功");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("请选择一个模块");
            }
        }

        private void materialButton55_Click(object sender, EventArgs e)
        {
            if (comboBox_pgf.SelectedItem != null)
            {
                string RemoteDir = controller.FileSystem.RemoteDirectory + comboBox_pgf.SelectedItem.ToString();
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    tasks = controller.Rapid.GetTasks();
                    bool flag1 = tasks[0].LoadProgramFromFile(RemoteDir, RapidLoadMode.Replace);
                    if (flag1)
                    {
                        MessageBox.Show("加载成功");
                    }
                    else
                    {
                        MessageBox.Show("加载失败");
                    }
                }

            }
            else
            {
                string strFileFullPath = "";
                string strFileName = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "RAPID文件(*.mod; *.sys)|*.mod;*.sys|PGF文件(*.pgf)|*.pgf|所有文件|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strFileFullPath = openFileDialog.FileName;
                    strFileName = openFileDialog.SafeFileName;

                }
                try
                {
                    tasks = controller.Rapid.GetTasks();
                    if (controller.FileSystem.FileExists(@"/" + strFileName))
                    {
                        
                        controller.FileSystem.PutFile(strFileFullPath, "\\" + strFileName, true);

                    }
                    else
                    {

                        controller.FileSystem.PutFile(strFileFullPath, "\\" + strFileName, false);

                    }
                    string RemoteDir = controller.FileSystem.RemoteDirectory + @"/" + strFileName;
                    using (Mastership m = Mastership.Request(controller.Rapid))
                    {
                        
                        tasks[0].LoadProgramFromFile(RemoteDir, RapidLoadMode.Replace);


                        MessageBox.Show("加载成功");


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

            }

        }

        private void materialButton57_Click(object sender, EventArgs e)
        {
            //创建一个新的文件夹
            try
            {
                string rootDirectory = controller.FileSystem.RemoteDirectory;

                string newFolderPath = "\\NewFloder";

                if (!controller.FileSystem.DirectoryExists(newFolderPath))
                {
                    controller.FileSystem.CreateDirectory(newFolderPath);
                    MessageBox.Show($"文件夹 '{StaticString}' 创建成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"文件夹 '{StaticString}' 已经存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button21_Count++;
                    SetStaticString("\\" + "NewFloder" + button21_Count.ToString());
                    controller.FileSystem.CreateDirectory(StaticString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建文件夹失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //进行备份
            try
            {
                if (controller != null)
                {
                    UserAuthorizationSystem uas = controller.AuthenticationSystem;
                    if (uas.CheckDemandGrant(Grant.BackupController))
                    {

                        string s = controller.SystemName + "_backup" + DateTime.Now.ToString("yyyy-MM-dd");

                        if (button21_Count != 0)
                        {
                            controller.Backup($@"NewFloder{button21_Count}/" + s);
                            MessageBox.Show("备份成功");
                        }
                        else
                        {
                            controller.Backup(@"NewFloder/" + s);
                            MessageBox.Show("备份成功");

                        }

                    }
                    else
                    {
                        MessageBox.Show("没有权限");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"备份失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton58_Click(object sender, EventArgs e)
        {

            MechanicalUnitServiceInfo mechanicalUnitServiceInfo = controller.MotionSystem.ActiveMechanicalUnit.ServiceInfo;
            textBox_work.AppendText("生产总时间:" + mechanicalUnitServiceInfo.ElapsedProductionTime.TotalHours.ToString() + "小时\r\n");
            textBox_work.AppendText("自上从服务后生产总时间:" + mechanicalUnitServiceInfo.ElapsedProductionTimeSinceLastService.TotalMinutes.ToString() + "小时\r\n");
            textBox_work.AppendText("上次开机:" + mechanicalUnitServiceInfo.LastStart.ToString() + "\r\n");
            MainComputerServiceInfo mainComputerServiceInfo = controller.MainComputerServiceInfo;
            textBox_work.AppendText("主机CPU温度:" + mainComputerServiceInfo.Temperature.ToString() + "\r\n");
            textBox_work.AppendText("主机CPU信息:" + mainComputerServiceInfo.CpuInfo.ToString() + "\r\n");
            textBox_work.AppendText("主机存储大小:" + mainComputerServiceInfo.RamSize.ToString() + "\r\n");

        }

        private void materialButton59_Click(object sender, EventArgs e)
        {
            textBox_Info.AppendText("系统名" + controller.RobotWare.Name.ToString() + "\r\n");
            textBox_Info.AppendText("系统版本" + controller.RobotWare.Version.ToString() + "\r\n");
            RobotWareOptionCollection robotWares = controller.RobotWare.Options;
            foreach (RobotWareOption robotWare in robotWares)
            {
                textBox_Info.AppendText(" option :" + robotWare.ToString() + "\r\n");
            }

        }
        private void materialButton60_Click(object sender, EventArgs e)
        {
            try
            {
                remoteEP = new IPEndPoint(IPAddress.Any, egmServerPort);
                var data = _udpServer.Receive(ref remoteEP);
                robot = EgmRobot.CreateBuilder().MergeFrom(data).Build();
                MessageBox.Show("连接到 EGM 服务器成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接到 EGM 服务器失败: " + ex.Message);
            }

        }
        public static void SetStaticString(string value)
        {
            StaticString = value;
        }

        private void hopePictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Down_point = new Point(e.X, e.Y);//记录鼠标按下的点
            Last_point = new Point(e.X, e.Y);//记录鼠标按下的点
            bCatch = true;
            bGet = true;

        }

        private void hopePictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g1 = hopePictureBox1.CreateGraphics();//创建画板
            if (bCatch == true)
            {
                this.Invoke(new System.Action(() =>
                {
                    New_point = new Point(e.X, e.Y);//记录鼠标移动的新点
                    Pen pen = new Pen(Color.Red, 2);//画笔
                    g1.DrawLine(pen, Last_point, New_point);//画线
                    Last_point = New_point;//将新点赋值给上一个点
                    textBox_move.Text = "X:" + (0.8 * (New_point.X - Down_point.X)).ToString() + "Y:" + (0.8 * (New_point.Y - Down_point.Y)).ToString();//显示移动的距离
                }));

                //Create_Sensor_Message();
                if ((DateTime.Now - _lastInvokeTime).TotalMilliseconds >= THROTTLE_INTERVAL_MS)
                {
                    _lastInvokeTime = DateTime.Now;
                    System.Threading.Tasks.Task.Run(() =>
                {
                    Display_inbouse_Message(robot);
                    Create_Sensor_Message();
                });
                }
            }

        }

        private void hopePictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bCatch = false;
            Graphics g1 = hopePictureBox1.CreateGraphics();
            g1.Clear(Color.White);

        }

        private void materialButton61_Click(object sender, EventArgs e)
        {
            try
            {
                string rootDirectory = controller.FileSystem.RemoteDirectory;

                string newFolderPath = "\\FromStl";

                if (!controller.FileSystem.DirectoryExists(newFolderPath))
                {
                    controller.FileSystem.CreateDirectory(newFolderPath);
                    MessageBox.Show($"文件夹 '{StaticString}' 创建成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"创建文件夹失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string localFilePath = (controller.FileSystem.RemoteDirectory + "\\FromStl\\FromStu" + DateTime.Now.ToString("yyyy-MM-dd") + ".mod");
            string modifiedCode = textBox_Rapid.Text;
            System.IO.File.WriteAllText(localFilePath, modifiedCode, Encoding.UTF8);
            try
            {
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    string RemoteDir = controller.FileSystem.RemoteDirectory + "\\FromStl\\FromStu" + DateTime.Now.ToString("yyyy-MM-dd") + ".mod";

                    tasks = controller.Rapid.GetTasks();
                    bool flag1 = tasks[0].LoadModuleFromFile(RemoteDir, RapidLoadMode.Replace);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void materialCard7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialCard8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialCard5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hopePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text.ToString() == "点按")
            {
                button13.Text = "长按";
                button13.BackColor = Color.RoyalBlue;
            }
            else
            {
                button13.Text = "点按";
                button13.BackColor = Color.SteelBlue;
            }
        }

        private void TP_write_Click(object sender, EventArgs e)
        {

        }
    }
}