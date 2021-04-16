using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Cube cube = (Cube)target;

        // Change color 
        GUILayout.BeginHorizontal();
           if (GUILayout.Button("Change Color"))
           {
               cube.SetRandomColor();
           }
           if (GUILayout.Button("Reset Color"))
           {
               cube.ResetColor();
           }
        GUILayout.EndHorizontal();

        GUILayout.Label("Testing description");
        cube.size = EditorGUILayout.Slider("Cube size",cube.size, 0, 3);

        cube.transform.localScale = Vector3.one * cube.size;
    }

}
