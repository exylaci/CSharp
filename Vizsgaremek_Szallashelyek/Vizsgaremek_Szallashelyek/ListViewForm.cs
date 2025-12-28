using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vizsgaremek_Szallashelyek.ConditionsDLL;


namespace Vizsgaremek_Szallashelyek
{
    public partial class ListViewForm : Form
    {
        private List<Accommodation> original;


        internal ListViewForm(AccommodationList accommodations)
        {
            InitializeComponent();
            original = accommodations.ToList();
            original.Sort();
        }

        private void ListViewForm_Load(object sender, EventArgs e)
        {
            Refresh(original);
        }

        private void btnFilterOn_Click(object sender, EventArgs e)
        {
            FilterForm form = new FilterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                AccommodationConditions conditions = form.Conditions;
                Refresh(original.FindAll(conditions.Condition()));
            }
        }

        private void btnFilterOff_Click(object sender, EventArgs e)
        {
            Refresh(original);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Refresh(List<Accommodation> filtered)
        {
            lsv.View = View.Details;
            lsv.Items.Clear();
            if (lsv.Columns.Count == 0)
            {
                for (int i = 0; i < typeof(Accommodation).GetProperties().Count() - 1; ++i)
                {
                    lsv.Columns.Add(typeof(Accommodation).GetProperties().ElementAt(i).Name);
                }
                lsv.Columns.Add("Minősítés");
                for (int i = 2; i < typeof(Address).GetProperties().Count(); ++i)
                {
                    lsv.Columns.Add(typeof(Address).GetProperties().ElementAt(i).Name);
                }
                lsv.Columns.Add("Aktuális ár",100,HorizontalAlignment.Right);
                lsv.Columns.Add("Extrák");
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
                    accommodation.Address.City,accommodation.Address.Street,accommodation.Address.HouseNumber,
                    accommodation.GetPrice().ToString(),service
                }));
            }
            lsv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
