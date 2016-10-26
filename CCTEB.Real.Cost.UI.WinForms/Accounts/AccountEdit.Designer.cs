namespace CCTEB.Real.Cost.UI.WinForms.Accounts
{
    partial class AccountEdit
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
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccType = new System.Windows.Forms.ComboBox();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.tbAccID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAccLevel = new System.Windows.Forms.TextBox();
            this.tbFinanceName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbFinanceID = new System.Windows.Forms.TextBox();
            this.tbFinanceLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCommet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbChargingDept = new System.Windows.Forms.Label();
            this.cmbChargeBy = new System.Windows.Forms.ComboBox();
            this.lbChargingComment = new System.Windows.Forms.Label();
            this.tbPricingComent = new System.Windows.Forms.TextBox();
            this.cmbAssistBy = new PresentationControls.CheckBoxComboBox();
            this.cmbResponsibleBy = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(333, 429);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(450, 429);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "科目名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "类型：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "科目编码：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAccType
            // 
            this.cmbAccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccType.FormattingEnabled = true;
            this.cmbAccType.IntegralHeight = false;
            this.cmbAccType.Location = new System.Drawing.Point(79, 21);
            this.cmbAccType.Name = "cmbAccType";
            this.cmbAccType.Size = new System.Drawing.Size(197, 28);
            this.cmbAccType.TabIndex = 2;
            this.cmbAccType.SelectedIndexChanged += new System.EventHandler(this.cmbAccType_SelectedIndexChanged);
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(79, 55);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(197, 26);
            this.tbAccountName.TabIndex = 3;
            // 
            // tbAccID
            // 
            this.tbAccID.Location = new System.Drawing.Point(79, 87);
            this.tbAccID.Name = "tbAccID";
            this.tbAccID.Size = new System.Drawing.Size(197, 26);
            this.tbAccID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "科目级别：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "财务科目名称：";
            // 
            // tbAccLevel
            // 
            this.tbAccLevel.Location = new System.Drawing.Point(79, 119);
            this.tbAccLevel.Name = "tbAccLevel";
            this.tbAccLevel.Size = new System.Drawing.Size(197, 26);
            this.tbAccLevel.TabIndex = 3;
            // 
            // tbFinanceName
            // 
            this.tbFinanceName.Location = new System.Drawing.Point(397, 55);
            this.tbFinanceName.Name = "tbFinanceName";
            this.tbFinanceName.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "财务科目级别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "财务科目编码：";
            // 
            // tbFinanceID
            // 
            this.tbFinanceID.Location = new System.Drawing.Point(397, 87);
            this.tbFinanceID.Name = "tbFinanceID";
            this.tbFinanceID.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceID.TabIndex = 3;
            // 
            // tbFinanceLevel
            // 
            this.tbFinanceLevel.Location = new System.Drawing.Point(397, 119);
            this.tbFinanceLevel.Name = "tbFinanceLevel";
            this.tbFinanceLevel.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceLevel.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "备注：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCommet
            // 
            this.tbCommet.Location = new System.Drawing.Point(79, 219);
            this.tbCommet.Multiline = true;
            this.tbCommet.Name = "tbCommet";
            this.tbCommet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCommet.Size = new System.Drawing.Size(515, 78);
            this.tbCommet.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 396);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "标签：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(79, 393);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(515, 26);
            this.tbLabel.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "填写部门：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "协助部门：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbChargingDept
            // 
            this.lbChargingDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChargingDept.AutoSize = true;
            this.lbChargingDept.Location = new System.Drawing.Point(7, 306);
            this.lbChargingDept.Name = "lbChargingDept";
            this.lbChargingDept.Size = new System.Drawing.Size(79, 20);
            this.lbChargingDept.TabIndex = 1;
            this.lbChargingDept.Text = "收费单位：";
            this.lbChargingDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbChargeBy
            // 
            this.cmbChargeBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargeBy.FormattingEnabled = true;
            this.cmbChargeBy.Location = new System.Drawing.Point(79, 303);
            this.cmbChargeBy.Name = "cmbChargeBy";
            this.cmbChargeBy.Size = new System.Drawing.Size(515, 28);
            this.cmbChargeBy.TabIndex = 2;
            // 
            // lbChargingComment
            // 
            this.lbChargingComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChargingComment.AutoSize = true;
            this.lbChargingComment.Location = new System.Drawing.Point(7, 337);
            this.lbChargingComment.Name = "lbChargingComment";
            this.lbChargingComment.Size = new System.Drawing.Size(79, 20);
            this.lbChargingComment.TabIndex = 1;
            this.lbChargingComment.Text = "收费说明：";
            this.lbChargingComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPricingComent
            // 
            this.tbPricingComent.Location = new System.Drawing.Point(79, 337);
            this.tbPricingComent.Multiline = true;
            this.tbPricingComent.Name = "tbPricingComent";
            this.tbPricingComent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPricingComent.Size = new System.Drawing.Size(515, 50);
            this.tbPricingComent.TabIndex = 3;
            // 
            // cmbAssistBy
            // 
            checkBoxProperties2.CheckBoxPadding = new System.Windows.Forms.Padding(4, 3, 0, 14);
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbAssistBy.CheckBoxProperties = checkBoxProperties2;
            this.cmbAssistBy.DisplayMemberSingleItem = "";
            this.cmbAssistBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistBy.FormattingEnabled = true;
            this.cmbAssistBy.Location = new System.Drawing.Point(79, 185);
            this.cmbAssistBy.Name = "cmbAssistBy";
            this.cmbAssistBy.Size = new System.Drawing.Size(515, 28);
            this.cmbAssistBy.TabIndex = 4;
            this.cmbAssistBy.Click += new System.EventHandler(this.cmbResponseBy_Click);
            // 
            // cmbResponsibleBy
            // 
            this.cmbResponsibleBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsibleBy.FormattingEnabled = true;
            this.cmbResponsibleBy.Location = new System.Drawing.Point(79, 151);
            this.cmbResponsibleBy.Name = "cmbResponsibleBy";
            this.cmbResponsibleBy.Size = new System.Drawing.Size(321, 28);
            this.cmbResponsibleBy.TabIndex = 5;
            // 
            // AccountEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 474);
            this.Controls.Add(this.cmbResponsibleBy);
            this.Controls.Add(this.cmbAssistBy);
            this.Controls.Add(this.tbFinanceName);
            this.Controls.Add(this.tbFinanceLevel);
            this.Controls.Add(this.tbFinanceID);
            this.Controls.Add(this.tbPricingComent);
            this.Controls.Add(this.tbCommet);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.tbAccLevel);
            this.Controls.Add(this.tbAccID);
            this.Controls.Add(this.tbAccountName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbChargeBy);
            this.Controls.Add(this.cmbAccType);
            this.Controls.Add(this.lbChargingComment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbChargingDept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AccountEdit";
            this.Text = "AccountEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.TextBox tbAccID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAccLevel;
        private System.Windows.Forms.TextBox tbFinanceName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFinanceID;
        private System.Windows.Forms.TextBox tbFinanceLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCommet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbChargingDept;
        private System.Windows.Forms.ComboBox cmbChargeBy;
        private System.Windows.Forms.Label lbChargingComment;
        private System.Windows.Forms.TextBox tbPricingComent;
        private System.Windows.Forms.ComboBox cmbAccType;
        private PresentationControls.CheckBoxComboBox cmbAssistBy;
        private System.Windows.Forms.ComboBox cmbResponsibleBy;
    }
}