using LibraryApplication.Controllers;
using LibraryApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml.Linq;

namespace LibraryApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        

        [Display(Name = "Year of Issue")]
        public int YearOfIssue { get; set; }


        [Display(Name = "Number of Pages")]
        public int NumberOfPages { get; set; }
        

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher pubObj { get; set; }

    }
    public class Publisher
    {
        public int Id { get; set; }
        [Display(Name = "Publisher Name")]
        public string Name { get; set; }
        [Display(Name = "Publisher Country")]
        public string Country { get; set; }

    }
}