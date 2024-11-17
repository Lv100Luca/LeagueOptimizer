# Champion Classes Update

This branch focuses on updating the structure of champion classes to improve consistency and maintainability.

## Key Changes

1. **Champion Class Structure**
    - The champion class must strictly adhere to the structure defined by the interface.
      - Functions that calculate ability damage will all pass a target object (e.g., champion) as a parameter.
    - Any champion-specific effects (e.g., Caitlyn's abilities) should be implemented within the champion class and factored into the generic ability calculation methods.

      Examples of champion-specific effects for Caitlyn:
        - **Headshot Active**
        - **Enemy Trapped**

2. **Base Stats and Champion Stats**
    - The structure of base stats data and champion stats will be updated.
    - Each champion will have:
        - A **base stats object** (generic base stats).
        - A **champion-specific ability stats object**.

### Base Stats Object
The base stats object will include:
- **Base Value**: The starting value of each stat.
- **Growth Value**: The stat's increment per level.

### Accessing Base Stats
Champions will access these values via a property that directly returns the base stat value for a given stat.  
The **total stat value** will continue to be calculated in the same way.

## Goal
These changes aim to:
- **Unify** the process of retrieving champion stats.
- Maintain clarity and structure in champion class implementations.
