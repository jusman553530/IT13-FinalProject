#nullable enable

using System;
using System.Drawing;
using System.Windows.Forms;
using CRM.winforms.UI;

namespace CRM.winforms
{
    partial class GuestHistoryForm
    {
        private System.ComponentModel.IContainer? components = null;

        private Label lblHeading = null!;
        private Label lblSubheading = null!;

        private Panel pnlTabs = null!;
        private RoundedButton btnTabReservations = null!;
        private RoundedButton btnTabInquiries = null!;
        private RoundedButton btnTabFeedback = null!;

        private Panel pnlTabsHost = null!;
        private DataGridView dgvReservations = null!;
        private DataGridView dgvInquiries = null!;
        private DataGridView dgvFeedback = null!;

        private RoundedButton btnClose = null!;

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

            lblHeading = new Label();
            lblSubheading = new Label();

            pnlTabs = new Panel();
            btnTabReservations = new RoundedButton();
            btnTabInquiries = new RoundedButton();
            btnTabFeedback = new RoundedButton();

            pnlTabsHost = new Panel();
            dgvReservations = new DataGridView();
            dgvInquiries = new DataGridView();
            dgvFeedback = new DataGridView();

            btnClose = new RoundedButton();

            pnlTabs.SuspendLayout();
            pnlTabsHost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInquiries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).BeginInit();

            SuspendLayout();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 640);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GuestHistoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Guest History";

            // Heading
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(30, 30, 30);
            lblHeading.Location = new Point(30, 20);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(200, 32);
            lblHeading.TabIndex = 0;
            lblHeading.Text = "Guest History";

            lblSubheading.AutoSize = true;
            lblSubheading.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblSubheading.ForeColor = Color.Gray;
            lblSubheading.Location = new Point(33, 58);
            lblSubheading.Name = "lblSubheading";
            lblSubheading.Size = new Size(300, 19);
            lblSubheading.TabIndex = 1;
            lblSubheading.Text = "";

            // Tabs
            pnlTabs.Location = new Point(30, 90);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(840, 44);
            pnlTabs.TabIndex = 2;

            ConfigureTab(btnTabReservations, "Reservations", 0);
            ConfigureTab(btnTabInquiries, "Inquiries", 180);
            ConfigureTab(btnTabFeedback, "Feedback", 360);

            pnlTabs.Controls.Add(btnTabReservations);
            pnlTabs.Controls.Add(btnTabInquiries);
            pnlTabs.Controls.Add(btnTabFeedback);

            // Tab host
            pnlTabsHost.BackColor = Theme.Background;
            pnlTabsHost.Location = new Point(30, 145);
            pnlTabsHost.Name = "pnlTabsHost";
            pnlTabsHost.Size = new Size(840, 430);
            pnlTabsHost.TabIndex = 3;

            ConfigureGrid(dgvReservations);
            ConfigureGrid(dgvInquiries);
            ConfigureGrid(dgvFeedback);

            pnlTabsHost.Controls.Add(dgvReservations);
            pnlTabsHost.Controls.Add(dgvInquiries);
            pnlTabsHost.Controls.Add(dgvFeedback);

            // Close
            btnClose.NormalColor = Theme.Primary;
            btnClose.HoverColor = Theme.PrimaryHover;
            btnClose.CornerRadius = 10;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(730, 585);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 40);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;

            Controls.Add(lblHeading);
            Controls.Add(lblSubheading);
            Controls.Add(pnlTabs);
            Controls.Add(pnlTabsHost);
            Controls.Add(btnClose);

            pnlTabs.ResumeLayout(false);
            pnlTabsHost.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInquiries).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFeedback).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureTab(RoundedButton tab, string text, int x)
        {
            tab.NormalColor = Theme.Field;
            tab.HoverColor = Theme.Tint;
            tab.CornerRadius = 10;
            tab.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tab.ForeColor = Theme.TextDark;
            tab.Location = new Point(x, 0);
            tab.Name = "btnTab" + text;
            tab.Size = new Size(170, 40);
            tab.TabIndex = 0;
            tab.Text = text;
            tab.UseVisualStyleBackColor = false;
        }

        private void ConfigureGrid(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = Theme.Card;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Primary,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Theme.Primary,
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 8, 0)
            };

            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Card,
                ForeColor = Theme.TextDark,
                SelectionBackColor = Theme.Tint,
                SelectionForeColor = Theme.Primary,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Padding = new Padding(8, 0, 8, 0)
            };

            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Theme.Border;
            grid.Location = new Point(0, 0);
            grid.Margin = new Padding(0);
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 36;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(840, 430);
            grid.Dock = DockStyle.Fill;
            grid.Visible = false;
        }
    }
}