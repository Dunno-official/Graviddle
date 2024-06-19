
namespace _2D_Laser_system.Code.Laser.Utils.Pool.Factory
{
    public class LaserFactory : IFactory<Laser.Laser>
    {
        private readonly ComponentFactory<Laser.Laser> _componentFactory;
        private readonly Laser.Laser _prefab;

        public LaserFactory(Laser.Laser prefab)
        {
            _componentFactory = new ComponentFactory<Laser.Laser>(prefab);
            _prefab = prefab;
        }

        public Laser.Laser Create()
        {
            Laser.Laser laser = _componentFactory.Create();
            laser.BranchLaser(_prefab);

            return laser;
        }
    }
}