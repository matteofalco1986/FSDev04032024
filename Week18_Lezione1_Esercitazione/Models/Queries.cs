using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public static class Queries
    {
        public static string AdminData = "SELECT * FROM AdminData where Username = @username AND Password = @password";

    }
}