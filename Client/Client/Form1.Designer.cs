
namespace Client
{
    partial class ClinetMainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TextBoxServer1 = new System.Windows.Forms.TextBox();
            this.ConnectButtonServer1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectButtonServer2 = new System.Windows.Forms.Button();
            this.TextBoxServer2 = new System.Windows.Forms.TextBox();
            this.SendMsg1 = new System.Windows.Forms.Button();
            this.SendMsgBox1 = new System.Windows.Forms.RichTextBox();
            this.SendMsgBox2 = new System.Windows.Forms.RichTextBox();
            this.SendMsg2 = new System.Windows.Forms.Button();
            this.LogMsgBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LogMsgBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TextBoxServer1
            // 
            this.TextBoxServer1.Location = new System.Drawing.Point(27, 43);
            this.TextBoxServer1.Name = "TextBoxServer1";
            this.TextBoxServer1.Size = new System.Drawing.Size(360, 25);
            this.TextBoxServer1.TabIndex = 1;
            this.TextBoxServer1.Text = "http://localhost:8000/ws/";
            // 
            // ConnectButtonServer1
            // 
            this.ConnectButtonServer1.Location = new System.Drawing.Point(393, 43);
            this.ConnectButtonServer1.Name = "ConnectButtonServer1";
            this.ConnectButtonServer1.Size = new System.Drawing.Size(91, 25);
            this.ConnectButtonServer1.TabIndex = 2;
            this.ConnectButtonServer1.Text = "Start!";
            this.ConnectButtonServer1.UseVisualStyleBackColor = true;
            this.ConnectButtonServer1.Click += new System.EventHandler(this.ConnectButtonServer1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server2";
            // 
            // ConnectButtonServer2
            // 
            this.ConnectButtonServer2.Location = new System.Drawing.Point(875, 43);
            this.ConnectButtonServer2.Name = "ConnectButtonServer2";
            this.ConnectButtonServer2.Size = new System.Drawing.Size(91, 25);
            this.ConnectButtonServer2.TabIndex = 5;
            this.ConnectButtonServer2.Text = "Start!";
            this.ConnectButtonServer2.UseVisualStyleBackColor = true;
            this.ConnectButtonServer2.Click += new System.EventHandler(this.ConnectButtonServer2_Click);
            // 
            // TextBoxServer2
            // 
            this.TextBoxServer2.Location = new System.Drawing.Point(509, 43);
            this.TextBoxServer2.Name = "TextBoxServer2";
            this.TextBoxServer2.Size = new System.Drawing.Size(360, 25);
            this.TextBoxServer2.TabIndex = 4;
            this.TextBoxServer2.Text = "http://localhost:8001/ws/";
            // 
            // SendMsg1
            // 
            this.SendMsg1.Location = new System.Drawing.Point(393, 93);
            this.SendMsg1.Name = "SendMsg1";
            this.SendMsg1.Size = new System.Drawing.Size(91, 25);
            this.SendMsg1.TabIndex = 10;
            this.SendMsg1.Text = "Send";
            this.SendMsg1.UseVisualStyleBackColor = true;
            this.SendMsg1.Click += new System.EventHandler(this.SendMsg1_Click);
            // 
            // SendMsgBox1
            // 
            this.SendMsgBox1.Location = new System.Drawing.Point(27, 93);
            this.SendMsgBox1.Name = "SendMsgBox1";
            this.SendMsgBox1.Size = new System.Drawing.Size(360, 105);
            this.SendMsgBox1.TabIndex = 11;
            this.SendMsgBox1.Text = "";
            // 
            // SendMsgBox2
            // 
            this.SendMsgBox2.Location = new System.Drawing.Point(509, 99);
            this.SendMsgBox2.Name = "SendMsgBox2";
            this.SendMsgBox2.Size = new System.Drawing.Size(360, 99);
            this.SendMsgBox2.TabIndex = 13;
            this.SendMsgBox2.Text = "";
            // 
            // SendMsg2
            // 
            this.SendMsg2.Location = new System.Drawing.Point(875, 99);
            this.SendMsg2.Name = "SendMsg2";
            this.SendMsg2.Size = new System.Drawing.Size(91, 25);
            this.SendMsg2.TabIndex = 12;
            this.SendMsg2.Text = "Send";
            this.SendMsg2.UseVisualStyleBackColor = true;
            this.SendMsg2.Click += new System.EventHandler(this.SendMsg2_Click);
            // 
            // LogMsgBox1
            // 
            this.LogMsgBox1.Location = new System.Drawing.Point(27, 237);
            this.LogMsgBox1.Name = "LogMsgBox1";
            this.LogMsgBox1.Size = new System.Drawing.Size(457, 298);
            this.LogMsgBox1.TabIndex = 14;
            this.LogMsgBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Log1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Log2";
            // 
            // LogMsgBox2
            // 
            this.LogMsgBox2.Location = new System.Drawing.Point(512, 237);
            this.LogMsgBox2.Name = "LogMsgBox2";
            this.LogMsgBox2.Size = new System.Drawing.Size(454, 298);
            this.LogMsgBox2.TabIndex = 16;
            this.LogMsgBox2.Text = "";
            // 
            // ClinetMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1000, 567);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogMsgBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LogMsgBox1);
            this.Controls.Add(this.SendMsgBox2);
            this.Controls.Add(this.SendMsg2);
            this.Controls.Add(this.SendMsgBox1);
            this.Controls.Add(this.SendMsg1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectButtonServer2);
            this.Controls.Add(this.TextBoxServer2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectButtonServer1);
            this.Controls.Add(this.TextBoxServer1);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClinetMainForm";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox TextBoxServer1;
        private System.Windows.Forms.Button ConnectButtonServer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectButtonServer2;
        private System.Windows.Forms.TextBox TextBoxServer2;
        private System.Windows.Forms.Button SendMsg1;
        private System.Windows.Forms.RichTextBox SendMsgBox1;
        private System.Windows.Forms.RichTextBox SendMsgBox2;
        private System.Windows.Forms.Button SendMsg2;
        private System.Windows.Forms.RichTextBox LogMsgBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox LogMsgBox2;
    }
}

