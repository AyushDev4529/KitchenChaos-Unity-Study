
In C#, an **interface** ==defines a **contract** that classes or structs can implement==. It specifies what members a type must provide (methods, properties, events, indexers) but, traditionally, not how they are implemented. 

Key Characteristics

- **Contract Definition**: An interface acts as a blueprint, guaranteeing that any type implementing it will have specific public members.
- **Abstraction**: Interfaces help achieve full abstraction by separating the definition of behavior from the implementation details, which reduces code complexity and improves maintainability.
- **Multiple Inheritance**: C# does not support multiple inheritance of classes, but a class can implement multiple interfaces, allowing it to inherit functionality from multiple sources.
- **Loose Coupling and Dependency Injection**: Interfaces enable the creation of loosely coupled systems. Code can interact with objects through their interface type rather than their concrete class, making it easier to swap implementations (e.g., for unit testing with mocks).
- **Default Members (C# 8.0+)**: Starting with C# 8.0 and .NET Core 3.0, interfaces can contain default implementations for members. This allows adding new members to an interface without breaking existing implementing classes.
- **Naming Convention**: By convention, interface names start with the capital letter "I" (e.g., `IAnimal`, `IDisposable`).

To make an Interface we first need to identify the requirement.
our player or any other entity that can interact with other game object must implement, an interface named `IInteractable` which has an empty method defined e.g. `public void Interact(GameObject interactor);`,
So any class implementing this Interface must implement this method which could be anything from spawning to calling an event for a animation etc.
For our  case we use it for `ClearCounter`, 
And in future every type of interactable counter should implement this interface.
now in `ClearCounter` the interactable implements the `Interactable(GameObject interactor)` method where if interacted calls the method for `SpawnKitchenObject()`
and when Interacted again transfers the Kitchen Object to the interactor.

==To implement Interface, we just extend the class to use  the Interface just like `MonoBehaviour` if there is already a extended class just add a `,` and write the interface name for our case `IInteractable`==

Now just like this we implement the Interface for transfer of `kitchenObject` parent.
this new interface named `IKitchenObjectParent` should include basic methods which all parent class should include.

- such as `GetKitchenObjectAttachPoint()` for getting the transform of attach point.
>this will be an empty object attached to parent object.
- a method to get and set `KitchenObject`.
- a bool to check if parent `HasKitchenObject()`
- and a method to clear the `KitchenObject()`

now these methods we implement both in player and counter, while adding the interface,

Now in `ClearCounter` we implement the interface functions,
- for `GetKitchenObjectAttachPoint()` we return a `GameObject` `counterTop` and `playerHand` for player interface
- for setting `KitchenObject` we set the `this.kitchenObject = kitchenObject`
- get the `kitchenObject` by returning the `kitchenObject`.
- for `HasKitchenObject()` we return `kitchenObject != null`
- and to `ClearKitchenObject` we set `kitchenObject = null`.

Similarly we implement these for `Player`.

