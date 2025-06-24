# Flappy Bird Clone (Unity)

A simple Flappy Bird-style game made in Unity using C#. This project includes basic bird movement, pipe spawning, and infinite scrolling obstacles.

## 🎮 Features

- Bird flaps upward when spacebar is pressed
- Pipes spawn at regular intervals
- Pipes move from right to left
- Beginner-friendly Unity and C# structure

## 🛠️ How to Run

1. Open Unity Hub
2. Add this project folder
3. Open the scene named `MainScene.unity` (or your scene)
4. Press ▶️ (Play) to start the game

## 📁 Project Structure

```bash
Assets/
├── Scripts/
│   ├── BirdScript.cs
│   ├── PipeMoveScript.cs
│   └── PipeSpawnScript.cs
├── Prefabs/
│   ├── Pipe.prefab
│   └── Bird.prefab
├── Scenes/
│   └── MainScene.unity
```

## 🐳 Docker Build Support

This project supports Docker for consistent Unity builds without installing Unity locally.

### 🛠 Requirements

- [Docker](https://www.docker.com/get-started) installed

### 📦 Step 1: Build the Docker Image

```bash
docker build -t unity-flappy .
```

### 🚀 Step 2: Build the Unity Project to WebGL

```bash
docker run -it --rm \
  -v $(pwd)/Build:/app/Build \
  unity-flappy \
  /opt/unity/Editor/Unity \
  -quit -batchmode -nographics \
  -projectPath /app \
  -buildTarget WebGL \
  -executeMethod BuildScript.BuildWebGL
```
