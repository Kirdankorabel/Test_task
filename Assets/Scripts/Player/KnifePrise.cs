using System;
using UnityEngine;

namespace KnifeScripts
{
    public class KnifePrise : MonoBehaviour
    {
        private uint _prise;
        public event Action PriseChanged;
        public event Action LevelEnded;

        public int Prise
        {
            get => (int)_prise;

            set
            {
                if (value > 0)
                    _prise = (uint)value;
                else
                    _prise = 1;

                PriseChanged?.Invoke();
            }
        }

        private void Awake()
        {
            _prise = 1;
        }

        public void ChangePrise(int value, bool mult)
        {
            if (mult && value > 0)
                Prise *= value;
            else if (mult && value < 0)
                Prise /= -value;
            else
                Prise += value;
        }

        public void TakeAway(int points)
        {
            if (Prise - points > 0)
                Prise -= points;
            else
            {
                _prise = 0;
                PriseChanged?.Invoke();
                LevelEnded?.Invoke();
            }
        }
    }
}
