using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt
{

    public abstract class AstNodeType
    {
        public string Name { get; set; }
    }

    public class AstNonVariantType : AstNodeType
    {
        public List<AstField> Fields { get; set; }

        public AstNonVariantType()
        {
            Fields = new List<AstField>();
        }
    }

    public class AstVariantType : AstNodeType
    {
        public List<AstVariant> Variants { get; set; }

        public AstVariantType()
        {
            Variants = new List<AstVariant>();
        }
    }

    public class AstVariant
    {
        public string Name { get; set; }
        public List<AstField> Fields { get; set; }

        public AstVariant()
        {
            Fields = new List<AstField>();
        }
    }

    public class AstField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Initializer { get; set; }
    }
}
