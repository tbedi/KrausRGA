﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KrausRGA.EntityModel;
using KrausRGA.ErrorLogger;

namespace KrausRGA.DBLogics
{
    public class cmdReturnImages
    {
        #region Declarations.

        //RMASYSTEM Database entity object.
      //  RMASYSTEMEntities entRMA = new RMASYSTEMEntities(); 
        
        #endregion

        #region Get methods.
        


        #endregion

        #region Set methods.
        
        /// <summary>
        ///  Upsert method for ReturnImages Table.
        /// </summary>
        /// <param name="ReturnImageObj">
        /// ReturnImages Table Object to be Updated or inserted.
        /// </param>
        /// <returns>
        /// Boolean value indiction Trasction success or failuer.
        /// </returns>
        public Boolean UpsertReturnImage(ReturnImage ReturnImageObj)
        {
            Boolean _returnFlag = false;
            try
            {
                _returnFlag = Service.entSave.ReturnImages(ReturnImageObj.CopyToSaveDTO(ReturnImageObj));
            }
            catch (Exception ex)
            {
                ex.LogThis("cmdReturnImages/UpsertReturnImage");
            }
            return _returnFlag;
        }

        #endregion

        #region Delete methods.

        #endregion

    }
}
