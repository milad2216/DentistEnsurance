﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AccessControl
{
    [Table("Personal")]
    public class Personal : BaseEntityClass
    {
        public Personal()
        {
            Users = new HashSet<User>();
            Childrens = new HashSet<Personal>();
        }
        public int ParentId { get; set; }
        public string PersonalNo {get;set;}
        public string FirsName  {get;set;}
        public string LastName {get;set;}
        public string Relation {get;set;}
        public string NationalNo {get;set;}
        public string Unit {get;set;}


        public virtual Personal Parent { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Personal> Childrens { get; set; }
    }
}