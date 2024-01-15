using Imenik.DB.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imenik.Forms
{
    public partial class AzurirajForm : Form
    {
        private readonly OsobaStore osobaStore;
        private readonly Korisnik korisnik;
        private readonly Action updateGrid;
        public AzurirajForm(OsobaStore osobaStore, Korisnik korisnik, Action updateGrid)
        {
            InitializeComponent();
            this.osobaStore = osobaStore;
            this.korisnik = korisnik;
            this.updateGrid = updateGrid;
            PopuniPodatke();
        }
        private void PopuniPodatke()
        {
            txtIme.Text = korisnik.Ime;
            txtPrezime.Text = korisnik.Prezime;
            txtAdresa.Text = korisnik.Adresa;
            txtBroj.Text = korisnik.Telefonski_broj;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            korisnik.Ime = txtIme.Text.Trim();
            korisnik.Prezime = txtPrezime.Text.Trim();
            korisnik.Adresa = txtAdresa.Text.Trim();
            korisnik.Telefonski_broj = txtBroj.Text.Trim();

            osobaStore.AzurirajKorisnika(korisnik);
            updateGrid();
            Close();
        }
    }
}
