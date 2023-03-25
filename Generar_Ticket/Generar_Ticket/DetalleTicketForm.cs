using Datos;
using Entidades;
using System;
using System.Windows.Forms;

namespace Generar_Ticket
{
    public partial class DetalleTicketForm : Form
    {
        public DetalleTicketForm()
        {
            InitializeComponent();
        }

        DetalleTicketDB detalleTicketDB = new DetalleTicketDB();
        public DetalleTicket detalleTicket = new DetalleTicket();

        private void DetalleTicketForm_Load(object sender, EventArgs e)
        {

            DetalleDataGridView.DataSource = detalleTicketDB.DevolverDetalleTicketDB();
        }
    }
}
