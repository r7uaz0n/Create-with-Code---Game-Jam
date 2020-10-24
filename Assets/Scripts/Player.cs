using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;

    public bool hasPick;
    private GameObject Pick;
    private Animation anim;

    private void Start()
    {
        hasPick = false;
        Pick = GameObject.Find("Pick");
        anim = Pick.GetComponent<Animation>();
    }
    void Update()
    {
        UpdateMovement();
        SwingPick();
    }

    private void UpdateMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float deltaX = inputX * Time.deltaTime * speed;
        float deltaZ = inputZ * Time.deltaTime * speed;

        Vector3 movement = new Vector3(deltaX, 0.0f, deltaZ);
        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickPowerup"))
        {
            hasPick = true;
            Destroy(other.gameObject);
        }

    }

    void SwingPick()
    {
        if (hasPick == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play();
        }
    }
    
}

////References
//https://answers.unity.com/questions/1086481/how-do-you-write-a-script-for-swinging-a-sword-or.html