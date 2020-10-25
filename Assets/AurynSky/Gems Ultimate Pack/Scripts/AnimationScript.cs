using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class AnimationScript : MonoBehaviour {

    [SerializeField] private Player player = default;
    [SerializeField] private GameState.KeyId keyId = default;

    public bool isAnimated = false;

    public bool isRotating = false;
    [SerializeField] private bool isFloating = false;
    public bool isScaling = false;

    public Vector3 rotationAngle;
    public float rotationSpeed;

    public float floatSpeed;
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;
   
    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;

    public bool wasCollected = false;

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
            GameState.collectKeyWith(keyId);
            floatSpeed = Mathf.Abs(floatSpeed);
        }
    }
}
