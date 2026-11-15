# 🎮 Who Will Win The Million  
### C# WinForms Game – .NET Framework 4.7.2 | File-System Based Storage

![.NET Framework 4.7.2](https://img.shields.io/badge/.NET_Framework-4.7.2-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)[Language](https://img.shields.io/badge/C%23-9147FF?style=for-the-badge&logo=c-sharp)
![UI](https://img.shields.io/badge/WinForms-3A0CA3?style=for-the-badge&logo=windows)
![Storage](https://img.shields.io/badge/File%20System-4C1D95?style=for-the-badge&logo=files)
![Category](https://img.shields.io/badge/Desktop%20Game-5B21B6?style=for-the-badge&logo=windows95)

---

## 📌 Overview  
**Who Will Win The Million** is a desktop game built using **C#**, **Windows Forms**, and **.NET Framework 4.7.2**.  
This application replicates the experience of the classic game *"Who Wants to Be a Millionaire?"* with a clean UI, interactive elements, lifelines, sound effects, and a file-based question database.

The project demonstrates advanced **UI/UX design**, clean architectural patterns, and structured game logic suitable for educational and portfolio use.

---

## ✨ Key Features

### 🎨 **UX/UI Designed with 60/30/10 Color Principle**
- **60% dark theme**: main background for low-fatigue visibility  
- **30% purple**: primary interactive elements  
- **10% gold**: success indicators and visual highlights  
- Hover animations, click effects, glowing states, and accessible layout

---

### 📂 **File-System Based Question Database**
- No SQL server or external database required  
- All questions/answers stored in structured text files  
- Loaded dynamically at runtime  
- Lightweight, portable, and easy to maintain  

---

### 💾 **Game Progress Persistence – Binary Serialization**
- Binary serialization to save the player's current game progress  
- Binary deserialization to restore previously saved game progress  
- Allows players to continue their game from where they left off  

---

### 🔊 **Integrated Sound Engine**
- Hover sound  
- Click sound  
- Win/Lose effects  
- Leave-game effect  
- Global Mute/Unmute through MenuStrip  

---

### 🧠 **Smart Game Logic**
- 15 progressive levels  
- Randomized question selection  
- **Two lifelines:**  
  - **50:50** → removes two incorrect answers  
  - **Switch Question** → replaces the current question  
- Leave game button (player keeps current balance)  

---

### 🖥️ **Main Application Screens**
- **Intro screen** with animated **Circular Progress Bar**  
- **Main game screen** (question + four answers + level indicator)  
- **Menu** with sound settings and restart/exit options  

---

## 🛠️ **Tech Stack**
- **C#**  
- **Windows Forms (WinForms)**  
- **.NET Framework 4.7.2**  
- **System.IO** (File reading/writing)  
- **Binary Serialization** (Saving and restoring game progress)  
- **Embedded Resources** (audio + UI assets)

## 🚀 **How to Run**
- **Clone repo**
- **Open .sln file in Visual Studio**
- **Run the project (no setup needed)**
