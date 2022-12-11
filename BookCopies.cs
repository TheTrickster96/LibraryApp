using LibraryApplication.Data;
using Microsoft.AspNetCore.Mvc;
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
    public class BookCopies
    {
        public int Id { get; set; }


        [Display (Name = "Book")]
        public int BookId { get; set; }
        public Book bookObj { get; set; }


        [Display(Name = "Number of Copies")]
        public int NumberOfCopies { get; set; }


        [Display (Name ="Library")]
        public int LibraryId { get; set; }
        public Library libObj { get; set; }


        public BookCopies()
        {

        }
    }
}
