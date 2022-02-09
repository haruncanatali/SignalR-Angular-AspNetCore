using System;
using System.Collections.Generic;

#nullable disable

namespace SecimAnaliz.API.Models
{
    public partial class TblParti
    {
        public TblParti()
        {
            TblOys = new HashSet<TblOy>();
        }

        public int Id { get; set; }
        public string PartiAdi { get; set; }

        public virtual ICollection<TblOy> TblOys { get; set; }
    }
}
