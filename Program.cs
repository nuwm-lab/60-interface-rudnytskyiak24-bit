using System;

namespace GeometryApp
{
    // ---------------- Клас "Коло в просторі" ----------------
    class Circle3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Radius { get; set; }

        // Задання даних кола
        public void SetData()
        {
            Console.Write("Введіть координату X центру кола: ");
            X = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату Y центру кола: ");
            Y = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату Z центру кола: ");
            Z = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть радіус кола: ");
            Radius = Convert.ToDouble(Console.ReadLine());
        }

        // Виведення даних кола
        public void DisplayInfo()
        {
            Console.WriteLine($"\nКоло в просторі:");
            Console.WriteLine($"Центр: ({X}, {Y}, {Z})");
            Console.WriteLine($"Радіус: {Radius}");
        }

        // Обчислення довжини кола
        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }
    }

    // ---------------- Клас "Конус" ----------------
    class Cone : Circle3D
    {
        public double ApexX { get; set; }
        public double ApexY { get; set; }
        public double ApexZ { get; set; }
        public double SlantHeight { get; set; }

        // Задання даних конуса
        public new void SetData()
        {
            base.SetData(); // викликаємо метод базового класу для задання кола

            Console.Write("Введіть координату X вершини конуса: ");
            ApexX = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату Y вершини конуса: ");
            ApexY = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату Z вершини конуса: ");
            ApexZ = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть твірну конуса: ");
            SlantHeight = Convert.ToDouble(Console.ReadLine());
        }

        // Виведення даних конуса
        public new void DisplayInfo()
        {
            base.DisplayInfo(); // викликаємо метод базового класу для виведення кола

            Console.WriteLine($"Вершина: ({ApexX}, {ApexY}, {ApexZ})");
            Console.WriteLine($"Твірна: {SlantHeight}");
        }

        // Обчислення бічної поверхні конуса
        public double GetLateralSurfaceArea()
        {
            return Math.PI * Radius * SlantHeight;
        }

        // Обчислення радіуса основи конуса
        public double GetBaseRadius()
        {
            double dx = ApexX - X;
            double dy = ApexY - Y;
            double dz = ApexZ - Z;
            double height = Math.Sqrt(dx * dx + dy * dy + dz * dz);

            return Math.Sqrt(SlantHeight * SlantHeight - height * height);
        }
    }

    // ---------------- Головна програма ----------------
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Створення кола в просторі
                Circle3D circle = new Circle3D();
                circle.SetData();
                circle.DisplayInfo();
                Console.WriteLine($"Довжина кола: {circle.GetCircumference():F2}");

                // Створення конуса
                Cone cone = new Cone();
                cone.SetData();
                cone.DisplayInfo();
                Console.WriteLine($"Радіус основи конуса: {cone.GetBaseRadius():F2}");
                Console.WriteLine($"Бічна поверхня конуса: {cone.GetLateralSurfaceArea():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ Сталася помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
