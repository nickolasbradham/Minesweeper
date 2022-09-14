
using System.Windows.Forms;

namespace nbradhamMinesweeper {
    
    /// <summary>
    /// Handles Form code.
    /// </summary>
    partial class Form1 {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            buttons=new GridButton[boardWidth,boardHeight];
            labels=new Label[boardWidth,boardHeight];
            this.components=new System.ComponentModel.Container();
            this.menuStrip1=new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            this.showStatsToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            this.panel1=new System.Windows.Forms.Panel();
            this.statusStrip1=new System.Windows.Forms.StatusStrip();
            this.timer1=new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1=new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize=new System.Drawing.Size(20,20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location=new System.Drawing.Point(0,0);
            this.menuStrip1.Name="menuStrip1";
            this.menuStrip1.Size=new System.Drawing.Size(315,28);
            this.menuStrip1.TabIndex=0;
            this.menuStrip1.Text="menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStatsToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.toolStripMenuItem1.Name="toolStripMenuItem1";
            this.toolStripMenuItem1.Size=new System.Drawing.Size(62,26);
            this.toolStripMenuItem1.Text="Game";
            // 
            // showStatsToolStripMenuItem
            // 
            this.showStatsToolStripMenuItem.Name="showStatsToolStripMenuItem";
            this.showStatsToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.showStatsToolStripMenuItem.Text="Show Stats";
            this.showStatsToolStripMenuItem.Click+=new System.EventHandler(this.ShowStatsToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name="restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.restartToolStripMenuItem.Text="Restart";
            this.restartToolStripMenuItem.Click+=new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name="exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.exitToolStripMenuItem.Text="Exit";
            this.exitToolStripMenuItem.Click+=new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name="helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.helpToolStripMenuItem.Text="Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name="instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.instructionsToolStripMenuItem.Text="Instructions";
            this.instructionsToolStripMenuItem.Click+=new System.EventHandler(this.InstructionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name="aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size=new System.Drawing.Size(224,26);
            this.aboutToolStripMenuItem.Text="About";
            this.aboutToolStripMenuItem.Click+=new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location=new System.Drawing.Point(12,31);
            this.panel1.Name="panel1";
            this.panel1.Size=new System.Drawing.Size(boardWidth*30+8,boardHeight*30+8);
            this.panel1.TabIndex=1;
            // 
            // buttons
            // 
            for(byte x = 0;x<boardWidth;x++)
                for(byte y = 0;y<boardHeight;y++) {
                    buttons[x,y]=new GridButton(x,y);
                    buttons[x,y].Location=new System.Drawing.Point(4+x*30,4+y*30);
                    buttons[x,y].Size=new System.Drawing.Size(30,30);
                    buttons[x,y].TabIndex=0;
                    buttons[x,y].UseVisualStyleBackColor=true;
                    buttons[x,y].Click+=new System.EventHandler(this.Button1_Click);
                    buttons[x,y].MouseDown+=new System.Windows.Forms.MouseEventHandler(this.Button_Right);
                    panel1.Controls.Add(buttons[x,y]);
                    labels[x,y]=new Label();
                    labels[x,y].AutoSize=true;
                    labels[x,y].Location=new System.Drawing.Point(8+x*30,10+y*30);
                    labels[x,y].Size=new System.Drawing.Size(17,17);
                    labels[x,y].TabIndex=100;
                    panel1.Controls.Add(labels[x,y]);
                }
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize=new System.Drawing.Size(20,20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location=new System.Drawing.Point(0,365);
            this.statusStrip1.Name="statusStrip1";
            this.statusStrip1.Size=new System.Drawing.Size(315,26);
            this.statusStrip1.TabIndex=2;
            this.statusStrip1.Text="statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name="toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size=new System.Drawing.Size(106,20);
            this.toolStripStatusLabel1.Text="Game Time: 0s";
            // 
            // timer1
            // 
            this.timer1.Interval=100;
            this.timer1.Tick+=new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(8F,16F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize=new System.Drawing.Size(boardWidth*30+30,boardHeight*30+70);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip=this.menuStrip1;
            this.MainMenuStrip=this.menuStrip1;
            this.Name="Form1";
            this.Text="Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private GridButton[,] buttons;
        private Label[,] labels;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}