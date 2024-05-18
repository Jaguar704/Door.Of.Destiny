using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetParentByName : EditorWindow
{
    private string gameObjectNameToFind = "GameObjectName"; // Change this to the name of the GameObject you want to find
    private GameObject newParent;

    [MenuItem("SetParent/Set Parent By Name")]
    static void Init()
    {
        SetParentByName window = (SetParentByName)EditorWindow.GetWindow(typeof(SetParentByName));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Enter GameObject name to find:");
        gameObjectNameToFind = EditorGUILayout.TextField(gameObjectNameToFind);

        EditorGUILayout.Space();

        if (GUILayout.Button("Set Parent"))
        {
            SetParentToGameObject();
        }
    }

    void SetParentToGameObject()
    {
        newParent = new GameObject();
        List<GameObject> gameObjects = new();
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allGameObjects)
        {
            if(obj.name == gameObjectNameToFind)
            gameObjects.Add(obj);
        }
        
        if (gameObjects.Count == 0)
        {
            Debug.LogWarning("No GameObject found with the name: " + gameObjectNameToFind);
            return;
        }

        foreach (GameObject go in gameObjects)
        {
            go.transform.SetParent(newParent.transform);
        }

        Debug.Log("Set parent to " + newParent.name + " for GameObjects with the name: " + gameObjectNameToFind);
    }
}