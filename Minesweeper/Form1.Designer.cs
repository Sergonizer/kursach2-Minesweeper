namespace Minesweeper
{
    partial class Minesweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СложностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лёгкаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средняяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сложнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свояToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stopwatch1 = new System.Windows.Forms.Label();
            this.restart_button = new System.Windows.Forms.Button();
            this.Flags = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.результатыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СложностьToolStripMenuItem,
            this.размерПоляToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // СложностьToolStripMenuItem
            // 
            this.СложностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лёгкаяToolStripMenuItem,
            this.средняяToolStripMenuItem,
            this.сложнаяToolStripMenuItem,
            this.свояToolStripMenuItem});
            this.СложностьToolStripMenuItem.Name = "СложностьToolStripMenuItem";
            this.СложностьToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.СложностьToolStripMenuItem.Text = "Сложность";
            // 
            // лёгкаяToolStripMenuItem
            // 
            this.лёгкаяToolStripMenuItem.Name = "лёгкаяToolStripMenuItem";
            this.лёгкаяToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.лёгкаяToolStripMenuItem.Text = "Лёгкая";
            this.лёгкаяToolStripMenuItem.Click += new System.EventHandler(this.лёгкаяToolStripMenuItem_Click);
            // 
            // средняяToolStripMenuItem
            // 
            this.средняяToolStripMenuItem.Name = "средняяToolStripMenuItem";
            this.средняяToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.средняяToolStripMenuItem.Text = "Средняя";
            this.средняяToolStripMenuItem.Click += new System.EventHandler(this.средняяToolStripMenuItem_Click);
            // 
            // сложнаяToolStripMenuItem
            // 
            this.сложнаяToolStripMenuItem.Name = "сложнаяToolStripMenuItem";
            this.сложнаяToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.сложнаяToolStripMenuItem.Text = "Сложная";
            this.сложнаяToolStripMenuItem.Click += new System.EventHandler(this.сложнаяToolStripMenuItem_Click);
            // 
            // свояToolStripMenuItem
            // 
            this.свояToolStripMenuItem.Name = "свояToolStripMenuItem";
            this.свояToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.свояToolStripMenuItem.Text = "Своя";
            this.свояToolStripMenuItem.Click += new System.EventHandler(this.свояToolStripMenuItem_Click);
            // 
            // размерПоляToolStripMenuItem
            // 
            this.размерПоляToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x5ToolStripMenuItem,
            this.x10ToolStripMenuItem,
            this.x15ToolStripMenuItem,
            this.свойToolStripMenuItem});
            this.размерПоляToolStripMenuItem.Name = "размерПоляToolStripMenuItem";
            this.размерПоляToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.размерПоляToolStripMenuItem.Text = "Размер поля";
            // 
            // x5ToolStripMenuItem
            // 
            this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            this.x5ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x5ToolStripMenuItem.Text = "5x5";
            this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // x10ToolStripMenuItem
            // 
            this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
            this.x10ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x10ToolStripMenuItem.Text = "10x10";
            this.x10ToolStripMenuItem.Click += new System.EventHandler(this.x10ToolStripMenuItem_Click);
            // 
            // x15ToolStripMenuItem
            // 
            this.x15ToolStripMenuItem.Name = "x15ToolStripMenuItem";
            this.x15ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.x15ToolStripMenuItem.Text = "15x15";
            this.x15ToolStripMenuItem.Click += new System.EventHandler(this.x15ToolStripMenuItem_Click);
            // 
            // свойToolStripMenuItem
            // 
            this.свойToolStripMenuItem.Name = "свойToolStripMenuItem";
            this.свойToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.свойToolStripMenuItem.Text = "Свой";
            this.свойToolStripMenuItem.Click += new System.EventHandler(this.свойToolStripMenuItem_Click);
            // 
            // результатыToolStripMenuItem
            // 
            this.результатыToolStripMenuItem.Name = "результатыToolStripMenuItem";
            this.результатыToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.результатыToolStripMenuItem.Text = "Результаты";
            this.результатыToolStripMenuItem.Click += new System.EventHandler(this.результатыToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Stopwatch1
            // 
            this.Stopwatch1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stopwatch1.Location = new System.Drawing.Point(12, 28);
            this.Stopwatch1.Name = "Stopwatch1";
            this.Stopwatch1.Size = new System.Drawing.Size(174, 58);
            this.Stopwatch1.TabIndex = 6;
            this.Stopwatch1.Text = "00:00:00";
            this.Stopwatch1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restart_button
            // 
            this.restart_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.restart_button.BackgroundImage = global::Minesweeper.Properties.Resources.restart;
            this.restart_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.restart_button.Location = new System.Drawing.Point(204, 33);
            this.restart_button.MinimumSize = new System.Drawing.Size(53, 53);
            this.restart_button.Name = "restart_button";
            this.restart_button.Size = new System.Drawing.Size(59, 59);
            this.restart_button.TabIndex = 7;
            this.restart_button.UseVisualStyleBackColor = true;
            this.restart_button.Click += new System.EventHandler(this.Restart);
            // 
            // Flags
            // 
            this.Flags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Flags.BackColor = System.Drawing.Color.Transparent;
            this.Flags.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Flags.Location = new System.Drawing.Point(281, 28);
            this.Flags.Name = "Flags";
            this.Flags.Size = new System.Drawing.Size(174, 58);
            this.Flags.TabIndex = 8;
            this.Flags.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 348);
            this.label1.TabIndex = 9;
            this.label1.Visible = false;
            // 
            // Minesweeper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(467, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flags);
            this.Controls.Add(this.restart_button);
            this.Controls.Add(this.Stopwatch1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(483, 0);
            this.Name = "Minesweeper";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem СложностьToolStripMenuItem;
        private ToolStripMenuItem размерПоляToolStripMenuItem;
        private ToolStripMenuItem лёгкаяToolStripMenuItem;
        private ToolStripMenuItem средняяToolStripMenuItem;
        private ToolStripMenuItem сложнаяToolStripMenuItem;
        private ToolStripMenuItem свояToolStripMenuItem;
        private ToolStripMenuItem x5ToolStripMenuItem;
        private ToolStripMenuItem x10ToolStripMenuItem;
        private ToolStripMenuItem x15ToolStripMenuItem;
        private ToolStripMenuItem свойToolStripMenuItem;
        private ToolStripMenuItem результатыToolStripMenuItem;
        private Label Stopwatch1;
        private Button restart_button;
        private Label Flags;
        private Label label1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}