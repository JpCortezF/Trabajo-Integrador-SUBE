﻿using Biblioteca_TarjetaSube;
using Biblioteca_Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sube
{
    public partial class InicioPasajero : Form
    {
        List<Pasajero> listPassengers;
        Pasajero passenger;
        private Form currentChildForm = null;


        public InicioPasajero(Pasajero passenger, List<Pasajero> listPassengers)
        { 
            InitializeComponent();
            this.passenger = passenger;
            this.listPassengers = listPassengers;
        }

        private void InicioPasajero_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem itemSalir = new ToolStripMenuItem("| SALIR |");
            menuStrip1.Items.Add(itemSalir);
            itemSalir.Alignment = ToolStripItemAlignment.Right;
            itemSalir.BackColor = SystemColors.ActiveCaption;
            itemSalir.ForeColor = SystemColors.ControlText;
            itemSalir.Click += itemSalir_Click;
            lblNombre.Text = $"¡Hola {passenger.Name + " " + passenger.LastName}!";
        }
        private GraphicsPath CrearRegionConEsquinasRedondeadas(int width, int height, int radio)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radio * 2, radio * 2, 180, 90); // Esquina superior izquierda
            path.AddArc(width - (radio * 2), 0, radio * 2, radio * 2, 270, 90); // Esquina superior derecha
            path.AddArc(width - (radio * 2), height - (radio * 2), radio * 2, radio * 2, 0, 90); // Esquina inferior derecha
            path.AddArc(0, height - (radio * 2), radio * 2, radio * 2, 90, 90); // Esquina inferior izquierda
            path.CloseFigure();

            return path;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radio = 15; // Ajusta el radio según tus preferencias

            this.Region = new Region(CrearRegionConEsquinasRedondeadas(this.Width, this.Height, radio));
        }
        private void itemSalir_Click(object sender, EventArgs e)
        {
            FormEmergente emergente = new FormEmergente("¿Está seguro que desea salir?", "Salir");
            emergente.ShowDialog();
            if (emergente.DialogResult == DialogResult.OK)
            {
                string ruta = @"..\..\..\Data";
                string nombre = "MisPasajeros.Json";
                string path = Path.Combine(ruta, nombre);

                Serializador.WriteJsonPassenger(path, listPassengers);
                //SerializadorJSON<List<Pasajero>> serializadorPasajero = new SerializadorJSON<List<Pasajero>>();
                //serializadorPasajero.Serialize(path, listPassengers);

                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
                Close();
            }
        }
        private void vIAJARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is TomarTransporte))
            {
                TomarTransporte transporte = new TomarTransporte(passenger);
                OpenChildForm(transporte);
            }
        }
        private void subeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is FormSubePasajero))
            {
                FormSubePasajero miSube = new FormSubePasajero(passenger, listPassengers);
                OpenChildForm(miSube);
            }
        }
        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is FormViajes))
            {
                FormViajes viajes = new FormViajes(this, passenger, passenger.MySube.QueueTravels);
                OpenChildForm(viajes);
            }
        }

        private void tarifaSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is FormTarifaSocial))
            {
                FormTarifaSocial tarifaSocial = new FormTarifaSocial(passenger);
                OpenChildForm(tarifaSocial);
            }
        }
        /// <summary>
        /// Abre un formulario hijo en el formulario principal, asegurándose de que solo un formulario hijo esté abierto a la vez.
        /// </summary>
        /// <param name="childForm">El formulario hijo que se abrirá.</param>
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.MdiParent = this;
            childForm.Location = new Point(0, 0);
            childForm.FormClosed += (s, args) =>
            {
                currentChildForm = null;
            };
            lblNombre.Visible = false;
            pictureBox1.Visible = false;
            childForm.Show();
        }
        /// <summary>
        /// Maneja el evento de hacer clic en el elemento de menú "Buscador". Abre el formulario de búsqueda de usuarios como un formulario hijo en el formulario principal, asegurándose de que solo un formulario hijo esté abierto a la vez.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento (en este caso, el elemento de menú "Buscador").</param>
        /// <param name="e">Argumentos del evento.</param>

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
                lblNombre.Visible = false;
            }
        }

        private void darDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is FormDarDeBaja))
            {
                FormDarDeBaja DeBaja = new FormDarDeBaja(passenger, listPassengers);
                OpenChildForm(DeBaja);
            }
        }

        private void mISTRÁMITESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChildForm is null || !(currentChildForm is FormPasajeroTramites))
            {
                FormPasajeroTramites Tramites = new FormPasajeroTramites(passenger, listPassengers);
                OpenChildForm(Tramites);
            }
        }
        public void ItemsMdiParentVisibles()
        {
            lblNombre.Visible = true;
            pictureBox1.Visible = true;
        }
    }
}
