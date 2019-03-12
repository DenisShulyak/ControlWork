using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControlWork
{
    class Program
    {
        static void Main(string[] args)
        {

            string act;
            while (true)
            {
                Console.WriteLine("1) Регистрация");
                Console.WriteLine("2) Вход");
                Console.WriteLine("3) Выход");
                Console.WriteLine("Введите действие: ");
                act = Console.ReadLine();
                if (act == "1")
                {
                    Console.Clear();
                    string email;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите Email: ");
                        email = Console.ReadLine();
                        if ((email.Contains("@gmail.") || email.Contains("@mail.") || email.Contains("@yandex.")) && !email.Contains(' '))
                        {
                            try
                            {
                                using (StreamReader stream = new StreamReader(email + ".txt"))
                                {
                                }
                                Console.WriteLine("Такой email уже существует");
                                Console.ReadLine();
                                continue;
                            }
                            catch
                            {
                                break;
                            }
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка, повторите попытку.");
                        }
                    }
                    string phone;
                    while (true)
                    {
                        Console.WriteLine("Введите номер телефона(Без кода страны +7): ");
                        phone = Console.ReadLine();
                        if (phone.Length == 10  && IsDigitsOnly(phone))
                        {
                            break;
                        }
                        else if (phone.Length > 10)
                        {
                            Console.Clear();

                            Console.WriteLine("Кол-во символов больше 10");
                        }
                        else if (phone.Length < 10)
                        {
                            Console.Clear();

                            Console.WriteLine("Кол-во символов меньше 10");
                        }
                    }
                    string fullName;
                    while (true)
                    {
                        Console.WriteLine("Введите Имя Фамилия через пробел: ");
                        fullName = Console.ReadLine();
                        int countSpace = 0;
                        for (int i = 0; i < fullName.Length; i++)
                        {
                            if (fullName[i] == ' ')
                            {
                                countSpace++;
                            }
                        }
                        if (fullName[0] != ' ' && fullName[fullName.Length - 1] != ' ' && countSpace == 1)
                        {
                          
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка, повторите попытку.");
                        }

                    }
                    int age;
                    while (true)
                    {
                        Console.WriteLine("Введите возраст: ");
                        age = int.Parse(Console.ReadLine());
                        if (age >= 12 && age < 100)
                        {
                            
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка, повторите попытку.");
                        }
                    }
                    string password;
                    while (true)
                    {
                        Console.WriteLine("Введите пароль(2-8): ");//$%^&*()_+"№;:?=-/\/|.`~
                        password = Console.ReadLine();
                        if (password.Length >= 2 && password.Length <= 8 && !password.Contains('@') && !password.Contains(' ') && !password.Contains('"') && !password.Contains('#') && !password.Contains('$') && !password.Contains('%') && !password.Contains('^') && !password.Contains('&') && !password.Contains('*') && !password.Contains('(') && !password.Contains(')') && !password.Contains('_') && !password.Contains('+') && !password.Contains('№') && !password.Contains(';') && !password.Contains(':') && !password.Contains('?') && !password.Contains('=') && !password.Contains('-') && !password.Contains('/') && !password.Contains('\'') && !password.Contains('|') && !password.Contains('.') && !password.Contains('`') && !password.Contains('~'))
                        {
                            using (StreamWriter stream =  File.AppendText(email + ".txt"))
                            {
                                stream.Write(email);
                                stream.Write(" " + "+7" + phone);
                                stream.Write(" " + fullName);
                                stream.Write(" " + age);
                                stream.Write(" " + password);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка, повторите попытку");
                        }

                    }
                    Console.Clear();
                }
                else if (act == "2")
                {
                    Console.Clear();
                    string login;
                    string password;
                        string fullName;
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Введите логин: ");
                         login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        password = Console.ReadLine();
                        try
                        {
                            using (StreamReader stream = new StreamReader(login + ".txt"))
                            {
                                string str = stream.ReadLine();
                                var data = str.Split(' ').ToList();
                                fullName = data[2] + " " + data[3];
                                if (password == data[5])
                                {
                                    break;
                                }
                                else {
                                    Console.WriteLine("Ошибка, неверный логин или пароль.Повторите попытку(Нажмите Enter).");
                                    Console.ReadLine();
                                }
                            }
                               

                        }
                        catch
                        {
                            Console.WriteLine("Ошибка, неверный логин или пароль.Повторите попытку(Нажмите Enter).");
                            Console.ReadLine();
                        }
                    }
                    Console.WriteLine("Добро пожаловать " + fullName + "!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (act == "3")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введено неверное действие");
                }
                //Console.Clear();

            }

           
        }
        static bool IsDigitsOnly(string str)
        {
            for(int i = 0; i < str.Length;i++)
            {

                if (str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5' && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9' && str[i] != '0')
                    return false;
            }
            return true;

        }
    }
}
