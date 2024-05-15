using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApp.Utilities.Validations
{
    public class UniqueAttribute<TEntity> : ValidationAttribute where TEntity : class
    {
        private readonly Type _contextType;
        public UniqueAttribute(Type contextType)
        {
            _contextType = contextType;
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            IServiceProvider serviceProvider = validationContext.GetRequiredService<IServiceProvider>();
            DbContext dbContext = (DbContext)serviceProvider.GetRequiredService(_contextType);

            string attributeName = validationContext.MemberName;
            if (attributeName.IsNullOrEmpty()) return new ValidationResult("Column cannot be null");

            string currentValue = value?.ToString();
            IQueryable<TEntity> query = dbContext.Set<TEntity>().
                Where(v => EF.Property<object>(v, attributeName).ToString() == currentValue);

            return query.Any() ? new ValidationResult($"The {attributeName} field must be unique.") : ValidationResult.Success!;
        }
    }
}
