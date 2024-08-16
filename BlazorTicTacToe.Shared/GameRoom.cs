namespace BlazorTicTacToe.Shared
{
    public class GameRoom
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public List<Player> Players { get; set; } = new();
        public TicTacToeGame Game { get; set; } = new();

        public GameRoom(string roomId, string roomName)
        {
            RoomId = roomId;
            RoomName = roomName;
        }

        public bool TryAddPlayer(Player newPlayer)
        {
            Console.WriteLine($"Attempting to add player with ConnectionId: {newPlayer.ConnectionId}");

            if (Players.Count < 2 && !Players.Any(p => p.ConnectionId == newPlayer.ConnectionId))
            {
                Players.Add(newPlayer);
                if (Players.Count == 1)
                {
                    Game.PlayerXId = newPlayer.ConnectionId;
                    Console.WriteLine($"PlayerXId assigned: {Game.PlayerXId}");

                }
                else if(Players.Count == 2)
                {
                    Game.PlayerOId = newPlayer.ConnectionId;
                    Console.WriteLine($"PlayerOId assigned: {Game.PlayerOId}");

                }
                return true;
            }
            return false;
        }
    }
}
