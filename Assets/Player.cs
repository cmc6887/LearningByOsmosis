﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InControl;
using UnityEngine;

namespace Assets
{
    public class Player
    {
        private readonly InputDevice _device;

		public bool[] activeEffects;


        public Player(InputDevice inputDevice, Color color)
        {
            _device = inputDevice;
            Color = color;
            Ready = true;
			activeEffects = new bool[6];
        }

        public InputDevice Device
        {
            get { return _device; }
        }

        public Color Color { get; private set; }

        public bool Ready { get; private set; }
		
		//TODO:  Add current book, add hitpoint books, add head size, add powerups, etc.
		public bool isAffected(BookBehavior.KnowledgeType kt){
			return activeEffects [(int)kt];
		}
		public void SetEffect(BookBehavior.KnowledgeType kt){
			activeEffects [(int)kt] = true;
		}
    }
}
