using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vizsgaremek_Szallashelyek.AccommodationProfileDLL;
using Vizsgaremek_Szallashelyek.ConditionsDLL;

namespace Vizsgaremek_Szallashelyek
{
    public partial class FilterForm : Form
    {
        internal AccommodationConditions Conditions { get; set; }


        internal FilterForm()
        {
            InitializeComponent();
        }


        private void FilterForm_Load(object sender, EventArgs e)
        {
            Conditions = new AccommodationConditions();
            cmbProfile.DataSource = Enum.GetValues(typeof(AccommodationProfile));
            cmbProfile.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Conditions.InId = txbId.Text;
            Conditions.InName = txbName.Text;

            if (cmbProfile.SelectedIndex >= 0)
            {
                Conditions.ByProfile = (AccommodationProfile)(cmbProfile.SelectedIndex);
            }
            else
            {
                Conditions.ByProfile = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIdOff_Click(object sender, EventArgs e)
        {
            txbId.Text = string.Empty;
        }

        private void btnNameOff_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
        }

        private void btnProfileOff_Click(object sender, EventArgs e)
        {
            cmbProfile.SelectedIndex = -1;
        }
    }
}
