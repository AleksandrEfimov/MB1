using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB1
{
    class Program
    {
        
        struct Card 
        {
            public Card(string start, string stop)
            {
                Start = start;
                Stop = stop;
            }
            public string Start;
            public string Stop;

            
        }


        static void Main(string[] args)
        {
            

           // Инициализация массива карточек
            ArrayList ArrCard = new ArrayList(); 
            ArrCard.Add(new Card("Москва", "Ярославль"));
            ArrCard.Add(new Card("Ярославль", "Архангельск"));
            ArrCard.Add(new Card("Архангельск", "Питер"));
            ArrCard.Add(new Card("Орел", "Москва"));
            ArrCard.Add(new Card("Берлин", "Москва"));

            int Count = ArrCard.Count;
            string StartPoint;

            // Проверим набор на сходимость ( Одно начало, один конец) 
            if (TestArrCard(ref ArrCard))
            {

                // индекс карты начала маршрута в массиве 
                int start = FindStart(ref ArrCard, ref Count, out StartPoint);
                Console.WriteLine("Позиция карты с началом маршрута: " + (start + 1));
                Console.WriteLine("Начало маршрута в точке:  " + StartPoint);

                // Сортировка и вывод отсортированного массива

                ArrCard = Sort(ref ArrCard, ref Count, start);
                Console.WriteLine("Отправление: \t  Назначение: \n");
                foreach (Card card in ArrCard)
                    Console.WriteLine(" - " + card.Start + " \t-->  " + card.Stop);

                // Завершение программы
                Console.ReadKey();

                List<Card> ArStrongCard = new List<Card>();

                ArStrongCard.Add(new Card("lkj", "lkj"));
                ArStrongCard.Add(new Card("lkj", "lkj"));


                //ArStrongCard[0].Start = "zxc";
                //ArStrongCard[1].Start = "zsdfc";
                //Console.WriteLine("ArStronCard"+ArStrongCard[0].Start);
            }

        }



        static bool TestArrCard(ref ArrayList ArrCard)
        {
            // Перед сортировкой требуется проверить:
            //  - в наличии одно начало и один конец 
            // составим словарь пунктов отправлений
            var dict = new Dictionary<string, int>();
            

            #region Набираем словарь 
            
            foreach (Card card in ArrCard)
            {
                // считаем/добавляем ключи по списку Start
                if (dict.ContainsKey(card.Start))
                {
                            dict[card.Start] += 1;
                            
                }
                    else
                    {         
                                dict.Add(card.Start, 1);
                    }
                // считаем/добавляем ключи по списку Stop
                if (dict.ContainsKey(card.Stop))
                {          
                        dict[card.Stop] += 1;
                }
                    else
                    {
                            dict.Add(card.Stop, 1);
                    }
            }


            #endregion
           
            // Проверка 
            int max = dict.Max(d => d.Value);
            // Проверка списка на единственность точек Start и Stop
            var FindStartStopPoint = dict.Where(d => d.Value == 1);

            // Результат проверки карточек маршрута
            if (max == 2 && FindStartStopPoint.Count() == 2)
            {               

                Console.WriteLine("max = "+max+"\n StartStopPoint :");
                foreach (KeyValuePair<string, int> pair in FindStartStopPoint)
                    {
                        Console.WriteLine(pair.Key);
                    }
                return true;
            }
            else
            {
                Console.WriteLine("Обнаружена ошибка в точках маршрута");
                if(FindStartStopPoint.Count() > 2)
                foreach (KeyValuePair<string, int> pair in FindStartStopPoint)
                    {
                        Console.WriteLine(pair.Key);
                    }

                Console.ReadKey();
                return false;
            } 
        }


        static int FindStart(ref ArrayList ArList, ref int Count, out string StartPoint )
        {
            int start = 0 ;
            StartPoint = "Ошибка в наборе карт маршрута. Не найдена точка старта.";
            bool isHaveInStop=false; // в списке Stop обнаружен одноименный Start

            Card card_x;
            Card card_y;
            

            
            // Найти начало - Start и конец - Stop маршрута
            //  

            

            for (int i = 0; i < Count ; i++)
            {   card_x = (Card)ArList[i];

                for (int j=0; j < Count; j++)
                {   card_y = (Card)ArList[j];

                    


                    // проверка совпадений Start со Stop
                    if (card_x.Start == card_y.Stop)
                        {
                            isHaveInStop = true; // есть совпадение
                            break;               // переходим к следующей карточке
                        }
                        else isHaveInStop = false;
                }
                if (isHaveInStop == false)
                {
                    start = i;
                    StartPoint = card_x.Start;
                    break;
                }   
            }
            return start;
        }

        





        static ArrayList Sort(ref ArrayList ArList, ref int Count, int start)
        {
            bool completed = false;

            Card cardStart = (Card)ArList[start];

            ArrayList SortedArrList = new ArrayList();
            SortedArrList.Add(cardStart);

            Console.WriteLine("The sorting began...");

            while ( !completed )
            {
                foreach(Card crd in ArList)
                {       
                    if (crd.Start == cardStart.Stop)
                    {
                        SortedArrList.Add(crd);
                        cardStart = crd;       
                    }
                }

                Console.WriteLine("Сртировка. Кол-во в сортМассиве " + SortedArrList.Count);

                if (SortedArrList.Count == Count)
                {
                    completed = true;
                    Console.WriteLine("\n Sorting is done");
                }
                //else if (SortedArrList.Count > Count)
                //{
                //    Console.WriteLine("\n Сортировка не выполнена. \nВозможно, одноименная точка Start/Stop встречается больше 2х раз.");
                //    break;
                //}
            }
            return SortedArrList;

        }
    }
}
