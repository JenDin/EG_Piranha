using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace EG_Piranha.Models
{
    [PageType(Title = "Product Page", UseBlocks = false)]
    public class ProductPage : Page<SimplePage>
    {
        public class ProductReg
        {
            [Field(Title = "Product title")]
            public StringField Title { get; set; }

            [Field(Title = "Product image")]
            public ImageField ProductImage { get; set; }

            [Field(Title = "Primary description")]
            public TextField Description1 { get; set; }

            [Field(Title = "Ingredients")]
            public TextField Ingredients { get; set; }

            [Field(Title = "Energy (kcal)")]
            public StringField Energy { get; set; }

            [Field(Title = "Fat (g)")]
            public StringField Fat { get; set; }

            [Field(Title = "Saturated fat (g)")]
            public StringField SaturatedFat { get; set; }

            [Field(Title = "Carbohydrates (g)")]
            public StringField Carbohydrates { get; set; }

            [Field(Title = "Protein (g)")]
            public StringField Protein { get; set; }

            [Field(Title = "Fibers (g)")]
            public StringField Fibers { get; set; }

            [Field(Title = "Sugar (g)")]
            public StringField Sugar { get; set; }

            [Field(Title = "Salt (g)")]
            public StringField Salt { get; set; }
        }

        [Region(Title = "Product Region")]
        public ProductReg ProductRegion { get; set; }
    }
}

