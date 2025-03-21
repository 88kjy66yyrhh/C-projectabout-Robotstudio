using ABB.Robotics;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;

namespace WinFormsControlLibrary2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "" }, -1, Color.Empty, SystemColors.Info, null);
            listView1 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            label_Operate = new Label();
            label_Status = new Label();
            label_State = new Label();
            button13 = new Button();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            tabPage1 = new TabPage();
            button3 = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label5 = new Label();
            txtShowRdQ3 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            X = new Label();
            txtShowRdQ2 = new TextBox();
            txtShowRdQ1 = new TextBox();
            txtShowRdZ = new TextBox();
            txtShowRdY = new TextBox();
            txtShowRdX = new TextBox();
            txtShowRd = new TextBox();
            button2 = new Button();
            tabPage3 = new TabPage();
            button25 = new Button();
            listView2 = new ListView();
            名字 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            listView3 = new ListView();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            textBox_Sub_IO = new TextBox();
            label10 = new Label();
            设备名称 = new Label();
            textGetSig = new TextBox();
            textSigName = new TextBox();
            button5 = new Button();
            button4 = new Button();
            tabPage4 = new TabPage();
            button_z = new Button();
            button_y = new Button();
            Button_x = new Button();
            button38 = new Button();
            button37 = new Button();
            button36 = new Button();
            button35 = new Button();
            button34 = new Button();
            button33 = new Button();
            button31 = new Button();
            button30 = new Button();
            button29 = new Button();
            button28 = new Button();
            button27 = new Button();
            button26 = new Button();
            radioButton_User = new RadioButton();
            radioButton_WorkProject = new RadioButton();
            radioButton_Tool = new RadioButton();
            radioButton_Base = new RadioButton();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            radioButton_world = new RadioButton();
            radioButton_guanjie = new RadioButton();
            tabPage5 = new TabPage();
            textBoxWrite_speed = new TextBox();
            button7 = new Button();
            label18 = new Label();
            button6 = new Button();
            label17 = new Label();
            hScrollBar1 = new HScrollBar();
            tabPage6 = new TabPage();
            button14 = new Button();
            textBox_TP_ReadNum = new TextBox();
            textBox_TpWrite = new TextBox();
            label19 = new Label();
            tabPage7 = new TabPage();
            label21 = new Label();
            comboBox4 = new ComboBox();
            button15 = new Button();
            listView4 = new ListView();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            tabPage8 = new TabPage();
            button16 = new Button();
            textBox_Log = new TextBox();
            splitter1 = new Splitter();
            tabPage9 = new TabPage();
            comboBox_pgf = new ComboBox();
            comboBox_Save = new ComboBox();
            comboBox_jiazai = new ComboBox();
            button20 = new Button();
            button19 = new Button();
            button18 = new Button();
            button17 = new Button();
            tabPage10 = new TabPage();
            comboBox_Restart = new ComboBox();
            button22 = new Button();
            button21 = new Button();
            tabPage11 = new TabPage();
            button24 = new Button();
            textBox_work = new TextBox();
            textBox_Info = new TextBox();
            button23 = new Button();
            tabPage12 = new TabPage();
            textBox_move = new TextBox();
            label20 = new Label();
            pictureBox1 = new PictureBox();
            button32 = new Button();
            tabPage13 = new TabPage();
            button39 = new Button();
            textBox_Rapid = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer_exercise = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage7.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage9.SuspendLayout();
            tabPage10.SuspendLayout();
            tabPage11.SuspendLayout();
            tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage13.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader1 });
            listView1.Location = new Point(25, 6);
            listView1.Name = "listView1";
            listView1.Size = new Size(1123, 479);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.DoubleClick += listView_Double_click;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "IP地址";
            columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "ID";
            columnHeader8.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.DisplayIndex = 3;
            columnHeader2.Text = "是否虚拟";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.DisplayIndex = 4;
            columnHeader3.Text = "系统名称";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.DisplayIndex = 5;
            columnHeader4.Text = "控制器版本";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.DisplayIndex = 6;
            columnHeader5.Text = "控制器名称";
            columnHeader5.Width = 200;
            // 
            // columnHeader1
            // 
            columnHeader1.DisplayIndex = 2;
            columnHeader1.Text = "是否可用";
            columnHeader1.Width = 200;
            // 
            // button1
            // 
            button1.Location = new Point(357, 545);
            button1.Name = "button1";
            button1.Size = new Size(367, 82);
            button1.TabIndex = 2;
            button1.Text = "刷新";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Controls.Add(tabPage9);
            tabControl1.Controls.Add(tabPage10);
            tabControl1.Controls.Add(tabPage11);
            tabControl1.Controls.Add(tabPage12);
            tabControl1.Controls.Add(tabPage13);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2055, 1163);
            tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label_Operate);
            tabPage2.Controls.Add(label_Status);
            tabPage2.Controls.Add(label_State);
            tabPage2.Controls.Add(button13);
            tabPage2.Controls.Add(comboBox3);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(button12);
            tabPage2.Controls.Add(button11);
            tabPage2.Controls.Add(button10);
            tabPage2.Controls.Add(button9);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(listView1);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2047, 1126);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "主页";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // label_Operate
            // 
            label_Operate.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label_Operate.Location = new Point(1254, 24);
            label_Operate.Name = "label_Operate";
            label_Operate.Size = new Size(333, 63);
            label_Operate.TabIndex = 14;
            label_Operate.Text = "label21";
            label_Operate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Status
            // 
            label_Status.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label_Status.Location = new Point(1642, 268);
            label_Status.Name = "label_Status";
            label_Status.Size = new Size(333, 63);
            label_Status.TabIndex = 13;
            label_Status.Text = "label20";
            label_Status.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_State
            // 
            label_State.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label_State.Location = new Point(1628, 116);
            label_State.Name = "label_State";
            label_State.Size = new Size(333, 63);
            label_State.TabIndex = 12;
            label_State.Text = "label19";
            label_State.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button13
            // 
            button13.Location = new Point(1445, 748);
            button13.Name = "button13";
            button13.Size = new Size(250, 102);
            button13.TabIndex = 11;
            button13.Text = "设置指针";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(1686, 650);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(182, 32);
            comboBox3.TabIndex = 10;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox3.Click += comboBox3_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1405, 650);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 32);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.Click += comboBox2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1111, 650);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 32);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Click += comboBox1_Click;
            // 
            // button12
            // 
            button12.Location = new Point(1306, 386);
            button12.Name = "button12";
            button12.Size = new Size(256, 99);
            button12.TabIndex = 7;
            button12.Text = "PP TO Main";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Location = new Point(1477, 268);
            button11.Name = "button11";
            button11.Size = new Size(131, 62);
            button11.TabIndex = 6;
            button11.Text = "停止";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(1241, 268);
            button10.Name = "button10";
            button10.Size = new Size(146, 62);
            button10.TabIndex = 5;
            button10.Text = "启动";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.Location = new Point(1477, 116);
            button9.Name = "button9";
            button9.Size = new Size(131, 61);
            button9.TabIndex = 4;
            button9.Text = "下电";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1241, 116);
            button8.Name = "button8";
            button8.Size = new Size(146, 61);
            button8.TabIndex = 3;
            button8.Text = "上电";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtShowRdQ3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(X);
            tabPage1.Controls.Add(txtShowRdQ2);
            tabPage1.Controls.Add(txtShowRdQ1);
            tabPage1.Controls.Add(txtShowRdZ);
            tabPage1.Controls.Add(txtShowRdY);
            tabPage1.Controls.Add(txtShowRdX);
            tabPage1.Controls.Add(txtShowRd);
            tabPage1.Controls.Add(button2);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2047, 1126);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "变量";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(47, 601);
            button3.Name = "button3";
            button3.Size = new Size(186, 98);
            button3.TabIndex = 21;
            button3.Text = "写入";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(561, 126);
            label9.Name = "label9";
            label9.Size = new Size(46, 24);
            label9.TabIndex = 20;
            label9.Text = "变量";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(315, 126);
            label8.Name = "label8";
            label8.Size = new Size(46, 24);
            label8.TabIndex = 19;
            label8.Text = "模块";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 126);
            label7.Name = "label7";
            label7.Size = new Size(46, 24);
            label7.TabIndex = 18;
            label7.Text = "任务";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 93);
            label6.Name = "label6";
            label6.Size = new Size(0, 24);
            label6.TabIndex = 17;
            label6.Click += label6_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(494, 194);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(204, 112);
            textBox3.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(250, 194);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 112);
            textBox2.TabIndex = 15;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 194);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 112);
            textBox1.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(756, 675);
            label5.Name = "label5";
            label5.Size = new Size(36, 24);
            label5.TabIndex = 13;
            label5.Text = "Q3";
            label5.Click += label5_Click;
            // 
            // txtShowRdQ3
            // 
            txtShowRdQ3.Location = new Point(867, 617);
            txtShowRdQ3.Multiline = true;
            txtShowRdQ3.Name = "txtShowRdQ3";
            txtShowRdQ3.Size = new Size(163, 82);
            txtShowRdQ3.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(756, 531);
            label4.Name = "label4";
            label4.Size = new Size(36, 24);
            label4.TabIndex = 11;
            label4.Text = "Q2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(755, 401);
            label3.Name = "label3";
            label3.Size = new Size(36, 24);
            label3.TabIndex = 10;
            label3.Text = "Q1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(756, 282);
            label2.Name = "label2";
            label2.Size = new Size(21, 24);
            label2.TabIndex = 9;
            label2.Text = "Z";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(756, 174);
            label1.Name = "label1";
            label1.Size = new Size(21, 24);
            label1.TabIndex = 8;
            label1.Text = "Y";
            // 
            // X
            // 
            X.AutoSize = true;
            X.Location = new Point(755, 57);
            X.Name = "X";
            X.Size = new Size(22, 24);
            X.TabIndex = 7;
            X.Text = "X";
            X.Click += label1_Click;
            // 
            // txtShowRdQ2
            // 
            txtShowRdQ2.Location = new Point(867, 473);
            txtShowRdQ2.Multiline = true;
            txtShowRdQ2.Name = "txtShowRdQ2";
            txtShowRdQ2.Size = new Size(163, 82);
            txtShowRdQ2.TabIndex = 6;
            // 
            // txtShowRdQ1
            // 
            txtShowRdQ1.Location = new Point(863, 350);
            txtShowRdQ1.Multiline = true;
            txtShowRdQ1.Name = "txtShowRdQ1";
            txtShowRdQ1.Size = new Size(167, 75);
            txtShowRdQ1.TabIndex = 5;
            // 
            // txtShowRdZ
            // 
            txtShowRdZ.Location = new Point(864, 223);
            txtShowRdZ.Multiline = true;
            txtShowRdZ.Name = "txtShowRdZ";
            txtShowRdZ.Size = new Size(166, 83);
            txtShowRdZ.TabIndex = 4;
            // 
            // txtShowRdY
            // 
            txtShowRdY.Location = new Point(863, 113);
            txtShowRdY.Multiline = true;
            txtShowRdY.Name = "txtShowRdY";
            txtShowRdY.Size = new Size(167, 85);
            txtShowRdY.TabIndex = 3;
            // 
            // txtShowRdX
            // 
            txtShowRdX.Location = new Point(863, 5);
            txtShowRdX.Multiline = true;
            txtShowRdX.Name = "txtShowRdX";
            txtShowRdX.Size = new Size(167, 76);
            txtShowRdX.TabIndex = 2;
            txtShowRdX.TextChanged += textBox1_TextChanged_1;
            // 
            // txtShowRd
            // 
            txtShowRd.Location = new Point(368, 435);
            txtShowRd.Multiline = true;
            txtShowRd.Name = "txtShowRd";
            txtShowRd.Size = new Size(266, 221);
            txtShowRd.TabIndex = 1;
            txtShowRd.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(47, 401);
            button2.Name = "button2";
            button2.Size = new Size(186, 98);
            button2.TabIndex = 0;
            button2.Text = "获取";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button25);
            tabPage3.Controls.Add(listView2);
            tabPage3.Controls.Add(listView3);
            tabPage3.Controls.Add(textBox_Sub_IO);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(设备名称);
            tabPage3.Controls.Add(textGetSig);
            tabPage3.Controls.Add(textSigName);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button4);
            tabPage3.ImeMode = ImeMode.Off;
            tabPage3.Location = new Point(4, 33);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(2047, 1126);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "IO";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // button25
            // 
            button25.Location = new Point(1255, 87);
            button25.Name = "button25";
            button25.Size = new Size(154, 44);
            button25.TabIndex = 13;
            button25.Text = "重新订阅板卡";
            button25.UseVisualStyleBackColor = true;
            button25.Click += button25_Click;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { 名字, columnHeader9, columnHeader10, columnHeader19 });
            listView2.Location = new Point(500, 169);
            listView2.Name = "listView2";
            listView2.Size = new Size(598, 788);
            listView2.TabIndex = 12;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // 名字
            // 
            名字.Text = "名字";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "类型";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "值";
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "所属名称";
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader11, columnHeader12, columnHeader13, columnHeader14 });
            listViewItem2.StateImageIndex = 0;
            listView3.Items.AddRange(new ListViewItem[] { listViewItem2 });
            listView3.Location = new Point(1285, 169);
            listView3.Name = "listView3";
            listView3.Size = new Size(566, 788);
            listView3.TabIndex = 10;
            listView3.TileSize = new Size(2, 2);
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "名字";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "类型";
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "值";
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "所属设备";
            // 
            // textBox_Sub_IO
            // 
            textBox_Sub_IO.Location = new Point(1449, 27);
            textBox_Sub_IO.Multiline = true;
            textBox_Sub_IO.Name = "textBox_Sub_IO";
            textBox_Sub_IO.Size = new Size(221, 104);
            textBox_Sub_IO.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Gainsboro;
            label10.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label10.ForeColor = SystemColors.MenuHighlight;
            label10.Location = new Point(67, 878);
            label10.Name = "label10";
            label10.Size = new Size(54, 28);
            label10.TabIndex = 6;
            label10.Text = "输入";
            // 
            // 设备名称
            // 
            设备名称.AutoSize = true;
            设备名称.BackColor = Color.Gainsboro;
            设备名称.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            设备名称.ForeColor = SystemColors.MenuHighlight;
            设备名称.Location = new Point(25, 694);
            设备名称.Name = "设备名称";
            设备名称.Size = new Size(77, 28);
            设备名称.TabIndex = 5;
            设备名称.Text = "IO名称";
            设备名称.Click += label10_Click;
            // 
            // textGetSig
            // 
            textGetSig.Location = new Point(127, 833);
            textGetSig.Multiline = true;
            textGetSig.Name = "textGetSig";
            textGetSig.Size = new Size(186, 124);
            textGetSig.TabIndex = 4;
            textGetSig.TextChanged += textBox5_TextChanged;
            // 
            // textSigName
            // 
            textSigName.Location = new Point(127, 644);
            textSigName.Multiline = true;
            textSigName.Name = "textSigName";
            textSigName.Size = new Size(186, 124);
            textSigName.TabIndex = 3;
            // 
            // button5
            // 
            button5.Location = new Point(127, 463);
            button5.Name = "button5";
            button5.Size = new Size(186, 104);
            button5.TabIndex = 1;
            button5.Text = "写入IO";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(641, 27);
            button4.Name = "button4";
            button4.Size = new Size(186, 104);
            button4.TabIndex = 0;
            button4.Text = "读取IO";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(button_z);
            tabPage4.Controls.Add(button_y);
            tabPage4.Controls.Add(Button_x);
            tabPage4.Controls.Add(button38);
            tabPage4.Controls.Add(button37);
            tabPage4.Controls.Add(button36);
            tabPage4.Controls.Add(button35);
            tabPage4.Controls.Add(button34);
            tabPage4.Controls.Add(button33);
            tabPage4.Controls.Add(button31);
            tabPage4.Controls.Add(button30);
            tabPage4.Controls.Add(button29);
            tabPage4.Controls.Add(button28);
            tabPage4.Controls.Add(button27);
            tabPage4.Controls.Add(button26);
            tabPage4.Controls.Add(radioButton_User);
            tabPage4.Controls.Add(radioButton_WorkProject);
            tabPage4.Controls.Add(radioButton_Tool);
            tabPage4.Controls.Add(radioButton_Base);
            tabPage4.Controls.Add(label16);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(label14);
            tabPage4.Controls.Add(label13);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(label11);
            tabPage4.Controls.Add(textBox9);
            tabPage4.Controls.Add(textBox8);
            tabPage4.Controls.Add(textBox7);
            tabPage4.Controls.Add(textBox6);
            tabPage4.Controls.Add(textBox5);
            tabPage4.Controls.Add(textBox4);
            tabPage4.Controls.Add(radioButton_world);
            tabPage4.Controls.Add(radioButton_guanjie);
            tabPage4.Location = new Point(4, 33);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(2047, 1126);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "机器人位置";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Click += tabPage4_Click;
            // 
            // button_z
            // 
            button_z.Location = new Point(675, 807);
            button_z.Name = "button_z";
            button_z.Size = new Size(112, 92);
            button_z.TabIndex = 33;
            button_z.Text = "绕z轴旋转";
            button_z.UseVisualStyleBackColor = true;
            button_z.Click += button_z_Click;
            // 
            // button_y
            // 
            button_y.Location = new Point(419, 807);
            button_y.Name = "button_y";
            button_y.Size = new Size(112, 92);
            button_y.TabIndex = 32;
            button_y.Text = "绕y轴旋转";
            button_y.UseVisualStyleBackColor = true;
            button_y.Click += button_y_Click;
            // 
            // Button_x
            // 
            Button_x.Location = new Point(200, 807);
            Button_x.Name = "Button_x";
            Button_x.Size = new Size(112, 92);
            Button_x.TabIndex = 31;
            Button_x.Text = "绕x轴旋转";
            Button_x.UseVisualStyleBackColor = true;
            Button_x.Click += Button_x_Click;
            // 
            // button38
            // 
            button38.Location = new Point(1271, 599);
            button38.Name = "button38";
            button38.Size = new Size(73, 61);
            button38.TabIndex = 29;
            button38.Text = "-";
            button38.UseVisualStyleBackColor = true;
            button38.Click += button38_Click;
            button38.MouseDown += button38_MouseDown;
            button38.MouseUp += button38_MouseUp;
            // 
            // button37
            // 
            button37.Location = new Point(1271, 365);
            button37.Name = "button37";
            button37.Size = new Size(73, 61);
            button37.TabIndex = 28;
            button37.Text = "-";
            button37.UseVisualStyleBackColor = true;
            button37.Click += button37_Click;
            button37.MouseDown += button37_MouseDown;
            button37.MouseUp += button37_MouseUp;
            // 
            // button36
            // 
            button36.Location = new Point(1271, 189);
            button36.Name = "button36";
            button36.Size = new Size(73, 61);
            button36.TabIndex = 27;
            button36.Text = "-";
            button36.UseVisualStyleBackColor = true;
            button36.Click += button36_Click;
            button36.MouseDown += button36_MouseDown;
            button36.MouseUp += button36_MouseUp;
            // 
            // button35
            // 
            button35.Location = new Point(532, 599);
            button35.Name = "button35";
            button35.Size = new Size(73, 61);
            button35.TabIndex = 26;
            button35.Text = "-";
            button35.UseVisualStyleBackColor = true;
            button35.Click += button35_Click;
            button35.MouseDown += button35_MouseDown;
            button35.MouseUp += button35_MouseUp;
            // 
            // button34
            // 
            button34.Location = new Point(532, 365);
            button34.Name = "button34";
            button34.Size = new Size(73, 61);
            button34.TabIndex = 25;
            button34.Text = "-";
            button34.UseVisualStyleBackColor = true;
            button34.Click += button34_Click;
            button34.MouseDown += button34_MouseDown;
            button34.MouseUp += button34_MouseUp;
            // 
            // button33
            // 
            button33.Location = new Point(532, 189);
            button33.Name = "button33";
            button33.Size = new Size(73, 61);
            button33.TabIndex = 24;
            button33.Text = "-";
            button33.UseVisualStyleBackColor = true;
            button33.Click += button33_Click;
            button33.MouseDown += button33_MouseDown;
            button33.MouseUp += button33_MouseUp;
            // 
            // button31
            // 
            button31.Location = new Point(1116, 599);
            button31.Name = "button31";
            button31.Size = new Size(73, 61);
            button31.TabIndex = 23;
            button31.Text = "+";
            button31.UseVisualStyleBackColor = true;
            button31.Click += button31_Click;
            button31.MouseDown += button31_MouseDown;
            button31.MouseUp += button31_MouseUp;
            // 
            // button30
            // 
            button30.Location = new Point(1116, 365);
            button30.Name = "button30";
            button30.Size = new Size(73, 61);
            button30.TabIndex = 22;
            button30.Text = "+";
            button30.UseVisualStyleBackColor = true;
            button30.Click += button30_Click;
            button30.MouseDown += button30_MouseDown;
            button30.MouseUp += button30_MouseUp;
            // 
            // button29
            // 
            button29.Location = new Point(1116, 189);
            button29.Name = "button29";
            button29.Size = new Size(73, 61);
            button29.TabIndex = 21;
            button29.Text = "+";
            button29.UseVisualStyleBackColor = true;
            button29.Click += button29_Click;
            button29.MouseDown += button29_MouseDown;
            button29.MouseUp += button29_MouseUp;
            // 
            // button28
            // 
            button28.Location = new Point(382, 599);
            button28.Name = "button28";
            button28.Size = new Size(73, 61);
            button28.TabIndex = 20;
            button28.Text = "+";
            button28.UseVisualStyleBackColor = true;
            button28.Click += button28_Click;
            button28.MouseDown += button28_MouseDown;
            button28.MouseUp += button28_MouseUp;
            // 
            // button27
            // 
            button27.Location = new Point(382, 365);
            button27.Name = "button27";
            button27.Size = new Size(73, 61);
            button27.TabIndex = 19;
            button27.Text = "+";
            button27.UseVisualStyleBackColor = true;
            button27.Click += button27_Click;
            button27.MouseDown += button27_MouseDown;
            button27.MouseUp += button27_MouseUp;
            // 
            // button26
            // 
            button26.Location = new Point(382, 189);
            button26.Name = "button26";
            button26.Size = new Size(73, 61);
            button26.TabIndex = 18;
            button26.Text = "+";
            button26.UseVisualStyleBackColor = true;
            button26.Click += button26_Click;
            button26.MouseDown += button26_MouseDown;
            button26.MouseUp += button26_MouseUp;
            // 
            // radioButton_User
            // 
            radioButton_User.AutoSize = true;
            radioButton_User.FlatStyle = FlatStyle.Flat;
            radioButton_User.Location = new Point(376, 102);
            radioButton_User.Name = "radioButton_User";
            radioButton_User.Size = new Size(123, 28);
            radioButton_User.TabIndex = 17;
            radioButton_User.Text = "用户坐标系";
            radioButton_User.UseVisualStyleBackColor = true;
            radioButton_User.Visible = false;
            radioButton_User.CheckedChanged += radioButton_User_CheckedChanged;
            radioButton_User.Click += RadioButton_Text_Appear;
            // 
            // radioButton_WorkProject
            // 
            radioButton_WorkProject.AutoSize = true;
            radioButton_WorkProject.FlatStyle = FlatStyle.Flat;
            radioButton_WorkProject.Location = new Point(376, 48);
            radioButton_WorkProject.Name = "radioButton_WorkProject";
            radioButton_WorkProject.Size = new Size(123, 28);
            radioButton_WorkProject.TabIndex = 16;
            radioButton_WorkProject.Text = "工件坐标系";
            radioButton_WorkProject.UseVisualStyleBackColor = true;
            radioButton_WorkProject.Click += RadioButton_Text_Appear;
            // 
            // radioButton_Tool
            // 
            radioButton_Tool.AutoSize = true;
            radioButton_Tool.FlatStyle = FlatStyle.Flat;
            radioButton_Tool.Location = new Point(189, 102);
            radioButton_Tool.Name = "radioButton_Tool";
            radioButton_Tool.Size = new Size(123, 28);
            radioButton_Tool.TabIndex = 15;
            radioButton_Tool.Text = "工具坐标系";
            radioButton_Tool.UseVisualStyleBackColor = true;
            radioButton_Tool.Visible = false;
            radioButton_Tool.Click += RadioButton_Text_Appear;
            // 
            // radioButton_Base
            // 
            radioButton_Base.AutoSize = true;
            radioButton_Base.FlatStyle = FlatStyle.Flat;
            radioButton_Base.Location = new Point(187, 48);
            radioButton_Base.Name = "radioButton_Base";
            radioButton_Base.Size = new Size(105, 28);
            radioButton_Base.TabIndex = 14;
            radioButton_Base.Text = "基坐标系";
            radioButton_Base.UseVisualStyleBackColor = true;
            radioButton_Base.CheckedChanged += radioButton_Base_CheckedChanged;
            radioButton_Base.Click += RadioButton_Text_Appear;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(789, 617);
            label16.Name = "label16";
            label16.Size = new Size(28, 24);
            label16.TabIndex = 13;
            label16.Text = "J6";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(789, 402);
            label15.Name = "label15";
            label15.Size = new Size(28, 24);
            label15.TabIndex = 12;
            label15.Text = "J5";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(789, 212);
            label14.Name = "label14";
            label14.Size = new Size(28, 24);
            label14.TabIndex = 11;
            label14.Text = "J4";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(25, 617);
            label13.Name = "label13";
            label13.Size = new Size(28, 24);
            label13.TabIndex = 10;
            label13.Text = "J3";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(25, 402);
            label12.Name = "label12";
            label12.Size = new Size(28, 24);
            label12.TabIndex = 9;
            label12.Text = "J2";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(25, 212);
            label11.Name = "label11";
            label11.Size = new Size(28, 24);
            label11.TabIndex = 8;
            label11.Text = "J1";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(861, 573);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(219, 95);
            textBox9.TabIndex = 7;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(861, 361);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(219, 95);
            textBox8.TabIndex = 6;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(864, 176);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(219, 95);
            textBox7.TabIndex = 5;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(102, 573);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(219, 95);
            textBox6.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(102, 361);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(219, 95);
            textBox5.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(102, 176);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(219, 95);
            textBox4.TabIndex = 2;
            // 
            // radioButton_world
            // 
            radioButton_world.AutoSize = true;
            radioButton_world.FlatStyle = FlatStyle.Flat;
            radioButton_world.Location = new Point(42, 102);
            radioButton_world.Name = "radioButton_world";
            radioButton_world.Size = new Size(123, 28);
            radioButton_world.TabIndex = 1;
            radioButton_world.Text = "世界坐标系";
            radioButton_world.UseVisualStyleBackColor = true;
            radioButton_world.Click += RadioButton_Text_Appear;
            // 
            // radioButton_guanjie
            // 
            radioButton_guanjie.AutoSize = true;
            radioButton_guanjie.FlatAppearance.BorderColor = Color.Red;
            radioButton_guanjie.FlatAppearance.CheckedBackColor = Color.FromArgb(128, 255, 128);
            radioButton_guanjie.FlatAppearance.MouseDownBackColor = Color.Yellow;
            radioButton_guanjie.FlatStyle = FlatStyle.Flat;
            radioButton_guanjie.Location = new Point(42, 48);
            radioButton_guanjie.Name = "radioButton_guanjie";
            radioButton_guanjie.Size = new Size(123, 28);
            radioButton_guanjie.TabIndex = 0;
            radioButton_guanjie.Text = "关节坐标系";
            radioButton_guanjie.UseVisualStyleBackColor = true;
            radioButton_guanjie.CheckedChanged += radioButton1_CheckedChanged;
            radioButton_guanjie.Click += RadioButton_Text_Appear;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(textBoxWrite_speed);
            tabPage5.Controls.Add(button7);
            tabPage5.Controls.Add(label18);
            tabPage5.Controls.Add(button6);
            tabPage5.Controls.Add(label17);
            tabPage5.Controls.Add(hScrollBar1);
            tabPage5.Location = new Point(4, 33);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(2047, 1126);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "速度";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBoxWrite_speed
            // 
            textBoxWrite_speed.Location = new Point(335, 148);
            textBoxWrite_speed.Multiline = true;
            textBoxWrite_speed.Name = "textBoxWrite_speed";
            textBoxWrite_speed.Size = new Size(167, 65);
            textBoxWrite_speed.TabIndex = 5;
            // 
            // button7
            // 
            button7.Location = new Point(63, 148);
            button7.Name = "button7";
            button7.Size = new Size(154, 65);
            button7.TabIndex = 4;
            button7.Text = "写入最大速度";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(300, 619);
            label18.Name = "label18";
            label18.Size = new Size(74, 24);
            label18.TabIndex = 3;
            label18.Text = "label18";
            // 
            // button6
            // 
            button6.Location = new Point(31, 586);
            button6.Name = "button6";
            button6.Size = new Size(206, 91);
            button6.TabIndex = 2;
            button6.Text = "获取速度百分比";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label17
            // 
            label17.BackColor = Color.WhiteSmoke;
            label17.Location = new Point(381, 509);
            label17.Name = "label17";
            label17.Size = new Size(84, 35);
            label17.TabIndex = 1;
            label17.Text = "label17";
            label17.Click += label17_Click;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new Point(5, 471);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(863, 96);
            hScrollBar1.TabIndex = 0;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(button14);
            tabPage6.Controls.Add(textBox_TP_ReadNum);
            tabPage6.Controls.Add(textBox_TpWrite);
            tabPage6.Controls.Add(label19);
            tabPage6.Location = new Point(4, 33);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(2047, 1126);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "写屏幕信息";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Location = new Point(78, 193);
            button14.Name = "button14";
            button14.Size = new Size(155, 55);
            button14.TabIndex = 4;
            button14.Text = "响应ReadNUm";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // textBox_TP_ReadNum
            // 
            textBox_TP_ReadNum.Location = new Point(261, 205);
            textBox_TP_ReadNum.Multiline = true;
            textBox_TP_ReadNum.Name = "textBox_TP_ReadNum";
            textBox_TP_ReadNum.Size = new Size(150, 45);
            textBox_TP_ReadNum.TabIndex = 3;
            // 
            // textBox_TpWrite
            // 
            textBox_TpWrite.Location = new Point(239, 97);
            textBox_TpWrite.Multiline = true;
            textBox_TpWrite.Name = "textBox_TpWrite";
            textBox_TpWrite.Size = new Size(150, 45);
            textBox_TpWrite.TabIndex = 1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(136, 118);
            label19.Name = "label19";
            label19.Size = new Size(79, 24);
            label19.TabIndex = 0;
            label19.Text = "TpWrite";
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(label21);
            tabPage7.Controls.Add(comboBox4);
            tabPage7.Controls.Add(button15);
            tabPage7.Controls.Add(listView4);
            tabPage7.Location = new Point(4, 33);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(2047, 1126);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "数据";
            tabPage7.UseVisualStyleBackColor = true;
            tabPage7.Click += tabPage7_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(1388, 536);
            label21.Name = "label21";
            label21.Size = new Size(82, 24);
            label21.TabIndex = 3;
            label21.Text = "数据类型";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "robtarget", "num", "bool", "string", "pos", "orient", "jointtarget" });
            comboBox4.Location = new Point(1543, 536);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(182, 32);
            comboBox4.TabIndex = 2;
            // 
            // button15
            // 
            button15.Location = new Point(1516, 662);
            button15.Name = "button15";
            button15.Size = new Size(209, 81);
            button15.TabIndex = 1;
            button15.Text = "获取数据";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // listView4
            // 
            listView4.Columns.AddRange(new ColumnHeader[] { columnHeader15, columnHeader16, columnHeader17, columnHeader18 });
            listView4.Location = new Point(40, 111);
            listView4.Name = "listView4";
            listView4.Size = new Size(1268, 823);
            listView4.TabIndex = 0;
            listView4.UseCompatibleStateImageBehavior = false;
            listView4.View = View.Details;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "名字";
            columnHeader15.Width = 300;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "存储类型";
            columnHeader16.Width = 300;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "数据类型";
            columnHeader17.Width = 300;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "值";
            columnHeader18.Width = 300;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(button16);
            tabPage8.Controls.Add(textBox_Log);
            tabPage8.Controls.Add(splitter1);
            tabPage8.Location = new Point(4, 33);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(2047, 1126);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "日志";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Location = new Point(1474, 854);
            button16.Name = "button16";
            button16.Size = new Size(337, 139);
            button16.TabIndex = 2;
            button16.Text = "获取日志";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // textBox_Log
            // 
            textBox_Log.Location = new Point(34, 23);
            textBox_Log.Multiline = true;
            textBox_Log.Name = "textBox_Log";
            textBox_Log.Size = new Size(1374, 1045);
            textBox_Log.TabIndex = 1;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(3, 3);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 1120);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(comboBox_pgf);
            tabPage9.Controls.Add(comboBox_Save);
            tabPage9.Controls.Add(comboBox_jiazai);
            tabPage9.Controls.Add(button20);
            tabPage9.Controls.Add(button19);
            tabPage9.Controls.Add(button18);
            tabPage9.Controls.Add(button17);
            tabPage9.Location = new Point(4, 33);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(2047, 1126);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "传输文件";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // comboBox_pgf
            // 
            comboBox_pgf.FormattingEnabled = true;
            comboBox_pgf.Location = new Point(414, 835);
            comboBox_pgf.Name = "comboBox_pgf";
            comboBox_pgf.Size = new Size(182, 32);
            comboBox_pgf.TabIndex = 6;
            comboBox_pgf.Click += comboBox_pgf_Click;
            // 
            // comboBox_Save
            // 
            comboBox_Save.FormattingEnabled = true;
            comboBox_Save.Location = new Point(445, 595);
            comboBox_Save.Name = "comboBox_Save";
            comboBox_Save.Size = new Size(182, 32);
            comboBox_Save.TabIndex = 5;
            comboBox_Save.SelectedIndexChanged += comboBox_Save_SelectedIndexChanged;
            comboBox_Save.Click += comboBox_Save_Click;
            // 
            // comboBox_jiazai
            // 
            comboBox_jiazai.FormattingEnabled = true;
            comboBox_jiazai.Location = new Point(445, 299);
            comboBox_jiazai.Name = "comboBox_jiazai";
            comboBox_jiazai.Size = new Size(182, 32);
            comboBox_jiazai.TabIndex = 4;
            comboBox_jiazai.SelectedIndexChanged += comboBox_jiazai_SelectedIndexChanged;
            comboBox_jiazai.Click += comboBox5_Click;
            // 
            // button20
            // 
            button20.Location = new Point(27, 803);
            button20.Name = "button20";
            button20.Size = new Size(256, 64);
            button20.TabIndex = 3;
            button20.Text = "加载所有模块";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // button19
            // 
            button19.Location = new Point(27, 563);
            button19.Name = "button19";
            button19.Size = new Size(256, 64);
            button19.TabIndex = 2;
            button19.Text = "保存文件";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button18
            // 
            button18.Location = new Point(27, 299);
            button18.Name = "button18";
            button18.Size = new Size(256, 64);
            button18.TabIndex = 1;
            button18.Text = "加载文件";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button17
            // 
            button17.Location = new Point(27, 50);
            button17.Name = "button17";
            button17.Size = new Size(256, 64);
            button17.TabIndex = 0;
            button17.Text = "上传文件";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(comboBox_Restart);
            tabPage10.Controls.Add(button22);
            tabPage10.Controls.Add(button21);
            tabPage10.Location = new Point(4, 33);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(3);
            tabPage10.Size = new Size(2047, 1126);
            tabPage10.TabIndex = 9;
            tabPage10.Text = "备份与重启";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // comboBox_Restart
            // 
            comboBox_Restart.FormattingEnabled = true;
            comboBox_Restart.Items.AddRange(new object[] { "Warm", "Cold", "PStart", "IStart", "XStart", "SStart", "BStart" });
            comboBox_Restart.Location = new Point(348, 436);
            comboBox_Restart.Name = "comboBox_Restart";
            comboBox_Restart.Size = new Size(182, 32);
            comboBox_Restart.TabIndex = 2;
            // 
            // button22
            // 
            button22.Location = new Point(101, 404);
            button22.Name = "button22";
            button22.Size = new Size(162, 64);
            button22.TabIndex = 1;
            button22.Text = "重启";
            button22.UseVisualStyleBackColor = true;
            button22.Click += button22_Click;
            // 
            // button21
            // 
            button21.Location = new Point(101, 119);
            button21.Name = "button21";
            button21.Size = new Size(162, 64);
            button21.TabIndex = 0;
            button21.Text = "备份";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // tabPage11
            // 
            tabPage11.Controls.Add(button24);
            tabPage11.Controls.Add(textBox_work);
            tabPage11.Controls.Add(textBox_Info);
            tabPage11.Controls.Add(button23);
            tabPage11.Location = new Point(4, 33);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new Padding(3);
            tabPage11.Size = new Size(2047, 1126);
            tabPage11.TabIndex = 10;
            tabPage11.Text = "选项信息";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            button24.Location = new Point(1385, 733);
            button24.Name = "button24";
            button24.Size = new Size(239, 93);
            button24.TabIndex = 3;
            button24.Text = "获取运行时长信息";
            button24.UseVisualStyleBackColor = true;
            button24.Click += button24_Click;
            // 
            // textBox_work
            // 
            textBox_work.Location = new Point(1096, 27);
            textBox_work.Multiline = true;
            textBox_work.Name = "textBox_work";
            textBox_work.Size = new Size(875, 662);
            textBox_work.TabIndex = 2;
            // 
            // textBox_Info
            // 
            textBox_Info.Location = new Point(26, 27);
            textBox_Info.Multiline = true;
            textBox_Info.Name = "textBox_Info";
            textBox_Info.Size = new Size(875, 662);
            textBox_Info.TabIndex = 1;
            // 
            // button23
            // 
            button23.Location = new Point(295, 733);
            button23.Name = "button23";
            button23.Size = new Size(239, 93);
            button23.TabIndex = 0;
            button23.Text = "获取机器人信息";
            button23.UseVisualStyleBackColor = true;
            button23.Click += button23_Click;
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(textBox_move);
            tabPage12.Controls.Add(label20);
            tabPage12.Controls.Add(pictureBox1);
            tabPage12.Controls.Add(button32);
            tabPage12.Location = new Point(4, 33);
            tabPage12.Name = "tabPage12";
            tabPage12.Padding = new Padding(3);
            tabPage12.Size = new Size(2047, 1126);
            tabPage12.TabIndex = 11;
            tabPage12.Text = "运动";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // textBox_move
            // 
            textBox_move.Location = new Point(40, 252);
            textBox_move.Multiline = true;
            textBox_move.Name = "textBox_move";
            textBox_move.Size = new Size(205, 135);
            textBox_move.TabIndex = 3;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(293, 130);
            label20.Name = "label20";
            label20.Size = new Size(74, 24);
            label20.TabIndex = 2;
            label20.Text = "label20";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(436, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1293, 726);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button32
            // 
            button32.Location = new Point(40, 94);
            button32.Name = "button32";
            button32.Size = new Size(179, 97);
            button32.TabIndex = 0;
            button32.Text = "开始";
            button32.UseVisualStyleBackColor = true;
            button32.Click += button32_Click;
            // 
            // tabPage13
            // 
            tabPage13.Controls.Add(button39);
            tabPage13.Controls.Add(textBox_Rapid);
            tabPage13.Location = new Point(4, 33);
            tabPage13.Name = "tabPage13";
            tabPage13.Padding = new Padding(3);
            tabPage13.Size = new Size(2047, 1126);
            tabPage13.TabIndex = 12;
            tabPage13.Text = "Rapid";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // button39
            // 
            button39.Location = new Point(1624, 780);
            button39.Name = "button39";
            button39.Size = new Size(223, 107);
            button39.TabIndex = 1;
            button39.Text = "保存";
            button39.UseVisualStyleBackColor = true;
            button39.Click += button39_Click;
            // 
            // textBox_Rapid
            // 
            textBox_Rapid.Location = new Point(8, 16);
            textBox_Rapid.Multiline = true;
            textBox_Rapid.Name = "textBox_Rapid";
            textBox_Rapid.ScrollBars = ScrollBars.Both;
            textBox_Rapid.Size = new Size(1564, 871);
            textBox_Rapid.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            // 
            // timer_exercise
            // 
            timer_exercise.Interval = 1000;
            timer_exercise.Tick += timer_exercise_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2052, 1160);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            tabPage9.ResumeLayout(false);
            tabPage10.ResumeLayout(false);
            tabPage11.ResumeLayout(false);
            tabPage11.PerformLayout();
            tabPage12.ResumeLayout(false);
            tabPage12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage13.ResumeLayout(false);
            tabPage13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button2;
        private TextBox txtShowRd;
        private TextBox txtShowRdQ2;
        private TextBox txtShowRdQ1;
        private TextBox txtShowRdZ;
        private TextBox txtShowRdY;
        private TextBox txtShowRdX;
        private Label X;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private TextBox txtShowRdQ3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox3;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button button3;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private TabPage tabPage3;
        private Button button5;
        private Button button4;
        private Label 设备名称;
        private TextBox textGetSig;
        private TextBox textSigName;
        private Label label10;
        private TabPage tabPage4;
        private System.Windows.Forms.Timer timer1;
        private RadioButton radioButton_world;
        private RadioButton radioButton_guanjie;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private RadioButton radioButton_User;
        private RadioButton radioButton_WorkProject;
        private RadioButton radioButton_Tool;
        private RadioButton radioButton_Base;
        private TabPage tabPage5;
        private HScrollBar hScrollBar1;
        private Label label17;
        private Button button6;
        private Label label18;
        private Button button7;
        private TextBox textBoxWrite_speed;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button12;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button13;
        private Label label_State;
        private Label label_Operate;
        private Label label_Status;
        private TextBox textBox_Sub_IO;
        private ListView listView3;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private TabPage tabPage6;
        private TextBox textBox_TpWrite;
        private Label label19;
        private Button button14;
        private TextBox textBox_TP_ReadNum;
        private TabPage tabPage7;
        private ListView listView4;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private Label label21;
        private ComboBox comboBox4;
        private Button button15;
        private TabPage tabPage8;
        private Button button16;
        private TextBox textBox_Log;
        private Splitter splitter1;
        private TabPage tabPage9;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private ComboBox comboBox_jiazai;
        private ComboBox comboBox_Save;
        private ComboBox comboBox_pgf;
        private TabPage tabPage10;
        private Button button21;
        private ComboBox comboBox_Restart;
        private Button button22;
        private TabPage tabPage11;
        private TextBox textBox_Info;
        private Button button23;
        private Button button24;
        private TextBox textBox_work;
        private ListView listView2;
        private ColumnHeader 名字;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader19;
        private Button button25;
        private TabPage tabPage12;
        private Button button31;
        private Button button30;
        private Button button29;
        private Button button28;
        private Button button27;
        private TextBox textBox_move;
        private Label label20;
        private PictureBox pictureBox1;
        private Button button32;
        private Button button26;
        private Button button33;
        private Button button38;
        private Button button37;
        private Button button36;
        private Button button35;
        private Button button34;
        private System.Windows.Forms.Timer timer_exercise;
        private Button Button_x;
        private Button button_z;
        private Button button_y;
        private TabPage tabPage13;
        private Button button39;
        private TextBox textBox_Rapid;
    }
}