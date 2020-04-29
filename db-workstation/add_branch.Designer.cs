namespace db_workstation
{
    partial class add_branch
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtB_area = new System.Windows.Forms.TextBox();
            this.txtB_working_hours = new System.Windows.Forms.TextBox();
            this.txtB_phone = new System.Windows.Forms.TextBox();
            this.txtB_address = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес филиала";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Телефон ресепшена";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Площадь помещения";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Часы работы";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(149, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtB_area
            // 
            this.txtB_area.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_area.Location = new System.Drawing.Point(55, 162);
            this.txtB_area.Name = "txtB_area";
            this.txtB_area.Size = new System.Drawing.Size(321, 22);
            this.txtB_area.TabIndex = 5;
            // 
            // txtB_working_hours
            // 
            this.txtB_working_hours.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_working_hours.Location = new System.Drawing.Point(55, 207);
            this.txtB_working_hours.Name = "txtB_working_hours";
            this.txtB_working_hours.Size = new System.Drawing.Size(321, 22);
            this.txtB_working_hours.TabIndex = 6;
            // 
            // txtB_phone
            // 
            this.txtB_phone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_phone.Location = new System.Drawing.Point(55, 117);
            this.txtB_phone.Name = "txtB_phone";
            this.txtB_phone.Size = new System.Drawing.Size(321, 22);
            this.txtB_phone.TabIndex = 7;
            // 
            // txtB_address
            // 
            this.txtB_address.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtB_address.Location = new System.Drawing.Point(55, 72);
            this.txtB_address.Name = "txtB_address";
            this.txtB_address.Size = new System.Drawing.Size(321, 22);
            this.txtB_address.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // add_branch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 351);
            this.Controls.Add(this.txtB_address);
            this.Controls.Add(this.txtB_phone);
            this.Controls.Add(this.txtB_working_hours);
            this.Controls.Add(this.txtB_area);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "add_branch";
            this.Text = "Добавить филиал";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtB_area;
        private System.Windows.Forms.TextBox txtB_working_hours;
        private System.Windows.Forms.TextBox txtB_phone;
        private System.Windows.Forms.TextBox txtB_address;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
    }
}