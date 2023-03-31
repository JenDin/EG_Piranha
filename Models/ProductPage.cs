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

            [Field(Title = "Secondary description")]
            public TextField Description2 { get; set; }

            [Field]
            public TextField Ingredients { get; set; }
        }

        [Region(Title = "Product Region")]
        public ProductReg ProductRegion { get; set; }
    }
}

