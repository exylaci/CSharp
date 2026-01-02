using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vizsgaremek_Szallashelyek
{
    internal partial class MainForm : Form
    {
        private AccommodationList accommodations;


        internal MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                accommodations = Repositories.LoadAllAccommodations();
                accommodations.AccommodationListChanged += TitleUpdate;
                RefreshList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nem sikerült kapcsolódni és beolvasni az adatbázist!{Environment.NewLine}A program leáll.{Environment.NewLine}{Environment.NewLine}Hibaüzenet: {ex.Message}", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            timer.Enabled = true;
        }

        private void RefreshList(bool keepSelection = false)
        {
            int selected = lsb.SelectedIndex;
            lsb.Items.Clear();
            accommodations.ForEach(a => lsb.Items.Add(a));
            if (keepSelection)
            {
                lsb.SelectedIndex = selected;
            }
        }

        private void TitleUpdate(Accommodation accommodation, string direction)
        {
            this.Text = $"{accommodation?.Name} {(accommodation is Hotel ? "szálloda" : accommodation is Guesthouse ? "panzió" : "kemping")} {direction}.";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AccommodationForm form = new AccommodationForm(null, accommodations);
            if (form.ShowDialog() == DialogResult.OK)
            {
                accommodations.Add(form.accommodation);
                RefreshList();
                lsb.SelectedIndex = lsb.Items.Count - 1;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedIndex >= 0)
            {
                Accommodation accommodation = accommodations[lsb.SelectedIndex];
                AccommodationForm form = new AccommodationForm(accommodation, accommodations);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshList(true);
                }
            }
            else
            {
                MessageBox.Show("Nincs kijelölve szálláshely!", "Szálláshely módosítás", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedIndex >= 0)
            {
                Accommodation accommodation = accommodations[lsb.SelectedIndex];
                if (MessageBox.Show($"Biztos töröljük a(z) {accommodation.Name} szálláshelyet?", "Szálláshely törlés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        Repositories.DeleteAccommodation(accommodation);
                        accommodations.RemoveById(accommodation.Id);
                        RefreshList();
                    }
                    catch (DBExceptions ex)
                    {
                        MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                    }
                    catch (Exception ex)
                    {
                        Log.Append(ex);
                        MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = DialogResult.None;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincs kijelölve szálláshely!", "Szálláshely törlése", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (accommodations != null && MessageBox.Show("Biztosan ki akar lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void lsb_DoubleClick(object sender, EventArgs e)
        {
            if (lsb.SelectedIndex >= 0 && accommodations[lsb.SelectedIndex] is Building)
            {
                new AccommodationForm(accommodations[lsb.SelectedIndex], accommodations, true).Show();
            }
        }

        private void btnSorted_Click(object sender, EventArgs e)
        {
            new ListViewForm(accommodations).Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                accommodations = Repositories.LoadAllAccommodations();
                RefreshList(true);
            }
            catch (Exception ex)
            {
                MessageToStatusBar($"{DateTime.Now}-kor nem sikerült frissíteni az adatokat az adatbázisból: {ex.Message}");
            }
        }

        private void MessageToStatusBar(string message)
        {
            StringBuilder truncatedMessage = new StringBuilder();
            truncatedMessage.Append(message.ToString());
            int width = this.Width - 20;
            Graphics g = stl.Owner.CreateGraphics();
            while (g.MeasureString(truncatedMessage.ToString(), stl.Font).Width > width && truncatedMessage.Length > 5)
            {
                truncatedMessage.Length -= 5;
                truncatedMessage.Append(" ...");
            }
            stl.Text = truncatedMessage.ToString();
        }
    }
}
