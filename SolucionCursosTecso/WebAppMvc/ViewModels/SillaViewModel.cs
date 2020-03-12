using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.ViewModels
{
    public class SillaViewModel
    {
        public int SillaId { get; set; }

        public string Codigo { get; set; }

        public string Estado { get; set; }
    }
}