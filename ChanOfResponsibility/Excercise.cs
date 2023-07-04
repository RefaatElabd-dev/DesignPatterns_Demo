namespace ChanOfResponsibility.Ex
{
    public abstract class Creature
    {
        protected Game game;
        public Creature(Game game)
        {
            this.game = game;
        }
        public int attack { get; set; }
        public int defense { get; set; }
        public int Attack
        {
            get
            {
                game.CalculateProps(this);
                return attack;
            }
        }

        public int Defense
        {
            get
            {
                game.CalculateProps(this);
                return defense;
            }
        }

    }

    public class Goblin : Creature
    {
        public Goblin(Game game)
         : base(game)
        {
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game)
         :base(game)
        {
        }
    }

    public class Game
    {
        public IList<Creature> Creatures;
        public Game()
        {
            Creatures = new List<Creature>();
        }
        public void CalculateProps(Creature c)
        {
            c.attack = (c is GoblinKing) ? 3 : 1;
            c.defense = (c is GoblinKing) ? 3 : 1;
            foreach (var item in Creatures)
            {
                if (!item.Equals(c))
                {
                    c.defense += 1;

                    if (item is GoblinKing)
                    {
                        c.attack += 1;
                    }
                }
            }
        }
    }
}
