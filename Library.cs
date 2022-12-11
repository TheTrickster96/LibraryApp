using LibraryApplication.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace LibraryApplication.Models

{
    public class Library
    {
        public int Id { get; set; }
        [Display(Name = "Library Name")]
        public string Name { get; set; }
        [Display(Name = "Library Address")]
        public string Address { get; set; }
        [Display(Name = "Library City")]
        public string City { get; set; }

        public Library()
        {

        }
    }
}
