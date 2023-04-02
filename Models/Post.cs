using System;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace EG_Piranha.Models
{
    [PostType(Title = "Post", UseBlocks = false)]
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

            [Field(Title = "First image")]
            public ImageField FirstImage { get; set; }

            [Field(Title = "Second image")]
            public ImageField SecondImage { get; set; }

            [Field(Title = "Third image")]
            public ImageField ThirdImage { get; set; }
        }

        [Region]
        public PostReg PostRegion { get; set; }
    }
}

