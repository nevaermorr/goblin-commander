using System.Linq;
using UnityEngine;
using Entitas;

[Game]
public class BeaconComponent : IComponent{
    public BeaconAction Action;
    public float Range;
}