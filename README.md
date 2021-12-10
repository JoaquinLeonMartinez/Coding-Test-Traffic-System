# TrafficSystem

Author: Joaquín León Martínez
Date: 10/12/2021

External Assets:
- CITY package: https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224
- Simple Cars Pack: https://assetstore.unity.com/packages/3d/vehicles/land/simple-cars-pack-97669

Exercise:
High-Level Description
Your task is to create a traffic and pedestrian system where the below requirements are
met. The objective of this exercise is to see how you approach problem solving and
implementation of a suitable solution, and your knowledge of Unity and C#.

Requirements

Environment
● The environment can be represented by anything you want
○ If you have modelling experience you are welcome to create some assets.
○ If you would rather use primitives then that's fine too (for example, cubes to
represent buildings, capsules to represent pedestrians, etc).
● The environment can take any form that you wish. As an example, please see the
attached image as a minimum requirement.

Vehicles
● Vehicles should drive on roads.
● The side on which vehicles drive is not important - either left or right will do.
● Vehicles do not have to be physics-based, but can be if you want them to.
● Vehicles should obey the laws of the road
○ keep a safe following distance to other vehicles.
○ yield to other traffic at intersections.
○ yield to pedestrians at zebra crossings.
● Note that vehicles do not need to decide whether or not to turn left/right at
intersections - they may follow fixed routes if this makes things easier.

Example scenarios
3-Way Intersection
● A vehicle approaches a stop street and stops within a certain distance of it, or
queues if there is already a line of vehicles waiting.
● The vehicle yields to other traffic already at the stop street.
● The vehicle proceeds when it is its turn to go.
Pedestrian Crossing
● A pedestrian approaches a zebra crossing.
● A vehicle approaches the zebra crossing, and sees there is a pedestrian
approaching.
● The vehicle yields to the pedestrian, who crosses, and the vehicle proceeds when
it is safe to do so.
● Any other approaching vehicles should queue appropriately.

