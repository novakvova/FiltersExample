﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblCategories")]
    public class Category
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [ForeignKey("Parent"), Column(Order = 1)]
        public int ? ParentId { get; set; }
        [Required, StringLength(maximumLength:255)]
        public string Name { get; set; }
        public ICollection<Category> Parent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
