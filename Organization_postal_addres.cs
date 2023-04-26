using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr15_bondyrev
{
    public class Organization_postal_addres
    {
        string fio, adress, city;
        int index;
        public string Fio {get {return fio;}set {fio = value;}}
        public string Adress {get {return adress;}set {adress = value;}}
        public string City {get {return city;}set {city = value;}}
        public int Index {get {return index;}set {index = value;}}
        public Organization_postal_addres(string fio, string adress, string city, int index)
        {
            this.fio = fio;
            this.adress = adress;
            this.city = city;
            this.index = index;
        }
        public Organization_postal_addres()
        {

        }
    }
}
