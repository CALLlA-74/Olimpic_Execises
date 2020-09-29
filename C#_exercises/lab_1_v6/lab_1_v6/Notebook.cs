// Lakhov Alexander KE-203 variant 6

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace lab_1_v6
{

    public class Notebook
    {
        private List<Person> list;

        class Person
        {
            public string name, surname, phoneNumber, dateOfBirthday;
            public Person(string surname, string name, string phoneNumber, string dateOfBirthday)
            {
                this.name = name;
                this.phoneNumber = phoneNumber;
                this.dateOfBirthday = dateOfBirthday;
                this.surname = surname;
            }
        }

        public Notebook()
        {
            list = new List<Person>();
        }

        public int Add(string surname, string name, string phoneNumber, string dateOfBirthday)
        {
            if (surname == null || name == null || phoneNumber == null) return 2;
            if (surname == "" || name == "" || phoneNumber == "") return 2;
            Person prsn = new Person(surname, name, phoneNumber, dateOfBirthday);
            foreach (Person p in list)
            {
                bool isLess = false;
                bool isEqualSurname = false;
                bool isEqualName = false;
                bool isEqualPhoneNumber = false;
                for (int currentPos = 0; currentPos < p.surname.Length && currentPos < prsn.surname.Length; currentPos++)
                {
                    int temp = (int)p.surname[currentPos] - (int)prsn.surname[currentPos];
                    if (temp > 0)
                    {
                        list.Insert(list.IndexOf(p), prsn);
                        return 0;
                    }
                    if (temp < 0)
                    {
                        isLess = true;
                        break;
                    }
                    else isEqualSurname = true;
                }

                if (isLess) continue;

                for (int currentPos = 0; currentPos < p.name.Length && currentPos < prsn.name.Length; currentPos++)
                {
                    int temp = (int)p.name[currentPos] - (int)prsn.name[currentPos];
                    if (temp > 0)
                    {
                        list.Insert(list.IndexOf(p), prsn);
                        return 0;
                    }
                    if (temp < 0)
                    {
                        isLess = true;
                        break;
                    }
                    else isEqualName = true;
                }

                if (isLess) continue;

                for (int currentPos = 0; currentPos < p.phoneNumber.Length && currentPos < prsn.phoneNumber.Length; currentPos++)
                {
                    int temp = (int)p.phoneNumber[currentPos] - (int)prsn.phoneNumber[currentPos];
                    if (temp > 0)
                    {
                        list.Insert(list.IndexOf(p), prsn);
                        return 0;
                    }
                    if (temp < 0)
                    {
                        isLess = true;
                        break;
                    }
                    else isEqualPhoneNumber = true;
                }

                if (isLess) continue;
                if (isEqualName && isEqualSurname) return 1;
                if (isEqualPhoneNumber) return 3;

                for (int currentPos = 0; currentPos < p.dateOfBirthday.Length && currentPos < prsn.dateOfBirthday.Length; currentPos++)
                {
                    int temp = (int)p.dateOfBirthday[currentPos] - (int)prsn.dateOfBirthday[currentPos];
                    if (temp > 0)
                    {
                        list.Insert(list.IndexOf(p), prsn);
                        return 0;
                    }
                    if (temp < 0) break;
                }

            }
            list.Add(prsn);
            return 0;
        }

        public void clearList()
        {
            list.Clear();
        }

        public bool removeNote(int position)
        {
            return list.Remove(list[position]);
        }

        public string GetSurnameByPos(int pos)
        {
            return list[pos].surname;
        }

        public string GetNameByPos(int pos)
        {
            return list[pos].name;
        }

        public string GetPhoneByPos(int pos)
        {
            return list[pos].phoneNumber;
        }

        public string GetDateByPos(int pos)
        {
            return list[pos].dateOfBirthday;
        }

        public int GetCount()
        {
            return list.Count;
        }

        public string GetAll()
        {
            string res = "";
            foreach (Person prsn in list)
            {
                if (prsn.surname != null) res += (prsn.surname + " ");
                if (prsn.name != null) res += (prsn.name + " ");
                if (prsn.phoneNumber != null) res += (prsn.phoneNumber + " ");
                if (prsn.dateOfBirthday != null) res += (prsn.dateOfBirthday);
                res += "\n";
            }
            return res;
        }

        public int SearchBySurnameAndName(string surname, string name, int left = 0, int right = -1)
        {
            if (right < 0) right = list.Count;
            if (right > list.Count || left >= list.Count || left >= right) return -1;
            int mid = left + (right - left) / 2;
            if (list[mid].surname.Equals(surname) && list[mid].name.Equals(name))
                return mid;

            if (list[mid].surname.Length > surname.Length)
            {
                for (int idx = 0; idx < surname.Length; idx++)
                {
                    if (list[mid].surname[idx] < surname[idx]) return SearchBySurnameAndName(surname, name, mid + 1, right);
                    if (list[mid].surname[idx] > surname[idx]) return SearchBySurnameAndName(surname, name, left, mid);
                }
                return SearchBySurnameAndName(surname, name, left, mid);
            }
            else if (list[mid].surname.Length < surname.Length)
            {
                for (int idx = 0; idx < list[mid].surname.Length; idx++)
                {
                    if (list[mid].surname[idx] < surname[idx]) return SearchBySurnameAndName(surname, name, mid + 1, right);
                    if (list[mid].surname[idx] > surname[idx]) return SearchBySurnameAndName(surname, name, left, mid);
                }
                return SearchBySurnameAndName(surname, name, mid + 1, right);
            }
            else
            {
                for (int idx = 0; idx < surname.Length; idx++)
                {
                    if (list[mid].surname[idx] < surname[idx]) return SearchBySurnameAndName(surname, name, mid + 1, right);
                    if (list[mid].surname[idx] > surname[idx]) return SearchBySurnameAndName(surname, name, left, mid);
                }

                if (list[mid].name.Length > name.Length)
                {
                    for (int idx = 0; idx < name.Length; idx++)
                    {
                        if (list[mid].name[idx] < name[idx]) return SearchBySurnameAndName(surname, name, mid + 1, right);
                        if (list[mid].name[idx] > name[idx]) return SearchBySurnameAndName(surname, name, left, mid);
                    }
                    return SearchBySurnameAndName(surname, name, left, mid);
                }
                else
                {
                    for (int idx = 0; idx < list[mid].name.Length; idx++)
                    {
                        if (list[mid].name[idx] < name[idx]) return SearchBySurnameAndName(surname, name, mid + 1, right);
                        if (list[mid].name[idx] > name[idx]) return SearchBySurnameAndName(surname, name, left, mid);
                    }
                    return SearchBySurnameAndName(surname, name, mid + 1, right);
                }
            }
        }
    }
}
