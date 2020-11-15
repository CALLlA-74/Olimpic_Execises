using System.Collections.Generic;

namespace lab3_v6
{
    class CargoPlane : Airplane
    {
        private double weightOfCargo;
        public CargoPlane(int flightNumber, double weightOfCargo, string aircrewList) : base(flightNumber, aircrewList)
        {
            this.weightOfCargo = weightOfCargo;
            emptyWeightOfPlane = Constants.emptyWeightOfCargoPlane;
            curbWeight = GetCurbWeight();
            typeOfPlane = Constants.typeOfPlaneIsCargo;
        }

        protected override double GetCurbWeight()
        {
            return weightOfCargo + emptyWeightOfPlane;
        }
    }
}
