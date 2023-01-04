namespace Internship_7_EF_Dmail.Presentation.Interfaces
{
    public interface IMenuAction : IAction
    {
        IList<IAction> Actions { get; }
    }
}
