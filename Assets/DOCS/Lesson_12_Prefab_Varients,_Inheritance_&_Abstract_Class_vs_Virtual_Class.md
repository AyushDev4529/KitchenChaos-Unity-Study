>See Documentation for Prefab Variants and how to create it [Unity - Manual: Create variations of prefabs](https://docs.unity3d.com/6000.3/Documentation/Manual/PrefabVariants.html)

Now after making all our counters to prefab variants who has some base common prefab, with just transform and box collider,

we just need to reassign the `SerializeFields` again, and now our game should run just as before.

Now before continuing we want to assign responsibility to correct responsibility to each counter and generalize so player can pick kitchen object from any counter.
- Current Responsibility : 
	- `ContainerCounter` → spawns `KitchenObject` and acts as container, Can `Interact`
	- `ClearCounter` → assign functions later. Can `Interact`
	- `Player` → mediates pickup and placement
- Now in game there can be many counters and player can `Interact` with many, but we do not want to refactor our player class or counter scripts to add these functionality of interaction or implementing `IKitchenObjectParent` interface multiple times. 
- To avoid this we can do in multiple ways by creating a manager, implementing a new Interface etc. but we will do by implementing Inheritance.
> 	Note : Only implement Inheritance where it is needed and do not complicate the parent class.
- Now we can create a Base Class of Counter named `BaseCounter` which will have `IInteractable` & `IKitchenObjectParent` both interface implemented,
- `Interact()` should be `virtual` if a default behavior exists, or `abstract` if every counter must define its own interaction.

>An abstract class is a special type of class that cannot be instantiated directly. Instead, it serves as a blueprint for other classes. An abstract class may contain abstract methods, which are methods declared in the abstract class but must be implemented in concrete-derived classes.

```
public abstract class Vehicle
 {
   // Abstract method to be implemented in non-abstract child class
 public abstract void DisplayInfo();`
}
```

>Virtual methods are methods in a base class that have a default implementation but can be overridden in derived classes. The **virtual** keyword is used to declare a method as virtual. Derived classes use the **override** keyword to provide a specific implementation of the method, which helps to understand how a child class can override the virtual method of its parent.

```
// Non-abstract class
public class Animal
{
// Virtual method with a default implementation
public virtual void Speak()
{
Console.WriteLine("Some generic animal sound");
 }
 }
```
### Difference and When to Use
- Use abstract methods when all derived classes must provide their own implementation of a method.
- Use virtual methods when derived classes should have the option to override a default or provide additional behaviors.

Now make the both counter inherit from `BaseCounter` instead of `monobehaviour` and move `IKitchenObjectParent` interface and all its implemented methods in base class,

Implement `Interact()` method with an `override` keyword to override the default base class behavior,
and in this method implement `SpawnKitchenObject()` method and assign it directly to `player` as this counter is only responsible for spawning the `KitchenObject`,

Now in `player`.cs script change all the reference from `ClearCounter` to `CounterBase` now it plyer should show same behavior when its Raycast touches any `IInteractable` and `BaseCounter`.

Now Do the same for Selection Logic change reference from `ClearCounter` to `BaseCounter` also to avoid any reference error in visual in future implement a `GetComponentInParent<>();` for the `baseCounter` in `Awake()`

Now in Unity Inspector assign correct `SerializeField` reference and for more than one reference needed for  Selected Visual we can make it a type array ex `[SerializeField] private GameObject[] selectedVisualGameObjectArray;`
and to use it we can just use a `foreach` and move the method implementation inside it.
ex. 
```
foreach (GameObject selectedVisualGameObject in selectedVisualGameObjectArray)
{
    if (selectedVisualGameObject != null)
        selectedVisualGameObject.SetActive(false);
}
```

Now we have made the  code clean and easy to read and maintain in future and assigned each script in counter responsible for their own method and functionality.
later we will do so for player also,

Also if there is any requirement to increase the functionality in future we can improve our base class or use a new method by refactoring our code.