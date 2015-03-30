using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * 3. Используя 3 текстовых файла из 2 лб, считать из них данные в отдельные потоки,
 * после чего все числа выше задаваемого пользователем записать в 1 файл,
 * ниже – во 2 файл, а слова без повторений – в 3-й файл.
 * Запись проводить прямо в процессе работы со всеми потоками.
 */
namespace Lab_5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
