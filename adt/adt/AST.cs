using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adt.adt
{
    // expr: BINOP op expr expr | UNOP op expr | ATOM atom
    // atom: CONSTANT v | PARAM p
    public abstract class Expr
    {
    }

    public static class ExprMatchExtensions
    {
        public static void Match(this Expr instance, Action<Binop> binop, Action<Unop> unop, Action<AtomExpr> atomExpr, Action nullAction = null)
        {
            if (instance is Binop)
            {
                binop((Binop)instance);
            }
            else if (instance is Unop)
            {
                unop((Unop)instance);
            }
            else if (instance is AtomExpr)
            {
                atomExpr((AtomExpr)instance);
            } else if (instance == null && nullAction != null)
            {
                nullAction();
            } else
            {
                throw new Exception();
            }
        }

        public static T Match<T>(this Expr instance, Func<Binop, T> binop, Func<Unop, T> unop, Func<AtomExpr, T> atomExpr, Func<T> nullAction = null)
        {
            if (instance is Binop)
            {
                return binop((Binop)instance);
            }
            else if (instance is Unop)
            {
                return unop((Unop)instance);
            }
            else if (instance is AtomExpr)
            {
                return atomExpr((AtomExpr)instance);
            } else if (instance == null && nullAction != null)
            {
                return nullAction();
            } else
            {
                throw new Exception();
            }
        }
    }

    public enum BinopType
    {
        Plus, Minus, Mul, Div
    }

    public class Binop : Expr
    {
        public BinopType OpType { get; set; }
        public Expr Lhs { get; set; }
        public Expr Rhs { get; set; }

        public Binop() { }
        public Binop(BinopType opType, Expr lhs, Expr rhs)
        {
            OpType = opType;
            Lhs = lhs;
            Rhs = rhs;
        }
    }

    public enum UnopType
    {
        Plus, Minus
    }

    public class Unop : Expr
    {
        public UnopType OpType { get; set; }
        public Expr Operand { get; set; }

        public Unop() { }
        public Unop(UnopType opType, Expr operand)
        {
            OpType = opType;
            Operand = operand;
        }
    }

    public class AtomExpr : Expr
    {
        public Atom Atom { get; set; }
        public AtomExpr() { }
        public AtomExpr(Atom atom)
        {
            Atom = atom;
        }
    }

    public abstract class Atom
    {
    }

    public static class AtomMatchExtensions
    {
        public static void Match(this Atom instance, Action<ConstantAtom> constantAtom, Action<ParameterAtom> parameterAtom, Action nullAction = null)
        {
            if (instance is ConstantAtom)
            {
                constantAtom((ConstantAtom)instance);
            }
            else if (instance is ParameterAtom)
            {
                parameterAtom((ParameterAtom)instance);
            }
            else if (instance == null && nullAction != null)
            {
                nullAction();
            } else
            {
                throw new Exception();
            }
        }

        public static T Match<T>(this Atom instance, Func<ConstantAtom, T> constantAtom, Func<ParameterAtom, T> parameterAtom, Func<T> nullAction = null)
        {
            if (instance is ConstantAtom)
            {
                return constantAtom((ConstantAtom)instance);
            }
            else if (instance is ParameterAtom)
            {
                return parameterAtom((ParameterAtom)instance);
            }
            else if (instance == null && nullAction != null)
            {
                return nullAction();
            }
            else
            {
                throw new Exception();
            }
        }
    }

    public class ConstantAtom : Atom
    {
        public double Value { get; set; }

        public ConstantAtom() { }
        public ConstantAtom(double value)
        {
            Value = value;
        }
    }

    public class ParameterAtom : Atom
    {
        public string Name { get; set; }

        public ParameterAtom() { }
        public ParameterAtom(string name)
        {
            Name = name;
        }
    }
}
