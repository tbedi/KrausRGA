﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KrausRGA.EntityModel;

namespace KrausRGA.DBLogics
{
   public class cmdReturnDetail
    {
       //Entity RGA System database object.
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

        #region Get methods.



        #endregion

        #region Set methods.

       /// <summary>
       /// Upsert record in to ReturnDetail table of RMASYSTEM database.
       /// </summary>
       /// <param name="ReturnDetailsObj">
       /// Return table object to be add or update in to the database.
       /// </param>
       /// <returns>
       /// Boolean value true if transaction is success.
       /// otherwise false if transaction is fail.
       /// </returns>
       public Boolean UpsetReturnDetail(ReturnDetail ReturnDetailsObj)
       {
           Boolean _returnFlag = false;
           try
           {
               ReturnDetail rDetails = new ReturnDetail();
               rDetails = entRMA.ReturnDetails.SingleOrDefault(ret => ret.ReturnID == ReturnDetailsObj.ReturnDetailID);
               //Save new record in database if pervious is not persent with same id.
               if (rDetails ==null)
               {
                   entRMA.AddToReturnDetails(ReturnDetailsObj);
               }
               else //Update existing record with same id.
               {
                   rDetails = ReturnDetailsObj;
               }
               entRMA.SaveChanges();
               _returnFlag = true;
           }
           catch (Exception)
           {}
           return _returnFlag;
 
       }

        #endregion

        #region Deleted.



        
        #endregion
    }
}