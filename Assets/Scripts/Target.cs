using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    
    public ParticleSystem explosionParticle;
    public int pointValue;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //assigning reference to game manager to add score when targets are destroyed
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //adding upward force multiplied by randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //adding torque with randomized xyz values
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //creating random place for different objects to spawn
        transform.position = RandomSpawnPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     //to destroy game object
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);

        //for particle explosion
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        //to call gameManager.GameOver() if target collides with sensor
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    //new functions
    Vector3 RandomForce ()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
