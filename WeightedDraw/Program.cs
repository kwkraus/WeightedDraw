namespace WeightedDraw
{
    internal class Program
    {
        static readonly Random random = new();

        static void Main(string[] args)
        {
            var numberOfLoops = int.Parse(args[0]);

            Console.WriteLine($"Running weighted distrubution {numberOfLoops} times.");

            int[] weights = new int[] { 1, 2 };

            var results = new List<int>();

            for (int i = 0; i < numberOfLoops; i++)
            {
                var result = WeightedDraw(weights);

                //Console.WriteLine(result);

                results.Add(result);
            }

            foreach (var weight in weights)
            {
                Console.WriteLine(
                    @$"Percentage of {weight} = Occurances:{results.Count(x => x == weight)}
                    ({((float)(results.Count(x => x == weight)) / numberOfLoops) * 100}%)");
            }

            Console.ReadLine();
        }


        static int WeightedDraw(int[] weights)
        {
            var sum = 0;

            int randomValue = random.Next(weights.Sum());

            for (var i = 0; i < weights.Length; i++)
            {
                if (randomValue < (sum + weights[i]))
                {
                    // hit
                    return weights[i];
                }
                else
                {
                    sum += weights[i];
                }
            }

            return 0;
        }
    }
}