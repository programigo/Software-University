namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public const string Namespace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType(Namespace + unitType);

            IUnit currentUnit = (IUnit)Activator.CreateInstance(type);

            return currentUnit;
        }
    }
}