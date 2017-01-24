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
            //ArrCard.Add(new Card("Берлин", "Москва"));

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

           // comment
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


        // Функция поиска в массиве расположения карточки с началом маршрута
        static int FindStart(ref ArrayList ArList, ref int Count, out string StartPoint )
        {
            int start_pos = 0 ;
            StartPoint = "Ошибка в наборе карт маршрута. Не найдена точка старта.";
            bool isHaveInStop=false; // флаг уникальности точки старта 

            Card card_i;
            Card card_j;
            

                for (int i = 0; i < Count ; i++)
                {   card_i = (Card)ArList[i];

                // сравнение начальной точки с конечными 
                for (int j=0; j < Count; j++)
                    {   card_j = (Card)ArList[j];
                    
                            if (card_i.Start == card_j.Stop)
                                {
                                    isHaveInStop = true; 
                                    break;               
                                }
                            else isHaveInStop = false;
                    }
                // после перебора карт запоминаем позицию в массиве и наименование старта
                    if (isHaveInStop == false)
                    {
                        start_pos = i;
                        StartPoint = card_i.Start;
                        break;
                    }   
                }
            return start_pos;
        }

        




        // Функция сортировки массива карточек
        static ArrayList Sort(ref ArrayList ArList, ref int Count, int start)
        {
            
            Card cardStart = (Card)ArList[start];
            ArrayList SortedArrList = new ArrayList();
            SortedArrList.Add(cardStart);

            Console.WriteLine("Запуск сортировки...");

            bool is_sorted = false;

            while ( !is_sorted )
            {
                    foreach(Card crd in ArList)
                    {       
                        if (crd.Start == cardStart.Stop)
                        {
                            SortedArrList.Add(crd);
                            cardStart = crd;       
                        }
                    }

                
                    // выход из цикла определяется равенством количества элементов в массивах
                    if (SortedArrList.Count == Count)
                    {
                        is_sorted = true;
                        Console.WriteLine("\n Sorting is done");
                    }

            }
            return SortedArrList;
        }
    }
}
