
async Task<int> method()
{
    return method2();
}

async void method1()
{
    var t = await method();
    Console.WriteLine(t+3);
}

Console.WriteLine(await method());

method1();

Console.WriteLine("Hello, World!");
Console.ReadLine();



async Task<int> method2()
{
    Thread.Sleep(1000);
    return 2;
}