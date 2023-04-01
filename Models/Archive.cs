using System;
using Piranha.AttributeBuilder;
using Piranha.Models;
using System.IO.Compression;

namespace EG_Piranha.Models
{
    [PageType(Title = "Archive Page", UseBlocks = false, IsArchive = true)]
    public class Archive : Page<Archive>
    {

    }
}