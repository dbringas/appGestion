using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApp.Models
{
    public class MenuViewModels
    {
        public String id { get; set; }
        public String padre { get; set; }
        public Int32 hijos { get; set; }
        public String area { get; set; }
        public String controlador { get; set; }
        public String vista { get; set; }
        public String icono { get; set; }
        public String nombre { get; set; }
    }
}