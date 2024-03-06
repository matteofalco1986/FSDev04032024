using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class StatoSpedizioni
    {
        private static int _minValueId = 1;
        private static int _maxValueId = 4;
        public static int MinValueId { get { return _minValueId; } }
        public static int MaxValueId { get { return _maxValueId; } }
        public int Id { get; set; }
        public string StatoSpedizione { get; set; }
    }
}