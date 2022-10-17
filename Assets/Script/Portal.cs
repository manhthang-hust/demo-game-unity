using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollider2D(Collider2D coll)
    {
        if (coll.name == "statue") 
        {
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
