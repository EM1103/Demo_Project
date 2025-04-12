VAR empathy = 0
VAR curiosity = 0
VAR defiance = 0
VAR resolve = 0
VAR corruption = 0

VAR p_key = 0

-> shelf_intro
=== shelf_intro ===
{ p_key > 0:
    This shelf is empty. 
- else:
    This shelf seems to have something valuable in it.
}
-> Options

=== Options ===
* [Leave]
    You leave the shelf alone.
    {corruption >= 1:
        But something feels off.
    }
    -> END

* {p_key == 0} [Search]
    ~temp random = RANDOM(1,3)
    { random == 1:
        ~ p_key += 1
        ~ curiosity += 1
        You find a book.
        It appears to be a journal.
    }
    { random == 2:
        ~ p_key += 1
        ~ resolve += 1
        You find a piece of paper.
        It appears to be a motivational flyer.
    }
    { random == 3:
        ~ p_key += 1
        ~ corruption += 1
        You find an amulet.
        You feel something strange in your chest when you pick it up.
    }
    -> Options