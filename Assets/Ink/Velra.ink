INCLUDE globalVAR.ink

-> velra_intro
=== velra_intro ===
A lady adorned in scholarly garb stands before you.
    * [Approach her]
    Upon closer inspection, there appears to be a symbol on the floor.
    She turns to you with a puzzled expression.
    ~temp random_choice = RANDOM(1,2)
    { random_choice == 1: 
        VELRA: You seem lost. 
    }
    { random_choice == 2:
        VELRA: I don't beleive we've met.
    }
    { corruption >= 1:
        VELRA: But something about you seems interesting.
        She says with a slight grin.
    }
    -> options
    
    * [Leave]
    -> END
    
=== options ===
* [Ask about the castle]
    She shurgs.
    VELRA: I have no clue what you are talking about.
    VELRA: You've got better luck asking the two downstairs.
    She returns her attention to the symbol on the floor.
    ~ curiosity += 6
    -> options

* {corruption >= 1} [Ask about the symbol on the floor]
    She looks at you with new found interest.
    It sends a chill down your spine...
    VELRA: Hmmm... I'll let you step through it.
    VELRA: It will being you to the place you need to be.
    ~ corruption += 5
    -> options

* [Leave]
    -> END