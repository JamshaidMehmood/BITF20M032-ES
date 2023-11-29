using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Mediator
    {
        // Mediator Interface
        public interface IAuctionMediator
        {
            void AddBidder(Bidder bidder);
            void PlaceBid(decimal amount, Bidder bidder);
        }

        // Concrete Mediator: Auction
        public class Auction : IAuctionMediator
        {
            private readonly List<Bidder> _bidders = new List<Bidder>();
            private decimal _currentBid;
            private Bidder _currentWinner;

            public void AddBidder(Bidder bidder)
            {
                _bidders.Add(bidder);
            }

            public void PlaceBid(decimal amount, Bidder bidder)
            {
                if (amount > _currentBid)
                {
                    _currentBid = amount;
                    _currentWinner = bidder;
                    NotifyBidders();
                }
                else
                {
                    Console.WriteLine($"Sorry, bid of {amount:C} is not higher than the current bid of {_currentBid:C}.");
                }
            }

            private void NotifyBidders()
            {
                foreach (var bidder in _bidders)
                {
                    if (bidder != _currentWinner)
                    {
                        bidder.ReceiveMessage($"Bid of {_currentBid:C} is leading.");
                    }
                }
            }
        }

        // Colleague Interface
        public abstract class Bidder
        {
            protected readonly IAuctionMediator _auctionMediator;
            protected readonly string _name;

            public Bidder(IAuctionMediator auctionMediator, string name)
            {
                _auctionMediator = auctionMediator;
                _name = name;
            }

            public abstract void PlaceBid(decimal amount);
            public abstract void ReceiveMessage(string message);
        }

        // Concrete Colleague: AuctionParticipant
        public class AuctionParticipant : Bidder
        {
            public AuctionParticipant(IAuctionMediator auctionMediator, string name) : base(auctionMediator, name) { }

            public override void PlaceBid(decimal amount)
            {
                Console.WriteLine($"{_name} places a bid of {amount:C}");
                _auctionMediator.PlaceBid(amount, this);
            }

            public override void ReceiveMessage(string message)
            {
                Console.WriteLine($"{_name} receives: {message}");
            }
        }

        // ------------------------------------------------------------------------------
        // Mediator Interface
        public interface IAirTrafficControl
        {
            void RegisterAircraft(Aircraft aircraft);
            void SendMessage(string message, Aircraft sender);
        }

        // Concrete Mediator: AirTrafficControlTower
        public class AirTrafficControlTower : IAirTrafficControl
        {
            private readonly List<Aircraft> _aircrafts = new List<Aircraft>();

            public void RegisterAircraft(Aircraft aircraft)
            {
                _aircrafts.Add(aircraft);
            }

            public void SendMessage(string message, Aircraft sender)
            {
                foreach (var aircraft in _aircrafts)
                {
                    if (aircraft != sender) // Do not send the message back to the sender
                    {
                        aircraft.ReceiveMessage(message);
                    }
                }
            }
        }

        // Colleague Interface
        public abstract class Aircraft
        {
            protected readonly IAirTrafficControl _atc;
            protected readonly string _callSign;

            public Aircraft(IAirTrafficControl atc, string callSign)
            {
                _atc = atc;
                _callSign = callSign;
            }

            public abstract void SendMessage(string message);
            public abstract void ReceiveMessage(string message);
        }

        // Concrete Colleague: Airplane
        public class Airplane : Aircraft
        {
            public Airplane(IAirTrafficControl atc, string callSign) : base(atc, callSign) { }

            public override void SendMessage(string message)
            {
                Console.WriteLine($"{_callSign} sends: {message}");
                _atc.SendMessage(message, this);
            }

            public override void ReceiveMessage(string message)
            {
                Console.WriteLine($"{_callSign} receives: {message}");
            }
        }

    }
}
