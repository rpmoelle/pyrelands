using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadWorld : MonoBehaviour {
    AsyncOperation async;
    //public static AsyncOperation LoadSceneAsync(string sceneName, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);
    // Use this for initialization
    /*LoadLevelAsync returns an AsyncOperation object.
Set the allowSceneActivation flag in it to false.
Wait for for the AsyncOperation.progress to reach 0.9 (this is as far as it will get - scene loaded but not activated. Then set .allowSceneActivation to true when you want the scenes to actually switch*/
    public void ActivateScene()
    {
        Debug.Log("Next Scene");
        async.allowSceneActivation = true;
    }

    IEnumerator Start()
    {
        async = Application.LoadLevelAsync("world");
        async.allowSceneActivation = false;
        Debug.Log("Loading complete");
        yield return async;    
    }

    
}
