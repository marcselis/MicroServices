using Microsoft.EntityFrameworkCore;

namespace ProductsService.Models
{
  [Owned]
  public class LifeCycleInfo
  {
    public DateOnly? Plan { get; set; }
    public DateOnly? PhaseIn { get; set; }
    public DateOnly? Active { get; set; }
    public DateOnly? PhaseOut { get; set; }
    public DateOnly? EndOfLife { get; set; }

    public LifeCycle Current
    {
      get
      {
        var today = DateOnly.FromDateTime(DateTime.Now);
        if (EndOfLife.HasValue && EndOfLife.Value < today)
        {
          return LifeCycle.EndOfLife;
        }
        if (PhaseOut.HasValue && PhaseOut.Value < today)
        {
          return LifeCycle.PhaseOut;
        }
        if (Active.HasValue && Active.Value < today)
        {
          return LifeCycle.Active;
        }
        if (PhaseIn.HasValue && PhaseIn.Value < today)
        {
          return LifeCycle.PhaseIn;
        }
        if (Plan.HasValue && Plan.Value < today)
        {
          return LifeCycle.Plan;
        }
        return LifeCycle.Undefined;
      }
    }
  }
}