using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

// // Шаг 3
// string notePath = Path.Combine("data", "note.txt");
// Directory.CreateDirectory("data");

// File.WriteAllText(notePath, "Привет, файл!", Encoding.UTF8);

// string text = File.ReadAllText(notePath, Encoding.UTF8);
// Console.WriteLine(text);

// // Шаг 4
// string journalPath = Path.Combine("data", "journal.txt");

// File.WriteAllText(journalPath, "Первый запуск" + Environment.NewLine, Encoding.UTF8);
// File.AppendAllText(journalPath, "Второй запуск" + Environment.NewLine, Encoding.UTF8);

// Console.WriteLine(File.ReadAllText(journalPath, Encoding.UTF8));

// // Найдите ошибку
// string historyExamplePath = Path.Combine("data", "history-example.txt");

// File.WriteAllText(historyExamplePath, "Запись 1" + Environment.NewLine, Encoding.UTF8);
// File.AppendAllText(historyExamplePath, "Запись 2" + Environment.NewLine, Encoding.UTF8);

// Console.WriteLine(File.ReadAllText(historyExamplePath, Encoding.UTF8));

// // Шаг 5
// string linesPath = Path.Combine("data", "lines-example.txt");
// string[] sourceLines = { "80", "90", "70" };

// File.WriteAllLines(linesPath, sourceLines, Encoding.UTF8);
// string[] loadedLines = File.ReadAllLines(linesPath, Encoding.UTF8);

// Console.WriteLine($"Строк: {loadedLines.Length}");

// foreach (string line in loadedLines)
// {
//     Console.WriteLine(line);
// }

// List<int> ParseScores(string[] lines)
// {
//     List<int> scores = new List<int>();

//     foreach (string line in lines)
//     {
//         if (int.TryParse(line, out int score) && score >= 0 && score <= 100)
//         {
//             scores.Add(score);
//         }
//     }
//     return scores;
// }
// string[] testLines = { "80", "abc", "101", "90", "", "70", "2147483648" };
// List<int> parsedScores = ParseScores(testLines);

// Console.WriteLine($"Принято: {parsedScores.Count}");
// Console.WriteLine($"Пропущено: {testLines.Length - parsedScores.Count}");

// // Найти ошибку
// List<int> ParseScores(string[] lines)
// {
//     List<int> scores = new List<int>();
//     foreach (string line in lines)
//     {
//         if (int.TryParse(line, out int score) && score >= 0 && score <= 100)
//         {
//             scores.Add(score);
//         }
//     }
//     return scores;
// }

// Шаг 7
string missingPath = Path.Combine("data", "missing-example.txt");
try
{
    string missingText = File.ReadAllText(missingPath, Encoding.UTF8);
    Console.WriteLine(missingText);
}
catch (FileNotFoundException)
{
    Console.WriteLine("Файл не найден");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Нет доступа к файлу или папке");
}
catch (IOException)
{
    Console.WriteLine("Ошибка чтения или записи файла");
}
