>Start with one kitchen game object and generalize later.

First create a kitchen object prefab, and in clear counter using a `[SerializeField]` reference the kitchen object visual. 
ex`[SerializeField] private Transform tomato`
And to spawn it on top of counter visual we create a new empty object with positioned top of the counter visual prefab and reference it in script., ex. `[SerializeField] private Transform counterTopTransform`

Then we simply spawn the kitchen game object on top of the `counterTopTransform`.
To Spawn game objects at runtime we use **`Instantiate()`**  This is essential for creating dynamic elements like projectiles, enemies, or power-ups during gameplay, rather than placing them all in the scene manually beforehand.
ex. 
```
// Spawns at the spawner object's position with default rotation (Quaternion.identity)
Instantiate(objectToSpawn, transform.position, Quaternion.identity); 
```
Not to spawn exactly on top of the spawn point we change the `localPosition` to `Vector3.Zero` ex. `tomatoTransform.localPosition = Vector3.zero`
Now in game when you interact with the counter visual.

Now to generalize so we do not have to manually define and assign each kitchen object we use scriptable objects.
>Scriptable Objects in Unity are ==data containers that allow developers to **store data and behavior separately from GameObjects**==. They exist as assets in the project, not components in a scene, making them ideal for creating data-driven architectures, managing large amounts of shared data, and reducing memory usage.
---

To make scriptable objects make a new c# script and name it `KitchenObjectSO`, append it with SO for scriptable objects.

In this new `KitchenObjectSO` make it child of `ScriptableObject` ex, `public class KitchenObjectSO : ScriptableObject
`
Now define an scriptable object property above the class with `[CreateAssetMenu()]`
 add fields inside the class which will hold information about the game object.
like transform or game object, sprite of the item for when dropped or and object Name ,
ex.
```
 public Transform prefab;
 public Sprite objectSprite;
 public string objectName;
```
Now in asset menu create a scriptable game object of type `KitchenObjectSO` in assets folder.
Open the scriptable object in inspector and assign the prefab, sprite and object name.

Now in `ClearCcounter.cs` script change the tomato prefab and add a reference of `KitchenObjectSO` and to spawn it replace spawn object with `kitchenObjectSO.prefab`.

Now when interaction with counter *tomato* should spawn or any assigned prefab.

To get what prefab we are spawning we can just assign new script to all the kitchen object prefabs, named `KitchenObjects.cs` which contain a method to get the `KitchenObjectSO`, and return the `kitchenObjectSO` which we will take reference with help of `[SerializeField]`.
and make sure to assign correct scriptable object to the corresponding prefab.
