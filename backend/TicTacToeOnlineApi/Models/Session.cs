namespace TicTacToeOnlineApi.Models
{
    public class Session
    {
        public string SessionId { get; set; } = string.Empty;
        public string[,] Board { get; set; } = new string[3, 3];
        public string CurrentPlayer { get; set; } = "X";
        public string? Player1 { get; set; } = null;
        public string? Player2 { get; set; } = null;
    }
}
