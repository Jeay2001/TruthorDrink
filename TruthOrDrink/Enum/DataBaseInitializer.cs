using TruthOrDrink.Enum;
using TruthOrDrink.MVVM.Models;
using TruthOrDrink.Repositories;

namespace TruthOrDrink;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        var categoryRepo = new BaseRepository<Category>();

        // Add standard categories if they do not exist
        var standardCategories = new List<Category>
        {
            new Category { Name = CategoryEnum.Party },
            new Category { Name = CategoryEnum.Friends },
            new Category { Name = CategoryEnum.Family }
        };

        foreach (var category in standardCategories)
        {
            if (categoryRepo.GetEntities().All(c => c.Name != category.Name))
            {
                categoryRepo.SaveEntity(category);
            }
        }
    }
}
