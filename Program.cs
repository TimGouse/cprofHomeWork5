using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace cprofHomeWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = F.Get();
            var serializer = new Serializer();

            // Замер времени функции сериализации
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            string serializedString = serializer.SerializeToCsv(obj);

            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Сериализованная строка: {serializedString}");
            Console.WriteLine($"Время на сериализацию: {elapsed} мс");

            // Замер времени JSON сериализации
            var stopwatchJson = new Stopwatch();
            stopwatchJson.Start();

            string jsonString = JsonConvert.SerializeObject(obj);

            stopwatchJson.Stop();
            var elapsedJson = stopwatchJson.ElapsedMilliseconds;

            Console.WriteLine($"Сериализованная JSON строка: {jsonString}");
            Console.WriteLine($"Время на JSON сериализацию: {elapsedJson} мс");

            // Замер времени функции десериализации
            var stopwatchDeserialization = new Stopwatch();
            stopwatchDeserialization.Start();

            var deserializedObj = serializer.DeserializeFromCsv<F>(serializedString);

            stopwatchDeserialization.Stop();
            var elapsedDeserialization = stopwatchDeserialization.ElapsedMilliseconds;

            Console.WriteLine($"Время на десериализацию: {elapsedDeserialization} мс");

            // Замер времени JSON десериализации
            var stopwatchJsonDeserialization = new Stopwatch();
            stopwatchJsonDeserialization.Start();

            F deserializedJsonObj = JsonConvert.DeserializeObject<F>(jsonString);

            stopwatchJsonDeserialization.Stop();
            var elapsedJsonDeserialization = stopwatchJsonDeserialization.ElapsedMilliseconds;

            Console.WriteLine($"Время на JSON десериализацию: {elapsedJsonDeserialization} мс");
        }
    }
}
