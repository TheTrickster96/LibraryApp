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
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace LibraryApplication.Models

{
    public class Lending
    {
        public int Id { get; set; }


        [Display (Name = "Book")]
        public int BookId { get; set; }
        public Book bookObj { get; set; }
        

        [Display (Name = "Client")]
        public int ClientId { get; set; }
        public Client clientObj { get; set; }

        [Display(Name = "Date Taken")]
        public DateTime DatumZajmuvanje { get; set; }
        [Display(Name = "Date Returned")]
        public DateTime DatumVratena { get; set; }


        public Lending()
        {

        }
    }
}
