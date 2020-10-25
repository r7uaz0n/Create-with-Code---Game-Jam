using System.Collections;
using UnityEngine;

public class Room3Manager : MonoBehaviour
{
    [SerializeField] Trigger trigger1 = default;
    [SerializeField] Trigger trigger2 = default;
    [SerializeField] Trigger trigger3 = default;
    [SerializeField] Trigger trigger4 = default;
    [SerializeField] Trigger trigger5 = default;
    [SerializeField] Trigger trigger6 = default;

    [SerializeField] Material initialMaterial = default;
    [SerializeField] Material successMaterial = default;
    [SerializeField] Material failMaterial = default;

    [SerializeField] GameObject wall1 = default;
    [SerializeField] GameObject wall2 = default;

    [SerializeField] GameObject starIcon = default;
    [SerializeField] StarCounter starCounter;

    [SerializeField] GameObject directionalLight = default;

    [SerializeField] Room3SoundManager soundManager = default;

    Trigger[] triggers = default;
    bool[] triggerIds = { false, false, false, false, false, false };
    bool triggersBlocked = false;

    void Start()
    {
        NullChecks();
        triggers = new Trigger[] { trigger1, trigger2, trigger3, trigger4, trigger5, trigger6 };
        CheckKeyStatus();
    }

    public void playerTouched(int triggerId)
    {
        if (triggersBlocked)
        {
            return;
        }

        if (checkIfOrderIsCorrect(triggerId))
        {
            triggerIds[triggerId] = true;
            Trigger trigger = triggers[triggerId];
            trigger.gameObject.GetComponent<MeshRenderer>().material = successMaterial;
            if (triggers.Length - 1 == triggerId)
            {
                directionalLight.SetActive(true);
                Destroy(wall1);
                Destroy(wall2);
                soundManager.playRoomCompleteSound();
            }
            else
            {
                soundManager.playSuccessSound();
            }
        }
        else
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                Trigger trigger = triggers[i];
                trigger.gameObject.GetComponent<MeshRenderer>().material = failMaterial;
            }
            soundManager.playFailSound();
            StartCoroutine(resetMaterial());
            triggersBlocked = true;
            for (int i = 0; i < triggerIds.Length; i++)
            {
                triggerIds[i] = false;
            }
        }
    }

    bool checkIfOrderIsCorrect(int id)
    {
        if (0 == id)
        {
            return true;
        }

        for (int i = 0; i < id; i++)
        {
            if (false == triggerIds[i])
            {
                return false;
            }
        }

        return true;
    }

    void NullChecks()
    {
        if (!trigger1 || !trigger2 || !trigger3 || !trigger4 || !trigger5 || !trigger6)
        {
            Debug.LogError("At least one trigger is null.");
        }
        if (!initialMaterial || !successMaterial)
        {
            Debug.LogError("At least one material is null.");
        }
        if (!wall1 || !wall2)
        {
            Debug.LogError("At least one wall is null.");
        }
        if (!directionalLight)
        {
            Debug.LogError("directionalLight is null.");
        }
    }

    void CheckKeyStatus()
    {
        bool keyCollectionStatus = GameState.CheckKeyCollectionStatus(GameState.KeyId.Room3);
        for (int i = 0; i < triggers.Length; i++)
        {
            Trigger trigger = triggers[i];
            trigger.gameObject.SetActive(!keyCollectionStatus);
        }
        wall1.SetActive(!keyCollectionStatus);
        wall2.SetActive(!keyCollectionStatus);
        starIcon.SetActive(!keyCollectionStatus);
        directionalLight.SetActive(keyCollectionStatus);
    }

    IEnumerator resetMaterial()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < triggers.Length; i++)
        {
            Trigger trigger = triggers[i];
            trigger.gameObject.GetComponent<MeshRenderer>().material = initialMaterial;
        }
        triggersBlocked = false;
    }

}
