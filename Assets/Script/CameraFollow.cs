using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;

    public float smoothTime = 0.1f;

    public Vector2 refVelovity;

    public float maxSpeed = 250f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, Player.transform.position.x, ref refVelovity.x, smoothTime, maxSpeed);
        float posY = Mathf.SmoothDamp(this.transform.position.y, Player.transform.position.y, ref refVelovity.y, smoothTime, maxSpeed);
        this.transform.position = new Vector3(posX, posY, transform.position.z);
    }

}
