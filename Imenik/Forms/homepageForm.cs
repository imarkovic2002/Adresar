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
    public partial class homepageForm : Form
    {
        private readonly OsobaStore osobaStore;
        public homepageForm()
        {
            InitializeComponent();
            osobaStore = new OsobaStore();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            dgListaKorisnika.DataSource = osobaStore.GetKorisnik();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dodajForm = new DodajForm(osobaStore, UpdateGrid);
            dodajForm.ShowDialog();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(dgListaKorisnika.SelectedRows.Count > 0)
            {
                var selectedKorisnik = dgListaKorisnika.SelectedRows[0].DataBoundItem as Korisnik;
                var azurirajForm = new AzurirajForm(osobaStore, selectedKorisnik, UpdateGrid);
                azurirajForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Odaberite korisnika za ažuriranje.", "Upozorenje");
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgListaKorisnika.SelectedRows.Count > 0)
            {
                var selectedKorisnik = dgListaKorisnika.SelectedRows[0].DataBoundItem as Korisnik;
                osobaStore.IzbrisiKorisnika(selectedKorisnik);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Odaberite korisnika za brisanje.", "Upozorenje");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string pretraga = txtSearch.Text.Trim();
            dgListaKorisnika.DataSource = osobaStore.Pretrazivanje(pretraga);
        }
    }
}
