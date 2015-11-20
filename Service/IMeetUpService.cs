using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Data;

namespace Service
{
    [ServiceContract]
    public interface IMeetUpService
    {
        [OperationContract]
        List<MeetUp> GetAllMeetups();

        [OperationContract]
        MeetUp GetMeetUpById(string id);

        [OperationContract]
        MeetUp CreateMeetUp(MeetUp meetup);

        [OperationContract]
        MeetUp UpdateMeetUp(string id, MeetUp meetup);

        [OperationContract]
        void DeleteMeetUp(string id);
    }
}