using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public class QuotasRepository : IQuotasRepository
    {
        private readonly ApplicationContext _context;

        public QuotasRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех квот
        /// </summary>
        public IEnumerable<Quota> GetAll()
        {
            return _context.Quotas.ToList();
        }

        /// <summary>
        /// Получить квоту по идентификатору
        /// </summary>
        public Quota GetQuotaById(int id)
        {
            return _context.Quotas.Include(quota => quota.QuotaContributions).Include(quota => quota.City).Include(quota => quota.Purpose).FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Добавить новую квоту
        /// </summary>
        public void AddNewQuota(Quota quota)
        {
            var connection = _context.Database.GetDbConnection() as SqlConnection;

            CreateNewQuota(quota, connection);  //Add(quota)
        }

        /// <summary>
        /// Обновить квоту
        /// </summary>
        public void UpdateQuota(Quota quota)
        {
            foreach (var contribution in _context.QuotaContributions.Where(x => x.QuotaId == quota.Id))
            {
                _context.QuotaContributions.Remove(contribution);
            }

            _context.Update(quota);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удалить квоту
        /// </summary>
        public void Remove(Quota quota)
        {
            _context.Remove(quota);
            _context.SaveChanges();
        }

        private void CreateNewQuota(Quota quota, SqlConnection connection)
        {
            using (connection)
            {
                int newQuotaId;
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Quotas (CityId, PurposeId, RefinancingAmount, CreationDate, EditDate, Comment, InterestRate) output INSERTED.ID VALUES (@ci, @pi, @ra, @cd, @ed, @com, @ir)", connection))
                {
                    cmd.Parameters.AddWithValue("@ci", quota.CityId);
                    cmd.Parameters.AddWithValue("@pi", quota.PurposeId);
                    cmd.Parameters.AddWithValue("@ra", quota.RefinancingAmount);
                    cmd.Parameters.AddWithValue("@cd", quota.CreationDate);
                    cmd.Parameters.AddWithValue("@ed", quota.EditDate);
                    cmd.Parameters.AddWithValue("@com", quota.Comment);
                    cmd.Parameters.AddWithValue("@ir", quota.InterestRate);
                    connection.Open();

                    newQuotaId = (Int32)cmd.ExecuteScalar();
                }

                foreach (var contribution in quota.QuotaContributions)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO QuotaContributions (QuotaId, Value) output INSERTED.ID VALUES (@ci, @pi)", connection))
                    {
                        cmd.Parameters.AddWithValue("@ci", newQuotaId);
                        cmd.Parameters.AddWithValue("@pi", contribution.Value);

                        cmd.ExecuteScalar();
                    }
                }
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
            }
        }
    }
}
