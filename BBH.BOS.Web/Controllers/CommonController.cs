﻿using BBH.BOS.Domain.Entities;
using BBH.BOS.Shared;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class CommonController : Controller
    {
        string masterKey = ConfigurationManager.AppSettings["KeyBOS"];
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepositBTC()
        {
            try
            {
                if (Session["MemberInfomation"] != null)
                {
                    MemberInformationBO member = (MemberInformationBO)Session["MemberInfomation"];
                    int intIndexWallet = member.IndexWallet;
                    string strClientExtKey = masterKey;
                    RandomUtils.Random = new UnsecureRandom();
                    ExtKey masterPubKey = new BitcoinExtKey(strClientExtKey, Network.TestNet);
                    ExtKey pubkey = masterPubKey.Derive(intIndexWallet, hardened: true);
                    var strWalletAddress = pubkey.PrivateKey.GetBitcoinSecret(Network.TestNet).GetAddress().ToString();
                    ViewBag.WalletAddress = strWalletAddress;
                    string strQRCode = Utility.GenQRCode(strWalletAddress);
                    ViewBag.DataQRCode = "data:image/png;base64," + strQRCode + "";
                }
                else
                {
                    ViewBag.WalletAddress = "00000000000000";
                    ViewBag.DataQRCode = "data:image/png;base64," + 00000000000000 + "";
                }
            }
            catch
            {
                ViewBag.WalletAddress = "00000000000000";
                ViewBag.DataQRCode = "data:image/png;base64," + 00000000000000 + "";
            }
            return PartialView();
        }
        public ActionResult BuyPackage()
        {
            return PartialView();
        }
        public ActionResult PartialDashboard()
        {
            return PartialView();
        }
    }
}