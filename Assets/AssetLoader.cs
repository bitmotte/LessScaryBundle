using UnityEditor;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{

    void Awake()
    {
        AssetBundle bundle = AssetBundle.LoadFromFile("Assets/copy.bundle");   
        GameObject obj = Instantiate((GameObject)bundle.LoadAsset("Assets/Copy.prefab"));
        bundle.Unload(false);
    }
}
