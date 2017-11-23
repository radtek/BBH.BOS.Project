﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using BBH.BOS.Domain;
using BBH.BOS.Respository;
using BBH.BOS.Domain.Interfaces;
using BBH.BOS.Domain.Entities;

namespace BBH.BOS.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        //[Dependency]
        protected IIMemberService repository { get; set; }
        
        public ActionResult Index(string p)
        {
            //if (Session["Email"] == null)
            //{
            //    Response.Redirect("/login");
            //}
            //int totalRecord = 0;
            //int intPageSize = 10;
            //int start = 0, end = 10;
            ////Int32.TryParse(ConfigurationManager.AppSettings["NumberRecordPage"], out intPageSize);

            //int page = 1;
            //try
            //{
            //    if (p != null && p != "")
            //    {
            //        page = int.Parse(p);
            //    }
            //}
            //catch
            //{

            //}
            //if (page > 1)
            //{
            //    start = (page - 1) * intPageSize + 1;
            //    end = (page * intPageSize);
            //}
            //IEnumerable<MemberBO> lstMember = repository.GetListMember(start,end);
            //    if (lstMember != null && lstMember.Count() > 0)
            //    {
            //        string Emaail = lstMember.ElementAt(0).Email;
            //    }
            //    ViewData["ListAdmin"] = lstMember;
                //IEnumerable<GroupAdminBO> lstGroupAdmin = repository.ListGroupAdmin();
                //ViewData["ListGroupAdmin"] = lstGroupAdmin;
            

            return View();
        }

        [HttpPost]
        public string RegisterMember(string email,string password, string mobile, string fullName)
 //string address, string password, string avatar, int isDelete,DateTime birthday, int isActive, int gender, DateTime updateDate, DateTime deleteDate, string updateUser, string linkActive, DateTime expireTimeLink, DateTime createDate,string deleteUser)
        {
            string result = "";
            MemberBO member = new MemberBO();
            //if (Session["Email"] == null)
            //{
            //    Response.Redirect("/login");
            //}
            //else
            //{
                //if ((int)Session["GroupID"] != 1)
                //{
                //    Response.Redirect("/");
                //}
                //if (memberID > 0)
                //{
                //    member.FullName = fullName;
                //    member.Email = email;
                //    member.Mobile = mobile;
                   

                //    bool rs = repository.UpdateMember( member,memberID);
                   

                //}
                //else if (memberID == 0)
                //{
                    member.FullName = fullName;
                    member.Email = email;
                    member.Mobile = mobile;
                    member.Address = "";
                    member.Password = password;
                    //string passMd5 = Utility.MaHoaMD5(password + "1234");
                    //member.Password = passMd5;
                    member.Birdthday = DateTime.Parse("1/1/1990");
                    member.DeleteDate = DateTime.Parse("1/1/1990");
                    member.DeleteUser = "";
                    member.LinkActive = "";
                    member.ExpireTimeLink = DateTime.Parse("1/1/1990");
                    member.IsActive = 1;
                    member.IsDelete = 0;
                    //member.Hashkey = "1234";
                    member.CreateDate = DateTime.Now;
                    member.Gender = 1;
                    member.DeleteUser = "";
                    member.UpdateUser = "";
                    member.Avatar = "";

                    bool checkUserName = repository.CheckEmailExists(email);
                    if (checkUserName)
                    {
                        Response.Write("EmailExist");
                    }
                    else
                    {                   
                        bool returnAdminID = repository.InsertMember(member);
                        if(returnAdminID==true)
                        {
                            member = repository.GetMemberDetailByEmail(email);
                            Member_WalletBO memberWallet = new Member_WalletBO();

                            bool rs_ = repository.InsertMemberWallet(memberWallet);
                            if (rs_)
                            {
                                Session["Email"] = email;
                                //Session["Points"] = member.Points;
                                result = "registerSuccess";
                                //if (Session["username"] == null)
                                //{
                                //    Session["username"] = member.Email;

                                //}
                                Session["memberid"] = member.MemberID;
                                //Session["ewallet"] = member.E_Wallet;
                                Session["MemberInfomation"] = member;
                            }

                        }
                        else
                        {
                            result = "RegisterFaile";
                        }
                        //result = "insertsuccess";
                    }
                //}
            //}
            return result;
        }
    }
}