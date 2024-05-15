using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoffeeShopApp.Models
{
    public class ModelBase : IModelBase
    {
        public string Id { get; set; } 
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDraft { get; set; }

        public ModelBase()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedDate = DateTime.Now;
        }
        public void Init()
        {
            this.Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
        }

        public void Delete(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
