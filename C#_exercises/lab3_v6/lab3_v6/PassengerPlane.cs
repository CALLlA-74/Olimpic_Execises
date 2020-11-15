using System.Collections.Generic;

namespace lab3_v6
{
    class PassengerPlane : Airplane
    {
        private int countOfBoardingSeats;
        public PassengerPlane(int flightNumber, int countOfBoardingSeats, string aircrewList) : base(flightNumber, aircrewList)
        {
            this.countOfBoardingSeats = countOfBoardingSeats;
            emptyWeightOfPlane = Constants.emptyWeightOfPassengerPlane;
            curbWeight = GetCurbWeight();
            typeOfPlane = Constants.typeOfPlaneIsPassenger;
        }

        protected override double GetCurbWeight()
        {
            return Constants.averagePassengerWeight * countOfBoardingSeats + emptyWeightOfPlane;
        }
    }
}
