public class EnemyPool2 : ObjectPool2<Enemy2>
{
    public override void ReturnToPool(Enemy2 objectToDeActivate)
    {
        base.ReturnToPool(objectToDeActivate);
    }

    public override void Activate(Enemy2 objectToActivate)
    {
        base.Activate(objectToActivate);
    }
}
