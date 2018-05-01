using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.PupilDetailViewModels
{
    public class IndexViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int Id { get; set; }
    }
}
