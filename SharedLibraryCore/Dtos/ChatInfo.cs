﻿using System;
using static SharedLibraryCore.Server;

namespace SharedLibraryCore.Dtos
{
    public class ChatInfo
    {
        public int ClientId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public Game ServerGame { get; set; }
        public bool IsQuickMessage { get; set; }
    }
}