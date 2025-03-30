using ABB.Robotics;

using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.IOSystemDomain;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.EventLogDomain;




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
namespace WinFormsControlLibrary2
{
    public partial class Form1 : Form
    {
        private NetworkScanner scanner = null;
        private ABB.Robotics.Controllers.Controller? controller = null;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;
        private NetworkWatcher networkwatcher = null;

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

        //private UdpClient udpClient = new UdpClient(6510);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
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

                this.listView1.Items.Add(item);//将获取的控制器信息添加到listview中
                item.Tag = controllerInfo;
            }
        }
        private void listView_Double_click(object sender, EventArgs e)
        {


            if (this.listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = this.listView1.SelectedItems[0];
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
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RapidData rapidData = controller.Rapid.GetRapidData(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
                txtShowRd.Text = rapidData.Value.ToString();
                if (rapidData.RapidType == "robtarget")
                {
                    RobTarget robTarget = (RobTarget)rapidData.Value;
                    txtShowRdX.Text = robTarget.Trans.X.ToString();
                    txtShowRdZ.Text = robTarget.Trans.Z.ToString();
                    txtShowRdY.Text = robTarget.Trans.Y.ToString();
                    txtShowRdQ1.Text = robTarget.Rot.Q1.ToString();
                    txtShowRdQ2.Text = robTarget.Rot.Q2.ToString();
                    txtShowRdQ3.Text = robTarget.Rot.Q3.ToString();
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //使用时要在示教器钟开启ALL权限
        private void button5_Click(object sender, EventArgs e)
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
                MessageBox.Show("改变量没有开启ALL权限!");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void RadioButton_Text_Appear(object sender, EventArgs e)
        {
            if (radioButton_guanjie.Checked)
            {
                this.label11.Text = "J1";
                this.label12.Text = "J2";
                this.label13.Text = "J3";
                this.label14.Text = "J4";
                this.label15.Text = "J5";
                this.label16.Text = "J6";

            }
            else if (radioButton_world.Checked
                || radioButton_Base.Checked
                || radioButton_Tool.Checked
                || radioButton_WorkProject.Checked
                || radioButton_User.Checked)
            {
                this.label11.Text = "X";
                this.label12.Text = "Y";
                this.label13.Text = "Z";
                this.label14.Text = "pitch";
                this.label15.Text = "yaw";
                this.label16.Text = "roll";


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label17.Text = hScrollBar1.Value.ToString() + "%";
            controller.MotionSystem.SpeedRatio = Convert.ToInt32(hScrollBar1.Value);
            label18.Text = "机器人速度" + controller.MotionSystem.SpeedRatio.ToString() + "%";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label18.Text = "机器人速度" + controller.MotionSystem.SpeedRatio.ToString() + "%";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                    RapidData rapidData = controller.Rapid.GetRapidData("T_ROB1", "Modle2", "no_speed");
                    Num speed = (Num)rapidData.Value;
                    speed.FillFromString2(textBoxWrite_speed.Text);
                    rapidData.Value = speed;
                    MessageBox.Show("已经将最大速度设置为"+ textBoxWrite_speed.Text.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();

            comboBox1.Items.Clear();
            for (int i = 0; i < tasks.Length; i++)
            {
                comboBox1.Items.Add(tasks[i].Name.ToString());
            }
            comboBox1.Text = tasks[0].Name.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks?.FirstOrDefault(task => task.Name == comboBox1.SelectedItem?.ToString());

            if (selectedTask != null)
            {
                Module[] modules = selectedTask.GetModules();
                comboBox2.Items.Clear();
                for (int i = 0; i < modules.Length; i++)
                {
                    comboBox2.Items.Add(modules[i].Name.ToString());
                }
                if (modules.Length > 0)
                {
                    comboBox2.Text = modules[0].Name.ToString();
                }
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();
            ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks?.FirstOrDefault(task => task.Name == comboBox1.SelectedItem?.ToString());
            if (selectedTask != null)
            {
                Module[] modules = selectedTask.GetModules();
                Module? selectedModule = modules.FirstOrDefault(module => module.Name == comboBox2.SelectedItem?.ToString());
                if (selectedModule != null)
                {
                    Routine[] routines = selectedModule.GetRoutines();
                    comboBox3.Items.Clear();
                    for (int i = 0; i < routines.Length; i++)
                    {
                        comboBox3.Items.Add(routines[i].Name.ToString());
                    }
                    if (routines.Length > 0)
                    {
                        comboBox3.Text = routines[0].Name.ToString();
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string s1 = "";
            string s2 = "";
            s1 = comboBox2.SelectedItem.ToString();
            s2 = comboBox3.SelectedItem.ToString();
            try
            {
                tasks = controller.Rapid.GetTasks();
                ABB.Robotics.Controllers.RapidDomain.Task? selectedTask = tasks.FirstOrDefault(task => task.Name == comboBox1.SelectedItem.ToString());

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
            label_Status.Text = "控制器状态：\r\n" + ex.Status.ToString() + "\r\n" + "控制器模式：\r\n" + ex.Time.ToString();

        }
        private void controller_StateChanged(object sender, StateChangedEventArgs e)
        {
            this.Invoke(new EventHandler(Uodate_GUI_State), sender, e);

        }
        private void Uodate_GUI_State(object sender, System.EventArgs e)
        {
            StateChangedEventArgs ex = (StateChangedEventArgs)e;
            label_State.Text = "控制器状态：\r\n" + ex.NewState.ToString() + "\r\n" + "控制器模式：\r\n" + ex.Time.ToString();

        }


        private void controller_OperatingModeChanged(object sender, OperatingModeChangeEventArgs e)
        {
            this.Invoke(new EventHandler(Uodate_GUI_Operate), sender, e);

        }
        private void Uodate_GUI_Operate(object sender, System.EventArgs e)
        {
            OperatingModeChangeEventArgs ex = (OperatingModeChangeEventArgs)e;
            label_Operate.Text = "控制器状态：\r\n" + ex.NewMode.ToString() + "\r\n" + "控制器模式：\r\n" + ex.Time.ToString();

        }

        private void button25_Click(object sender, EventArgs e)
        {
            subcibe_IO();
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
                    item.SubItems.Add(signal.Unit.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    this.listView3.Items.Add(item);
                    item.Tag = signal;
                    signal.Changed += new EventHandler<SignalChangedEventArgs>(Signal_Changed);
                }
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
            if (ex.InstructionType == UIInstructionType.TPWrite)
            {
                textBox_TpWrite.Text = ex.EventMessage.ToString();
            }
            else if (ex.InstructionType == UIInstructionType.TPReadNum)
            {
                numEventArgs = (UITPReadNumEventArgs)e;
                textBox_TpWrite.Text = numEventArgs.TPText.ToString();

            }

        }



        private void tabPage3_Click(object sender, EventArgs e)
        {


        }

        private void button14_Click(object sender, EventArgs e)
        {
            numEventArgs.SendAnswer(Convert.ToDouble(textBox_TP_ReadNum.Text));
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
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
                item.SubItems.Add(rapidData.Value?.ToString() ?? "null");
                this.listView4.Items.Add(item);
                item.Tag = symbol;
            }
        }

        private void button16_Click(object sender, EventArgs e)
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

        private void button17_Click(object sender, EventArgs e)
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

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox_jiazai.SelectedItem != null)
            {
                string RemoteDir = controller.FileSystem.RemoteDirectory + @"/"+comboBox_jiazai.SelectedItem.ToString();
                using (Mastership m = Mastership.Request(controller.Rapid))
                {
                tasks = controller.Rapid.GetTasks();
                    bool flag1 = tasks[0].LoadModuleFromFile(RemoteDir, RapidLoadMode.Replace);
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
                MessageBox.Show("请选择一个文件");
            }
        }

        private void button19_Click(object sender, EventArgs e)
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

        private void button20_Click(object sender, EventArgs e)
        {
            //if (comboBox_pgf.SelectedItem != null)
            //{
            //    string RemoteDir = controller.FileSystem.RemoteDirectory + comboBox_pgf.SelectedItem.ToString();
            //    using (Mastership m = Mastership.Request(controller.Rapid))
            //    {
            //        bool flag1 = tasks[0].LoadModuleFromFile(RemoteDir, RapidLoadMode.Replace);
            //        if (flag1)
            //        {
            //            MessageBox.Show("加载成功");
            //        }
            //        else
            //        {
            //            MessageBox.Show("加载失败");
            //        }
            //    }
            //}
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
                    tasks = controller.Rapid.GetTasks();
                    tasks[0].LoadModuleFromFile(RemoteDir, RapidLoadMode.Replace);


                    MessageBox.Show("加载成功");


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                
            }
            finally
            {
              
            }

        }

        private void comboBox5_Click(object sender, EventArgs e)
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

        private void comboBox_jiazai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Save_Click(object sender, EventArgs e)
        {
            tasks = controller.Rapid.GetTasks();
            Module[] modules = tasks[0].GetModules();
            comboBox_Save.Items.Clear();
            foreach (Module module in modules)
            {
                comboBox_Save.Items.Add(module.Name.ToString());
            }
        }

        private void comboBox_pgf_Click(object sender, EventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {


            try
            {
                remoteEP = new IPEndPoint(IPAddress.Any, egmServerPort);
                var data = _udpServer.Receive(ref remoteEP);
                robot = EgmRobot.CreateBuilder().MergeFrom(data).Build();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接到 EGM 服务器失败: " + ex.Message);
            }

        }

        private void radioButton_Base_CheckedChanged(object sender, EventArgs e)
        {

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
                            if ((float.Parse(textBox4.Text) + 1) < lin2)
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
                            if ((float.Parse(textBox4.Text) + 5) > lin2)
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
                Send_Exercise_num_Add("join3", "zl", "3", "3", 60, 120);
                Button3 = 0;
            }
            else if (Button4 == 1)
            {
                Send_Exercise_num_Add("join4", "rxl", "3", "3", 150, 170);
                Button4 = 0;
            }
            else if (Button5 == 1)
            {
                Send_Exercise_num_Add("join5", "ryl", "3", "3", 110, 170);
                Button5 = 0;
            }
            else if (Button6 == 1)
            {
                Send_Exercise_num_Add("join6", "rzl", "3", "3", 390, 170);
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
                Send_Exercise_num_Sub("join4", "rxl", "4", "4", -150, -170);
                Button10 = 0;
            }
            else if (Button11 == 1)
            {
                Send_Exercise_num_Sub("join5", "ryl", "4", "4", -110, -170);
                Button11 = 0;
            }
            else if (Button12 == 1)
            {
                Send_Exercise_num_Sub("join6", "rzl", "4", "4", -390, -170);
                Button12 = 0;
            }
        }

        private void button26_MouseDown(object sender, MouseEventArgs e)
        {
            Button1 = 1;
            timer_exercise.Start();

        }

        private void button26_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join1", "xl", "0", "0", 155, 560);


        }
        private void button27_MouseDown(object sender, MouseEventArgs e)
        {
            Button2 = 1;
            timer_exercise.Start();

        }

        private void button27_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join2", "yl", "0", "0", 100, 560);

        }
        private void button28_MouseDown(object sender, MouseEventArgs e)
        {
            Button3 = 1;
            timer_exercise.Start();

        }

        private void button28_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join3", "zl", "0", "0", 60, 120);


        }
        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            Button4 = 1;
            timer_exercise.Start();

        }

        private void button29_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join4", "rxl", "0", "0", 150, 170);


        }
        private void button30_MouseDown(object sender, MouseEventArgs e)
        {
            Button5 = 1;
            timer_exercise.Start();

        }

        private void button30_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join5", "ryl", "0", "0", 110, 170);


        }
        private void button31_MouseDown(object sender, MouseEventArgs e)
        {
            Button6 = 1;
            timer_exercise.Start();

        }

        private void button31_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Add("join6", "rzl", "0", "0", 390, 170);


        }
        private void button33_MouseDown(object sender, MouseEventArgs e)
        {
            Button7 = 1;
            timer_exercise.Start();

        }

        private void button33_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join1", "xl", "  0", "0", -155, -560);


        }
        private void button34_MouseDown(object sender, MouseEventArgs e)
        {
            Button8 = 1;
            timer_exercise.Start();

        }

        private void button34_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join2", "yl", "0", "0", -100, -560);


        }
        private void button35_MouseDown(object sender, MouseEventArgs e)
        {
            Button9 = 1;
            timer_exercise.Start();

        }

        private void button35_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join3", "zl", "0", "0", -80, -105);


        }
        private void button36_MouseDown(object sender, MouseEventArgs e)
        {
            Button10 = 1;
            timer_exercise.Start();

        }

        private void button36_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join4", "rxl", "0", "0", -150, -170);

        }
        private void button37_MouseDown(object sender, MouseEventArgs e)
        {
            Button11 = 1;
            timer_exercise.Start();

        }

        private void button37_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join5", "ryl", "0", "0", -110, -170);
        }
        private void button38_MouseDown(object sender, MouseEventArgs e)
        {
            Button12 = 1;
            timer_exercise.Start();

        }

        private void button38_MouseUp(object sender, MouseEventArgs e)
        {
            timer_exercise.Stop();
            Send_Exercise_num_Sub("join6", "rzl", "0", "0", -390, -170);


        }


        private void Button_x_Click(object sender, EventArgs e)
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

        private void button_y_Click(object sender, EventArgs e)
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

        private void button_z_Click(object sender, EventArgs e)
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

        private void button39_Click(object sender, EventArgs e)
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
            string localFilePath = (controller.FileSystem.RemoteDirectory + "\\FromStl\\FromStu" + DateTime.Now.ToString("yyyy-MM-dd")+".mod");
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

        private void comboBox_Save_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_User_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}

