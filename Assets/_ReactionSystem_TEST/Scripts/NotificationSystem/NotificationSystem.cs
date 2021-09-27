using System;
using Com.PI.ReactionSystem;


namespace Com.PI.NotificationSystem {
    public static class NotificationSystem {
        public static void AddObserver(string NotificationName,Action<PacketData> inputHandler) { }

        public static void RemoveObserver(string NotificationName,Action<PacketData> inputHandler) { }

        public static void PostNotification(string NotificationName,PacketData inputPacketData) { }
    }
}