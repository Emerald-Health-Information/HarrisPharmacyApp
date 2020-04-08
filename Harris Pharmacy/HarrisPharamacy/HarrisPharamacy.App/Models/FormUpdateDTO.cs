using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;

namespace HarrisPharmacy.App.Models
{
    public class FormUpdateDTO
    {
        public Form Form { get; set; }
        public List<FormField> FormFields { get; set; }
    }
}