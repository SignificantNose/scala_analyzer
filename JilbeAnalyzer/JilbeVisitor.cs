using ScalaJilbe.Generated;

namespace JilbeAnalyzer;

public class JilbeVisitor : ScalaJilbeBaseVisitor<object?>
{
    public int amntOfOperators = 0;
    public int amntOfConditionals = 0;
    public int maxNestingLevel = 0;

    private int currentNestingLevel = 0;
    private int generatorCounter = 0;

    public int fors = 0;
    public int cases = 0;
    public int ifs = 0;
    public int whiles = 0;
    public int assigns = 0;
    public int sums = 0;
    public int muls = 0;
    public int cmps = 0;
    public int bits = 0;
    public int bools = 0;
    public int signs = 0;
    public int brackets = 0;
    
    
    private void StartNesting()
    {
        if (currentNestingLevel > maxNestingLevel)
        {
            maxNestingLevel = currentNestingLevel;
        }
        
        currentNestingLevel++;
    }

    private void FinishNesting()
    {
        currentNestingLevel--;
    }

    public override object? VisitNestedCaseClause(ScalaJilbeParser.NestedCaseClauseContext context)
    {
        StartNesting();
        amntOfConditionals++;
        amntOfOperators++;
        cases++;
        var result = base.VisitNestedCaseClause(context);
        FinishNesting();
        return result;
    }

    public override object? VisitIfClause(ScalaJilbeParser.IfClauseContext context)
    {
        StartNesting();
        amntOfConditionals++;
        amntOfOperators++;
        ifs++;
        var result = base.VisitIfClause(context);
        FinishNesting();
        return result;
    }

    public override object? VisitElseClause(ScalaJilbeParser.ElseClauseContext context)
    {
        StartNesting();
        var result = base.VisitElseClause(context);
        FinishNesting();
        return result;
    }

    public override object? VisitWhileExpr(ScalaJilbeParser.WhileExprContext context)
    {
        StartNesting();
        amntOfConditionals++;
        amntOfOperators++;
        whiles++;
        var result = base.VisitWhileExpr(context);
        FinishNesting();
        return result;
    }

    public override object? VisitDoWhileExpr(ScalaJilbeParser.DoWhileExprContext context)
    {
        // not so sure about this one, but there ARE branches, so:
        StartNesting();
        amntOfConditionals++;
        amntOfOperators++;
        var result = base.VisitDoWhileExpr(context);
        FinishNesting();
        return result;
    }


    public override object? VisitFor(ScalaJilbeParser.ForContext context)
    {
        // count amnt of generators (yikes help)
        generatorCounter = 0;
        return base.VisitFor(context);
    }

    public override object? VisitForRight(ScalaJilbeParser.ForRightContext context)
    {
        for (int i = 0; i < generatorCounter; i++)
        {
            StartNesting();
        }
        amntOfConditionals += generatorCounter;
        amntOfOperators += generatorCounter;
        // because of for situation:
        amntOfOperators += generatorCounter;
        fors += generatorCounter;
        
        var result = base.VisitForRight(context);
        for (int i = 0; i < generatorCounter; i++)
        {
            FinishNesting();
        }

        return result;
    }

    public override object? VisitGenerator(ScalaJilbeParser.GeneratorContext context)
    {
        generatorCounter++;
        return base.VisitGenerator(context);
    }


    
    
    public override object? VisitAssignOp(ScalaJilbeParser.AssignOpContext context)
    {
        amntOfOperators++;
        assigns++;
        return base.VisitAssignOp(context);
    }

    public override object? VisitOperationSum(ScalaJilbeParser.OperationSumContext context)
    {
        amntOfOperators++;
        sums++;
        return base.VisitOperationSum(context);
    }

    public override object? VisitOperationMul(ScalaJilbeParser.OperationMulContext context)
    {
        amntOfOperators++;
        muls++;
        return base.VisitOperationMul(context);
    }

    public override object? VisitOperationCmp(ScalaJilbeParser.OperationCmpContext context)
    {
        amntOfOperators++;
        cmps++;
        return base.VisitOperationCmp(context);
    }

    public override object? VisitOperationBit(ScalaJilbeParser.OperationBitContext context)
    {
        amntOfOperators++;
        bits++;
        return base.VisitOperationBit(context);
    }

    public override object? VisitOperationBool(ScalaJilbeParser.OperationBoolContext context)
    {
        amntOfOperators++;
        bools++;
        return base.VisitOperationBool(context);
    }

    public override object? VisitOperationSign(ScalaJilbeParser.OperationSignContext context)
    {
        // hmm?
        amntOfOperators++;
        signs++;
        return base.VisitOperationSign(context);
    }

    public override object? VisitBlockExpr(ScalaJilbeParser.BlockExprContext context)
    {
        amntOfOperators++;
        brackets++;
        return base.VisitBlockExpr(context);
    }
}