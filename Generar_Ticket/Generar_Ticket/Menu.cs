using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generar_Ticket
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            UsuariosForm userForm = new UsuariosForm();
            userForm.MdiParent = this;
            userForm.Show();
        }

        private void SoporteToolStripButton_Click(object sender, EventArgs e)
        {
            ClienteForm soporteForm = new ClienteForm();
            soporteForm.MdiParent = this;
            soporteForm.Show();
        }

        private void TickectToolStripButton_Click(object sender, EventArgs e)
        {
            TicketForm ticketForm = new TicketForm();
            ticketForm.MdiParent = this;
            ticketForm.Show();
        }
    }
}
