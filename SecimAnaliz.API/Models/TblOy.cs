using System;
using System.Collections.Generic;

#nullable disable

namespace SecimAnaliz.API.Models
{
    public partial class TblOy
    {
        public int Id { get; set; }
        public DateTime? SistemGirisTarihi { get; set; }
        public int? PartiId { get; set; }

        public virtual TblParti Parti { get; set; }
    }
}
