using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemsDB_SO), editorForChildClasses: true)]
public class ItemsDB_SO_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ItemsDB_SO database = target as ItemsDB_SO;
        if (GUILayout.Button("GenerateDatabase"))
            database.CollectItemsFromFolder();
    }
}