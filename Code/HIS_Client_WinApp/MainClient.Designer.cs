namespace HIS_Client_WinApp
{
    partial class MainClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPat = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtMID = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.txtNer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(100, 243);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(216, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始注射";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(100, 298);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(216, 23);
            this.btnCall.TabIndex = 1;
            this.btnCall.Text = "btnCall";
            this.btnCall.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "病人ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "药物ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "护士ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "医生ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "药物总量";
            // 
            // txtPat
            // 
            this.txtPat.Location = new System.Drawing.Point(113, 13);
            this.txtPat.Name = "txtPat";
            this.txtPat.Size = new System.Drawing.Size(203, 21);
            this.txtPat.TabIndex = 7;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(113, 193);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(203, 21);
            this.txtCount.TabIndex = 8;
            // 
            // txtMID
            // 
            this.txtMID.Location = new System.Drawing.Point(113, 148);
            this.txtMID.Name = "txtMID";
            this.txtMID.Size = new System.Drawing.Size(203, 21);
            this.txtMID.TabIndex = 9;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(113, 58);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(203, 21);
            this.txtDoc.TabIndex = 10;
            // 
            // txtNer
            // 
            this.txtNer.Location = new System.Drawing.Point(113, 103);
            this.txtNer.Name = "txtNer";
            this.txtNer.Size = new System.Drawing.Size(203, 21);
            this.txtNer.TabIndex = 11;
            // 
            // MainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 333);
            this.Controls.Add(this.txtNer);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.txtMID);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtPat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnStart);
            this.Name = "MainClient";
            this.Text = "HIS客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPat;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtMID;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtNer;
    }
}

