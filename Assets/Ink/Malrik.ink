INCLUDE globalVAR.ink

-> malrik_intro
=== malrik_intro ===
An old man appears to be locked behind a cell.
    * [Call out to him]
        He looks up at your approach
        ~temp random_choice = RANDOM(1,2)
        { random_choice == 1: 
            MALRIK: You seem new here.
        }
        { random_choice == 2:
            MALRIK: I don't recall seeing you before.
        }
        MALRIK: Listen, something wrong here.
        MALRIK: I've heard people were going missing.
        ~temp random_choice_1 = RANDOM(1,2)
        { random_choice == 1: 
            MALRIK: Somehow I feel safer in here.
        }
        { random_choice == 2:
            He appears to be nervous.
        }
        -> malrik_options
        
    * [Leave]
        -> END

=== malrik_options ===
* [Ask who he is]
    ~temp random_choice_1 = RANDOM(1,2)
    { random_choice == 1: 
        MALRIK: Just an honest man trying to make a living.
    }
    { random_choice == 2:
        MALRIK: That isn't important right now.
    }
    ~ curiosity += 5
    -> malrik_options
    
* [Ask about the missing people]
    ~temp random_choice_2 = RANDOM(1,2)
    { random_choice == 1: 
        MALRIK: I swear it has something to do with the catacombs.
        MALRIK: I've got a gut feeling.
    }
    { random_choice == 2:
        MALRIK: I've heard guards talk about it.
        MALRIK: Something about some catacombs under the castle.
        MALRIK: This isn't right.
    }
    -> malrik_options
    
* [Ask if he needs help]
    ~temp random_choice_3 = RANDOM(1,2)
    { random_choice == 1: 
        MALRIK: Help?
        MALRIK: No. I'm safe in here.
    }
    { random_choice == 2:
        MALRIK: Don't bother, that guard Mikul out there would catch you.
    }
    -> malrik_options
    
* { curiosity >= 1 } [Ask how he got locked up]
    ~temp random_choice_4 = RANDOM(1,2)
    { random_choice == 1: 
        MALRIK: I don't really remember.
    }
    { random_choice == 2:
        MALRIK: A few guards caught me near the castle walls.
        MALRIK: Said I looked suspicious.
    }
    MALRIK: But I swear I'm innocent!
    -> malrik_options
    
* [Leave.]
    ~temp random_choice = RANDOM(1,3)
    { random_choice == 1: 
        MALRIK: Take this.
        He tosses an object at you.
        It is a key.
    }
    { random_choice == 2:
        MALRIK: ...
        He tosses an object at you.
        It appears to be a key.
    }
    { random_choice == 3: 
        MALRIK: Before you go.
        MALRIK: Have this, it didn't do anything for me.
        He hands you an object.
        It appears to be a key.
        You accept his offer.
    }
    ~ key_p += 1
    -> END
