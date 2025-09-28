using KonyvesboltKomponens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonyvesboltWinForms
{
    public partial class Form1 : BaseForm
    {
        Konyvesbolt bolt;
        ToolStripLabel status;

        public Form1()
        {
            InitializeComponent();
            ToolStripButton moly = new ToolStripButton("Uj Moly");
            moly.Click += Moly_Click;
            menuStrip1.Items.Add(moly);
            status = new ToolStripLabel();
            statusStrip1.Items.Add(status);
            bolt = new Konyvesbolt();
            bolt.UjKonyvErkezettABoltba += Bolt_UjKonyvErkezettABoltba;
        }

        private void Bolt_UjKonyvErkezettABoltba(Konyv uj)
        {
            status.Text = $"A boltba új könyv érkezett: {uj}";
        }

        private void Moly_Click(object sender, EventArgs e)
        {
            MolyForm dialogus = new MolyForm();
            if (dialogus.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(dialogus.Moly);
                bolt.UjKonyvErkezettABoltba += dialogus.Moly.KonyErkezettABoltba;
                dialogus.Moly.KonyvetVettem += Moly_KonyvetVettem;
            }
        }

        private void Moly_KonyvetVettem(Konyv mit, Konyvmoly moly)
        {
            listBox2.Items.Add($"{moly} megvette a(z) {mit} és a vagyona: {moly.Vagyon} lett.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] vezetek = { "gipsz", "Teszt", "Trab" };
            string[] kereszt = { "Jakab", "Elek", "Antal" };
            string[] cimek = { "Harry", "Potter", "Legyek", "Ura", "Péntek", "13" };
            Random r = new Random();
            bolt.UjKonyv(new Konyv(
                vezetek[r.Next(0, vezetek.Length)] + " " + kereszt[r.Next(0, kereszt.Length)],
                cimek[r.Next(0, cimek.Length)] + " " + cimek[r.Next(0, cimek.Length)],
                r.Next(2, 20),
                (KonyvTipusok)r.Next(0, Enum.GetValues(typeof(KonyvTipusok)).Length),
                r.Next(1, 4)
                ));
        }
    }
}
