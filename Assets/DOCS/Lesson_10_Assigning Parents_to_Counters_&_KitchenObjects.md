
>The Goal is to make sure there are no items are laying around the world, if we spawn a kitchen object it knows who owns it and the owner also knows who owns this kitchen object, if the kitchen object leaves the counter we do not have to manually check our world again if counter is empty or not, and who is the new owner of the kitchen object.

To do that we need to add below in `ClearCounter.cs` 
- first create a variable to reference our kitchen object of type `KitchenObject`
- then when player interact, check for if kitchen object is already not on the counter, ex `if(kitchenObject == null)`
- if yes then `Instantiate` the kitchen object and `GetComponent` of `Instantiate` game object,
- ex `kitchenObject = kitchenObjectInstance.GetComponent<KitchenObject>();`
Now we have set the clear counter object so it knows and owns the `kitchenObject`.

And Now we add below in `KitchenObject` Script so it also know where it is and who owns it.
- Set a field for `ClearCounter`,
- and two functions `setClearCounter()` & `getClearCounter()`;
- Both need to be public to be accessible by the owner of the `kitchenObject`.
- To set the Clear counter we need the reference to the clear counter so we pass the parameter of type `ClearCounter`, and set `clearCounter` to `this.clearCounter`.
- Now we Get the `ClearCounter` by simply returning the `clearCounter`.

Now Counter Knows Kitchen Object is on it and Kitchen Object Knows that it is on Counter.