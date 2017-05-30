namespace WildWorld
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.addAnimalBtn = new System.Windows.Forms.Button();
            this.addAnimalPanel = new System.Windows.Forms.Panel();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.AddAnimal = new System.Windows.Forms.Button();
            this.xTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.yTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.runSpeedTB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.walkSpeedTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.maxSizeTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.thirstIncTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.libIncTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hungIncTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.thirstTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.libTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hungTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.drowTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addWaterFieldBtn = new System.Windows.Forms.Button();
            this.addWaterFieldPanel = new System.Windows.Forms.Panel();
            this.addWaterField = new System.Windows.Forms.Button();
            this.x2CB = new System.Windows.Forms.ComboBox();
            this.y1CB = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.y2TB = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.x1TB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.standartBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.sexCB = new System.Windows.Forms.ComboBox();
            this.mindTypeCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.addAnimalPanel.SuspendLayout();
            this.addWaterFieldPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(649, 401);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // addAnimalBtn
            // 
            this.addAnimalBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAnimalBtn.Location = new System.Drawing.Point(61, 398);
            this.addAnimalBtn.Name = "addAnimalBtn";
            this.addAnimalBtn.Size = new System.Drawing.Size(75, 23);
            this.addAnimalBtn.TabIndex = 1;
            this.addAnimalBtn.Text = "Add animal";
            this.addAnimalBtn.UseVisualStyleBackColor = true;
            this.addAnimalBtn.Click += new System.EventHandler(this.AddAnimalBtn_Click);
            // 
            // addAnimalPanel
            // 
            this.addAnimalPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAnimalPanel.Controls.Add(this.sexCB);
            this.addAnimalPanel.Controls.Add(this.mindTypeCB);
            this.addAnimalPanel.Controls.Add(this.nameTB);
            this.addAnimalPanel.Controls.Add(this.label19);
            this.addAnimalPanel.Controls.Add(this.AddAnimal);
            this.addAnimalPanel.Controls.Add(this.xTB);
            this.addAnimalPanel.Controls.Add(this.label14);
            this.addAnimalPanel.Controls.Add(this.yTB);
            this.addAnimalPanel.Controls.Add(this.label13);
            this.addAnimalPanel.Controls.Add(this.runSpeedTB);
            this.addAnimalPanel.Controls.Add(this.label12);
            this.addAnimalPanel.Controls.Add(this.walkSpeedTB);
            this.addAnimalPanel.Controls.Add(this.label11);
            this.addAnimalPanel.Controls.Add(this.label10);
            this.addAnimalPanel.Controls.Add(this.label9);
            this.addAnimalPanel.Controls.Add(this.maxSizeTB);
            this.addAnimalPanel.Controls.Add(this.label8);
            this.addAnimalPanel.Controls.Add(this.thirstIncTB);
            this.addAnimalPanel.Controls.Add(this.label7);
            this.addAnimalPanel.Controls.Add(this.libIncTB);
            this.addAnimalPanel.Controls.Add(this.label6);
            this.addAnimalPanel.Controls.Add(this.hungIncTB);
            this.addAnimalPanel.Controls.Add(this.label5);
            this.addAnimalPanel.Controls.Add(this.thirstTB);
            this.addAnimalPanel.Controls.Add(this.label4);
            this.addAnimalPanel.Controls.Add(this.libTB);
            this.addAnimalPanel.Controls.Add(this.label3);
            this.addAnimalPanel.Controls.Add(this.hungTB);
            this.addAnimalPanel.Controls.Add(this.label2);
            this.addAnimalPanel.Controls.Add(this.drowTB);
            this.addAnimalPanel.Controls.Add(this.label1);
            this.addAnimalPanel.Location = new System.Drawing.Point(12, 12);
            this.addAnimalPanel.Name = "addAnimalPanel";
            this.addAnimalPanel.Size = new System.Drawing.Size(200, 380);
            this.addAnimalPanel.TabIndex = 2;
            this.addAnimalPanel.Visible = false;
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(91, 7);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(100, 20);
            this.nameTB.TabIndex = 29;
            this.nameTB.Text = "horse";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(50, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "Name";
            // 
            // AddAnimal
            // 
            this.AddAnimal.Location = new System.Drawing.Point(135, 342);
            this.AddAnimal.Name = "AddAnimal";
            this.AddAnimal.Size = new System.Drawing.Size(56, 23);
            this.AddAnimal.TabIndex = 3;
            this.AddAnimal.Text = "Add";
            this.AddAnimal.UseVisualStyleBackColor = true;
            this.AddAnimal.Click += new System.EventHandler(this.AddAnimal_Click);
            // 
            // xTB
            // 
            this.xTB.Location = new System.Drawing.Point(27, 345);
            this.xTB.Name = "xTB";
            this.xTB.Size = new System.Drawing.Size(36, 20);
            this.xTB.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 348);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "X";
            // 
            // yTB
            // 
            this.yTB.Location = new System.Drawing.Point(93, 345);
            this.yTB.Name = "yTB";
            this.yTB.Size = new System.Drawing.Size(36, 20);
            this.yTB.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(73, 348);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Y";
            // 
            // runSpeedTB
            // 
            this.runSpeedTB.Location = new System.Drawing.Point(91, 319);
            this.runSpeedTB.Name = "runSpeedTB";
            this.runSpeedTB.Size = new System.Drawing.Size(100, 20);
            this.runSpeedTB.TabIndex = 23;
            this.runSpeedTB.Text = "3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Running speed";
            // 
            // walkSpeedTB
            // 
            this.walkSpeedTB.Location = new System.Drawing.Point(91, 293);
            this.walkSpeedTB.Name = "walkSpeedTB";
            this.walkSpeedTB.Size = new System.Drawing.Size(100, 20);
            this.walkSpeedTB.TabIndex = 21;
            this.walkSpeedTB.Text = "2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Walking speed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sex";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Mind type";
            // 
            // maxSizeTB
            // 
            this.maxSizeTB.Location = new System.Drawing.Point(91, 215);
            this.maxSizeTB.Name = "maxSizeTB";
            this.maxSizeTB.Size = new System.Drawing.Size(100, 20);
            this.maxSizeTB.TabIndex = 15;
            this.maxSizeTB.Text = "30";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Max size";
            // 
            // thirstIncTB
            // 
            this.thirstIncTB.Location = new System.Drawing.Point(91, 189);
            this.thirstIncTB.Name = "thirstIncTB";
            this.thirstIncTB.Size = new System.Drawing.Size(100, 20);
            this.thirstIncTB.TabIndex = 13;
            this.thirstIncTB.Text = "1,0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thirst inc";
            // 
            // libIncTB
            // 
            this.libIncTB.Location = new System.Drawing.Point(91, 163);
            this.libIncTB.Name = "libIncTB";
            this.libIncTB.Size = new System.Drawing.Size(100, 20);
            this.libIncTB.TabIndex = 11;
            this.libIncTB.Text = "1,0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Libido inc";
            // 
            // hungIncTB
            // 
            this.hungIncTB.Location = new System.Drawing.Point(91, 137);
            this.hungIncTB.Name = "hungIncTB";
            this.hungIncTB.Size = new System.Drawing.Size(100, 20);
            this.hungIncTB.TabIndex = 9;
            this.hungIncTB.Text = "1,0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hunger inc";
            // 
            // thirstTB
            // 
            this.thirstTB.Location = new System.Drawing.Point(91, 111);
            this.thirstTB.Name = "thirstTB";
            this.thirstTB.Size = new System.Drawing.Size(100, 20);
            this.thirstTB.TabIndex = 7;
            this.thirstTB.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thirst";
            // 
            // libTB
            // 
            this.libTB.Location = new System.Drawing.Point(91, 85);
            this.libTB.Name = "libTB";
            this.libTB.Size = new System.Drawing.Size(100, 20);
            this.libTB.TabIndex = 5;
            this.libTB.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Libido";
            // 
            // hungTB
            // 
            this.hungTB.Location = new System.Drawing.Point(91, 59);
            this.hungTB.Name = "hungTB";
            this.hungTB.Size = new System.Drawing.Size(100, 20);
            this.hungTB.TabIndex = 3;
            this.hungTB.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hunger";
            // 
            // drowTB
            // 
            this.drowTB.Location = new System.Drawing.Point(91, 33);
            this.drowTB.Name = "drowTB";
            this.drowTB.Size = new System.Drawing.Size(100, 20);
            this.drowTB.TabIndex = 1;
            this.drowTB.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drowsiness";
            // 
            // addWaterFieldBtn
            // 
            this.addWaterFieldBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addWaterFieldBtn.Location = new System.Drawing.Point(274, 398);
            this.addWaterFieldBtn.Name = "addWaterFieldBtn";
            this.addWaterFieldBtn.Size = new System.Drawing.Size(105, 23);
            this.addWaterFieldBtn.TabIndex = 3;
            this.addWaterFieldBtn.Text = "Add water field";
            this.addWaterFieldBtn.UseVisualStyleBackColor = true;
            this.addWaterFieldBtn.Click += new System.EventHandler(this.addWaterFieldBtn_Click);
            // 
            // addWaterFieldPanel
            // 
            this.addWaterFieldPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addWaterFieldPanel.Controls.Add(this.addWaterField);
            this.addWaterFieldPanel.Controls.Add(this.x2CB);
            this.addWaterFieldPanel.Controls.Add(this.y1CB);
            this.addWaterFieldPanel.Controls.Add(this.label17);
            this.addWaterFieldPanel.Controls.Add(this.y2TB);
            this.addWaterFieldPanel.Controls.Add(this.label18);
            this.addWaterFieldPanel.Controls.Add(this.x1TB);
            this.addWaterFieldPanel.Controls.Add(this.label15);
            this.addWaterFieldPanel.Controls.Add(this.label16);
            this.addWaterFieldPanel.Location = new System.Drawing.Point(228, 292);
            this.addWaterFieldPanel.Name = "addWaterFieldPanel";
            this.addWaterFieldPanel.Size = new System.Drawing.Size(200, 100);
            this.addWaterFieldPanel.TabIndex = 4;
            this.addWaterFieldPanel.Visible = false;
            // 
            // addWaterField
            // 
            this.addWaterField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addWaterField.Location = new System.Drawing.Point(69, 64);
            this.addWaterField.Name = "addWaterField";
            this.addWaterField.Size = new System.Drawing.Size(56, 23);
            this.addWaterField.TabIndex = 28;
            this.addWaterField.Text = "Add";
            this.addWaterField.UseVisualStyleBackColor = true;
            this.addWaterField.Click += new System.EventHandler(this.addWaterField_Click);
            // 
            // x2CB
            // 
            this.x2CB.FormattingEnabled = true;
            this.x2CB.Items.AddRange(new object[] {
            "left",
            "right"});
            this.x2CB.Location = new System.Drawing.Point(26, 37);
            this.x2CB.Name = "x2CB";
            this.x2CB.Size = new System.Drawing.Size(63, 21);
            this.x2CB.TabIndex = 37;
            // 
            // y1CB
            // 
            this.y1CB.FormattingEnabled = true;
            this.y1CB.Items.AddRange(new object[] {
            "top",
            "bottom"});
            this.y1CB.Location = new System.Drawing.Point(115, 11);
            this.y1CB.Name = "y1CB";
            this.y1CB.Size = new System.Drawing.Size(63, 21);
            this.y1CB.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "X2";
            // 
            // y2TB
            // 
            this.y2TB.Location = new System.Drawing.Point(115, 37);
            this.y2TB.Name = "y2TB";
            this.y2TB.Size = new System.Drawing.Size(36, 20);
            this.y2TB.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(95, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Y2";
            // 
            // x1TB
            // 
            this.x1TB.Location = new System.Drawing.Point(26, 11);
            this.x1TB.Name = "x1TB";
            this.x1TB.Size = new System.Drawing.Size(36, 20);
            this.x1TB.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "X1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(95, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Y1";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsBtn.Location = new System.Drawing.Point(465, 398);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 5;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsPanel.Controls.Add(this.standartBtn);
            this.settingsPanel.Controls.Add(this.helpBtn);
            this.settingsPanel.Controls.Add(this.clearBtn);
            this.settingsPanel.Location = new System.Drawing.Point(434, 256);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(137, 136);
            this.settingsPanel.TabIndex = 6;
            this.settingsPanel.Visible = false;
            // 
            // standartBtn
            // 
            this.standartBtn.Location = new System.Drawing.Point(31, 21);
            this.standartBtn.Name = "standartBtn";
            this.standartBtn.Size = new System.Drawing.Size(75, 23);
            this.standartBtn.TabIndex = 2;
            this.standartBtn.Text = "Standart";
            this.standartBtn.UseVisualStyleBackColor = true;
            this.standartBtn.Click += new System.EventHandler(this.standartBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(31, 57);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(75, 23);
            this.helpBtn.TabIndex = 1;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(31, 94);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 0;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startBtn.Location = new System.Drawing.Point(591, 398);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 7;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // sexCB
            // 
            this.sexCB.FormattingEnabled = true;
            this.sexCB.Items.AddRange(new object[] {
            "m",
            "f"});
            this.sexCB.Location = new System.Drawing.Point(91, 265);
            this.sexCB.Name = "sexCB";
            this.sexCB.Size = new System.Drawing.Size(100, 21);
            this.sexCB.TabIndex = 8;
            this.sexCB.Text = "m";
            // 
            // mindTypeCB
            // 
            this.mindTypeCB.FormattingEnabled = true;
            this.mindTypeCB.Items.AddRange(new object[] {
            "herbivorous",
            "carnivore"});
            this.mindTypeCB.Location = new System.Drawing.Point(91, 241);
            this.mindTypeCB.Name = "mindTypeCB";
            this.mindTypeCB.Size = new System.Drawing.Size(100, 21);
            this.mindTypeCB.TabIndex = 9;
            this.mindTypeCB.Text = "herbivorous";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 433);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.addWaterFieldPanel);
            this.Controls.Add(this.addWaterFieldBtn);
            this.Controls.Add(this.addAnimalPanel);
            this.Controls.Add(this.addAnimalBtn);
            this.Controls.Add(this.Canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Wild world";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.addAnimalPanel.ResumeLayout(false);
            this.addAnimalPanel.PerformLayout();
            this.addWaterFieldPanel.ResumeLayout(false);
            this.addWaterFieldPanel.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button addAnimalBtn;
        private System.Windows.Forms.Panel addAnimalPanel;
        private System.Windows.Forms.TextBox xTB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox yTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox runSpeedTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox walkSpeedTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox maxSizeTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox thirstIncTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox libIncTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox hungIncTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox thirstTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox libTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hungTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox drowTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddAnimal;
        private System.Windows.Forms.Button addWaterFieldBtn;
        private System.Windows.Forms.Panel addWaterFieldPanel;
        private System.Windows.Forms.Button addWaterField;
        private System.Windows.Forms.ComboBox x2CB;
        private System.Windows.Forms.ComboBox y1CB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox y2TB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox x1TB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button standartBtn;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.ComboBox sexCB;
        private System.Windows.Forms.ComboBox mindTypeCB;
    }
}

