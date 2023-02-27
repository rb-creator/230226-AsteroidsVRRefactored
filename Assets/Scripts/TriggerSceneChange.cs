using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange : MonoBehaviour
{
    public int sceneNumber;
    public SceneTransitionManager transitionManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            transitionManager.GoToSceneAsync(sceneNumber);
    }
}
