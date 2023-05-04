using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace EG_Piranha.Models
{
    [PageType(Title = "Recipe Details Page")]
    public class RecipePage : Page<SimplePage>
    {
        public class RecipeReg
        {
            [Field(Title = "Title")]
            public StringField Title { get; set; }

            [Field(Title = "Portions")]
            public StringField Portions { get; set; }

            [Field(Title = "Recipe image")]
            public ImageField RecipeImage { get; set; }

            [Field(Title = "Recipe image small")]
            public ImageField RecipeImageSmall { get; set; }

            [Field(Title = "Total duration", Options = FieldOption.HalfWidth)]
            public StringField TotalDuration { get; set; }

            [Field(Title = "Cooking time", Options = FieldOption.HalfWidth)]
            public StringField CookingTime { get; set; }

            [Field(Title = "Difficulty level")]
            public StringField DifficultyLevel { get; set; }


            [Field(Title = "Ingredient Html")]
            public HtmlField IngredientsHtml { get; set; }

            [Field(Title = "Method Html")]
            public HtmlField MethodHtml { get; set; }
        }

        [Region(Title = "Recipe Region")]
        public RecipeReg RecipeRegion { get; set; }
    }
}

