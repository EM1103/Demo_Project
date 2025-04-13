INCLUDE globalVAR.ink

-> intro
=== intro ===
The water in this crate seems to shine.
    * [Examine]
    It appears to have some magical properties.
    As if it could absolve you of all your troubles.
    -> options
    
    * [Leave]
    -> END
    
=== options ===
* {amulet >= 1} [Dip the amulet]
    Upon dipping the amulet in the water,
    It seems to shimmer.
    And you feel a weight let off your chest.
    ~ corruption = 0
    -> END
    
* [Leave]
    There is nothing for you to do here.
    -> END