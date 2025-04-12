VAR empathy = 0
VAR curiosity = 0
VAR defiance = 0
VAR resolve = 0
VAR corruption = 0

VAR p_key = 0

-> mikul_intro
=== mikul_intro ===
MIKUL: Hey there!
-> options

=== options ===
* [Greet him]
    MIKUL: Go on ahead.
    -> END
* {curiosity > 3} [Ask about the cell]
    MIKUL: The cell?
    MIKUL: It was meant for small animals.
    MIKUL: But that old man was creeping everyone out!
    -> END