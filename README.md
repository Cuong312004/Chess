# 🕹️ Caro Chess Game over LAN (WinForms – C#)

A LAN-based **Caro Chess (Gomoku)** game built using **Windows Forms** in **C#**, supporting two-player interaction over a local network via TCP sockets.

---

## 🚀 Features

- 🧠 **Two-player mode over LAN** (TCP socket communication)
- 🎮 Interactive **GUI Chessboard** using `Panel` and `Button`
- 🖌️ **Custom background gradients** via GDI+
- 🎯 End-game detection with event-driven handling
- 🔄 Real-time turn switching and move updates
- 💬 Basic status messaging: connect, disconnect, notifications

---

## 🛠️ Technologies Used

| Stack | Description |
|-------|-------------|
| **C# .NET** | Programming language and runtime |
| **Windows Forms (WinForms)** | UI for game board and controls |
| **System.Net.Sockets** | TCP socket communication |
| **Multithreading** | Background listener thread |
| **GDI+ (Graphics)** | Gradient rendering for UI styling |

---

## 📦 Project Structure

Caro_Chess/
├── Caro.cs # Main form, handles UI and game logic
├── Chess_Board_Manager.cs # Game board rendering and state
├── SocketManager.cs # Manages TCP communication
├── SocketData.cs # Custom message protocol (command, message, point)
└── Resources/



---

## 🧩 How It Works

1. **Player A** starts as the server (`CreateServer()`).
2. **Player B** connects as client (`ConnectServer()`).
3. Both players take turns marking points on the board.
4. Each move is sent over TCP with a custom `SocketData` object.
5. Game automatically detects victory and disables input.
6. Supports new game requests, connection status, and exit messages.

---

## 📸 Screenshot
![System Architecture](https://github.com/Cuong312004/Chess/blob/main/Screenshot%202025-07-10%20212033.png)

![System Architecture](https://github.com/Cuong312004/Chess/blob/main/Screenshot%202025-07-10%20212135.png)

---

## ✅ Requirements

- Windows OS
- .NET Framework 4.7+ or .NET 6 (WinForms support)
- Visual Studio 2019/2022

---

## 🧑‍💻 Author

**Lưu Quốc Cường**  
- Email: quoccuongluu03@gmail.com

---

## 📄 License

MIT License – Feel free to use or modify for educational purposes.
