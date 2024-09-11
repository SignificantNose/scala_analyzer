using ScalaParse.Generated;

namespace Antlr_Scala;

public class ScalaVisitor : ScalaBaseVisitor<object?>
{
    public Dictionary<string, int> Operations
    {
        get => _operations;
    }

    public Dictionary<string, int> Operands
    {
        get => _operands;
    }
    private Dictionary<string, int> _operations = new ();
    private Dictionary<string, int> _operands = new ();

    private void AddOperation(string operationName, int quantity=1)
    {
        if (_operations.TryGetValue(operationName, out int prevValue))
        {
            _operations[operationName] = prevValue + quantity;
        }
        else
        {
            _operations.Add(operationName, quantity);
        }
    }

    private void AddOperand(string operandName, int quantity=1)
    {
        if (_operands.TryGetValue(operandName, out int prevValue))
        {
            _operands[operandName] = prevValue + quantity;
        }
        else
        {
            _operands.Add(operandName, quantity);
        }
    }


    public override object? VisitDotOp(ScalaParser.DotOpContext context)
    {
        AddOperation(".");     
        return base.VisitDotOp(context);
    }

    public override object? VisitImportId(ScalaParser.ImportIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitImportId(context);
    }

    public override object? VisitObjectId(ScalaParser.ObjectIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitObjectId(context);
    }

    public override object? VisitTemplateBody(ScalaParser.TemplateBodyContext context)
    {
        AddOperation("{...}");
        return base.VisitTemplateBody(context);
    }

    public override object? VisitAssignOp(ScalaParser.AssignOpContext context)
    {
        AddOperation("=");
        return base.VisitAssignOp(context);
    }

    public override object? VisitFuncId(ScalaParser.FuncIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitFuncId(context);
    }

    public override object? VisitParamId(ScalaParser.ParamIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitParamId(context);
    }

    public override object? VisitBlockExpr(ScalaParser.BlockExprContext context)
    {
        AddOperation("{...}");
        return base.VisitBlockExpr(context);
    }

    public override object? VisitFunctionInvocationId(ScalaParser.FunctionInvocationIdContext context)
    {
        AddOperation($"{context.GetText()}()");
        return base.VisitFunctionInvocationId(context);
    }

    public override object? VisitExpr1WithSemi(ScalaParser.Expr1WithSemiContext context)
    {
        AddOperation(";");
        return base.VisitExpr1WithSemi(context);
    }

    public override object? VisitSimpleExpr1WithSemi(ScalaParser.SimpleExpr1WithSemiContext context)
    {
        AddOperation(";");
        return base.VisitSimpleExpr1WithSemi(context);
    }

    public override object? VisitLiteral(ScalaParser.LiteralContext context)
    {
        AddOperand(context.GetText());
        return base.VisitLiteral(context);
    }
    
    public override object? VisitUnderscore(ScalaParser.UnderscoreContext context)
    {
        AddOperand("_");
        return base.VisitUnderscore(context);
    }

    public override object? VisitActualStableId(ScalaParser.ActualStableIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitActualStableId(context);
    }

    public override object? VisitMethodInvPart1(ScalaParser.MethodInvPart1Context context)
    {
        AddOperand(context.GetText());
        AddOperation(".");
        return base.VisitMethodInvPart1(context);
    }

    public override object? VisitMethodInvPart2(ScalaParser.MethodInvPart2Context context)
    {
        AddOperation($"{context.GetText()}()");
        return base.VisitMethodInvPart2(context);
    }

    public override object? VisitValVarId(ScalaParser.ValVarIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitValVarId(context);
    }

    public override object? VisitIfExprNoElse(ScalaParser.IfExprNoElseContext context)
    {
        AddOperation("if () ...");
        return base.VisitIfExprNoElse(context);
    }

    public override object? VisitIfExprWithElse(ScalaParser.IfExprWithElseContext context)
    {
        AddOperation("if () ... else ...");
        return base.VisitIfExprWithElse(context);
    }

    public override object? VisitPendSymbol(ScalaParser.PendSymbolContext context)
    {
        AddOperation(context.GetText());
        return base.VisitPendSymbol(context);
    }

    public override object? VisitOperationCmp(ScalaParser.OperationCmpContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationCmp(context);
    }

    public override object? VisitOperationBit(ScalaParser.OperationBitContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationBit(context);
    }

    public override object? VisitOperationBool(ScalaParser.OperationBoolContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationBool(context);
    }

    public override object? VisitOperationMul(ScalaParser.OperationMulContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationMul(context);
    }

    public override object? VisitOperationSign(ScalaParser.OperationSignContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationSign(context);
    }

    public override object? VisitOperationSum(ScalaParser.OperationSumContext context)
    {
        AddOperation(context.GetText());
        return base.VisitOperationSum(context);
    }

    public override object? VisitBoolExprWithParentheses(ScalaParser.BoolExprWithParenthesesContext context)
    {
        AddOperation("()");
        return base.VisitBoolExprWithParentheses(context);
    }

    public override object? VisitArithmeticExprWithParentheses(ScalaParser.ArithmeticExprWithParenthesesContext context)
    {
        AddOperation("()");
        return base.VisitArithmeticExprWithParentheses(context);
    }

    public override object? VisitMatchExpr(ScalaParser.MatchExprContext context)
    {
        AddOperation("... match {...}");
        return base.VisitMatchExpr(context);
    }

    public override object? VisitAssignId(ScalaParser.AssignIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitAssignId(context);
    }

    public override object? VisitAssignClassTemplateId(ScalaParser.AssignClassTemplateIdContext context)
    {
        AddOperand($"{context.GetText()}()");
        return base.VisitAssignClassTemplateId(context);
    }

    public override object? VisitAssignSimpleExpr1WithSemi(ScalaParser.AssignSimpleExpr1WithSemiContext context)
    {
        AddOperation(";");
        return base.VisitAssignSimpleExpr1WithSemi(context);
    }

    public override object? VisitAssignMethodInvPart2(ScalaParser.AssignMethodInvPart2Context context)
    {
        AddOperand($"{context.GetText()}()");
        return base.VisitAssignMethodInvPart2(context);
    }

    public override object? VisitAssignFunctionInvocationId(ScalaParser.AssignFunctionInvocationIdContext context)
    {
        AddOperand($"{context.GetText()}()");
        return base.VisitAssignFunctionInvocationId(context);
    }

    public override object? VisitTry(ScalaParser.TryContext context)
    {
        AddOperation("try ...");
        return base.VisitTry(context);
    }

    public override object? VisitTryCatch(ScalaParser.TryCatchContext context)
    {
        AddOperation("try ... catch ...");
        return base.VisitTryCatch(context);
    }

    public override object? VisitTryFinally(ScalaParser.TryFinallyContext context)
    {
        AddOperation("try ... finally ...");
        return base.VisitTryFinally(context);
    }

    public override object? VisitTryCatchFinally(ScalaParser.TryCatchFinallyContext context)
    {
        AddOperation("try ... catch ... finally ...");
        return base.VisitTryCatchFinally(context);
    }

    public override object? VisitBoolConstant(ScalaParser.BoolConstantContext context)
    {
        AddOperand(context.GetText());
        return base.VisitBoolConstant(context);
    }

    public override object? VisitClassId(ScalaParser.ClassIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitClassId(context);
    }

    public override object? VisitTraitId(ScalaParser.TraitIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitTraitId(context);
    }

    public override object? VisitClassParamId(ScalaParser.ClassParamIdContext context)
    {
        AddOperand(context.GetText());
        return base.VisitClassParamId(context);
    }

    public override object? VisitFor(ScalaParser.ForContext context)
    {
        AddOperation("for (...) ... ");
        return base.VisitFor(context);
    }

    public override object? VisitForYield(ScalaParser.ForYieldContext context)
    {
        AddOperation("for (...) yield ...");
        return base.VisitForYield(context);
    }

    public override object? VisitGenerator(ScalaParser.GeneratorContext context)
    {
        AddOperation("<-");
        return base.VisitGenerator(context);
    }

    public override object? VisitWhileExpr(ScalaParser.WhileExprContext context)
    {
        AddOperation("while () ...");
        return base.VisitWhileExpr(context);
    }

    public override object? VisitDoWhileExpr(ScalaParser.DoWhileExprContext context)
    {
        AddOperation("do ... while ()");
        return base.VisitDoWhileExpr(context);
    }

    public override object? VisitGuard_(ScalaParser.Guard_Context context)
    {
        AddOperation("if ...");
        return base.VisitGuard_(context);
    }

    // public override object? VisitReturnExpr(ScalaParser.ReturnExprContext context)
    // {
    //     AddOperation("return ...");
    //     return base.VisitReturnExpr(context);
    // }
    //
    // public override object? VisitThrowExpr(ScalaParser.ThrowExprContext context)
    // {
    //     AddOperation("throw ...");
    //     return base.VisitThrowExpr(context);
    // }
}