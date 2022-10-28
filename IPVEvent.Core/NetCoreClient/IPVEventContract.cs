using NetCoreServer;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NetCoreClient
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPVEventCallback))]
    public interface IPVEventContract
    {
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
}
