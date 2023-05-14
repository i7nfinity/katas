# Elevator Kata by Marco Consolaro

Implement a controller for an elevator system considering the following requirements. For evaluating purpose, assume
that it takes one second to move the elevator from one floor to another and the doors stay open for three seconds at
every stop.

## Part I

The building has 5 total floors including basement and ground. The elevator can be called at any floor only when it is
not in use via one call button.

- Given the elevator is positioned on the ground floor
- When there is a call from floor3 to go to basement
- And there is a call from ground to go to basement
- And there is a call from floor2 to go to basement
- And there is a call from floor1 to go to floor 3
- Then the doors should open at floor3, basement, ground, basement, floor2, basement, floor1 and floor3 in this order

## Part II

The elevator is not fast enough so as an experiment to speed it up the idea is to allow the elevator to queue the
requests and optimize the trips. The elevator can now queue the stop requests from the floors and collect people in the
way, but cannot change direction once started until all calls in the same direction have been fulfilled.

- Given the elevator is positioned on the groud floor
- When there is a call from floor3 to go to basement
- And there is a call from ground to go to basement
- And there is a call from floor2 to go to basement
- And there is a call from floor1 to go to floor 3
- Then the doors should open at floor3, floor2, ground, basement, floor1 and floor3 in this order

### Non functional requirement

the total time spent in the process of Part II should be less than the time spent with the algorthm of Part I