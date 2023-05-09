using System;
using Microsoft.AspNetCore.Routing;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace EG_Piranha.Models
{
    [PostType(Title = "Post")]
    public class Post : PostBase
	{
        public class PostReg
        {
            [Field]
            public StringField Title { get; set; }

            [Field(Title = "Top content")]
            public TextField TopContent { get; set; }

            [Field(Title = "Bottom content (optional)")]
            public TextField BottomContent { get; set; }

            [Field(Title = "First image", Options = FieldOption.HalfWidth)]
            public ImageField FirstImage { get; set; }

            [Field(Title = "Second image", Options = FieldOption.HalfWidth)]
            public ImageField SecondImage { get; set; }

            [Field(Title = "Third image", Options = FieldOption.HalfWidth)]
            public ImageField ThirdImage { get; set; }

            [Field(Title = "Fourth image", Options = FieldOption.HalfWidth)]
            public ImageField FourthImage { get; set; }
        }

        [Region]
        public PostReg PostRegion { get; set; }
    }
}

