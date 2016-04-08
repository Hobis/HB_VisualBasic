namespace Roland
{
    partial class FormMain
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
            this.wbRoot = new System.Windows.Forms.WebBrowser();
            this.tmRoot = new System.Windows.Forms.Timer(this.components);
            this.btn1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbRoot
            // 
            this.wbRoot.AllowNavigation = false;
            this.wbRoot.AllowWebBrowserDrop = false;
            this.wbRoot.IsWebBrowserContextMenuEnabled = false;
            this.wbRoot.Location = new System.Drawing.Point(12, 12);
            this.wbRoot.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRoot.Name = "wbRoot";
            this.wbRoot.ScrollBarsEnabled = false;
            this.wbRoot.Size = new System.Drawing.Size(20, 20);
            this.wbRoot.TabIndex = 0;
            this.wbRoot.TabStop = false;
            this.wbRoot.WebBrowserShortcutsEnabled = false;
            // 
            // tmRoot
            // 
            this.tmRoot.Tick += new System.EventHandler(this.p_tmRoot_Tick);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(713, 565);
            this.btn1.Name = "btn1";
            this.btn1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.p_btn1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.wbRoot);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.p_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbRoot;
        private System.Windows.Forms.Timer tmRoot;
        private System.Windows.Forms.Button btn1;
    }
}

