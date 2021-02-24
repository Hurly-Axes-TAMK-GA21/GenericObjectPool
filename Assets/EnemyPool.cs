public class EnemyPool : ObjectPool<Enemy>
{
    public override void Deactivate(Enemy objectToDeActivate)
    {
        base.Deactivate(objectToDeActivate);
    }

    public override void Activate(Enemy objectToActivate)
    {
        base.Activate(objectToActivate);
    }
}
