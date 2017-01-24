using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB1
{
    class ClassTestArray  
    {
        static public bool TestArrCard(ref ArrayList ArrCard)
        {
            //
            // Перед сортировкой требуется проверить:
            // имеем в наличии одно начало маршрута и один конец .
            // Составим словарь пунктов отправлений
            // 
            var dict = new Dictionary<string, int>();

            // Заполняем словарь
            #region 
            foreach (Card card in ArrCard)
            {
                // считаем или добавляем ключи по списку Start
                if (dict.ContainsKey(card.Start))
                {
                    dict[card.Start] += 1;

                }
                else
                {
                    dict.Add(card.Start, 1);
                }
                //  ------    --//--    ------          Stop
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

            // Проверка полученного словаря.
            // Максимум упоминаний точек ( Должен быть равным 2. Исключаем повторный заезд в какой-либо пункт)
            // Количества точек упоминаемых единожды (признак начала/конца)
            int max = dict.Max(d => d.Value);
            var FindStartStopPoint = dict.Where(d => d.Value == 1);

            // Проверка заданным условиям
            if (max == 2 && FindStartStopPoint.Count() == 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Обнаружена ошибка в точках маршрута.");
                if (max > 2) { Console.WriteLine("Error max = {0}", max); }
                if (FindStartStopPoint.Count() > 2)
                { Console.WriteLine("Маршрут имеет несколько начальных или конечных точек"); }
                Console.ReadKey();
                return false;
            }
        }
    }
}
