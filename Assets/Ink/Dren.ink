INCLUDE globalVAR.ink

-> dren_intro
=== dren_intro ===
A man adorned in semi-regal clothing stand before you.
    * [Approach him]
    He looks at you with a worried look.
    Though it seems like it's not you that he's worried about.
    ~temp random_choice = RANDOM(1,2)
        { random_choice == 1: 
            DREN: Have you seen any other guards recently?
            DREN: It's been awfully quiet.
        }
        { random_choice == 2:
            He trys to hide his expression.
            But it didn't work very well.
        }
    -> options

=== options ===
* [Ask about the castle]
    ~temp random_choice = RANDOM(1,2)
    { random_choice == 1: 
        DREN: People have been missing recently.
        DREN: Not sure what to make of it.
    }
    { random_choice == 2:
        DREN: Haven't heard from my friend for the past week.
        DREN: Im starting to get worried.
    }
    -> options
    
* {curiosity >= 6} [Ask about the locked door]
    DREN: Sorry but that area is off-limits.
    DREN: The place is in disarray.
    -> options_1
    
* [Leave]
    -> END
    
=== options_1 ===
* {journal > 0}[Hand him the journal]
    ~temp random_choice = RANDOM(1,2)
    { random_choice == 1: 
        DREN: Woah! I've been looking for this!
        DREN: Thank you so much!
    }
    { random_choice == 2:
        His expression brightens at the sight of the journal.
    }
    He takes the journal from your hand.
    He tells you about the gap in the wall of the side room. 
    ~ resolve += 5
    -> options
    
* [Leave]
    -> END