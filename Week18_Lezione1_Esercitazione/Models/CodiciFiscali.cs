﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class CodiciFiscali
    {
        private static int _length = 16;
        public static int Length { get { return _length; } }
        public int Id { get; set; }
        public string CodiceFiscale { get; set; }
        public string Password {  get; set; }
        public string NomeDestinatario { get; set; }
    }
}