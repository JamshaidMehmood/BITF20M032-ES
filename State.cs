using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class State
    {

        // State Interface
        public interface IFanState
        {
            void ChangeSpeed(Fan fan);
        }

        // Concrete State 1: Off State
        public class OffState : IFanState
        {
            public void ChangeSpeed(Fan fan)
            {
                Console.WriteLine("Turning fan on to low speed.");
                fan.SetState(new LowState());
            }
        }

        // Concrete State 2: Low Speed State
        public class LowState : IFanState
        {
            public void ChangeSpeed(Fan fan)
            {
                Console.WriteLine("Increasing fan speed to medium.");
                fan.SetState(new MediumState());
            }
        }

        // Concrete State 3: Medium Speed State
        public class MediumState : IFanState
        {
            public void ChangeSpeed(Fan fan)
            {
                Console.WriteLine("Increasing fan speed to high.");
                fan.SetState(new HighState());
            }
        }

        // Concrete State 4: High Speed State
        public class HighState : IFanState
        {
            public void ChangeSpeed(Fan fan)
            {
                Console.WriteLine("Turning fan off.");
                fan.SetState(new OffState());
            }
        }

        // Context
        public class Fan
        {
            private IFanState _state;

            public Fan()
            {
                _state = new OffState(); // Initial state is Off
            }

            public void SetState(IFanState state)
            {
                _state = state;
            }

            public void ChangeSpeed()
            {
                _state.ChangeSpeed(this);
            }
        }
        //-------------------------------------------------------------------
        // State Interface
        public interface ITrafficLightState
        {
            void Change(TrafficLight light);
        }

        // Concrete State 1: Red Light
        public class RedLight : ITrafficLightState
        {
            public void Change(TrafficLight light)
            {
                Console.WriteLine("Red Light - Stop!");
                light.SetState(new GreenLight());
            }
        }

        // Concrete State 2: Green Light
        public class GreenLight : ITrafficLightState
        {
            public void Change(TrafficLight light)
            {
                Console.WriteLine("Green Light - Go!");
                light.SetState(new YellowLight());
            }
        }

        // Concrete State 3: Yellow Light
        public class YellowLight : ITrafficLightState
        {
            public void Change(TrafficLight light)
            {
                Console.WriteLine("Yellow Light - Prepare to stop!");
                light.SetState(new RedLight());
            }
        }

        // Context
        public class TrafficLight
        {
            private ITrafficLightState _state;

            public TrafficLight()
            {
                _state = new RedLight(); // Initial state is Red
            }

            public void SetState(ITrafficLightState state)
            {
                _state = state;
            }

            public void ChangeLight()
            {
                _state.Change(this);
            }
        }

    }
}
