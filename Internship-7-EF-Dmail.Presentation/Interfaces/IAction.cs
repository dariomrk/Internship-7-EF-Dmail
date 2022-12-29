namespace Internship_7_EF_Dmail.Presentation.Interfaces
{
    public interface IAction
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public void Action();
    }
}
