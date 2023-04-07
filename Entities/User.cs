using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FileSharingAPI.Entities
{
    public class User : IdentityUser
    {
        public virtual List<FileHeader> Files { get; set; }
    }
}
