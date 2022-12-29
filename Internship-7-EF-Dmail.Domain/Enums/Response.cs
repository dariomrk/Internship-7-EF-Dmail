namespace Internship_7_EF_Dmail.Domain.Enums
{
    public enum Response
    {
        Succeeded,
        NoChanges,
        ErrorNotFound,
        ErrorViolatesUniqueConstraint,
        ErrorViolatesRequirements,
        ErrorInvalidFormat,
    }
}
