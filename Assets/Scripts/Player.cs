using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f;

    void Update()
    {
        UpdateMovement();
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
}
