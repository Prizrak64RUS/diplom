
namespace Assets.myScript.entity
{
    public class News
    {
        private int id;
        private int id_event;
        private string description;
        private string date_write;

        public News() { }
        public News(int id, int id_event, string description, string date_write)
        {
            this.id = id;
            this.id_event = id_event;
            this.description = description;
            this.date_write = date_write;
        }
    }
}