﻿using System;
using Data.Models;
using Data.Models.Client;

namespace SharedLibraryCore.Dtos
{
    public class  ClientInfo
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int LinkId { get; set; }
        public EFClient.Permission Level { get; set; }
        public DateTime LastConnection { get; set; }
        public Reference.Game Game { get; set; }
        public bool IsMasked { get; set; }
    }
}
