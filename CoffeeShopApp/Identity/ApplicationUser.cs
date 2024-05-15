using CoffeeShopApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShopApp.Identity
{
    public class ApplicationUser : IdentityUser, IModelBase
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDraft { get; set; }

        public void Delete(string userName)
        {
            this.IsDeleted = true;
            this.UpdatedBy = userName;
            this.UpdatedDate = DateTime.Now;
        }
        public void Init()
        {
            this.Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }
    }
}
