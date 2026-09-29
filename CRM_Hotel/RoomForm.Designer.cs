namespace CRM.winforms
{
    partial class RoomForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;

        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cmbRoomType;

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;

        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();

            this.lblRoomType = new System.Windows.Forms.Label();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();

            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();

            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();

            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(251, 250, 218);
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Room";

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(550, 90);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI",
                20F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Add Room";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font(
                "Segoe UI",
                9.5F);
            this.lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(210, 225, 215);
            this.lblSubtitle.Location = new System.Drawing.Point(29, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Enter the room information";

            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            this.lblRoomNumber.ForeColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblRoomNumber.Location = new System.Drawing.Point(35, 120);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Text = "Room Number";

            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.txtRoomNumber.Location =
                new System.Drawing.Point(35, 145);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size =
                new System.Drawing.Size(480, 27);
            this.txtRoomNumber.TabIndex = 1;

            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            this.lblRoomType.ForeColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblRoomType.Location =
                new System.Drawing.Point(35, 190);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Text = "Room Type";

            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Items.AddRange(
                new object[]
                {
                    "Standard",
                    "Deluxe",
                    "Suite"
                });
            this.cmbRoomType.Location =
                new System.Drawing.Point(35, 215);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size =
                new System.Drawing.Size(480, 28);
            this.cmbRoomType.TabIndex = 2;

            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblStatus.Location =
                new System.Drawing.Point(35, 260);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Status";

            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(
                new object[]
                {
                    "Available",
                    "Occupied",
                    "Maintenance"
                });
            this.cmbStatus.Location =
                new System.Drawing.Point(35, 285);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size =
                new System.Drawing.Size(480, 28);
            this.cmbStatus.TabIndex = 3;

            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.lblPrice.Location =
                new System.Drawing.Point(35, 330);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Text = "Price";

            // 
            // txtPrice
            // 
            this.txtPrice.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.txtPrice.Location =
                new System.Drawing.Point(35, 355);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "e.g. 1500.00";
            this.txtPrice.Size =
                new System.Drawing.Size(480, 27);
            this.txtPrice.TabIndex = 4;

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor =
                System.Drawing.Color.FromArgb(140, 140, 110);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location =
                new System.Drawing.Point(280, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size =
                new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click +=
                new System.EventHandler(this.btnCancel_Click);

            // 
            // btnSave
            // 
            this.btnSave.BackColor =
                System.Drawing.Color.FromArgb(18, 55, 42);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location =
                new System.Drawing.Point(400, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size =
                new System.Drawing.Size(115, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Room";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // 
            // Add controls
            // 
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.pnlHeader);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}