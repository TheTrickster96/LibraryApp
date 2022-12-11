using LibraryApplication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace LibraryApplication.Models

{
    public class Client
    {
        public int Id { get; set; }
        [Display (Name = "Client Name")]
        public string Name { get; set; }
        [Display(Name = "Client Phone")]
        public string Phone { get; set; }
        [Display(Name = "Client Address")]
        public string Address { get; set; }
        [Display(Name = "Client City")]
        public string City { get; set; }

        public Client()
        {

        }
    }
}
