using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectPooler))]
public class ObjectPoolerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectPooler objectPooler = (ObjectPooler)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Initialize Pool"))
        {
            objectPooler.ObjectPoolInitialize();
            ObjectPooler.instance = objectPooler;
        }
        if (GUILayout.Button("Clear All Pool"))
        {
            objectPooler.UnActiveAllPool("Cube");
        }
        if (GUILayout.Button("RetrieveFromSpawn"))
        {
            objectPooler.RetrieveFromSpawn("Cube");
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Remove Pool Dictionary"))
        {
            objectPooler.RemovePoolDictionary();
        }
    }
}
