using System.Collections.Generic;

namespace DomainEvent.Events {
    public class ResetClientSecretNotificationEvent {
        public string Url { get; set; }
        public List<string> Recipients { get; set; } = new List<string>();
    }
}

