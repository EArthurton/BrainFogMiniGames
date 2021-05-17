using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    public static string previousLevel;
    private void OnDestroy()
    {
        previousLevel = gameObject.scene.name;
    }
}
