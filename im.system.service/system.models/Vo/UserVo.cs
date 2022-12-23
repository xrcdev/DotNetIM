using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace system.models.Vo
{
    public class UserVo 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Headsrc { get; set; }
        public string UserTag { get; set; }
    }
}
