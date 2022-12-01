using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstPrefabS1 : MonoBehaviour
{
    void Awake()
    {
        //Item
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(-8, -4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(7, -4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemApple"), new Vector3(10, 1, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemGoldenSword"), new Vector3(-2, 4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/ItemLegendaryGoldenSword"), new Vector3(9, -6, 0), Quaternion.identity);
        //Chest
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(-5, -4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(-8, 4, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(10, 5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3((float)-0.5, (float)-2.5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Chest_golden"), new Vector3(6, -3, 0), Quaternion.identity);
        //Monster
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(-6, (float)-1.5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(-2, (float)-2.5, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(10, -2, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3((float)1.5, 3, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(-4, 3, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(6, -6, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3(6, 6, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("Prefabs/Monster_goblin"), new Vector3((float)-2.5, -6, 0), Quaternion.identity);
        // Map
        Instantiate(Resources.Load<GameObject>("Prefabs/HealthBuff"), new Vector3(3, 6, 0), Quaternion.identity);
    }
}
