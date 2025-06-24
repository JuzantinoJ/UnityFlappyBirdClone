using UnityEditor;

public class BuildScript
{
    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/MainScene.unity" }, // Adjust if your scene is named differently
            "Build/WebGLBuild",                         // Output directory
            BuildTarget.WebGL,
            BuildOptions.None
        );
    }
}
