using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;
    private ContainerCounter containerCounter;
    private const string OPEN_CLOSE = "OpenClose";

    private void Awake()
    {
        
       if (containerCounter == null)
            containerCounter = GetComponentInParent<ContainerCounter>();

       if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;

    }
    private void OnDestroy()
    {
        containerCounter.OnPlayerGrabbedObject -= ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
