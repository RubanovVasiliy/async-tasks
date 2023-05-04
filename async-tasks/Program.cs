

namespace async_tasks;

internal abstract class Program
{
    static async Task Main()
    {
        Console.WriteLine("Нажмите любую кнопку чтобы выйти \n");

        using var cts = new CancellationTokenSource();
        var tasks = new Task[5];

        for (var i = 0; i < tasks.Length; i++)
        {
            var threadNumber = i + 1;

            tasks[i] = Task.Run(async () =>
            {
                var counter = 0;
                try
                {
                    while (true)
                    {
                        counter++;
                        Console.WriteLine($"{threadNumber} - {counter}");

                        await Task.Delay(5000, cts.Token);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Task {threadNumber} stopped");
                }

            }, cts.Token);
        }

        Console.ReadKey(true);

        cts.Cancel();

        await Task.WhenAll(tasks);
    }
}