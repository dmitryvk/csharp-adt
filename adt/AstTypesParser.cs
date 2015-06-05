using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt
{
    public static class AstTypesParser
    {
        public static List<AstNodeType> ParseTypes(string src)
        {
            var result = new List<AstNodeType>();
            var ts = new TokenStream(src);
            while (ts.Read())
            {
                if (ts.curType != TokenType.Id)
                {
                    throw new Exception();
                }
                switch (ts.curValue.ToString())
                {
                    case "node":
                        {
                            ts.ReadAssert();
                            var type = ParseNodeType(ts);
                            result.Add(type);
                        }
                        break;
                    case "node_variants":
                        {
                            ts.ReadAssert();
                            var type = ParseNodeVariantType(ts);
                            result.Add(type);
                        }
                        break;
                    default: throw new Exception();
                }
            }
            return result;
        }

        private static AstVariantType ParseNodeVariantType(TokenStream ts)
        {
            // . id '=' variantDef ('|' variantDef)*;
            if (ts.curType != TokenType.Id)
            {
                throw new Exception();
            }
            var result = new AstVariantType();
            result.Name = ts.curValue.ToString();
            ts.ReadAssert();
            // id . '=' variantDef ('|' variantDef)*;
            if (ts.curType != TokenType.Eq)
            {
                throw new Exception();
            }
            ts.ReadAssert();
            // id '=' . variantDef ('|' variantDef)*;
            var firstVariant = ParseVariant(ts);
            result.Variants.Add(firstVariant);
            // id '=' variantDef . ('|' variantDef)*;
            while (ts.curType == TokenType.Pipe)
            {
                // id '=' variantDef (. '|' variantDef)*;
                ts.ReadAssert();
                // id '=' variantDef ('|' . variantDef)*;
                var variant = ParseVariant(ts);
                // id '=' variantDef ('|' variantDef .)*;
                result.Variants.Add(variant);
            }
            return result;
        }

        private static AstVariant ParseVariant(TokenStream ts)
        {
            var result = new AstVariant();
            // variantDef ::= id field (',' field)*;
            if (ts.curType != TokenType.Id)
            {
                throw new Exception();
            }
            result.Name = ts.curValue.ToString();
            ts.ReadAssert();
            // id . field (',' field)*
            var firstField = ParseField(ts);
            result.Fields.Add(firstField);
            // id field . (field)*
            while (ts.curType == TokenType.Id)
            {
                // id field . (',' field)*
                //ts.ReadAssert();
                // id field (',' . field)*
                var field = ParseField(ts);
                // id field (',' field .)*
                result.Fields.Add(field);
            }
            return result;
        }

        private static AstNonVariantType ParseNodeType(TokenStream ts)
        {
            // . id '=' field (',' field)* ';'
            if (ts.curType != TokenType.Id)
            {
                throw new Exception();
            }
            var result = new AstNonVariantType();
            result.Name = ts.curValue.ToString();
            ts.ReadAssert();
            // id . '=' field (',' field)* ';'
            if (ts.curType != TokenType.Eq)
            {
                throw new Exception();
            }
            ts.ReadAssert();
            // id '=' . field (',' field)* ';'
            var firstField = ParseField(ts);
            // id '=' field . (field)* ';'
            result.Fields.Add(firstField);
            while (ts.curType == TokenType.Id)
            {
                //ts.ReadAssert();
                // id '=' field (',' . field)* ';'
                var field = ParseField(ts);
                // id '=' field (',' field .)* ';'
                result.Fields.Add(field);
            }
            return result;
        }

        private static AstField ParseField(TokenStream ts)
        {
            // . id ':' id
            if (ts.curType != TokenType.Id)
            {
                throw new Exception();
            }
            var fieldName = ts.curValue.ToString();
            ts.ReadAssert();
            // id . ':' id
            if (ts.curType != TokenType.Colon)
            {
                throw new Exception();
            }
            ts.ReadAssert();
            // id ':' . id
            if (ts.curType != TokenType.Id)
            {
                throw new Exception();
            }
            var fieldType = ts.curValue.ToString();
            var field = new AstField { Name = fieldName, Type = fieldType };
            ts.ReadAssert();
            // id ':' id .
            return field;
        }

        //grammar:
        // types ::= type*;
        // type ::= variantType | nonVariantType;
        // nonVariantType ::= 'node' id '=' field (',' field)*';';
        // variantType ::= 'node_variants' id '=' variantDef ('|' variantDef)*;
        // variantDef ::= id field (',' field)*;
        // field ::= id ':' id

        public enum TokenType
        {
            Eq, Semi, Colon, Pipe, Id
        }

        public class TokenStream
        {
            string src;
            int idx = 0;

            public TokenType curType;
            public StringBuilder curValue = new StringBuilder();

            public TokenStream(string src)
            {
                this.src = src;
            }

            public bool Read()
            {
                if (idx >= src.Length)
                {
                    return false;
                }

                while (idx < src.Length && char.IsWhiteSpace(src[idx]))
                {
                    ++idx;
                }

                if (idx >= src.Length)
                {
                    return false;
                }

                curValue.Clear();

                var c = src[idx];

                if (IsId(src[idx]))
                {
                    while (idx < src.Length && IsId(src[idx]))
                    {
                        curValue.Append(src[idx]);
                        ++idx;
                    }
                    curType = TokenType.Id;
                    return true;
                }
                else if (src[idx] == ':')
                {
                    curType = TokenType.Colon;
                    ++idx;
                    return true;
                }
                else if (src[idx] == ';')
                {
                    curType = TokenType.Semi;
                    ++idx;
                    return true;
                }
                else if (src[idx] == '=')
                {
                    curType = TokenType.Eq;
                    ++idx;
                    return true;
                }
                else if (src[idx] == '|')
                {
                    curType = TokenType.Pipe;
                    ++idx;
                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }

            private static bool IsId(char c)
            {
                return char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '<' || c == '>' || c == ',';
            }

            public void ReadAssert()
            {
                if (!Read())
                {
                    throw new Exception();
                }
            }
        }
    }
}
