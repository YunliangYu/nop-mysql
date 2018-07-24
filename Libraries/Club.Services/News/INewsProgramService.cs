using System.Collections.Generic;
using Club.Core.Domain.News;

namespace Club.Services.News
{
    /// <summary>
    /// News Program interface
    /// </summary>
    public partial interface INewsProgramService
    {
        /// <summary>
        /// Delete news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        void DeleteNewsProgram(NewsProgram newsProgram);

        /// <summary>
        /// Gets all news programs
        /// </summary>
        /// <returns>News Programs</returns>
        IList<NewsProgram> GetAllNewsPrograms();

        /// <summary>
        /// Gets a news program
        /// </summary>
        /// <param name="newsProgramId">News Program identifier</param>
        /// <returns>News Program</returns>
        NewsProgram GetNewsProgramById(int newsProgramId);

        /// <summary>
        /// Inserts news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        void InsertNewsProgram(NewsProgram newsProgram);

        /// <summary>
        /// Updates the news program
        /// </summary>
        /// <param name="newsProgram">News Program</param>
        void UpdateNewsProgram(NewsProgram newsProgram);
    }
}
