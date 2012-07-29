namespace TangleEdit
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.geoMetry_Tab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.geoNameBox = new System.Windows.Forms.TextBox();
            this.ent_Place = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.geoRotBoxZ = new System.Windows.Forms.TextBox();
            this.geoRotBoxY = new System.Windows.Forms.TextBox();
            this.geoRotBoxX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.scaleZBox = new System.Windows.Forms.TextBox();
            this.scaleYBox = new System.Windows.Forms.TextBox();
            this.scaleXBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ent_Tab = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.light_Tab = new System.Windows.Forms.TabPage();
            this.gameControl1 = new TangleEdit.GameControl();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.geoMetry_Tab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ent_Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1018, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 19);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.geoMetry_Tab);
            this.tabControl1.Controls.Add(this.ent_Tab);
            this.tabControl1.Controls.Add(this.light_Tab);
            this.tabControl1.Location = new System.Drawing.Point(802, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(206, 601);
            this.tabControl1.TabIndex = 2;
            // 
            // geoMetry_Tab
            // 
            this.geoMetry_Tab.Controls.Add(this.groupBox6);
            this.geoMetry_Tab.Controls.Add(this.ent_Place);
            this.geoMetry_Tab.Controls.Add(this.groupBox5);
            this.geoMetry_Tab.Controls.Add(this.groupBox2);
            this.geoMetry_Tab.Controls.Add(this.groupBox1);
            this.geoMetry_Tab.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.geoMetry_Tab.Location = new System.Drawing.Point(4, 27);
            this.geoMetry_Tab.Name = "geoMetry_Tab";
            this.geoMetry_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.geoMetry_Tab.Size = new System.Drawing.Size(198, 570);
            this.geoMetry_Tab.TabIndex = 0;
            this.geoMetry_Tab.Text = "Geometry";
            this.geoMetry_Tab.ToolTipText = "Shapes and Terrain";
            this.geoMetry_Tab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.geoNameBox);
            this.groupBox6.Location = new System.Drawing.Point(13, 288);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(176, 74);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Name:";
            // 
            // geoNameBox
            // 
            this.geoNameBox.Location = new System.Drawing.Point(11, 27);
            this.geoNameBox.Name = "geoNameBox";
            this.geoNameBox.Size = new System.Drawing.Size(156, 25);
            this.geoNameBox.TabIndex = 0;
            // 
            // ent_Place
            // 
            this.ent_Place.Location = new System.Drawing.Point(15, 402);
            this.ent_Place.Name = "ent_Place";
            this.ent_Place.Size = new System.Drawing.Size(174, 50);
            this.ent_Place.TabIndex = 4;
            this.ent_Place.Text = "Place";
            this.ent_Place.UseVisualStyleBackColor = true;
            this.ent_Place.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Location = new System.Drawing.Point(10, 218);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(180, 58);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Behaviours";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 22);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Add Collisions?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(9, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 149);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimensions";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.geoRotBoxZ);
            this.groupBox3.Controls.Add(this.geoRotBoxY);
            this.groupBox3.Controls.Add(this.geoRotBoxX);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(4, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(93, 117);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotation";
            // 
            // geoRotBoxZ
            // 
            this.geoRotBoxZ.Location = new System.Drawing.Point(39, 82);
            this.geoRotBoxZ.Name = "geoRotBoxZ";
            this.geoRotBoxZ.Size = new System.Drawing.Size(22, 25);
            this.geoRotBoxZ.TabIndex = 8;
            // 
            // geoRotBoxY
            // 
            this.geoRotBoxY.Location = new System.Drawing.Point(39, 55);
            this.geoRotBoxY.Name = "geoRotBoxY";
            this.geoRotBoxY.Size = new System.Drawing.Size(22, 25);
            this.geoRotBoxY.TabIndex = 7;
            // 
            // geoRotBoxX
            // 
            this.geoRotBoxX.Location = new System.Drawing.Point(39, 24);
            this.geoRotBoxX.Name = "geoRotBoxX";
            this.geoRotBoxX.Size = new System.Drawing.Size(22, 25);
            this.geoRotBoxX.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.scaleZBox);
            this.groupBox4.Controls.Add(this.scaleYBox);
            this.groupBox4.Controls.Add(this.scaleXBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(97, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(83, 117);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scale";
            // 
            // scaleZBox
            // 
            this.scaleZBox.Location = new System.Drawing.Point(36, 86);
            this.scaleZBox.Name = "scaleZBox";
            this.scaleZBox.Size = new System.Drawing.Size(22, 25);
            this.scaleZBox.TabIndex = 5;
            // 
            // scaleYBox
            // 
            this.scaleYBox.Location = new System.Drawing.Point(36, 55);
            this.scaleYBox.Name = "scaleYBox";
            this.scaleYBox.Size = new System.Drawing.Size(22, 25);
            this.scaleYBox.TabIndex = 4;
            // 
            // scaleXBox
            // 
            this.scaleXBox.Location = new System.Drawing.Point(36, 24);
            this.scaleXBox.Name = "scaleXBox";
            this.scaleXBox.Size = new System.Drawing.Size(22, 25);
            this.scaleXBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Z:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "X: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Primitive :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cube",
            "Cylinder"});
            this.comboBox1.Location = new System.Drawing.Point(6, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 26);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Primitive";
            // 
            // ent_Tab
            // 
            this.ent_Tab.Controls.Add(this.listBox1);
            this.ent_Tab.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ent_Tab.Location = new System.Drawing.Point(4, 27);
            this.ent_Tab.Name = "ent_Tab";
            this.ent_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.ent_Tab.Size = new System.Drawing.Size(198, 570);
            this.ent_Tab.TabIndex = 1;
            this.ent_Tab.Text = "Entities";
            this.ent_Tab.ToolTipText = "Entity Creation - Players, ammo etc.";
            this.ent_Tab.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Items.AddRange(new object[] {
            "EntList Here"});
            this.listBox1.Location = new System.Drawing.Point(6, 164);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(186, 400);
            this.listBox1.TabIndex = 0;
            // 
            // light_Tab
            // 
            this.light_Tab.BackColor = System.Drawing.Color.Transparent;
            this.light_Tab.Location = new System.Drawing.Point(4, 27);
            this.light_Tab.Name = "light_Tab";
            this.light_Tab.Size = new System.Drawing.Size(198, 570);
            this.light_Tab.TabIndex = 2;
            this.light_Tab.Text = "Lighting";
            // 
            // gameControl1
            // 
            this.gameControl1.Location = new System.Drawing.Point(0, 29);
            this.gameControl1.Name = "gameControl1";
            this.gameControl1.Size = new System.Drawing.Size(800, 600);
            this.gameControl1.TabIndex = 3;
            this.gameControl1.Text = "gameControl1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1018, 740);
            this.Controls.Add(this.gameControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Instruction", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(200, 200);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 764);
            this.MinimumSize = new System.Drawing.Size(1024, 764);
            this.Name = "Main";
            this.Text = "Tangle Level Editor";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.geoMetry_Tab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ent_Tab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ent_Tab;
        private System.Windows.Forms.TabPage light_Tab;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.TabPage geoMetry_Tab;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox scaleZBox;
        private System.Windows.Forms.TextBox scaleYBox;
        private System.Windows.Forms.TextBox scaleXBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button ent_Place;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox geoNameBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox geoRotBoxZ;
        private System.Windows.Forms.TextBox geoRotBoxY;
        private System.Windows.Forms.TextBox geoRotBoxX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private GameControl gameControl1;
    }
}