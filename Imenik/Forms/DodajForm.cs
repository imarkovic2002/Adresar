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
    public partial class DodajForm : Form
    {
        private readonly OsobaStore osobaStore;
        private readonly Action updateGrid;
        public DodajForm(OsobaStore osobaStore, Action updateGrid)
        {
            InitializeComponent();
            this.osobaStore = osobaStore;
            this.updateGrid = updateGrid;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var korisnik = new Korisnik
            {
                Ime = txtIme.Text.Trim(),
                Prezime = txtPrezime.Text.Trim(),
                Adresa = txtAdresa.Text.Trim(),
                Telefonski_broj = txtBroj.Text.Trim()
            };
            osobaStore.DodajKorisnika(korisnik);
            updateGrid();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
