using System;

namespace Coding.Exercise
{

    public class Game
    {
        public event EventHandler<Rat> RatAdded;
        public event EventHandler<Rat> RatRemoved;

        public void AddRat(Rat rat)
        {
            RatAdded?.Invoke(this, rat);
        }

        public void RemoveRat(Rat rat)
        {
            RatRemoved?.Invoke(this, rat);
            rat.Dispose();
        }
    }

    public class Rat : IDisposable
    {
        public int Attack;
        public static int totalCount = 0;
        private readonly Game _game;

        public Rat(Game game)
        {
            _game = game;
            _game.RatAdded += OnRatAdded;
            _game.RatRemoved += OnRatRemoved;
            Attack = ++totalCount;
        }

        public void Dispose()
        {
            _game.RatAdded -= OnRatAdded;
            _game.RatRemoved -= OnRatRemoved;
            Attack = --totalCount;
        }

        private void OnRatAdded(object sender, Rat rat)
        {
            if (rat != this)
            {
                Attack = totalCount;
            }
        }

        private void OnRatRemoved(object sender, Rat rat)
        {
            if (rat != this)
            {
                Attack = totalCount;
            }
        }
    }
}