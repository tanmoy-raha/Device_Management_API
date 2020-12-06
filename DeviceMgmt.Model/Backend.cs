using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeviceMgmt.Model
{
    public interface IBackend
    {
        Guid ID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
    public class DeviceMgmt_Backend : IBackend
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
    }
}
