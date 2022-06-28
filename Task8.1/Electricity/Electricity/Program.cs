using Electricity;
using StreamReader reader1 = new StreamReader(@"Base1.txt");
using StreamReader reader2 = new StreamReader(@"Base2.txt");
AccountFlats account1 = new AccountFlats(reader1);
AccountFlats account2 = new AccountFlats(reader2);
//запис таблиці в файл
using StreamWriter writer = new StreamWriter(@"Report.txt");
writer.WriteLine(account1.CreateTable());
writer.WriteLine(account1.FlatIdWithoutEnergy());
writer.WriteLine(account1.ReportForOneFlat(15));
writer.WriteLine(account1.IdOfTheBiggestDebt());

//вивід таблиці в консоль
Console.WriteLine(account1.CreateTable());
Console.WriteLine(account2.CreateTable());

AccountFlats account3 = account1 + account2;
Console.WriteLine(account3.CreateTable());
AccountFlats account4 = account1 - account2;
Console.WriteLine(account4.CreateTable());