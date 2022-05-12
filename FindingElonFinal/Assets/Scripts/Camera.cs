using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float timeOffset;

    public Vector2 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;

        //players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        
        //Lerping
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);


    }
}
