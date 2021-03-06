﻿namespace Lykke.Contracts.Pay
{
    public class AssertPairRate { 
        private bool _filledBit;
        private bool _filledAsk;

        public AssertPairRate()
        {
            
        }
        public AssertPairRate(AssertPairRate source)
        {
            if (source == null)
            {
                return;
            }

            AssetPair = source.AssetPair;
            Bid = source.Bid;
            Ask = source.Ask;
            Accuracy = source.Accuracy;
            _filledBit = _filledAsk = true;
        }
        public AssertPairRate(IPairRate source)
        {
            AssetPair = source.AssetPair;
            FillRate(source);
        }

        public void FillRate(IPairRate source)
        {
            if (source.IsBuy)
            {
                Bid = (float)source.Price;
                _filledBit = true;
            }
            else
            {
                Ask = (float)source.Price;
                _filledAsk = true;
            }
        }

        public string AssetPair { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public int Accuracy { get; set; }
        public bool IsReady()
        {
            return _filledBit && _filledAsk;
        }
    }
}
