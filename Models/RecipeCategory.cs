using System;
using Microsoft.Extensions.Options;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;
using static EG_Piranha.Models.RecipePage;

namespace EG_Piranha.Models
{
    [PageType(Title = "Recipe Category Page", UseBlocks = false)]
    public class RecipeCategory : Page<SimplePage>
    {
        public class RecipeCategoryReg
        {
            [Field(Title = "Recipe category")]
            public StringField CategoryName { get; set; }

            [Field(Title = "Recipe category image")]
            public ImageField CategoryImage { get; set; }
        }

        [Region(Title = "Recipe Category Region")]
        public RecipeCategoryReg RecipeCategoryRegion { get; set; }
    }
}

