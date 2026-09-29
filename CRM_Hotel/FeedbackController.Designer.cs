#nullable enable

using CRM.winforms.UI;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CRM.winforms
{
    partial class FeedbackControl
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlHeader = null!;
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;

        // Left form
        private RoundedPanel pnlForm = null!;
        private Label lblFormHeading = null!;

        private Label lblCustomer = null!;
        private ComboBox cmbCustomer = null!;

        private Label lblRating = null!;
        private Label star1 = null!;
        private Label star2 = null!;
        private Label star3 = null!;
        private Label star4 = null!;
        private Label star5 = null!;

        private Label lblComments = null!;
        private TextBox txtComments = null!;

        private RoundedButton btnSubmit = null!;

        // Right list
        private RoundedPanel pnlList = null!;
        private Label lblListHeading = null!;
        private Label lblFeedbackCount = null!;
        private DataGridView dgvFeedback = null!;

        private RoundedButton btnDelete = null!;
        private RoundedButton btnRefresh = null!;

        private Label lblStatus = null!;

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
            components = new System.ComponentModel.Container();

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            pnlForm = new RoundedPanel();
            lblFormHeading = new Label();
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblRating = new Label();
            star1 = new Label();
            star2 = new Label();
            star3 = new Label();
            star4 = new Label();
            star5 = new Label();
            lblComments = new Label();
            txtComments = new TextBox();
            btnSubmit = new RoundedButton();

            pnlList = new RoundedPanel();
            lblListHeading = new Label();
            lblFeedbackCount = new Label();
            dgvFeedback = new DataGridView();

            btnDelete = new RoundedButton();
            btnRefresh = new RoundedButton();
            lblStatus = new Label();

            pnlHeader.SuspendLayout();
            pnlForm.SuspendLayout();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();

            SuspendLayout();

            // =====================================================
            // HEADER
            // =====================================================

            pnlHeader.BackColor = Theme.Primary;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(970, 110);
            pnlHeader.TabIndex = 0;

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Feedback";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubtitle.ForeColor = Theme.Tint;
            lblSubtitle.Location = new Point(39, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Collect and review guest feedback";

            // =====================================================
            // FORM PANEL
            // =====================================================

            pnlForm.BackColor = Theme.Card;
            pnlForm.BorderColor = Theme.Border;
            pnlForm.BorderThickness = 1;
            pnlForm.CornerRadius = 14;
            pnlForm.Location = new Point(35, 135);
            pnlForm.Name = "pnlForm";
            pnlForm.Size = new Size(420, 560);
            pnlForm.TabIndex = 1;

            pnlForm.Controls.Add(lblFormHeading);
            pnlForm.Controls.Add(lblCustomer);
            pnlForm.Controls.Add(cmbCustomer);
            pnlForm.Controls.Add(lblRating);
            pnlForm.Controls.Add(star1);
            pnlForm.Controls.Add(star2);
            pnlForm.Controls.Add(star3);
            pnlForm.Controls.Add(star4);
            pnlForm.Controls.Add(star5);
            pnlForm.Controls.Add(lblComments);
            pnlForm.Controls.Add(txtComments);
            pnlForm.Controls.Add(btnSubmit);

            lblFormHeading.AutoSize = true;
            lblFormHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFormHeading.ForeColor = Theme.TextDark;
            lblFormHeading.Location = new Point(25, 20);
            lblFormHeading.Name = "lblFormHeading";
            lblFormHeading.Size = new Size(180, 23);
            lblFormHeading.TabIndex = 0;
            lblFormHeading.Text = "New Feedback";

            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomer.ForeColor = Theme.TextDark;
            lblCustomer.Location = new Point(25, 70);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(62, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer";

            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(25, 90);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(370, 25);
            cmbCustomer.TabIndex = 2;

            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRating.ForeColor = Theme.TextDark;
            lblRating.Location = new Point(25, 140);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(100, 15);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating";

            ConfigureStar(star1, 25);
            ConfigureStar(star2, 70);
            ConfigureStar(star3, 115);
            ConfigureStar(star4, 160);
            ConfigureStar(star5, 205);

            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComments.ForeColor = Theme.TextDark;
            lblComments.Location = new Point(25, 215);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(65, 15);
            lblComments.TabIndex = 9;
            lblComments.Text = "Comments";

            txtComments.Font = new Font("Segoe UI", 9.5F);
            txtComments.Location = new Point(25, 235);
            txtComments.Multiline = true;
            txtComments.ScrollBars = ScrollBars.Vertical;
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(370, 220);
            txtComments.TabIndex = 10;

            btnSubmit.NormalColor = Theme.Accent;
            btnSubmit.HoverColor = Color.FromArgb(210, 90, 30);
            btnSubmit.CornerRadius = 10;
            btnSubmit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(25, 475);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(370, 55);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Submit Feedback";
            btnSubmit.UseVisualStyleBackColor = false;

            // =====================================================
            // LIST PANEL
            // =====================================================

            pnlList.BackColor = Theme.Card;
            pnlList.BorderColor = Theme.Border;
            pnlList.BorderThickness = 1;
            pnlList.CornerRadius = 14;
            pnlList.Location = new Point(475, 135);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(460, 560);
            pnlList.TabIndex = 2;

            pnlList.Controls.Add(lblListHeading);
            pnlList.Controls.Add(lblFeedbackCount);
            pnlList.Controls.Add(dgvFeedback);

            lblListHeading.AutoSize = true;
            lblListHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblListHeading.ForeColor = Theme.TextDark;
            lblListHeading.Location = new Point(25, 20);
            lblListHeading.Name = "lblListHeading";
            lblListHeading.Size = new Size(200, 23);
            lblListHeading.TabIndex = 0;
            lblListHeading.Text = "All Feedback";

            lblFeedbackCount.AutoSize = true;
            lblFeedbackCount.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblFeedbackCount.ForeColor = Color.Gray;
            lblFeedbackCount.Location = new Point(25, 50);
            lblFeedbackCount.Name = "lblFeedbackCount";
            lblFeedbackCount.Size = new Size(70, 15);
            lblFeedbackCount.TabIndex = 1;
            lblFeedbackCount.Text = "0 record(s)";

            dgvFeedback.AllowUserToAddRows = false;
            dgvFeedback.AllowUserToDeleteRows = false;
            dgvFeedback.AllowUserToResizeRows = false;
            dgvFeedback.BackgroundColor = Theme.Card;
            dgvFeedback.BorderStyle = BorderStyle.None;
            dgvFeedback.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFeedback.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvFeedback.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvFeedback.ColumnHeadersHeight = 44;
            dgvFeedback.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFeedback.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };
            dgvFeedback.EnableHeadersVisualStyles = false;
            dgvFeedback.GridColor = Theme.Border;
            dgvFeedback.Location = new Point(20, 80);
            dgvFeedback.Margin = new Padding(0);
            dgvFeedback.MultiSelect = false;
            dgvFeedback.Name = "dgvFeedback";
            dgvFeedback.ReadOnly = true;
            dgvFeedback.RowHeadersVisible = false;
            dgvFeedback.RowTemplate.Height = 40;
            dgvFeedback.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedback.Size = new Size(420, 460);
            dgvFeedback.TabIndex = 2;
            dgvFeedback.Anchor =
                AnchorStyles.Top | AnchorStyles.Bottom |
                AnchorStyles.Left | AnchorStyles.Right;

            // =====================================================
            // BOTTOM BUTTONS
            // =====================================================

            btnDelete.NormalColor = Theme.Danger;
            btnDelete.HoverColor = Color.FromArgb(160, 40, 40);
            btnDelete.CornerRadius = 10;
            btnDelete.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(35, 710);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 44);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;

            btnRefresh.NormalColor = Theme.Field;
            btnRefresh.HoverColor = Theme.Tint;
            btnRefresh.CornerRadius = 10;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Theme.TextDark;
            btnRefresh.Location = new Point(175, 710);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 44);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;

            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblStatus.ForeColor = Theme.TextDark;
            lblStatus.Location = new Point(310, 718);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(625, 25);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;

            // =====================================================
            // USER CONTROL
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Theme.Background;
            AutoScroll = true;
            Name = "FeedbackControl";
            Size = new Size(970, 780);

            Controls.Add(pnlHeader);
            Controls.Add(pnlForm);
            Controls.Add(pnlList);
            Controls.Add(btnDelete);
            Controls.Add(btnRefresh);
            Controls.Add(lblStatus);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();

            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureStar(Label star, int x)
        {
            star.AutoSize = true;
            star.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Regular);
            star.ForeColor = Color.Gray;
            star.Location = new Point(x, 155);
            star.Name = "star" + ((x / 45) + 1);
            star.Size = new Size(30, 40);
            star.TabIndex = 0;
            star.Text = "☆";
            star.Cursor = Cursors.Hand;
        }
    }
}