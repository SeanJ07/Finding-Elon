using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float timeOffset;

    public Vector2 posOffset;

    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float topLimit;
    internal static object main;

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


        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }
    void OnDrawGizmos()
    {
        //draw a box around our camera boundary
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit,topLimit),new Vector2(leftLimit, topLimit));
    }
}
