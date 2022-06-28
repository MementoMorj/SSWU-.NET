using Statistics;
using StreamReader reader = new StreamReader(@"Base.txt");
Stats stats=new Stats(reader);
Console.WriteLine(stats.StatisticInfo());

using StreamWriter writer = new StreamWriter(@"Report.txt");
writer.WriteLine(stats.StatisticInfo());