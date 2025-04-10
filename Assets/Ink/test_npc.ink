VAR empathy = 0

-> Start
== Start ==
You see someone who looks upset.

+ { empathy >= 2 } [Ask if they're okay.]
    They nod, thankful for your concern.
    -> End

+ { empathy < 2 } [Ignore them.]
    You decide not to get involved.
    -> End

== End ==
You continue on your way.
-> DONE
