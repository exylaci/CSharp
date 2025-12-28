using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vizsgaremek_Szallashelyek
{
    public partial class ListViewForm : Form
    {
        List<Accommodation> original;


        internal ListViewForm(AccommodationList accommodations)
        {
            InitializeComponent();
            original = accommodations.ToList();
            original.Sort();
        }

        private void ListViewForm_Load(object sender, EventArgs e)
        {
            refresh(original);
        }

        private void btnFilterOn_Click(object sender, EventArgs e)
        {
            FilterForm form = new FilterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                refresh(original.Where(a => Conditions.Condition(a)).ToList());
            }
        }

        private void btnFilterOff_Click(object sender, EventArgs e)
        {
            refresh(original);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refresh(List<Accommodation> filtered)
        {
            lsv.View = View.Details;
            lsv.Items.Clear();
            if (lsv.Columns.Count == 0)
            {
                for (int i = 0; i < typeof(Accommodation).GetProperties().Count() - 1; ++i)
                {
                    lsv.Columns.Add(typeof(Accommodation).GetProperties().ElementAt(i).Name);
                }
                lsv.Columns.Add(" ");
                for (int i = 2; i < typeof(Address).GetProperties().Count(); ++i)
                {
                    lsv.Columns.Add(typeof(Address).GetProperties().ElementAt(i).Name);
                }
                lsv.Columns.Add(" ");
            }
            foreach (Accommodation accommodation in filtered)
            {
                string stars = string.Empty;
                if (accommodation is Building)
                {
                    for (int i = 0; i < ((Building)accommodation).Stars; ++i)
                    {
                        stars += "★";
                    }
                }
                string service = string.Empty;
                if (accommodation is Camping && ((Camping)accommodation).AtWaterfront)
                {
                    service = "vízparti";
                }
                if (accommodation is Guesthouse && ((Guesthouse)accommodation).HasBreakfast)
                {
                    service = "van reggeli";
                }
                if (accommodation is Hotel && ((Hotel)accommodation).HasWellness)
                {
                    service = "van wellness";
                }
                lsv.Items.Add(new ListViewItem(new string[]
                {
                    accommodation.Id,accommodation.Name,accommodation.Profile.ToString(),stars,
                    accommodation.Address.City,accommodation.Address.Street,accommodation.Address.HouseNumber,service
                }));
            }
            lsv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
