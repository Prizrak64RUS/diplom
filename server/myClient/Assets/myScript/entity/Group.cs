using System;

namespace Assets.myScript.entity
{
    public class Group
    {
        public int id { get; set; }
        public int idEvent { get; set; }
        public int number_child { get; set; }
        public int numberResponsible { get; set; }
        public int numberOverall { get; set; }
        public string responsible { get; set; }
        public string school { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public int groupExist { get; set; }

        public Group(int idEvent, int number_child, int numberResponsible, int numberOverall, string responsible, string school, string location, string date, int groupExist)
        {
            this.id = 0;
            this.idEvent = idEvent;
            this.number_child = number_child;
            this.numberResponsible = numberResponsible;
            this.numberOverall = numberOverall;
            this.responsible = responsible;
            this.school = school;
            this.location = location;
            this.date = date;
            this.groupExist = groupExist;
        }

        public Group()
        {
        }
    }
}
