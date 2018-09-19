namespace Visa_Instrument
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnAutoScale = new System.Windows.Forms.Button();
            this.ledBulb1 = new Visa_Instrument.LedBulb();
            this.btnOutGen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "MSO-x 3012A";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(32, 31);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(148, 30);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(32, 193);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(148, 30);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnAutoScale
            // 
            this.btnAutoScale.Location = new System.Drawing.Point(32, 141);
            this.btnAutoScale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAutoScale.Name = "btnAutoScale";
            this.btnAutoScale.Size = new System.Drawing.Size(148, 30);
            this.btnAutoScale.TabIndex = 4;
            this.btnAutoScale.Text = "Auto Scale";
            this.btnAutoScale.UseVisualStyleBackColor = true;
            this.btnAutoScale.Click += new System.EventHandler(this.btnAutoScale_Click);
            // 
            // ledBulb1
            // 
            this.ledBulb1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ledBulb1.Location = new System.Drawing.Point(176, 272);
            this.ledBulb1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ledBulb1.Name = "ledBulb1";
            this.ledBulb1.On = true;
            this.ledBulb1.Size = new System.Drawing.Size(27, 30);
            this.ledBulb1.TabIndex = 0;
            this.ledBulb1.Text = "ledBulb1";
            // 
            // btnOutGen
            // 
            this.btnOutGen.Location = new System.Drawing.Point(32, 86);
            this.btnOutGen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOutGen.Name = "btnOutGen";
            this.btnOutGen.Size = new System.Drawing.Size(148, 30);
            this.btnOutGen.TabIndex = 5;
            this.btnOutGen.Text = "Output Generator";
            this.btnOutGen.UseVisualStyleBackColor = true;
            this.btnOutGen.Click += new System.EventHandler(this.btnOutGen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 325);
            this.Controls.Add(this.btnOutGen);
            this.Controls.Add(this.btnAutoScale);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ledBulb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LedBulb ledBulb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnAutoScale;
        private System.Windows.Forms.Button btnOutGen;
    }
}

