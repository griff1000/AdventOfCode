namespace Challenge2
{
    public class Round
    {
        private RockPaperScissors ElfGuess { get; }

        /// <summary>
        /// Before the full requirements, the last bit of the strategy
        /// was assumed to be the player's guess
        /// </summary>
        private RockPaperScissors MyGuessBefore { get; }

        /// <summary>
        /// After the full requirements, the last bit of the strategy
        /// was known to indicate that the player's guess was relative
        /// to the elf's guess
        /// </summary>
        private RockPaperScissors MyGuessAfter => CalculateMyGuessBasedOnFullRequirements();

        private Strategy Strategy { get; }

        /// <summary>
        /// Score based on incomplete and therefore incorrect requirements
        /// </summary>
        public int RoundScoreBefore => (int)MyGuessBefore + ScoreForDidIWin(MyGuessBefore);

        /// <summary>
        /// Score based on full requirements
        /// </summary>
        //public int RoundScoreAfter => (int)MyGuessAfter + ScoreForStrategy();
        public int RoundScoreAfter => (int)MyGuessAfter + ScoreForDidIWin(MyGuessAfter);

        public Round(string round)
        {
            var goes = round.Split(' ');
            ElfGuess = ConvertGuessToEnum(goes[0]);
            MyGuessBefore = ConvertGuessToEnum(goes[1]);
            Strategy = ConvertStrategyToEnum(goes[1]);
        }

        private static Strategy ConvertStrategyToEnum(string strategy) => strategy.ToUpper() switch
        {
            "X" => Strategy.Lose,
            "Y" => Strategy.Draw,
            "Z" => Strategy.Win,
            _ => throw new ArgumentOutOfRangeException()
        };

        private static RockPaperScissors ConvertGuessToEnum(string guess) =>
            guess.ToUpper() switch
            {
                "A" or "X" => RockPaperScissors.Rock,
                "B" or "Y" => RockPaperScissors.Paper,
                "C" or "Z" => RockPaperScissors.Scissors,
                _ => throw new ArgumentOutOfRangeException()
            };

        //private int ScoreForStrategy() => Strategy switch
        //{
        //    Strategy.Win => 6,
        //    Strategy.Draw => 3,
        //    _ => 0
        //};

        private RockPaperScissors CalculateMyGuessBasedOnFullRequirements() =>
            Strategy switch
            {
                Strategy.Lose => 
                    ElfGuess switch
                    {
                        RockPaperScissors.Rock => RockPaperScissors.Scissors,
                        RockPaperScissors.Paper => RockPaperScissors.Rock,
                        RockPaperScissors.Scissors => RockPaperScissors.Paper,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                Strategy.Draw =>
                    ElfGuess,
                Strategy.Win =>
                    ElfGuess switch
                    {
                        RockPaperScissors.Rock => RockPaperScissors.Paper,
                        RockPaperScissors.Paper => RockPaperScissors.Scissors,
                        RockPaperScissors.Scissors => RockPaperScissors.Rock,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                _ => throw new ArgumentOutOfRangeException()
            };

        private int ScoreForDidIWin(RockPaperScissors myGuess)
        {
            if (ElfGuess == myGuess) return 3;

            var result = (ElfGuess, myGuess) switch
            {
                (RockPaperScissors.Rock, RockPaperScissors.Paper) or
                (RockPaperScissors.Paper, RockPaperScissors.Scissors) or
                (RockPaperScissors.Scissors, RockPaperScissors.Rock) => 6,
                _ => 0
            };
            return result;
        }
    }
}
