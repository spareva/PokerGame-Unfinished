using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool result = CheckForFiveSame(hand);
            if (result && hand.Cards.Count == 5)
            {
                return true;
            }
            throw new InvalidOperationException("Hand not valid -> not 5 cards");
        }

        private static bool CheckForFiveSame(IHand hand)
        {
            byte[] differentFaces = new byte[15];

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                byte faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;

                if (i != hand.Cards.Count - 1)
                {
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Face == hand.Cards[j].Face &&
                            hand.Cards[i].Suit == hand.Cards[j].Suit)
                        {
                            throw new InvalidOperationException("Invalid hand");
                        }
                    }
                }
            }

            if (Array.Exists(differentFaces, element => element > 4))
            {
                throw new InvalidOperationException("Invalid hand (5 equal faces)");
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            IsValidHand(hand);
            if (IsFlush(hand) && IsStraight(hand))
            {
                return true;
            }
            else return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            if (Array.Exists(differentFaces, card => card == 4))
            {
                return true;
            }
            else return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            if (Array.Exists(differentFaces, card => card == 3) &&
                Array.Exists(differentFaces, card => card == 2))
            {
                return true;
            }
            else return false;        
        }

        public bool IsFlush(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentSuits = new byte[4];
            byte suitNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                suitNum = (byte)hand.Cards[i].Suit;
                differentSuits[suitNum]++;
            }

            if (Array.Exists(differentSuits, card => card == 5))
            {
                return true;
            }
            else return false;
        }

        public bool IsStraight(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            byte index = 0;                        
            while (differentFaces[index] == 0)
            {
                index++;
            }
            byte startStraight = index;
            while(differentFaces[index] == 1)
            {
                index++;
            }
            byte endStraight = index;
            if(endStraight-startStraight == 5)
            {
                return true;
            }
            else return false;   
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            if (Array.Exists(differentFaces, card => card == 3))
            {
                return true;
            }
            else return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            byte countPairs = 0;
            foreach (var cardNumber in differentFaces)
            {
                if (cardNumber == 2)
                {
                    countPairs++;
                }
            }

            if (countPairs >= 2)
            {
                return true;
            }
            else return false;
        }

        public bool IsOnePair(IHand hand)
        {
            IsValidHand(hand);
            byte[] differentFaces = new byte[15];
            byte faceNum = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faceNum = (byte)hand.Cards[i].Face;
                differentFaces[faceNum]++;
            }

            byte countPairs = 0;
            foreach (var cardNumber in differentFaces)
            {
                if (cardNumber == 2)
                {
                    countPairs++;
                }
            }

            if (countPairs == 1)
            {
                return true;
            }
            else return false;
        }

        public bool IsHighCard(IHand hand)
        {
            return IsValidHand(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
