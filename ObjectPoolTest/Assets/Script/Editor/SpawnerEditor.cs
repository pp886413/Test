using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Spawner spawner = (Spawner)target;

        if (GUILayout.Button("Get Pool Object"))
        {
            spawner.GetObject();
        }

    }

}
