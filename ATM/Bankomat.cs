using FastExpressionCompiler.LightExpression;
using ImTools;
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
                   Path_Database_Score = @"D:\ATM\Database_Score.txt",
                   Path_Database_Client_Info = @"D:\ATM\Database_Client_Info.txt";

            int Tank = -1,
                Tank_Array = 0;
            int sum = 0;

            int Number_Client = 5;

            FileInfo Database_Pin_Code = new FileInfo(Path_Database_Pin_Code);
            FileInfo Database_Pin_Name = new FileInfo(Path_Database_Name);
            FileInfo Database_Score = new FileInfo(Path_Database_Score);
            FileInfo Database_Client_Info = new FileInfo(Path_Database_Client_Info);

            string[] Array_Pin_Code = new string[100];
            string[] Array_Name = new string[100];
            string[] Array_Score = new string[100];
            string[] Array_Client_Info = new string[100];

            Array_Pin_Code = File.ReadAllLines(Path_Database_Pin_Code);
            Array_Name = File.ReadAllLines(Path_Database_Name);
            Array_Score = File.ReadAllLines(Path_Database_Score);
            Array_Client_Info = File.ReadAllLines(Path_Database_Client_Info);


            


            void Menu()
            {
                Console.WriteLine("Здравствуйте!");
                Console.WriteLine("1 - Число клиентов, 2 - Список клиентов,  3 - информация о клиенте ");

                int Act;

                Act = Convert.ToInt32(Console.ReadLine());

                switch (Act)
                {
                    case 1:
                        Console.WriteLine(Number_Client);
                        break;
                    case 2:
                        foreach (string search in Array_Name)
                        {
                            Console.WriteLine(search);
                        }
                        break;
                    case 3:
                        Info();
                        break;
                    case 4:
                        
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
                Console.WriteLine($"Вы сняли {sum} рублей\nВаш баланс {Array_Score[Tank]} рублей") ;
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
         
            void Info()
            {
                foreach (string search in Array_Name)
                {
                    Console.WriteLine(search);
                }

                Tank = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i <= 2; i++)
                    Console.WriteLine(Array_Client_Info[Tank] + i); 
            }
            void Number()
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