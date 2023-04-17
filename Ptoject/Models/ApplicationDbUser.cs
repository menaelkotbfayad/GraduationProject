using Microsoft.AspNetCore.Identity;

namespace Ptoject.Models
{
    public class ApplicationDbUser:IdentityUser
    {
     
        public virtual List<QuestionUser> QuestionUser { get; set; }

    }
}
