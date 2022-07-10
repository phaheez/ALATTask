using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ALAT.Core.Entities
{
    public class Otp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Passcode { get; set; }
        public DateTime Expiry { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
