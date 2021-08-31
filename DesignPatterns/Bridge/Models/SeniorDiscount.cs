﻿using BridgePattern.Interfaces;

namespace BridgePattern.Models
{
    public class SeniorDiscount : IDiscount
    {
        public int GetDiscount() => 20;
    }
}