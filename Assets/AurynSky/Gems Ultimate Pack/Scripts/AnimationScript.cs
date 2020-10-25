using UnityEngine;

public class AnimationScript : MonoBehaviour {

    [SerializeField] Player player = default;
    [SerializeField] GameState.KeyId keyId = default;
    bool wasCollected = false;

    // Animation status in general
    [SerializeField] bool isAnimated = false;
    [SerializeField] bool isRotating = false;
    [SerializeField] bool isFloating = false;
    [SerializeField] bool isScaling = false;

    // Rotation
    [SerializeField] Vector3 rotationAngle;
    [SerializeField] float rotationSpeed;

    // Floating
    [SerializeField] float floatSpeed;
    bool goingUp = true;
    [SerializeField] float floatRate;
    float floatTimer;

    // Scaling
    [SerializeField] Vector3 startScale;
    [SerializeField] Vector3 endScale;
    bool scalingUp = true;
    [SerializeField] float scaleSpeed;
    [SerializeField] float scaleRate;
    private float scaleTimer;

    void Update () {
        
        if(isAnimated)
        {
            if(isRotating)
            {
                Vector3 rotation = rotationAngle * rotationSpeed * Time.deltaTime;
                rotation *= wasCollected ? 15 : 1;
                transform.Rotate(rotation);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (!wasCollected && goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }
                else if(!wasCollected && !goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if(!wasCollected && isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (null != player && player.gameObject.name == collider.gameObject.name)
        {
            wasCollected = true;
            GameSoundManager.instance.PlayStarLiftoffSound();
            GameState.CollectKeyWith(keyId);
            floatSpeed = Mathf.Abs(floatSpeed);
        }
    }
}
