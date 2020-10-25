using UnityEngine;
using TMPro;

public class RoomThreeManager : MonoBehaviour
{
    [SerializeField] Trigger trigger1 = default;
    [SerializeField] Trigger trigger2 = default;
    [SerializeField] Trigger trigger3 = default;
    [SerializeField] Trigger trigger4 = default;
    [SerializeField] Trigger trigger5 = default;
    [SerializeField] Trigger trigger6 = default;

    [SerializeField] Material purpleMaterial = default;
    [SerializeField] Material greenMaterial = default;

    [SerializeField] GameObject wall1 = default;
    [SerializeField] GameObject wall2 = default;

    [SerializeField] StarCounter starCounter;

    [SerializeField] GameObject directionalLight = default;

    private Trigger[] triggers = default;
    private bool[] triggerIds = { false, false, false, false, false, false };

    void Start()
    {
        NullChecks();
        directionalLight.SetActive(false);
        triggers = new Trigger[] { trigger1, trigger2, trigger3, trigger4, trigger5, trigger6 };
    }

    public void playerTouched(int triggerId)
    {
        if (checkIfOrderIsCorrect(triggerId))
        {
            triggerIds[triggerId] = true;
            Trigger trigger = triggers[triggerId];
            trigger.gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
            if (triggers.Length - 1 == triggerId)
            {
                directionalLight.SetActive(true);
                Destroy(wall1);
                Destroy(wall2);
            }
        }
        else
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                Trigger trigger = triggers[i];
                trigger.gameObject.GetComponent<MeshRenderer>().material = purpleMaterial;
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
        if (!purpleMaterial || !greenMaterial)
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
}
