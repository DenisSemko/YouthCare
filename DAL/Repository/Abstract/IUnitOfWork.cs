using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IAnalysisRepository AnalysisRepository { get; }
        IMessageRepository MessageRepository { get; }
        IObservationNoteRepository ObservationNoteRepository { get; }
        ISectionRepository SectionRepository { get; }
        ISportsmanNoteRepository SportsmanNoteRepository { get; }
        ITreatmentRepository TreatmentRepository { get; }
        IUserRepository UserRepository { get; }
        IUsersUsersRepository UsersUsersRepository { get; }
        IAnalysisResultRepository AnalysisResultRepository { get; }
        void Complete();
        bool HasChanges();
    }
}
