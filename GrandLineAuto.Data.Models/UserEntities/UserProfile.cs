using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models.UserEntities
{
    public class UserProfile
    {
        [Comment("Identification of the user profile")]
        public Guid Id { get; set; }

        [Comment("Identification of the user id")]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        [Comment("First name used for cheackout")]
        public string FirstName { get; set; } = null!;

        [Comment("Last name used for checkout")]
        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? DefaultAddress { get; set; }
        public string? City { get; set; }
    }
}
