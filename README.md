# Tic Tac Toe Online 🎮

**Tic Tac Toe Online** is a lightweight, real-time multiplayer Tic Tac Toe game built using Angular and Ionic for the frontend, and .NET for the backend. It supports two-player gameplay via online sessions, accessible through a simple URL.

## 🚀 Features

- **Real-Time Multiplayer**: Play Tic Tac Toe instantly with your friends.
- **Session-Based Gameplay**: Create sessions, set game duration, move timers, or play unlimited.
- **Responsive UI**: Works seamlessly on mobile browsers and desktops.
- **Simple & Intuitive**: Minimal UI for a clean user experience.
- **Scoring**: Session-based scoring for each player.

---

## 📂 Project Structure
tic-tac-toe-online/ ├── backend/ │ └── TicTacToeOnlineApi/ │ ├── Controllers/ │ │ └── SessionController.cs │ ├── Models/ │ │ ├── Session.cs │ │ └── MoveRequest.cs │ ├── Services/ │ │ └── SessionService.cs │ ├── Program.cs │ └── TicTacToeOnlineApi.csproj └── frontend/ └── tic-tac-toe-ionic/ ├── src/ │ ├── app/ │ │ ├── components/ │ │ │ ├── board/ │ │ │ ├── player-info/ │ │ │ └── session-setup/ │ │ └── services/ │ │ ├── tic-tac-toe.service.ts │ │ ├── session.service.ts │ │ └── player.service.ts ├── ionic.config.json └── package.json


---

## 🛠️ Tech Stack

**Backend:**
- [.NET (C#)](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- SignalR (planned for real-time features)

**Frontend:**
- [Angular](https://angular.io/)
- [Ionic Framework](https://ionicframework.com/)
- TypeScript
- HTML/CSS

---

## ✅ Prerequisites

Make sure the following tools are installed before you start:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Ionic CLI](https://ionicframework.com/docs/cli)

Install Ionic globally using npm:
```bash
npm install -g @ionic/cli
```

# 🚦 Getting Started

Follow these instructions to get your development environment up and running:

### 1. Clone the Repository

```bash
git clone <your-github-repo-url>
cd tic-tac-toe-online
```

### 2. Backend Setup (.NET)

Navigate to backend:

```bash
cd backend/TicTacToeOnlineApi
```

Restore packages and build:

```bash
dotnet restore
dotnet build
```

Run the backend API:

```bash
dotnet run
```

Backend API is now available at:

```
http://localhost:5000
```

### 3. Frontend Setup (Angular/Ionic)

Navigate to frontend:

```bash
cd ../../frontend/tic-tac-toe-ionic
```

Install dependencies:

```bash
npm install
```

Serve frontend locally:

```bash
ionic serve
```

The frontend app will open automatically in your default browser at:

```
http://localhost:8100
```

---

# 📡 API Endpoints

| Method | Endpoint                                   | Description                         |
|--------|--------------------------------------------|-------------------------------------|
| POST   | `/api/session`                             | Creates a new session               |
| POST   | `/api/session/{sessionId}/join?playerName` | Joins a session                     |
| POST   | `/api/session/{sessionId}/move`            | Submits a move                      |
| GET    | `/api/session/{sessionId}`                 | Retrieves the current session state |

---

# 📌 Workflow for Development

- Clone or fork the repository.
- Set up both backend and frontend as mentioned above.
- Make your changes on a feature branch:

```bash
git checkout -b feature/your-feature
```

- Push changes and submit a Pull Request for review.

---

# 🚧 Planned Enhancements

- Integrate SignalR for instant real-time game moves.
- Add authentication and player profiles.
- Implement a leaderboard and persistent scores.
- Enhance UI with animations for a better gaming experience.
