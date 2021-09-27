using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Passes data to multiple other delegates, able to invalidate it, stopping it from propagating the event
to other receivers. Based on Chain of Command Pattern from Unity Design Patterns project.

Abstract
Start with a root node. This node represents an event. Other entities are able to respond to this event in various ways.
Each ReactionNode passes along a packet of data, copying it (while making sure to maintain references)
These events might be an entity taking damage/being commanded/being healed/whatever
These reactions are added to a list, via a ReactionNode and executed when the packet is invalidated,
    which is why references must be maintained, because this will be branching. Care must be taken to avoid stale references.
Each ReactionNode adds its reactions to the List, nothing is actually done until this list is iterated over and actually executed.
For this reason, classes are used instead of structs (?)
              



Requirements
Each unit needs to be able to respond to an event that happens, or be able to be commanded.
Needs to be able to handle commands from the UI.
Event System needs to be able to pass around a packed able to actually execute the command.
MUST MAINTAIN REFERENCES
Each entry in the List of actions to be performed needs 
*/


namespace Com.PI.ReactionSystem{
// All modifications to the packet, and thus the GameObject are done here.
// This is the only class that should actually talk to Unity.
public class ReactionRoot {
    // List of Reactions. These are generated from the branching tree created through various events and their responses
    private readonly List<Reaction> reactions;

    ReactionRoot() {
        // ToDo: Make this an IEnumerable, so reactions can be Wait. Look into Chaining them together to handle animation timings.
        reactions = new List<Reaction>();
    }

    // This can fail, returning false if one of the reactions fails, or something else goes wrong
    private bool Execute() {
        foreach (var reaction in reactions) {

        }

        return true;
    }

    // Adds a reaction to the list
    // Is there a need to be able to Remove an action?
    public void AddReaction(Reaction inputReaction) { reactions.Add(inputReaction); }
}

public class ReactionNode {
    // List of Reaction Nodes. These could be things like "Gaining Health in reaction to another enemy being spawned"
    // Having a reaction to being shot because of a buff
    // THIS SHOULD NOT MODIFY THE PACKET! That is done in the ReactionRoot

    private ReactionRoot root;
    private List<Reaction> nodeReactions;

    ReactionNode(ReactionRoot inputRoot) { root = inputRoot; }


}

public class Reaction {
    // This is the actual reaction from the event.
    // This modifies the packet

    public bool Execute() { return true; }
}

}