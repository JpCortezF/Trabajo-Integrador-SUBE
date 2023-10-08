﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Usuarios
{
    public class Pasajero : Usuario
    {
        Dictionary<string, Usuario> dictionaryPassengers;
        string document;
        string gender;
        TarjetaSube mySube;

        public Pasajero(string document, string gender, string email, string password,TarjetaSube sube) : base(email, password)
        {
            this.document = document;
            this.gender = gender;
            this.mySube = sube;
        }

        public string Document { get => document; set => document = value; }
        public string Gender { get => gender; set => gender = value; }      
        public TarjetaSube MySube { get => mySube; set => mySube = value; }

        /// <summary>
        /// Compara los atributos de 2 pasajeros, si encuentra alguna coincidencia entre sus atributos, retorna true.
        /// </summary>
        /// <param name="pasajero1"></param>
        /// <param name="pasajero2"></param>
        /// <returns> Retorna true si coincide algun atributo de los pasajeros. False si no encuentra coincidencia. </returns>
        private bool ComparePassengers(Pasajero pasajero1, Pasajero pasajero2)
        {
            return pasajero1.Document == pasajero2.Document
                || pasajero1.Email == pasajero2.Email
                || pasajero1.MySube.CardNumber == pasajero2.MySube.CardNumber;
        }
        /// <summary>
        /// Recorre todos los valores dentro del Dictionary, y en cada iteracion guarda el valor en PassengerToCompare
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns> Retorna True si el pasajero se encuentra en el Dictionary. False si se encuentra. </returns>
        public bool PassengerExist(Pasajero passenger, Dictionary<string, Usuario> dictionaryPassengers)
        {
            foreach (Pasajero passengerToCompare in dictionaryPassengers.Values)
            {
                if (ComparePassengers(passenger, passengerToCompare))
                {
                    return true;
                }
            }
            return false;
        }
        public string ShowUsers(Dictionary<string, Usuario> dictionaryPassengers)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, Usuario> kvp in dictionaryPassengers)
            {
                if (kvp.Value is Pasajero passenger)
                {
                    sb.AppendLine($"Email: {passenger.email}");
                    sb.AppendLine($"Password: {passenger.password}");
                    sb.AppendLine($"DNI: {passenger.document}");
                    sb.AppendLine($"Gender: {passenger.gender}");
                    sb.AppendLine($"Sube id: {passenger.MySube.CardNumber}");
                    sb.AppendLine($"Tarifa social: {passenger.MySube.TarifaSocial}");
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public string PassengerPassword(Pasajero passenger)
        {
            return passenger.password;
        }
    }
}
