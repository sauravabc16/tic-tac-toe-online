using TicTacToeOnlineApi.Models;

namespace TicTacToeOnlineApi.Services
{
    public class SessionService
    {
        private readonly Dictionary<string, Session> _sessions = new();

        public string CreateSession()
        {
            var sessionId = Guid.NewGuid().ToString().Substring(0, 8);
            var session = new Session
            {
                SessionId = sessionId,
                Board = new string[3, 3]
            };
            _sessions[sessionId] = session;
            return sessionId;
        }

        public bool JoinSession(string sessionId, string playerName)
        {
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                if (string.IsNullOrEmpty(session.Player1))
                {
                    session.Player1 = playerName;
                    return true;
                }
                else if (string.IsNullOrEmpty(session.Player2))
                {
                    session.Player2 = playerName;
                    return true;
                }
            }
            return false;
        }

        public Session? GetSession(string sessionId)
        {
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                return session;
            }
            return null;
        }

        public (bool Success, string Message, Session? UpdatedSession) MakeMove(string sessionId, MoveRequest move)
        {
            if (!_sessions.TryGetValue(sessionId, out var session))
            {
                return (false, "Session not found.", null);
            }

            if (move.Row < 0 || move.Row > 2 || move.Col < 0 || move.Col > 2)
            {
                return (false, "Invalid board position.", null);
            }

            if (!string.IsNullOrEmpty(session.Board[move.Row, move.Col]))
            {
                return (false, "Cell already occupied.", null);
            }

            session.Board[move.Row, move.Col] = session.CurrentPlayer;

            var winner = CheckWinner(session.Board);
            if (!string.IsNullOrEmpty(winner))
            {
                return (true, $"Player {winner} wins!", session);
            }

            if (IsBoardFull(session.Board))
            {
                return (true, "It's a draw!", session);
            }

            session.CurrentPlayer = (session.CurrentPlayer == "X") ? "O" : "X";
            return (true, "Move accepted.", session);
        }

        private string CheckWinner(string[,] board)
        {
            // Rows
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(board[i, 0]) &&
                    board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }
            }
            // Cols
            for (int j = 0; j < 3; j++)
            {
                if (!string.IsNullOrEmpty(board[0, j]) &&
                    board[0, j] == board[1, j] &&
                    board[1, j] == board[2, j])
                {
                    return board[0, j];
                }
            }
            // Diagonals
            if (!string.IsNullOrEmpty(board[0, 0]) &&
                board[0, 0] == board[1, 1] &&
                board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }
            if (!string.IsNullOrEmpty(board[0, 2]) &&
                board[0, 2] == board[1, 1] &&
                board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }
            return string.Empty;
        }

        private bool IsBoardFull(string[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(board[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
