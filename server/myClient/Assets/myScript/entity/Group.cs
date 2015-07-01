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
        public string ds { get; set; }
        public string de { get; set; }
        public int groupExist { get; set; }

        public Group(int idEvent, int number_child, int numberResponsible, int numberOverall, string responsible, string school,
            string location, string ds, string de, int groupExist)
        {
            this.id = 0;
            this.idEvent = idEvent;
            this.number_child = number_child;
            this.numberResponsible = numberResponsible;
            this.numberOverall = numberOverall;
            this.responsible = responsible;
            this.school = school;
            this.location = location;
            this.ds = ds;
            this.de = de;
            this.groupExist = groupExist;
        }

        public Group(int idEvent)
        {
            this.id = 0;
            this.idEvent = idEvent;
            this.groupExist = 0;

            this.number_child = 0;
            this.numberResponsible = 0;
            this.numberOverall = 0;
            this.responsible = "";
            this.school = "";
            this.location = "";
            this.ds = "";
            this.de = "";
        }
        public Group()
        { }
    }
}
