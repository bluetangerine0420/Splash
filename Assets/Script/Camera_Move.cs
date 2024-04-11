using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public int move_speed;
    public float zoom_speed;

    public CinemachineVirtualCamera CM;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * move_speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);//3.9
        else if(transform.position.y >10) transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        if (transform.position.x <-24) transform.position = new Vector3(-24, transform.position.y, transform.position.z);//-0.5
        else if (transform.position.x > 25.2f) transform.position = new Vector3(25.2f, transform.position.y, transform.position.z);
       

        //float zoom = Input.GetAxis("Mouse ScrollWheel");
        //CM.m_Lens.OrthographicSize -= zoom * zoom_speed;

    }
}
