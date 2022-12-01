using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstPrefabS2 : MonoBehaviour
{
    private void Awake()
    {
        //Item
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(10, -8, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(20, 1, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(29, -10, 0), Quaternion.identity);

        //Chest
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(14, -10, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(20, -6, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(17, -2, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(25, -1, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(33, -1, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(30, -5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(20, -13, 0), Quaternion.identity);
        //Monster
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(25, -5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(18, -11, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(20, -3, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(28, 0, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(32, -4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(31, -8, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(34, -10, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(31, -13, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(17, 0, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_golem"), new Vector3(15, -6, 0), Quaternion.identity);
        // Map
        Instantiate(Resources.Load<GameObject>("Prefabs/HealthBuff"), new Vector3(17, 3, 0), Quaternion.identity);
    }
}
