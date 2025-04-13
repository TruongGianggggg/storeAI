namespace Store_Management_Project
{
    partial class AIForm
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
            this.radChat1 = new Telerik.WinControls.UI.RadChat();
            ((System.ComponentModel.ISupportInitialize)(this.radChat1)).BeginInit();
            this.SuspendLayout();
            // 
            // radChat1
            // 
            this.radChat1.AvatarSize = new System.Drawing.SizeF(43.75F, 43.75F);
            this.radChat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChat1.EnableAnalytics = false;
            this.radChat1.EnableGestures = false;
            this.radChat1.Location = new System.Drawing.Point(0, 0);
            this.radChat1.Margin = new System.Windows.Forms.Padding(5);
            this.radChat1.Name = "radChat1";
            this.radChat1.ShowAvatars = false;
            this.radChat1.Size = new System.Drawing.Size(433, 500);
            this.radChat1.TabIndex = 0;
            this.radChat1.Text = "radChat1";
            this.radChat1.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            this.radChat1.SendMessage += new Telerik.WinControls.UI.SendMessageEventHandler(this.radChat1_SendMessage);
            // 
            // AIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 500);
            this.Controls.Add(this.radChat1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AIForm";
            this.Text = "AIForm";
            ((System.ComponentModel.ISupportInitialize)(this.radChat1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadChat radChat1;
    }
}