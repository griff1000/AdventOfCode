namespace Challenge2
{
    public class Round
    {
        public RockPaperScissors ElfGuess { get; }
        public RockPaperScissors MyGuessBeforeFullRequirements { get; }

        public RockPaperScissors MyGuessAfterFullRequirements { get; }
        public int RoundScoreBeforeFullRequirements { get; }
        public int RoundScoreAfterFullRequirements { get; }

        public Round(string round)
        {
            var goes = round.Split(' ');
            ElfGuess = ConvertGuessToEnum(goes[0]);
            MyGuessBeforeFullRequirements = ConvertGuessToEnum(goes[1]);
            MyGuessAfterFullRequirements = CalculateMyGuessBasedOnFullRequirements(ElfGuess, goes[1]);
            RoundScoreBeforeFullRequirements = ScoreForGuess(MyGuessBeforeFullRequirements) + ScoreForDidIWin(ElfGuess, MyGuessBeforeFullRequirements);
            RoundScoreAfterFullRequirements = ScoreForGuess(MyGuessAfterFullRequirements) +
                                              ScoreForDidIWin(ElfGuess, MyGuessAfterFullRequirements);
        }

        private static RockPaperScissors ConvertGuessToEnum(string guess) =>
            guess switch
            {
                "A" or "X" => RockPaperScissors.Rock,
                "B" or "Y" => RockPaperScissors.Paper,
                "C" or "Z" => RockPaperScissors.Scissors,
                _ => throw new ArgumentOutOfRangeException()
            };

        private int ScoreForGuess(RockPaperScissors go) =>
            go switch
            {
                RockPaperScissors.Rock => 1,
                RockPaperScissors.Paper => 2,
                RockPaperScissors.Scissors => 3,
                _ => throw new ArgumentOutOfRangeException()
            };

        private RockPaperScissors CalculateMyGuessBasedOnFullRequirements(RockPaperScissors elfGuess, string strategy)
        {
            return strategy.ToUpper() switch
            {
                "X" => // Lose
                    elfGuess switch
                    {
                        RockPaperScissors.Rock => RockPaperScissors.Scissors,
                        RockPaperScissors.Paper => RockPaperScissors.Rock,
                        RockPaperScissors.Scissors => RockPaperScissors.Paper,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                "Y" => // Draw
                    elfGuess,
                "Z" => // Win
                    elfGuess switch
                    {
                        RockPaperScissors.Rock => RockPaperScissors.Paper,
                        RockPaperScissors.Paper => RockPaperScissors.Scissors,
                        RockPaperScissors.Scissors => RockPaperScissors.Rock,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private int ScoreForDidIWin(RockPaperScissors elfGuess, RockPaperScissors myGuess) =>
            elfGuess switch
            {
                RockPaperScissors.Rock => myGuess switch
                {
                    RockPaperScissors.Rock => 3,
                    RockPaperScissors.Paper => 6,
                    _ => 0
                },
                RockPaperScissors.Paper => myGuess switch
                {
                    RockPaperScissors.Paper => 3,
                    RockPaperScissors.Scissors => 6,
                    _ => 0
                },
                RockPaperScissors.Scissors => myGuess switch
                {
                    RockPaperScissors.Scissors => 3,
                    RockPaperScissors.Rock => 6,
                    _ => 0
                },
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}
