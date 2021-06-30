using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuit
    {
        private Dictionary<string, ushort> _wireCircuit;


        public WireCircuit()
        {
            _wireCircuit = new Dictionary<string, ushort>();
        }



        public ushort GetWireSignal(string wireId)
        {
            if (_wireCircuit.ContainsKey(wireId))
            {
                return _wireCircuit[wireId];
            } else
            {
                throw new ArgumentException($"wire with id: {wireId} does not exist!");
            }
        }
    }
}
