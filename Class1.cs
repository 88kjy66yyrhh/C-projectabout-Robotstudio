using ABB.Robotics;

using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.IOSystemDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.EventLogDomain;

using Google.ProtocolBuffers;
using Google.Protobuf;
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
using ABB.Robotics.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ABB.Robotics.Controllers.MotionDomain;
using RobotStudio.Services.RobApi.RobApi1;
using RobotStudio.Services.RobApi;
using System.Security.Policy;
using abb.egm;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;
namespace WinFormsControlLibrary2
{
 
    
        
    

    //class Sensor
    //{
    //    private Thread _sensorThread = null;
        
    //    private bool _exitThread = false;
    //    private uint _seqNumber = 0;
    //    private UdpClient _udpServer = new UdpClient(6510);


    //    public void SensorThread()
    //    {
    //        string egmServerIp = "127.0.0.1"; // 替换为实际的 EGM 服务器 IP 地址
    //        int egmServerPort = 6510;
    //        // create an udp client and listen on any address and the port _ipPortNumber
           
                
           
            
            
    //        var remoteEP = new IPEndPoint(IPAddress.Any, egmServerPort);

    //        while (_exitThread == false)
    //        {
    //            // get the message from robot
    //            var data = _udpServer.Receive(ref remoteEP);
    //            if (data != null)
    //            {
    //                // de-serialize inbound message from robot
    //                EgmRobot robot = EgmRobot.CreateBuilder().MergeFrom(data).Build();//将接收到的字节数组解析为 EgmRobot 实例

    //                // display inbound message
    //                DisplayInboundMessage(robot);//显示机器人的消息

    //                // create a new outbound sensor message
    //                EgmSensor.Builder sensor = EgmSensor.CreateBuilder();//创建一个消息
    //                CreateSensorMessage(sensor);

    //                using (MemoryStream memoryStream = new MemoryStream())
    //                {
    //                    EgmSensor sensorMessage = sensor.Build();
    //                    sensorMessage.WriteTo(memoryStream);//将消息写入内存流

    //                    // send the udp message to the robot
    //                    int bytesSent = _udpServer.Send(memoryStream.ToArray(),
    //                                                   (int)memoryStream.Length, remoteEP);//发送消息
    //                    if (bytesSent < 0)
    //                    {
    //                        Console.WriteLine("Error send to robot");
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    // Display message from robot
    //    void DisplayInboundMessage(EgmRobot robot)
    //    {
    //        if (robot.HasHeader && robot.Header.HasSeqno && robot.Header.HasTm)
    //        {
    //            Console.WriteLine("Seq={0} tm={1}",
    //                robot.Header.Seqno.ToString(), robot.Header.Tm.ToString());
    //            if (Form1.bGet == true)//鼠标按下的时候获取机器人的位置
    //            {
    //                // MessageBox.Show("机器人的消息" + robot.FeedBack.Cartesian.Pos.X.ToString() + " " + robot.FeedBack.Cartesian.Pos.Y.ToString());
    //                Form1.bGet = false;
    //                Form1.robot_x_start = robot.FeedBack.Cartesian.Pos.X;
    //                Form1.robot_y_start = robot.FeedBack.Cartesian.Pos.Y;


    //            }
    //            else
    //            {
    //                Form1.robot_x_current = robot.FeedBack.Cartesian.Pos.X;
    //                Form1.robot_y_current = robot.FeedBack.Cartesian.Pos.Y;
    //            }
                
    //        }
    //        else
    //        {
    //            Console.WriteLine("No header in robot message");
    //        }
    //    }

    //    //////////////////////////////////////////////////////////////////////////
    //    // Create a sensor message to send to the robot
    //    void CreateSensorMessage(EgmSensor.Builder sensor)
    //    {
    //        // create a header
    //        EgmHeader.Builder hdr = new EgmHeader.Builder();
    //        hdr.SetSeqno(_seqNumber++)
    //            .SetTm((uint)DateTime.Now.Ticks)
    //            .SetMtype(EgmHeader.Types.MessageType.MSGTYPE_CORRECTION);

    //        sensor.SetHeader(hdr);

    //        // create some sensor data
    //        EgmPlanned.Builder planned = new EgmPlanned.Builder();
    //        EgmPose.Builder pos = new EgmPose.Builder();
    //        EgmQuaternion.Builder pq = new EgmQuaternion.Builder();
    //        EgmCartesian.Builder pc = new EgmCartesian.Builder();

    //        if (Form1.bCatch == true)
    //        {
    //            pc.SetX((float)(Form1.robot_x_start + 0.5 * (Form1.New_point.X - Form1.Down_point.X)));
    //            pc.SetY((float)(Form1.robot_y_start + 0.5 * (Form1.New_point.Y - Form1.Down_point.Y)));
    //            pc.SetZ(368);
    //        }
    //        else
    //        {
    //            pc.SetX((float)Form1.robot_x_current)
    //                     .SetY((float)Form1.robot_y_current)
    //                     .SetZ(368);
    //        }

    //        pq.SetU0(1.0)
    //            .SetU1(0.0)
    //            .SetU2(0.0)
    //            .SetU3(0.0);

    //        pos.SetPos(pc)
    //            .SetOrient(pq);

    //        planned.SetCartesian(pos);  // bind pos object to planned
    //        sensor.SetPlanned(planned); // bind planned to sensor object

    //        return;
    //    }

    //    // Start a thread to listen on inbound messages
    //    public void Start()
    //    {
    //        _sensorThread = new Thread(new ThreadStart(SensorThread));
    //        _sensorThread.Start();
    //    }

    //    // Stop and exit thread
    //    public void Stop()
    //    {
    //        _exitThread = true;
    //        _sensorThread.Abort();
    //    }
    //}
    public partial class Form1
    {
       
           // 定义一个静态字段
            public static string StaticString = "NewFloder";//将RApid文件保存到根目录下的文件夹名
        public  static int button21_Count = 1;
       

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

                Jv.SetColumn(i, CrossProduct(Zi,Pn - Pi)); // 线速度部分
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
            double[] jointAngles = {0,0,0,0, 0, 0 };
            for (int i = 0; i<6;i++)
            {
                jointAngles[i] = robot.FeedBack.Joints.JointsList[i];
            }

            Matrix<double> ja_conbi = ComputeJacobian(jointAngles);

            if(ja_conbi.Determinant() <= 0.5)
            {
                cartesian.SetX(100);
                cartesian.SetY(50);
                cartesian.SetZ(200);
            }
            else
            {
                if (bCatch == true)
                {
                    cartesian.SetX((float)(robot_x_start) + 5 * (New_point.X - Down_point.X));
                    cartesian.SetY((float)(robot_y_start) + 5 * (New_point.Y - Down_point.Y));
                    cartesian.SetZ(200);
                }
                else
                {
                    cartesian.SetX((float)robot_x_current)
                             .SetY((float)robot_y_current)
                             .SetZ(200);
                }
            }
            
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


        private void button21_Click(object sender, EventArgs e)
        {
            //创建一个新的文件夹
            try
            {
                string rootDirectory = controller.FileSystem.RemoteDirectory;

                string newFolderPath = $"{rootDirectory}/{StaticString}";

                if (!controller.FileSystem.DirectoryExists(newFolderPath))
                {
                    controller.FileSystem.CreateDirectory(newFolderPath);
                    MessageBox.Show($"文件夹 '{StaticString}' 创建成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"文件夹 '{StaticString}' 已经存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    SetStaticString("NewFloder" + button21_Count.ToString());
                    button21_Count++;
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
                        controller.Backup(@"/StaticString/" + s);
                        MessageBox.Show("备份成功");
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
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Restart.SelectedItem != null)
                {
                    using (Mastership m = Mastership.Request(controller))
                    {
                        controller.Restart((ControllerStartMode)Enum.Parse(typeof(ControllerStartMode), comboBox_Restart.SelectedItem.ToString()));
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
        private void button23_Click(object sender, EventArgs e)
        {
            textBox_Info.AppendText("系统名" + controller.RobotWare.Name.ToString() +"\r\n");
            textBox_Info.AppendText("系统版本" + controller.RobotWare.Version.ToString() + "\r\n");
            RobotWareOptionCollection robotWares = controller.RobotWare.Options;
            foreach (RobotWareOption robotWare in robotWares)
            {
                textBox_Info.AppendText(" option :"  + robotWare.ToString() + "\r\n");
            }

        }
        private void button24_Click(object sender, EventArgs e)
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
        //public void MoveJ(JointTarget target, double speed = 100, double zone = 5)
        //{
        //    // 申请 Mastership
        //    using (Mastership m = Mastership.Request(controller.Rapid))
        //    {
        //        // 目标位置为关节角度数组（单位：弧度）
         
        //        this.MoveJ(target, speed: 0.5, zone: 3); // 速度与平滑度参数[1,2](@ref)
               
        //    }
        //}
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                using(Mastership.Request(controller.Rapid))
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
        private void button27_Click(object sender, EventArgs e)
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
        private void button28_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) + 5) < 150)
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
        private void button29_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) + 5) < 175)
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
        private void button30_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) + 5) < 175)
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
                catch(Exception ex) 
                {
                    MessageBox.Show("出现异常" + ex.Message);
                }
               

            
        }
        private void button31_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) + 5) < 175)
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
        private void button33_Click(object sender, EventArgs e)
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
        private void button34_Click(object sender, EventArgs e)
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
        private void button35_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) - 5) > -105)
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
        private void button36_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) - 5) > -175)
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
        private void button37_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) - 5) > -175)
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
        private void button38_Click(object sender, EventArgs e)
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
                        if ((float.Parse(textBox4.Text) - 5) > -175)
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
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Down_point = new Point(e.X, e.Y);//记录鼠标按下的点
            Last_point = new Point(e.X, e.Y);//记录鼠标按下的点
            bCatch = true;
            bGet = true;
            //Display_inbouse_Message();
            //System.Threading.Tasks.Task.Run(() =>
            //{
            //    Display_inbouse_Message(robot);
            //});

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g1 = pictureBox1.CreateGraphics();//创建画板
            if (bCatch == true)
            {
                this.Invoke(new Action(() =>
                {
                    New_point = new Point(e.X, e.Y);//记录鼠标移动的新点
                    Pen pen = new Pen(Color.Red, 2);//画笔
                    g1.DrawLine(pen, Last_point, New_point);//画线
                    Last_point = New_point;//将新点赋值给上一个点
                    textBox_move.Text = "X:" + (0.1 * (New_point.X - Down_point.X)).ToString() + "Y:" + (0.1 * (New_point.Y - Down_point.Y)).ToString();//显示移动的距离
                }));
                
                //Create_Sensor_Message();
                System.Threading.Tasks.Task.Run(() =>
                {
                    Display_inbouse_Message(robot);
                    Create_Sensor_Message();
                });
            }
          
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            bCatch = false;
            Graphics g1 = pictureBox1.CreateGraphics();     
            g1.Clear(Color.White);
            //Display_inbouse_Message();
            // Create_Sensor_Message();
            //System.Threading.Tasks.Task.Run(() =>
            //{
            //    Display_inbouse_Message(robot);
               
            //});

        }
        public static void SetStaticString(string value)
        {
            StaticString = value;
        }

    }

}
