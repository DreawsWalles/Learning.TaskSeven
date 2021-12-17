using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class Menu
    {
        private List<string> list;
        public int Count { get { return list.Count; } private set { } }
        private bool haveEnd;
        private string themeMenu;
        private string[] Commands;
        
        public Menu(string theme, string[] com = null)
        {
            list = new List<string>();
            haveEnd = false;
            themeMenu = theme;
            Commands = com;
        } 
        public void ChangeTheme(string  newTheme)
        {
            themeMenu = newTheme;
        }
        public void Add(string s, bool isEnd = false)
        {
            if (haveEnd && isEnd)
                throw new Exception("Пункт меню для возврата уже добавлен");
            if (!isEnd)
                list.Add(s);
            else
            {
                list.Insert(0, s);
                haveEnd = isEnd;
            }
        }
        public void Delete(int index)
        {
            if (index >= list.Count)
                throw new Exception("Введен некорректный индекс");
            list.RemoveAt(index);
        }
        public void DeleteFirst()
        {
            Delete(1);
        }
        public void DeleteLast()
        {
            list.RemoveAt(list.Count - 1);
        }
        public void DeleteExit()
        {
            list.RemoveAt(0);
            haveEnd = false;
        }
        public void Print()
        {
            if (list.Count == 0)
                throw new Exception("В меню нет ни одного пункта");
            Console.WriteLine(themeMenu);
            if (haveEnd)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    Console.Write(i);
                    Console.Write(". ");
                    Console.WriteLine(list[i]);
                }
                Console.Write("<-- 0. ");
                Console.WriteLine(list[0]);
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(i);
                    Console.Write(". ");
                    Console.WriteLine(list[i]);
                }
            }
            Console.Write("-> ");
        }
        private void Pause()
        {
            Console.WriteLine("Для продолжения нажмите клавишу Enter...");
            Console.ReadLine();
        }
        public int Choice()
        {
            int result;
            string s;
            do
            {
                s = Console.ReadLine();
                if ((result = CheckChoice(s, 0, list.Count - 1)) == -1)
                {
                    Pause();
                    Console.Clear();
                    Print();
                }    
            } while (result == -1);
            return result;
        }
        public int Choice(out string commnad)
        {
            int result;
            string s;
            do
            {
                s = Console.ReadLine();
                if (Commands != null && Commands.Contains(s))
                {
                    commnad = s;
                    return -1;
                }
                if ((result = CheckChoice(s, 0, list.Count - 1)) == -1)
                {
                    Pause();
                    Console.Clear();
                    Print();
                }
            } while (result == -1);
            commnad = null;
            return result;
        }

        private int CheckChoice(string s, int borderBeg, int borderEnd)
        {
            int num;
            if (s.Length == 0)
            {
                Console.WriteLine("Считана пустая строка. Повторите ввод");
                return -1;
            }
            else
            {
                num = 0;
                int len = s.Length;
                int i = 0;
                int n;
                while (i < len)
                    if (char.IsDigit(s[i]))
                    {
                        n = s[i] - '0';
                        num = num * 10 + n;
                        i++;
                    }
                    else
                    {
                        Console.Write("Считан некорректный символ: ");
                        Console.Write(s[i]);
                        Console.WriteLine(" . Повторите ввод");
                        return -1;
                    }
                if ((num < borderBeg) || (num > borderEnd))
                {
                    Console.Write("Считанное значение некорректно. Значение должно быть в диапазоне от ");
                    Console.Write(borderBeg);
                    Console.Write(" до ");
                    Console.WriteLine(borderEnd);
                    return -1;
                }
                return num;
            }
        }
    }
}
