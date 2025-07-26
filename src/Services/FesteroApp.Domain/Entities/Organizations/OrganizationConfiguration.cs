using SrShut.Common;

namespace FesteroApp.Domain.Entities.Organizations;

public class OrganizationConfiguration
{
    private OrganizationConfiguration()
    {
    }

    public OrganizationConfiguration(Organization organization, TimeSpan? workdayStart = null, TimeSpan? workdayEnd = null) : this()
    {
        Organization = organization;

        CreatedOn = UpdatedOn = DateTime.Now;

        if (workdayStart != null && workdayEnd != null)
            SetWorkHours(workdayStart, workdayEnd);
    }

    public virtual int Id { get; private set; }

    public virtual TimeSpan? WorkdayStart { get; private set; }

    public virtual TimeSpan? WorkdayEnd { get; private set; }

    public virtual DateTime? CreatedOn { get; set; }

    public virtual DateTime? UpdatedOn { get; set; }

    public virtual DateTime? DeletedOn { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual void SetWorkHours(TimeSpan? start, TimeSpan? end)
    {
        Throw.IsTrue(end <= start, "Workday.Hour", "Horário final deve ser maior que o inicial.");

        WorkdayStart = start;
        WorkdayEnd = end;
    }

    public virtual void Delete() => DeletedOn = DateTime.Now;
}