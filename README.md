# ArtificialAnimals
Competitive Multi-Agent Simulation for A.I. Class

Here's my final (group) project for the third-year class "Introduction to Artifical Intelligence".

In this project I attempted to create a 2-dimensional simulation of a very very very simplified forest ecosystem. The ecosystem consisted of Plants (Producers), Deer (Herbivores),
and Wolves that look a bit like foxes (Carnivores) as well as some abiotic features such as boulders and ponds. The inhabitants had the following properties and behaviors:

<h2>Producer's Properties:</h2> 

><strong>fullness</strong>
>
>A variable tracking plant hunger levels

><strong>hydration</strong>
>
>A variable tracking plant thirst

><strong>health</strong>
>
>A variable tracking plant well-being

><strong>age</strong>
>
>A counter tracking plant’s current time alive

><strong>threat</strong>

>A variable presenting the plant’s threat. Can fluctuate due to plant condition.

<h2>Producer's Functions:</h2>

><strong>Metabolize()</strong>
>
>Continuously drains plant fullness and hydration. If either is empty, drains health. If both are full, regenerates plant health/energy.

><strong>Photosynthesis()</strong>
>
>Plant specific method for slightly draining hydration in order to regain a moderate amount of fullness

><strong>Reproduce()</strong>
>
>Periodically spawn a new instance of the plant that called this method

><strong>Growth()</strong> *Unsure if using in Plant Type*
>- Increase sprite size (to a limit)
>- Modify max health and other stats
>- Discrete stage transitions
>   - Child
>   - Adult
>   - Elder (old)
>   - Death

<h2>Herbivore's Properties:</h2> 

><strong>fullness</strong>
>
>A variable tracking animal hunger levels

><strong>hydration</strong>
>
>A variable tracking animal thirst

><strong>health</strong>
>
>A variable tracking animal well-being

><strong>age</strong>
>
>A counter tracking animal’s current time alive

><strong>threat</strong>
>
>A variable presenting the animal’s threat. Can fluctuate due to animal condition.

><strong>vision</strong>
>
>A variable determining sight range

><strong>hearing</strong>
>
>A variable determining hearing range

><strong>diet</strong>
>
>A variable used to denote the type of “tag” an animal is looking for when searching for food

><strong>mood</strong>
>
>A variable that reflects the animal’s current mental state such as :
>- Hunted
>- Hungry/Thirsty
>- Null (Content)

><strong>energy</strong>
>
>A variable reflecting an animal’s current physical capability. Low energy should reduce threat and ability to sprint to/from danger.

><strong>speed</strong>
>
>Animal base speed


<h2>Herbivore's Functions:</h2>

><strong>Metabolize()</strong>
>
>Continuously drains animal fullness and hydration. If either is empty, drains health. If both full, regenerates creature health/energy. Calls Growth()

><strong>Graze()</strong>
>
>Used to move towards and eat the animal’s current focus for fullness, should only be called when close to food. (Called inside Movement() when Mood is ‘Hungry/Thirsty’)


><strong>Reproduce()</strong>
>
>Periodically spawn a new instance of the creature that called this method

><strong>Growth()</strong>
>
>- Increase sprite size (to a limit)
>- Modify max health and other stats
>- Discrete stage transitions
>   - Child
>   - Adult
>   - Elder (old)
>   - Death

><strong>Movement()</strong>
>
>A function to be used in conjunction with mood state to determine which type of movement will be used. Should enforce low-level obstacle avoidance.

><strong>Wander()</strong>
>
>Semi-random movement patterns, wandering with no set direction, but animals should want to stay together. (Called inside Movement() when Mood is ‘Null’)

><strong>Evade()</strong>
>
>Motivated movement pattern to flee from predators. (Called inside Movement() when Mood is ‘Hunted’)

><strong>Defend()</strong>
>
>When taking damage from a predator, gives a set amount back through struggling.


<h2>Carnivore's Properties:</h2>

><strong>fullness</strong>
>
>A variable tracking animal hunger levels

><strong>hydration</strong>
>
>A variable tracking animal thirst

><strong>health</strong>
>
>A variable tracking animal well-being

><strong>age</strong>
>
>A counter tracking animal’s current time alive

><strong>threat</strong>
>
>A variable presenting the animal’s threat. Can fluctuate due to animal condition.

><strong>vision</strong>
>
>A variable determining sight range

><strong>hearing</strong>
>
>A variable determining hearing range

><strong>diet</strong>
>
>A variable used to denote the type of “tag” an animal is looking for when searching for food

><strong>mood</strong>
>
>A variable that reflects the animal’s current mental state such as :
> - Hunted
> - Hungry/Thirsty
> - Null (Content)

><strong>energy</strong>
>
>A variable reflecting an animal’s current physical capability. Low energy should reduce threat and ability to sprint to/from danger.

><strong>speed</strong>
>
>Animal base speed

<h2>Carnivore's Functions:</h2>

><strong>Metabolize()</strong>
>
>Continuously drains animal fullness and hydration. If either is empty, drains health. If both full, regenerates creature health/energy. Calls Growth()


><strong>Hunt()</strong>
>
>Similar to Herbivore Graze() but includes pursuit of the prey. (Called inside Movement when Mood is ‘Hungry’)

><strong>Reproduce()</strong>
>
>Periodically spawn a new instance of the creature that called this method

><strong>Growth()</strong>
>
>Increase sprite size (to a limit)
> - Modify max health and other stats
> - Discrete stage transitions
>   - Child
>   - Adult
>   - Elder (old)
>   - Death

><strong>Movement()</strong>
>
>A function to be used in conjunction with mood state to determine which type of movement will be used. Should enforce low-level obstacle avoidance.

><strong>Wander()</strong>
>
>Semi-random movement patterns, wandering with no set direction, but animals should want to stay together and have a bias towards their current interests. (Called inside >Movement() when Mood is ‘Null’ or ‘Hungry/Thirsty’)

><strong>Attack()</strong>
>The opposite of defend, used actively to damage prey. Should be called from Hunt()


