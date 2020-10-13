using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

  //  public GameObject focalPoint;
    public GameObject HealingPotion;
    public Rigidbody playerRb;
   // public Explosion;

    public bool isOnGround = true;
    public bool hasPowerUp = false;
    public bool isAlive = true;

    public int healthPoints = 100;

    //public float jumpHigh = 5f;
   // public float speed = 5.0f;
    public float powerUpStrenght = 15.0f;
    public float powerUpSpeed = 5f;
    public float explosionRadius = 5f;
    public float explosionPower = 5f;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       // focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {

        /* float forwardInput = Input.GetAxis("Vertical");

         playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
         powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

         if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
         {
             playerRb.AddForce(Vector3.up * jumpHigh, ForceMode.Impulse);
             isOnGround = false;
         } */


        /* if (hasPowerUp)
         {
             playerRb.AddForce(playerRb.transform.forward * powerUpSpeed * forwardInput);
         }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
           // powerUpIndicator.gameObject.SetActive(true);
            // speedUpIndicator.gameObject.SetActive(true);

        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(4);
        hasPowerUp = false;
      //  powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemyRigibody.gameObject.transform.position - transform.position;

            Debug.Log("Player collided with: " + collision.gameObject +
                " with powerup set to " + hasPowerUp);
            enemyRigibody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            /*  Vector3 direction = transform.position - collision.transform.position;
              direction.Normalize();
              float waveStrenght = 5f;
              GetComponent<Rigidbody>().AddForce(direction * waveStrenght, ForceMode.Impulse);
             */

            isOnGround = true;
        }


    }
}
