using System;
using Xunit;

namespace BowlingGameKata.Tests
{
    public class BowlingGameTest
    {
        public class BowlingGame
        {
            readonly Game game;

            public BowlingGame()
            {
                game = new Game();
            }

            private void RollMany(int n, int pins)
            {
                for (int i = 0; i < n; i++)
                {
                    game.Roll(pins);
                }
            }

            [Fact]
            public void GutterGame_Test()
            {
                RollMany(20, 0);
                Assert.Equal(0, game.Score());
            }

            [Fact]
            public void AllOnes_Test()
            {
                RollMany(20, 1);
                Assert.Equal(20, game.Score());
            }

            [Fact]
            public void OneSpare_Test()
            {
                RollSpare();
                game.Roll(3);
                RollMany(17, 0);
                Assert.Equal(16, game.Score());
            }

            private void RollSpare()
            {
                game.Roll(5);
                game.Roll(5);
            }

            [Fact]
            public void OneStrike_Test()
            {
                RollStrike();
                game.Roll(4);
                game.Roll(3);
                RollMany(16, 0);
                Assert.Equal(24, game.Score());
            }

            private void RollStrike()
            {
                game.Roll(10);
            }

            [Fact]
            public void PerfectGame_Test()
            {
                RollMany(12, 10);
                Assert.Equal(300, game.Score());
            }
        }
    }
}
