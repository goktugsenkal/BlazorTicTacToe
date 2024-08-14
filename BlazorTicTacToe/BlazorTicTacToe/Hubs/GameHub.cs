using BlazorTicTacToe.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorTicTacToe.Hubs
{
    public class GameHub : Hub
    {
        private static readonly List<GameRoom> _rooms = new();
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"'{Context.ConnectionId}' ID'li oyuncu bağlandı.");

            await Clients.Caller.SendAsync("Rooms", _rooms.OrderBy(x=>x.RoomName));
        }

        public async Task<GameRoom> CreateRoom(string roomName, string playerName)
        {
            var roomId = Guid.NewGuid().ToString();
            var gameRoom = new GameRoom(roomId, roomName);
            _rooms.Add(gameRoom);

            await Clients.All.SendAsync("Rooms", _rooms.OrderBy(x => x.RoomName));

            return gameRoom;
        }
    }
}
