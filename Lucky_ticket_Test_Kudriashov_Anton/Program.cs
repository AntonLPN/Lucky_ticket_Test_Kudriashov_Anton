using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lucky_ticket_Test_Kudriashov_Anton
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;

            do
            {
                //int enteredNumber = 0;//введенное пользователем число
                int sumFirstHalfTicket = 0;//сумма перввой половины билета
                int sumSecondtHalfTicket = 0;//сумма второй половины билета

                string enteredNumber = string.Empty;

                //instruction information----------------
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("Instruction :");
                Console.WriteLine("The maximum size of the entered numbers must be no more than 8 numbers ");
                Console.WriteLine("The number must be an integer for example 3344");
                Console.WriteLine("--------------------------------------------------------------------------");
                //---------------------------------------------



                //цикл работает до тех пор пока не будет введенно правильное значение.Хотя бы одна цифра больше нуля
                int num = 0;
                do
                {
                  
                    Console.Write("Enter your ticket numbers >>");
                    //проверка на коректность ввода данных
                    try
                    {
                        // Int32.TryParse(Console.ReadLine(), out enteredNumber);
                        enteredNumber = Console.ReadLine();

                         num = Int32.Parse(enteredNumber);


                        //если пользоваетль случайно ввел вместе с числом букву или ввел в формате с плавающей точкой или больше 8 значного числа делаем исключение
                        if (num == 0 || num > 99999999)
                        {
                            throw new Exception("Error: You entered an incorrect number");
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("*****************************************");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("*****************************************");
                    }


                } while (num==0);

              
                Console.WriteLine();

                //разбиваем число на отдельные цифры для этого конвертирую число в string 
                //используем LINQ
                //Забрасываем числа в List
                List<int> ListTiketNumber = enteredNumber.ToCharArray().Select(x => Convert.ToInt32(x.ToString())).ToList<int>();
              
                //добавляем нули в начало билета (при необходимости) для этого используем рекурсивный метод
                ListTiketNumber = CountZeroAddRecursion(ListTiketNumber.Count, ListTiketNumber);


                //агрегируем в строку значения листа для выведенния информации в консоль значениях билета которые ввел пользователь
                string resStr = ListTiketNumber.Aggregate(new StringBuilder(), (accum, elem) => accum.Append($"{elem}|"), strBulderAcc => strBulderAcc.ToString());
                Console.WriteLine($"You have entered the following ticket numbers {resStr}");


                //сумма первой половины белета
                for (int i = 0; i < ListTiketNumber.Count / 2; i++)
                {
                    sumFirstHalfTicket += ListTiketNumber[i];
                }

                //сумма второй половины билета
                for (int i = ListTiketNumber.Count / 2; i < ListTiketNumber.Count; i++)
                {
                    sumSecondtHalfTicket += ListTiketNumber[i];
                }


                if (sumFirstHalfTicket == sumSecondtHalfTicket)
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine("Your ticket is lucky");
                    Console.WriteLine("**********************************");
                }
                else
                {
                    Console.WriteLine("**********************************");
                    Console.WriteLine("Sorry your ticket is not lucky");
                    Console.WriteLine("**********************************");
                }

              
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("Enter 1 to try agan ");
                    Console.WriteLine("Enter 0 for the EXIT ");
                    int.TryParse(Console.ReadLine(), out menu);
              
            } while (menu!=0);

            Console.Clear();
            Console.WriteLine("Press any key");
            Console.ReadLine();

        }
        /// <summary>
        /// Рекурсивный метод добавляет нули в начало листа если  размер List меньше 4 или 6 или 8
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static List<int> CountZeroAddRecursion(int number, List<int> list)
        {


            if (number == 4 || number == 6 || number == 8)
            {
                return list;
            }
            else
            {
                //добавляем в начало нули
                list.Insert(0, 0);
                return CountZeroAddRecursion(number + 1, list); ;
            }

        }
    }
}
