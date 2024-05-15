using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoffeeShopApp.Models
{
    public interface IModelBase
    {
            [Key]
            [Required]
            [MaxLength(128)]
            string Id { get; set; }
            string CreatedBy { get; set; }
            DateTime CreatedDate { get; set; }
            string UpdatedBy { get; set; }
            DateTime? UpdatedDate { get; set; }
            [DefaultValue(false)]
            bool IsDeleted { get; set; }
            [DefaultValue(false)]
            bool IsDraft { get; set; }
            void Delete(string userName);
            void Init();

    }
}
