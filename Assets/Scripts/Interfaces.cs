using UnityEngine;

namespace DefaultNamespace
{
    public interface IMovable
    {
        void Move();
        void SetTarguet();
    }

    public interface IDamegeable
    {
        int Hp { get; set; }
        void Damege(int damege);
    }

    public interface IInstansable
    {
        GameObject Create(Vector3 position, Quaternion rotation);
    }

    public interface IFightable
    {
        int HitForce { get; set; }
        void Attack();
    }

    public interface IShootable
    {
        int ShotForce { get; set; }
        void Shot();
    }

    public interface IPreparable
    {
        int Iniciativa { get; set; }
    }
}