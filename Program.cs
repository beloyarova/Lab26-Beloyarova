using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

string dataDirectory = "data";
string inputPath = Path.Combine(dataDirectory, "scores.txt");
string reportPath = Path.Combine(dataDirectory, "report.txt");
string historyPath = Path.Combine(dataDirectory, "history.txt");

try
{
    Directory.CreateDirectory(dataDirectory);
    Console.WriteLine($"Входной файл: {Path.GetFullPath(inputPath)}");
    if (!File.Exists(inputPath))
    {
        Console.WriteLine("Входной файл не найден или недоступен");
        return;
    }
    string[] lines = File.ReadAllLines(inputPath, Encoding.UTF8);
    List<int> scores = ParseScores(lines);
    int skipped = lines.Length - scores.Count;
    List<string> report = BuildReport(scores, skipped);
    File.WriteAllLines(reportPath, report, Encoding.UTF8);
    string historyEntry = $"Сохранено: {scores.Count}; пропущено: {skipped}; сумма: {SumScores(scores)}";
    File.AppendAllText(historyPath, historyEntry + Environment.NewLine, Encoding.UTF8);
    string valid = Path.Combine(dataDirectory, "valid-scores.txt");
    SaveValidScores(valid, scores);
    Console.WriteLine(">>> Отчёт по файлу <<<");
    foreach (string line in report)
    {
        Console.WriteLine(line);
    }
    Console.WriteLine($"Отчёт сохранён: {Path.GetFullPath(reportPath)}");
    Console.WriteLine($"История дополнена: {Path.GetFullPath(historyPath)}");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Файл для чтения не найден");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Нет доступа к файлу или папке");
}
catch (IOException)
{
    Console.WriteLine("Ошибка чтения или записи файла");
}


List<int> ParseScores(string[] lines)
{
    List<int> scores = new List<int>();

    foreach (string line in lines)
    {
        if (int.TryParse(line, out int score) && score >= 0 && score <= 100)
        {
            scores.Add(score);
        }
    }
    return scores;
}

int SumScores(List<int> scores)
{
    int total = 0;
    for (int i = 0; i < scores.Count; i++)
    {
        total += scores[i];
    }
    return total;
}

List<string> BuildReport(List<int> scores, int skipped)
{
    List<string> a = new List<string>();

    a.Add($"Сохранено результатов: {scores.Count}");
    a.Add($"Пропущено строк: {skipped}");
    a.Add($"Сумма: {SumScores(scores)}");

    if (scores.Count == 0)
    {
        a.Add("Среднее не вычисляется: список пуст");
        a.Add("Результаты:");
        a.Add("Список пуст");
    }
    else
    {
        double average = (double)SumScores(scores) / scores.Count;
        a.Add($"Среднее: {average}");
        a.Add("Результаты:");
        for (int i = 0; i < scores.Count; i++)
        {
            a.Add($"{scores[i]}");
        }
    }
    return a;
}

// Самостоятельное задание 1
void SaveValidScores(string path, List<int> scores)
{
    List<string> valid = new List<string>();
    for (int i = 0; i < scores.Count; i++)
    {
        valid.Add($"{scores[i]}");
    }
    File.WriteAllLines(path, valid, Encoding.UTF8);
}