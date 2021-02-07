# ArtificialAnimals
Competitive Multi-Agent Simulation for A.I. Class

Here's my final (group) project for the third-year class "Introduction to Artifical Intelligence".

In this project I attempted to create a 2-dimensional simulation of a very very very simplified forest ecosystem. The ecosystem consisted of Plants (Producers), Deer (Herbivores),
and Wolves that look a bit like foxes (Carnivores). They had the following properties and behaviors:

<h2>Plant-type Variables:</h2> 

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

<h2>Plant-type Functions:</h2>

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
>  - Child
>  - Adult
>  - Elder (old)
>  - Death

