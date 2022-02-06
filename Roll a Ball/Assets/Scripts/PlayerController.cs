using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject loseText;
    public GameObject menu;

    public GameObject confetti;

    public GameObject ballBroken;

    public float speed = 10;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winText.SetActive(false);


        loseText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private void Update()
    {
        if (transform.position.y < -5)
        {
            loseText.SetActive(true);
            gameObject.SetActive(false);
            menu.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count += 1;


            GameObject colected = Instantiate(confetti, other.transform.position, Quaternion.Euler(-90,0,0));
            Destroy(colected, 2f);


            SetCountText();
        }

        if (other.gameObject.CompareTag("Obstacle"))    
        {
            loseText.SetActive(true);
            menu.SetActive(true);
            gameObject.SetActive(false);
            GameObject frac = Instantiate(ballBroken, transform.position, transform.rotation);
            Destroy(frac, 4f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            winText.SetActive(true);
            menu.SetActive(true);
            speed = 0;
        }
    }

}
