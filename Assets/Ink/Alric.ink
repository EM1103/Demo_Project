INCLUDE globalVAR.ink

-> alric_intro
=== alric_intro ===
A gentle looking person, a butler of some kind.
    * [Approach him]
    The butler notices you and smiles.
    ALRIC: Oh hello, how can I help you?
    -> options
    
    * [Leave]
    -> END
    
=== options ===
* [Ask about the castle]
    ALRIC: Hmmm, I not sure.
    ALRIC: I woke up one day and a lot of people vanished.
    -> options

* [Offer assistance]
    ALRIC: Hmm? Oh I'm fine.
    ALRIC: I'm missing something of mine, but I'm sure I'll find it!
    ->options_1
    
* [Leave]
    -> END
    
=== options_1 ===
* {flyer > 0} [Offer the flyer]
    The butler takes the flyer from you.
    ALRIC: Oh thank you so much!
    ALRIC: Here, have this.
    You are given a key.
    ~ key_1 += 1
    -> options_1

* [Leave]
    -> END