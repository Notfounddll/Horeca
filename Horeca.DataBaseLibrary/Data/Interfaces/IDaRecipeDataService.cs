using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaRecipeDataService
    {
        public Task CreateRecipe(RecipeModel newRecipe);
        public Task DeleteRecipe(int setActive);
        public Task UpdateRecipe(RecipeModel updateRecipe);
    }
}
