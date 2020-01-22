using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eventor2.Models
{
    public class TicketModels
    {
        [Key]
        public int TicketID { get; set; }
        public string Type {get;set;}
        public int Price { get; set; }

    }
}