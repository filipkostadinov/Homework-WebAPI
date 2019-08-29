using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DrawnNumbers { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public bool IsOpen { get; set; }
        //public List<Ticket> Winners { get; set; }
    }
}
