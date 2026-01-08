
### Applying Collison

- Using RayCast we can check if there is something in front of the player,
- if there is something it returns true and we stop movement
- ex. `Physics.Raycast(transform.position, movementDirection, playerSize)`
- We take player position, Movement Direction and player size as max distance the raycast should happen,
- Note : it returns true only if we hit something so we can move while it is false.
- Raycast works by shooting infinitely thin laser towards the front. So, even it works it causes clipping if player is slightly offset to the object.
- To avoid this we use `CapsuleCast` which casts a Capsule.
- `CapsuleCast` takes Point A and Point B as input, point a bottom part of capsule, and point B top part of capsule.
- We can use player position for bottom and player head for the top.
- next we need radius of the `CapsuleCast` which we use previous `playerSize` renamed it to `playerRadius`.
- then we need the Cast Distance which we can calculate using speed*/time ex. `Time.deltaTime * moveSpeed`.
- ex . `Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHight, playerRadius, movementDirection, Time.deltaTime * moveSpeed`
- Now to make character move diagonally even when Colliding with box we use if else block to check if player can't move then try moving in X axis, else Try moving in Z axis.
- To move in specified direction we only take only specified axis input and store in our `movementDirection` ex . for X axis `Vector3 movementDirectionX = new Vector3(MovementDirection().x, 0, 0)`.

> **NOTE : We will later add Character Controller because current *Manual collision resolution* 
	 *Your current logic will fail when:
	- touching two colliders at once
	- moving diagonally into corners
	- frame rate fluctuates
	- stepping up/down small ledges
	- rotating while sliding
	- collider shapes change*