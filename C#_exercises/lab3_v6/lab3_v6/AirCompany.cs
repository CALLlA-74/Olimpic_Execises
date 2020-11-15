using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab3_v6
{
    public class AirCompany
    {

        private static List<Airplane> AirplaneList;
        private double averageCurbWeight = 0;
        public AirCompany()
        {
            AirplaneList = new List<Airplane>();
        }

        public bool AddCargoFlight(int flightNumber, double weightOfCargo, string aircrewList)
        {
            bool flag = AddPlane(new CargoPlane(flightNumber, weightOfCargo, aircrewList));
            UpdateAverageCurbWeight();
            return flag;       
        }

        public bool AddPassengerFlight(int flightNumber, int countOfBoardingSeats, string aircrewList)
        {
            bool flag = AddPlane(new PassengerPlane(flightNumber, countOfBoardingSeats, aircrewList));
            UpdateAverageCurbWeight();
            return flag;
        }

        private bool AddPlane(Airplane arpn)
        {
            if (findIdxByFlightNumber(arpn, AirplaneList.Count) < 0) return false;
            int idxR = findIdxByCurbWeightRight(arpn, AirplaneList.Count);
            int idxL = findIdxByCurbWeightLeft(arpn, AirplaneList.Count);
            if (idxL == idxR)
                if (AirplaneList[idxR].flightNumber == arpn.flightNumber) return false;
                else if (AirplaneList[idxR].flightNumber < arpn.flightNumber) AirplaneList.Insert(idxR + 1, arpn);
                else AirplaneList.Insert(idxR, arpn);
            if (idxR < idxL) AirplaneList.Insert(idxL, arpn);
            if (idxL < idxR) 
            {
                int idx = findIdxByFlightNumber(arpn, Math.Min(idxR + 1, AirplaneList.Count), Math.Max(idxL - 1, -1));
                if (idx < 0) return false;
                AirplaneList.Insert(idx, arpn);
            }
            
            return true;
        }

        private int findIdxByCurbWeightRight(Airplane arpn, int right, int left = -1)
        {
            if (right - left <= 1) 
            {
                //if (left >= 0 && AirplaneList[left].GetCurbWeight() == arpn.GetCurbWeight()) 
                    return left;
            }
            int middle = (right + left) / 2;
            if (AirplaneList[middle].curbWeight <= arpn.curbWeight) left = middle;
            else right = middle;
            return findIdxByCurbWeightRight(arpn, right, left);
        }

        private int findIdxByCurbWeightLeft(Airplane arpn, int right, int left = -1)
        {
            if (right - left <= 1) {
                //if (right < AirplaneList.Count && AirplaneList[right].GetCurbWeight() == arpn.GetCurbWeight())
                    return right;
            }
            int middle = (right + left) / 2;
            if (AirplaneList[middle].curbWeight < arpn.curbWeight) left = middle;
            else right = middle;
            return findIdxByCurbWeightLeft(arpn, right, left);
        }

        private int findIdxByFlightNumber(Airplane arpn, int right, int left = -1)
        {
            if (right - left <= 1) 
            {
                if (right < AirplaneList.Count && AirplaneList[right].flightNumber == arpn.flightNumber) return -1;
                else return right;
            }
            int middle = (right + left) / 2;
            if (AirplaneList[middle].flightNumber < arpn.flightNumber) left = middle;
            else right = middle;
            return findIdxByFlightNumber(arpn, right, left);
        }

        private void UpdateAverageCurbWeight()
        {
            double sumOfCurbWeight = 0;
            foreach (Airplane i in AirplaneList) sumOfCurbWeight += i.curbWeight;
            averageCurbWeight = sumOfCurbWeight / AirplaneList.Count;
        }

        public double GetAverageCurbWeight()
        {
            return averageCurbWeight;
        }

        public flight GetFlight(int i)
        {
            if (i >= AirplaneList.Count) return null;

            return new flight() 
            {
                number = (i + 1).ToString(),
                flightNumber = AirplaneList[i].flightNumber.ToString(),
                typeOfPlane = AirplaneList[i].GetTypeOfPlane(),
                curbWeight = AirplaneList[i].curbWeight.ToString(),
                names = AirplaneList[i].aircrewList
            };
        }

        public int GetCountOfFlights()
        {
            return AirplaneList.Count;
        }



        public class flight
        {
            public string number { get; set; }
            public string flightNumber { get; set; }
            public string typeOfPlane { get; set; }
            public string curbWeight { get; set; }
            public string names { get; set; }
        }

        public static AirCompany RestoreDates(AirCompany company)
        {
            //JsonSerializer serializer = new JsonSerializer();
            //using (StreamReader In = new StreamReader(Constants.path))
            //using(JsonReader jsr = new JsonTextReader(In))
            StreamReader In;
            try 
            {
               In = new StreamReader(Constants.path);
                for (string s = In.ReadLine(); s != null; s = In.ReadLine()) {
                    flight f = JsonConvert.DeserializeObject<flight>(s);
                    if (f.typeOfPlane.Equals(Constants.typeOfPlaneIsCargo)) company.AddCargoFlight(Convert.ToInt32(f.flightNumber), Convert.ToDouble(f.curbWeight) - Constants.emptyWeightOfCargoPlane, f.names);
                    if (f.typeOfPlane.Equals(Constants.typeOfPlaneIsPassenger)) company.AddPassengerFlight(Convert.ToInt32(f.flightNumber), (int)((Convert.ToDouble(f.curbWeight) - Constants.emptyWeightOfPassengerPlane) / Constants.averagePassengerWeight), f.names);
                }
                In.Close();
            }
            catch 
            {
                return company;
            }
            return company;
        }
        
        public static void WriteFile(AirCompany company)
        {
            StreamWriter Out;
            try 
            {
                Out = new StreamWriter(Constants.path);
                Out.Write("");
                for (int i = 0; i < company.GetCountOfFlights(); i++) {
                    flight f = company.GetFlight(i);
                    Out.WriteLine(JsonConvert.SerializeObject(f));
                }
                Out.Close();
            }
            catch 
            {
                return;
            }
        }
    }
}
