﻿using Level.CharacterNM.Helpers;
using UnityEngine;

namespace Level.CharacterNM.CharacterStateMachineNM.States
{
    public class FallState : CharacterState
    {
        public FallState(Animator character) : base(character, AnimationsName.Fall)
        {
        }
    }
}