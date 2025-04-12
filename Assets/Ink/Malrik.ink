VAR has_met_malrik = false
VAR empathy = 0

-> malrik_intro
=== malrik_intro ===
{has_met_malrik == false:
    ~ has_met_malrik = true
    * [Approach the old man.]
        The figure turns his head slowly, as though hearing you before seeing you.
        MALRIK: Ahh... another wanderer stirs from the dust.
        MALRIK: You walk without memory. As all must, at first.
        MALRIK: The Spire calls you, though you do not yet hear it.
        MALRIK: And beyond it, the Looming Pulse... do you feel it? No? You will.
        -> malrik_options
- else:
    MALRIK: Still you wander. Still the Spire waits.
    -> malrik_options
}

=== malrik_options ===
* [Who are you?]
    MALRIK: I am no one worth naming. A Watcher. A voice in the dark.
    MALRIK: You might call me Malrik. But names are fleeting here.
    -> malrik_options
* [What is the Looming Pulse?]
    MALRIK: A breath before the end. A truth too vast to fit in mind.
    MALRIK: You will not understand it... not yet.
    -> malrik_options
* [What’s the Spire?]
    MALRIK: A tower of echoes. A needle through the sky.
    MALRIK: All paths wind toward it. All fates unravel near it.
    -> malrik_options
* [Leave.]
    MALRIK: Go, then. But remember—you *chose* to wake.
    -> END
