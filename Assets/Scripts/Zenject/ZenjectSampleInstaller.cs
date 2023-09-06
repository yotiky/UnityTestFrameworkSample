using UnityEngine;
using UnityTest.Models;
using Zenject;

public class ZenjectSampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISword>()
            .To<Sword>()
            .AsTransient()
            .WithArguments("鋼", "馴染みの鍛冶職人")
            .IfNotBound();

        // IInitializable呼ぶ時はこっち、だが上手くInitialize呼べてない
        //Container.BindInterfacesTo<Sword>()
        //    .AsTransient()
        //    .WithArguments("鋼", "馴染みの鍛冶職人")
        //    .IfNotBound();

        Container.Bind<Player>()
            .AsTransient()
            .IfNotBound();
    }
}