using NSubstitute;
using UnityEngine;
using Game.Physics.GravitySources;

namespace Tests.Factory
{
    //public interface IGravitySourceTestsFactory
    //{
    //    /// <summary>
    //    /// Gets a <see cref="GameObject"/> with a <see cref="IGravitySource"/> implementing component
    //    /// </summary>
    //    /// <returns>Some <see cref="GameObject"> that has a componenet that implements <see cref="IGravitySource"/></returns>
    //    GameObject GetGravitySourceGameObject();

    //    /// <summary>
    //    /// Gets an <see cref="IGravitySource"/> object or mock with no garuntee for extra functionality/properties
    //    /// </summary>
    //    /// <returns>A reference to an <see cref="IGravitySource"/> mock/object</returns>
    //    IGravitySource GetGravitySourceInterface();
    //}

    //public class GravitySourceTestsFactory : IGravitySourceTestsFactory
    //{
    //    public GameObject GetGravitySourceGameObject()
    //    {
    //        var gameObject = new GameObject();
    //        gameObject.AddComponent<BallGravitySourceBehaviour>();

    //        return gameObject;
    //    }

    //    public IGravitySource GetGravitySourceInterface()
    //    {
    //        return Substitute.For<IGravitySource>();
    //    }
    //}
}