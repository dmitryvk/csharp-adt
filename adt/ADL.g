grammar ADL;

options
{
    language=CSharp3;
}

@parser::namespace { adt }
@lexer::namespace { adt }

@header
{
using adt.ADL;
}

public program returns [ProgramDecl r]
    : namespaceDecl  { $r = new ProgramDecl { ns = $namespaceDecl.r }; }
    baseClassDecl { $r.baseClass = $baseClassDecl.r; }
    (walkerDecl { $r.walker = $walkerDecl.r; })?
    (printerDecl { $r.printer = $printerDecl.r; })?
    (node
        {
            $r.nodes.Add($node.r);
        }
    )+ EOF;

namespaceDecl returns [NamespaceDecl r]
@init { $r = new NamespaceDecl(); }
    : NAMESPACE id1=ID { $r.ids.Add($id1.text); } (DOT id2=ID { $r.ids.Add($id2.text); })* SEMI;

baseClassDecl returns [BaseClassDecl r]
    : BASE_CLASS ID SEMI
    { $r = new BaseClassDecl { name = $ID.text }; }
    ;

walkerDecl returns [WalkerDecl r]
    : WALKER ID SEMI
    { $r = new WalkerDecl { name = $ID.text }; }
    ;

printerDecl returns [PrinterDecl r]
    : PRINTER name=ID root=ID SEMI
    { $r = new PrinterDecl { name = $name.text, root = $root.text }; }
    ;

node returns [NodeDecl r]
    : nodeVariants { $r = $nodeVariants.r; } | nodeConcrete { $r = $nodeConcrete.r; };
    
nodeVariants returns [NodeVariantsDecl r]
    : ID EQ { $r = new NodeVariantsDecl { id = $ID.text }; }
    (
        c=commonFields
        {
            $r.commonFieldsBefore = $c.r;
        }
    )?
    v1=nodeVariant { $r.variants.Add($v1.r); } (PIPE v2=nodeVariant { $r.variants.Add($v2.r); })*
    (
        c=commonFields
        {
            $r.commonFieldsAfter = $c.r;
        }
    )?
    common_attributes?
    {
        $r.attributes = $common_attributes.r ?? new List<AttributeDecl>();
    }
    SEMI;

commonFields returns [List<FieldDecl> r]
    : COMMON_FIELDS OPEN fields? CLOSE
    {
        $r = $fields.r ?? new List<FieldDecl>();
    };

nodeVariant returns [NodeVariantDecl r]
    : ID OPEN fields? CLOSE attributes?
   { $r = new NodeVariantDecl 
       { id = $ID.text,
        fields = $fields.r ?? new List<FieldDecl>(),
        attributes = $attributes.r ?? new List<AttributeDecl>()
       };
   };

nodeConcrete returns [NodeConcreteDecl r]
    : ID EQ fields? attributes?
   { $r = new NodeConcreteDecl 
       { id = $ID.text,
        fields = $fields.r ?? new List<FieldDecl>(),
        attributes = $attributes.r ?? new List<AttributeDecl>()
       };
   } SEMI;
    
fields returns [List<FieldDecl> r]
@init { $r = new List<FieldDecl>(); }
    : f1=field { $r.Add($f1.r); } (COMMA f2=field { $r.Add($f2.r); })*;

attributes returns [List<AttributeDecl> r]
@init { $r = new List<AttributeDecl>(); }
    : ATTRIBUTES a1=attributeDecl { $r.Add($a1.r); } (COMMA a2=attributeDecl { $r.Add($a2.r); })*;

common_attributes returns [List<AttributeDecl> r]
@init { $r = new List<AttributeDecl>(); }
    : COMMON_ATTRIBUTES a1=attributeDecl { $r.Add($a1.r); } (COMMA a2=attributeDecl { $r.Add($a2.r); })*;
    
field returns [FieldDecl r]
    : typeId=ID (q=QUESTION|a=ASTERISK)? nameId=ID? {
    $r = new FieldDecl {
    type = $typeId.text, id = $nameId.text ?? $typeId.text, optional = $q != null, many = $a != null    };
    };

attributeDecl returns [AttributeDecl r]
    : PRINTED? attrType ID { $r = new AttributeDecl { id = $ID.text, type = $attrType.r, printed = $PRINTED != null }; };

attrType returns [string r]
    : id1=ID { $r = $id1.text; } (DOT id2=ID { $r = $r + "." + $id2.text; })*
    | QUOTED_TEXT { $r = $QUOTED_TEXT.text.Substring(1, $QUOTED_TEXT.text.Length - 2); };
    
QUOTED_TEXT
    : '"' (options { greedy = false; }: ~'"')* '"';

NAMESPACE: '@namespace';
WALKER: '@walker';
PRINTER: '@printer';
BASE_CLASS: '@baseclass';

COMMON_FIELDS: '@common_fields';
ATTRIBUTES: '@attributes';
COMMON_ATTRIBUTES: '@common_attributes';
PRINTED: '@printed';
    
QUESTION: '?';
ASTERISK: '*';
    
DOT : '.';

PIPE: '|';

SEMI: ';';

WS  :   (   ' '
        |   '\t'
        |   '\r' '\n'
        |   '\n'
        |   '\r'
        )
        {Skip();} //ignore this token
        ;

COMMENT
    : '/*' (options {greedy=false;} : .)* '*/' { Skip(); }
    | '//' (~('\r'|'\n'))* ('\n' | ('\r' (options{greedy=true;}:'\n')?)) { Skip(); };

ID 
    : ID_START_LETTER ( ID_LETTER )*
    ;

EQ : '=';

OPEN: '(';
CLOSE: ')';

COMMA: ',';

fragment
ID_START_LETTER
    :    '_'
    |    '$'
    |    'a'..'z'
    |    'A'..'Z'
    |    '\u0080'..'\ufffe'
    ;

fragment
ID_LETTER
    :    ID_START_LETTER
    |    '0'..'9'
    ;