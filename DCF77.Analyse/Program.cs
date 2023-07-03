// See https://aka.ms/new-console-template for more information
using DCF77.Analyse;

Console.WriteLine("Hello, World!");

while (true)
{
DCF77Analyse analyse = new DCF77Analyse();

Console.WriteLine("Input:");
analyse.PrintData(Console.ReadLine());

}