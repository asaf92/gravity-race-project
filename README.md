# Gravity Race

Gravity Race is a Unity3D project I made for my Computer's Science Graphics course. 
This is a racing game where the hook is that the default gravity has been replaced by objects that behave as gravity sources.

## Intro
In this document I will go over my progress making this game, explain the method of operation and show images/gifs from the game

## My Progress
### Begining
I started this project with no previous Unity3D experience. I did however implement a basic graphics engine (https://github.com/asaf92/computer-graphics-project) so I had knowledge of computer graphics.
I saw many different guides and started some "tutorial projects". The first thing I did was a normal racing game:
![](https://i.ibb.co/c6z5G6d/image.png)
After getting used to Unity3D and learning how to apply the coding practices I know in Unity (such as DI, Unit-Testing, etc...) I moved on to the real game

### Physics
After disabling the default gravity from all the `RigidBody` objects in the scene, I created two new GameObject components called `GravitySubject` and `GravitySource`.
`GravitySource` like the name suggests is a GameObject that applies force on `GravitySubjects` to pull them towards it (or push them away). `GravitySubject` refers to the vehicle in the race, but can be used in the future for other things as well.
I started by introducing a sample scene where primitive cubes are gravity subjects and primitive spheres are the gravity sources:
![](https://i.ibb.co/xXSJ7df/gravity.gif)

### Gravity Sources
The spherical gravity source was shown earlier. Here are some of the other gravity sources implemented:

#### Pipe
![](https://i.ibb.co/pWFz2L8/image.png)
![](https://i.ibb.co/3CN8HV9/image.png)
AKA Capsule.
This is not as simple as the sphere because the sphere had one center of gravity in the middle, and when driving on the tubes there is no such thing. 
By calculating the projection of the gravity source on the imaginal infinite line that runs through the capsule, I got the direction to which I need to apply the force.

Notice: We can acheive a "Tube" gravity source with this implementation. Using the Pipe logic backwards (pushing the subjects instead of pulling them) we can drive inside a hollow tube by sticking to the walls. It didn't require any additional implementation, just using the pipe gravity source with a different rigidbody and entering negative force values instead of positive ones in the editor.

#### Directional
This resembles a local normal gravity. The reason the name directional fits so well is because like in directional lighting, directional gravity applies the same force with the same direction on all subjects within it's area of effect.
![](https://i.ibb.co/yWfMSLX/joebiden.gif)

### Race
Using the different gravity sources in combination can create interesting race tracks. For example, in this level the path from the tube to the sphere is blocked, so the correct way is to drive upside down on the tube and the surface that connects it to the sphere, then reach the ending point (emitting blue particles in the picture) from the other side of the sphere.
![](https://i.ibb.co/KLfvZ9p/image.png)
.
