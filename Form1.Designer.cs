namespace PieFactory
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
            this.labelTopping = new System.Windows.Forms.Label();
            this.labelFlavor = new System.Windows.Forms.Label();
            this.labelFilling = new System.Windows.Forms.Label();
            this.listBoxOutLog = new System.Windows.Forms.ListBox();
            this.labelToppingVal = new System.Windows.Forms.Label();
            this.labelFlavorVal = new System.Windows.Forms.Label();
            this.labelFillingVal = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTopping
            // 
            this.labelTopping.AutoSize = true;
            this.labelTopping.Location = new System.Drawing.Point(13, 13);
            this.labelTopping.Name = "labelTopping";
            this.labelTopping.Size = new System.Drawing.Size(46, 13);
            this.labelTopping.TabIndex = 0;
            this.labelTopping.Text = "Topping";
            // 
            // labelFlavor
            // 
            this.labelFlavor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFlavor.Location = new System.Drawing.Point(65, 13);
            this.labelFlavor.Name = "labelFlavor";
            this.labelFlavor.Size = new System.Drawing.Size(313, 13);
            this.labelFlavor.TabIndex = 1;
            this.labelFlavor.Text = "Flavor";
            this.labelFlavor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFilling
            // 
            this.labelFilling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFilling.AutoSize = true;
            this.labelFilling.Location = new System.Drawing.Point(381, 9);
            this.labelFilling.Name = "labelFilling";
            this.labelFilling.Size = new System.Drawing.Size(33, 13);
            this.labelFilling.TabIndex = 2;
            this.labelFilling.Text = "Filling";
            // 
            // listBoxOutLog
            // 
            this.listBoxOutLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOutLog.FormattingEnabled = true;
            this.listBoxOutLog.Location = new System.Drawing.Point(12, 67);
            this.listBoxOutLog.Name = "listBoxOutLog";
            this.listBoxOutLog.Size = new System.Drawing.Size(402, 225);
            this.listBoxOutLog.TabIndex = 3;
            // 
            // labelToppingVal
            // 
            this.labelToppingVal.Location = new System.Drawing.Point(13, 26);
            this.labelToppingVal.Name = "labelToppingVal";
            this.labelToppingVal.Size = new System.Drawing.Size(46, 13);
            this.labelToppingVal.TabIndex = 4;
            this.labelToppingVal.Text = "label";
            this.labelToppingVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFlavorVal
            // 
            this.labelFlavorVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFlavorVal.Location = new System.Drawing.Point(65, 26);
            this.labelFlavorVal.Name = "labelFlavorVal";
            this.labelFlavorVal.Size = new System.Drawing.Size(294, 13);
            this.labelFlavorVal.TabIndex = 5;
            this.labelFlavorVal.Text = "label";
            this.labelFlavorVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFillingVal
            // 
            this.labelFillingVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFillingVal.Location = new System.Drawing.Point(377, 22);
            this.labelFillingVal.Name = "labelFillingVal";
            this.labelFillingVal.Size = new System.Drawing.Size(37, 17);
            this.labelFillingVal.TabIndex = 6;
            this.labelFillingVal.Text = "label";
            this.labelFillingVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 42);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 7;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(93, 42);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 8;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 309);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.labelFillingVal);
            this.Controls.Add(this.labelFlavorVal);
            this.Controls.Add(this.labelToppingVal);
            this.Controls.Add(this.listBoxOutLog);
            this.Controls.Add(this.labelFilling);
            this.Controls.Add(this.labelFlavor);
            this.Controls.Add(this.labelTopping);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTopping;
        private System.Windows.Forms.Label labelFlavor;
        private System.Windows.Forms.Label labelFilling;
        private System.Windows.Forms.ListBox listBoxOutLog;
        private System.Windows.Forms.Label labelToppingVal;
        private System.Windows.Forms.Label labelFlavorVal;
        private System.Windows.Forms.Label labelFillingVal;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
    }
}

