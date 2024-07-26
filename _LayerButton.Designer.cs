
namespace MPA_Creative
{
    partial class _LayerButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NWSE = new System.Windows.Forms.Panel();
            this.NS = new System.Windows.Forms.Panel();
            this.WE = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NWSE
            // 
            this.NWSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NWSE.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NWSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NWSE.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.NWSE.Location = new System.Drawing.Point(88, 24);
            this.NWSE.Name = "NWSE";
            this.NWSE.Size = new System.Drawing.Size(6, 6);
            this.NWSE.TabIndex = 0;
            this.NWSE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NWSE_MouseDown);
            this.NWSE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NWSE_MouseMove);
            this.NWSE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NWSE_MouseUp);
            // 
            // NS
            // 
            this.NS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NS.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NS.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.NS.Location = new System.Drawing.Point(45, 25);
            this.NS.Name = "NS";
            this.NS.Size = new System.Drawing.Size(6, 6);
            this.NS.TabIndex = 1;
            this.NS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NS_MouseDown);
            this.NS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NS_MouseMove);
            this.NS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NS_MouseUp);
            // 
            // WE
            // 
            this.WE.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.WE.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.WE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WE.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.WE.Location = new System.Drawing.Point(89, 12);
            this.WE.Name = "WE";
            this.WE.Size = new System.Drawing.Size(6, 6);
            this.WE.TabIndex = 2;
            this.WE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WE_MouseDown);
            this.WE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WE_MouseMove);
            this.WE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WE_MouseUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // _LayerButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.WE);
            this.Controls.Add(this.NS);
            this.Controls.Add(this.NWSE);
            this.Controls.Add(this.button1);
            this.Name = "_LayerButton";
            this.Size = new System.Drawing.Size(95, 31);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel NWSE;
        public System.Windows.Forms.Panel NS;
        public System.Windows.Forms.Panel WE;
        public System.Windows.Forms.Button button1;
    }
}
