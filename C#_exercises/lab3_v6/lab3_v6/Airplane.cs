using System.Collections.Generic;

namespace lab3_v6
{
    public abstract class Airplane
    {
        public readonly int flightNumber;
        public double curbWeight;
        protected double emptyWeightOfPlane;
        protected string typeOfPlane;
        public readonly string aircrewList = "";
        protected abstract double GetCurbWeight();
        public Airplane(int flightNumber, string aircrewList)
        {
            this.flightNumber = flightNumber;
            this.aircrewList = aircrewList;
        }

        public string GetTypeOfPlane()
        {
            return typeOfPlane;
        }
    }
}
