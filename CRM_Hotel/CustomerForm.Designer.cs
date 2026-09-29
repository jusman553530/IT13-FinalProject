namespace CRM.winforms
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();

            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(251, 250, 218);
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Customer";

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Text = "Register Customer";

            // First Name
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblFirstName.Location = new System.Drawing.Point(40, 95);
            this.lblFirstName.Text = "First Name *";

            this.txtFirstName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtFirstName.Location = new System.Drawing.Point(40, 120);
            this.txtFirstName.Size = new System.Drawing.Size(280, 30);

            // Middle Name
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblMiddleName.Location = new System.Drawing.Point(370, 95);
            this.lblMiddleName.Text = "Middle Name";

            this.txtMiddleName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtMiddleName.Location = new System.Drawing.Point(370, 120);
            this.txtMiddleName.Size = new System.Drawing.Size(280, 30);

            // Last Name
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblLastName.Location = new System.Drawing.Point(40, 170);
            this.lblLastName.Text = "Last Name *";

            this.txtLastName.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtLastName.Location = new System.Drawing.Point(40, 195);
            this.txtLastName.Size = new System.Drawing.Size(280, 30);

            // Contact Number
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblContactNumber.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblContactNumber.Location = new System.Drawing.Point(370, 170);
            this.lblContactNumber.Text = "Contact Number *";

            this.txtContactNumber.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtContactNumber.Location = new System.Drawing.Point(370, 195);
            this.txtContactNumber.Size = new System.Drawing.Size(280, 30);

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblEmail.Location = new System.Drawing.Point(40, 245);
            this.lblEmail.Text = "Email";

            this.txtEmail.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtEmail.Location = new System.Drawing.Point(40, 270);
            this.txtEmail.Size = new System.Drawing.Size(610, 30);

            // Address
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblAddress.Location = new System.Drawing.Point(40, 320);
            this.lblAddress.Text = "Address";

            this.txtAddress.Font = new System.Drawing.Font(
                "Segoe UI",
                10F);

            this.txtAddress.Location = new System.Drawing.Point(40, 345);
            this.txtAddress.Multiline = true;
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(610, 60);

            // Save button
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(18, 55, 42);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(390, 440);
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Cancel button
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(140, 140, 110);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);

            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(530, 440);
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblContactNumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddress);

            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtAddress);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}