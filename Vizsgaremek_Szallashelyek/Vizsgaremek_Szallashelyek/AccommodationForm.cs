using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;

namespace Vizsgaremek_Szallashelyek
{
    public enum AccommodationType
    {
        [Description("Szálloda")] Hotel,
        [Description("Panzió")] Guesthouse,
        [Description("Kemping")] Camping
    }

    public partial class AccommodationForm : Form
    {
        internal Accommodation accommodation;
        private byte stars;
        private AccommodationList accommodations;


        internal AccommodationForm()
        {
            InitializeComponent();
            cmbProfile.DataSource = Enum
                .GetValues(typeof(AccommodationProfile))
                .Cast<AccommodationProfile>()
                .Select(ap => new { Value = ap, Text = Accommodation.GetDescription(ap) })
                .ToList();
            cmbProfile.DisplayMember = "Text";
            cmbProfile.ValueMember = "Value";
            cmbType.DataSource = Enum
                .GetValues(typeof(AccommodationType))
                .Cast<AccommodationType>()
                .Select(at => new { Value = at, Text = Accommodation.GetDescription(at) })
                .ToList();
            cmbType.DisplayMember = "Text";
            cmbType.ValueMember = "Value";
            for (int i = 0; i < 5; i++)
            {
                Label star = new Label();
                star.Name = "star";
                star.Text = "☆";
                star.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Regular);
                star.ForeColor = Color.Gold;
                star.AutoSize = true;
                star.Top = 13;
                star.Left = 10 + i * 45;
                star.MouseClick += Stars_ClickOn;
                grbStars.Controls.Add(star);
            }
        }

        internal AccommodationForm(Accommodation accommodation, AccommodationList accommodations, bool onlyRead = false) : this()
        {
            this.accommodation = accommodation;
            this.accommodations = accommodations;
            if (accommodation == null)
            {
                this.Text = "Új szálláshely felvitele";
                btnRenovation.Visible = false;
                btnRenovation.Enabled = false;
                txbID.Focus();
            }
            else
            {
                this.Text = "Szálláshely módosítása";
                txbID.ReadOnly = true;
                txbID.Text = accommodation.Id;
                txbName.Text = accommodation.Name;
                numZipCode.Value = accommodation.Address.ZipCode;
                txbCity.Text = accommodation.Address.City;
                txbStreet.Text = accommodation.Address.Street;
                txbHouseNumber.Text = accommodation.Address.HouseNumber;
                cmbProfile.SelectedIndex = (int)accommodation.Profile;
                if (accommodation is Hotel hotel)
                {
                    cmbType.SelectedIndex = 0;
                    chbSpeciality.Checked = hotel.HasWellness;
                    chbSpeciality.Enabled = false;
                    numBasePrice.Value = (decimal)hotel.BasePrice;
                    stars = ((Building)accommodation).Stars;
                }
                else if (accommodation is Guesthouse guesthouse)
                {
                    cmbType.SelectedIndex = 1;
                    chbSpeciality.Checked = guesthouse.HasBreakfast;
                    numBasePrice.Value = (decimal)guesthouse.BasePrice;
                    stars = ((Building)accommodation).Stars;
                }
                else if (accommodation is Camping)
                {
                    cmbType.SelectedIndex = 2;
                    chbSpeciality.Checked = ((Camping)accommodation).AtWaterfront;
                    chbSpeciality.Enabled = false;
                    btnRenovation.Visible = false;
                }
                UpdateStarsPaint(stars);
                CalculateFinalPrice();
                cmbType.Enabled = false;
                grbStars.Enabled = false;
                if (onlyRead)
                {
                    this.Text = "Szálláshely adatai";
                    txbID.Enabled = false;
                    txbName.Enabled = false;
                    numZipCode.Enabled = false;
                    txbCity.Enabled = false;
                    txbStreet.Enabled = false;
                    txbHouseNumber.Enabled = false;
                    cmbProfile.Enabled = false;
                    chbSpeciality.Enabled = false;
                    numBasePrice.Enabled = false;
                    txbFinalPrice.Enabled = false;
                    btnRenovation.Visible = false;
                    btnOK.Visible = false;
                    btnCancel.Text = "Vissza";
                    btnCancel.Focus();
                }
            }
        }


        private void Stars_ClickOn(object sender, EventArgs e)
        {
            if (sender is Label star && star.Name.Equals("star"))
            {
                stars = (byte)((star.Left - 10) / 45 + 1);
                CalculateFinalPrice();
                UpdateStarsPaint(stars);
            }
        }

        private void UpdateStarsPaint(int stars)
        {
            foreach (Label label in grbStars.Controls)
            {
                label.Text = stars-- > 0 ? "★" : "☆";
            }
        }

        private void numBasePrice_ValueChanged(object sender, EventArgs e)
        {
            CalculateFinalPrice();
        }

        private void CalculateFinalPrice()
        {
            if (cmbType.SelectedIndex == 2)
            {
                txbFinalPrice.Text = new Camping(null, AccommodationProfile.Other, new Address(1000, "a", "a", null), chbSpeciality.Checked).GetPrice().ToString();
            }
            else if (stars > 0)
            {
                switch (cmbType.SelectedIndex)
                {
                    case 0:
                        txbFinalPrice.Text = new Hotel(null, AccommodationProfile.Other, new Address(1000, "a", "a", null), (int)numBasePrice.Value, stars, chbSpeciality.Checked).GetPrice().ToString();
                        break;
                    case 1:
                        txbFinalPrice.Text = new Guesthouse(null, AccommodationProfile.Other, new Address(1000, "a", "a", null), (int)numBasePrice.Value, stars, chbSpeciality.Checked).GetPrice().ToString();
                        break;
                }
            }
            else
            {
                txbFinalPrice.Text = numBasePrice.Value.ToString();
            }
        }

        private void SetTypePendingVisibilities()
        {
            if (cmbType.SelectedIndex == 2)
            {
                chbSpeciality.Text = "Vízparti";
                lblBasePrice.Visible = false;
                numBasePrice.Visible = false;
                grbStars.Visible = false;
            }
            else
            {
                chbSpeciality.Text = cmbType.SelectedIndex == 1 ? "Van reggeli" : "Van wellness lehetőség";
                lblBasePrice.Visible = true;
                numBasePrice.Visible = true;
                grbStars.Visible = true;
            }
            CalculateFinalPrice();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTypePendingVisibilities();
        }

        private void btnRenovation_Click(object sender, EventArgs e)
        {
            if (accommodation != null && (accommodation is Hotel || accommodation is Guesthouse))
            {
                MessageBox.Show("Állítsd be a felújítás utáni állapotot!", "Befejeződött a felújítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grbStars.Enabled = true;
                chbSpeciality.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (accommodation == null)
                {
                    switch (cmbType.SelectedIndex)
                    {
                        case 0:
                            accommodation = new Hotel(txbID.Text, txbName.Text, (AccommodationProfile)cmbProfile.SelectedIndex, new Address((short)numZipCode.Value, txbCity.Text, txbStreet.Text, txbHouseNumber.Text), (float)numBasePrice.Value, stars, chbSpeciality.Checked);
                            break;
                        case 1:
                            accommodation = new Guesthouse(txbID.Text, txbName.Text, (AccommodationProfile)cmbProfile.SelectedIndex, new Address((short)numZipCode.Value, txbCity.Text, txbStreet.Text, txbHouseNumber.Text), (float)numBasePrice.Value, stars, chbSpeciality.Checked);
                            break;
                        case 2:
                            accommodation = new Camping(txbID.Text, txbName.Text, (AccommodationProfile)cmbProfile.SelectedIndex, new Address((short)numZipCode.Value, txbCity.Text, txbStreet.Text, txbHouseNumber.Text), chbSpeciality.Checked);
                            break;
                    }
                    Repositories.InsertAccommodation(accommodation);
                }
                else
                {
                    accommodation.Name = txbName.Text;
                    accommodation.Address.ZipCode = (short)numZipCode.Value;
                    accommodation.Address.City = txbCity.Text;
                    accommodation.Address.Street = txbStreet.Text;
                    accommodation.Address.HouseNumber = txbHouseNumber.Text;
                    accommodation.Profile = (AccommodationProfile)cmbProfile.SelectedIndex;
                    if (accommodation is Guesthouse guesthouse)
                    {
                        guesthouse.HasBreakfast = chbSpeciality.Checked;
                        guesthouse.BasePrice = (double)numBasePrice.Value;
                        if (grbStars.Enabled)
                        {
                            ((Building)accommodation).Renovate(stars);
                        }
                    }
                    else if (accommodation is Hotel hotel)
                    {
                        hotel.BasePrice = (double)numBasePrice.Value;
                        if (grbStars.Enabled)
                        {
                            hotel.Renovate(stars, chbSpeciality.Checked);
                        }
                    }
                    Repositories.UpdateAccommodation(accommodation);
                }
            }
            catch (DBExceptions ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                Log.Append(ex);
            }
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            if (!txbID.Enabled)
            {
                return;
            }
            if (accommodations.Any(a => a?.Id == txbID.Text))
            {
                txbID.ForeColor = Color.Red;
                txbID.Focus();
            }
            else
            {
                txbID.ForeColor = SystemColors.ControlText;
            }
        }

        private void chbSpeciality_CheckedChanged(object sender, EventArgs e)
        {
            CalculateFinalPrice();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
