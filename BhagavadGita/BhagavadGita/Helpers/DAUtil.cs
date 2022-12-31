using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BhagavadGita.Controllers;
using BhagavadGita.Models;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace BhagavadGita.Helpers
{
    public class DAUtil
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["BGVT"].ToString();
            con = new SqlConnection(constr);
        }

        public List<SelectListItem> DD_Chapters()
        {
            connection();

            SqlCommand com = new SqlCommand("DD_Chapters", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(dt);
            con.Close();

            DD_ChaptersModel listOfCh = new DD_ChaptersModel();
            listOfCh.ChDetails = new List<DD_ChaptersList>();

            List<SelectListItem> listOfChObj = new List<SelectListItem>();

            foreach(DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr["ChapterId"].ToString()))
                {
                    listOfChObj.Add(new SelectListItem()
                    {
                        Text = Convert.ToString(dr["ChapterName"]),
                        Value = Convert.ToString(dr["ChapterId"])
                    });
                }
            }

            return listOfChObj;
        }

        // Get Chapter Details
        public ChapInfoDetails GetChDetails()
        {
            connection();

            SqlCommand com = new SqlCommand("GetChDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(dt);
            con.Close();

            ChapInfoDetails chInfo = new ChapInfoDetails();
            chInfo.ChapDetails = new List<ChapInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr["ChapterId"].ToString()))
                {
                    chInfo.ChapDetails.Add(new ChapInfo
                    {
                        chId = Convert.ToInt32(dr["ChapterId"]),
                        chName = Convert.ToString(dr["ChapterName"]),
                        chDesc = Convert.ToString(dr["ChDescription"])
                    });
                }
            }

            return chInfo;
        }

        // Get Shlokas by Chapter Id
        public ShlokasDetails GetShlokasByChapterNum(int chId)
        {
            connection();

            SqlCommand com = new SqlCommand("GetShlokasByChapterNum", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ChId", chId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();

            ShlokasDetails shInfo = new ShlokasDetails();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                if(!String.IsNullOrEmpty(dr["ChapterId"].ToString()))
                {
                    shInfo = new ShlokasDetails();

                    shInfo.ChapterId = Convert.ToInt32(dr["ChapterId"]);
                    shInfo.ChapterName = Convert.ToString(dr["ChapterName"]);
                }
            }
            shInfo.shlokaDetails = new List<ShlokaInfo>();

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                if (!String.IsNullOrEmpty(dr["ShlokaId"].ToString()))
                {
                    shInfo.shlokaDetails.Add(new ShlokaInfo
                    {
                        ShlokaId = Convert.ToInt32(dr["ShlokaId"]),
                        ChapterId = Convert.ToInt32(dr["ChapterId"]),
                        ShlokaSubId = Convert.ToInt32(dr["ShlokaSubId"]),
                        Shloka = Convert.ToString(dr["Shloka"]),
                        Transliteration = Convert.ToString(dr["Transliteration"]),
                        ShlokaTrans = Convert.ToString(dr["ShlokaTrans"]),
                        Notes = Convert.ToString(dr["Notes"]),
                        Purport = Convert.ToString(dr["Purport"]),
                    });
                }
            }

            return shInfo;
        }

        public ShlokaRes GetShlokasByChapterNum_JSON(int chId)
        {
            connection();

            SqlCommand com = new SqlCommand("GetShlokasByChapterNum", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ChId", chId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();

            ShlokaRes sr = new ShlokaRes();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (!String.IsNullOrEmpty(dr["ChapterId"].ToString()))
                {
                    sr = new ShlokaRes();

                    sr.ChapterNum = Convert.ToInt32(dr["ChapterId"]);
                    sr.ChapterName = Convert.ToString(dr["ChapterName"]);
                }
            }
            sr.ShlokaSubInfo = new List<ShlokaSubInfo>();

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                if (!String.IsNullOrEmpty(dr["ShlokaId"].ToString()))
                {
                    sr.ShlokaSubInfo.Add(new ShlokaSubInfo
                    {
                        ShlokaSubId = Convert.ToInt32(dr["ShlokaSubId"]),
                        Shloka = Convert.ToString(dr["Shloka"]),
                        Transliteration = Convert.ToString(dr["Transliteration"]),
                        ShlokaTrans = Convert.ToString(dr["ShlokaTrans"]),
                        Notes = Convert.ToString(dr["Notes"]),
                        Purport = Convert.ToString(dr["Purport"]),
                    });
                }
            }

            return sr;
        }

        public void ContactUsDetails(string fname, string lname, string job, string email, string message)
        {
            connection();

            SqlCommand com = new SqlCommand("updateContactUsDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@fname", fname);
            com.Parameters.AddWithValue("@lname", lname);
            com.Parameters.AddWithValue("@job", job);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@message", message);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.Open();
            da.Fill(ds);
            con.Close();
        }
    }
}