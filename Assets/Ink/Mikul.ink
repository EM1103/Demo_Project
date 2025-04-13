INCLUDE globalVAR.ink

-> mikul_intro
=== mikul_intro ===
An intimidating man in a battered suit of armor stands before you. 
* [Approach him]
    He turns to look at you.
    His eyebrows furled in a confused experesion.
    ~temp random_choice = RANDOM(1,2)
    { random_choice == 1: 
        MIKUL: I thought I was alone down here.
    }
    { random_choice == 2:
        MIKUL: I don't remember asking for any assitance.
        MIKUL: I can handle my shift just fine, thanks.
    }
    It appears that he has mistaken you for another guard.
    -> options

* [Leave]
    -> END

=== options ===
* [Ask him about the exit]
    ~temp random_choice = RANDOM(1,2)
    { random_choice == 1: 
        MIKUL: You don't remember.
    }
    { random_choice == 2:
        He stares at you for a momment.
        Confusion evident in his experession.
    }
    MIKUL: It's that red door ahead.
    MIKUL: Though, I've lost the key somewhere.
    MIKUL: I swear that old man in the cell has it.
    -> END
* {curiosity > 3} [Ask about the cell]
    MIKUL: The cell?
    MIKUL: It is meant for criminals.
    MIKUL: Right now we have this old man locked up.
    ~temp random_choice_1 = RANDOM(1,2)
    { random_choice == 1: 
        MIKUL: Not sure what he is guilty for.
    }
    { random_choice == 2:
        MIKUL: I wasn't told why, but it's probably somethign bad.
    }
    -> END