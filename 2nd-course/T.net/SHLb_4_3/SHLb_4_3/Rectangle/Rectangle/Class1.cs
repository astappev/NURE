using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    /// <summary> 
    /// Класс для работы с прямоугольником
    /// </summary>
    public class Rectangle
    {
        protected int a;
        protected int b;

        /// <summary>
        /// Конструктор с заданными длинами сторон. 
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="height">Высота прямоугольника.</param>
        public Rectangle(int width, int height)
        {
            this.a = width;
            this.b = height;
        }

        /// <summary>
        /// Вывод длины сторон прямоугольника
        /// </summary>
        /// <returns>Строка с длинами сторон прямоугольника.</returns> 
        public string PrintLength()
        {
            if (a != null && b != null)
                return String.Format("Ширина = {0}, Высота = {1}", a.ToString(), b.ToString());
            else
                return String.Format("Данные не заполнены.");
        }

        /// <summary>
        /// Расчёт периметра прямоугольника
        /// </summary>
        /// <returns>Периметр прямоугольника.</returns> 
        public int CalcPerimeter()
        {
            return a * 2 + b * 2;
        }

        /// <summary>
        /// Расчёт площади прямоугольника
        /// </summary>
        /// <returns>Площадь прямоугольника.</returns> 
        public int CalcArea()
        {
            return a * b;
        }

        /// <summary>
        /// Установить ширину
        /// </summary>
        /// <value>Ширина.</value>
        public int Width
        {
            get { return this.a; }
            set { this.a = value; }
        }

        /// <summary>
        /// Установить высоту
        /// </summary>
        /// <value>Высота.</value>
        /// 
        public int Height
        {
            get { return this.b; }
            set { this.b = value; }
        }

        /// <summary>
        /// Проверка является ли данный прямоугольник квадратом
        /// </summary>
        /// <returns>В случае если прямоугольник квадратный возвращает true.</returns> 
        public bool isSquare
        {
            get { return (bool)(a == b)?true:false; }
        }

    }
}
