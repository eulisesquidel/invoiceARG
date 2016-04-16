using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacturaElectronica.Ui.Win.Administrador
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void solicitarCAEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAutorizador frmAutorizador = new FormAutorizador();
            //frmAutorizador.MdiParent = this;
            //frmAutorizador.Show();
            frmAutorizador.ShowDialog(this);
        }

        private void webservicesAFIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultaWebServicesAFIP frmConsultaAFIP = new FormConsultaWebServicesAFIP();
            //frmConsultaAFIP.MdiParent = this;
            //frmConsultaAFIP.Show();

            frmConsultaAFIP.ShowDialog(this);
        }

        private void solicitudesDeAutorizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCorridas frmCorridas = new FormCorridas();
            //frmCorridas.MdiParent = this;
            //frmCorridas.Show();

            frmCorridas.ShowDialog(this);
        }

        private void enviarArchivosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEnviarArchivosAWeb frmEnviarArhchivos = new FormEnviarArchivosAWeb();
            frmEnviarArhchivos.ShowDialog(this);
        }

        private void consultarEnviosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConsultaEnviosArchivosAWeb frmConsultarEnvios = new FormConsultaEnviosArchivosAWeb();
            frmConsultarEnvios.ShowDialog(this);
        }

        private void enviarUnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEnviarArchivoIndividualAWeb frmEnviarArchivo = new FormEnviarArchivoIndividualAWeb();
            frmEnviarArchivo.ShowDialog(this);
        }
    }
}
