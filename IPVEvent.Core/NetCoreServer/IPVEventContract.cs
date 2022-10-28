using CoreWCF;
using NetCoreServer;
using System.Runtime.Serialization;

namespace Contract
{
    [DataContract]
    public class EchoFault
    {
        private string text;

        [DataMember]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
    }

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPVEventCallback))]

    //[ServiceContract]
    public interface IPVEventContract
    {
        //[OperationContract]
        //string Echo(string text);

        //[OperationContract]
        //string ComplexEcho(EchoMessage text);

        //[OperationContract]
        //[FaultContract(typeof(EchoFault))]
        //string FailEcho(string text);

        //[OperationContract]
        //string EchoForPermission(string text);

        [OperationContract(IsOneWay = true)]
        void Initialize(string clientApplicationName);

        [OperationContract(IsOneWay = false)]
        bool IsAlive();

    }

    public interface IPVEventCallback
    {
        [OperationContract(IsOneWay = true)]
        void RaiseEvent(PVEvent eventDetails);
    }


    [DataContract]
    public class EchoMessage
    {
        [DataMember]
        public string Text { get; set; }
    }
}
