﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_TarjetaSube
{
    public class Tramites
    {
        long claimId;
        string dniClaimer;
        string claimMessage;
        DateTime claimTime;
        string claimComplete;

        public Tramites() { }

        public Tramites(long claimId, string dniClaimer, string claimMessage, DateTime claimTime, string claimComplete)
        {
            this.claimId = claimId;
            this.dniClaimer = dniClaimer;
            this.claimMessage = claimMessage;
            this.claimTime = claimTime;
            this.ClaimComplete = claimComplete;
        }

        public long ClaimId { get => claimId; set => claimId = value; }
        public string DniClaimer { get => dniClaimer; set => dniClaimer = value; }
        public string ClaimMessage { get => claimMessage; set => claimMessage = value; }
        public DateTime ClaimTime { get => claimTime; set => claimTime = value; }
        public string ClaimComplete { get => claimComplete; set => claimComplete = value; }
    }
}
