using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IUniRxSample
{
    IReadOnlyReactiveProperty<int> OnReactiveProperty { get; }
    IObservable<int> OnSubject { get; }

    void CallReactiveProperty();
    void CallSubject();
}

public class UniRxSample : IUniRxSample
{
    private readonly ReactiveProperty<int> reactiveProperty = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> OnReactiveProperty => reactiveProperty;

    private readonly Subject<int> subject = new Subject<int>();
    public IObservable<int> OnSubject => subject;

    private int sCount;
    private int rpCount;

    public void CallReactiveProperty()
    {
        reactiveProperty.Value = ++rpCount;
    }
    public void CallSubject()
    {
        subject.OnNext(++sCount);
    }
}
