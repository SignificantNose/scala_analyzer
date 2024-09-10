using Antlr_Scala;
using Antlr4.Runtime;
using ScalaParse.Generated;

namespace ScalaAnalyzer;

public class Analyzer
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
    
    public void AnalyzeCode(string scalaCode)
    {
        var inputStream = new AntlrInputStream(scalaCode);
        var lexer = new ScalaLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new ScalaParser(tokenStream);
  
        var visitor = new ScalaVisitor();
        var query = parser.compilationUnit();
        visitor.Visit(query);

        _operands = visitor.Operands;
        _operations = visitor.Operations;
    }
}