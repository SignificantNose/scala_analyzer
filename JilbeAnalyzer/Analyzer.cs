using Antlr4.Runtime;
using ScalaJilbe.Generated;

namespace JilbeAnalyzer;

public class Analyzer
{
    private int _amntOfOperators = 0;
    private int _amntOfConditionals = 0;
    private int _maxNestingLevel = 0;
    
    public int AmntOfOperators => _amntOfOperators;
    public int AmntOfConditionals => _amntOfConditionals;
    public int MaxNestingLevel => _maxNestingLevel;
    
    public void AnalyzeCode(string scalaCode)
    {
        var inputStream = new AntlrInputStream(scalaCode);
        var lexer = new ScalaJilbeLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new ScalaJilbeParser(tokenStream);
  
        var visitor = new JilbeVisitor();
        var query = parser.compilationUnit();
        visitor.Visit(query);

        _amntOfOperators = visitor.amntOfOperators;
        _amntOfConditionals = visitor.amntOfConditionals;
        _maxNestingLevel = visitor.maxNestingLevel;
    }
}