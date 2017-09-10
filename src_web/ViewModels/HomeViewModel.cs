using System;
using System.Collections.Generic;
using src_lib.Models;

namespace src_web.ViewModels
{
    public class HomeViewModel
    {
        public List<SimEvent> SimEvents{ get; set; }

        public SimInfo Info { get; set; }

        public string TestMessage { get; set; }
    }
}