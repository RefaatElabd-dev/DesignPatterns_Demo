namespace Singlton
{
    public class OrdinaryDB: IDB
    {
        private Dictionary<string, int> capitals;
        public OrdinaryDB()
        {
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDB).Assembly.Location).DirectoryName, "capitals.txt")
              )
              .Chunk(2)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
