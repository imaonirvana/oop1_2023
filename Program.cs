namespace Program
{
    class Program
    {
        delegate int IntGetter();
        delegate int AverageFromGetters(IntGetter[] valueGetter);
        delegate int Average(int a, int b, int c);

        public static void Main()
        {
            var Add = (int a, int b) => a + b;
            var Sub = (int a, int b) => a - b;
            var Mul = (int a, int b) => a * b;
            var Div = (int a, int b) => a / b;

            Console.WriteLine(Add(1, 5));
            Console.WriteLine(Sub(6, 5));
            Console.WriteLine(Mul(2, 5));
            Console.WriteLine(Div(10, 5));

            IntGetter getter = () => Random.Shared.Next();

            AverageFromGetters averageFromGetters = (items) =>
            {
                var sum = 0;

                foreach (var getter in items)
                {
                    sum += getter();
                }

                return sum / items.Length;
            };

            Average average = (a, b, c) => (a + b + c) / 3;

            IntGetter[] getters = { getter, getter, getter };

            Console.WriteLine(averageFromGetters(getters));
            Console.WriteLine(average(2, 4, 6));
        }
    }
}