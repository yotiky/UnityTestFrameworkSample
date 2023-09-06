using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTest.Models
{
    public interface ISystemClock
    {
        DateTime Now { get; }
    }

    public class Ticket
    {
        private ISystemClock _clock;
        private uint _expireDays;

        public Ticket(ISystemClock clock, uint expireDays)
        {
            _clock = clock;
            _expireDays = expireDays;
        }

        public DateTime Issue()
        {
            return _clock.Now.AddDays(_expireDays);
        }
    }
}