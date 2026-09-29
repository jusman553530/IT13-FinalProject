using CRM.domain;
using CRM.infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class ManageDiscountsControl : UserControl
    {
        public ManageDiscountsControl()
        {
            InitializeComponent();
            WireEvents();
            LoadDiscounts();
        }

        public void ReloadData()
        {
            LoadDiscounts();
        }

        private void WireEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnRefresh.Click += (s, e) => LoadDiscounts();
        }

        // =========================================================
        // LOAD
        // =========================================================
        private void LoadDiscounts()
        {
            try
            {
                using (var db = new HotelDbContext())
                {
                    var silver = db.Discounts.FirstOrDefault(d => d.Tier == "Silver");
                    var gold = db.Discounts.FirstOrDefault(d => d.Tier == "Gold");
                    var platinum = db.Discounts.FirstOrDefault(d => d.Tier == "Platinum");

                    if (silver != null)
                    {
                        nudSilverRate.Value = silver.Rate * 100m;
                        chkSilverActive.Checked = silver.IsActive;
                    }

                    if (gold != null)
                    {
                        nudGoldRate.Value = gold.Rate * 100m;
                        chkGoldActive.Checked = gold.IsActive;
                    }

                    if (platinum != null)
                    {
                        nudPlatinumRate.Value = platinum.Rate * 100m;
                        chkPlatinumActive.Checked = platinum.IsActive;
                    }
                }

                lblStatus.Text = "Loaded.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load discounts.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // SAVE
        // =========================================================
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                decimal silverRate = nudSilverRate.Value / 100m;
                decimal goldRate = nudGoldRate.Value / 100m;
                decimal platinumRate = nudPlatinumRate.Value / 100m;

                // Sanity check
                if (silverRate > goldRate || goldRate > platinumRate)
                {
                    var proceed = MessageBox.Show(
                        "Discount rates are usually ordered: Silver < Gold < Platinum.\n\n" +
                        "Your values are:\n" +
                        "Silver: " + (silverRate * 100m).ToString("0.##") + "%\n" +
                        "Gold: " + (goldRate * 100m).ToString("0.##") + "%\n" +
                        "Platinum: " + (platinumRate * 100m).ToString("0.##") + "%\n\n" +
                        "Save anyway?",
                        "Unusual Rates",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (proceed != DialogResult.Yes)
                        return;
                }

                using (var db = new HotelDbContext())
                {
                    UpdateOrCreate(db, "Silver", silverRate, chkSilverActive.Checked);
                    UpdateOrCreate(db, "Gold", goldRate, chkGoldActive.Checked);
                    UpdateOrCreate(db, "Platinum", platinumRate, chkPlatinumActive.Checked);

                    db.SaveChanges();
                }

                lblStatus.Text = "Discounts updated at " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to save discounts.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void UpdateOrCreate(
            HotelDbContext db, string tier, decimal rate, bool active)
        {
            var existing = db.Discounts.FirstOrDefault(d => d.Tier == tier);

            if (existing == null)
            {
                db.Discounts.Add(new Discount
                {
                    Tier = tier,
                    Rate = rate,
                    IsActive = active,
                    UpdatedAt = DateTime.Now
                });
            }
            else
            {
                existing.Rate = rate;
                existing.IsActive = active;
                existing.UpdatedAt = DateTime.Now;
            }
        }
    }
}