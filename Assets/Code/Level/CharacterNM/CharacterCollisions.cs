using System;
using UnityEngine;
using Utils.Physics;

namespace Level.CharacterNM
{
    [Serializable]
    public class CharacterCollisions
    {
        [SerializeField] private CollisionsList _characterFeet;
        [SerializeField] private CollisionsList _allCollisions;

        public CollisionsList All => _allCollisions;
        public CollisionsList Feet => _characterFeet;
    }
}