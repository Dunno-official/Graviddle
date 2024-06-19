using System.Collections.Generic;
using _2D_Laser_system.Code.Laser.Laser.Components;
using _2D_Laser_system.Code.Laser.Laser.Components.Collision;
using _2D_Laser_system.Code.Laser.Laser.Components.Dissolve;
using _2D_Laser_system.Code.Laser.Laser.Components.HitEvent;
using _2D_Laser_system.Code.Laser.Laser.Components.Interaction;
using _2D_Laser_system.Code.Laser.Laser.Components.Length;
using _2D_Laser_system.Code.Laser.Laser.Data;
using _2D_Laser_system.Code.Laser.Laser.LaserLifeCycleFactory;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Composite;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.ConditionalUpdate;
using _2D_Laser_system.Code.Laser.Laser.LifeCycle.UpdateCycle.Link;
using UnityEngine;

namespace _2D_Laser_system.Code.Laser.Laser.ChainLaser
{
    public class ChainLaserLifeCycleFactory : ILaserLifeCycleFactory
    {
        private readonly ChainLaserKeyPointsProvider _keyPointsProvider;
        private readonly IUpdateCondition _enabledCondition;
        private readonly LaserBase _laserBase;
        private readonly LaserData _data;
        
        public ChainLaserLifeCycleFactory(IUpdateCondition enabledCondition, LaserBase laserBase, ChainLaserKeyPointsProvider keyPointsProvider) 
        {
            _keyPointsProvider = keyPointsProvider;
            _enabledCondition = enabledCondition;
            _laserBase = laserBase;
            _data = laserBase.Data;
        }

        public LifeCycle.LifeCycle Create()
        {
            LineRebuilding lineRebuilding = new(_data.Line, _keyPointsProvider);
            LaserLength length = new(_data.RaycastData, _data.Line);
            LaserDissolve dissolve = new(_data.ViewData);
            DissolveShutdown dissolveShutdown = new(_laserBase, dissolve, length);
            LaserView view = new(_laserBase.GetComponent<MeshRenderer>(), _data.Line, dissolve, length, _data.ViewData);
            LaserInteraction interaction = new(_laserBase);
            LaserActiveHits activeHits = new(length, _keyPointsProvider);
            ChainHitEffect hitEffect = new(_data.HitEffectPrefab, activeHits, _keyPointsProvider);
            LaserCollision collision = new(_data.CollisionData, length, _keyPointsProvider);
            HitEvent hitEvent = new(activeHits);
            LaserAudio audio = new(_data.LaserAudioSource, _data.HitAudioSource, hitEvent);
            ChainLaserMaxPointUpdate maxPointUpdate = new(_keyPointsProvider, _data.Line);
            
            IUpdate mainUpdateCycle = new UpdateComposite(
                maxPointUpdate,
                lineRebuilding, 
                length, 
                activeHits,
                hitEffect,
                hitEvent,
                new UpdateLink<Dictionary<Collider2D, List<RaycastHit2D>>>(collision, interaction));
            
            IUpdate updateCycle = new UpdateComposite(view, new ConditionalUpdate(_enabledCondition, mainUpdateCycle));
            IEnable enableAction = new EnableComposite(length, dissolve, audio, dissolveShutdown);
            IDisable disableAction = new DisableComposite(hitEffect, interaction, audio, dissolveShutdown);

            return new LifeCycle.LifeCycle(enableAction, disableAction, updateCycle);
        }
    }
}