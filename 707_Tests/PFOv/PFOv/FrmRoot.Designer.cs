namespace PFOv
{
    partial class FrmRoot
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoot));
            this.flaObj = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.flaObj)).BeginInit();
            this.SuspendLayout();
            // 
            // flaObj
            // 
            this.flaObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flaObj.Enabled = true;
            this.flaObj.Location = new System.Drawing.Point(0, 0);
            this.flaObj.Name = "flaObj";
            this.flaObj.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flaObj.OcxState")));
            this.flaObj.Size = new System.Drawing.Size(800, 600);
            this.flaObj.TabIndex = 0;
            // 
            // FrmRoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.flaObj);
            this.Location = new System.Drawing.Point(40, 40);
            this.MaximizeBox = false;
            this.Name = "FrmRoot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.p_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flaObj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash flaObj;
        private System.Windows.Forms.Timer timer1;
    }
}

