using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_02._03
{
    class Program
    {
        public class Writer
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
            public string Text { get; set; }
            public string Theme { get; set; }
            public Writer() { }
            public Writer(string titelPoem, string author, int year, string text, string theme)
            {
                Title = titelPoem;
                Author = author;
                Year = year;
                Text = text;
                Theme = theme;
            }
            public override string ToString() { return $"Название стиха: {Title}\nФИО автора: {Author}\nГод написания: {Year}\nТекст стиха: {Text}\nТема стиха: {Theme}"; }
        }
        class ListWriters
        {
            List<Writer> writers;
            public ListWriters() => writers = new List<Writer>();
            public void Add(Writer poem) => writers.Add(poem);
            public void Remove(Writer poem) => writers.Remove(poem);
            public void ChangeTitel(Writer poem, string titel) => poem.Title = titel;
            public void ChangeAuthor(Writer poem, string author) => poem.Author = author;
            public void ChangeYearWriting(Writer poem, int yearWriting) => poem.Year = yearWriting;
            public void ChangeTextPoem(Writer poem, string textPoem) => poem.Text = textPoem;
            public void ChangeThemePoem(Writer poem, string themePoem) => poem.Theme = themePoem;
            public List<Writer> FindTitel(string titelPoem) { return writers.Where(p => p.Title == titelPoem).ToList(); }
            public List<Writer> FindAuthor(string author) { return writers.Where(p => p.Author == author).ToList(); }
            public List<Writer> FindByTextPoem(string textPoem) { return writers.Where(p => p.Text == textPoem).ToList(); }
            public List<Writer> FindByThemePoem(string themePoem) { return writers.Where(p => p.Theme == themePoem).ToList(); }
            public List<Writer> FindByYearWriting(int yearWriting) { return writers.Where(p => p.Year == yearWriting).ToList(); }
            public void Save(string fileName)
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (Writer i in writers)
                        sw.WriteLine($"{i.ToString()}\n");
                }
            }
            public void File(string fileName)
            {
                List<Writer> writers = new List<Writer>();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string headerLine = sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] part = line.Split(',');
                        string title = part[0];
                        string author = part[1];
                        int year = int.Parse(part[2]);
                        string text = part[3];
                        string theme = part[3];
                        writers.Add(new Writer()
                        {
                            Title = title,
                            Author = author,
                            Year = year,
                            Text = text,
                            Theme = theme
                        });
                    }
                }
            }
            public void ReportTitel(string titelPoem, string fileName = null)
            {
                List<Writer> result = FindTitel(titelPoem);

                StringBuilder report = new StringBuilder();
                report.AppendLine($"Отчет по стихам с названием '{titelPoem}':");
                report.AppendLine($"{"Название стиха",-30}{"Автор",-20}{"Год",-10}{"Тема",-20}");
                foreach (Writer poem in result)
                    report.AppendLine($"{poem.Title,-30}{poem.Author,-20}{poem.Year,-10}{poem.Theme,-20}");
                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName)) { sw.Write(report); }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                    Console.WriteLine(report);
            }
            public void GenerateReportByAuthor(string author, string fileName = null)
            {
                List<Writer> result = FindAuthor(author);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Отчет {author}:");
                sb.AppendLine($"{"Название стиха",-30}{"Автор стиха",-20}{"Год стиха",-10}{"Тема стиха",-20}");
                foreach (Writer poem in result)
                    sb.AppendLine($"{poem.Title,-30}{poem.Author,-20}{poem.Year,-10}{poem.Theme,-20}");
                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName)) { sw.Write(sb); }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                    Console.WriteLine(sb);
            }
            public void GenerateReportByThemePoem(string themePoem, string fileName = null)
            {
                List<Writer> result = FindByThemePoem(themePoem);
                StringBuilder report = new StringBuilder();
                report.AppendLine($"Отчет по стихам на тему '{themePoem}':");
                report.AppendLine($"{"Название стиха",-30}{"Автор",-20}{"Год",-10}{"Тема",-20}");
                foreach (Writer poem in result)
                    report.AppendLine($"{poem.Title,-30}{poem.Author,-20}{poem.Year,-10}{poem.Theme,-20}");
                if (fileName != null)
                {
                    using (StreamWriter sw = new StreamWriter(fileName)) { sw.Write(report); }
                    Console.WriteLine($"Отчет сохранен в файл {fileName}");
                }
                else
                    Console.WriteLine(report);
            }
            public List<Writer> FindByWord(string word) { return writers.Where(p => p.Text.ToLower().Contains(word.ToLower())).ToList(); }
            public List<Writer> FindByYear(int year) { return writers.Where(p => p.Year == year).ToList(); }
            public List<Writer> FindByLength(int length) { return writers.Where(p => p.Text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length == length).ToList(); }
        }
        static void Main(string[] args)
        {
        }
    }
}
