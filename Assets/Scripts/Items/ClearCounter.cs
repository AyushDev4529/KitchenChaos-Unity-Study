using System;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IInteractable, IKitchenObjectParent
{
    [SerializeField] private GameObject counterTop;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private KitchenObject kitchenObject;

    public void Interact(GameObject interactor)
    {
        // Try to get the Player component from the interactor GameObject
        Player player = interactor.GetComponent<Player>();
        if (player != null)
        {
            SpawnKitchenObject(player);
        }
        else
        {
            Debug.LogWarning("Interactor does not have a Player component.");
        }
    }

    private void SpawnKitchenObject(Player player)
    {

        if (kitchenObject == null)
        {
            GameObject kitchenObjectInstance = Instantiate(kitchenObjectSO.prefab, counterTop.transform);
            // Set the local position to zero to align it with the counter top
            kitchenObjectInstance.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
        else
        {
            if (!player.HasKitchenObject())
                kitchenObject.SetKitchenObjectParent(player);
        }
    }


    public GameObject GetKitchenObjectAttachPoint()
    {
        return counterTop;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
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