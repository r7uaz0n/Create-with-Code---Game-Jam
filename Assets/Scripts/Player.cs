using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    public GameObject pickPrefab;
    public bool hasPick;

    private void Start()
    {
        hasPick = false;
    }
    void Update()
    {
        UpdateMovement();
        pickPrefab.SetActive(false);
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
        if (other.CompareTag("Pick"))
        {
            pickPrefab.SetActive(true);
            hasPick = true;
            Destroy(other.gameObject);
        }

    }

    private void SwingPick()
    {
 
    }
    //pickTransform = transform.Find("Pick");
    //pickTransform.transform.localPosition = Vector3.Slerp(pickTransform.localPosition, new Vector3(1, 0, 1), 0.01f);
}

