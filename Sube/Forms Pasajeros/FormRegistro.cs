﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca_Usuarios;
using Biblioteca_TarjetaSube;
using Biblioteca_DataBase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using NPOI.SS.Formula.Functions;

namespace Sube
{
    public partial class FormRegistro : Form
    {
        private string gender = "";
        private int idGender;
        List<Pasajero> listPassengers;
        string userCardNumber = "";


        public FormRegistro(List<Pasajero> listPassengers)
        {
            InitializeComponent();
            this.listPassengers = listPassengers;
        }
        private void FormRegistro_Load_1(object sender, EventArgs e)
        {
            grpDatos.Parent = panelDatos;
            lblTarjeta.Text = "El número de tarjeta debe tener 16 dígitos.";
            lblDni.Text = "El número de documento debe tener 8 dígitos";
            lblCorreo.Text = "Por favor, ingresá tu correo electrónico.";
            lblClave.Text = "Las claves no coinciden";
            txtTarjeta2.KeyPress += txtTarjeta_KeyPress;
            txtTarjeta3.KeyPress += txtTarjeta_KeyPress;
            txtTarjeta4.KeyPress += txtTarjeta_KeyPress;
            btnMasculino.Click += ButtonGender_Click;
            btnFemenino.Click += ButtonGender_Click;
            btnX.Click += ButtonGender_Click;
        }
        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la tecla presionada si no es un número entero
            }
        }
        private void btnContinuar_Click_1(object sender, EventArgs e)
        {
            string ruta = @"..\..\..\Data";
            string nombre = @".\MisPasajeros.Json";
            string path = ruta + nombre;
            try
            {
                string email = txtCorreo.Text;
                string password = txtClave.Text;
                string name = txtName.Text;
                string lastname = txtLastname.Text;
                if (ValidarIngresoTarjeta() && ValidarIngresoTextBox() && ValidarEmail(email) && EsSoloTexto(name) && EsSoloTexto(lastname) && !lblClave.Visible)
                {
                    string document = txtDni.Text;
                    string cardNumber = userCardNumber;

                    int.TryParse(document, out int dni);
                    TarjetaSube newSube = new TarjetaSube(cardNumber);
                    Pasajero passenger = new Pasajero(dni, idGender, email, password, name, lastname, cardNumber);
                    if (!passenger.PassengerExist(passenger, listPassengers))
                    {
                        listPassengers.Add(passenger);
                        MessageBox.Show($"Se registro exitosamente!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Serializador.WriteJsonPassenger(path, listPassengers);
                        //SerializadorJSON<List<Pasajero>> serializadorPasajero = new SerializadorJSON<List<Pasajero>>();
                        //serializadorPasajero.Serialize(path, listPassengers);

                        string query = @"
                        INSERT INTO tarjetas (id, balance, socialRate) VALUES (@tarjeta, @balance, @tarifaSocial);
                        INSERT INTO pasajeros(dni, name, lastname, email, password, idGender, idSube) VALUES(@dniPasajero, @nombrePasajero, @apellidoPasajero, @emailPasajero, @contraPasajero, @generoPasajero, @idSubePasajero)";
                        Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@tarjeta", newSube.CardNumber },
                            { "@balance", 0 },
                            { "@tarifaSocial", 1 },
                            { "@dniPasajero", passenger.Dni },
                            { "@nombrePasajero", passenger.Name },
                            { "@apellidoPasajero", passenger.LastName },
                            { "@emailPasajero", passenger.Email },
                            { "@contraPasajero", passenger.Password },
                            { "@generoPasajero", passenger.Gender },
                            { "@idSubePasajero", newSube.CardNumber }
                        };
                        DataBase<Object> db = new DataBase<Object>();
                        db.Insert(query, parameters);
                        InicioPasajero inicio = new InicioPasajero(passenger, listPassengers);
                        inicio.Show();
                        MdiParent.Close();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El usuario ya se encuentra registrado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            txtDni.Text = Regex.Replace(txtDni.Text, @"[^0-9]", "");
        }
        private void ButtonGender_Click(object sender, EventArgs e)
        {
            btnMasculino.BackColor = Color.WhiteSmoke;
            btnFemenino.BackColor = Color.WhiteSmoke;
            btnX.BackColor = Color.WhiteSmoke;
            if (sender is Button clickedButton)
            {
                this.gender = clickedButton.Text;
                switch (gender)
                {
                    case "Masculino":
                        idGender = 1;
                        break;
                    case "Femenino":
                        idGender = 2;
                        break;
                    case "x":
                        idGender = 3;
                        break;
                }
                clickedButton.BackColor = Color.LightGray;
            }
        }

        private bool ValidarIngresoTarjeta()
        {
            bool allCompleted = true;
            int totalLength = 0;
            List<string> cardNumbers = new List<string>();

            foreach (Control campo in grpTarjeta.Controls)
            {
                if (campo is TextBox textBox)
                {
                    totalLength += textBox.Text.Length;

                    cardNumbers.Add(textBox.Text);
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        allCompleted = false;
                        break;
                    }
                }
            }
            cardNumbers.Reverse();

            userCardNumber = string.Join("", cardNumbers);
            if (totalLength < 16)
            {
                lblTarjeta.Visible = true;
            }
            else
            {
                lblTarjeta.Visible = false;
            }

            return allCompleted;
        }
        private bool ValidarIngresoTextBox()
        {
            bool allCompleted = true;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        allCompleted = false;
                        break;
                    }
                }
            }
            if (txtDni.Text.Length < 8)
            {
                lblDni.Visible = true;
            }
            else
            {
                lblDni.Visible = false;
            }
            if (txtClave.Text != txtRepetirClave.Text)
            {
                lblClave.Visible = true;
            }
            else
            {
                lblClave.Visible = false;
            }
            return allCompleted;
        }
        private bool ValidarEmail(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            bool result = Regex.IsMatch(email, pattern);

            if (!result)
            {
                lblCorreo.Visible = true;
            }
            else
            {
                lblCorreo.Visible = false;
            }
            return result;
        }
        private bool EsSoloTexto(string texto)
        {
            return Regex.IsMatch(texto, "^[a-zA-Z ]+$");
        }
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            txtClave.Text = Regex.Replace(txtClave.Text, @"[^0-9]", "");
        }

        private void txtRepetirClave_TextChanged(object sender, EventArgs e)
        {
            txtRepetirClave.Text = Regex.Replace(txtRepetirClave.Text, @"[^0-9]", "");
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMostrarPass_Click_1(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '•')
            {
                txtClave.PasswordChar = '\0';
                btnMostrarPass.BackgroundImage = Properties.Resources.ojo_tachado;
            }
            else
            {
                txtClave.PasswordChar = '•';
                btnMostrarPass.BackgroundImage = Properties.Resources.view;
            }
        }

        private void btnDni_Click(object sender, EventArgs e)
        {
            txtDni.PlaceholderText = "42102030";
        }

        private void btnHardcode_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int _rnd = rnd.Next(1000, 9999);
            txtTarjeta2.Text = $"{_rnd}";
            _rnd = rnd.Next(1000, 9999);
            txtTarjeta3.Text = $"{_rnd}";
            _rnd = rnd.Next(1000, 9999);
            txtTarjeta4.Text = $"{_rnd}";
            txtName.Text = "Alejandro";
            txtLastname.Text = "Heidenreich";
            _rnd = rnd.Next(1000, 9999);
            txtDni.Text = $"3320{_rnd}";
            idGender = 1;
            txtCorreo.Text = $"AleHardcode@gmail.com";
            txtClave.Text = $"{_rnd}";
            txtRepetirClave.Text = $"{_rnd}";
        }
    }
}
