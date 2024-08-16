namespace BlazorTicTacToe.Shared
{
    public class TicTacToeGame
    {
        public string? PlayerXId { get; set; }
        public string? PlayerOId { get; set; }
        public string? CurrentPlayerId { get; set; }
        public string CurrentPlayerSymbol => CurrentPlayerId == PlayerXId ? "X" : "O";
        public bool GameStarted { get; set; } = false;
        public bool GameOver { get; set; } = false;
        public bool IsDraw { get; set; } = false;
        public string Winner { get; set; } = string.Empty;
        public List<List<string>> Board { get; set; } = new List<List<string>>(3);

        public TicTacToeGame()
        {
            InitializeBoard();
        }
        public void StartGame()
        {
            CurrentPlayerId = PlayerXId;
            GameStarted = true;
            GameOver = false;
            Winner = string.Empty;
            IsDraw = false;
            InitializeBoard();
        }
        private void InitializeBoard()
        {
            Board.Clear();
            for (int i = 0; i < 3; i++)
            {
                var row = new List<string>(3);
                for (int j = 0; j < 3; j++)
                {
                    row.Add(string.Empty);
                    Console.WriteLine("added a row");
                }
                Board.Add(row);
            }
        }

        public void TogglePlayer()
        {
            CurrentPlayerId = CurrentPlayerId == PlayerXId ? PlayerOId : PlayerXId;
        }

        public bool MakeMove(int row, int col, string playerId)
        {
            if (playerId != CurrentPlayerId
                    || row < 0 || row >=3
                    || col < 0 || col >=3
                    || Board[row][col] != string.Empty)
            {
                return false;
            }

            Board[row][col] = CurrentPlayerSymbol;
            TogglePlayer();
            return true;
        }

        public string CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                // Satır kontrolü
                if (!string.IsNullOrEmpty(Board[i][0])
                        && Board[i][0] == Board[i][1]
                        && Board[i][1] == Board[i][2])
                {
                    return Board[i][0];
                }

                // Sütun kontrolü
                if (!string.IsNullOrEmpty(Board[0][i])
                        && Board[0][i] == Board[1][i]
                        && Board[1][i] == Board[2][i])
                {
                    return Board[0][i];
                }
            }

            // Çapraz kontrolü (sol üstten sağ alta)
            if (!string.IsNullOrEmpty(Board[0][0])
                    && Board[0][0] == Board[1][1]
                    && Board[1][1] == Board[2][2])
            {
                return Board[0][0];
            }

            // Çapraz kontrolü (sağ üstten sol alta)
            if (!string.IsNullOrEmpty(Board[0][2])
                    && Board[0][2] == Board[1][1]
                    && Board[1][1] == Board[2][0])
            {
                return Board[0][2];
            }

            // Kazanan yoksa null dön
            return String.Empty ;
        }

        public bool CheckDraw()
        {
            // Oyun tahtasındaki her hücreyi kontrol et
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Eğer boş bir hücre varsa, oyun henüz bitmedi, beraberlik yok
                    if (string.IsNullOrEmpty(Board[i][j]))
                    {
                        return false;
                    }
                }
            }

            // Eğer tüm hücreler doluysa ve kazanan yoksa, oyun berabere
            return IsDraw = CheckWinner() == string.Empty;
        }

    }
}
