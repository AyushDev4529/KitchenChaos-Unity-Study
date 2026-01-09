
### Implementing Events,

> Currently our Interaction script is running every frame but we want to run when player indented to interact with the intractable object.

So we Create a new input Actions in `Player Action Map` named `Interaction` and Bind it to a key on keyboard or just bind it to `E` .

Now to Listen to the action we just need to update our `GameInput.cs` Script, 
First in Awake first we need to subscribe to the event happened when key pressed. 
for this we use `.Interaction.performed` key and to subscribe to the event we use `+=` sign for Ex. ` inputActions.Player.Interaction.performed += Interaction_performed`
here `Interaction_performed` is an function we pass to the event it works as an delegate who Invokes this event so in other scripts player or any other subscriber can subscribe to it.
> ==We will do a deep dive on Events and Delegates shortly.==

Now we need to make a delegate event handler ex ` public EventHandler OnInteractionAction;`, which is a c# standard given by `System`, You can also make you own delegate but this will suffice for our use.

And to can invoke this , to invoke the event in `Interaction_performed()` method we need to to use `?.Invoke(this,EventsArgs.Empty)` Keyword.

>Also` Interaction_Performed()` method can be created using nice shortcut in VS code by pressing **Tab** in visual studio.

If we are firing our event to avoid null reference exception, i.e. when there are no listeners. w just need to use an if statement to check if `OnInteractionAction != null`  only then fire the event.
or we can also use *Null Conditional  Operator* `?` which does the null check before firing the event ex. `OnInteractionAction?.Invoke(this, EventArgs.Empty);`.

Now we need to listen to this event in our `Player.cs` script
>NOTE: We generally listen to events in `Start()` this  ensure your listener is active and ready _after_ other objects are initialized but _before_ the main loop, setting up communication channels.

To listen to the event we just need to subscribe to the event and delegate to event handler ex. ` gameInput.OnInteractionAction += GameInput_OnInteractionAction;`
Now move the `HandleInteract()` method from `Update()` to subscribed `GameInput_OnInteractionAction()`method.