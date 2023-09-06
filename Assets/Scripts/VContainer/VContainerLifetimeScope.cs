using UnityTest.Models;
using VContainer;
using VContainer.Unity;

public class VContainerLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ISword, Sword>(Lifetime.Transient)
            .WithParameter("material", "オリハルコン")
            .WithParameter("author", "オルテガ");
        builder.Register<Player>(Lifetime.Transient);
        builder.RegisterComponentInHierarchy<VContainerSample>();
    }
}
