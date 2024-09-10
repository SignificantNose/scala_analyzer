
using ScalaAnalyzer;

var scalaCode = File.ReadAllText("D:\\wtfishappening\\antlr_rider\\Antlr_Scala\\ScalaAnalyzer\\ScalaCode.txt");
var analyzer = new Analyzer();
analyzer.AnalyzeCode(scalaCode);
Console.WriteLine("Operations: ");
analyzer.Operations.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);

Console.WriteLine();
Console.WriteLine("Operands: ");
analyzer.Operands.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
