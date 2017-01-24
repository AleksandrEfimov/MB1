using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB1
{
    class Program : ClassFindStart_and_Sort
    {
        
        


        static void Main(string[] args)
        {

           // Инициализация массива карточек
            ArrayList ArrCard = new ArrayList(); 
            ArrCard.Add(new Card("Москва", "Ярославль"));
            ArrCard.Add(new Card("Ярославль", "Архангельск"));
            ArrCard.Add(new Card("Архангельск", "Питер"));
            ArrCard.Add(new Card("Орел", "Москва"));
            // 
             //ArrCard.Add(new Card("Берлин", "Москва"));

            int Count = ArrCard.Count;
            string StartPoint;

            // Проверим набор на сходимость ( Одно начало, один конец, небольше 2х упоминаий пунктов маршрутов) 
            if (ClassTestArray.TestArrCard(ref ArrCard))
            {

                // индекс карты начала маршрута в массиве 
                int startIndex = FindStart(ref ArrCard, ref Count, out StartPoint);
                Console.WriteLine("Номер карты с началом маршрута: " + (startIndex + 1));
                Console.WriteLine("Начало маршрута в точке:  " + StartPoint);

                // Сортировка и вывод отсортированного массива
                ArrCard = Sort(ref ArrCard, ref Count, startIndex);
                Console.WriteLine("Пункт отправления:   Пункт назначения: \n");
                foreach (Card card in ArrCard)
                    Console.WriteLine(" - " + card.Start + " \t-->  " + card.Stop);

                Console.ReadKey();

            }

        }


        
    }
}
