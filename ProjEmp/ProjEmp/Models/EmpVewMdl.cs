﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEmp.Models
{
    public class EmpVewMdl{public int Id { get; set; } [Required]public string Name { get; set; } [Required][EmailAddress] public string EmailId { get; set; } [Required]public string Dept { get; set; }}
}
