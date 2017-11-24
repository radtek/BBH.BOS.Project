﻿using BBC.Core.Database;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Data
{
    public class TransactionWalletBusiness: ITransactionWalletService
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        static string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
        public IEnumerable<TransactionCoinBO> ListTransactionWalletBySearch(int memberID, DateTime fromDate, DateTime toDate, int start, int end)
        {
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<TransactionCoinBO> lstTransaction = new List<TransactionCoinBO>();
                string sql = "SP_ListTransactionWalletBySearchFrontEnd";
                SqlParameter[] pa = new SqlParameter[5];
                pa[0] = new SqlParameter("@memberID", memberID);
                pa[1] = new SqlParameter("@start", start);
                pa[2] = new SqlParameter("@end", end);
                pa[3] = new SqlParameter("@fromDate", fromDate);
                pa[4] = new SqlParameter("@toDate", toDate);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TransactionCoinBO transaction = new TransactionCoinBO();
                    transaction.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    transaction.ExpireDate = DateTime.Parse(reader["ExpireDate"].ToString());
                    transaction.MemberID = int.Parse(reader["MemberID"].ToString());
                    transaction.Note = reader["Note"].ToString();
                    transaction.QRCode = reader["QRCode"].ToString();
                    transaction.Status = int.Parse(reader["Status"].ToString());
                    transaction.TransactionBitcoin = reader["TransactionBitcoin"].ToString();
                    transaction.TransactionID = int.Parse(reader["TransactionID"].ToString());
                    transaction.TypeTransactionID = int.Parse(reader["TypeTransactionID"].ToString());
                    transaction.ValueTransaction = int.Parse(reader["ValueTransaction"].ToString());
                    transaction.WalletAddressID = reader["WalletAddressID"].ToString();
                    transaction.WalletID = int.Parse(reader["WalletID"].ToString());
                    transaction.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
                    lstTransaction.Add(transaction);

                }
                return lstTransaction;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }
        public IEnumerable<TransactionCoinBO> ListTransactionWalletByMember(int memberID, int start, int end)
        {
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<TransactionCoinBO> lstTransaction = new List<TransactionCoinBO>();
                string sql = "SP_ListTransactionWalletByMemberFE";
                SqlParameter[] pa = new SqlParameter[3];
                pa[0] = new SqlParameter("@memberID", memberID);
                pa[1] = new SqlParameter("@start", start);
                pa[2] = new SqlParameter("@end", end);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TransactionCoinBO transaction = new TransactionCoinBO();
                    transaction.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    transaction.ExpireDate = DateTime.Parse(reader["ExpireDate"].ToString());
                    transaction.MemberID = int.Parse(reader["MemberID"].ToString());
                    transaction.Note = reader["Note"].ToString();
                    transaction.QRCode = reader["QRCode"].ToString();
                    transaction.Status = int.Parse(reader["Status"].ToString());
                    transaction.TransactionBitcoin = reader["TransactionBitcoin"].ToString();
                    transaction.TransactionID = int.Parse(reader["TransactionID"].ToString());
                    transaction.TypeTransactionID = int.Parse(reader["TypeTransactionID"].ToString());
                    transaction.ValueTransaction = int.Parse(reader["ValueTransaction"].ToString());
                    transaction.WalletAddressID = reader["WalletAddressID"].ToString();
                    transaction.WalletID = int.Parse(reader["WalletID"].ToString());
                    transaction.TotalRecord = int.Parse(reader["TOTALROWS"].ToString());
                    lstTransaction.Add(transaction);

                }
                return lstTransaction;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }
        public bool CheckExistTransactionBitcoin(string strTransactionID)
        {
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_CheckExistTransactionBitcoinFE";
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@TransactionBitcoin", strTransactionID);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rs = true;
                    break;
                }
                return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }
    }
}
