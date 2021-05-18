using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Para manipular el punto de pivote
    public Transform pivot;

    //Rango para disparar
    public float springRange;
    //Velocidad maxima
    public float maxVel;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool canDrag = true;
    Vector3 dis;

    private void OnMouseDrag()
    {
        if (!canDrag)
            return;

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = pos - pivot.position;
        dis.z = 0;

        if(dis.magnitude > springRange)
        {
            dis = dis.normalized * springRange;
        }
        transform.position = dis + pivot.position;
    }

    private void OnMouseUp()
    {
        if (!canDrag)
            return;
        canDrag = false;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
    }

}
