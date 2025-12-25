using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        private AccommodationList accommodations;


        public MainForm()
        {
            InitializeComponent();
            accommodations = new AccommodationList();
            accommodations.AccommodationListChanged += TitleUpdate;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            accommodations = Repositories.LoadAllAccommodations();
            lsb.Items.Clear();
            foreach (Accommodation accommodation in accommodations)
            {
                lsb.Items.Add(accommodation);
            }
        }

        private void TitleUpdate(Accommodation accommodation, string direction)
        {
            this.Text = $"* {direction}: {accommodation?.Name}";
        }
    }
}
