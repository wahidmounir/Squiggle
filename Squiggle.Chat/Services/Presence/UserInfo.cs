﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Squiggle.Chat.Services.Presence
{
    class UserInfo
    {
        public string UserFriendlyName { get; set; }
        public IPEndPoint ChatEndPoint { get; set; }
        public TimeSpan KeepAliveSyncTime { get; set; }
        public string DisplayMessage { get; set; }
        public UserStatus Status { get; set; }       

        public static UserInfo FromEndPoint(IPEndPoint endPoint)
        {
            var user = new UserInfo() { ChatEndPoint = endPoint };
            return user;
        }

        public void Update(UserInfo user)
        {
            this.UserFriendlyName = user.UserFriendlyName;
            this.DisplayMessage = user.DisplayMessage;
            this.Status = user.Status;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is UserInfo)
            {
                IPEndPoint endPoint = ((UserInfo)obj).ChatEndPoint;
                return endPoint.Equals(ChatEndPoint);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            if (this.ChatEndPoint != null)
                return ChatEndPoint.GetHashCode();
            return base.GetHashCode();
        }
    }
}