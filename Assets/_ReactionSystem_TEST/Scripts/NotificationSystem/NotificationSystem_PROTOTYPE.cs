using System;
using Com.PI.ReactionSystem;


namespace Com.PI.NotificationSystem {
    /*
    // ToDo: Pretty sure this is wrong, but this is the general idea I want
    */
    public static class NotificationSystem<T> where T: PacketData {
        public static void AddObserver(string NotificationName,Action<T> inputHandler) { }

        public static void RemoveObserver(string NotificationName,Action<T> inputHandler) { }

        public static void PostNotification(string NotificationName,T inputPacketData) { }
    }
}