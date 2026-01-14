using System;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject counterTop;
    [SerializeField] private ClearCounter SecondCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private KitchenObject kitchenObject;


    [SerializeField] private bool IsTesting;
    public void Interact(GameObject interactor)
    {
        SpawnKitchenObject();
    }

    private void Update()
    {
        if (IsTesting && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(SecondCounter);
            }
        }

    }

    private void SpawnKitchenObject()
    {

        if (kitchenObject == null)
        {
            GameObject kitchenObjectInstance = Instantiate(kitchenObjectSO.prefab, counterTop.transform);
            // Set the local position to zero to align it with the counter top
            kitchenObjectInstance.GetComponent<KitchenObject>().SetClearCounter(this);

        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
    }

    public GameObject GetKitchenObjectFollowNewCounter()
    {
        return counterTop;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
}
