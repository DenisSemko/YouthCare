using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext myDbContext;

        public UnitOfWork(ApplicationContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public IAnalysisRepository AnalysisRepository => new AnalysisRepository(myDbContext);
        public IAnalysisResultRepository AnalysisResultRepository => new AnalysisResultRepository(myDbContext);
        public IObservationNoteRepository ObservationNoteRepository => new ObservationNoteRepository(myDbContext);
        public ISectionRepository SectionRepository => new SectionRepository(myDbContext);
        public ISportsmanNoteRepository SportsmanNoteRepository => new SportsmanNoteRepository(myDbContext);
        public ITreatmentRepository TreatmentRepository => new TreatmentRepository(myDbContext);
        public IUserRepository UserRepository => new UserRepository(myDbContext);
        public IUsersUsersRepository UsersUsersRepository => new UsersUsersRepository(myDbContext);
        public IAnalysisDetectionRepository AnalysisDetectionRepository => new AnalysisDetectionRepository(myDbContext);


        public void Complete()
        {
            myDbContext.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            myDbContext.ChangeTracker.DetectChanges();
            var changes = myDbContext.ChangeTracker.HasChanges();

            return changes;
        }
    }
}
