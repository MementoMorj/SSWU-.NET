using Electricity;
using StreamReader reader = new StreamReader(@"Base.txt");
AccountFlats account = new AccountFlats(reader);
//запис таблиці в файл
using StreamWriter writer = new StreamWriter(@"Report.txt");
writer.WriteLine(account.CreateTable());
writer.WriteLine(account.FlatIdWithoutEnergy());
writer.WriteLine(account.ReportForOneFlat(15));
writer.WriteLine(account.IdOfTheBiggestDebt());

//вивід таблиці в консоль
Console.WriteLine(account.CreateTable());
