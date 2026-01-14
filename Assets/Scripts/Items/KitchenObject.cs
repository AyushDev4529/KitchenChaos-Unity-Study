using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    // Other properties and methods related to KitchenObject can be added here
    public ClearCounter clearCounter;

    // Method to get the KitchenObjectSO
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    // Method to set the ClearCounter
    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;
        // Check if the ClearCounter already has a KitchenObject
        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a kitchen object!");
        }

        this.clearCounter.SetKitchenObject(this);
        gameObject.transform.parent = clearCounter.GetKitchenObjectFollowNewCounter().transform;
        gameObject.transform.localPosition = Vector3.zero;
    }

    // Method to get the ClearCounter
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
