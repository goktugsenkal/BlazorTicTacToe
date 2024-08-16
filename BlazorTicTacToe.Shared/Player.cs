namespace BlazorTicTacToe.Shared
{
    public class Player
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public Player(string connectionId, string name)
        {
            ConnectionId = connectionId;
            Name = name;
        }
    }
}
