namespace gamejam
{
    public interface IOnwer : IDamagable, IDestructible, IStatus ,IOrganized{ }
    

    public interface IStatus
    {
         int HP { get; }
    }

    public interface IDamagable
    {
        void TakeDamage(int damage);
    }

    public interface IDestructible
    {
        void Destroy();
    }

    public interface IOrganized
    {
         OwnerType Type { get; }
    }

    public enum OwnerType
    {
        Player1,
        Player2,
        Bomb,
        Other,
        None,
    }

    public enum SceneTitle
    {
        None,
        Title
    }
}