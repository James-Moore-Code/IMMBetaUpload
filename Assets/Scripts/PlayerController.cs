using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 20.0f;
    public static int lives;
    public static int score;
    public static int kills;
    private bool itemHeld = false;
    private bool isSuper = false;
    public int howManyHeld;
    private float delayAttackTime = 60.0f;
    private Rigidbody playerRb;
    public Animator playerAnim;

    private AudioSource playerAudio;
    public AudioClip clownSound;
    public AudioClip teaSound;
    public AudioClip superSound;
    public AudioClip hatterSound;

    public ParticleSystem skidParticle;
    public ParticleSystem bloodParticle;
    public ParticleSystem superParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        lives = 3;
        score = 0;
        kills = 0;
        howManyHeld = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        delayAttackTime -= 1.0f;
    }

    void MovePlayer()
    {
        //Get the horizontal and vertical input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        //fix look rotation error: viewing vector is zero. with if statement
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        //Move the player
        
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        playerRb.AddForce(Vector3.forward * speed * verticalInput);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("IsRunning", true);
        }
        else
            playerAnim.SetBool("IsRunning", false);

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            skidParticle.Play();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isSuper)
        {
            if (delayAttackTime <= 0)
            {
                delayAttackTime = 60.0f;
                lives -= 1;
                Debug.Log("Life: " + lives);
                itemHeld = false;
                playerAudio.PlayOneShot(clownSound, 1.0f);
                howManyHeld = 0;
                bloodParticle.Play();
            }

            if (lives <= 0)
            {
                Debug.Log("Life: " + lives + ". Score: " + score + ". GameOver!!!");
                GameOver();
            }
        }
        else if(collision.gameObject.CompareTag("Enemy") && isSuper)
        {
            Destroy(collision.gameObject);
            kills += 1;
        }

        if (collision.gameObject.CompareTag("DropZone") && itemHeld == true)
        {
            itemHeld = false;
            score += howManyHeld;
            Debug.Log("Score: " + score);
            playerAudio.PlayOneShot(hatterSound, 1.0f);
            howManyHeld = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            itemHeld = true;
            howManyHeld += 1;
            Debug.Log("Bring the food to youre family!!!");
            playerAudio.PlayOneShot(teaSound, 1.0f);
        }
        else if (other.gameObject.CompareTag("superPickUp"))
        {
            Destroy(other.gameObject);
            Debug.Log("Feel the power!!!");
            superParticle.Play();
            playerAudio.PlayOneShot(superSound, 2.0f);
            isSuper = true;
            speed = 30.0f;
            StartCoroutine(PowerupCountdownRoutine());
        }

    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        isSuper = false;
        speed = 20.0f;
        superParticle.Stop();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}