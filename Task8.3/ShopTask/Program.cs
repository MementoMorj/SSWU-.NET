
using ShopTask;
var storage1 = new Storage(
    new Product("moloko", 11, 12),
    new Product("kava", 13, 24));
var storage2 = new Storage(
    new Product("moloko", 11, 12),
    new Product("aefesf", 23445, 245),
    new Product("sgsrgd", 243, 3534));

foreach (var product in Storage.StorageExcept(storage1, storage2))
{
    Console.WriteLine(product);
}

foreach (var product in Storage.StorageIntersect(storage1, storage2))
{
    Console.WriteLine(product);
}

foreach (var product in Storage.StorageUnion(storage1, storage2))
{
    Console.WriteLine(product);
}