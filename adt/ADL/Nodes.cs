using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt.ADL
{
    public class ProgramDecl
    {
        public NamespaceDecl ns;
        public BaseClassDecl baseClass;
        public WalkerDecl walker;
        public PrinterDecl printer;
        public List<NodeDecl> nodes = new List<NodeDecl>();
    }

    public class NamespaceDecl
    {
        public List<string> ids = new List<string>();
    }

    public class BaseClassDecl
    {
        public string name;
    }

    public class WalkerDecl
    {
        public string name;
    }

    public class PrinterDecl
    {
        public string name;
        public string root;
    }

    public abstract class NodeDecl
    {
        public List<AttributeDecl> attributes;
    }

    public class NodeVariantsDecl : NodeDecl
    {
        public string id;
        public List<NodeVariantDecl> variants = new List<NodeVariantDecl>();
        public List<FieldDecl> commonFields = new List<FieldDecl>();
    }

    public class NodeVariantDecl
    {
        public string id;
        public List<FieldDecl> fields = new List<FieldDecl>();
        public List<AttributeDecl> attributes;
    }

    public class NodeConcreteDecl : NodeDecl
    {
        public string id;
        public List<FieldDecl> fields = new List<FieldDecl>();
    }

    public class FieldDecl
    {
        public string id;
        public string type;
        public bool optional;
        public bool many;
    }

    public class AttributeDecl
    {
        public string id;
        public string type;
        public bool printed;
    }
}
