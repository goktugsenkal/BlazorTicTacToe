using BlazorTicTacToe.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorTicTacToe.Hubs
{
    public class GameHub : Hub
    {
        private static readonly List<GameRoom> _rooms = new();
        public override async Task  OnConnectedAsync()
        {
            Console.WriteLine($"'{Context.ConnectionId}' ID'li oyuncu bağlandı.");

            await Clients.Caller.SendAsync("Rooms", _rooms.OrderBy(x => x.RoomName));
        }
        public async Task<GameRoom> CreateRoom(string roomName, string playerName)
        {
            var roomId = Guid.NewGuid().ToString();
            var gameRoom = new GameRoom(roomId, roomName);
            _rooms.Add(gameRoom);

            var newPlayer = new Player(Context.ConnectionId, playerName);
            gameRoom.TryAddPlayer(newPlayer);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.All.SendAsync("Rooms", _rooms.OrderBy(x => x.RoomName));

            return gameRoom;
        }
        public async Task<GameRoom?> JoinRoom(string roomId, string playerName)
        {
            var room = _rooms.FirstOrDefault(r=>r.RoomId == roomId);
            if (room is not null)
            {
                var newPlayer = new Player(Context.ConnectionId, playerName);
                if (room.TryAddPlayer(newPlayer))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                    await Clients.Group(roomId).SendAsync("PlayerJoined", newPlayer);

                    return room;
                }
            }
            return null;
        }
        public async Task StartGame(string roomId)
        {
            var room = _rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (room is not null)
            {
                room.Game.StartGame();
                await Clients.Group(roomId).SendAsync("UpdateGame", room);
            }
        }

        public async Task MakeMove(string roomId, int row, int col, string playerId)
        {
            var room = _rooms.FirstOrDefault(r => r.RoomId == roomId);

            if (room != null && room.Game.MakeMove(row,col,playerId))
            {
                room.Game.Winner = room.Game.CheckWinner();
                room.Game.IsDraw = room.Game.CheckDraw();
                if (!string.IsNullOrEmpty(room.Game.Winner) || room.Game.IsDraw)
                {
                    room.Game.GameOver = true;
                }
                await Clients.Group(roomId).SendAsync("UpdateGame", room);
            }
        }
    }
}
