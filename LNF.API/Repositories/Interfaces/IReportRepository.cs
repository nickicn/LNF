using LNF.API.Models;

namespace LNF.API.Repositories.Interfaces;

public interface IReportRepository
{
    Task<Report> GetMonthlyReportAsync(string userId, int month, int year);
    Task<IEnumerable<Report>> GetYearlyReportAsync(string userId, int year);
    Task<Report> CreateOrUpdateMonthlyReportAsync(Report report);
    
}
