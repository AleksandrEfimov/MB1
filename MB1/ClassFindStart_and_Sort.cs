using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB1
{
    class ClassFindStart_and_Sort
    {
        // Функция поиска в массиве расположения карточки с началом маршрута
        static public int FindStart(ref ArrayList ArList, ref int Count, out string StartPoint)
        {
            int start_pos = 0;
            StartPoint = "Ошибка в наборе карт маршрута. Не найдена точка старта.";
            bool isHaveInStop = false; // флаг уникальности точки старта 

            Card card_i;
            Card card_j;


            for (int i = 0; i < Count; i++)
            {
                card_i = (Card)ArList[i];

                // сравнение начальной точки с конечными 
                for (int j = 0; j < Count; j++)
                {
                    card_j = (Card)ArList[j];

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
        static public  ArrayList Sort(ref ArrayList ArList, ref int Count, int start)
        {

            Card cardStart = (Card)ArList[start];
            ArrayList SortedArrList = new ArrayList();
            SortedArrList.Add(cardStart);

            Console.WriteLine("Запуск сортировки...");

            bool is_sorted = false;

            while (!is_sorted)
            {
                foreach (Card crd in ArList)
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
                    Console.WriteLine("\n...Сортировка окончена");
                }

            }
            return SortedArrList;
        }

    }
}
