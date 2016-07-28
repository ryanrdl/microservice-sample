using System;

namespace Common
{
    public class UnobtrusiveConventions
    {
        public static Func<Type, bool> DefiningCommandsAs = type => type.Namespace != null && type.Namespace.EndsWith("Commands");
        public static Func<Type, bool> DefiningEventsAs = type => type.Namespace != null && type.Namespace.EndsWith("Events");
        public static Func<Type, bool> DefiningMessagesAs = type => type.Namespace != null && type.Namespace.EndsWith("Messages");
    }
}
