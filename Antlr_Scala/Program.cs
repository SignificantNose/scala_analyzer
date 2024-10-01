//
// using ScalaAnalyzer;
//
// var scalaCode = File.ReadAllText("D:\\wtfishappening\\antlr_rider\\Antlr_Scala\\ScalaAnalyzer\\ScalaCode.txt");
// var analyzer = new Analyzer();
// analyzer.AnalyzeCode(scalaCode);
// Console.WriteLine("Operations: ");
// analyzer.Operations.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
//
// Console.WriteLine();
// Console.WriteLine("Operands: ");
// analyzer.Operands.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
//


using JilbeAnalyzer;

var scalaCode = File.ReadAllText("D:\\4st sem\\IT\\IT4\\scala_analyzer\\JilbeAnalyzer\\ScalaCodeJilbe.txt");
var analyzer = new Analyzer();
analyzer.AnalyzeCode(scalaCode);
Console.WriteLine("amount of operators: "+analyzer.AmntOfOperators);
Console.WriteLine("amount of conditionals: "+analyzer.AmntOfConditionals);
Console.WriteLine("max nesting level: "+analyzer.MaxNestingLevel);