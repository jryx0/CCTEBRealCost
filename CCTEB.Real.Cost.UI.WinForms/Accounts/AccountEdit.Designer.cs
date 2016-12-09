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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbAccName = new System.Windows.Forms.Label();
            this.lbAccID = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.tbAccID = new System.Windows.Forms.TextBox();
            this.lbLevel = new System.Windows.Forms.Label();
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
            this.cbIsCharging = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(333, 405);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(450, 405);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbAccName
            // 
            this.lbAccName.AutoSize = true;
            this.lbAccName.Location = new System.Drawing.Point(7, 20);
            this.lbAccName.Name = "lbAccName";
            this.lbAccName.Size = new System.Drawing.Size(79, 20);
            this.lbAccName.TabIndex = 1;
            this.lbAccName.Text = "科目名称：";
            this.lbAccName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbAccID
            // 
            this.lbAccID.AutoSize = true;
            this.lbAccID.Location = new System.Drawing.Point(7, 53);
            this.lbAccID.Name = "lbAccID";
            this.lbAccID.Size = new System.Drawing.Size(79, 20);
            this.lbAccID.TabIndex = 1;
            this.lbAccID.Text = "科目编码：";
            this.lbAccID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(79, 17);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(197, 26);
            this.tbAccountName.TabIndex = 3;
            this.tbAccountName.TextChanged += new System.EventHandler(this.AccountValue_NameChanged);
            // 
            // tbAccID
            // 
            this.tbAccID.Location = new System.Drawing.Point(79, 50);
            this.tbAccID.Name = "tbAccID";
            this.tbAccID.Size = new System.Drawing.Size(197, 26);
            this.tbAccID.TabIndex = 3;
            this.tbAccID.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // lbLevel
            // 
            this.lbLevel.AutoSize = true;
            this.lbLevel.Location = new System.Drawing.Point(7, 86);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(79, 20);
            this.lbLevel.TabIndex = 1;
            this.lbLevel.Text = "科目级别：";
            this.lbLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "财务科目名称：";
            // 
            // tbAccLevel
            // 
            this.tbAccLevel.Location = new System.Drawing.Point(79, 83);
            this.tbAccLevel.Name = "tbAccLevel";
            this.tbAccLevel.Size = new System.Drawing.Size(197, 26);
            this.tbAccLevel.TabIndex = 3;
            this.tbAccLevel.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // tbFinanceName
            // 
            this.tbFinanceName.Location = new System.Drawing.Point(397, 17);
            this.tbFinanceName.Name = "tbFinanceName";
            this.tbFinanceName.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceName.TabIndex = 3;
            this.tbFinanceName.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "财务科目级别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "财务科目编码：";
            // 
            // tbFinanceID
            // 
            this.tbFinanceID.Location = new System.Drawing.Point(397, 50);
            this.tbFinanceID.Name = "tbFinanceID";
            this.tbFinanceID.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceID.TabIndex = 3;
            this.tbFinanceID.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // tbFinanceLevel
            // 
            this.tbFinanceLevel.Location = new System.Drawing.Point(397, 83);
            this.tbFinanceLevel.Name = "tbFinanceLevel";
            this.tbFinanceLevel.Size = new System.Drawing.Size(197, 26);
            this.tbFinanceLevel.TabIndex = 3;
            this.tbFinanceLevel.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "备注：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCommet
            // 
            this.tbCommet.Location = new System.Drawing.Point(79, 186);
            this.tbCommet.Multiline = true;
            this.tbCommet.Name = "tbCommet";
            this.tbCommet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCommet.Size = new System.Drawing.Size(515, 78);
            this.tbCommet.TabIndex = 3;
            this.tbCommet.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "标签：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(79, 271);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(515, 26);
            this.tbLabel.TabIndex = 3;
            this.tbLabel.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "填写部门：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 155);
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
            this.lbChargingDept.Location = new System.Drawing.Point(7, 305);
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
            this.cmbChargeBy.Location = new System.Drawing.Point(79, 305);
            this.cmbChargeBy.Name = "cmbChargeBy";
            this.cmbChargeBy.Size = new System.Drawing.Size(321, 28);
            this.cmbChargeBy.TabIndex = 2;
            this.cmbChargeBy.SelectedIndexChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // lbChargingComment
            // 
            this.lbChargingComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbChargingComment.AutoSize = true;
            this.lbChargingComment.Location = new System.Drawing.Point(7, 343);
            this.lbChargingComment.Name = "lbChargingComment";
            this.lbChargingComment.Size = new System.Drawing.Size(79, 20);
            this.lbChargingComment.TabIndex = 1;
            this.lbChargingComment.Text = "收费说明：";
            this.lbChargingComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPricingComent
            // 
            this.tbPricingComent.Location = new System.Drawing.Point(79, 340);
            this.tbPricingComent.Multiline = true;
            this.tbPricingComent.Name = "tbPricingComent";
            this.tbPricingComent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPricingComent.Size = new System.Drawing.Size(515, 50);
            this.tbPricingComent.TabIndex = 3;
            this.tbPricingComent.TextChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // cmbAssistBy
            // 
            checkBoxProperties1.CheckBoxPadding = new System.Windows.Forms.Padding(4, 3, 0, 14);
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbAssistBy.CheckBoxProperties = checkBoxProperties1;
            this.cmbAssistBy.DisplayMemberSingleItem = "";
            this.cmbAssistBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistBy.FormattingEnabled = true;
            this.cmbAssistBy.Location = new System.Drawing.Point(79, 151);
            this.cmbAssistBy.Name = "cmbAssistBy";
            this.cmbAssistBy.Size = new System.Drawing.Size(515, 28);
            this.cmbAssistBy.TabIndex = 4;
            this.cmbAssistBy.SelectedIndexChanged += new System.EventHandler(this.AccountValue_Changed);
            this.cmbAssistBy.Click += new System.EventHandler(this.cmbResponseBy_Click);
            // 
            // cmbResponsibleBy
            // 
            this.cmbResponsibleBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsibleBy.FormattingEnabled = true;
            this.cmbResponsibleBy.Location = new System.Drawing.Point(79, 116);
            this.cmbResponsibleBy.Name = "cmbResponsibleBy";
            this.cmbResponsibleBy.Size = new System.Drawing.Size(515, 28);
            this.cmbResponsibleBy.TabIndex = 5;
            this.cmbResponsibleBy.SelectedIndexChanged += new System.EventHandler(this.AccountValue_Changed);
            // 
            // cbIsCharging
            // 
            this.cbIsCharging.AutoSize = true;
            this.cbIsCharging.Location = new System.Drawing.Point(425, 307);
            this.cbIsCharging.Name = "cbIsCharging";
            this.cbIsCharging.Size = new System.Drawing.Size(84, 24);
            this.cbIsCharging.TabIndex = 6;
            this.cbIsCharging.Text = "是否收费";
            this.cbIsCharging.UseVisualStyleBackColor = true;
            // 
            // AccountEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 456);
            this.Controls.Add(this.cbIsCharging);
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
            this.Controls.Add(this.lbChargingComment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbChargingDept);
            this.Controls.Add(this.lbAccID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbLevel);
            this.Controls.Add(this.lbAccName);
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
        private System.Windows.Forms.Label lbAccName;
        private System.Windows.Forms.Label lbAccID;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.TextBox tbAccID;
        private System.Windows.Forms.Label lbLevel;
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
        private PresentationControls.CheckBoxComboBox cmbAssistBy;
        private System.Windows.Forms.ComboBox cmbResponsibleBy;
        private System.Windows.Forms.CheckBox cbIsCharging;
    }
}