/*

Harrison1 COSC 471 2019

File = FormUpdateDTO.cs
Author = Taylor Adam

Date = 2020 - 01 - 10

License = MIT

            Modification History

Version     Author Date           Desc
v 1.0		Taylor Adam     2020-01-20			Created

*/
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