using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CodeTest.DataModels;
using CodeTest.Model;

namespace CodeTest.DataAccess
{
    public class PaymentDetailsDataAdapter
    {

        public List<PaymentDetailModel> GetPaymentDetailsEntity(string AccountNo)
        {

            List<PaymentDetailModel> PymtModelList = new List<PaymentDetailModel>();

            using (var db = new CodeTestContext())
            {

                var query = from b in db.PaymentDetails.AsEnumerable()
                            where b.AccountNo == AccountNo
                            orderby b.Date descending
                            select b;

                
                //put data into AccountDetailModel
                foreach (var item in query)
                {
                    PaymentDetailModel PymtModel = new PaymentDetailModel();

                    PymtModel.Amount = item.Amount;
                    PymtModel.Date = item.Date;

                    PymtModelList.Add(PymtModel);

                }
                


            }

            return PymtModelList;
        }
    }
}