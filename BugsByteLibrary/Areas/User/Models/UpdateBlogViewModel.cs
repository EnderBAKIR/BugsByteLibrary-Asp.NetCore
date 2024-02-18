using Core.Layer.Models;

namespace BugsByteLibrary.Areas.User.Models
{
    public class UpdateBlogViewModel
    {
        public Blog Blog { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
    }
}
