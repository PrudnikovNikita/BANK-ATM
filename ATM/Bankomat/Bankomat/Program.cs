using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {

            string Pin_Code, Name;
            string Path_Database_Pin_Code = @"D:\ATM\Database_Pin_Code.txt",
                   Path_Database_Name = @"D:\ATM\Database_Name.txt",
                   Path_Database_Score = @"D:\ATM\Database_Score.txt";

            int Tank_Array = 0;
            int sum = 0,Tank;

            FileInfo Database_Pin_Code = new FileInfo(Path_Database_Pin_Code);
            FileInfo Database_Pin_Name = new FileInfo(Path_Database_Name);
            FileInfo Database_Score = new FileInfo(Path_Database_Score);

            string[] Array_Pin_Code = new string[100];
            string[] Array_Name = new string[100];
            string[] Array_Score = new string[100];

            Array_Pin_Code = File.ReadAllLines(Path_Database_Pin_Code);
            Array_Name = File.ReadAllLines(Path_Database_Name);
            Array_Score = File.ReadAllLines(Path_Database_Score);

           void menu()
            {
                Tank = -1;
                Console.WriteLine("Введите ПИН-КОД");
                Pin_Code = Console.ReadLine();
                foreach (string search in Array_Pin_Code)
                {
                    Tank++;
                    if (Pin_Code == search)
                    {
                       
                        Menu();
                    }
                }
            }
            menu();
            void Menu()
            {
                Console.WriteLine($"Здравствуйте {Array_Name[Tank]}!");
                Console.WriteLine("1 - Пополнить счёт, 2 - Снять наличные,3 - Узнать баланс, 4 - Выйти");

                int Act;

                Act = Convert.ToInt32(Console.ReadLine());

                switch (Act)
                {
                    case 1:
                        Full();
                        break;
                    case 2:
                        Cash();
                        break;
                    case 3:
                        Score();
                        break;
                    case 4:
                        menu();
                        break;
                }

            }
            void Cash()
            {
                Console.WriteLine("Какую сумму Вы хотите снять?");

                sum = Convert.ToInt32(Console.ReadLine());
                Tank_Array = Convert.ToInt32(Array_Score[Tank]);
                Tank_Array = Tank_Array - sum;
                Array_Score[Tank] = Convert.ToString(Tank_Array);
                Console.WriteLine($"Вы сняли {sum} рублей\nВаш баланс {Array_Score[Tank]} рублей");
                using (var stream = new FileStream(Path_Database_Score, FileMode.Truncate))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("");
                    }
                }
                foreach (string search in Array_Score)
                {
                    File.AppendAllText(Path_Database_Score, search);
                    File.AppendAllText(Path_Database_Score, Environment.NewLine);
                }
                sum = 0;
                Menu();
            }

            void Score()
            {
                Console.WriteLine(Array_Score[Tank]);
                Menu();
            }
            void Full()
            {
                Console.WriteLine("Какую сумму Вы хотите положить?");
                sum = Convert.ToInt32(Console.ReadLine());
                Tank_Array = Convert.ToInt32(Array_Score[Tank]);
                Tank_Array = Tank_Array + sum;
                Array_Score[Tank] = Convert.ToString(Tank_Array);
                Console.WriteLine($"Вы сняли положили на счёт {sum} рублей\nВаш баланс {Array_Score[Tank]} рублей");
                using (var stream = new FileStream(Path_Database_Score, FileMode.Truncate))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write("");
                    }
                }
                foreach (string search in Array_Score)
                {
                    File.AppendAllText(Path_Database_Score, search);
                    File.AppendAllText(Path_Database_Score, Environment.NewLine);
                }
                Menu();
            }
        }
    }
}