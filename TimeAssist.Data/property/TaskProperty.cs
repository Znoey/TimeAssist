
namespace TimeAssist.Data.Property
{
    public class TaskProperty : GenericProperty<string>
    {
        public TaskProperty(string task)
            : base(task)
        { }

        public override string ToString()
        {
            return Data;
        }

        public override AProperty FromString(string s)
        {
            Data = s;
            return this;
        }
    }
}
