using EqualRights.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EqualRights.Messages
{
    class LogInMessage : PubSubEvent<UserProfile>
    {
    }
}
