/* Latency data
 * Add life system
 * add position relative to lilypad. **Done
 * create a path rather than randomly generating lilypads. **Done
 * 
 * 
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float moveHorizontal;
    private float moveVertical;
    private float speed = 1f;
    private float jumpForce = 1000f;

    private bool alive = true;
    private bool start = false;
    private bool victory = false;

    public int lilyCount;
    public int lives = 3;

    // Create a string, and it can only contain integers.
    public string jumpOrder;

    private Rigidbody rb;
    private Vector3 startPos;

    public GameObject gameOverText;
    public GameObject victoryText;

    // Use this for initialization
    void Start () {
        startPos = rb.position;
        victoryText.SetActive(false);           //Disable text objects.
        gameOverText.SetActive(false);
        rb = GetComponent<Rigidbody>();         //Grant rigidbody component.
        rb.isKinematic = true;                  //Do not start moving yet.
    }

    // Update is called once per frame
    void Update () {
        //Start the Game by enabling the rigidbody.
        if(Input.GetKeyDown("2") && !start)
        {
            start = true;
            rb.isKinematic = false;
        }
    }

    private void FixedUpdate()
    {
        //Move around while player is alive.
        if (alive)
        {
            if(!start || victory)                                               //Cannot move w/o start or has gotten victory.
            {
                moveHorizontal = 0;
                moveVertical = 0;
            }
            else
            {
                moveHorizontal = Input.GetAxis("Horizontal") * speed;           //Move using arrow keys
                moveVertical = Input.GetAxis("Vertical") * speed;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);    //Move the object

            rb.position += movement;
        }

        //Reset the Game.
        if(Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(0);      //Reloading the same scene.
        }
    }

    //Player makes contact with an object
    private void OnTriggerEnter(Collider other)
    {
        //Player jumps on LilyPad.
        if(other.CompareTag("LilyPad"))
        {
            Vector3 lilyPos = other.transform.position;
            Vector3 playerPos = gameObject.transform.position;
            Vector3 relativePos = lilyPos - playerPos;

            float fromCenter = Mathf.Sqrt(relativePos.x * relativePos.x + relativePos.y * relativePos.y);

            string lilyName = other.name;
            
            switch(lilyName)
            {
                case "LilyPad":
                    jumpOrder = "/1," + fromCenter;
                    break;
                case "LilyPad (1)":
                    jumpOrder += "/2," + fromCenter;
                    break;
                case "LilyPad (2)":
                    jumpOrder += "/3," + fromCenter;
                    break;
                case "LilyPad (3)":
                    jumpOrder += "/4," + fromCenter;
                    break;
                case "LilyPad (4)":
                    jumpOrder += "/5," + fromCenter;
                    break;
                case "LilyPad (5)":
                    jumpOrder += "/6," + fromCenter;
                    break;
                case "LilyPad (6)":
                    jumpOrder += "/7," + fromCenter;
                    break;
                case "LilyPad (7)":
                    jumpOrder += "/8," + fromCenter;
                    break;
                case "LilyPad (8)":
                    jumpOrder += "/9," + fromCenter;
                    break;
                case "LilyPad (9)":
                    jumpOrder += "/10," + fromCenter;
                    break;
                case "LilyPad (10)":
                    jumpOrder += "/11," + fromCenter;
                    break;
                default:
                    jumpOrder += "/0," + fromCenter;
                    break;
            }
            lilyCount++;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(transform.up * jumpForce);
            other.gameObject.SetActive(false);
        }
        //Player falls on River.
        else if(other.CompareTag("River"))
        {
            Debug.Log("River");
            lives--;
            if(lives > 0)
            {
                gameObject.transform.position = startPos;
                GameObject[] offedObjects = GameObject.FindGameObjectsWithTag("LilyPad");
                for (int i = 1; i <= offedObjects.Length; i++)
                {
                    offedObjects[i].SetActive(true);
                }
            }
            else
            {
                GameOver();
            }
        }
        //Player falls on RiverBank.
        else if(other.CompareTag("RiverBank"))
        {
            Debug.Log("RiverBank");
            Pass();
        }
    }

    //Player passes the game.
    private void Pass()
    {
        rb.isKinematic = true;                      //Disable rigidbody to stop gravity.
        victory = true;                             //Confirm victory.
        victoryText.SetActive(true);                //Activate Victory Text.
    }

    //Player fails the game.
    private void GameOver()
    {
        rb.isKinematic = true;                      //Disable rigidbody to stop gravity.
        gameOverText.SetActive(true);               //Activate Game Over Text.
        alive = false;                              //Player is no longer alive.
    }
}

 */