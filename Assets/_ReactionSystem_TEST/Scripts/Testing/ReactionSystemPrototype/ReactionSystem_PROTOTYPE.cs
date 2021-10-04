using System;
using System.Collections;
using System.Collections.Generic;


//using Handler = System.Action<System.Object>;
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
NO UNITY CALLS HERE! 
Keep it modular, but easily usable from a Mono OR ScriptableObject
Mono should be able to just make a <List>Reaction or similar, so scriptable objects and serialization can be handles?
Each unit needs to be able to respond to an event that happens, or be able to be commanded.
Needs to be able to handle commands from the UI.
Event System needs to be able to pass around a packed able to actually execute the command.
MUST MAINTAIN REFERENCES
Each entry in the List of actions to be performed needs 
Notification system needs to fire an event when it's done running all callbacks from listeners

*/

/*
//ToDo: Finish commenting ReactionSystem_PROTOTYPE.
//ToDo: Give Validator.Invalidate an optional string 'InvalidationReason' parameter,
    add it to a List<string> so that multiple invalidation reasons can be given.
    For example you're trying to cast a spell, and you're out of mana AND it's not your turn.
 */
/*
namespace ReactionSystemPrototype {
    //ToDo: Consider implementing PacketData as an Interface instead of using inheritance. Or maybe generics?
    public class PacketData {
        public Action<PacketData> OnValidate;
        public Action<PacketData> OnExecute;
    }

    
    //ToDo: I think ReactionPacket needs to create a ReactionRoot
    
    public class ReactionPacket : PacketData {
        public PacketData Data { get; }
        public Validator Validator { get; private set; }

        public ReactionPacket(PacketData inputData = null) {
            Validator = new Validator();
            Data = inputData;
        }

        public bool IsInvalidated() { return Validator.IsInvalidated(); }
    }

    
    // Root of the ReactionNode tree. Could and should probably just be a ReactionNode, 
    // but I wanted to stuff extra functionality in a class for now, may refactor later.
    // ToDo Maybe: Make reactionNodes an IEnumerable, so reactions can be .Waited()
    
    public class ReactionRoot {
        ReactionRoot(ReactionPacket inputPacket) { packet = inputPacket; }
        // List of Reactions. These are generated from the branching tree created through various events and their responses
        private readonly List<ReactionNode> reactionNodes;
        private ReactionPacket packet;

        private void Execute() {
            // PostNotification here so listeners can add new reactionNodes via AddReactionNode 
            List<ReactionNode> reactionNodeList = BuildListFromReactionNodeTree();
            foreach (var reactionNode in reactionNodeList) {
                reactionNode.Execute();
            }
        }

        public void AddReactionNode(ReactionNode inputReactionNode) { reactionNodes.Add(inputReactionNode); }

        // Traverse the tree of reaction nodes, creating a List<ReactionNode>
        // or maybe a Queue. IEnumerator doesn't seem necessary here
        private List<ReactionNode> BuildListFromReactionNodeTree() {
            List<ReactionNode> returnReactionNodes = new List<ReactionNode>();
            foreach (var reactionNode in reactionNodes) {
                returnReactionNodes.Add(reactionNode);
            }

            return returnReactionNodes;
        }
    }

    
    //Nodes in a tree, to hopefully preserve order of Reactions properly
    
    public class ReactionNode {
        ReactionNode(ReactionRoot inputRoot,ReactionPacket inputPacket,List<ReactionNode> inputReactionNodes = null) {
            root = inputRoot;
            packet = inputPacket;
            if (inputReactionNodes != null) {
                reactionNodes = new List<ReactionNode>(inputReactionNodes);
            } else {
                reactionNodes = null;
            }
        }

        // List of Reaction Nodes. These could be things like "Gaining Health in reaction to another enemy being spawned"
        //      or having a reaction to being taking damage because of a buff
        // THIS SHOULD NOT MODIFY THE PACKET! That is done in the ReactionRoot, when sequencing the List<Reactions>
        private ReactionRoot root;
        private ReactionPacket packet;
        private List<ReactionNode> reactionNodes;

        public void Execute() {
            foreach (var reaction in reactionNodes) {
                if (packet.IsInvalidated()) {
                    // Not sure what I want to do here yet
                } else {
                    reaction.Execute();
                }
            }
        }
    }

    
    //Handles the passing of the ReactionPacket to the NotificationSystem. 
    
    public class Reaction {
        // This is the actual reaction from the event.
        // executeAction modifies the packet
        private ReactionRoot root;
        private ReactionPacket packet;

        public Reaction(ReactionRoot inputRoot,ReactionPacket inputPacket) {
            root = inputRoot;
            packet = inputPacket;
            inputPacket.Data.OnExecute(inputPacket);
        }

        public void Execute() {
            // Check if root has been invalidated before editing packet
            if (packet.IsInvalidated()) {
                // Don't change the packet
            } else {
                // Don't invoke it here, add it to the list built after building the tree of reactionNodes,
                // then traversing it
                // ToDo: NotificationSystem.PostNotification("OnReactionExecute",executeAction.Invoke(packet));
            }
        }
    }

    // Used as a signal to terminate propagation and/or events or handlers from firing if necessary.
    // Some reactions will also need validation. I want to be able to PostNotification(ReactionValidationNotification) 
    //      and have Listeners be able to invalidate it, so I can have UI buttons for abilities. Able to click a button
    //      and the user input gets validated 
    // Anything can read it, or invalidate it, but nothing can revalidate it.
    public class Validator {
        // ToDo: Give Validator.Invalidate an optional string 'InvalidationReason' parameter,
         // add it to a List<string> so that multiple invalidation reasons can be given.
         // For example you're trying to cast a spell, and you're out of mana AND it's not your turn.
        
        private bool invalidated;

        public Validator() { invalidated = false; }

        public void Invalidate() { invalidated = true; }

        public bool IsInvalidated() { return invalidated; }
    }
}
*/