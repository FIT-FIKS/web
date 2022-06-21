using Microsoft.AspNetCore.Identity;

namespace Fiks.Models
{
    public class User : IdentityUser<long>
    {
        User() : base() {
            TwoFactorEnabled = false;    
        }

        User(string userName) : base(userName) { 
            TwoFactorEnabled = false;
        }

        public School school { get; set; }
    }
}
