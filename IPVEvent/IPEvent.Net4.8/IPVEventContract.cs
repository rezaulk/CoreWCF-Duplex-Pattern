using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPEvent.Net4._8
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPVEventCallback))]
    public interface IPVEventContract
    {
        [OperationContract(IsOneWay = true)]
        void Initialize(string clientApplicationName);
        [OperationContract(IsOneWay = false)]
        bool IsAlive();

        // TODO: Add your service operations here
    }

    public interface IPVEventCallback
    {
        [OperationContract(IsOneWay = true)]
        void RaiseEvent(PVEvent eventDetails);
    }
}
