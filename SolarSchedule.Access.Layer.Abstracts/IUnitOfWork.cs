using System.Threading.Tasks;

namespace SolarSchedule.Access.Layer.Abstracts
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}