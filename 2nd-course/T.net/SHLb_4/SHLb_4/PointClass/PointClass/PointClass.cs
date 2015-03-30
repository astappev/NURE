using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointSpace
{
    /// <summary> 
    /// Класс для работы с координатами точки
    /// </summary>
    public class PointClass
    {
        protected int _x;
        protected int _y;

        /// <summary>
        /// Установить т. X
        /// </summary>
        public int x
        {
            get { return this._x; }
            set { this._x = value; }
        }

        /// <summary>
        /// Установить т. Y
        /// </summary>
        public int y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PointClass()
        {
            this.x = 0;
            this.y = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">Координаты по X.</param>
        /// <param name="y">Координаты по Y.</param>
        public PointClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Вывести координаты точки на экран
        /// </summary>
        /// <returns>Строка с текущими координатами.</returns> 
        public string PrintCord()
        {
            if (x != null && y != null)
                return String.Format("x = {0}, y = {1}", x.ToString(), y.ToString());
            else
                return String.Format("Данные не заполнены.");
        }

        /// <summary>
        /// Рассчитать расстояние от начала координат до точки
        /// </summary>
        /// <returns>Рузультаты вычисления растояния от точки до начала коодинат.</returns> 
        public int CalcDistance()
        {
            return (int)Math.Sqrt(Math.Pow(0 - this.x, 2) + Math.Pow(0 - this.y, 2));
        }

        /// <summary>
        /// Переместить точку на плоскости на вектор (a, b)
        /// </summary>
        /// <param name="x">Параметр a, вектора (a, b).</param>
        /// <param name="y">Параметр b, вектора (a, b).</param>
        public void MovePoint(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        /* Свойства позволяющие умножить координаты точки на скаляр (доступное для чтений и записи) */
        /// <summary>
        /// Умножить координаты т. X на скаляр
        /// </summary>
        /// <value>Возвращает текущее значение точки, по оси X. Записывает в точку ее значение умноженое на скаляр.</value>
        public double MultiplyX
        {
            get { return x; }
            set { x = (int) (value * x); }
        }

        /// <summary>
        /// Умножить координаты т. Y на скаляр
        /// </summary>
        /// <value>Возвращает текущее значение точки, по оси Y. Записывает в точку ее значение умноженое на скаляр.</value>
        public double MultiplyY
        {
            get { return y; }
            set { y = (int)(value * y); }
        }
    }
}
