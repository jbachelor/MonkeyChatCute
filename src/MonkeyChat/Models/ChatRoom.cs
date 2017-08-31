using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AzureMobileClient.Helpers;
using MvvmHelpers;

namespace MonkeyChat.Models
{
    public class ChatRoom : EntityData
    {
        public ChatRoom()
        {
        }

        public string Name { get; set; }
    }
}
