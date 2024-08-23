using System;
using System.Collections.Generic;
using System.Linq;

public class DataRow
{
    public string ProductionStep { get; set; }
    public string MeasureName { get; set; }
    public double? Value { get; set; }
}

class Program
{
    static void Main()
    {
        var data = ReadData();
        var productionData = new Dictionary<string, Dictionary<string, (List<double> values, int errorCount)>>();

        foreach (DataRow row in data)
        {
            if (!productionData.ContainsKey(row.ProductionStep))
            {
                productionData[row.ProductionStep] = new Dictionary<string, (List<double>, int)>();
            }

            if (!productionData[row.ProductionStep].ContainsKey(row.MeasureName))
            {
                productionData[row.ProductionStep][row.MeasureName] = (new List<double>(), 0);
            }

            var currentData = productionData[row.ProductionStep][row.MeasureName];

            if (row.Value.HasValue)
            {
                currentData.values.Add(row.Value.Value);
            }
            else
            {
                currentData.errorCount++;
            }

            // Reassign the updated tuple back into the dictionary
            productionData[row.ProductionStep][row.MeasureName] = currentData;
        }

        // Calculate averages and prepare output data
        var outputData = new Dictionary<string, Dictionary<string, (double avg, int errorCount)>>();
        foreach (var step in productionData)
        {
            outputData[step.Key] = new Dictionary<string, (double, int)>();
            foreach (var measure in step.Value)
            {
                double avg = measure.Value.values.Any() ? measure.Value.values.Average() : 0.0;
                outputData[step.Key][measure.Key] = (avg, measure.Value.errorCount);
            }
        }

        // Sort columns by error count and print the results
        var sortedMeasures = outputData.SelectMany(x => x.Value)
                                       .GroupBy(x => x.Key)
                                       .OrderByDescending(g => g.Sum(x => x.Value.errorCount))
                                       .Select(g => g.Key)
                                       .ToList();

        Console.WriteLine("Production Step\t" + string.Join("\t", sortedMeasures.Select(m => $"{m} Avg\t{m} Errors")));

        foreach (var step in outputData)
        {
            Console.Write(step.Key);
            foreach (var measure in sortedMeasures)
            {
                if (step.Value.ContainsKey(measure))
                {
                    Console.Write($"\t{step.Value[measure].avg:F1}\t{step.Value[measure].errorCount}");
                }
                else
                {
                    Console.Write("\t0.0\t0");
                }
            }
            Console.WriteLine();
        }
    }

    static List<DataRow> ReadData()
    {
        // This method would be implemented to read actual data. For now, return a sample list.
        return new List<DataRow>
        {
            new DataRow { ProductionStep = "Assembly", MeasureName = "Temp", Value = 43 },
            new DataRow { ProductionStep = "Assembly", MeasureName = "Humidity", Value = 65 },
            new DataRow { ProductionStep = "Soldering", MeasureName = "Temp", Value = 48 },
            new DataRow { ProductionStep = "Soldering", MeasureName = "S.Temp", Value = 97.4 },
            new DataRow { ProductionStep = "Soldering", MeasureName = "Humidity", Value = null },
            new DataRow { ProductionStep = "Assembly", MeasureName = "Temp", Value = 41 },
            new DataRow { ProductionStep = "Assembly", MeasureName = "Duration", Value = 23 }
        };
    }
}
