using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//Клас відстеження помилок, який повинна існувати в єдиному екземплярі. Реалізовувати методи:
//1) Фіксування помилки(Час, код, текст з описом помилки)
//2) Очищення історії помилок.
//3) Вивід інформації про всі помилки
//4) Збереження історії помилок до файлу.
namespace C_.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var errors = ErrorHandler.Instance;
            errors.errorLog("someCode", "404Error");
            errors.errorLog("cod2", "Error");
            errors.showDataErrors();
            errors.errortoFile();
        }
    }
    public class ErrorHandler
    {
        private static ErrorHandler _instance;
        private List<string> _errorLoglist = new List<string>();

        public ErrorHandler() { }

        public static ErrorHandler
        Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ErrorHandler();
                }
                return _instance;

            }
        }
        public void errorLog(string data, string errormessage)
        {
            string error = $"Data/Time: {DateTime.Now},Code: {data}, Error: {errormessage}";
            _errorLoglist.Add(error);
        }
        public void clearErrorData()
        {
            _errorLoglist.Clear();
        }
        public void showDataErrors()
        {
            foreach (string error in _errorLoglist)
            {
                Console.WriteLine(error);
            }
        }
        public void errortoFile()
        {
            for (int i = 0; i < _errorLoglist.Count; i++)
            {
                _errorLoglist[i].ToString();
            }
            File.WriteAllLines("errors.txt", _errorLoglist);
            Console.WriteLine("Error list has been written to file:'errors.txt'");
        }
    }
}

