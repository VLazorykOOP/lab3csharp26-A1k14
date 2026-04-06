using System;
using System.Linq;

namespace LabWork3
{
    class ATriangle
    {
        protected int a;
        protected int b;
        protected int c;

        public ATriangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int A
        {
            get { return a; }
            set { if (value > 0) a = value; }
        }

        public int B
        {
            get { return b; }
            set { if (value > 0) b = value; }
        }

        public int Color
        {
            get { return c; }
        }

        public void PrintSides()
        {
            Console.WriteLine($"KAtet a: {a}, Katet b: {b}");
        }

        public double GetPerimeter()
        {
            double hypotenuse = Math.Sqrt(a * a + b * b);
            return a + b + hypotenuse;
        }

        public double GetArea()
        {
            return 0.5 * a * b;
        }

        public bool IsIsosceles()
        {
            return a == b;
        }

        // task 2

        class Product
        {
            protected string name;
            protected double weight;

            public Product(string name, double weight)
            {
                this.name = name;
                this.weight = weight;
            }

            public virtual void Show()
            {
                Console.WriteLine($"(Product)Name: {name}, weight: {weight} kg");
            }
        }

        class Part : Product
        {
            protected string material;

            public Part(string name, double weight, string material) : base(name, weight)
            {
                this.material = material;
            }

            public override void Show()
            {
                Console.WriteLine($"[Gear] name: {name}, Material: {material}, Weight: {weight} kg");
            }
        }

        class Assembly : Product
        {
            protected int partCount;

            public Assembly(string name, double weight, int partCount) : base(name, weight)
            {
                this.partCount = partCount;
            }

            public override void Show()
            {
                Console.WriteLine($"[note] name: {name}, amout details: {partCount}, weight: {weight} kg");
            }
        }

        class Mechanism : Assembly
        {
            protected string function;

            public Mechanism(string name, double weight, int partCount, string function) : base(name, weight, partCount)
            {
                this.function = function;
            }

            public override void Show()
            {
                Console.WriteLine($"[Mechanism] name: {name}, function: {function}, partCount: {partCount}, weight: {weight} kg");
            }
        }

        // task 2 end

        class Program
        {
            static void Main()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n LAB 3, 1-2:");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Task1();
                            break;
                        case "2":
                            Task2();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("wrong");
                            break;
                    }
                }
            }

            static void Task1()
            {
                Console.WriteLine("Task 1.");
                Console.Write("Number triangls n: ");

                if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                {
                    ATriangle[] triangles = new ATriangle[n];

                    for (int i = 0; i < n; i++)
                    {

                        int a, b, c;
                        Console.Write("Katet  a: ");
                        while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                        {
                            Console.Write("only 1234567890 ");
                        }

                        Console.Write("katet  b: ");
                        while (!int.TryParse(Console.ReadLine(), out b) || b <= 0)
                        {
                            Console.Write("only 1234567890 ");
                        }

                        Console.Write("color: ");
                        while (!int.TryParse(Console.ReadLine(), out c))
                        {
                            Console.Write("only 1234567890  ");
                        }

                        triangles[i] = new ATriangle(a, b, c);
                    }

                    var sortedByColor = triangles.OrderBy(t => t.Color).ToArray();
                    Console.WriteLine("\n--- Vporiadkuvannia color ---");
                    foreach (var t in sortedByColor)
                    {
                        Console.WriteLine($"Color: {t.Color}, Area: {t.GetArea()}, Perimetr: {t.GetPerimeter():F2}");
                    }

                    var sortedByArea = triangles.OrderBy(t => t.GetArea()).ToArray();
                    Console.WriteLine("\n--- Vporiadcuvannia area ---");
                    foreach (var t in sortedByArea)
                    {
                        Console.WriteLine($"area: {t.GetArea()}, color: {t.Color}, Perimetr: {t.GetPerimeter():F2}");
                    }

                    var sortedByPerimeter = triangles.OrderBy(t => t.GetPerimeter()).ToArray();
                    Console.WriteLine("\n--- Vporiadcuvania perimetr ---");
                    foreach (var t in sortedByPerimeter)
                    {
                        Console.WriteLine($"Perimetr: {t.GetPerimeter():F2}, Color: {t.Color}, Area: {t.GetArea()}");
                    }

                    int isoscelesCount = triangles.Count(t => t.IsIsosceles());
                    Console.WriteLine($"\nAmout rivnobedrinih triangl: {isoscelesCount}");
                }
                else
                {
                    Console.WriteLine("only 1234567890 ");
                }
            }

            static void Task2()
            {
                Console.WriteLine("Task 2");

                Product[] products = FillProducts();

                Console.WriteLine("\nMasive for sort");
                foreach (var product in products)
                {
                    product.Show();
                }

                var sortedProducts = products.OrderBy(p => p.GetType().Name).ToArray();

                Console.WriteLine("\n vporiadcovanii masiv za tipom clasa");
                foreach (var product in sortedProducts)
                {
                    product.Show();
                }
            }

            static Product[] FillProducts()
            {
                return new Product[]
                {
                new Part("Gear", 1.5, "Steel"),
                new Mechanism("Internal Combustion Engine", 150.0, 45, "Shaft Rotation"),
                new Product("Profile", 2.0),
                new Assembly("Gearbox", 45.0, 12),
                new Part("Vulcanized Gasket", 0.1, "Rubber"),
                new Mechanism("Hydraulic Cylinder", 25.0, 8, "Linear Motion")
                };
            }
        }
    }
}
