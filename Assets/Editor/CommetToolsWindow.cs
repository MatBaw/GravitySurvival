#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CometToolsWindow : EditorWindow
{
    private string cometName = "NewCometData";

    [MenuItem("Tools/Comet Tools")]
    public static void ShowWindow()
    {
        GetWindow<CometToolsWindow>("Comet Tools");
    }

    private void OnGUI()
    {
        GUILayout.Label("Utwórz ScriptableObject komety", EditorStyles.boldLabel);

        cometName = EditorGUILayout.TextField("Nazwa:", cometName);

        if (GUILayout.Button("Create CometData"))
        {
            CreateCometDataAsset(cometName);
        }
    }

    private void CreateCometDataAsset(string name)
    {
        var asset = ScriptableObject.CreateInstance<CometData>();

        string folder = "Assets/Data";
        if (!AssetDatabase.IsValidFolder(folder))
            AssetDatabase.CreateFolder("Assets", "Data");

        string path = AssetDatabase.GenerateUniqueAssetPath($"{folder}/{name}.asset");
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
#endif
