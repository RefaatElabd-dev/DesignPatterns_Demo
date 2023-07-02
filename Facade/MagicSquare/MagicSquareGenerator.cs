namespace Facade.MagicSquare
{
    public class MagicSquareGenerator
    {
        public List<List<int>> Generate(int size)
        {
            var square =new List<List<int>>();
            Generator generator = new Generator();
            Splitter spliter = new Splitter();
            Verifier verifier = new Verifier();
            while (true)
            {
                for (int i = 0; i < size; i++)
                {
                    square.Add(generator.Generate(size));
                }

                spliter.Split(square);

                if(verifier.Verify(square))
                    return square;
                else
                    square.Clear();
            }
        }
    }
}
