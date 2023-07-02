namespace Facade.MagicSquare
{
    public class MagicSquareGenerator
    {
        public List<List<int>> Generate(int size)
        {
            while (true)
            {
                var square =new List<List<int>>();
                Generator generator = new Generator();
                for (int i = 0; i < size; i++)
                {
                    square.Add(generator.Generate(size));
                }

                var spliter = new Splitter();
                spliter.Split(square);

                var verifier = new Verifier();
                if(verifier.Verify(square))
                {
                    return square;
                }
            }
        }
    }
}
