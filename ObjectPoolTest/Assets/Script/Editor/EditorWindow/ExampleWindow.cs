using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    Color color;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Colorizer");
    }

    public void OnGUI()
    {
        GUILayout.Label("Color selected object ",EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("color", color);

        if (GUILayout.Button("Change color"))
        {
            Colorize();
        }
    }

    private void Colorize()
    {
        foreach (GameObject gameObject in Selection.gameObjects)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            if (renderer)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
