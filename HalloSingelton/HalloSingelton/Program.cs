using HalloSingelton;

Console.WriteLine("Hello Singelton");

Parallel.For(0, 10, i => Logger.Instance.Info($"Hallo Logger {i}"));

//for (int i = 0; i < 10000; i++)
//{
//    Task.Run(() => Logger.Instance.Info($"Hallo Logger {i}"));
//}


Console.WriteLine("Ende");
Console.ReadLine();
