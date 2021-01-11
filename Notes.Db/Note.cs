using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Notes.Db
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string value { get; set; }
    }
}
