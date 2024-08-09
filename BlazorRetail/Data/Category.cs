using System.ComponentModel.DataAnnotations;

namespace BlazorRetail.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category must have a name.")]
        public string Name { get; set; }
    }
}
