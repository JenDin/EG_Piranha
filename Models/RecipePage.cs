using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace EG_Piranha.Models
{
    [PageType(Title = "Recipe Page", UseBlocks = false)]
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

            [Field(Title = "Total duration", Options = FieldOption.HalfWidth)]
            public StringField TotalDuration { get; set; }

            [Field(Title = "Cooking time", Options = FieldOption.HalfWidth)]
            public StringField CookingTime { get; set; }

            [Field(Title = "Difficulty level")]
            public StringField DifficultyLevel { get; set; }

            [Field(Title = "Ingredient 1", Options = FieldOption.HalfWidth)]
            public StringField Ingredient1 { get; set; }

            [Field(Title = "Ingredient 2", Options = FieldOption.HalfWidth)]
            public StringField Ingredient2 { get; set; }

            [Field(Title = "Ingredient 3", Options = FieldOption.HalfWidth)]
            public StringField Ingredient3 { get; set; }

            [Field(Title = "Ingredient 4", Options = FieldOption.HalfWidth)]
            public StringField Ingredient4 { get; set; }

            [Field(Title = "Ingredient 5", Options = FieldOption.HalfWidth)]
            public StringField Ingredient5 { get; set; }

            [Field(Title = "Ingredient 6", Options = FieldOption.HalfWidth)]
            public StringField Ingredient6 { get; set; }

            [Field(Title = "Ingredient 7", Options = FieldOption.HalfWidth)]
            public StringField Ingredient7 { get; set; }

            [Field(Title = "Ingredient 8", Options = FieldOption.HalfWidth)]
            public StringField Ingredient8 { get; set; }

            [Field(Title = "Ingredient 9", Options = FieldOption.HalfWidth)]
            public StringField Ingredient9 { get; set; }

            [Field(Title = "Ingredient 10", Options = FieldOption.HalfWidth)]
            public StringField Ingredient10 { get; set; }

            [Field(Title = "Ingredient 11", Options = FieldOption.HalfWidth)]
            public StringField Ingredient11 { get; set; }

            [Field(Title = "Ingredient 12", Options = FieldOption.HalfWidth)]
            public StringField Ingredient12 { get; set; }

            [Field(Title = "Ingredient 13", Options = FieldOption.HalfWidth)]
            public StringField Ingredient13 { get; set; }

            [Field(Title = "Ingredient 14", Options = FieldOption.HalfWidth)]
            public StringField Ingredient14 { get; set; }

            [Field(Title = "Step 1")]
            public StringField Step1 { get; set; }

            [Field(Title = "Step 2")]
            public StringField Step2 { get; set; }

            [Field(Title = "Step 3")]
            public StringField Step3 { get; set; }

            [Field(Title = "Step 4")]
            public StringField Step4 { get; set; }

            [Field(Title = "Step 5")]
            public StringField Step5 { get; set; }

            [Field(Title = "Step 6")]
            public StringField Step6 { get; set; }

            [Field(Title = "Step 7")]
            public StringField Step7 { get; set; }

            [Field(Title = "Step 8")]
            public StringField Step8 { get; set; }

            [Field(Title = "Step 9")]
            public StringField Step9 { get; set; }

            [Field(Title = "Step 10")]
            public StringField Step10 { get; set; }
        }

        [Region(Title = "Recipe Region")]
        public RecipeReg RecipeRegion { get; set; }
    }
}

