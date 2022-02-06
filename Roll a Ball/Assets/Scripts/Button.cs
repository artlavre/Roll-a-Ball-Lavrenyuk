using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Color myColor, myColor2;
    MeshRenderer render;
    private Color reach;
    public GameObject box;
    public Transform maxPoint, minPoint;

    void Start()
    {
        reach = myColor;
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.material.color = Color.Lerp(render.material.color, reach, 0.05f);
        if(box.transform.position.y > minPoint.position.y && reach !=myColor2)
        {
            box.transform.position -= box.transform.up * Time.deltaTime * 2;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Push"))
        {
            reach = myColor2;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Push"))
        {
            reach = myColor2;
            if (box.transform.position.y < maxPoint.position.y)
            {
                box.transform.position += box.transform.up * Time.deltaTime * 2;
            }
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Push"))
        {
            reach = myColor;
        }
    }
}

