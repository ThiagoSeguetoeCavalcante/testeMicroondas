
using System;

namespace AppMicroondas.Models
{
    public class Settings : BasePropertyChanged
    {
        private DateTime _time;
        private int _power;
        private string _program;
        private char _charHeating;

        public Settings()
        {
            CharHeating = '.';
        }

        public DateTime Time
        {
            get
            {
                return _time;
            }           
        }

        public void AddTime(int number)
        {

            var oldTime = _time;
            var minutes = _time.Minute;
            var seconds = _time.Second * 10 + number;

            if (seconds > 60)
            {
                minutes = seconds / 60;
                seconds = seconds % 60;
            }

            _time = new DateTime(0001, 1, 1, 0, minutes, seconds);
            SetProperty(ref oldTime, _time);
        }

        public void SubtraiTime()
        {

            var oldTime = _time;
            var minutes = _time.Minute;
            var seconds = _time.Second;

            if (minutes > 0 && seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }

            _time = new DateTime(0001, 1, 1, 0, minutes, seconds);
            SetProperty(ref oldTime, _time);
        }

        public void ZerarTime()
        {
            var oldTime = _time;
            _time = new DateTime();
            SetProperty(ref oldTime, _time);
        }

        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                SetProperty(ref _power, value);
            }
        }

        public string Program
        {
            get
            {
                return _program;
            } 
            set
            {
                SetProperty(ref _program, value);
            }
        }

        public char CharHeating
        {
            get { return _charHeating; }
            set
            {
                SetProperty(ref _charHeating, value);
            }
        }
    }
}
