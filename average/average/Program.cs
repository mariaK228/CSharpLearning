/*напиши функцию, которая ищет среднее арифметическое чисел из массива, который задан любым типом ICollection
т.е. у тебя должна быть функция, которая работает одинаково и для List<double> и для double[] и прочих массивов
а по хорошему не только double, а вообще любых примитивных типов
double, int, uint, long, ulong, float
ICollection (как и IEnumerable) не позволяют получать доступ к элементу по индексу, поэтому для перебора элементов придется использовать foreach(var element in collection)
Надо объяснять, что такое интерфейс?
Интерфейс это почти то же самое, что абстрактный класс, только абстрактный класс может иметь частичную реализацию, приватные и защищенный поля, функции и прочее. 
А интерфейс может иметь только полностью абстрактные методы и свойства 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace average
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
