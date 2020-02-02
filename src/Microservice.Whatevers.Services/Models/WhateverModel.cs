using System;
using System.Collections.Generic;

namespace Microservice.Whatevers.Services.Models
{
    public class WhateverModel : BaseModel
    {
        public string Name { get; set; }
        public IList<ThingModel> Things { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; }
    }
}