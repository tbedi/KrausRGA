﻿using KrausRGA.EntityModel;
using KrausRGA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrausRGA.DBLogics
{
    /// <summary>
    /// Avinash: 31 Oct 2013
    /// Get Operations Performed on sage x3v6 the database of BI server.
    /// </summary>
   public class cmdSageOperations
    {

       /// <summary>
       /// Database object of x3v6 from BI server.
       /// </summary>
       x3v6Entities entX3V6 = new x3v6Entities();

       /// <summary>
       /// Get RMA details from the sage by SRNumber.
       /// </summary>
       /// <param name="SRNumber">
       /// String SRNumber. must be valied.
       /// </param>
       /// <returns>
       /// list of RMAInfo class related to entered SRNumber.
       /// </returns>
       public List<RMAInfo> GetRMAInfoBySRNumber(String SRNumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfo>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                                    so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                                    so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                                    sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                                    bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                                    itm.ITMDES2_0 ProductName, CAST(srd.DLVQTY_0 AS INT) DeliveredQty,
                                                                                    CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                                    CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                                    CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                                    CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                                    CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                                    CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                                    CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                                    CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                                    CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                                    CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                                    CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                                    CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                                    CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                                    CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                                    CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                                    CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                                    CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                                    CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                                    CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                                    CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                                    CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                                    CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                                    (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                    ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                                    FROM PRODUCTION.SRETURN sr
                                                                                    INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                                    LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                                    INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SRDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                                    LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                    LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                                    LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                                    ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE sr.SRHNUM_0 ='" + SRNumber + "';").ToList();
               if (RMAdetailsInfo.Count()>0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       RMAInfo rmaInfo = (RMAInfo)RMAitem;
                       lsRMAInfo.Add(rmaInfo);
                   }
               }
           }
           catch (Exception)
           {}
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by PO Number.
       /// </summary>
       /// <param name="PONumber">
       /// String PO Number.
       /// </param>
       /// <returns>
       /// list of RMAInfo class related to entered PONumber.
       /// </returns>
       public List<RMAInfo> GetRMAInfoByPONumber(String PONumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfo>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                                    so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                                    so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                                    sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                                    bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                                    itm.ITMDES2_0 ProductName, CAST(srd.DLVQTY_0 AS INT) DeliveredQty,
                                                                                    CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                                    CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                                    CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                                    CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                                    CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                                    CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                                    CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                                    CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                                    CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                                    CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                                    CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                                    CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                                    CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                                    CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                                    CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                                    CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                                    CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                                    CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                                    CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                                    CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                                    CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                                    CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                                    (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                    ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                                    FROM PRODUCTION.SRETURN sr
                                                                                    INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                                    LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                                    INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SRDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                                    LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                    LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                                    LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                                    ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE so.CUSORDREF_0 ='" + PONumber + "';").ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       RMAInfo rmaInfo = (RMAInfo)RMAitem;
                       lsRMAInfo.Add(rmaInfo);
                   }
               }
           }
           catch (Exception)
           { }
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by SO Number customer Order number.
       /// </summary>
       /// <param name="SONumber">
       /// string SOnumber .
       /// </param>
       /// <returns>
       /// List of RMA Information class.
       /// </returns>
       public List<RMAInfo> GetRMAInfoBySONumber(String SONumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfo>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                                    so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                                    so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                                    sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                                    bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                                    itm.ITMDES2_0 ProductName, CAST(srd.DLVQTY_0 AS INT) DeliveredQty,
                                                                                    CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                                    CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                                    CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                                    CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                                    CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                                    CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                                    CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                                    CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                                    CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                                    CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                                    CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                                    CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                                    CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                                    CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                                    CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                                    CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                                    CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                                    CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                                    CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                                    CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                                    CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                                    CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                                    (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                    ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                                    FROM PRODUCTION.SRETURN sr
                                                                                    INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                                    LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                                    INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SRDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                                    LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                    LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                                    LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                                    ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE so.SOHNUM_0 ='" + SONumber + "';").ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       RMAInfo rmaInfo = (RMAInfo)RMAitem;
                       lsRMAInfo.Add(rmaInfo);
                   }
               }
           }
           catch (Exception)
           { }
           return lsRMAInfo;
       }

       /// <summary>
       /// Get RMA details from the sage by Shipmen Number.
       /// </summary>
       /// <param name="ShipmentNumber">
       /// string Shipment Number .
       /// </param>
       /// <returns>
       /// List of RMA Information class.
       /// </returns>
       public List<RMAInfo> GetRMAInfoByShipmentNumber(String ShipmentNumber)
       {
           List<RMAInfo> lsRMAInfo = new List<RMAInfo>();
           try
           {
               var RMAdetailsInfo = entX3V6.ExecuteStoreQuery<RMAInfo>(@"SELECT sr.SRHNUM_0 RMANumber, srd.SDHNUM_0 ShipmentNumber,
                                                                                    so.SOHNUM_0 OrderNumber, so.CUSORDREF_0 PONumber,
                                                                                    so.ORDDAT_0 OrderDate, sdh.DLVDAT_0 DeliveryDate,
                                                                                    sr.RTNDAT_0 ReturnDate, sr.BPCORD_0 VendorNumber,
                                                                                    bpc.BPCNAM_0 VendorName, srd.ITMDES1_0 SKUNumber,
                                                                                    itm.ITMDES2_0 ProductName, CAST(srd.DLVQTY_0 AS INT) DeliveredQty,
                                                                                    CAST(srd.EXTQTY_0 AS INT) ExpectedQty, CAST(srd.QTY_0 AS INT) ReturnedQty,
                                                                                    CASE WHEN sr.BPDNAM_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_0 END,
                                                                                    CASE WHEN so.BPCNAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_0 END,
                                                                                    CASE WHEN so.BPINAM_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_0 END),'')) ELSE sr.BPDNAM_0 END CustomerName1,
                                                                                    CASE WHEN sr.BPDNAM_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDNAM_1 END,
                                                                                    CASE WHEN so.BPCNAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCNAM_1 END,
                                                                                    CASE WHEN so.BPINAM_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPINAM_1 END),'')) ELSE sr.BPDNAM_1 END CustomerName2,
                                                                                    CASE WHEN sr.BPDADDLIG_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_0 END,
                                                                                    CASE WHEN so.BPCADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCADDLIG_0 END,
                                                                                    CASE WHEN so.BPIADDLIG_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIADDLIG_0 END),'')) ELSE sr.BPDADDLIG_0 END Address1,
                                                                                    CASE WHEN sr.BPDADDLIG_1 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END,
                                                                                    CASE WHEN so.BPDADDLIG_1 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_1 END),'')) ELSE sr.BPDADDLIG_1 END Address2,
                                                                                    CASE WHEN sr.BPDADDLIG_2 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END,
                                                                                    CASE WHEN so.BPDADDLIG_2 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDADDLIG_2 END),'')) ELSE sr.BPDADDLIG_2 END Address3,
                                                                                    CASE WHEN sr.BPDPOSCOD_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDPOSCOD_0 END,
                                                                                    CASE WHEN so.BPCPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCPOSCOD_0 END,
                                                                                    CASE WHEN so.BPIPOSCOD_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPIPOSCOD_0 END),'')) ELSE sr.BPDPOSCOD_0 END ZipCode,
                                                                                    CASE WHEN sr.BPDCTY_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCTY_0 END,
                                                                                    CASE WHEN so.BPCCTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCTY_0 END,
                                                                                    CASE WHEN so.BPICTY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICTY_0 END),'')) ELSE sr.BPDCTY_0 END City,
                                                                                    CASE WHEN sr.BPDSAT_0 = '' THEN
                                                                                    (ISNULL(COALESCE(CASE WHEN so.BPDSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDSAT_0 END,
                                                                                    CASE WHEN so.BPCSAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCSAT_0 END,
                                                                                    CASE WHEN so.BPISAT_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPISAT_0 END),'')) ELSE sr.BPDSAT_0 END State,
                                                                                    CASE WHEN sr.BPDCRY_0 = '' THEN
                                                                                    (CASE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') WHEN 'UNI' THEN 'US' WHEN 'USA' THEN 'US' WHEN 'CAN' THEN 'CA'
                                                                                    ELSE ISNULL(COALESCE(CASE WHEN so.BPDCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPDCRY_0 END,
                                                                                    CASE WHEN so.BPCCRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPCCRY_0 END,
                                                                                    CASE WHEN so.BPICRY_0 = '' THEN CAST(NULL AS CHAR) ELSE so.BPICRY_0 END),'') END ) ELSE sr.BPDCRY_0 END Country
                                                                                    FROM PRODUCTION.SRETURN sr
                                                                                    INNER JOIN PRODUCTION.SRETURND srd ON sr.SRHNUM_0 = srd.SRHNUM_0
                                                                                    LEFT JOIN PRODUCTION.SDELIVERY sdh ON sdh.SDHNUM_0 = srd.SDHNUM_0
                                                                                    INNER JOIN PRODUCTION.SDELIVERYD sdd ON sdh.SDHNUM_0 = sdd.SDHNUM_0 AND sdd.SDDLIN_0 = srd.SRDLIN_0 AND sdd.LINTYP_0 <> 6
                                                                                    LEFT JOIN PRODUCTION.SORDER so ON so.SOHNUM_0 = sdh.SOHNUM_0
                                                                                    LEFT JOIN PRODUCTION.BPCUSTOMER bpc ON sr.BPCORD_0 = bpc.BPCNUM_0
                                                                                    LEFT JOIN PRODUCTION.ITMMASTER itm
                                                                                    ON itm.ITMREF_0 = srd.ITMREF_0
                                                                                    WHERE srd.SDHNUM_0 ='" + ShipmentNumber + "';").ToList();
               if (RMAdetailsInfo.Count() > 0)
               {
                   foreach (var RMAitem in RMAdetailsInfo)
                   {
                       RMAInfo rmaInfo = (RMAInfo)RMAitem;
                       lsRMAInfo.Add(rmaInfo);
                   }
               }
           }
           catch (Exception)
           { }
           return lsRMAInfo;
       }
    }
}