using UnityEngine;

public interface IKitchenObjectParent
{
    public GameObject GetKitchenObjectAttachPoint();
    public KitchenObject GetKitchenObject();
    public void SetKitchenObject(KitchenObject kitchenObject);
    public bool HasKitchenObject();
    public void ClearKitchenObject();

}
