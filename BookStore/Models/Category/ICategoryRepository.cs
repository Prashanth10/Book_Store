using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Category
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategory();
        Category GetCategory(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}