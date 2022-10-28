using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IPEvent.Net4._8
{
    public class PVEvent
    {
        [DataMember]
        public string Name { get; set; } // Card name. Ignore. Will be blank.
        [DataMember]
        public string Company { get; set; } // Ignore. Will be blank.
        [DataMember]
        public string UnitNo { get; set; } // Ignore. Will be blank.
        [DataMember]
        public string Site { get; set; } // Site name. Will be blank.
        [DataMember]
        public string MonitorPointId { get; set; } // Reader ID. Will be blank.
        [DataMember]
        public string MonitorPointDesc { get; set; } // Reader name
        [DataMember]
        public string EventDesc { get; set; } // Event description/name
        [DataMember]
        public string CardId { get; set; } // Card number
        [DataMember]
        public string Id { get; set; } // Ignore. Will be blank.
        [DataMember]
        public string EventDate { get; set; } // Event occurred date
        [DataMember]
        public string EventTime { get; set; } // Event occurred time
        [DataMember]
        public int AlarmStatus { get; set; } // Ignore. Will be blank.
                                             //Alarm status:Normal = 0, Alarm = 3 or 2 or 1.
                                             //3 = When Alarm triggered,
                                             //2 = Alarm Acknowledged but not cleared,
                                             //1 = Alarm cleared but not acknowledged
        [DataMember]
        public int DoorStatus { get; set; } // Ignore. Will be blank.
                                            //  Door open status(Open = 1, Close = 2)

    }
}
